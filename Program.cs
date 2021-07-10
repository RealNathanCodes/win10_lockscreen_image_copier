using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.MetaData.Profiles.Exif;

namespace lockscreencopier
{
    class Program
    {
        static void Main(string[] args)
        {
            var fromDirectory = @"C:\Users\username\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
            var proposedBackgroundsDirectory = @"C:\Users\username\Desktop\Nathan\proposedBackgrounds";
            var backgroundsDirectory = @"C:\Users\username\Desktop\Nathan\backgrounds";
            var rejectedBackgroundsDirectory = @"C:\Users\username\Desktop\Nathan\rejectedBackgrounds";
            var fromStartIndex = fromDirectory.Length + 1;

            foreach (var fileName in Directory.EnumerateFiles(fromDirectory, "*", SearchOption.AllDirectories))
            {
                // skip files that are too small to likely be desktop backgrounds
                if (new FileInfo(fileName).Length < 10000)
                {
                    continue;
                }

                var testFileName = Path.DirectorySeparatorChar + fileName.Substring(fromStartIndex) + ".jpg";
                var proposedFileName = proposedBackgroundsDirectory + testFileName;
                var backgroundFileName = backgroundsDirectory + testFileName;
                var rejectedBackgroundFileName = rejectedBackgroundsDirectory + testFileName;
                
                // If the file has already been accepted, rejected, or proposed, skip it.
                if (File.Exists(proposedFileName) || File.Exists(backgroundFileName) || File.Exists(rejectedBackgroundFileName))
                {
                    continue;
                }

                // if it isn't a jpeg, skip it
                var format = Image.DetectFormat(fileName);
                if (format.Name != "JPEG")
                {
                    continue;
                }

                using (var image = Image.Load(fileName))
                {
                    // I only wanted 1920x1080p backgrounds
                    if (image.Width == 1920 && image.Height == 1080)
                    {
                        Console.WriteLine($"Copying file {fileName} to {proposedFileName}.");
                        File.Copy(fileName, proposedFileName);
                    }
                }
            }
        }
    }
}

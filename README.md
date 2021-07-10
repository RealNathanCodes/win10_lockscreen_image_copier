# win10_lockscreen_image_copier
This copies images from that have been used as windows 10 lockscreen images to another directory so they can be used as backgrounds

Windows 10 had different lock screen images, some of which I really liked and wanted to use as a desktop image.

I found an article on how to access those lock screen backgrounds and then wrote this little .net core utility
to automate the process I found in the article [https://lifehacker.com/how-to-save-the-windows-10-lock-screen-images-you-like-1768783711](https://lifehacker.com/how-to-save-the-windows-10-lock-screen-images-you-like-1768783711)

There are three folders, a folder full of the backgrounds I decided to keep, those that I have rejected, and those proposed by the utility that I haven't sorted yet.

The workflow I automated is as follows:
* Look for all the files with file sizes big enough to make them likely to be backgrounds
* Check that the file hasn't already been accepted, rejected, or proposed
* ensure that the file is a jpeg
* Ensure that the file matches the dimensions I wanted.
* If the file found passes all of those checks it gets moved to a proposed folder.
From there, whenever I wanted, I would pick my favorites from the proposed and move them to the accepted folder, and all the rest would move to the rejected folder.

I know that keeping the enitre rejected image instead of just a filename, or a hash of the image wastes space, but there weren't that many and they weren't that big so I didn't feel the need to optimize further.

# Build Instructions
```
dotnet build
```

# Runnint Instructions
First build the utility, then place the compiled dll where you want it and run it with 
```
dotnet path\to\the\dll\filename.dll
```
 

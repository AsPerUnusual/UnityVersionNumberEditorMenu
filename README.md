### Editor menu to increment the Unity project version number

A Unity Editor Menu script to quickly increment the project version number and save the project settings.

![Screenshot of the menu in Unity](menuOpenScreenshot.jpg?raw=true)

Thanks to [Warped Imagination on YouTube](https://www.youtube.com/c/WarpedImagination) for tips around building your own Editor utilities.


Installation:

Add the CreateVersionChangeMenu.cs file to the Editor folder in your Assets folder.  

The Editor folder isn't created by default, you will have to add one.

If the script isn't within the Editor folder, Unity won't create a menu item for you.

![Screenshot of Assets/Editor location](putScriptInEditorFolder.png?raw=true)


Additional Details:

The path string in the script can be changed if you have a preferred location instead of a Tools menu.

This script does assume the version number in the Project Settings follows the #.#.# format.

You can change the string in the MenuItem attributes to match your preferences or numbering scheme conventions.


Incrementing by an additional fourth number is included because I have had times where things like expiring certificates required a new version number in MDM systems without any code or content changes.
Adding the extra number worked to satisfy this requirement without changing a version number that indicates more significant changes.

If that isn't something you require and you want a shorter menu you can comment out or remove the MenuItem attribute for the ChangeWasSuperSmall() function.


I left Debug.Log statements showing the changed version number active for user feedback without workflow interruption.
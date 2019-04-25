# TextureImportProcessor

### Automatically configures texture file settings on import

Works on Unity 2018.3 and previous versions. 
_Code has obsolete warnings!_

![Example](https://i.imgur.com/32uiTyR.jpg)

__Currently configured to:__
* Android Override
* Max Size: 2048
* Compression ETC2 RGBA8
* Compression Quality: Best (100)
* Convert to normal map if file name contains "Normal"

### Instructions

Script must be placed inside folder named __Editor__ (Doesn't have to be a root folder)

Script will print to the console when it runs

In case you want to change existing textures, you can open the editor and change `OnImportOnly` to _false_. 
Reimport textures you want to effect. I wouldn't recommend using __Reimport All__ as it takes a long time.
Remember to set `OnImportOnly` back to _true_, or else your changes to textures will always be overwritten by this script.

using UnityEngine;
using UnityEditor;

/// <summary>
/// Sets textures to following specifications:
/// Platform: Android
/// Texture size: 2048
/// Compression: Compressed DXT1 (Not compatible with alpha textures)
/// Compression: Best Quality
/// Converts texture with the word "Normal" in it's filename
/// 
/// Change 'OnImportOnly' to true to affect imports only, otherwise apply settings to EVERY texture
/// 
/// </summary>
class TexturePostprocessor : AssetPostprocessor
{
    const bool OnImportOnly = true;

    void OnPreprocessTexture()
    {
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        Object asset = AssetDatabase.LoadAssetAtPath(textureImporter.assetPath, typeof(Texture2D));

        if (asset && OnImportOnly)
            return;

        Debug.Log("VRVision Texture Processing running");

        textureImporter.SetPlatformTextureSettings("Android", 2048, TextureImporterFormat.ETC2_RGBA8, 100, false);

        if (assetPath.Contains("Normal"))
            textureImporter.normalmap = true;
    }
}
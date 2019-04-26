using UnityEngine;
using UnityEditor;

/// <summary>
/// Sets textures to following specifications:
/// Platform: Android
/// Texture size: 2048
/// Compression: Compressed ETC2 RGBA8
/// Compression: Worst (0)
/// Converts to normalmap if the word "Normal" is in its filename
/// 
/// Set 'OnImportOnly' to true to affect imports only, otherwise this will overwrite settings you actively apply on textures
/// 
/// </summary>
class TexturePostprocessor : AssetPostprocessor
{
	const bool OnImportOnly = false;
	const int CompressionQuality = 0; // 0 for fastest compressing, 100 for best quality

	void OnPreprocessTexture()
	{
		TextureImporter textureImporter = (TextureImporter) assetImporter;
		Object asset = AssetDatabase.LoadAssetAtPath(textureImporter.assetPath, typeof(Texture2D));

		if (asset && OnImportOnly)
			return;

		if (OnImportOnly)
			Debug.Log("Texture Processing running");
		else
			Debug.LogWarning("Texture Processing overwriting settings on existing textures. This will prevent you from applying your own texture settings!");

		textureImporter.SetPlatformTextureSettings("Android", 2048, TextureImporterFormat.ETC2_RGBA8, CompressionQuality, false);

		if (assetPath.Contains("Normal"))
			textureImporter.normalmap = true;
	}
}

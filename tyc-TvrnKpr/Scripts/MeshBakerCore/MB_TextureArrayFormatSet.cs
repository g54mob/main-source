using System;
using DigitalOpus.MB.Core;
using UnityEngine;

[Serializable]
public class MB_TextureArrayFormatSet
{
	public string name;

	public TextureFormat defaultFormat;

	[Tooltip("The ammount of time Unity takes exploring different compression options to find the compressed version of a texture that most closely matches the original art.This is only used For iOS (and some Android formats)")]
	public MB_TextureCompressionQuality defaultCompressionQuality;

	[NonReorderable]
	public MB_TextureArrayFormat[] formatOverrides;

	public bool ValidateTextureImporterFormatsExistsForTextureFormats(MB2_EditorMethodsInterface editorMethods, int idx)
	{
		return false;
	}

	public TextureFormat GetFormatForProperty(string propName, out MB_TextureCompressionQuality compressionQuality)
	{
		compressionQuality = default(MB_TextureCompressionQuality);
		return default(TextureFormat);
	}
}

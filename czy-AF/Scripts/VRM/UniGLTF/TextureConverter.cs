using System.Linq;
using UnityEngine;

namespace UniGLTF
{
	public static class TextureConverter
	{
		public delegate Color32 ColorConversion(Color32 color);

		public static Texture2D Convert(Texture2D texture, glTFTextureTypes textureType, ColorConversion colorConversion, Material convertMaterial)
		{
			Texture2D texture2D = TextureItem.CopyTexture(texture, TextureIO.GetColorSpace(textureType), convertMaterial);
			if (colorConversion != null)
			{
				texture2D.SetPixels32((from x in texture2D.GetPixels32()
					select colorConversion(x)).ToArray());
				texture2D.Apply();
			}
			texture2D.name = texture.name;
			return texture2D;
		}

		public static void AppendTextureExtension(Texture texture, string extension)
		{
			if (!texture.name.EndsWith(extension))
			{
				texture.name += extension;
			}
		}

		public static void RemoveTextureExtension(Texture texture, string extension)
		{
			if (texture.name.EndsWith(extension))
			{
				texture.name = texture.name.Replace(extension, "");
			}
		}
	}
}

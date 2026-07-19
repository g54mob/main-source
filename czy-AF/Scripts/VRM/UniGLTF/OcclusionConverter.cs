using UnityEngine;

namespace UniGLTF
{
	public class OcclusionConverter : ITextureConverter
	{
		private const string m_extension = ".occlusion";

		public Texture2D GetImportTexture(Texture2D texture)
		{
			Texture2D texture2D = TextureConverter.Convert(texture, glTFTextureTypes.Occlusion, Import, null);
			TextureConverter.AppendTextureExtension(texture2D, ".occlusion");
			return texture2D;
		}

		public Texture2D GetExportTexture(Texture2D texture)
		{
			Texture2D texture2D = TextureConverter.Convert(texture, glTFTextureTypes.Occlusion, Export, null);
			TextureConverter.RemoveTextureExtension(texture2D, ".occlusion");
			return texture2D;
		}

		public Color32 Import(Color32 src)
		{
			return new Color32
			{
				r = 0,
				g = src.r,
				b = 0,
				a = byte.MaxValue
			};
		}

		public Color32 Export(Color32 src)
		{
			return new Color32
			{
				r = src.g,
				g = 0,
				b = 0,
				a = byte.MaxValue
			};
		}
	}
}

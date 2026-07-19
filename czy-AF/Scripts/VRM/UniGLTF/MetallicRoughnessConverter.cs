using UnityEngine;

namespace UniGLTF
{
	public class MetallicRoughnessConverter : ITextureConverter
	{
		private const string m_extension = ".metallicRoughness";

		private float _smoothnessOrRoughness;

		public MetallicRoughnessConverter(float smoothnessOrRoughness)
		{
			_smoothnessOrRoughness = smoothnessOrRoughness;
		}

		public Texture2D GetImportTexture(Texture2D texture)
		{
			Texture2D texture2D = TextureConverter.Convert(texture, glTFTextureTypes.Metallic, Import, null);
			TextureConverter.AppendTextureExtension(texture2D, ".metallicRoughness");
			return texture2D;
		}

		public Texture2D GetExportTexture(Texture2D texture)
		{
			Texture2D texture2D = TextureConverter.Convert(texture, glTFTextureTypes.Metallic, Export, null);
			TextureConverter.RemoveTextureExtension(texture2D, ".metallicRoughness");
			return texture2D;
		}

		public Color32 Import(Color32 src)
		{
			float f = (float)(int)src.g * _smoothnessOrRoughness / 255f;
			float num = 1f - Mathf.Sqrt(f);
			return new Color32
			{
				r = src.b,
				g = 0,
				b = 0,
				a = (byte)Mathf.Clamp(num * 255f, 0f, 255f)
			};
		}

		public Color32 Export(Color32 src)
		{
			float num = (float)(int)src.a * _smoothnessOrRoughness / 255f;
			float num2 = 1f - num;
			float num3 = num2 * num2;
			return new Color32
			{
				r = 0,
				g = (byte)Mathf.Clamp(num3 * 255f, 0f, 255f),
				b = src.r,
				a = byte.MaxValue
			};
		}
	}
}

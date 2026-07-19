using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniGLTF
{
	public static class TextureSamplerUtil
	{
		public enum TextureWrapType
		{
			All = 0,
			U = 1,
			V = 2,
			W = 3
		}

		public static KeyValuePair<TextureWrapType, TextureWrapMode> TypeWithMode(TextureWrapType type, TextureWrapMode mode)
		{
			return new KeyValuePair<TextureWrapType, TextureWrapMode>(type, mode);
		}

		public static IEnumerable<KeyValuePair<TextureWrapType, TextureWrapMode>> GetUnityWrapMode(glTFTextureSampler sampler)
		{
			if (sampler.wrapS == sampler.wrapT)
			{
				switch (sampler.wrapS)
				{
				case glWrap.NONE:
					yield return TypeWithMode(TextureWrapType.All, TextureWrapMode.Repeat);
					break;
				case glWrap.CLAMP_TO_EDGE:
					yield return TypeWithMode(TextureWrapType.All, TextureWrapMode.Clamp);
					break;
				case glWrap.REPEAT:
					yield return TypeWithMode(TextureWrapType.All, TextureWrapMode.Repeat);
					break;
				case glWrap.MIRRORED_REPEAT:
					yield return TypeWithMode(TextureWrapType.All, TextureWrapMode.Mirror);
					break;
				default:
					throw new NotImplementedException();
				}
				yield break;
			}
			switch (sampler.wrapS)
			{
			case glWrap.NONE:
				yield return TypeWithMode(TextureWrapType.U, TextureWrapMode.Repeat);
				break;
			case glWrap.CLAMP_TO_EDGE:
				yield return TypeWithMode(TextureWrapType.U, TextureWrapMode.Clamp);
				break;
			case glWrap.REPEAT:
				yield return TypeWithMode(TextureWrapType.U, TextureWrapMode.Repeat);
				break;
			case glWrap.MIRRORED_REPEAT:
				yield return TypeWithMode(TextureWrapType.U, TextureWrapMode.Mirror);
				break;
			default:
				throw new NotImplementedException();
			}
			switch (sampler.wrapT)
			{
			case glWrap.NONE:
				yield return TypeWithMode(TextureWrapType.V, TextureWrapMode.Repeat);
				break;
			case glWrap.CLAMP_TO_EDGE:
				yield return TypeWithMode(TextureWrapType.V, TextureWrapMode.Clamp);
				break;
			case glWrap.REPEAT:
				yield return TypeWithMode(TextureWrapType.V, TextureWrapMode.Repeat);
				break;
			case glWrap.MIRRORED_REPEAT:
				yield return TypeWithMode(TextureWrapType.V, TextureWrapMode.Mirror);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public static FilterMode ImportFilterMode(glFilter filterMode)
		{
			switch (filterMode)
			{
			case glFilter.NEAREST:
			case glFilter.NEAREST_MIPMAP_NEAREST:
			case glFilter.NEAREST_MIPMAP_LINEAR:
				return FilterMode.Point;
			case glFilter.NONE:
			case glFilter.LINEAR:
			case glFilter.LINEAR_MIPMAP_NEAREST:
				return FilterMode.Bilinear;
			case glFilter.LINEAR_MIPMAP_LINEAR:
				return FilterMode.Trilinear;
			default:
				throw new NotImplementedException();
			}
		}

		public static void SetSampler(Texture2D texture, glTFTextureSampler sampler)
		{
			if (texture == null)
			{
				return;
			}
			foreach (KeyValuePair<TextureWrapType, TextureWrapMode> item in GetUnityWrapMode(sampler))
			{
				switch (item.Key)
				{
				case TextureWrapType.All:
					texture.wrapMode = item.Value;
					break;
				case TextureWrapType.U:
					texture.wrapModeU = item.Value;
					break;
				case TextureWrapType.V:
					texture.wrapModeV = item.Value;
					break;
				case TextureWrapType.W:
					texture.wrapModeW = item.Value;
					break;
				default:
					throw new NotImplementedException();
				}
			}
			texture.filterMode = ImportFilterMode(sampler.minFilter);
		}

		public static glFilter ExportFilterMode(Texture texture)
		{
			return texture.filterMode switch
			{
				FilterMode.Point => glFilter.NEAREST, 
				FilterMode.Bilinear => glFilter.LINEAR, 
				FilterMode.Trilinear => glFilter.LINEAR_MIPMAP_LINEAR, 
				_ => throw new NotImplementedException(), 
			};
		}

		public static TextureWrapMode GetWrapS(Texture texture)
		{
			return texture.wrapModeU;
		}

		public static TextureWrapMode GetWrapT(Texture texture)
		{
			return texture.wrapModeV;
		}

		public static glWrap ExportWrapMode(TextureWrapMode wrapMode)
		{
			switch (wrapMode)
			{
			case TextureWrapMode.Clamp:
				return glWrap.CLAMP_TO_EDGE;
			case (TextureWrapMode)(-1):
			case TextureWrapMode.Repeat:
				return glWrap.REPEAT;
			case TextureWrapMode.Mirror:
			case TextureWrapMode.MirrorOnce:
				return glWrap.MIRRORED_REPEAT;
			default:
				throw new NotImplementedException();
			}
		}

		public static glTFTextureSampler Export(Texture texture)
		{
			glFilter glFilter2 = ExportFilterMode(texture);
			glWrap wrapS = ExportWrapMode(GetWrapS(texture));
			glWrap wrapT = ExportWrapMode(GetWrapT(texture));
			return new glTFTextureSampler
			{
				magFilter = glFilter2,
				minFilter = glFilter2,
				wrapS = wrapS,
				wrapT = wrapT
			};
		}
	}
}

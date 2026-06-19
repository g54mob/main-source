using System;
using UnityEngine;

namespace Pug.Sprite
{
	[Serializable]
	public class SpriteData
	{
		[Serializable]
		public class PositionalData
		{
			public Vector3[] frames;

			public PositionalData(PositionalData other)
			{
				if (other.frames != null)
				{
					other.frames = new Vector3[other.frames.Length];
					for (int i = 0; i < other.frames.Length; i++)
					{
						frames[i] = other.frames[i];
					}
				}
				else
				{
					frames = null;
				}
			}
		}

		public Texture2D texture;

		public Texture2D emissiveTexture;

		public Texture2D normalTexture;

		public Vector2 pivot;

		public PositionalData[] positionalData;

		public bool inheritPivot;

		public bool hasAnyTexture
		{
			get
			{
				if (!(texture != null) && !(emissiveTexture != null))
				{
					return normalTexture != null;
				}
				return true;
			}
		}

		public SpriteData()
		{
			texture = null;
			emissiveTexture = null;
			normalTexture = null;
			pivot = Vector2.one * 0.5f;
			positionalData = null;
			inheritPivot = true;
		}

		public SpriteData(Texture2D texture)
		{
			this.texture = texture;
			emissiveTexture = null;
			normalTexture = null;
			pivot = Vector2.one * 0.5f;
			positionalData = null;
			inheritPivot = true;
		}

		public SpriteData(Texture2D texture, Texture2D emissiveTexture)
		{
			this.texture = texture;
			this.emissiveTexture = emissiveTexture;
			normalTexture = null;
			pivot = Vector2.one * 0.5f;
			positionalData = null;
			inheritPivot = true;
		}

		public SpriteData(Texture2D texture, Texture2D emissiveTexture, Texture2D normalTexture)
		{
			this.texture = texture;
			this.emissiveTexture = emissiveTexture;
			this.normalTexture = normalTexture;
			pivot = Vector2.one * 0.5f;
			positionalData = null;
			inheritPivot = true;
		}

		public SpriteData(SpriteData other)
		{
			texture = other.texture;
			emissiveTexture = other.emissiveTexture;
			normalTexture = other.normalTexture;
			pivot = other.pivot;
			if (other.positionalData != null)
			{
				positionalData = new PositionalData[other.positionalData.Length];
				for (int i = 0; i < other.positionalData.Length; i++)
				{
					positionalData[i] = other.positionalData[i];
				}
			}
			else
			{
				positionalData = null;
			}
			inheritPivot = other.inheritPivot;
		}

		public Texture2D GetSrcTexture()
		{
			if (texture != null)
			{
				return texture;
			}
			if (emissiveTexture != null)
			{
				return emissiveTexture;
			}
			if (normalTexture != null)
			{
				return normalTexture;
			}
			return null;
		}

		public string GetAssetName()
		{
			return SpriteAsset.GetAssetName(texture, emissiveTexture, normalTexture);
		}

		public string GetName(FrameAnimation animation)
		{
			string assetName = SpriteAsset.GetAssetName(animation.spriteData.texture, animation.spriteData.emissiveTexture, animation.spriteData.normalTexture);
			return SpriteAsset.PrettifyName(SpriteAsset.GetAssetName(texture, emissiveTexture, normalTexture), assetName);
		}

		public string GetName(SpriteAsset spriteAsset)
		{
			return SpriteAsset.PrettifyName(SpriteAsset.GetAssetName(texture, emissiveTexture, normalTexture), spriteAsset.name);
		}

		public void ReleaseSourceAssets()
		{
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
				texture = null;
			}
			if (emissiveTexture != null)
			{
				Resources.UnloadAsset(emissiveTexture);
				emissiveTexture = null;
			}
			if (normalTexture != null)
			{
				Resources.UnloadAsset(normalTexture);
				normalTexture = null;
			}
		}

		public Texture2D RenderEditorPreview(int width, int height, int frameCount, GradientMapDataBlock gradientMap1, GradientMapDataBlock gradientMap2, GradientMapDataBlock gradientMap3, bool hideEmissive = false)
		{
			return null;
		}
	}
}

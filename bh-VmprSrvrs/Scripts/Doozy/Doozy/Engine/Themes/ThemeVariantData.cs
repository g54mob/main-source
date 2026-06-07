using System;
using System.Collections.Generic;
using UnityEngine;

namespace Doozy.Engine.Themes
{
	[Serializable]
	public class ThemeVariantData : ISerializationCallbackReceiver
	{
		public const string DEFAULT_THEME_VARIANT_NAME = "Unnamed Variant";

		[SerializeField]
		private string m_variantName;

		[SerializeField]
		private byte[] SerializedGuid;

		[SerializeField]
		private Guid m_id;

		public List<ColorId> Colors;

		public List<SpriteId> Sprites;

		public List<TextureId> Textures;

		public List<FontId> Fonts;

		public List<FontAssetId> FontAssets;

		public static Color DefaultColor => default(Color);

		public static Sprite DefaultSprite => null;

		public static Texture DefaultTexture => null;

		public static Font DefaultFont => null;

		public Guid Id => default(Guid);

		public string VariantName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ThemeVariantData()
		{
		}

		public ThemeVariantData(string variantName)
		{
		}

		public ThemeVariantData(string variantName, List<LabelId> colorLabels, List<LabelId> spriteLabels, List<LabelId> textureLabels, List<LabelId> fontLabels, List<LabelId> fontAssetLabels)
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public void AddColorProperty(Guid guid)
		{
		}

		public void AddColorProperty(Guid guid, Color color)
		{
		}

		public bool ContainsColor(Guid propertyId)
		{
			return false;
		}

		public Color GetColor(Guid propertyId)
		{
			return default(Color);
		}

		public void AddSpriteProperty(Guid guid)
		{
		}

		public void AddSpriteProperty(Guid guid, Sprite sprite)
		{
		}

		public bool ContainsSprite(Guid propertyId)
		{
			return false;
		}

		public Sprite GetSprite(Guid propertyId)
		{
			return null;
		}

		public void AddTextureProperty(Guid guid)
		{
		}

		public void AddTextureProperty(Guid guid, Texture texture)
		{
		}

		public bool ContainsTexture(Guid propertyId)
		{
			return false;
		}

		public Texture GetTexture(Guid propertyId)
		{
			return null;
		}

		public void AddFontProperty(Guid guid)
		{
		}

		public void AddFontProperty(Guid guid, Font font)
		{
		}

		public bool ContainsFont(Guid propertyId)
		{
			return false;
		}

		public Font GetFont(Guid propertyId)
		{
			return null;
		}

		private void SyncColorIdsToLabelIds(List<LabelId> colorLabels)
		{
		}

		private void SyncSpriteIdsToLabelIds(List<LabelId> spriteLabels)
		{
		}

		private void SyncTextureIdsToLabelIds(List<LabelId> textureLabels)
		{
		}

		private void SyncFontIdsToLabelIds(List<LabelId> fontLabels)
		{
		}

		private void SyncFontAssetIdsToLabelIds(List<LabelId> fontAssetLabels)
		{
		}
	}
}

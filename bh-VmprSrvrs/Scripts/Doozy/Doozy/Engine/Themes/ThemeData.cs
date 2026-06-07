using System;
using System.Collections.Generic;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Themes
{
	[Serializable]
	public class ThemeData : ScriptableObject, ISerializationCallbackReceiver
	{
		public const string UNNAMED_THEME_NAME = "Unnamed Theme";

		public const string UNNAMED_VARIANT_NAME = "Unnamed Variant";

		public const string UNNAMED_PROPERTY = "Unnamed Property";

		public const string DEFAULT_VARIANT_NAME = "Default";

		[SerializeField]
		private string m_themeName;

		[SerializeField]
		private byte[] SerializedGuid;

		[SerializeField]
		private Guid m_id;

		[SerializeField]
		private ThemeVariantData m_activeVariant;

		public List<LabelId> ColorLabels;

		public List<LabelId> SpriteLabels;

		public List<LabelId> TextureLabels;

		public List<LabelId> FontLabels;

		public List<LabelId> FontAssetLabels;

		public List<string> VariantsNames;

		public List<ThemeVariantData> Variants;

		private const string COLOR_DEFAULT_COLOR_LABEL_1 = "Primary";

		private const string COLOR_DEFAULT_COLOR_LABEL_2 = "Secondary";

		private const string COLOR_DEFAULT_COLOR_LABEL_3 = "Accent 1";

		private const string COLOR_DEFAULT_COLOR_LABEL_4 = "Accent 2";

		private const string COLOR_DEFAULT_COLOR_LABEL_5 = "Text";

		private const string COLOR_DEFAULT_COLOR_LABEL_6 = "Disabled";

		private static UILanguagePack UILabels => null;

		public ThemeVariantData ActiveVariant => null;

		public Guid Id => default(Guid);

		public string ThemeName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsGeneralTheme => false;

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public void ActivateVariant(ThemeVariantData variant)
		{
		}

		public void ActivateVariant(Guid variantId)
		{
		}

		public void ActivateVariant(string variantName)
		{
		}

		public void AddColorProperty(bool performUndo, bool saveAssets = false)
		{
		}

		public void AddSpriteProperty(bool performUndo, bool saveAssets = false)
		{
		}

		public void AddTextureProperty(bool performUndo, bool saveAssets = false)
		{
		}

		public void AddFontProperty(bool performUndo, bool saveAssets = false)
		{
		}

		public void AddFontAssetProperty(bool performUndo, bool saveAssets = false)
		{
		}

		public void AddVariant(bool performUndo, bool saveAssets = false)
		{
		}

		public bool ContainsColorProperty(Guid propertyId)
		{
			return false;
		}

		public bool ContainsSpriteProperty(Guid propertyId)
		{
			return false;
		}

		public bool ContainsTextureProperty(Guid propertyId)
		{
			return false;
		}

		public bool ContainsFontProperty(Guid propertyId)
		{
			return false;
		}

		public bool ContainsFontAssetProperty(Guid propertyId)
		{
			return false;
		}

		public bool ContainsVariant(Guid variantGuid)
		{
			return false;
		}

		public bool ContainsVariant(string variantName)
		{
			return false;
		}

		public ThemeVariantData GetVariant(Guid variantId)
		{
			return null;
		}

		public ThemeVariantData GetVariant(string variantName)
		{
			return null;
		}

		public int GetColorPropertyIndex(Guid id)
		{
			return 0;
		}

		public int GetSpritePropertyIndex(Guid id)
		{
			return 0;
		}

		public int GetTexturePropertyIndex(Guid id)
		{
			return 0;
		}

		public int GetFontPropertyIndex(Guid id)
		{
			return 0;
		}

		public int GetFontAssetPropertyIndex(Guid id)
		{
			return 0;
		}

		public int GetVariantIndex(Guid id)
		{
			return 0;
		}

		public void Init(bool showProgress, bool saveAssets)
		{
		}

		public void RemoveColorProperty(Guid deleteGuid, bool performUndo, bool saveAssets)
		{
		}

		public void RemoveSpriteProperty(Guid deleteGuid, bool performUndo, bool saveAssets)
		{
		}

		public void RemoveTextureProperty(Guid deleteGuid, bool performUndo, bool saveAssets)
		{
		}

		public void RemoveFontProperty(Guid deleteGuid, bool performUndo, bool saveAssets)
		{
		}

		public void RemoveFontAssetProperty(Guid deleteGuid, bool performUndo, bool saveAssets)
		{
		}

		public void RefreshThemeVariants(bool showProgress, bool performUndo, bool saveAssets)
		{
		}

		public bool RemoveVariant(ThemeVariantData data, bool performUndo = false, bool showDialog = false, bool saveAssets = false)
		{
			return false;
		}

		public void SetDirty(bool saveAssets)
		{
		}

		public void Sort(bool performUndo, bool saveAssets)
		{
		}

		public void UndoRecord(string undoMessage)
		{
		}

		public void UpdateVariantsNames(bool saveAssets)
		{
		}

		private void AddDefaultColorLabels()
		{
		}

		private bool AddDefaultVariant(bool saveAssets = false)
		{
			return false;
		}

		private static int GetPropertyIndex(Guid id, List<LabelId> propertyList)
		{
			return 0;
		}

		private static void RemoveProperty(Guid deleteGuid, List<LabelId> propertyList)
		{
		}
	}
}

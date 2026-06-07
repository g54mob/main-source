using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Assets.Scripts.UI.Dialogs;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Decal")]
	public class TextureDecalData : DecalData, ICraftTextureDecal, ICraftDecal, ITexturePropertyHandler
	{
		private static class ShaderPropertyIds
		{
			public static readonly int BaseColor = Shader.PropertyToID("_BaseColor");

			public static readonly int BaseMap = Shader.PropertyToID("_BaseMap");

			public static readonly int DrawOrder = Shader.PropertyToID("_DrawOrder");
		}

		public const string DecalIdDesignerPropertyName = "_decalId";

		private const int InstancingRendererCountThreshold = 1;

		private CraftDecalData _decalData;

		[DesignerPropertyTexture(Label = "Texture", Order = 1)]
		private string _decalId;

		private int _decalRendererCount;

		private Material _material;

		private TextureDecalScript _script;

		private Texture2D _texture;

		private Vector2 _textureOffset;

		private Vector2 _textureTiling;

		public CraftDecalData CraftDecalData
		{
			get
			{
				return _decalData;
			}
			set
			{
				_decalId = value?.Id ?? "Default";
				if (_decalData != value)
				{
					_decalData = value;
					_texture = Game.Instance.CraftDecalManager.GetDecalTexture(value.Id);
					OnMaterialPropertiesChanged();
					SetDirty();
				}
			}
		}

		public override CraftDecalType DecalType => CraftDecalType.Texture;

		public override Vector3 Size
		{
			get
			{
				return Vector3.Scale(base.Size, new Vector3(CraftDecalData.AspectRatio, 1f, 1f));
			}
			set
			{
				base.Size = value;
			}
		}

		public Texture2D Texture => _texture;

		[DesignerPropertyVector(0.1f, -1f, 1f, Label = "Offset", Order = 30)]
		public Vector2 TextureOffset
		{
			get
			{
				return _textureOffset;
			}
			set
			{
				if (!Utilities.CompareVector2s(_textureOffset, value, 0.001f))
				{
					_textureOffset = value;
					SetDirty();
				}
			}
		}

		[DesignerPropertyVector(1f, -100f, 100f, Label = "Tiling", Order = 31)]
		public Vector2 TextureTiling
		{
			get
			{
				return _textureTiling;
			}
			set
			{
				if (!Utilities.CompareVector2s(_textureTiling, value, 0.001f))
				{
					_textureTiling = value;
					SetDirty();
				}
			}
		}

		public TextureDecalData(XElement element)
			: base(element)
		{
			_textureTiling = Vector2.one;
			_textureOffset = Vector2.zero;
			CraftDecalData = Game.Instance.CraftDecalManager.CraftDecals.Skip(1).FirstOrDefault() ?? CraftDecalData.Default;
		}

		public IEnumerable<TexturePickerItem> CreateItemsForTexturePicker(IConfigurableProperty property)
		{
			List<TexturePickerItem> list = new List<TexturePickerItem>();
			CraftDecalManager decalManager = Game.Instance.CraftDecalManager;
			foreach (CraftDecalData decal in decalManager.CraftDecals)
			{
				list.Add(new TexturePickerItem(decal.Id, () => decalManager.GetDecalTexture(decal.Id), decal.Category, decal.DisplayName));
			}
			return list;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("decalId", _decalId);
			xElement.SetAttribute("tiling", _textureTiling);
			xElement.SetAttribute("offset", _textureOffset);
			return xElement;
		}

		public Texture2D GetPreviewTexture(IConfigurableProperty property)
		{
			return _texture;
		}

		public override object GetSymmetricValue(string propertyName, int symmetricPartCount, PartModifierData sourceModifier, object sourceValue)
		{
			if (symmetricPartCount == 2 && propertyName == "TextureTiling")
			{
				Vector2 vector = (Vector2)sourceValue;
				return new Vector2(0f - vector.x, vector.y);
			}
			return base.GetSymmetricValue(propertyName, symmetricPartCount, sourceModifier, sourceValue);
		}

		public void OnTextureSelected(TexturePickerItem item)
		{
			if (item != null)
			{
				CraftDecalData = Game.Instance.CraftDecalManager.GetDecalData(item.Id);
				_script.OnDecalPropertiesUpdated();
			}
		}

		public void ReleaseDecalMaterial(Material material)
		{
			_decalRendererCount--;
			OnDecalRendererCountChanged();
		}

		public Material RequestDecalMaterial()
		{
			if (_decalRendererCount == 0)
			{
				_material = Game.Instance.ResourceLoader.InstantiateMaterial("Craft/Parts/Materials/PartDecalMaterial");
				UpdateMaterial();
			}
			_decalRendererCount++;
			OnDecalRendererCountChanged();
			return _material;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_decalId = stateElement.GetStringAttribute("decalId");
			CraftDecalData decalData = Game.Instance.CraftDecalManager.GetDecalData(_decalId);
			if (decalData == null)
			{
				Debug.LogError("Unable to find craft decal with id '" + _decalId + "'");
				CraftDecalData = Game.Instance.CraftDecalManager.CraftDecals.Skip(1).FirstOrDefault();
			}
			else
			{
				CraftDecalData = decalData;
			}
			_textureTiling = stateElement.GetVector2Attribute("tiling", Vector2.one);
			_textureOffset = stateElement.GetVector2Attribute("offset", Vector2.zero);
		}

		protected override DecalScript CreateAndInitializeScript(GameObject gameObject)
		{
			_script = gameObject.AddComponent<TextureDecalScript>();
			_script.Initialize(this);
			return _script;
		}

		protected override void OnMaterialPropertiesChanged()
		{
			base.OnMaterialPropertiesChanged();
			UpdateMaterial();
		}

		private void OnDecalRendererCountChanged()
		{
			if (_decalRendererCount < 0)
			{
				Debug.LogError($"Craft decal renderer count is currently less than zero ({_decalRendererCount}). Something is broken...");
				_decalRendererCount = 0;
			}
			if (_decalRendererCount == 0)
			{
				if (_material != null)
				{
					Object.Destroy(_material);
					_material = null;
				}
			}
			else if (_material != null)
			{
				bool flag = _decalRendererCount >= 1;
				if (_material.enableInstancing != flag)
				{
					_material.enableInstancing = flag;
				}
			}
		}

		private void UpdateMaterial()
		{
			if ((object)_material != null)
			{
				_material.SetTexture(ShaderPropertyIds.BaseMap, _texture);
				_material.SetColor(ShaderPropertyIds.BaseColor, new Color(base.TintColor.r, base.TintColor.g, base.TintColor.b, base.TintColor.a * base.Opacity * base.Opacity));
				_material.SetFloat(ShaderPropertyIds.DrawOrder, base.RenderPriority);
			}
		}
	}
}

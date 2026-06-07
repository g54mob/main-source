using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Paint;
using Jundroo.Juicy.Widgets;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.UI.Paint
{
	public class TexturePreviewScript : MonoBehaviour
	{
		private Graphic _graphic;

		private Material _material;

		private bool _update;

		public PaintColorData[] ColorData { get; set; }

		public PaintStyle? PaintStyle { get; set; }

		public PaintTextureData Texture { get; set; }

		public void InitializeMaterial(PartMaterial partMaterial)
		{
			ColorData = partMaterial?.ColorData;
			PaintStyle = partMaterial?.Style;
			Texture = partMaterial?.Texture;
			if (_graphic == null)
			{
				_graphic = GetComponent<ImageWidget>()?.Image;
				if (_graphic == null)
				{
					_graphic = GetComponent<RawImageWidget>()?.Image;
				}
				_material = Game.Instance.ResourceLoader.InstantiateMaterial("Craft/Parts/Materials/UI.PartMaterial");
				_graphic.material = _material;
				_graphic.RegisterDirtyMaterialCallback(OnMaterialDirty);
			}
			_update = true;
		}

		public void UpdateMaterial()
		{
			_update = true;
		}

		protected virtual void Awake()
		{
			base.gameObject.AddComponent<ColorButtonMeshModifier>();
		}

		protected virtual void OnDestroy()
		{
			if (_graphic != null)
			{
				_graphic.UnregisterDirtyMaterialCallback(OnMaterialDirty);
			}
			if (_material != null)
			{
				Object.Destroy(_material);
			}
		}

		protected virtual void Update()
		{
			if (_update)
			{
				_update = false;
				_graphic.SetMaterialDirty();
			}
		}

		private void OnMaterialDirty()
		{
			if (PaintStyle.HasValue && ColorData != null)
			{
				PaintColorData[] colorData = ColorData;
				PaintStyle? paintStyle = PaintStyle;
				int num = Texture?.TextureIndex ?? 0;
				Texture2DArray textureArray = Game.Instance.PaintTextureManager.GetTextureArray(paintStyle.Value);
				PaintTextureData texture = Texture;
				float value = ((texture == null || texture.NormalizationFlags.HasFlag(PaintTextureMaskNormalizationFlags.NormalizeColorMask)) ? 1f : 0f);
				int num2 = (((Texture?.ColorCount ?? 1) >= 4) ? 1 : 0);
				Material materialForRendering = _graphic.materialForRendering;
				materialForRendering.SetColor("_PartColor1", colorData[0].Color);
				materialForRendering.SetColor("_PartColor2", colorData[1].Color);
				materialForRendering.SetColor("_PartColor3", colorData[2].Color);
				materialForRendering.SetColor("_PartColor4", colorData[3].Color);
				materialForRendering.SetTexture("_PartTextures", textureArray);
				materialForRendering.SetFloat("_PartTextureIndex", num);
				materialForRendering.SetFloat("_PartTextureNormalizeMask", value);
				materialForRendering.SetFloat("_PartTextureAlphaMask", num2);
				materialForRendering.SetFloat("_PartMaterialStyle", (float)paintStyle.Value);
			}
		}
	}
}

using TMPro;
using Unity.Profiling;
using UnityEngine;
using space.chikalin.textdecal;

namespace Assets.Scripts.Craft.Decals
{
	public class PartMeshDecalText : PartMeshDecalObject
	{
		private static class Profile
		{
			public static readonly ProfilerMarker OnRefreshRenderer = new ProfilerMarker("PartMeshDecalText.OnRefreshRenderer");
		}

		private static class ShaderPropertyIds
		{
			public static readonly int DecalLayerMaskFromDecal = Shader.PropertyToID("_DecalLayerMaskFromDecal");
		}

		private Material _material;

		private RectTransform _rectTransform;

		public RectTransform RectTransform
		{
			get
			{
				return _rectTransform;
			}
			set
			{
				_rectTransform = value;
				base.Transform = value;
			}
		}

		public ICraftTextDecal TextDecal { get; private set; }

		public TextDecal TmpDecal { get; private set; }

		public TextMeshPro TmpText { get; private set; }

		public static PartMeshDecalText Create()
		{
			return PartMeshDecalObject.Create<PartMeshDecalText>();
		}

		protected override void OnCreated()
		{
			base.OnCreated();
			TmpText = base.gameObject.AddComponent<TextMeshPro>();
			TmpDecal = base.gameObject.AddComponent<TextDecal>();
			RectTransform = base.GameObject.GetComponent<RectTransform>();
			TmpText.alignment = TextAlignmentOptions.Center;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			ReleaseMaterial();
		}

		protected override void OnInitializePooledObject(ICraftDecal decal, DecalTargetScript target)
		{
			base.OnInitializePooledObject(decal, target);
			TextDecal = (ICraftTextDecal)decal;
		}

		protected override void OnRefreshRenderer()
		{
			using (Profile.OnRefreshRenderer.Auto())
			{
				base.OnRefreshRenderer();
				ICraftTextDecal textDecal = TextDecal;
				if (!base.DecalTarget.DecalToTargetMatrix.HasValue)
				{
					base.Transform.SetPositionAndRotation(textDecal.CraftPosition, textDecal.CraftRotation);
				}
				else
				{
					Matrix4x4 value = base.DecalTarget.DecalToTargetMatrix.Value;
					base.Transform.SetLocalPositionAndRotation(value.MultiplyPoint3x4(textDecal.CraftPosition), value.rotation * textDecal.CraftRotation);
				}
				RectTransform.sizeDelta = new Vector2(textDecal.Size.x, textDecal.Size.y);
				TmpDecal.settings.projectionDepth = textDecal.Size.z;
				TmpText.text = textDecal.Text;
				TmpText.fontSize = textDecal.FontSize;
				TMP_FontAsset font = textDecal.GetFont();
				if (TmpText.font != font || _material == null)
				{
					ReleaseMaterial();
					_material = Object.Instantiate(textDecal.GetFontMaterial());
					TmpText.font = font;
					TmpText.fontSharedMaterial = _material;
				}
				TmpText.horizontalAlignment = textDecal.HorizontalAlignment;
				TmpText.verticalAlignment = textDecal.VerticalAlignment;
				Color tintColor = textDecal.TintColor;
				tintColor.a = textDecal.Opacity * textDecal.Opacity;
				TmpText.color = tintColor;
				TmpText.sortingOrder = textDecal.RenderPriority;
				uint num = DecalLayers.DecalTargetIdToLayerMask(base.DecalTarget.DecalTargetId);
				_material.SetFloat(ShaderPropertyIds.DecalLayerMaskFromDecal, num);
				TmpDecal.ForceDecalUpdate();
			}
		}

		protected override void OnResetPooledObject()
		{
			base.OnResetPooledObject();
			TextDecal = null;
		}

		private void ReleaseMaterial()
		{
			if (_material != null)
			{
				Object.Destroy(_material);
				_material = null;
			}
		}
	}
}

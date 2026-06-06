using System;
using Coffee.UISoftMaskInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Coffee.UISoftMask
{
	[ExecuteAlways]
	[RequireComponent(typeof(Graphic))]
	[DisallowMultipleComponent]
	public class MaskingShape : UIBehaviour, IMeshModifier, IMaterialModifier, IComparable<MaskingShape>, IMaskable
	{
		public enum MaskingMethod
		{
			Additive = 0,
			Subtract = 1
		}

		[Tooltip("Masking method.")]
		[SerializeField]
		private MaskingMethod m_MaskingMethod;

		[Tooltip("Show the graphic that is associated with the Mask render area.")]
		[SerializeField]
		private bool m_ShowMaskGraphic;

		[Tooltip("The transparent part of the mask cannot be clicked.\nThis can be achieved by enabling Read/Write enabled in the Texture Import Settings for the texture.\n\nNOTE: Enable this only if necessary, as it will require more graphics memory and processing time.")]
		[SerializeField]
		private bool m_AlphaHitTest;

		[Tooltip("The threshold for anti-alias masking.\nThe smaller this value, the less jagged it is.")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_AntiAliasingThreshold;

		[Tooltip("The minimum and maximum alpha values used for soft masking.\nThe larger the gap between these values, the stronger the softness effect.")]
		[SerializeField]
		private MinMax01 m_SoftnessRange = new MinMax01(0f, 1f);

		private bool _antiAliasingRegistered;

		private MaskingShapeContainer _container;

		private Graphic _graphic;

		private Mask _mask;

		private Material _maskMaterial;

		private Mesh _mesh;

		private MaterialPropertyBlock _mpb;

		private Matrix4x4 _prevTransformMatrix;

		private UnityAction _setContainerDirty;

		private bool _shouldRecalculateStencil;

		private int _stencilBits;

		private Action _updateAntiAliasing;

		private UnityAction _updateContainer;

		public Graphic graphic
		{
			get
			{
				if (!_graphic && !TryGetComponent<Graphic>(out _graphic))
				{
					return null;
				}
				return _graphic;
			}
		}

		public bool hasTransformChanged => base.transform.HasChanged(ref _prevTransformMatrix, UISoftMaskProjectSettings.sensitivity);

		public MaskingMethod maskingMethod
		{
			get
			{
				return m_MaskingMethod;
			}
			set
			{
				if (m_MaskingMethod != value)
				{
					m_MaskingMethod = value;
					SetContainerDirty();
					if ((bool)graphic)
					{
						graphic.SetMaterialDirty();
					}
				}
			}
		}

		public bool showMaskGraphic
		{
			get
			{
				return m_ShowMaskGraphic;
			}
			set
			{
				if (m_ShowMaskGraphic != value)
				{
					m_ShowMaskGraphic = value;
					if ((bool)graphic)
					{
						graphic.SetMaterialDirty();
					}
				}
			}
		}

		public bool alphaHitTest
		{
			get
			{
				return m_AlphaHitTest;
			}
			set
			{
				m_AlphaHitTest = value;
			}
		}

		public float antiAliasingThreshold
		{
			get
			{
				return m_AntiAliasingThreshold;
			}
			set
			{
				m_AntiAliasingThreshold = value;
			}
		}

		public MinMax01 softnessRange
		{
			get
			{
				return m_SoftnessRange;
			}
			set
			{
				if (!m_SoftnessRange.Approximately(value))
				{
					m_SoftnessRange = value;
					SetContainerDirty();
				}
			}
		}

		public float alpha
		{
			get
			{
				if (!graphic)
				{
					return 1f;
				}
				return graphic.color.a;
			}
			set
			{
				value = Mathf.Clamp01(value);
				if ((bool)this && !Mathf.Approximately(alpha, value) && (bool)graphic)
				{
					Color color = graphic.color;
					color.a = value;
					graphic.color = color;
				}
			}
		}

		protected override void OnEnable()
		{
			UpdateContainer();
			if ((bool)graphic)
			{
				graphic.RegisterDirtyMaterialCallback(UpdateContainer);
				graphic.RegisterDirtyVerticesCallback(SetContainerDirty);
				graphic.RegisterDirtyLayoutCallback(SetContainerDirty);
				graphic.SetMaterialDirty();
				graphic.SetVerticesDirty();
			}
			RegisterAntiAliasingIfNeeded();
			_shouldRecalculateStencil = true;
		}

		protected override void OnDisable()
		{
			_mask = null;
			StencilMaterial.Remove(_maskMaterial);
			_maskMaterial = null;
			MeshExtensions.Return(ref _mesh);
			SoftMaskUtils.materialPropertyBlockPool.Return(ref _mpb);
			SetContainerDirty();
			UpdateContainer();
			RegisterAntiAliasingIfNeeded();
			if ((bool)graphic)
			{
				graphic.UnregisterDirtyMaterialCallback(UpdateContainer);
				graphic.UnregisterDirtyVerticesCallback(SetContainerDirty);
				graphic.UnregisterDirtyLayoutCallback(SetContainerDirty);
				graphic.SetMaterialDirty();
				graphic.SetVerticesDirty();
			}
		}

		protected override void OnCanvasHierarchyChanged()
		{
			UpdateContainer();
		}

		protected override void OnDidApplyAnimationProperties()
		{
			SetContainerDirty();
		}

		protected override void OnRectTransformDimensionsChange()
		{
			SetContainerDirty();
		}

		protected override void OnTransformParentChanged()
		{
			UpdateContainer();
		}

		int IComparable<MaskingShape>.CompareTo(MaskingShape other)
		{
			if (this == other)
			{
				return 0;
			}
			if (!this && (bool)other)
			{
				return -1;
			}
			if ((bool)this && !other)
			{
				return 1;
			}
			int num = (graphic ? graphic.depth : (-1));
			int num2 = (other.graphic ? other.graphic.depth : (-1));
			if (num != -1 && num2 != -1)
			{
				return num - num2;
			}
			return base.transform.CompareHierarchyIndex(other.transform, _container ? _container.transform : null);
		}

		void IMaskable.RecalculateMasking()
		{
			_shouldRecalculateStencil = true;
			UpdateContainer();
			RegisterAntiAliasingIfNeeded();
		}

		Material IMaterialModifier.GetModifiedMaterial(Material baseMaterial)
		{
			if (!base.isActiveAndEnabled)
			{
				return baseMaterial;
			}
			RecalculateStencilIfNeeded();
			if (_stencilBits == 0 && !_mask)
			{
				StencilMaterial.Remove(_maskMaterial);
				_maskMaterial = null;
				return null;
			}
			Material maskMaterial = null;
			ColorWriteMask colorWriteMask = (m_ShowMaskGraphic ? ColorWriteMask.All : ((ColorWriteMask)0));
			if (SoftMaskingEnabled() && !UISoftMaskProjectSettings.useStencilOutsideScreen)
			{
				if (m_ShowMaskGraphic)
				{
					maskMaterial = StencilMaterial.Add(baseMaterial, _stencilBits, StencilOp.Keep, CompareFunction.Equal, colorWriteMask, _stencilBits, _stencilBits);
				}
			}
			else
			{
				switch (maskingMethod)
				{
				case MaskingMethod.Additive:
					maskMaterial = StencilMaterial.Add(baseMaterial, _stencilBits, StencilOp.Replace, CompareFunction.NotEqual, colorWriteMask, _stencilBits, _stencilBits);
					break;
				case MaskingMethod.Subtract:
					maskMaterial = StencilMaterial.Add(baseMaterial, _stencilBits, StencilOp.Invert, CompareFunction.Equal, colorWriteMask, _stencilBits, _stencilBits);
					break;
				}
			}
			StencilMaterial.Remove(_maskMaterial);
			_maskMaterial = maskMaterial;
			return _maskMaterial;
		}

		void IMeshModifier.ModifyMesh(Mesh mesh)
		{
		}

		void IMeshModifier.ModifyMesh(VertexHelper verts)
		{
			if (base.isActiveAndEnabled)
			{
				if (!_mesh)
				{
					_mesh = MeshExtensions.Rent();
				}
				_mesh.Clear(keepVertexLayout: false);
				verts.FillMesh(_mesh);
				_mesh.RecalculateBounds();
			}
		}

		internal bool SoftMaskingEnabled()
		{
			if (base.isActiveAndEnabled && _mask is SoftMask softMask)
			{
				return softMask.SoftMaskingEnabled();
			}
			return false;
		}

		internal bool AntiAliasingEnabled()
		{
			if (base.isActiveAndEnabled && _mask is SoftMask softMask)
			{
				return softMask.AntiAliasingEnabled();
			}
			return false;
		}

		private void RecalculateStencilIfNeeded()
		{
			if (!base.isActiveAndEnabled)
			{
				_mask = null;
				_stencilBits = 0;
			}
			else if (_shouldRecalculateStencil)
			{
				_shouldRecalculateStencil = false;
				bool useStencilOutsideScreen = UISoftMaskProjectSettings.useStencilOutsideScreen;
				_stencilBits = Utils.GetStencilBits(base.transform, includeSelf: true, useStencilOutsideScreen, out _mask, out var _);
			}
		}

		private void SetContainerDirty()
		{
			if ((bool)_container)
			{
				_container.SetContainerDirty();
			}
		}

		private void UpdateContainer()
		{
			Mask nearestMask = null;
			if (base.isActiveAndEnabled)
			{
				bool useStencilOutsideScreen = UISoftMaskProjectSettings.useStencilOutsideScreen;
				Utils.GetStencilBits(base.transform, includeSelf: false, useStencilOutsideScreen, out nearestMask, out var _);
			}
			MaskingShapeContainer orAddComponent = nearestMask.GetOrAddComponent<MaskingShapeContainer>();
			if (orAddComponent != _container)
			{
				if ((bool)_container)
				{
					_container.Unregister(this);
				}
				if ((bool)orAddComponent)
				{
					orAddComponent.Register(this);
				}
			}
			_container = orAddComponent;
		}

		internal bool IsInside(Vector2 sp, Camera eventCamera, float threshold = 0.01f)
		{
			if (!base.isActiveAndEnabled)
			{
				return false;
			}
			if (!RectTransformUtility.RectangleContainsScreenPoint(graphic.rectTransform, sp, eventCamera))
			{
				return false;
			}
			if (alphaHitTest && !Utils.AlphaHitTestValid(graphic, sp, eventCamera, threshold))
			{
				return false;
			}
			return true;
		}

		internal void DrawSoftMaskBuffer(CommandBuffer cb, int depth)
		{
			Texture mainTexture = graphic.mainTexture;
			Mesh mesh = _mesh;
			if ((bool)mesh && graphic.IsInScreen())
			{
				if (_mpb == null)
				{
					_mpb = SoftMaskUtils.materialPropertyBlockPool.Rent();
				}
				SoftMaskUtils.ApplyMaterialPropertyBlock(_mpb, depth, mainTexture, softnessRange, alpha);
				Material softMaskingMaterial = SoftMaskUtils.GetSoftMaskingMaterial(maskingMethod);
				cb.DrawMesh(mesh, base.transform.localToWorldMatrix, softMaskingMaterial, 0, 0, _mpb);
			}
		}

		private void RegisterAntiAliasingIfNeeded()
		{
			if (_antiAliasingRegistered != AntiAliasingEnabled())
			{
				if (!_antiAliasingRegistered)
				{
					_antiAliasingRegistered = true;
					UIExtraCallbacks.onBeforeCanvasRebuild += UpdateAntiAliasing;
					UpdateAntiAliasing();
				}
				else
				{
					_antiAliasingRegistered = false;
					UIExtraCallbacks.onBeforeCanvasRebuild -= UpdateAntiAliasing;
					UpdateAntiAliasing();
				}
			}
		}

		private void UpdateAntiAliasing()
		{
			if ((bool)this && (bool)_graphic)
			{
				RecalculateStencilIfNeeded();
				if (AntiAliasingEnabled())
				{
					Utils.UpdateAntiAlias(_graphic, enabled: true, antiAliasingThreshold);
				}
				else
				{
					Utils.UpdateAntiAlias(_graphic, enabled: false, 0f);
				}
			}
		}
	}
}

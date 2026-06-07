using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Coffee.UISoftMask
{
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(CanvasRenderer))]
	[DisallowMultipleComponent]
	[AddComponentMenu("")]
	public class TerminalMaskingShape : MaskableGraphic, ILayoutElement, ILayoutIgnorer, IMaskable
	{
		private static Material s_SharedTerminalMaterial;

		private Mask _mask;

		private Mask _parentMask;

		private bool _shouldRecalculateStencil;

		private int _stencilBits;

		public override bool raycastTarget
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		float ILayoutElement.minWidth => 0f;

		float ILayoutElement.preferredWidth => 0f;

		float ILayoutElement.flexibleWidth => 0f;

		float ILayoutElement.minHeight => 0f;

		float ILayoutElement.preferredHeight => 0f;

		float ILayoutElement.flexibleHeight => 0f;

		int ILayoutElement.layoutPriority => 0;

		bool ILayoutIgnorer.ignoreLayout => true;

		protected override void OnEnable()
		{
			if (!s_SharedTerminalMaterial)
			{
				s_SharedTerminalMaterial = new Material(Shader.Find("Hidden/UI/TerminalMaskingShape"))
				{
					hideFlags = (HideFlags.DontSave | HideFlags.NotEditable)
				};
			}
			material = s_SharedTerminalMaterial;
			base.transform.parent.TryGetComponent<Mask>(out _parentMask);
			_shouldRecalculateStencil = true;
			base.hideFlags = UISoftMaskProjectSettings.hideFlagsForTemp;
			base.OnEnable();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if ((bool)_parentMask && _parentMask.MaskEnabled())
			{
				_parentMask.graphic.SetMaterialDirty();
			}
		}

		void ILayoutElement.CalculateLayoutInputHorizontal()
		{
		}

		void ILayoutElement.CalculateLayoutInputVertical()
		{
		}

		void IMaskable.RecalculateMasking()
		{
			_shouldRecalculateStencil = true;
		}

		public override Material GetModifiedMaterial(Material baseMaterial)
		{
			if (!IsActive())
			{
				StencilMaterial.Remove(m_MaskMaterial);
				m_MaskMaterial = null;
				return null;
			}
			RecalculateStencilIfNeeded();
			if ((_stencilBits == 0 && !_mask) || _parentMask != _mask)
			{
				StencilMaterial.Remove(m_MaskMaterial);
				m_MaskMaterial = null;
				return null;
			}
			Material material = StencilMaterial.Add(baseMaterial, _stencilBits, StencilOp.Zero, CompareFunction.Equal, (ColorWriteMask)0, _stencilBits, _stencilBits);
			StencilMaterial.Remove(m_MaskMaterial);
			m_MaskMaterial = material;
			return material;
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
			if (IsActive())
			{
				vh.AddVert(new Vector3(-999999f, -999999f), new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), new Vector2(0f, 0f));
				vh.AddVert(new Vector3(-999999f, 999999f), new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), new Vector2(0f, 1f));
				vh.AddVert(new Vector3(999999f, 999999f), new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), new Vector2(1f, 1f));
				vh.AddVert(new Vector3(999999f, -999999f), new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), new Vector2(1f, 0f));
				vh.AddTriangle(0, 1, 2);
				vh.AddTriangle(2, 3, 0);
			}
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
				_stencilBits = Utils.GetStencilBits(base.transform, includeSelf: false, useStencilOutsideScreen, out _mask, out var _);
			}
		}
	}
}

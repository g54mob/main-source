using System;
using Coffee.UISoftMaskInternal;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UISoftMask
{
	[ExecuteAlways]
	public class SoftMaskable : MonoBehaviour, IMaterialModifier, IMaskable
	{
		private static readonly int s_AlphaClipThreshold = Shader.PropertyToID("_AlphaClipThreshold");

		private Action _checkGraphic;

		private MaskableGraphic _graphic;

		private Material _maskableMaterial;

		private bool _shouldRecalculateStencil;

		private SoftMask _softMask;

		private int _softMaskDepth;

		private int _stencilBits;

		private bool isTerminal => _graphic is TerminalMaskingShape;

		private void OnEnable()
		{
			base.hideFlags = UISoftMaskProjectSettings.hideFlagsForTemp;
			this.AddComponentOnChildren<SoftMaskable>(base.hideFlags, includeSelf: false);
			_shouldRecalculateStencil = true;
			if (TryGetComponent<MaskableGraphic>(out _graphic))
			{
				_graphic.SetMaterialDirty();
			}
			else
			{
				UIExtraCallbacks.onBeforeCanvasRebuild += CheckGraphic;
			}
		}

		private void OnDisable()
		{
			UIExtraCallbacks.onBeforeCanvasRebuild -= CheckGraphic;
			if ((bool)_graphic)
			{
				_graphic.SetMaterialDirty();
			}
			_graphic = null;
			_softMask = null;
			MaterialRepository.Release(ref _maskableMaterial);
		}

		private void OnDestroy()
		{
			_graphic = null;
			_maskableMaterial = null;
			_softMask = null;
			_checkGraphic = null;
		}

		private void OnTransformChildrenChanged()
		{
			this.AddComponentOnChildren<SoftMaskable>(UISoftMaskProjectSettings.hideFlagsForTemp, includeSelf: false);
		}

		void IMaskable.RecalculateMasking()
		{
			_shouldRecalculateStencil = true;
		}

		Material IMaterialModifier.GetModifiedMaterial(Material baseMaterial)
		{
			if (!UISoftMaskProjectSettings.softMaskEnabled)
			{
				MaterialRepository.Release(ref _maskableMaterial);
				return baseMaterial;
			}
			if (!base.isActiveAndEnabled || !_graphic || !_graphic.maskable || isTerminal || baseMaterial == null)
			{
				MaterialRepository.Release(ref _maskableMaterial);
				return baseMaterial;
			}
			RecalculateStencilIfNeeded();
			_softMaskDepth = (_softMask ? _softMask.softMaskDepth : (-1));
			_ = UISoftMaskProjectSettings.useStencilOutsideScreen;
			uint u32_ = 0u;
			if (!_softMask || _softMaskDepth < 0 || 4 <= _softMaskDepth)
			{
				MaterialRepository.Release(ref _maskableMaterial);
				return baseMaterial;
			}
			bool flag = Application.isPlaying && _graphic.canvas.IsStereoCanvas();
			MaterialRepository.Get(new Hash128((uint)baseMaterial.GetInstanceID(), (uint)_softMask.softMaskBuffer.GetInstanceID(), (uint)(_stencilBits + (flag ? 256 : 0) + (_softMaskDepth << 9)), u32_), ref _maskableMaterial, ((Material baseMaterial, RenderTexture softMaskBuffer, int _softMaskDepth, int _stencilBits, bool isStereo) x) => SoftMaskUtils.CreateSoftMaskable(x.baseMaterial, x.softMaskBuffer, x._softMaskDepth, x._stencilBits, x.isStereo, UISoftMaskProjectSettings.fallbackBehavior), (baseMaterial, _softMask.softMaskBuffer, _softMaskDepth, _stencilBits, flag));
			return _maskableMaterial;
		}

		private void RecalculateStencilIfNeeded()
		{
			if (!base.isActiveAndEnabled)
			{
				_softMask = null;
				_stencilBits = 0;
			}
			else if (_shouldRecalculateStencil)
			{
				_shouldRecalculateStencil = false;
				bool useStencilOutsideScreen = UISoftMaskProjectSettings.useStencilOutsideScreen;
				_stencilBits = Utils.GetStencilBits(base.transform, includeSelf: false, useStencilOutsideScreen, out var _, out _softMask);
			}
		}

		private void CheckGraphic()
		{
			if (!_graphic && TryGetComponent<MaskableGraphic>(out _graphic))
			{
				UIExtraCallbacks.onBeforeCanvasRebuild -= CheckGraphic;
				base.gameObject.AddComponent<SoftMaskable>();
				Misc.Destroy(this);
			}
		}
	}
}

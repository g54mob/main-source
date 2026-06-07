using System;
using System.Collections.Generic;
using Coffee.UISoftMaskInternal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Coffee.UISoftMask
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[AddComponentMenu("")]
	public class MaskingShapeContainer : MonoBehaviour, ICanvasRaycastFilter, IMaterialModifier
	{
		[SerializeField]
		private List<MaskingShape> m_MaskingShapes = new List<MaskingShape>();

		private Action _checkTransformChanged;

		private bool _dirty;

		private Mask _mask;

		private bool _needTerminal;

		private TerminalMaskingShape _terminal;

		private void OnEnable()
		{
			UIExtraCallbacks.onBeforeCanvasRebuild += CheckTransformChanged;
			base.hideFlags = UISoftMaskProjectSettings.hideFlagsForTemp;
			SetContainerDirty();
			if (_mask is IMaskingShapeContainerOwner maskingShapeContainerOwner)
			{
				maskingShapeContainerOwner.Register(this);
			}
			_dirty = true;
			m_MaskingShapes.RemoveAll((MaskingShape x) => !x);
			m_MaskingShapes.Sort();
		}

		private void OnDisable()
		{
			UIExtraCallbacks.onBeforeCanvasRebuild -= CheckTransformChanged;
			_dirty = false;
			_needTerminal = false;
		}

		private void OnDestroy()
		{
			_mask = null;
			_terminal = null;
			m_MaskingShapes.Clear();
			_checkTransformChanged = null;
		}

		bool ICanvasRaycastFilter.IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			if (FrameCache.TryGet<bool>(this, "IsRaycastLocationValid", out var result))
			{
				return result;
			}
			if (!_mask || !_mask.MaskEnabled() || _mask is IMaskingShapeContainerOwner)
			{
				FrameCache.Set(this, "IsRaycastLocationValid", result: true);
				return true;
			}
			result = IsInside(sp, eventCamera, defaultValid: true);
			FrameCache.Set(this, "IsRaycastLocationValid", result);
			return result;
		}

		Material IMaterialModifier.GetModifiedMaterial(Material baseMaterial)
		{
			if (base.isActiveAndEnabled && (bool)_mask && _mask.MaskEnabled() && _needTerminal)
			{
				_mask.graphic.canvasRenderer.hasPopInstruction = false;
				_mask.graphic.canvasRenderer.popMaterialCount = 0;
			}
			return baseMaterial;
		}

		public bool IsInside(Vector2 sp, Camera eventCamera, bool defaultValid = false, float threshold = 0.01f)
		{
			if (FrameCache.TryGet<bool>(this, "IsInside", (!defaultValid) ? 1 : 0, out var result))
			{
				return result;
			}
			result = defaultValid;
			for (int i = 0; i < m_MaskingShapes.Count; i++)
			{
				if ((bool)m_MaskingShapes[i] && m_MaskingShapes[i].IsInside(sp, eventCamera, threshold))
				{
					result = m_MaskingShapes[i].maskingMethod switch
					{
						MaskingShape.MaskingMethod.Additive => true, 
						MaskingShape.MaskingMethod.Subtract => false, 
						_ => throw new ArgumentOutOfRangeException(), 
					};
				}
			}
			FrameCache.Set(this, "IsInside", (!defaultValid) ? 1 : 0, result);
			return result;
		}

		public void SetContainerDirty()
		{
			if (!_mask)
			{
				TryGetComponent<Mask>(out _mask);
			}
			_dirty = true;
		}

		private void CheckTransformChanged()
		{
			if (!_mask)
			{
				return;
			}
			SoftMask softMask = _mask as SoftMask;
			_needTerminal = false;
			for (int i = 0; i < m_MaskingShapes.Count; i++)
			{
				MaskingShape maskingShape = m_MaskingShapes[i];
				if ((bool)maskingShape && (bool)maskingShape.graphic && maskingShape.graphic.IsInScreen())
				{
					if (maskingShape.hasTransformChanged)
					{
						_dirty = true;
					}
					if (maskingShape.maskingMethod == MaskingShape.MaskingMethod.Additive)
					{
						_needTerminal = true;
					}
				}
			}
			if (_dirty && (bool)_mask && _mask.MaskEnabled())
			{
				if ((bool)softMask)
				{
					softMask.SetSoftMaskDirty();
				}
				else
				{
					_mask.graphic.SetMaterialDirty();
				}
			}
			_dirty = false;
			if (!_mask.MaskEnabled() || ((bool)softMask && softMask.SoftMaskingEnabled() && !UISoftMaskProjectSettings.useStencilOutsideScreen))
			{
				_needTerminal = false;
			}
			if (_needTerminal && !_terminal)
			{
				_terminal = FindTerminal();
			}
			if ((bool)_terminal)
			{
				_terminal.enabled = _needTerminal;
				_terminal.transform.SetAsLastSibling();
			}
		}

		public bool IsInScreen()
		{
			for (int i = 0; i < m_MaskingShapes.Count; i++)
			{
				MaskingShape maskingShape = m_MaskingShapes[i];
				if ((bool)maskingShape && (bool)maskingShape.graphic && maskingShape.graphic.IsInScreen())
				{
					return true;
				}
			}
			return false;
		}

		public void DrawSoftMaskBuffer(CommandBuffer cb, int softMaskDepth)
		{
			for (int num = m_MaskingShapes.Count - 1; num >= 0; num--)
			{
				if (!m_MaskingShapes[num])
				{
					m_MaskingShapes.RemoveAtFast(num);
				}
			}
			m_MaskingShapes.Sort();
			for (int i = 0; i < m_MaskingShapes.Count; i++)
			{
				m_MaskingShapes[i].DrawSoftMaskBuffer(cb, softMaskDepth);
			}
		}

		public void Register(MaskingShape shape)
		{
			if ((bool)shape && !m_MaskingShapes.Contains(shape))
			{
				m_MaskingShapes.Add(shape);
				_dirty = true;
			}
		}

		public void Unregister(MaskingShape shape)
		{
			if (m_MaskingShapes.Contains(shape))
			{
				m_MaskingShapes.Remove(shape);
				_dirty = true;
			}
		}

		private TerminalMaskingShape FindTerminal()
		{
			int childCount = base.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				if (base.transform.GetChild(i).TryGetComponent<TerminalMaskingShape>(out var component))
				{
					return component;
				}
			}
			GameObject obj = new GameObject("[generated] TerminalMaskingShape");
			obj.transform.SetParent(base.transform, worldPositionStays: false);
			obj.hideFlags = HideFlags.HideAndDontSave;
			return obj.AddComponent<TerminalMaskingShape>();
		}
	}
}

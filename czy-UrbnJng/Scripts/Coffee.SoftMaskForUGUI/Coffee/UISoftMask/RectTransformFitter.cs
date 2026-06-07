using System;
using Coffee.UISoftMaskInternal;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UISoftMask
{
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	public sealed class RectTransformFitter : MonoBehaviour, ILayoutElement, ILayoutIgnorer
	{
		[Flags]
		public enum RectTransformProperties
		{
			PositionX = 2,
			PositionY = 4,
			PositionZ = 8,
			Position2D = 6,
			Position = 0xE,
			Rotation = 0x10,
			ScaleX = 0x20,
			ScaleY = 0x40,
			ScaleZ = 0x80,
			Scale = 0xE0,
			SizeDeltaX = 0x1000,
			SizeDeltaY = 0x2000,
			SizeDelta = 0x3000
		}

		[Tooltip("Target RectTransform to fit.")]
		[SerializeField]
		private RectTransform m_Target;

		[Tooltip("Target RectTransform properties.")]
		[SerializeField]
		private RectTransformProperties m_TargetProperties = RectTransformProperties.Position | RectTransformProperties.Scale | RectTransformProperties.SizeDelta | RectTransformProperties.Rotation;

		private Action _fit;

		private RectTransform _rectTransform;

		private DrivenRectTransformTracker _tracker;

		public RectTransform target
		{
			get
			{
				return m_Target;
			}
			set
			{
				m_Target = value;
			}
		}

		public RectTransformProperties targetProperties
		{
			get
			{
				return m_TargetProperties;
			}
			set
			{
				if (m_TargetProperties != value)
				{
					m_TargetProperties = value;
					OnValidate();
				}
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

		private void OnEnable()
		{
			_rectTransform = GetComponent<RectTransform>();
			UIExtraCallbacks.onBeforeCanvasRebuild += Fit;
			OnValidate();
		}

		private void OnDisable()
		{
			UIExtraCallbacks.onBeforeCanvasRebuild -= Fit;
			OnValidate();
		}

		private void OnDestroy()
		{
			_rectTransform = null;
			_fit = null;
		}

		private void OnValidate()
		{
			_tracker.Clear();
			if (base.isActiveAndEnabled)
			{
				DrivenTransformProperties drivenTransformProperties = (DrivenTransformProperties)m_TargetProperties;
				if ((RectTransformProperties)0 < (m_TargetProperties & (RectTransformProperties.Position | RectTransformProperties.SizeDelta)))
				{
					drivenTransformProperties |= DrivenTransformProperties.Anchors | DrivenTransformProperties.Pivot;
				}
				_tracker.Add(this, _rectTransform, drivenTransformProperties);
			}
		}

		void ILayoutElement.CalculateLayoutInputHorizontal()
		{
		}

		void ILayoutElement.CalculateLayoutInputVertical()
		{
		}

		private void Fit()
		{
			if (!m_Target || !_rectTransform || m_Target.IsChildOf(_rectTransform))
			{
				return;
			}
			if ((RectTransformProperties)0 < (m_TargetProperties & RectTransformProperties.Position))
			{
				Vector3 position = m_Target.position;
				Vector3 position2 = _rectTransform.position;
				if ((RectTransformProperties)0 < (m_TargetProperties & RectTransformProperties.PositionX))
				{
					position2.x = position.x;
				}
				if ((RectTransformProperties)0 < (m_TargetProperties & RectTransformProperties.PositionY))
				{
					position2.y = position.y;
				}
				if ((RectTransformProperties)0 < (m_TargetProperties & RectTransformProperties.PositionZ))
				{
					position2.z = position.z;
				}
				_rectTransform.position = position2;
			}
			if ((RectTransformProperties)0 < (m_TargetProperties & RectTransformProperties.Rotation))
			{
				_rectTransform.rotation = m_Target.rotation;
			}
			if ((RectTransformProperties)0 < (m_TargetProperties & RectTransformProperties.Scale))
			{
				Transform parent = _rectTransform.parent;
				Vector3 lossyScale = m_Target.lossyScale;
				Vector3 vector = (parent ? parent.lossyScale : Vector3.one);
				Vector3 localScale = _rectTransform.localScale;
				if ((RectTransformProperties)0 < (m_TargetProperties & RectTransformProperties.ScaleX))
				{
					localScale.x = (Mathf.Approximately(vector.x, 0f) ? 1f : (lossyScale.x / vector.x));
				}
				if ((RectTransformProperties)0 < (m_TargetProperties & RectTransformProperties.ScaleY))
				{
					localScale.y = (Mathf.Approximately(vector.y, 0f) ? 1f : (lossyScale.y / vector.y));
				}
				if ((RectTransformProperties)0 < (m_TargetProperties & RectTransformProperties.ScaleZ))
				{
					localScale.z = (Mathf.Approximately(vector.z, 0f) ? 1f : (lossyScale.z / vector.z));
				}
				_rectTransform.localScale = localScale;
			}
			if ((RectTransformProperties)0 < (m_TargetProperties & RectTransformProperties.SizeDelta))
			{
				Vector2 size = m_Target.rect.size;
				Vector2 sizeDelta = _rectTransform.sizeDelta;
				if ((RectTransformProperties)0 < (m_TargetProperties & RectTransformProperties.SizeDeltaX))
				{
					sizeDelta.x = size.x;
				}
				if ((RectTransformProperties)0 < (m_TargetProperties & RectTransformProperties.SizeDeltaY))
				{
					sizeDelta.y = size.y;
				}
				_rectTransform.sizeDelta = sizeDelta;
			}
			if ((RectTransformProperties)0 < (m_TargetProperties & (RectTransformProperties.Position | RectTransformProperties.SizeDelta)))
			{
				RectTransform rectTransform = _rectTransform;
				RectTransform rectTransform2 = _rectTransform;
				Vector2 vector2 = (_rectTransform.anchorMin = new Vector2(0.5f, 0.5f));
				Vector2 pivot = (rectTransform2.anchorMax = vector2);
				rectTransform.pivot = pivot;
			}
		}
	}
}

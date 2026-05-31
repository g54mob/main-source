using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CTS.Utilities
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(RectTransform), typeof(Image))]
	public class ImageFitter : UIBehaviour, ILayoutSelfController, ILayoutController
	{
		[SerializeField]
		private Image _image;

		[SerializeField]
		private AspectRatioFitter.AspectMode _aspectMode;

		[NonSerialized]
		private RectTransform m_Rect;

		private bool m_DelayedSetDirty;

		private bool _doesParentExist;

		private DrivenRectTransformTracker m_Tracker;

		private RectTransform rectTransform
		{
			get
			{
				if (m_Rect == null)
				{
					m_Rect = GetComponent<RectTransform>();
				}
				return m_Rect;
			}
		}

		public float _aspectRatio
		{
			get
			{
				if (_image == null)
				{
					return 1f;
				}
				return _image.GetSpriteAspectRatio();
			}
		}

		public AspectRatioFitter.AspectMode AspectMode
		{
			get
			{
				return _aspectMode;
			}
			set
			{
				if (_aspectMode != value)
				{
					_aspectMode = value;
					SetDirty();
				}
			}
		}

		protected ImageFitter()
		{
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			_doesParentExist = (rectTransform.parent ? true : false);
			SetDirty();
		}

		protected override void Start()
		{
			base.Start();
			if (!IsComponentValidOnObject() || !IsAspectModeValid())
			{
				base.enabled = false;
			}
		}

		protected override void OnDisable()
		{
			m_Tracker.Clear();
			LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
			base.OnDisable();
		}

		protected override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			_doesParentExist = (rectTransform.parent ? true : false);
			SetDirty();
		}

		protected virtual void Update()
		{
			if (m_DelayedSetDirty)
			{
				m_DelayedSetDirty = false;
				SetDirty();
			}
		}

		protected override void OnRectTransformDimensionsChange()
		{
			UpdateRect();
		}

		private void UpdateRect()
		{
			if (!IsActive() || !IsComponentValidOnObject())
			{
				return;
			}
			m_Tracker.Clear();
			switch (_aspectMode)
			{
			case AspectRatioFitter.AspectMode.HeightControlsWidth:
				m_Tracker.Add(this, rectTransform, DrivenTransformProperties.SizeDeltaX);
				rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rectTransform.rect.height * _aspectRatio);
				break;
			case AspectRatioFitter.AspectMode.WidthControlsHeight:
				m_Tracker.Add(this, rectTransform, DrivenTransformProperties.SizeDeltaY);
				rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectTransform.rect.width / _aspectRatio);
				break;
			case AspectRatioFitter.AspectMode.FitInParent:
			case AspectRatioFitter.AspectMode.EnvelopeParent:
				if (DoesParentExists())
				{
					m_Tracker.Add(this, rectTransform, DrivenTransformProperties.Anchors | DrivenTransformProperties.AnchoredPosition | DrivenTransformProperties.SizeDelta);
					rectTransform.anchorMin = Vector2.zero;
					rectTransform.anchorMax = Vector2.one;
					rectTransform.anchoredPosition = Vector2.zero;
					Vector2 zero = Vector2.zero;
					Vector2 parentSize = GetParentSize();
					if ((parentSize.y * _aspectRatio < parentSize.x) ^ (_aspectMode == AspectRatioFitter.AspectMode.FitInParent))
					{
						zero.y = GetSizeDeltaToProduceSize(parentSize.x / _aspectRatio, 1);
					}
					else
					{
						zero.x = GetSizeDeltaToProduceSize(parentSize.y * _aspectRatio, 0);
					}
					rectTransform.sizeDelta = zero;
				}
				break;
			}
		}

		private float GetSizeDeltaToProduceSize(float size, int axis)
		{
			return size - GetParentSize()[axis] * (rectTransform.anchorMax[axis] - rectTransform.anchorMin[axis]);
		}

		private Vector2 GetParentSize()
		{
			RectTransform rectTransform = this.rectTransform.parent as RectTransform;
			if ((bool)rectTransform)
			{
				return rectTransform.rect.size;
			}
			return Vector2.zero;
		}

		public virtual void SetLayoutHorizontal()
		{
		}

		public virtual void SetLayoutVertical()
		{
		}

		protected void SetDirty()
		{
			UpdateRect();
		}

		public bool IsComponentValidOnObject()
		{
			Canvas component = base.gameObject.GetComponent<Canvas>();
			if ((bool)component && component.isRootCanvas && component.renderMode != RenderMode.WorldSpace)
			{
				return false;
			}
			return true;
		}

		public bool IsAspectModeValid()
		{
			if (!DoesParentExists())
			{
				AspectRatioFitter.AspectMode aspectMode = AspectMode;
				if (aspectMode == AspectRatioFitter.AspectMode.EnvelopeParent || aspectMode == AspectRatioFitter.AspectMode.FitInParent)
				{
					return false;
				}
			}
			return true;
		}

		private bool DoesParentExists()
		{
			return _doesParentExist;
		}
	}
}

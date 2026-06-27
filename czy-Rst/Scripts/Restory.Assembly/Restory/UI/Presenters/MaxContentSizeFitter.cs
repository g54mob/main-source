using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Presenters
{
	[AddComponentMenu("Layout/Max Content Size Fitter", 141)]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	public class MaxContentSizeFitter : UIBehaviour, ILayoutSelfController, ILayoutController
	{
		[SerializeField]
		private float maxWidth = -1f;

		[SerializeField]
		private float maxHeight = -1f;

		[NonSerialized]
		private RectTransform rectTransform;

		public float MaxWidth
		{
			get
			{
				return maxWidth;
			}
			set
			{
				if (maxWidth != value)
				{
					maxWidth = value;
					SetDirty();
				}
			}
		}

		public float MaxHeight
		{
			get
			{
				return maxHeight;
			}
			set
			{
				if (maxHeight != value)
				{
					maxHeight = value;
					SetDirty();
				}
			}
		}

		private RectTransform RectTransform
		{
			get
			{
				if (rectTransform == null)
				{
					rectTransform = GetComponent<RectTransform>();
				}
				return rectTransform;
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			SetDirty();
		}

		protected override void OnDisable()
		{
			LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
			base.OnDisable();
		}

		protected override void OnRectTransformDimensionsChange()
		{
			SetDirty();
		}

		private void HandleSelfFittingAlongAxis(int axis)
		{
			RectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis)axis, GetPreferredSize(axis));
		}

		private float GetPreferredSize(int axis)
		{
			float num = LayoutUtility.GetPreferredSize(rectTransform, axis);
			if (axis == 0 && maxWidth >= 0f)
			{
				num = Mathf.Min(num, maxWidth);
			}
			else if (axis == 1 && maxHeight >= 0f)
			{
				num = Mathf.Min(num, maxHeight);
			}
			return num;
		}

		public virtual void SetLayoutHorizontal()
		{
			HandleSelfFittingAlongAxis(0);
		}

		public virtual void SetLayoutVertical()
		{
			HandleSelfFittingAlongAxis(1);
		}

		protected void SetDirty()
		{
			if (IsActive())
			{
				LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
			}
		}
	}
}

using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20.UI
{
	public class ElementLayoutController : UIBehaviour
	{
		private RectTransform _rect;

		public RectTransform RectTransform
		{
			get
			{
				if (_rect == null)
				{
					_rect = GetComponent<RectTransform>();
				}
				return _rect;
			}
		}

		protected override void OnEnable()
		{
			SetDirty();
		}

		protected override void OnDisable()
		{
			SetDirty();
		}

		protected override void OnTransformParentChanged()
		{
			SetDirty();
		}

		protected override void OnRectTransformDimensionsChange()
		{
			SetDirty();
		}

		public void SetDirty()
		{
			if (IsActive())
			{
				if (!CanvasUpdateRegistry.IsRebuildingLayout())
				{
					MarkDirty();
				}
				else
				{
					StartCoroutine(DelayedSetDirty());
				}
			}
		}

		private IEnumerator DelayedSetDirty()
		{
			yield return null;
			MarkDirty();
		}

		protected virtual void MarkDirty()
		{
			LayoutRebuilder.MarkLayoutForRebuild(RectTransform);
		}
	}
}

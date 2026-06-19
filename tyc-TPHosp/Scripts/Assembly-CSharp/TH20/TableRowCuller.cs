using System.Collections;
using TH20.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20
{
	public class TableRowCuller : UIBehaviour, ILayoutGroup, ILayoutController
	{
		private RectTransform _rect;

		public Table Table;

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

		void ILayoutController.SetLayoutHorizontal()
		{
		}

		void ILayoutController.SetLayoutVertical()
		{
			Table.UpdateCulling();
			Table.SetDirty();
		}
	}
}

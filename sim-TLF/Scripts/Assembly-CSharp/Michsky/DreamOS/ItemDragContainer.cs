using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[DisallowMultipleComponent]
	public class ItemDragContainer : MonoBehaviour
	{
		public enum DragMode
		{
			Snapped = 0,
			Free = 1
		}

		public enum PreferredLayout
		{
			Grid = 0,
			Horizontal = 1,
			Vertical = 2
		}

		[Header("Resources")]
		public RectTransform dragBorder;

		[HideInInspector]
		public GridLayoutGroup gridLayoutGroup;

		[HideInInspector]
		public HorizontalLayoutGroup horLayoutGroup;

		[HideInInspector]
		public VerticalLayoutGroup verLayoutGroup;

		[Header("Settings")]
		public PreferredLayout preferredLayout;

		public DragMode dragMode = DragMode.Free;

		[HideInInspector]
		public List<ItemDragger> items = new List<ItemDragger>();

		public GameObject objectBeingDragged { get; set; }

		private void Awake()
		{
			objectBeingDragged = null;
			if (dragBorder == null)
			{
				dragBorder = base.gameObject.GetComponent<RectTransform>();
			}
			if (preferredLayout == PreferredLayout.Grid)
			{
				gridLayoutGroup = base.gameObject.GetComponent<GridLayoutGroup>();
			}
			else if (preferredLayout == PreferredLayout.Horizontal)
			{
				horLayoutGroup = base.gameObject.GetComponent<HorizontalLayoutGroup>();
			}
			else if (preferredLayout == PreferredLayout.Vertical)
			{
				verLayoutGroup = base.gameObject.GetComponent<VerticalLayoutGroup>();
			}
		}

		private void OnEnable()
		{
			if (gridLayoutGroup != null)
			{
				UpdateDragMode();
			}
		}

		public void FreeDragMode()
		{
			Invoke("FreeDragModeHelper", 0.1f);
		}

		private void FreeDragModeHelper()
		{
			dragMode = DragMode.Free;
			gridLayoutGroup.enabled = false;
			for (int i = 0; i < items.Count && !(items[i] == null); i++)
			{
				items[i].UpdateObject();
			}
		}

		public void SnappedDragMode()
		{
			dragMode = DragMode.Snapped;
			gridLayoutGroup.enabled = true;
		}

		public void UpdateDragMode()
		{
			if (dragMode == DragMode.Free)
			{
				FreeDragMode();
			}
			else
			{
				SnappedDragMode();
			}
		}
	}
}

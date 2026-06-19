using UnityEngine;

namespace Battlehub.UIControls
{
	[RequireComponent(typeof(RectTransform))]
	public class TreeViewDropMarker : ItemDropMarker
	{
		private TreeView m_treeView;

		private RectTransform m_siblingGraphicsRectTransform;

		public GameObject ChildGraphics;

		public override ItemDropAction Action
		{
			get
			{
				return base.Action;
			}
			set
			{
				base.Action = value;
				ChildGraphics.SetActive(base.Action == ItemDropAction.SetLastChild);
				SiblingGraphics.SetActive(base.Action != ItemDropAction.SetLastChild);
			}
		}

		protected override void AwakeOverride()
		{
			base.AwakeOverride();
			m_treeView = GetComponentInParent<TreeView>();
			m_siblingGraphicsRectTransform = SiblingGraphics.GetComponent<RectTransform>();
		}

		public override void SetTraget(ItemContainer item)
		{
			base.SetTraget(item);
			if (!(item == null))
			{
				TreeViewItem treeViewItem = (TreeViewItem)item;
				if (treeViewItem != null)
				{
					m_siblingGraphicsRectTransform.offsetMin = new Vector2(treeViewItem.Indent, m_siblingGraphicsRectTransform.offsetMin.y);
				}
				else
				{
					m_siblingGraphicsRectTransform.offsetMin = new Vector2(0f, m_siblingGraphicsRectTransform.offsetMin.y);
				}
			}
		}

		public override void SetPosition(Vector2 position)
		{
			if (base.Item == null)
			{
				return;
			}
			RectTransform rectTransform = base.Item.RectTransform;
			TreeViewItem treeViewItem = (TreeViewItem)base.Item;
			Camera cam = null;
			if (base.ParentCanvas.renderMode == RenderMode.WorldSpace)
			{
				cam = m_treeView.Camera;
			}
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, position, cam, out var localPoint))
			{
				if (localPoint.y > (0f - rectTransform.rect.height) / 4f)
				{
					Action = ItemDropAction.SetPrevSibling;
					base.RectTransform.position = rectTransform.position;
				}
				else if (localPoint.y < rectTransform.rect.height / 4f - rectTransform.rect.height && !treeViewItem.HasChildren)
				{
					Action = ItemDropAction.SetNextSibling;
					base.RectTransform.position = rectTransform.position - new Vector3(0f, rectTransform.rect.height, 0f);
				}
				else
				{
					Action = ItemDropAction.SetLastChild;
					base.RectTransform.position = rectTransform.position;
				}
			}
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Battlehub.UIControls
{
	public class TreeView : ItemsControl<TreeViewItemDataBindingArgs>
	{
		public int Indent = 20;

		private bool m_expandSilently;

		public event EventHandler<ItemExpandingArgs> ItemExpanding;

		protected override void OnEnableOverride()
		{
			base.OnEnableOverride();
			TreeViewItem.ParentChanged += OnTreeViewItemParentChanged;
		}

		protected override void OnDisableOverride()
		{
			base.OnDisableOverride();
			TreeViewItem.ParentChanged -= OnTreeViewItemParentChanged;
		}

		public void AddChild(object parent, object item)
		{
			if (parent == null)
			{
				Add(item);
				return;
			}
			TreeViewItem treeViewItem = (TreeViewItem)GetItemContainer(parent);
			if (treeViewItem == null)
			{
				return;
			}
			int num = -1;
			if (treeViewItem.IsExpanded)
			{
				if (treeViewItem.HasChildren)
				{
					TreeViewItem treeViewItem2 = treeViewItem.LastChild();
					num = IndexOf(treeViewItem2.Item) + 1;
				}
				else
				{
					num = IndexOf(treeViewItem.Item) + 1;
				}
			}
			else
			{
				treeViewItem.CanExpand = true;
			}
			if (num > -1)
			{
				((TreeViewItem)Insert(num, item)).Parent = treeViewItem;
			}
		}

		public void ChangeParent(object parent, object item)
		{
			if (base.IsDropInProgress)
			{
				return;
			}
			ItemContainer itemContainer = GetItemContainer(item);
			if (!(itemContainer == null))
			{
				ItemContainer itemContainer2 = GetItemContainer(parent);
				ItemContainer[] dragItems = new ItemContainer[1] { itemContainer };
				if (CanDrop(dragItems, itemContainer2))
				{
					Drop(dragItems, itemContainer2, ItemDropAction.SetLastChild);
				}
			}
		}

		public void Expand(TreeViewItem item)
		{
			if (m_expandSilently || this.ItemExpanding == null)
			{
				return;
			}
			ItemExpandingArgs itemExpandingArgs = new ItemExpandingArgs(item.Item);
			this.ItemExpanding(this, itemExpandingArgs);
			IEnumerable children = itemExpandingArgs.Children;
			int num = item.transform.GetSiblingIndex();
			int num2 = IndexOf(item.Item);
			item.CanExpand = children != null;
			if (!item.CanExpand)
			{
				return;
			}
			foreach (object item2 in children)
			{
				num++;
				num2++;
				TreeViewItem treeViewItem = (TreeViewItem)InstantiateItemContainer(num);
				treeViewItem.Parent = item;
				treeViewItem.Item = item2;
				InsertItem(num2, item2);
				DataBindItem(item2, treeViewItem);
			}
			UpdateSelectedItemIndex();
		}

		public void Collapse(TreeViewItem item)
		{
			int siblingIndex = item.transform.GetSiblingIndex();
			int num = IndexOf(item.Item);
			if (base.SelectedItems != null)
			{
				List<object> selectedItems = base.SelectedItems.OfType<object>().ToList();
				int containerIndex = siblingIndex + 1;
				int itemIndex = num + 1;
				Unselect(selectedItems, item, ref containerIndex, ref itemIndex);
				base.SelectedItems = selectedItems;
			}
			Collapse(item, siblingIndex + 1, num + 1);
		}

		private void Unselect(List<object> selectedItems, TreeViewItem item, ref int containerIndex, ref int itemIndex)
		{
			while (true)
			{
				TreeViewItem treeViewItem = (TreeViewItem)GetItemContainer(containerIndex);
				if (!(treeViewItem == null) && !(treeViewItem.Parent != item))
				{
					containerIndex++;
					itemIndex++;
					selectedItems.Remove(treeViewItem.Item);
					Unselect(selectedItems, treeViewItem, ref containerIndex, ref itemIndex);
					continue;
				}
				break;
			}
		}

		private void Collapse(TreeViewItem item, int containerIndex, int itemIndex)
		{
			while (true)
			{
				TreeViewItem treeViewItem = (TreeViewItem)GetItemContainer(containerIndex);
				if (!(treeViewItem == null) && !(treeViewItem.Parent != item))
				{
					Collapse(treeViewItem, containerIndex + 1, itemIndex + 1);
					RemoveItemAt(itemIndex);
					DestroyItemContainer(containerIndex);
					continue;
				}
				break;
			}
		}

		protected override ItemContainer InstantiateItemContainerOverride(GameObject container)
		{
			TreeViewItem treeViewItem = container.GetComponent<TreeViewItem>();
			if (treeViewItem == null)
			{
				treeViewItem = container.AddComponent<TreeViewItem>();
				treeViewItem.gameObject.name = "TreeViewItem";
			}
			return treeViewItem;
		}

		protected override void DestroyItem(object item)
		{
			TreeViewItem treeViewItem = (TreeViewItem)GetItemContainer(item);
			if (treeViewItem != null)
			{
				Collapse(treeViewItem);
				base.DestroyItem(item);
				if (treeViewItem.Parent != null && !treeViewItem.Parent.HasChildren)
				{
					treeViewItem.Parent.CanExpand = false;
				}
			}
		}

		protected override void DataBindItem(object item, ItemContainer itemContainer)
		{
			TreeViewItemDataBindingArgs treeViewItemDataBindingArgs = new TreeViewItemDataBindingArgs();
			treeViewItemDataBindingArgs.Item = item;
			treeViewItemDataBindingArgs.ItemPresenter = itemContainer.gameObject;
			RaiseItemDataBinding(treeViewItemDataBindingArgs);
			((TreeViewItem)itemContainer).CanExpand = treeViewItemDataBindingArgs.HasChildren;
		}

		protected override bool CanDrop(ItemContainer[] dragItems, ItemContainer dropTarget)
		{
			if (!base.CanDrop(dragItems, dropTarget))
			{
				return false;
			}
			TreeViewItem treeViewItem = (TreeViewItem)dropTarget;
			if (treeViewItem == null)
			{
				return true;
			}
			for (int i = 0; i < dragItems.Length; i++)
			{
				TreeViewItem parent = (TreeViewItem)dragItems[i];
				if (treeViewItem.IsDescendantOf(parent))
				{
					return false;
				}
			}
			return true;
		}

		private void OnTreeViewItemParentChanged(object sender, ParentChangedEventArgs e)
		{
			TreeViewItem treeViewItem = (TreeViewItem)sender;
			if (!CanHandleEvent(treeViewItem))
			{
				return;
			}
			TreeViewItem oldParent = e.OldParent;
			if (oldParent != null && !oldParent.HasChildren)
			{
				oldParent.CanExpand = false;
			}
			if (base.DropMarker.Action != ItemDropAction.SetLastChild && base.DropMarker.Action != ItemDropAction.None)
			{
				return;
			}
			TreeViewItem newParent = e.NewParent;
			if (newParent != null)
			{
				if (newParent.CanExpand)
				{
					newParent.IsExpanded = true;
				}
				else
				{
					newParent.CanExpand = true;
					m_expandSilently = true;
					newParent.IsExpanded = true;
					m_expandSilently = false;
				}
			}
			TreeViewItem treeViewItem2 = treeViewItem.FirstChild();
			TreeViewItem treeViewItem3 = null;
			if (newParent != null)
			{
				treeViewItem3 = newParent.LastChild();
				if (treeViewItem3 == null)
				{
					treeViewItem3 = newParent;
				}
			}
			else
			{
				treeViewItem3 = (TreeViewItem)LastItemContainer();
			}
			if (treeViewItem3 != treeViewItem)
			{
				DropItemAfter(treeViewItem3, treeViewItem);
			}
			if (treeViewItem2 != null)
			{
				MoveSubtree(treeViewItem, treeViewItem2);
			}
		}

		private void MoveSubtree(TreeViewItem parent, TreeViewItem child)
		{
			int siblingIndex = parent.transform.GetSiblingIndex();
			int num = child.transform.GetSiblingIndex();
			bool flag = false;
			if (siblingIndex < num)
			{
				flag = true;
			}
			TreeViewItem treeViewItem = parent;
			while (child != null && child.IsDescendantOf(parent) && !(treeViewItem == child))
			{
				DropItemAfter(treeViewItem, child);
				treeViewItem = child;
				if (flag)
				{
					num++;
				}
				child = (TreeViewItem)GetItemContainer(num);
			}
		}

		protected override void Drop(ItemContainer[] dragItems, ItemContainer dropTarget, ItemDropAction action)
		{
			TreeViewItem treeViewItem = (TreeViewItem)dropTarget;
			switch (action)
			{
			case ItemDropAction.SetLastChild:
			{
				for (int i = 0; i < dragItems.Length; i++)
				{
					((TreeViewItem)dragItems[i]).Parent = treeViewItem;
				}
				break;
			}
			case ItemDropAction.SetPrevSibling:
			{
				for (int j = 0; j < dragItems.Length; j++)
				{
					TreeViewItem treeViewItem4 = (TreeViewItem)dragItems[j];
					TreeViewItem treeViewItem5 = treeViewItem4.FirstChild();
					DropItemBefore(treeViewItem, treeViewItem4);
					if (treeViewItem5 != null)
					{
						MoveSubtree(treeViewItem4, treeViewItem5);
					}
					treeViewItem4.Parent = treeViewItem.Parent;
				}
				break;
			}
			case ItemDropAction.SetNextSibling:
			{
				for (int num = dragItems.Length - 1; num >= 0; num--)
				{
					TreeViewItem treeViewItem2 = (TreeViewItem)dragItems[num];
					TreeViewItem treeViewItem3 = treeViewItem2.FirstChild();
					DropItemAfter(treeViewItem, treeViewItem2);
					if (treeViewItem3 != null)
					{
						MoveSubtree(treeViewItem2, treeViewItem3);
					}
					treeViewItem2.Parent = treeViewItem.Parent;
				}
				break;
			}
			}
			UpdateSelectedItemIndex();
		}
	}
}

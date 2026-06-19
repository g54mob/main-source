using System;
using UnityEngine;
using UnityEngine.UI;

namespace Battlehub.UIControls
{
	public class TreeViewItem : ItemContainer
	{
		private TreeViewExpander m_expander;

		[SerializeField]
		private HorizontalLayoutGroup m_itemLayout;

		private Toggle m_toggle;

		private TreeView m_treeView;

		private int m_indent;

		private TreeViewItem m_parent;

		private bool m_canExpand;

		private bool m_isExpanded;

		public int Indent => m_indent;

		public TreeViewItem Parent
		{
			get
			{
				return m_parent;
			}
			set
			{
				if (m_parent == value)
				{
					return;
				}
				TreeViewItem parent = m_parent;
				m_parent = value;
				if (m_parent != null && m_treeView != null && m_itemLayout != null)
				{
					m_indent = m_parent.m_indent + m_treeView.Indent;
					m_itemLayout.padding = new RectOffset(m_indent, m_itemLayout.padding.right, m_itemLayout.padding.top, m_itemLayout.padding.bottom);
					int siblingIndex = base.transform.GetSiblingIndex();
					SetIndent(this, ref siblingIndex);
				}
				else
				{
					m_indent = 0;
					if (m_itemLayout != null)
					{
						m_itemLayout.padding = new RectOffset(m_indent, m_itemLayout.padding.right, m_itemLayout.padding.top, m_itemLayout.padding.bottom);
					}
				}
				if (m_treeView != null && TreeViewItem.ParentChanged != null)
				{
					TreeViewItem.ParentChanged(this, new ParentChangedEventArgs(parent, m_parent));
				}
			}
		}

		public override bool IsSelected
		{
			get
			{
				return base.IsSelected;
			}
			set
			{
				if (base.IsSelected != value)
				{
					m_toggle.isOn = value;
					base.IsSelected = value;
				}
			}
		}

		public bool CanExpand
		{
			get
			{
				return m_canExpand;
			}
			set
			{
				if (m_canExpand != value)
				{
					m_canExpand = value;
					if (m_expander != null)
					{
						m_expander.CanExpand = m_canExpand;
					}
					if (!m_canExpand)
					{
						IsExpanded = false;
					}
				}
			}
		}

		public bool IsExpanded
		{
			get
			{
				return m_isExpanded;
			}
			set
			{
				if (m_isExpanded == value)
				{
					return;
				}
				m_isExpanded = value && m_canExpand;
				if (m_expander != null)
				{
					m_expander.IsOn = value && m_canExpand;
				}
				if (m_treeView != null)
				{
					if (m_isExpanded)
					{
						m_treeView.Expand(this);
					}
					else
					{
						m_treeView.Collapse(this);
					}
				}
			}
		}

		public bool HasChildren
		{
			get
			{
				int siblingIndex = base.transform.GetSiblingIndex();
				TreeViewItem treeViewItem = (TreeViewItem)m_treeView.GetItemContainer(siblingIndex + 1);
				if (treeViewItem != null)
				{
					return treeViewItem.Parent == this;
				}
				return false;
			}
		}

		public static event EventHandler<ParentChangedEventArgs> ParentChanged;

		private void SetIndent(TreeViewItem parent, ref int siblingIndex)
		{
			while (true)
			{
				TreeViewItem treeViewItem = (TreeViewItem)m_treeView.GetItemContainer(siblingIndex + 1);
				if (treeViewItem == null || treeViewItem.Parent != parent)
				{
					break;
				}
				treeViewItem.m_indent = parent.m_indent + m_treeView.Indent;
				treeViewItem.m_itemLayout.padding.left = treeViewItem.m_indent;
				siblingIndex++;
				SetIndent(treeViewItem, ref siblingIndex);
			}
		}

		public bool IsDescendantOf(TreeViewItem parent)
		{
			if (parent == null)
			{
				return true;
			}
			TreeViewItem treeViewItem = this;
			while (treeViewItem != null)
			{
				if (parent == treeViewItem)
				{
					return true;
				}
				treeViewItem = treeViewItem.Parent;
			}
			return false;
		}

		public TreeViewItem FirstChild()
		{
			if (!HasChildren)
			{
				return null;
			}
			int siblingIndex = base.transform.GetSiblingIndex();
			siblingIndex++;
			return (TreeViewItem)m_treeView.GetItemContainer(siblingIndex);
		}

		public TreeViewItem NextChild(TreeViewItem currentChild)
		{
			if (currentChild == null)
			{
				throw new ArgumentNullException("currentChild");
			}
			int siblingIndex = currentChild.transform.GetSiblingIndex();
			siblingIndex++;
			TreeViewItem treeViewItem = (TreeViewItem)m_treeView.GetItemContainer(siblingIndex);
			while (treeViewItem != null && treeViewItem.IsDescendantOf(this))
			{
				if (treeViewItem.Parent == this)
				{
					return treeViewItem;
				}
				siblingIndex++;
				treeViewItem = (TreeViewItem)m_treeView.GetItemContainer(siblingIndex);
			}
			return null;
		}

		public TreeViewItem LastChild()
		{
			if (!HasChildren)
			{
				return null;
			}
			int num = base.transform.GetSiblingIndex();
			TreeViewItem result = null;
			while (true)
			{
				num++;
				TreeViewItem treeViewItem = (TreeViewItem)m_treeView.GetItemContainer(num);
				if (treeViewItem == null || treeViewItem.Parent != this)
				{
					break;
				}
				result = treeViewItem;
			}
			return result;
		}

		protected override void AwakeOverride()
		{
			m_toggle = GetComponent<Toggle>();
			m_toggle.interactable = false;
			m_toggle.isOn = IsSelected;
			m_expander = GetComponentInChildren<TreeViewExpander>();
			if (m_expander != null)
			{
				m_expander.CanExpand = m_canExpand;
			}
		}

		protected override void StartOverride()
		{
			m_treeView = GetComponentInParent<TreeView>();
			if (IsExpanded)
			{
				m_treeView.Expand(this);
			}
			if (Parent != null)
			{
				m_indent = Parent.m_indent + m_treeView.Indent;
				m_itemLayout.padding.left = m_indent;
			}
		}
	}
}

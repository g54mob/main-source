using System;
using System.Collections.Generic;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class TreeNode<T> : IDragDropElement
	{
		public class DropTarget
		{
			public TreeNode<T> Container { get; set; }

			public TreeNode<T> InsertBefore { get; set; }
		}

		private XmlElement _arrow;

		private List<TreeNode<T>> _children = new List<TreeNode<T>>();

		private bool _collapsed;

		private int _indent;

		private XmlElement _rowElement;

		public bool AllowDrop { get; set; } = true;

		public IReadOnlyList<TreeNode<T>> Children => _children;

		public virtual bool Collapsed
		{
			get
			{
				return _collapsed;
			}
			set
			{
				_collapsed = value;
				if (_arrow != null)
				{
					if (_collapsed)
					{
						_arrow.rectTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
					}
					else
					{
						_arrow.rectTransform.localRotation = Quaternion.Euler(0f, 0f, -90f);
					}
				}
			}
		}

		GameObject IDragDropElement.GameObject => RowElement.gameObject;

		public int Indent
		{
			get
			{
				return _indent;
			}
			set
			{
				_indent = value;
				UpdateIndent();
			}
		}

		public bool IsAnyParentCollapsed => Parent?.Collapsed ?? false;

		public bool IsVisible
		{
			get
			{
				XmlElement rowElement = RowElement;
				if ((object)rowElement == null)
				{
					return false;
				}
				return rowElement.gameObject?.activeInHierarchy == true;
			}
		}

		public T Item { get; set; }

		public int LastSiblingIndex
		{
			get
			{
				int num = RowElement.transform.GetSiblingIndex();
				foreach (TreeNode<T> child in Children)
				{
					num = Mathf.Max(child.LastSiblingIndex, num);
				}
				return num;
			}
		}

		public TreeNode<T> Parent { get; set; }

		public TreeNode<T> Root
		{
			get
			{
				if (Parent != null)
				{
					return Parent.Root;
				}
				return this;
			}
		}

		public XmlElement RowElement
		{
			get
			{
				return _rowElement;
			}
			set
			{
				if (!(_rowElement != value))
				{
					return;
				}
				_rowElement = value;
				_arrow = _rowElement.GetElementByInternalId("arrow");
				if (SupportsArrow)
				{
					if (_arrow != null)
					{
						_arrow.AddOnClickEvent(delegate
						{
							OnArrowClicked(this);
						});
					}
				}
				else
				{
					_arrow.SetActive(active: false);
				}
			}
		}

		public virtual bool ShowCollapseArrow => Children.Count > 0;

		public bool ShowReadyForDragIndication { get; set; }

		public bool SupportsArrow { get; set; } = true;

		public virtual void Delete()
		{
			Parent._children.Remove(this);
			while (Children.Count > 0)
			{
				Children[0].Delete();
			}
			if (RowElement != null)
			{
				UnityEngine.Object.DestroyImmediate(RowElement.gameObject);
			}
		}

		public void ExecuteParentTree(Action<T> action)
		{
			action(Item);
			Parent?.ExecuteParentTree(action);
		}

		public void ExecuteTree(Action<T> action)
		{
			action(Item);
			foreach (TreeNode<T> child in Children)
			{
				child.ExecuteTree(action);
			}
		}

		public TreeNode<T> FindNode(Func<TreeNode<T>, bool> predicate)
		{
			if (predicate(this))
			{
				return this;
			}
			foreach (TreeNode<T> child in Children)
			{
				TreeNode<T> treeNode = child.FindNode(predicate);
				if (treeNode != null)
				{
					return treeNode;
				}
			}
			return null;
		}

		public TreeNode<T> GetNextOrNull()
		{
			int num = Parent._children.IndexOf(this);
			if (num >= 0 && num < Parent.Children.Count - 1)
			{
				return Parent.Children[num + 1];
			}
			return null;
		}

		public bool IsAncestor(TreeNode<T> node)
		{
			if (node == this)
			{
				return true;
			}
			foreach (TreeNode<T> child in Children)
			{
				if (child.IsAncestor(node))
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool MoveToContainer(TreeNode<T> container, TreeNode<T> insertBefore)
		{
			SetParent(container, insertBefore);
			return true;
		}

		public void SetParent(TreeNode<T> parent, TreeNode<T> insertBefore = null)
		{
			if (Parent != null)
			{
				Parent._children.Remove(this);
			}
			Parent = parent;
			if (Parent != null)
			{
				int num = Parent._children.IndexOf(insertBefore);
				if (num >= 0 && insertBefore != null)
				{
					Parent._children.Insert(num, this);
				}
				else
				{
					Parent._children.Add(this);
				}
			}
			Indent = (parent?.Indent ?? 0) + 1;
		}

		public void UpdateIndent()
		{
			if (RowElement != null)
			{
				RowElement.GetElementByInternalId("inner-panel").rectTransform.offsetMin = new Vector2(_indent * 15, 0f);
			}
		}

		public void UpdateRowElements()
		{
			UpdateRowElements(0, Indent, collapsedSubTree: false);
		}

		protected virtual void OnArrowClicked(TreeNode<T> node)
		{
			if (node != null)
			{
				node.Collapsed = !node.Collapsed;
				Root.UpdateRowElements();
			}
		}

		protected virtual int UpdateRowElements(int index, int indent, bool collapsedSubTree)
		{
			if (RowElement != null)
			{
				RowElement.transform.SetSiblingIndex(index++);
				RowElement.SetActive(!collapsedSubTree && Parent != null);
			}
			Indent = indent;
			if (SupportsArrow)
			{
				if (ShowCollapseArrow)
				{
					_arrow?.SetActive(active: true);
				}
				else
				{
					_arrow?.SetActive(active: false);
				}
			}
			collapsedSubTree = Collapsed || collapsedSubTree;
			foreach (TreeNode<T> child in Children)
			{
				index = child.UpdateRowElements(index, indent + 1, collapsedSubTree);
			}
			return index;
		}
	}
}

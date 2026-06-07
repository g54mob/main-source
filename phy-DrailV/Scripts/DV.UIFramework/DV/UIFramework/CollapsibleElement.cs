using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UIFramework
{
	public class CollapsibleElement : LayoutElement
	{
		public delegate void CollapsedChangedDelegate(CollapsibleElement element, bool collapsed);

		public delegate void CollapsibleClickedDelegate(CollapsibleElement element);

		public delegate void TextChangeRequestDelegate(CollapsibleElement element, string text);

		public delegate void SelectionChangedDelegate(CollapsibleElement element, bool selected);

		public delegate void SearchMatchChangedDelegate(CollapsibleElement element, bool searchMatched);

		public List<RectTransform> indentationIgnoreChildren = new List<RectTransform>();

		public Vector2 layoutIndentation = Vector2.zero;

		[NonSerialized]
		public CollapsibleElement parentElement;

		[NonSerialized]
		public bool isLeaf;

		private ButtonDV button;

		private bool isCollapsed;

		private bool isSelected;

		private HashSet<CollapsibleElement> childElements = new HashSet<CollapsibleElement>();

		public bool IsCollapsed
		{
			get
			{
				return isCollapsed;
			}
			private set
			{
				if (isCollapsed != value)
				{
					isCollapsed = value;
					this.CollapsedChanged?.Invoke(this, isCollapsed);
				}
			}
		}

		public event CollapsedChangedDelegate CollapsedChanged;

		public event CollapsibleClickedDelegate CollapsibleElementClicked;

		public event TextChangeRequestDelegate TextChangeRequested;

		public event SelectionChangedDelegate SelectionChanged;

		public event SearchMatchChangedDelegate SearchMatchChanged;

		protected override void Awake()
		{
			base.Awake();
			button = GetComponentInChildren<ButtonDV>(includeInactive: true);
			if (button != null)
			{
				button.onClick.AddListener(OnButtonClicked);
			}
			else
			{
				Debug.LogError("CollapsibleElement: Missing button reference. Clicking will not work.", this);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (button != null)
			{
				button.onClick.RemoveListener(OnButtonClicked);
			}
		}

		private void OnButtonClicked()
		{
			this.CollapsibleElementClicked?.Invoke(this);
		}

		public override void CalculateLayoutInputHorizontal()
		{
			base.CalculateLayoutInputHorizontal();
			foreach (RectTransform indentationIgnoreChild in indentationIgnoreChildren)
			{
				if (!(indentationIgnoreChild == null))
				{
					float x = 0f - layoutIndentation.x;
					indentationIgnoreChild.offsetMin = new Vector2(x, indentationIgnoreChild.offsetMin.y);
				}
			}
		}

		public void Collapse(bool deactivate)
		{
			foreach (CollapsibleElement childElement in childElements)
			{
				childElement.Collapse(deactivate: true);
			}
			IsCollapsed = childElements.Count > 0;
			if (deactivate)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		public void Expand(bool expandAll)
		{
			if (expandAll)
			{
				foreach (CollapsibleElement childElement in childElements)
				{
					childElement.Expand(expandAll: true);
				}
			}
			else
			{
				foreach (CollapsibleElement childElement2 in childElements)
				{
					childElement2.gameObject.SetActive(value: true);
				}
			}
			base.gameObject.SetActive(value: true);
			IsCollapsed = false;
		}

		public void Toggle()
		{
			if (IsCollapsed)
			{
				Expand(expandAll: false);
			}
			else
			{
				Collapse(deactivate: false);
			}
		}

		public void AddChild(CollapsibleElement child)
		{
			childElements.Add(child);
			child.parentElement = this;
			child.gameObject.SetActive(value: false);
			IsCollapsed = true;
		}

		public void Select()
		{
			if (isSelected)
			{
				return;
			}
			CollapsibleElement collapsibleElement = parentElement;
			while (collapsibleElement != null)
			{
				if (collapsibleElement.IsCollapsed)
				{
					collapsibleElement.Expand(expandAll: false);
				}
				collapsibleElement = collapsibleElement.parentElement;
			}
			if (isLeaf)
			{
				isSelected = true;
				this.SelectionChanged?.Invoke(this, isSelected);
			}
		}

		public void Deselect()
		{
			if (isSelected)
			{
				isSelected = false;
				this.SelectionChanged?.Invoke(this, isSelected);
			}
		}

		public void SetText(string text)
		{
			this.TextChangeRequested?.Invoke(this, text);
		}

		public void SetSearchMatched(bool matched)
		{
			if (matched)
			{
				CollapsibleElement collapsibleElement = parentElement;
				while (collapsibleElement != null)
				{
					if (collapsibleElement.IsCollapsed)
					{
						collapsibleElement.Expand(expandAll: false);
					}
					collapsibleElement = collapsibleElement.parentElement;
				}
			}
			this.SearchMatchChanged?.Invoke(this, matched);
		}
	}
}

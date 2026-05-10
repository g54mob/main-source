using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	[DontApplyToListElements]
	public sealed class ListDrawerSettingsAttribute : Attribute
	{
		public bool HideAddButton;

		public bool HideRemoveButton;

		public string ListElementLabelName;

		public string CustomAddFunction;

		[LabelWidth(200f)]
		public string CustomRemoveIndexFunction;

		[LabelWidth(200f)]
		public string CustomRemoveElementFunction;

		public string OnBeginListElementGUI;

		public string OnEndListElementGUI;

		public bool AlwaysAddDefaultValue;

		public bool AddCopiesLastElement;

		[ColorResolver]
		public string ElementColor;

		private string onTitleBarGUI;

		private int numberOfItemsPerPage;

		private bool paging;

		private bool draggable;

		private bool isReadOnly;

		private bool showItemCount;

		private bool pagingHasValue;

		private bool draggableHasValue;

		private bool isReadOnlyHasValue;

		private bool showItemCountHasValue;

		private bool numberOfItemsPerPageHasValue;

		private bool showIndexLabels;

		private bool showIndexLabelsHasValue;

		private bool defaultExpandedStateHasValue;

		private bool defaultExpandedState;

		public bool ShowFoldout;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "paging", "pagingHasValue" })]
		public bool ShowPaging
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "draggable", "draggableHasValue" })]
		public bool DraggableItems
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "numberOfItemsPerPage", "numberOfItemsPerPageHasValue" })]
		public int NumberOfItemsPerPage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "isReadOnly", "isReadOnlyHasValue" })]
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "showItemCount", "showItemCountHasValue" })]
		public bool ShowItemCount
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Use ShowFoldout instead, which is what Expanded has always done. If you want to control the default expanded state, use DefaultExpandedState. Expanded has been implemented wrong for a long time.", false)]
		public bool Expanded
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "defaultExpandedState", "defaultExpandedStateHasValue" })]
		public bool DefaultExpandedState
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "showIndexLabels", "showIndexLabelsHasValue" })]
		public bool ShowIndexLabels
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "onTitleBarGUI" })]
		public string OnTitleBarGUI
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool PagingHasValue => false;

		public bool ShowItemCountHasValue => false;

		public bool NumberOfItemsPerPageHasValue => false;

		public bool DraggableHasValue => false;

		public bool IsReadOnlyHasValue => false;

		public bool ShowIndexLabelsHasValue => false;

		public bool DefaultExpandedStateHasValue => false;
	}
}

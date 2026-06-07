using System;
using System.Diagnostics;
using UnityEngine;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	[Conditional("UNITY_EDITOR")]
	public class TableListAttribute : Attribute
	{
		public int NumberOfItemsPerPage;

		public bool IsReadOnly;

		public int DefaultMinColumnWidth;

		public bool ShowIndexLabels;

		public bool DrawScrollView;

		public int MinScrollViewHeight;

		public int MaxScrollViewHeight;

		public bool AlwaysExpanded;

		public bool HideToolbar;

		public int CellPadding;

		[SerializeField]
		[HideInInspector]
		private bool showPagingHasValue;

		[SerializeField]
		[HideInInspector]
		private bool showPaging;

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

		public bool ShowPagingHasValue => false;

		public int ScrollViewHeight
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}
	}
}

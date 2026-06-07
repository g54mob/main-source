using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputMapCategory : InputCategory
	{
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _checkConflictsWithAllCategories;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<int> _checkConflictsCategoryIds;

		private ReadOnlyCollection<int> _checkConflictsCategoryIds_readOnly;

		public bool checkConflictsWithAllCategories
		{
			get
			{
				return _checkConflictsWithAllCategories;
			}
			internal set
			{
				_checkConflictsWithAllCategories = value;
			}
		}

		public IList<int> checkConflictsCategoryIds
		{
			get
			{
				return _checkConflictsCategoryIds_readOnly;
			}
		}

		internal List<int> checkConflictsCategoryIds_orig
		{
			get
			{
				return _checkConflictsCategoryIds;
			}
		}

		public InputMapCategory()
		{
			_checkConflictsCategoryIds = new List<int>();
		}

		public InputMapCategory(InputMapCategory source)
			: base(source)
		{
			_checkConflictsWithAllCategories = source._checkConflictsWithAllCategories;
			_checkConflictsCategoryIds = ListTools.ShallowCopy(source._checkConflictsCategoryIds);
		}

		internal void dFyvOnKBbTYzKLbxHBbiIGdcrpeH()
		{
			if (_checkConflictsCategoryIds != null)
			{
				_checkConflictsCategoryIds_readOnly = new ReadOnlyCollection<int>(_checkConflictsCategoryIds);
			}
		}
	}
}

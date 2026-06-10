using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputMapCategory : InputCategory
	{
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _checkConflictsWithAllCategories;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<int> _checkConflictsCategoryIds;

		private ReadOnlyCollection<int> _checkConflictsCategoryIds_readOnly;

		public bool checkConflictsWithAllCategories
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public IList<int> checkConflictsCategoryIds => null;

		internal List<int> checkConflictsCategoryIds_orig => null;

		public InputMapCategory()
		{
		}

		public InputMapCategory(InputMapCategory source)
		{
		}

		internal void yevEaEOpxaTseresMwWwEaZGFmnj()
		{
		}
	}
}

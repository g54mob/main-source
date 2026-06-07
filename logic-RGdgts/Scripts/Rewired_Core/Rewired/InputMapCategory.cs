using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputMapCategory : InputCategory
	{
		[CustomObfuscation]
		[SerializeField]
		private bool _checkConflictsWithAllCategories;

		[CustomObfuscation]
		[SerializeField]
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

		internal List<int> PWekGiBsxoKNDMYZSDuzyDDgagy => null;

		public InputMapCategory()
		{
		}

		public InputMapCategory(InputMapCategory P_0)
		{
		}

		internal void gUxczTgMdKUcYRnCXamteWaCXJodc()
		{
		}
	}
}

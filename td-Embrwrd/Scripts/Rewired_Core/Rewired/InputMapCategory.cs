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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<int> _checkConflictsCategoryIds;

		private ReadOnlyCollection<int> _checkConflictsCategoryIds_readOnly;

		internal override string keyCategory => null;

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

		internal List<int> NvKTpAJQWRNpgWhgiVFDyLYAsHpA => null;

		public InputMapCategory()
		{
		}

		public InputMapCategory(InputMapCategory P_0)
		{
		}

		internal override void ZZMjnVEmerGakmqPbAVaqWetfITIA()
		{
		}

		internal override void fctRAgpiaDZgjgsrNjkskqtYXbiy()
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputMapCategory : InputCategory
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _checkConflictsWithAllCategories;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		internal List<int> IxiEHtJYoXfahiMaFLhhUqHgNmIoA => null;

		public InputMapCategory()
		{
		}

		public InputMapCategory(InputMapCategory P_0)
		{
		}

		internal override void OTNlqTDvKkLXyQNECbJYedgXGAGy()
		{
		}

		internal override void qHeUKakOCOTsvUcggKaCulxmnoxf()
		{
		}
	}
}

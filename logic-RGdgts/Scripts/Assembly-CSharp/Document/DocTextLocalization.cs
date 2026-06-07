using System;
using UnityEngine.Localization;

namespace Document
{
	[Serializable]
	public struct DocTextLocalization
	{
		public LocalizedString localizedString;

		public DocTextLocalization(LocalizedString localizedString)
		{
			this.localizedString = null;
		}
	}
}

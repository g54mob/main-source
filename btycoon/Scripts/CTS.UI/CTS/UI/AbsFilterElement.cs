using System;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS.UI
{
	[Serializable]
	public abstract class AbsFilterElement
	{
		[field: SerializeField]
		public LocalizedString Title { get; protected set; }

		[field: SerializeField]
		public Sprite Icon { get; protected set; }

		[field: SerializeField]
		public LocalizedString ToolTipsText { get; protected set; }

		public abstract int GetIntTag();
	}
}

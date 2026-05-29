using System;
using CTS.BBT;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[Serializable]
	public struct ChoreIcon
	{
		public ChoreCategory chore;

		public Sprite icon;

		public LocalizedString choreTitle;

		public LocalizedString choreText;
	}
}

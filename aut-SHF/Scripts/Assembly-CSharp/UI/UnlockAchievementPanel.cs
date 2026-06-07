using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace UI
{
	public class UnlockAchievementPanel : UnlockContentPanel
	{
		[SerializeField]
		private LocalizedString localizedString;

		[SerializeField]
		private GameObject continuousObj;

		public override void Init(List<string> iconPaths, string text = null)
		{
		}
	}
}

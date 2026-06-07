using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
	public class UnlockAscensionPanel : UnlockContentPanel
	{
		[SerializeField]
		protected TMP_Text ascensionText;

		public override void Init(List<string> iconPaths, string text = null)
		{
		}

		public void InitAscensionText(int from, int to)
		{
		}

		protected override void PlusAnimation()
		{
		}
	}
}

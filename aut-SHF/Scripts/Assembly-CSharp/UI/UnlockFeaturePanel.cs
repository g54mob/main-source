using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
	public class UnlockFeaturePanel : UnlockContentPanel
	{
		[SerializeField]
		private TMP_Text detailText;

		public override void Init(List<string> iconPaths, string text = null)
		{
		}

		public void SetDetailText(string detail)
		{
		}

		protected override void PlusAnimation()
		{
		}
	}
}

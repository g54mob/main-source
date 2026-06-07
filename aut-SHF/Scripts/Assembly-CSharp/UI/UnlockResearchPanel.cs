using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UnlockResearchPanel : UnlockContentPanel
	{
		[SerializeField]
		protected Image iconFrame;

		public override void Init(List<string> iconPaths, string text = null)
		{
		}
	}
}

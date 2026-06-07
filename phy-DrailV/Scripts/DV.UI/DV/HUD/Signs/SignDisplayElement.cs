using DV.Common;
using TMPro;
using UnityEngine;

namespace DV.HUD.Signs
{
	public class SignDisplayElement : ASignDisplayElement
	{
		private TextMeshProUGUI tmpro;

		public override void SetText(string value)
		{
			if (!tmpro)
			{
				tmpro = GetComponentInChildren<TextMeshProUGUI>();
			}
			if ((bool)tmpro)
			{
				tmpro.text = value;
			}
			else
			{
				Debug.LogWarning("Tried to set text value but TMP is missing.", this);
			}
		}
	}
}

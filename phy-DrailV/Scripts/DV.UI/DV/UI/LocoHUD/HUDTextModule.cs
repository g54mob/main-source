using TMPro;
using UnityEngine;

namespace DV.UI.LocoHUD
{
	public class HUDTextModule : MonoBehaviour
	{
		public TextMeshProUGUI textValue;

		public TextMeshProUGUI textUnit;

		public void SetTextValue(string value)
		{
			if ((bool)textValue)
			{
				textValue.text = value;
			}
		}

		public void SetTextUnit(string value)
		{
			if ((bool)textUnit)
			{
				textUnit.text = value;
			}
		}
	}
}

using TMPro;
using UnityEngine;

namespace DV.UI.LocoHUD
{
	public class HUDTextLabelNameProvider : HUDElementNameProviderBase
	{
		private const string TEXT_LABEL_NAME = "text-label";

		public override string GetName()
		{
			Transform transform = base.transform.Find("text-label");
			if (!transform)
			{
				return "";
			}
			return transform.GetComponent<TextMeshProUGUI>().text;
		}
	}
}

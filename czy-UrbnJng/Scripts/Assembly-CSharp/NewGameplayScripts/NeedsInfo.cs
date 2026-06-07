using System;
using TMPro;
using UnityEngine;

namespace NewGameplayScripts
{
	[Serializable]
	public class NeedsInfo
	{
		public Transform icon;

		public Transform iconBG;

		public TextMeshProUGUI text;

		public void Hide()
		{
			icon.gameObject.SetActive(value: false);
			iconBG.gameObject.SetActive(value: false);
			text.gameObject.SetActive(value: false);
		}

		public void Show()
		{
			icon.gameObject.SetActive(value: true);
			iconBG.gameObject.SetActive(value: true);
			text.gameObject.SetActive(value: true);
		}
	}
}

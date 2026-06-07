using DV.Common;
using TMPro;
using UnityEngine;

namespace DV.HUD.Signs
{
	public class TrackIDSignDisplayElement : ASignDisplayElement
	{
		public const char SEPARATOR = '|';

		private TextMeshProUGUI[] texts;

		public override void SetText(string value)
		{
			if (texts == null)
			{
				texts = GetComponentsInChildren<TextMeshProUGUI>();
			}
			if (texts.Length != 2)
			{
				Debug.LogError("Didn't find exactly 2 texts!", base.gameObject);
				return;
			}
			string[] array = value.Split('|');
			texts[0].text = array[0];
			texts[1].text = array[1];
		}
	}
}

using TMPro;
using UnityEngine;

namespace Kamgam.LocalizationForSettings
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class LocalizeTMPro : LocalizeBase
	{
		public TextMeshProUGUI Textfield;

		public override void Awake()
		{
			Textfield = GetComponent<TextMeshProUGUI>();
			base.Awake();
		}

		public override string GetText()
		{
			if ((Object)(object)Textfield != null)
			{
				return Textfield.text;
			}
			return null;
		}

		public override void SetText(string text)
		{
			if ((Object)(object)Textfield != null)
			{
				Textfield.text = text;
			}
		}
	}
}

using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class LabelledOptionData : TMP_Dropdown.OptionData
	{
		public string Value { get; private set; }

		public string Label => null;

		public LabelledOptionData(string label, string value, Sprite image = null)
		{
		}
	}
}

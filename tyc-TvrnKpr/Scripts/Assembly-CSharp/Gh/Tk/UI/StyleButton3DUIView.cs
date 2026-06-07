using System.Collections.Generic;
using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class StyleButton3DUIView : Button3DUIView
	{
		[SerializeField]
		private TextMeshProI18n _labelText;

		[SerializeField]
		private TextMeshPro _costText;

		[SerializeField]
		private List<SwatchButton3DUIView> _swatchButtons;

		public string StyleId { get; set; }

		protected override void Awake()
		{
		}

		public void SetLabelKey(string labelKey)
		{
		}

		public void SetCost(int cost)
		{
		}

		public void SetSwatches(List<StyleSwatch> swatches)
		{
		}
	}
}

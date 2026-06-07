using UnityEngine;

namespace Gh.Tk
{
	public class PatronSatisfactionCategoryButton3DUIView : Button3DUIView
	{
		private GameObject _icon;

		private string _categoryCapitalized;

		private string _labelContentKey;

		public string Category { get; private set; }

		public bool PatronAttractionDisplayMode { get; set; }

		public void SetCategory(string category)
		{
		}

		public void SetSatisfactionValue(int value)
		{
		}

		public void SetLabelKey(string labelKey)
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}
	}
}

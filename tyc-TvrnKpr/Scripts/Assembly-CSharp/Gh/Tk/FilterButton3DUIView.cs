using System.Collections.Generic;
using Gh.Tk.Story;
using TMPro;
using UnityEngine;

namespace Gh.Tk
{
	public class FilterButton3DUIView : Button3DUIView
	{
		public const string DECOR_FILTER_ID_PREFIX = "decor_";

		public bool isZoneFilter;

		public string filterId;

		[DropDownChoice(typeof(StoryHelper), "GetAllPatronNeedTypes")]
		public List<string> requiredNeeds;

		public Material enabledMaterial;

		public Material disabledMaterial;

		public Color enabledTextColor;

		public Color disabledTextColor;

		private Renderer[] _renderers;

		private TextMeshPro[] _textMeshes;

		private TMP_Text _searchCountText;

		public override bool IsBlocked => false;

		protected override void Awake()
		{
		}

		public void SetSearchCountText(int amount)
		{
		}

		protected override void UpdateColourChanger()
		{
		}
	}
}

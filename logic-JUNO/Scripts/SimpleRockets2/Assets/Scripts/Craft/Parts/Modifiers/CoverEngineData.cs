using System;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	public class CoverEngineData : PartModifierData<CoverEngineScript>
	{
		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Cover Engine", Tooltip = "Determines if this part should automatically try to resize itself to cover an engine when connected to the same spot on a fuel tank.")]
		private bool _coverEngine = true;

		public bool CoverEngine => _coverEngine;
	}
}

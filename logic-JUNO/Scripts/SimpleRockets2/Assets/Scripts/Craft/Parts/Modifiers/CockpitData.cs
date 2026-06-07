using System;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Cockpit")]
	[PartModifierTypeId("Cockpit")]
	public class CockpitData : PartModifierData<CockpitScript>
	{
	}
}

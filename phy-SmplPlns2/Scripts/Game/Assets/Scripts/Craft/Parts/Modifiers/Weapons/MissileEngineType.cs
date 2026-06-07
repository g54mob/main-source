using Jundroo.Common.Attributes;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public enum MissileEngineType
	{
		[DisplayName("Solid")]
		Solid = 0,
		[DisplayName("Thrust Vector")]
		ThrustVector = 1,
		[DisplayName("Jet")]
		Jet = 2
	}
}

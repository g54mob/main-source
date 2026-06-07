using Jundroo.Common.Attributes;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public enum SeekerType
	{
		[DisplayName("Unguided")]
		Unguided = 0,
		[DisplayName("Infrared")]
		Infrared = 1,
		[DisplayName("Semi-Active Radar")]
		SemiActiveRadar = 2,
		[DisplayName("Active Radar")]
		ActiveRadar = 3,
		[DisplayName("Laser")]
		Laser = 4,
		[DisplayName("Anti-Radiation")]
		AntiRadiation = 5
	}
}

using Jundroo.Common.Attributes;

namespace Assets.Scripts.Flight.Combat
{
	public enum WeaponFunction
	{
		[DisplayName("None")]
		None = 0,
		[DisplayName("Air-to-Air")]
		AirToAir = 1,
		[DisplayName("Air-to-Ground")]
		AirToSurface = 2,
		[DisplayName("Multi-Role")]
		MultiRole = 3
	}
}

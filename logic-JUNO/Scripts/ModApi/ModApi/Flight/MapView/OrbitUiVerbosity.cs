using ModApi.Common.Attributes;

namespace ModApi.Flight.MapView
{
	public enum OrbitUiVerbosity
	{
		[DisplayName("High")]
		High = 3,
		[DisplayName("Medium")]
		Medium = 2,
		[DisplayName("Low")]
		Low = 1,
		[DisplayName("Minimal")]
		Minimal = 0
	}
}

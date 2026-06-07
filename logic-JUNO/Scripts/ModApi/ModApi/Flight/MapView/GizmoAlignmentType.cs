using ModApi.Common.Attributes;

namespace ModApi.Flight.MapView
{
	public enum GizmoAlignmentType
	{
		[DisplayName("Reference")]
		ReferenceOrbit = 0,
		[DisplayName("New")]
		NewOrbit = 1
	}
}

using ModApi.Common.Attributes;

namespace Assets.Scripts.Flight.MapView.Orbits.DrawModes.Interfaces.IDrawMode
{
	public enum ModeType
	{
		[DisplayName("Hybrid")]
		HybridTime = 0,
		[DisplayName("Enctr Exit")]
		EncounterNodeAtExitTime = 1,
		[DisplayName("Ref. Time")]
		ParentAtReferenceTime = 2,
		[DisplayName("Point Time")]
		ParentAtPointTime = 3,
		[DisplayName("Curr. Time")]
		ParentAtCurrentTime = 4,
		[DisplayName("Sblng Pt T")]
		SiblingAtPointTime = 5,
		[DisplayName("Basic")]
		Basic = 6
	}
}

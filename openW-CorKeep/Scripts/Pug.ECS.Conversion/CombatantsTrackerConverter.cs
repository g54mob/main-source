using Pug.Conversion;

public class CombatantsTrackerConverter : SingleAuthoringComponentConverter<CombatantsTrackerAuthoring>
{
	protected override void Convert(CombatantsTrackerAuthoring authoring)
	{
		EnsureHasBuffer<CombatantsTrackerBuffer>();
		EnsureHasBuffer<NewCombatantsBuffer>();
	}
}

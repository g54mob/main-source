using Pug.Conversion;

public class EnrageStateConverter : SingleAuthoringComponentConverter<EnrageStateAuthoring>
{
	protected override void Convert(EnrageStateAuthoring authoring)
	{
		SetProperty("EnrageState/enrageAtHealthRatio", authoring.enrageAtHealthRatio);
		SetProperty("EnrageState/leaveEnrageAtHealthRatio", authoring.leaveEnrageAtHealthRatio);
		SetProperty("EnrageState/duration", authoring.duration);
		EnsureHasComponent<EnrageStateCD>();
		EnsureHasComponent<IsInCombatCD>();
	}
}

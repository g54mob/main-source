using Pug.Conversion;

public class CicadaBossConverter : SingleAuthoringComponentConverter<CicadaBossAuthoring>
{
	protected override void Convert(CicadaBossAuthoring authoring)
	{
		EnsureHasComponent<CicadaEnemyCD>();
		EnsureHasComponent<SummonedEnemyCD>();
	}
}

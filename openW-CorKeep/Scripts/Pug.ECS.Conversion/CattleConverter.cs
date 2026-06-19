using Pug.Conversion;

public class CattleConverter : SingleAuthoringComponentConverter<CattleAuthoring>
{
	protected override void Convert(CattleAuthoring authoring)
	{
		EnsureHasComponent<CattleCD>();
		EnsureHasComponent<LeashedCD>();
	}
}

using Pug.Conversion;

public class EnemyConverter : SingleAuthoringComponentConverter<EnemyAuthoring>
{
	protected override void Convert(EnemyAuthoring authoring)
	{
		EnsureHasComponent<EnemyCD>();
		EnsureHasComponent<IsCloneCD>(componentIsEnabled: false);
		EnsureHasComponent<LastAttackerCD>();
		if (authoring.dontBlockPlayerMovement)
		{
			SetProperty("Enemy/dontBlockPlayerMovement");
		}
	}
}

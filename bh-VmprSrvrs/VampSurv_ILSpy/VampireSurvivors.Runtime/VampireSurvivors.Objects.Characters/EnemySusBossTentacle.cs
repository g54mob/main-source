namespace VampireSurvivors.Objects.Characters;

public class EnemySusBossTentacle : EnemyController
{
	private bool _isLeft;

	public void SetupTentacle(bool isLeft)
	{
		_isLeft = isLeft;
		base._003CIsCullable_003Ek__BackingField = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
	}

	protected override void OnUpdate()
	{
	}
}

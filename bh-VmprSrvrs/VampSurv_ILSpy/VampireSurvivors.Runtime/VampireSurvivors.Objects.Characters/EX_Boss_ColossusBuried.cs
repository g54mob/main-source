using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters;

public class EX_Boss_ColossusBuried : EnemyControllerBoss
{
	public override void InitEnemy(EnemyType enemyType, bool asRemote = false)
	{
		base.InitEnemy(enemyType, asRemote);
		BaseBody baseBody = body;
		((EnemyController)this)._003CIsCullable_003Ek__BackingField = false;
		baseBody._immovable = true;
	}

	protected override void OnUpdate()
	{
		if (!((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			base.UpdateDepth();
		}
	}

	public override void Despawn()
	{
		base.Despawn();
		if (!((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			((EnemyController)this)._003CIsCullable_003Ek__BackingField = false;
		}
	}
}

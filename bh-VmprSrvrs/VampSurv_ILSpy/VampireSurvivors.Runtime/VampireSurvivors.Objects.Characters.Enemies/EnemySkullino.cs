using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemySkullino : EnemyController
{
	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_003a: Expected O, but got F4
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		base.InitEnemy(enemyType, asRemote);
		EnemyData currentEnemyData = _currentEnemyData;
		base._003CSpeed_003Ek__BackingField = currentEnemyData._003Cspeed_003Ek__BackingField;
		object obj = Random.value;
		object obj3 = default(object);
		object obj2 = obj3 * base._003CSpeed_003Ek__BackingField;
		float num = (float)obj2 * 0.3f;
		float num2 = num + currentEnemyData._003Cspeed_003Ek__BackingField;
		base._003CSpeed_003Ek__BackingField = num2;
	}
}

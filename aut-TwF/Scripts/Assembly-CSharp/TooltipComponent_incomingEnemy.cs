using System.Collections.Generic;

public class TooltipComponent_incomingEnemy : TooltipComponent
{
	protected override Dictionary<string, object> GetData()
	{
		IncomingEnemiesUI_enemy component = GetComponent<IncomingEnemiesUI_enemy>();
		return new Dictionary<string, object>
		{
			{ "enemyData", component.EnemyData },
			{ "cycle", component.Cycle }
		};
	}
}

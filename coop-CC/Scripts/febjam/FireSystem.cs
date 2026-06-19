using Aggro.Core;
using Mirror;

[UpdateInGroup(typeof(SimulationSystemGroup), 10)]
public class FireSystem : EntityObjectSystemBase<Flammable>
{
	protected override bool ShouldRun()
	{
		return NetworkServer.active;
	}

	protected override void OnUpdateObjectSystem(QueryResults<Flammable> results)
	{
		for (int i = 0; i < results.count; i++)
		{
			results[i].ServerSystemProcessHeatSurrounding();
		}
		for (int j = 0; j < results.count; j++)
		{
			results[j].ServerSystemProcessFire();
		}
	}
}

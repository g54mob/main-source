using Aggro.Core;
using Mirror;
using UnityEngine;

[UpdateInGroup(typeof(SimulationSystemGroup), UpdatePriority.Normal)]
public class BoxDestroySystem : EntityObjectSystemBase<Grabbable>
{
	private const float KILL_FLOOR_Y = -10f;

	private const float KILL_CEIL_Y = 1000f;

	protected override void OnUpdateObjectSystem(QueryResults<Grabbable> results)
	{
		if (!NetworkServer.active)
		{
			return;
		}
		for (int i = 0; i < results.count; i++)
		{
			Entity entity = results.GetEntity(i);
			float y = entity.transform.position.y;
			if (y <= -10f || y >= 1000f)
			{
				RoomType roomType = RoomType.None;
				if (entity.TryGetStruct<EntityContextComp>(out var comp))
				{
					roomType = comp.roomType;
				}
				Debug.LogWarning($"Box out of bounds, Destroying! Box: {entity.name} RoomType: {roomType} Scene: {GameUtil.currentWarehouseSceneName}");
				EntityUtil.Destroy(entity);
			}
		}
	}
}

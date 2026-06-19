using Aggro.Core;
using UnityEngine;

[UpdateInGroup(typeof(PhysicsSystemGroup), 10)]
public class PhysicsUpdateSystem : EntitySystemBase
{
	protected override void OnUpdateSystem()
	{
		Physics.Simulate(Time.fixedDeltaTime);
		if (GameUtil.TryGetLocalPlayer(out var player) && player.HasObject<Rigidbody>())
		{
			Vector3 position = player.rigidbody.position;
			player.rigidbody.MovePosition(new Vector3(position.x, 0f, position.z));
		}
	}
}

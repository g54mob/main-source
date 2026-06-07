using Unity.Collections;
using UnityEngine;

public class SoundEmitterBranch : MonoBehaviour
{
	public void BatchOverlapSphere()
	{
		NativeArray<OverlapSphereCommand> commands = new NativeArray<OverlapSphereCommand>(1, Allocator.TempJob);
		NativeArray<ColliderHit> results = new NativeArray<ColliderHit>(3, Allocator.TempJob);
		commands[0] = new OverlapSphereCommand(base.transform.position, 10f, QueryParameters.Default);
		OverlapSphereCommand.ScheduleBatch(commands, results, 1, 3).Complete();
		foreach (ColliderHit item in results)
		{
			Debug.Log(item.collider.name);
		}
		commands.Dispose();
		results.Dispose();
	}
}

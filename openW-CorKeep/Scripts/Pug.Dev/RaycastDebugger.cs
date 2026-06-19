using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class RaycastDebugger : MonoBehaviour
{
	private void OnDrawGizmos()
	{
		if (Application.isPlaying)
		{
			_ = Time.time * 0.1f % 1f;
			float2 float5 = base.transform.forward.XZ().normalized;
			if (Manager.multiMap.RaycastWalls(base.transform.position.ToWorld().XZ(), float5, 100f, out var hitInfo))
			{
				Gizmos.color = Color.red;
				Gizmos.DrawLine(base.transform.position, base.transform.position + (Vector3)float5.X0Y() * hitInfo.distance);
				Gizmos.color = Color.yellow;
				Gizmos.DrawWireCube(base.transform.position + (Vector3)float5.X0Y() * hitInfo.distance, Vector3.one * 0.25f);
			}
			else
			{
				Gizmos.color = Color.green;
				Gizmos.DrawLine(base.transform.position, base.transform.position + (Vector3)float5.X0Y() * 100f);
			}
		}
	}
}

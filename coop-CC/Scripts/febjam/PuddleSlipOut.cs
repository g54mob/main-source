using Aggro.Core;
using UnityEngine;

public class PuddleSlipOut : EntityBehaviourBase
{
	[Min(0f)]
	public float radius = 1f;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.matrix = Matrix4x4.Scale(new Vector3(1f, 0f, 1f));
		Gizmos.DrawWireSphere(base.transform.position, radius);
	}
}

using CTS.AI;
using UnityEngine;

namespace CTS.BBT
{
	public class Entrance : MonoBehaviour, IContextActor
	{
		[SerializeField]
		private Bounds _bounds;

		[SerializeField]
		private MoveTarget _moveTargetPrefab;

		public ContextActorData ContextActorData { get; } = new ContextActorData();

		public MoveTarget GetEntryPoint()
		{
			return MoveTarget.CreateNew(base.transform.TransformPoint(_bounds.center + new Vector3(Random.Range(0f - _bounds.extents.x, _bounds.extents.x), 0f, Random.Range(0f - _bounds.extents.z, _bounds.extents.z))), Quaternion.identity, AgentPath.EDestinationType.Simple);
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.DrawWireCube(_bounds.center, _bounds.extents * 2f);
		}
	}
}

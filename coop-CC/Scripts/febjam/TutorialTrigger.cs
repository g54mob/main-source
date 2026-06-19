using Aggro.Core;
using UnityEngine;

public class TutorialTrigger : EntityBehaviourBase
{
	private Transform _transform;

	private bool _sent;

	protected override void OnEntityCreated()
	{
		_sent = false;
		_transform = base.transform;
	}

	protected override void OnUpdateSimulation()
	{
		if (!_sent && GameUtil.TryGetLocalPlayer(out var player))
		{
			Vector3 position = player.transform.position;
			Vector3 vector = _transform.InverseTransformPoint(position);
			if (vector.x >= -0.5f && vector.x <= 0.5f && vector.z >= -0.5f && vector.z <= 0.5f)
			{
				AggroManagerBase<TutorialManager>.instance.TutorialTriggerEntered();
				_sent = true;
			}
		}
	}

	private void OnDrawGizmos()
	{
		if (!Application.isPlaying || !_sent)
		{
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Color green = Color.green;
			green.a = 0.5f;
			Gizmos.color = green;
			Gizmos.DrawCube(Vector3.zero, new Vector3(1f, 0.1f, 1f));
		}
	}
}

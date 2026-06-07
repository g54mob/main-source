using UltimateReplay;
using UnityEngine;

public class MirrorReplay : ReplayBehaviour
{
	private Collider mirrorCollider;

	public override void Awake()
	{
		base.Awake();
		mirrorCollider = base.transform.FindChildRecursively("Mirror").GetComponent<Collider>();
	}

	public override void OnReplayStart()
	{
		base.OnReplayStart();
		mirrorCollider.enabled = true;
	}
}

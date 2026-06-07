using UltimateReplay;
using UnityEngine;

public class LevelCollectableReplay : ReplayBehaviour
{
	private MeshRenderer meshRenderer;

	private Rotator rotator;

	public override void Awake()
	{
		base.Awake();
		meshRenderer = GetComponent<MeshRenderer>();
		rotator = GetComponent<Rotator>();
	}

	public override void OnReplayStart()
	{
		base.OnReplayStart();
		rotator.enabled = true;
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		if (meshRenderer != null)
		{
			state.Write(meshRenderer.enabled);
		}
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		if (meshRenderer != null)
		{
			meshRenderer.enabled = state.ReadBool();
		}
	}
}

using UltimateReplay;
using UnityEngine;

public class BlockBodyViewReplay : ReplayBehaviour
{
	private BlockBodyView bodyView;

	public override void Awake()
	{
		base.Awake();
		bodyView = GetComponent<BlockBodyView>();
	}

	public override void OnReplayStart()
	{
		base.OnReplayStart();
		Collider[] allBodyColliders = bodyView.GetAllBodyColliders();
		for (int i = 0; i < allBodyColliders.Length; i++)
		{
			allBodyColliders[i].enabled = true;
		}
	}
}

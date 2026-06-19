using Aggro.Core;
using UnityEngine;

public class PlayerListener : EntityBehaviourBase
{
	public Transform target;

	protected override void OnUpdatePresentationEarly()
	{
		if (GameUtil.TryGetLocalPlayer(out var player) && !GameUtil.isLobby)
		{
			target.position = player.transform.position;
		}
	}
}

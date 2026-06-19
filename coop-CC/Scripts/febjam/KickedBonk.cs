using Aggro.Core;
using UnityEngine;

public class KickedBonk : EntityBehaviourBase, ILocalPlayerKicked
{
	[Min(0f)]
	public float playerForce = 20f;

	public void OnLocalPlayerKicked(Entity player)
	{
		Vector3 vector = player.transform.position - base.entity.transform.position;
		player.GetObject<PlayerStress>().RequestBumpStress();
		player.GetObject<PlayerGrabber>().RequestPlayerDropBoxes(breakStack: true, checkUpgrade: true);
		player.GetObject<PlayerAnimation>().PlayBonk();
		player.GetObject<PlayerColorManagerNetwork>().CmdPlayFlash();
		player.GetObject<VehicleController>().LocalPlayerTakeForce(vector.normalized * playerForce);
	}
}

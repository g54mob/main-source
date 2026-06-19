using UnityEngine;

public class CultistCicada : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, center + new Vector3(-1f, -0.5f, 0f), 5);
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, center + new Vector3(1f, -0.5f, 0f), 5);
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, center + new Vector3(0f, -0.5f, 1f), 5);
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, center + new Vector3(0f, -0.5f, 1f), 5);
	}
}

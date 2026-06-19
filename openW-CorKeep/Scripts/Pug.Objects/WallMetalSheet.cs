using UnityEngine;

public class WallMetalSheet : EntityMonoBehaviour
{
	public override Vector3 center => GetCenter();

	private Vector3 GetCenter()
	{
		return spriteObjects[0].transform.position;
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 position = spriteObjects[0].transform.position;
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, position, 2);
	}
}

using UnityEngine;

public class ChineseKnotDecoration : EntityMonoBehaviour
{
	public override Vector3 center => GetCenter();

	private Vector3 GetCenter()
	{
		return spriteObjects[0].transform.position;
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, spriteObjects[0].transform.position, 2);
	}
}

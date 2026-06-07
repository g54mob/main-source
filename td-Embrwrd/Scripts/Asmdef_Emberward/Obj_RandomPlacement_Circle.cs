using UnityEngine;

public class Obj_RandomPlacement_Circle : AObj_RandomPlacement
{
	[SerializeField]
	[Header("隨機放置的範圍限制(半徑)")]
	private int placementRange;

	public override void TriggerRandomPlacement()
	{
	}
}

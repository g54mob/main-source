using UnityEngine;

public class Obj_RandomPlacement_Square : AObj_RandomPlacement
{
	[Header("隨機放置的範圍限制(xz軸)")]
	[SerializeField]
	private Vector2Int placementRange;

	public override void TriggerRandomPlacement()
	{
	}
}

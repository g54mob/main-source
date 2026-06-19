using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

public class PulseCircuit : EntityMonoBehaviour
{
	public SpriteRenderer sr;

	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		base.OnHide();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		switch (base.variation)
		{
		case 0:
			sr.transform.localEulerAngles = new Vector3(0f, 0f, 270f);
			break;
		case 1:
			sr.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
			break;
		case 2:
			sr.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
			break;
		case 3:
			sr.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			break;
		}
	}
}

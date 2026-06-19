using UnityEngine;

public class AncientChest : Chest
{
	public GameObject effects;

	public override void OnOccupied()
	{
		base.OnOccupied();
		effects.SetActive(base.variation == 1);
	}
}

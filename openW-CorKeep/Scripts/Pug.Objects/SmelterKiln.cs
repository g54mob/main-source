using UnityEngine;

public class SmelterKiln : Furnace
{
	public GameObject lid;

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		lid.SetActive(base.IsActive || base.CurrentBarAmount > 0);
	}
}

using UnityEngine;

public class OilFireTrap : FireTrap
{
	public GameObject fire2;

	public GameObject fire3;

	public float offsetMax = 0.5f;

	public override void OnOccupied()
	{
		base.OnOccupied();
		fire2.transform.localPosition = new Vector3(Random.Range(0f - offsetMax, offsetMax), fire2.transform.localPosition.y, fire2.transform.localPosition.z);
		fire3.transform.localPosition = new Vector3(Random.Range(0f - offsetMax, offsetMax), fire3.transform.localPosition.y, fire3.transform.localPosition.z);
	}
}

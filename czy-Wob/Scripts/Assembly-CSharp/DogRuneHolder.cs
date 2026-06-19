using UnityEngine;

public class DogRuneHolder : MonoBehaviour
{
	public GameObject runeObject;

	public void SetRune(GameObject runePrefab, bool bounce = true)
	{
		if (runeObject != null)
		{
			Object.Destroy(runeObject);
		}
		runeObject = Object.Instantiate(runePrefab, base.transform.position, base.transform.rotation, base.transform);
		if (bounce)
		{
			GetComponent<InchwormBounce>().RequestBounce();
		}
	}
}

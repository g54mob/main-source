using UnityEngine;

public class Duplicator : MonoBehaviour
{
	public GameObject objectToDuplicate;

	public int times = 10;

	public Vector3 offset = new Vector3(10f, 0f, 0f);

	private void Awake()
	{
		if ((bool)objectToDuplicate)
		{
			for (int i = 1; i < times; i++)
			{
				Vector3 position = objectToDuplicate.transform.position + offset * i;
				Object.Instantiate(objectToDuplicate, position, objectToDuplicate.transform.rotation);
			}
		}
	}
}

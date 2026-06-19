using UnityEngine;

public class GardenSign : MonoBehaviour
{
	public Transform displayTransform;

	private GameObject currentDisplayObject;

	public void DisplayNewPreview(InventoryItem item)
	{
		if (currentDisplayObject != null)
		{
			Object.Destroy(currentDisplayObject);
			currentDisplayObject = null;
		}
	}
}

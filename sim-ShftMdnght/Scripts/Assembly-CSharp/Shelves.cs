using UnityEngine;

public class Shelves : MonoBehaviour
{
	public RestockShelf[] restockShelves;

	public static Shelves Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}
}

using UnityEngine;
using cakeslice;

public class ItemCollector : MonoBehaviour
{
	[Header("Components")]
	public InventoryManager inventoryManager;

	[Header("Detection")]
	public DetectionManager detectionManager;

	[Header("ItemData")]
	public InventoryItem Item;

	public Outline outline;

	private void OnValidate()
	{
	}

	private bool CheckAndAddCollider(Transform obj)
	{
		return false;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void CreateInteraction()
	{
	}

	private void GetItem(KeyCode key, object[] param)
	{
	}

	public string CapitalizeFirstLetter(string input)
	{
		return null;
	}
}

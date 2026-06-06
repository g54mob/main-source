using UnityEngine;

public class LiquidPanel : MonoBehaviour, IBuildablePanelElement
{
	[Tooltip("Array of capacity bars that will visualize the fullness of the inventory.")]
	[SerializeField]
	private InventoryPanelCapacityBar[] _capacityBars = new InventoryPanelCapacityBar[0];

	private Inventory _inventory;

	public BuildablePanelElementId Id => BuildablePanelElementId.None;

	private void OnDisable()
	{
		if (_inventory != null)
		{
			_inventory = null;
		}
		base.gameObject.SetActive(value: false);
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		if (finished && (bool)buildable.Inventory && buildable.Properties.ReturnShowElement(this, finished))
		{
			_inventory = buildable.Inventory;
			for (int i = 0; i < _capacityBars.Length; i++)
			{
				_capacityBars[i].Initialize(buildable.Inventory);
			}
			base.gameObject.SetActive(value: true);
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
	}
}

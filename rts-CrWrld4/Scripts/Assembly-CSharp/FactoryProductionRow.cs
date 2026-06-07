using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class FactoryProductionRow : MonoBehaviour
{
	public Toggle makeToggle;

	public RawImage sourceWareImage;

	public RawImage targetWareImage;

	public Text targetWareCostText;

	public Text targetWareText;

	public Toggle slowToggle;

	public Text inventoryText;

	public int sourceWareType;

	public int targetWareType;

	public FactoryPane factoryPane;

	private void Awake()
	{
	}

	public void Refresh()
	{
	}

	public void SetInventoryCount(int amt)
	{
	}

	public void OnRemoveInventory(int amt)
	{
	}

	public void OnMakeToggle(bool val)
	{
	}

	public void OnSlowToggle(bool val)
	{
	}

	private void SetWareImage(int num, RawImage image)
	{
	}
}

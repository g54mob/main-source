using System.Collections.Generic;
using UnityEngine;

public class AutoFeederBoxes : BoxList
{
	public GameObject topArrow;

	public GameObject botArrow;

	public List<GameObject> bubs;

	public AutoFeederGUIController guiRef;

	public Material lockedMat;

	private Vector3 scrollScaleDefault = Vector3.one;

	private Vector3 scrollScaleDisabled = new Vector3(0.5f, 0.5f, 0.5f);

	private InventoryManager managerRef;

	private void Awake()
	{
		boxOffsetX = 3f;
		boxOffsetY = 2.75f;
		boxesPerRow = 5;
		rowsPerScreen = 5;
		scaleInTime = 0.5f;
		scaleOutTime = 0.5f;
		scaleInOffset = 0.025f;
		scaleOutOffset = 0.01f;
	}

	public override void Preload()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		managerRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		ToggleBubs = _ToggleBubs;
		ToggleScrollUp = _ToggleScrollUp;
		ToggleScrollDown = _ToggleScrollDown;
		base.Preload();
	}

	private void _ToggleBubs(bool newVal)
	{
		Vector3 localScale = (newVal ? scrollScaleDefault : scrollScaleDisabled);
		for (int i = 0; i < bubs.Count; i++)
		{
			bubs[i].transform.localScale = localScale;
		}
	}

	private void _ToggleScrollUp(bool newVal)
	{
		Vector3 localScale = (newVal ? scrollScaleDefault : scrollScaleDisabled);
		topArrow.transform.localScale = localScale;
		if (newVal)
		{
			topArrow.GetComponent<CoreButton>().UnlockScale();
		}
		else
		{
			topArrow.GetComponent<CoreButton>().LockScale();
		}
	}

	private void _ToggleScrollDown(bool newVal)
	{
		Vector3 localScale = (newVal ? scrollScaleDefault : scrollScaleDisabled);
		botArrow.transform.localScale = localScale;
		if (newVal)
		{
			botArrow.GetComponent<CoreButton>().UnlockScale();
		}
		else
		{
			botArrow.GetComponent<CoreButton>().LockScale();
		}
	}

	protected override void OnBoxClicked(int index)
	{
		base.SetActiveBox(index);
		if (index < heldObjectsOfType.Count)
		{
			guiRef.UpdateItem((InventoryItem)GetObjectForIndex(index));
		}
	}

	public override object GetSelectedObject()
	{
		return (InventoryItem)heldObjectsOfType[GetWorkingIndex(activeBoxIndex)];
	}

	protected override string GetObjectNameForIndex(int index)
	{
		return ((InventoryItem)heldObjectsOfType[index]).itemNameLocalized;
	}

	protected override string GetObjectDescriptionForIndex(int index)
	{
		return ((InventoryItem)heldObjectsOfType[index]).itemDescriptionLocalized;
	}

	private bool IsObjectUnlocked(InventoryItem item)
	{
		return managerRef.GetUnlockStatusForFood(item);
	}

	protected override void UpdateHeldObjectsOfType()
	{
		List<object> allObjects = GetAllObjects();
		heldObjectsOfType.Clear();
		for (int i = 0; i < allObjects.Count; i++)
		{
			heldObjectsOfType.Add(allObjects[i]);
		}
	}

	protected override int GetNumObjectsForIndex(int index)
	{
		return 1;
	}

	protected override List<object> GetAllObjects()
	{
		List<object> list = new List<object>();
		List<InventoryItem> allItemsOfType = managerRef.GetAllItemsOfType(ItemType.FOOD);
		for (int i = 0; i < allItemsOfType.Count; i++)
		{
			list.Add(allItemsOfType[i]);
		}
		return list;
	}

	protected override void OnBoxesFilled()
	{
		base.OnBoxesFilled();
		for (int i = 0; i < boxes.Count; i++)
		{
			int workingIndex = GetWorkingIndex(i);
			if (workingIndex >= heldObjectsOfType.Count)
			{
				break;
			}
			if (!managerRef.GetUnlockStatusForFood((InventoryItem)heldObjectsOfType[workingIndex]))
			{
				Clickable[] components = GetBackingObject(boxes[i]).GetComponents<Clickable>();
				foreach (Clickable obj in components)
				{
					obj.Unload();
					Object.Destroy(obj);
				}
			}
		}
	}
}

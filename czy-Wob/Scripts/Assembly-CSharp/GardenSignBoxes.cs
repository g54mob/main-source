using System.Collections.Generic;
using UnityEngine;

public class GardenSignBoxes : BoxList
{
	public GameObject topArrow;

	public GameObject botArrow;

	public List<GameObject> bubs;

	public GardenSignGUIController guiRef;

	public Material lockedMat;

	private Vector3 scrollScaleDefault = Vector3.one;

	private Vector3 scrollScaleDisabled = new Vector3(0.5f, 0.5f, 0.5f);

	private InventoryManager managerRef;

	private void Awake()
	{
		boxOffsetX = 5f;
		boxOffsetY = 4.583f;
		boxesPerRow = 3;
		rowsPerScreen = 3;
		instantLoad = true;
		instantUnload = true;
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
			guiRef.UpdateGrowable((GrowableObject)GetObjectForIndex(index));
		}
	}

	public override object GetSelectedObject()
	{
		return (GrowableObject)heldObjectsOfType[GetWorkingIndex(activeBoxIndex)];
	}

	protected override string GetObjectNameForIndex(int index)
	{
		return ((GrowableObject)heldObjectsOfType[index]).finalObject.itemNameLocalized;
	}

	protected override string GetObjectDescriptionForIndex(int index)
	{
		return ((GrowableObject)heldObjectsOfType[index]).finalObject.itemDescriptionLocalized;
	}

	private bool IsObjectUnlocked(int index)
	{
		return IsObjectUnlocked((GrowableObject)GetObjectForIndex(index));
	}

	private bool IsObjectUnlocked(GrowableObject item)
	{
		if (!item.startUnlocked)
		{
			return false;
		}
		return managerRef.GetUnlockStatusForFood(item.finalObject);
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
		List<GrowableObject> allGrowables = managerRef.GetAllGrowables();
		for (int i = 0; i < allGrowables.Count; i++)
		{
			if (IsObjectUnlocked(allGrowables[i]))
			{
				list.Add(allGrowables[i]);
			}
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
			GrowableObject growableObject = (GrowableObject)heldObjectsOfType[workingIndex];
			if (!managerRef.GetUnlockStatusForFood(growableObject.finalObject))
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

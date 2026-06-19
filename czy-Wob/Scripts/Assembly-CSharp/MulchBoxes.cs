using System.Collections.Generic;
using UnityEngine;

public class MulchBoxes : BoxList
{
	public GameObject topArrow;

	public GameObject botArrow;

	public List<GameObject> bubs;

	public GardenSignGUIController guiRef;

	public Material lockedMat;

	private Vector3 scrollScaleDefault = Vector3.one;

	private Vector3 scrollScaleDisabled = new Vector3(0.5f, 0.5f, 0.5f);

	private void Awake()
	{
		rotatePreviews = false;
		boxOffsetX = 5f;
		boxOffsetY = 4.583f;
		boxesPerRow = 3;
		rowsPerScreen = 3;
		instantLoad = true;
		instantUnload = true;
	}

	public override void Preload()
	{
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
			guiRef.UpdateMulchType((Mulch)GetObjectForIndex(index));
		}
	}

	public override object GetSelectedObject()
	{
		return (Mulch)heldObjectsOfType[GetWorkingIndex(activeBoxIndex)];
	}

	protected override GameObject GetPreviewObjectForObject(object obj)
	{
		GameObject obj2 = new GameObject();
		SpriteRenderer spriteRenderer = obj2.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = GetPreviewIconSpriteForObject(obj);
		spriteRenderer.sortingOrder = 25;
		return obj2;
	}

	protected override Sprite GetPreviewIconSpriteForObject(object obj)
	{
		return ((Mulch)obj).icon;
	}

	protected override string GetObjectNameForIndex(int index)
	{
		return ((Mulch)heldObjectsOfType[index]).recipeName;
	}

	protected override string GetObjectDescriptionForIndex(int index)
	{
		return ((Mulch)heldObjectsOfType[index]).recipeDescription;
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
		_ = (Mulch)heldObjectsOfType[index];
		return 0;
	}

	protected override List<object> GetAllObjects()
	{
		return new List<object>();
	}

	protected override void OnBoxesFilled()
	{
		base.OnBoxesFilled();
		for (int i = 0; i < boxes.Count && GetWorkingIndex(i) < heldObjectsOfType.Count; i++)
		{
		}
	}
}

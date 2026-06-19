using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxList : MonoBehaviour
{
	public delegate void ScrollCall(bool toggleVal);

	public GameObject boxPrefab;

	public GameObject activeObjectPreviewHolder;

	public GameObject activeObjectPreviewName;

	public GameObject activeObjectPreviewDescription;

	public GameObject coreObject;

	protected ScrollCall ToggleScrollUp;

	protected ScrollCall ToggleScrollDown;

	protected ScrollCall ToggleBubs;

	protected string selectionName = "SelectionSprite";

	protected string backingName = "ItemBoxSprite";

	protected string objectNumName = "ItemNumSprite";

	protected string previewName = "PreviewObject";

	protected GameObject previewObj;

	protected List<object> heldObjectsOfType = new List<object>();

	protected int startRow;

	private List<Segment> currentEases = new List<Segment>();

	protected int loadingBoxIndex;

	protected List<GameObject> boxes = new List<GameObject>();

	protected Dictionary<object, GameObject> previewCache = new Dictionary<object, GameObject>();

	protected int activeBoxIndex;

	protected ScalableUIContainer.LoadCallback callback;

	protected bool instantLoad;

	protected bool instantUnload;

	protected float scaleInTime = 0.15f;

	protected float scaleOutTime = 0.15f;

	protected int boxesPerRow = 3;

	protected int rowsPerScreen = 2;

	protected float boxOffsetX = 3.5f;

	protected float boxOffsetY = 3.5f;

	protected Vector3 inactiveScale = new Vector3(0.25f, 0.25f, 0.25f);

	protected bool rotatePreviews = true;

	protected Vector3 objectThumbnailPos = new Vector3(0f, 0f, -5f);

	protected Vector3 objectThumbnailScale = Vector3.one;

	protected Vector3 objectThumbnailRot = new Vector3(-35f, -35f, 0f);

	protected bool needsDelayedScaleIn;

	protected bool needsDelayedScaleOut;

	protected float currentOffset;

	protected float scaleInOffset = 0.05f;

	protected float scaleOutOffset = 0.05f;

	protected Inchworm inchwormRef;

	private void Update()
	{
		CheckDelayedEases();
	}

	public virtual object GetSelectedObject()
	{
		Debug.LogError("Override expected.");
		return null;
	}

	public object GetObjectForIndex(int index)
	{
		int workingIndex = GetWorkingIndex(index);
		if (workingIndex >= heldObjectsOfType.Count)
		{
			Debug.LogError("BoxList Out Of Range exception.");
			return null;
		}
		return heldObjectsOfType[workingIndex];
	}

	private GameObject _GetPreviewObjectForIndex(int index)
	{
		GameObject obj = Object.Instantiate(previewCache[heldObjectsOfType[GetWorkingIndex(index)]]);
		obj.SetActive(value: true);
		return obj;
	}

	protected virtual GameObject GetPreviewObjectForObject(object obj)
	{
		Debug.LogError("Override expected.");
		return null;
	}

	protected virtual Sprite GetPreviewIconSpriteForObject(object obj)
	{
		Debug.LogError("Override expected.");
		return null;
	}

	private string _GetObjectNameForIndex(int index)
	{
		return GetObjectNameForIndex(GetWorkingIndex(index));
	}

	protected virtual string GetObjectNameForIndex(int index)
	{
		Debug.LogError("Override expected.");
		return "";
	}

	private string _GetObjectDescriptionForIndex(int index)
	{
		return GetObjectDescriptionForIndex(GetWorkingIndex(index));
	}

	protected virtual string GetObjectDescriptionForIndex(int index)
	{
		Debug.LogError("Override expected.");
		return "";
	}

	protected virtual void UpdateHeldObjectsOfType()
	{
		Debug.LogError("Override expected.");
	}

	protected int _GetNumObjectsForIndex(int index)
	{
		return GetNumObjectsForIndex(GetWorkingIndex(index));
	}

	protected virtual int GetNumObjectsForIndex(int index)
	{
		return 1;
	}

	protected virtual void NoObjectsOfTypeCallback()
	{
	}

	protected int GetWorkingIndex(int index)
	{
		return index + startRow * boxesPerRow;
	}

	protected int GetActualIndex(int workingIndex)
	{
		return workingIndex - startRow * boxesPerRow;
	}

	protected virtual void SetActiveBox(int index)
	{
		if (GetWorkingIndex(index) >= heldObjectsOfType.Count)
		{
			index = 0;
		}
		int num = activeBoxIndex;
		activeBoxIndex = index;
		if (previewObj != null)
		{
			Object.Destroy(previewObj);
			previewObj = null;
		}
		if (heldObjectsOfType.Count == 0)
		{
			if (activeObjectPreviewName != null)
			{
				activeObjectPreviewName.GetComponent<TextMeshPro>().text = "";
			}
			if (activeObjectPreviewDescription != null)
			{
				activeObjectPreviewDescription.GetComponent<TextMeshPro>().text = "";
			}
			return;
		}
		if (num < heldObjectsOfType.Count)
		{
			DeactivateSelection(boxes[num]);
		}
		ActivateSelection(boxes[activeBoxIndex]);
		if (activeObjectPreviewHolder != null)
		{
			previewObj = _GetPreviewObjectForIndex(index);
			ObjectUtil.SetAllLayers(previewObj, LayerMask.NameToLayer("UI"));
			previewObj.transform.SetParent(activeObjectPreviewHolder.transform);
			previewObj.transform.localScale = Vector3.one;
			previewObj.transform.localPosition = Vector3.zero;
			previewObj.transform.localRotation = Quaternion.identity;
		}
		if (activeObjectPreviewName != null)
		{
			activeObjectPreviewName.GetComponent<TextMeshPro>().text = _GetObjectNameForIndex(index);
		}
		if (activeObjectPreviewDescription != null)
		{
			activeObjectPreviewDescription.GetComponent<TextMeshPro>().text = _GetObjectDescriptionForIndex(index);
		}
	}

	private void CreateBoxes()
	{
		for (int i = 0; i < rowsPerScreen; i++)
		{
			for (int j = 0; j < boxesPerRow; j++)
			{
				GameObject gameObject = Object.Instantiate(boxPrefab);
				gameObject.transform.SetParent(base.transform);
				gameObject.transform.localPosition = new Vector3((float)j * boxOffsetX, (float)i * (0f - boxOffsetY));
				gameObject.transform.localScale = Vector3.zero;
				boxes.Add(gameObject);
			}
		}
	}

	protected virtual List<object> GetAllObjects()
	{
		Debug.LogError("Override expected.");
		return new List<object>();
	}

	protected void PreloadPreviews()
	{
		if (previewCache.Count <= 0)
		{
			List<object> allObjects = GetAllObjects();
			for (int i = 0; i < allObjects.Count; i++)
			{
				previewCache[allObjects[i]] = GetPreviewObjectForObject(allObjects[i]);
				previewCache[allObjects[i]].SetActive(value: false);
			}
		}
	}

	protected virtual void OnBoxClicked(int index)
	{
		SetActiveBox(index);
	}

	private void CheckDelayedEases()
	{
		if (needsDelayedScaleIn)
		{
			currentOffset += Time.deltaTime;
			if (currentOffset >= scaleInOffset)
			{
				LoadNextBox();
			}
		}
		else if (needsDelayedScaleOut)
		{
			currentOffset += Time.deltaTime;
			if (currentOffset >= scaleOutOffset)
			{
				UnloadNextBox();
			}
		}
	}

	public virtual void Preload()
	{
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		CreateBoxes();
		PreloadPreviews();
		UpdateHeldObjectsOfType();
		SetActiveBox(activeBoxIndex);
		startRow = 0;
	}

	public virtual void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		callback = loadCallback;
		needsDelayedScaleIn = true;
		if (instantLoad)
		{
			while (needsDelayedScaleIn)
			{
				LoadNextBox();
			}
		}
		else
		{
			LoadNextBox();
		}
	}

	public virtual void ForceImmediateUnload()
	{
		loadingBoxIndex = 0;
		for (int i = 0; i < currentEases.Count; i++)
		{
			Segment segment = currentEases[i];
			inchwormRef.CancelEase(ref segment);
		}
		currentEases.Clear();
		ClearBoxes();
		for (int j = 0; j < boxes.Count; j++)
		{
			InternalBoxUnload(boxes[j]);
			boxes[j].transform.localScale = Vector3.zero;
		}
		OnUnloadComplete();
	}

	public virtual void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		if (instantUnload)
		{
			callback = unloadCallback;
			ForceImmediateUnload();
			return;
		}
		RemoveClickables();
		needsDelayedScaleOut = true;
		callback = unloadCallback;
		UnloadNextBox();
	}

	public void ScrollDown()
	{
		int num = boxesPerRow * rowsPerScreen;
		int num2 = heldObjectsOfType.Count / boxesPerRow;
		if (heldObjectsOfType.Count > num && startRow + rowsPerScreen - 1 < num2)
		{
			startRow += rowsPerScreen;
			ClearBoxes();
			FillBoxes();
			SetActiveBox(activeBoxIndex);
		}
	}

	public void ScrollUp()
	{
		int num = boxesPerRow * rowsPerScreen;
		if (heldObjectsOfType.Count > num && startRow > 0)
		{
			startRow -= rowsPerScreen;
			ClearBoxes();
			FillBoxes();
			SetActiveBox(activeBoxIndex);
		}
	}

	protected void RemoveClickables()
	{
		for (int i = 0; i < boxes.Count; i++)
		{
			GameObject backingObject = GetBackingObject(boxes[i]);
			if (!(backingObject == null))
			{
				Clickable component = backingObject.GetComponent<Clickable>();
				if (component != null)
				{
					component.Unload();
					component = null;
				}
			}
		}
	}

	private void ActivateSelection(GameObject box)
	{
		GetSelectionObject(box).SetActive(value: true);
	}

	private void DeactivateSelection(GameObject box)
	{
		GetSelectionObject(box).SetActive(value: false);
	}

	public void UpdateType()
	{
		ClearBoxes();
		DeactivateSelection(boxes[activeBoxIndex]);
		UpdateHeldObjectsOfType();
		activeBoxIndex = 0;
		SetActiveBox(activeBoxIndex);
		startRow = 0;
		FillBoxes();
	}

	protected void ClearBoxes()
	{
		for (int i = 0; i < boxes.Count; i++)
		{
			GameObject previewObject = GetPreviewObject(boxes[i]);
			if (previewObject != null)
			{
				Object.Destroy(previewObject);
			}
			GameObject backingObject = GetBackingObject(boxes[i]);
			if (!(backingObject == null))
			{
				Clickable component = backingObject.GetComponent<Clickable>();
				if (component != null)
				{
					component.Unload();
					Object.Destroy(component);
					component = null;
				}
				GameObject objectNumObject = GetObjectNumObject(boxes[i]);
				if (objectNumObject != null)
				{
					objectNumObject.SetActive(value: false);
				}
			}
		}
	}

	protected virtual void FillBoxes()
	{
		for (int i = 0; i < boxes.Count; i++)
		{
			Clickable clickable = GetBackingObject(boxes[i]).AddComponent<Clickable>();
			if (GetWorkingIndex(i) < heldObjectsOfType.Count)
			{
				clickable.enabled = true;
				boxes[i].transform.localScale = Vector3.one;
				clickable.SetClickCallbacks(null, OnBoxClicked, null, null, i);
				clickable.SetClickCallbackTime(Clickable.CallbackTime.CLICK_START);
			}
			else
			{
				clickable.enabled = false;
				boxes[i].transform.localScale = inactiveScale;
			}
			FillBox(boxes[i], i);
		}
		UpdateScrolling();
		OnBoxesFilled();
	}

	public void UpdateScrolling()
	{
		if (heldObjectsOfType.Count <= rowsPerScreen * boxesPerRow)
		{
			ToggleBubs(toggleVal: false);
			ToggleScrollUp(toggleVal: false);
			ToggleScrollDown(toggleVal: false);
			return;
		}
		ToggleBubs(toggleVal: true);
		if (startRow * boxesPerRow + rowsPerScreen * boxesPerRow >= heldObjectsOfType.Count)
		{
			ToggleScrollDown(toggleVal: false);
		}
		else
		{
			ToggleScrollDown(toggleVal: true);
		}
		if (startRow == 0)
		{
			ToggleScrollUp(toggleVal: false);
		}
		else
		{
			ToggleScrollUp(toggleVal: true);
		}
	}

	private void LoadNextBox()
	{
		GameObject gameObject = boxes[loadingBoxIndex];
		FillBox(gameObject, loadingBoxIndex);
		Clickable clickable = GetBackingObject(gameObject).AddComponent<Clickable>();
		clickable.SetClickCallbacks(null, OnBoxClicked, null, null, loadingBoxIndex);
		clickable.SetClickCallbackTime(Clickable.CallbackTime.CLICK_START);
		clickable.SetDefaultScale(Vector3.one);
		Vector3 one = Vector3.one;
		if (loadingBoxIndex >= heldObjectsOfType.Count)
		{
			clickable.enabled = false;
			one = inactiveScale;
		}
		loadingBoxIndex++;
		if (loadingBoxIndex >= boxes.Count)
		{
			needsDelayedScaleIn = false;
			if (instantLoad)
			{
				gameObject.transform.localScale = one;
				OnLoadComplete();
			}
			else
			{
				currentEases.Add(inchwormRef.RequestEaseToScale(gameObject, one, scaleInTime, Inchworm.EaseStyle.ElasticOut, OnLoadComplete));
			}
		}
		else if (instantLoad)
		{
			gameObject.transform.localScale = one;
		}
		else
		{
			currentEases.Add(inchwormRef.RequestEaseToScale(gameObject, one, scaleInTime, Inchworm.EaseStyle.ElasticOut));
		}
		currentOffset = 0f;
	}

	protected virtual void FillBox(GameObject box, int index, bool updateRotation = true)
	{
		if (GetWorkingIndex(index) < heldObjectsOfType.Count)
		{
			GameObject gameObject = _GetPreviewObjectForIndex(index);
			ObjectUtil.SetAllLayers(gameObject, LayerMask.NameToLayer("UI"));
			gameObject.name = previewName;
			gameObject.transform.SetParent(GetBackingObject(box).transform);
			gameObject.transform.localScale = objectThumbnailScale;
			gameObject.transform.localPosition = objectThumbnailPos;
			if (updateRotation && rotatePreviews)
			{
				gameObject.transform.Rotate(objectThumbnailRot);
			}
			int num = _GetNumObjectsForIndex(index);
			if (num > 1)
			{
				GetObjectNumObject(box).SetActive(value: true);
				GetObjectNumObject(box).transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = num.ToString();
			}
			else if (num == -1)
			{
				GetObjectNumObject(box).SetActive(value: true);
				GetObjectNumObject(box).transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = "∞";
			}
		}
	}

	protected GameObject GetObjectNumObject(GameObject box)
	{
		Transform transform = GetBackingObject(box).transform.Find(objectNumName);
		if (transform == null)
		{
			return null;
		}
		return transform.gameObject;
	}

	protected GameObject GetBackingObject(GameObject box)
	{
		Transform transform = box.transform.GetChild(0).Find(backingName);
		if (transform != null)
		{
			return transform.gameObject;
		}
		return null;
	}

	private GameObject GetSelectionObject(GameObject box)
	{
		return box.transform.GetChild(0).Find(selectionName).gameObject;
	}

	private GameObject GetPreviewObject(GameObject box)
	{
		if (box == null)
		{
			return null;
		}
		GameObject backingObject = GetBackingObject(box);
		if (backingObject == null)
		{
			return null;
		}
		Transform transform = backingObject.transform.Find(previewName);
		if (transform == null)
		{
			return null;
		}
		return transform.gameObject;
	}

	private void UnloadNextBox()
	{
		if (loadingBoxIndex <= 0)
		{
			OnUnloadComplete();
			return;
		}
		loadingBoxIndex--;
		GameObject gameObject = boxes[loadingBoxIndex];
		InternalBoxUnload(gameObject);
		if (loadingBoxIndex <= 0)
		{
			needsDelayedScaleOut = false;
			currentEases.Add(inchwormRef.RequestEaseToScale(gameObject, Vector3.zero, scaleOutTime, Inchworm.EaseStyle.ElasticIn, OnUnloadComplete));
		}
		else
		{
			currentEases.Add(inchwormRef.RequestEaseToScale(gameObject, Vector3.zero, scaleOutTime, Inchworm.EaseStyle.ElasticIn));
		}
		currentOffset = 0f;
	}

	private void InternalBoxUnload(GameObject box)
	{
		GameObject backingObject = GetBackingObject(box);
		if (backingObject != null)
		{
			Clickable component = backingObject.GetComponent<Clickable>();
			if (component != null)
			{
				component.Unload();
				component = null;
			}
		}
	}

	public void SetSelectedObject(object obj)
	{
		int num = activeBoxIndex;
		for (int i = 0; i < heldObjectsOfType.Count; i++)
		{
			if (heldObjectsOfType[i] == obj)
			{
				num = i;
				break;
			}
		}
		if (num != activeBoxIndex)
		{
			startRow = GetRowNumForIndex(num);
			SetActiveBox(GetActualIndex(num));
		}
	}

	protected int GetRowNumForIndex(int index)
	{
		return Mathf.CeilToInt(index / boxesPerRow);
	}

	private void OnLoadComplete()
	{
		currentEases.Clear();
		OnBoxesFilled();
		needsDelayedScaleIn = false;
		ScalableUIContainer.LoadCallback loadCallback = callback;
		callback = null;
		loadCallback();
		if (heldObjectsOfType.Count == 0)
		{
			NoObjectsOfTypeCallback();
		}
	}

	protected virtual void OnBoxesFilled()
	{
	}

	protected void OnUnloadComplete()
	{
		currentEases.Clear();
		needsDelayedScaleOut = false;
		foreach (GameObject value in previewCache.Values)
		{
			Object.Destroy(value);
		}
		previewCache.Clear();
		for (int num = boxes.Count - 1; num >= 0; num--)
		{
			Object.Destroy(boxes[num]);
		}
		boxes.Clear();
		loadingBoxIndex = 0;
		if (callback != null)
		{
			callback();
			callback = null;
		}
	}
}

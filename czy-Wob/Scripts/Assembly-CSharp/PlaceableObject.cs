using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaceableObject : MonoBehaviour
{
	public bool canBeMoved = true;

	public bool isDen;

	public bool useTriggersForFootprintBake;

	public GameObject selectionGUIPrefab;

	private GameObject createdSelectionGUI;

	public UnityEvent editStartEvents;

	public UnityEvent editEndEvents;

	private PlaceableObjectState currentState;

	private List<Renderer> rendererKeyList = new List<Renderer>();

	private Dictionary<Renderer, Material[]> defaultMaterialDict = new Dictionary<Renderer, Material[]>();

	private float additionalYOffset = 2f;

	private BoundingBoxComponent bbc;

	private void Awake()
	{
		AwakeBehavior();
	}

	protected virtual void AwakeBehavior()
	{
		bbc = GetComponent<BoundingBoxComponent>();
		if (bbc == null)
		{
			bbc = base.gameObject.AddComponent<BoundingBoxComponent>();
		}
	}

	private void OnDestroy()
	{
		HideSelectionGUI();
	}

	public void ShowSelectionGUI(RoomCustomizationObject objectRef)
	{
		createdSelectionGUI = Object.Instantiate(selectionGUIPrefab, objectRef.centerOffset, Quaternion.identity);
		PlacementWorldspaceGUI component = createdSelectionGUI.GetComponent<PlacementWorldspaceGUI>();
		component.SetFollowTransform(base.transform);
		component.worldspaceOffset = new Vector3(0f, objectRef.footprint.y * 2f + additionalYOffset, 0f);
		component.SetObjectRef(this);
	}

	public void HideSelectionGUI()
	{
		if (!(createdSelectionGUI == null))
		{
			Object.Destroy(createdSelectionGUI);
			createdSelectionGUI = null;
		}
	}

	public void OnEditButtonClicked()
	{
		ObjectPlacementManager.SetSubMode(ObjectPlacementManager.SubMode.EDIT_SELECTED);
	}

	public void OnMoveButtonClicked()
	{
		ObjectPlacementManager.SetSubMode(ObjectPlacementManager.SubMode.MOVE_SELECTED);
	}

	public void OnDestroyButtonClicked()
	{
		ObjectPlacementManager.DestroySelectedObject();
	}

	public void RunEditStartEvents()
	{
		editStartEvents.Invoke();
	}

	public void RunEditEndEvents()
	{
		editEndEvents.Invoke();
	}

	public void SetState(PlaceableObjectState newState)
	{
		currentState = newState;
	}

	public PlaceableObjectState GetState()
	{
		return currentState;
	}

	public void SetMaterials(Material newMat)
	{
		if (newMat == null)
		{
			if (defaultMaterialDict.Count != 0)
			{
				RestoreMaterials();
			}
			return;
		}
		if (defaultMaterialDict.Count == 0)
		{
			StoreDefaultMaterials();
		}
		for (int i = 0; i < rendererKeyList.Count; i++)
		{
			rendererKeyList[i].materials = new Material[1] { newMat };
		}
	}

	public void RestoreMaterials()
	{
		if (defaultMaterialDict.Count == 0)
		{
			Debug.LogError(string.Concat("Attempting to restore material state for object: ", base.gameObject, " but the original materials were never saved."));
			return;
		}
		for (int i = 0; i < rendererKeyList.Count; i++)
		{
			if (rendererKeyList[i] != null)
			{
				rendererKeyList[i].materials = defaultMaterialDict[rendererKeyList[i]];
			}
		}
		rendererKeyList.Clear();
		defaultMaterialDict.Clear();
	}

	private void StoreDefaultMaterials()
	{
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in componentsInChildren)
		{
			rendererKeyList.Add(renderer);
			defaultMaterialDict[renderer] = renderer.materials;
		}
	}
}

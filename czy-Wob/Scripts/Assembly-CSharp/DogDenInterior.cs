using UnityEngine;

public class DogDenInterior : MonoBehaviour
{
	public Transform focusTransform;

	public Transform entranceTransform;

	public Transform mainRoomTargetTransform;

	public ulong associatedDenUID;

	public DogDen associatedDenRef;

	public DenExpansion expansions;

	public InventoryItem snowballObject;

	public InventoryItem dirtClumpObject;

	public GameObject roomCreationParticleEffect;

	public Material snowyInteriorMat;

	public Material defaultInteriorMat;

	private bool isSnowy;

	private int dirtClumpLow = 10;

	private int dirtClumpHigh = 15;

	private float dirtScaleMultRangeLow = 0.1f;

	private float dirtScaleMultRangeHigh = 0.5f;

	private void Awake()
	{
		expansions.ShowInitialExpansion();
		expansions.SetAssociatedInterior(this);
	}

	private void OnDestroy()
	{
		if (associatedDenRef != null)
		{
			associatedDenRef.PreDestroy();
		}
	}

	public void SetIsSnowy(bool val)
	{
		if (val != isSnowy)
		{
			isSnowy = val;
			Material material = defaultInteriorMat;
			if (isSnowy)
			{
				material = snowyInteriorMat;
			}
			Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].material = material;
			}
		}
	}

	public void CenterFocusTransform()
	{
		focusTransform.localPosition = new Vector3(0f, 1.75f, 0f);
	}

	public bool IsAnyRoomBeingExpanded()
	{
		return expansions.IsDogRegistered();
	}

	public bool CanExpand()
	{
		if (IsAnyRoomBeingExpanded())
		{
			return false;
		}
		return expansions.CanDogExpand();
	}

	public DenExpansion GetFreeDenExpansion()
	{
		if (!CanExpand())
		{
			return null;
		}
		return expansions;
	}

	public int GetAdditionalCapacity()
	{
		return expansions.additionalCapacity;
	}

	public bool DoesDenHaveExpansionType(ExpansionType type)
	{
		switch (type)
		{
		case ExpansionType.BEDROOM:
			if (expansions.currentBedroomTransform != null)
			{
				return true;
			}
			return false;
		case ExpansionType.NEST:
			if (expansions.currentNestTransform != null)
			{
				return true;
			}
			return false;
		case ExpansionType.RITUAL:
			if (expansions.currentRitualTransform != null)
			{
				return true;
			}
			return false;
		default:
			return false;
		}
	}

	public void ExpandDen()
	{
		Vector3 position = expansions.GetCurrentExpansionTransform().position;
		expansions.Expand();
		DogHome globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		InventoryItem item = dirtClumpObject;
		if (isSnowy)
		{
			item = snowballObject;
		}
		int num = Random.Range(dirtClumpLow, dirtClumpHigh);
		for (int i = 0; i < num; i++)
		{
			GameObject gameObject = globalComponent.TrySpawnItem(item, position, null, moveToGoodLocation: false);
			gameObject.transform.localScale += gameObject.transform.localScale * Random.Range(dirtScaleMultRangeLow, dirtScaleMultRangeHigh);
		}
		Object.Instantiate(roomCreationParticleEffect, position, Quaternion.identity).transform.localScale *= 4f;
	}

	public Vector3 GetExpansionTypeTarget(ExpansionType typeRef)
	{
		switch (typeRef)
		{
		case ExpansionType.BEDROOM:
			return expansions.currentBedroomTransform.position;
		case ExpansionType.NEST:
			return expansions.currentNestTransform.position;
		case ExpansionType.RITUAL:
			return expansions.currentRitualTransform.position;
		default:
			Debug.LogError("No valid expansion transform found for type: " + typeRef);
			return mainRoomTargetTransform.position;
		}
	}
}

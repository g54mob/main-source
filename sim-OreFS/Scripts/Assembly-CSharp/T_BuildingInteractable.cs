using UnityEngine;

public class T_BuildingInteractable : InteractableBase
{
	[Header("References")]
	[SerializeField]
	private BuildingObject buildingObject;

	private T_Equipments localEquipments;

	private void Awake()
	{
		if (buildingObject == null)
		{
			buildingObject = GetComponentInParent<BuildingObject>();
		}
	}

	private void Start()
	{
		if (GameManager.Instance != null)
		{
			localEquipments = GameManager.Instance.localEquipments;
		}
	}

	public override bool CanInteractPrimary()
	{
		if (!IsHammerEquipped())
		{
			return true;
		}
		if (buildingObject == null || !buildingObject.IsPlaced)
		{
			return false;
		}
		return true;
	}

	public override bool CanInteractSecondary()
	{
		if (!IsHammerEquipped())
		{
			return true;
		}
		if (buildingObject == null || !buildingObject.IsPlaced)
		{
			return false;
		}
		return true;
	}

	public override void OnPrimaryInteracted()
	{
		if (!IsHammerEquipped() || buildingObject == null)
		{
			return;
		}
		T_Equipments t_Equipments = GameManager.Instance?.localEquipments;
		if (!(t_Equipments == null))
		{
			uint netId = buildingObject.netId;
			if (netId != 0)
			{
				t_Equipments.CmdResaleBuilding(netId);
			}
		}
	}

	public override void OnSecondaryInteracted()
	{
		if (!IsHammerEquipped() || buildingObject == null)
		{
			return;
		}
		T_Equipments t_Equipments = GameManager.Instance?.localEquipments;
		if (!(t_Equipments == null))
		{
			uint netId = buildingObject.netId;
			if (netId != 0)
			{
				t_Equipments.CmdRelocateBuilding(netId);
			}
		}
	}

	private bool IsHammerEquipped()
	{
		if (localEquipments == null)
		{
			if (GameManager.Instance != null)
			{
				localEquipments = GameManager.Instance.localEquipments;
			}
			if (localEquipments == null)
			{
				return false;
			}
		}
		if (localEquipments.equippedIndex < 0 || localEquipments.equippedIndex >= localEquipments.localTools.Count)
		{
			return false;
		}
		return localEquipments.localTools[localEquipments.equippedIndex].itemType == ItemType.Hammer;
	}

	public BuildingObject GetBuildingObject()
	{
		return buildingObject;
	}
}

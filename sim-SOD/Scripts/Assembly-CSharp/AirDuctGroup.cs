using System;
using System.Collections.Generic;
using UnityEngine;

public class AirDuctGroup : Controller
{
	[Serializable]
	public class AirVent
	{
		public int ventID;

		public static int assignVentID;

		public NewAddress.AirVent ventType;

		public NewWall wall;

		public NewNode node;

		public NewNode roomNode;

		public NewRoom room;

		public AirDuctGroup group;

		public MapDuctsButtonController mapButton;

		public bool discovered;

		public bool removed;

		public InteractableController spawned;

		public Vector3 debugNode;

		public Vector3 debugRoomNode;

		public AirVent(NewAddress.AirVent newType, NewRoom newRoom)
		{
		}

		public void SetDiscovered(bool val)
		{
		}

		public AirVent(CitySaveData.AirVentSave load)
		{
		}

		public void Remove()
		{
		}

		public AirDuctSection GetDuctSection()
		{
			return null;
		}
	}

	[Serializable]
	public class AirDuctSection
	{
		public int level;

		public int index;

		public Vector3Int duct;

		public Vector3Int previous;

		public Vector3Int next;

		public bool ext;

		public bool peekSection;

		public Vector3Int additionalRot;

		public NewNode node;

		public AirDuctGroup group;

		public MapDuctsButtonController mapButton;

		public bool discovered;

		public AirDuctSection(int newLevel, int newIndex, Vector3Int newDuct, Vector3Int newPrevious, Vector3Int newNext, NewNode newNode, AirDuctGroup newGroup, bool newPeek, Vector3Int newAdditionalRot)
		{
		}

		public void SetDiscovered(bool val)
		{
		}

		public List<AirDuctSection> GetNeighborSections(out List<Vector3Int> relativeOffsets, out List<AirVent> vents, out List<Vector3Int> ventRelativeOffsets)
		{
			relativeOffsets = null;
			vents = null;
			ventRelativeOffsets = null;
			return null;
		}

		public List<AirVent> FindVents(out List<Vector3Int> ventRelativeOffsets)
		{
			ventRelativeOffsets = null;
			return null;
		}

		public Vector3 GetWorldPosition()
		{
			return default(Vector3);
		}
	}

	public int ductID;

	public static int assignID;

	public NewBuilding building;

	public bool isExterior;

	public bool isVisible;

	[Header("Air Vents")]
	public List<AirVent> airVents;

	[Header("Air Ducts")]
	public List<AirDuctSection> airDucts;

	[Header("Combined Mesh")]
	public MeshFilter meshFilter;

	public MeshRenderer combinedMesh;

	[Header("Culling")]
	public List<AirDuctGroup> adjoiningGroups;

	public List<NewRoom> ventRooms;

	public void SetupNew(NewBuilding newBuilding)
	{
	}

	public void Load(CitySaveData.AirDuctGroupCitySave load, NewBuilding newBuilding)
	{
	}

	public void AddAirDuctSection(int level, Vector3Int duct, Vector3Int previous, Vector3Int next, NewNode newNode, int index = 0)
	{
	}

	public void AddAirVent(AirVent newVent)
	{
	}

	public void AddAdjoiningDuctGroup(AirDuctGroup ductGroup)
	{
	}

	public void LoadDucts()
	{
	}

	public void SetVisible(bool newVis, bool forceUpdate = false)
	{
	}

	public List<Vector3Int> GetDuctOffsets(NewNode thisNode, AirDuctSection duct)
	{
		return null;
	}

	public CitySaveData.AirDuctGroupCitySave GenerateSaveData()
	{
		return null;
	}
}

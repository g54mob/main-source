using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class StreetController : NewGameLocation, IComparable<StreetController>
{
	[Serializable]
	public class StreetTile
	{
		public string name;

		public Vector3 worldPos;

		public StreetTilePreset.StreetSection section;

		public int angle;

		public StreetTile(string chunkName, Vector3 newWorldPos, StreetTilePreset.StreetSection newSection, int newAngle)
		{
		}
	}

	[Header("ID")]
	public int streetID;

	public static int assignID;

	[Header("Custom Editor Flags")]
	public bool isPlayerEditedName;

	public string playerEditedStreetName;

	[Header("Details")]
	public List<NewTile> tiles;

	public string streetSuffix;

	public bool isAlley;

	public bool isBackstreet;

	public float normalizedFootfall;

	public int chunkSize;

	private Dictionary<NewRoom.StaticBatchKey, List<GameObject>> staticBatchDictionary;

	[Header("Road Tile Setup")]
	public List<PathFinder.StreetChunk> streetChunks;

	public List<StreetTile> streetSections;

	public Dictionary<MeshRenderer, StreetTilePreset.StreetSectionModel> loadedModelReference;

	public List<StreetController> sharedGroundElements;

	public List<string> debugAddressSet;

	public void Setup(DistrictController newDistrict)
	{
	}

	public void Load(CitySaveData.StreetCitySave data)
	{
	}

	public void AddTile(NewTile newTile)
	{
	}

	public void RemoveTile(NewTile newTile)
	{
	}

	public void SetAsAlley()
	{
	}

	public void SetAsBackstreet()
	{
	}

	public void SetAsStreet()
	{
	}

	public void UpdateNameCustom(StreetController controller, string userStreetName)
	{
	}

	public void UpdateName(bool forceTrueRandom = false)
	{
	}

	public override bool IsOutside()
	{
		return false;
	}

	public void AddChunk(PathFinder.StreetChunk newChunk)
	{
	}

	public List<StreetController> GetNeighboringStreets()
	{
		return null;
	}

	public int CompareTo(StreetController otherObject)
	{
		return 0;
	}

	public override void CreateEvidence()
	{
	}

	public override void SetupEvidence()
	{
	}

	public CitySaveData.StreetCitySave GenerateSaveData()
	{
		return null;
	}

	public void LoadStreetTiles()
	{
	}

	public void LoadSections()
	{
	}

	public void AddForStaticBatching(GameObject obj, Mesh objectMesh, Material objectMat)
	{
	}

	public void ExecuteStaticBatching()
	{
	}

	private StreetTilePreset.StreetSectionModel GetModel(StreetTilePreset.StreetSection section, string seed)
	{
		return null;
	}

	public NewNode GetDestinationNode()
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void Redecorate()
	{
	}
}

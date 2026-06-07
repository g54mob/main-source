using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	public class ERTerrain : MonoBehaviour
	{
		[HideInInspector]
		public List<Vector3> surfacevecs;

		[HideInInspector]
		public float[] tdataFloat;

		[HideInInspector]
		public TerrainData terrainData;

		[HideInInspector]
		public int xStart = 0;

		[HideInInspector]
		public int zStart = 0;

		[HideInInspector]
		public GameObject roadSurface;

		[HideInInspector]
		public Mesh surfaceMesh;

		[HideInInspector]
		public MeshCollider surfaceCollider;

		[HideInInspector]
		public List<ERTerrainData> terrainDataStored = new List<ERTerrainData>();

		[HideInInspector]
		public List<ERTerrainChange> terrainChanges = new List<ERTerrainChange>();

		[HideInInspector]
		public List<ERTree> terrainTrees = new List<ERTree>();

		[HideInInspector]
		public List<List<tPoint>> detailInstancesOld = new List<List<tPoint>>();

		[HideInInspector]
		public List<tPoint> detailInstances = new List<tPoint>();

		[HideInInspector]
		public List<int> detailInstanceStarts = new List<int>();

		[HideInInspector]
		public List<GameObject> surfaceObjects = new List<GameObject>();

		[HideInInspector]
		public List<Vector3> terrainTestPoints = new List<Vector3>();

		[HideInInspector]
		public List<ERSplatmap> splatData = new List<ERSplatmap>();

		[HideInInspector]
		public List<ERTreeInstance> addedTrees = new List<ERTreeInstance>();

		[HideInInspector]
		public List<ERCell> holes = new List<ERCell>();

		[HideInInspector]
		public List<ERTerrainData> terrainHeightsBackup = new List<ERTerrainData>();

		[HideInInspector]
		public List<ERTree> terrainTreesBackup = new List<ERTree>();

		[HideInInspector]
		public List<tPoint> terrainDetailBackup = new List<tPoint>();

		[HideInInspector]
		public List<ERSplatmap> terrainSplatBackup = new List<ERSplatmap>();

		[HideInInspector]
		public List<int> detailInstanceStartsBackUp = new List<int>();

		[HideInInspector]
		public bool heightmapFlag;

		[HideInInspector]
		public bool splatmapFlag;

		[HideInInspector]
		public bool treeFlag;

		[HideInInspector]
		public bool detailFlag;

		[HideInInspector]
		public bool holesFlag;

		[HideInInspector]
		public bool terrainDone;

		[HideInInspector]
		public bool backupFlagNotification = false;

		[HideInInspector]
		public bool ignore = false;

		[HideInInspector]
		public GameObject backupObject;

		[HideInInspector]
		public TerrainData terrain;
	}
}

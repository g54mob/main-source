using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERTerrain : MonoBehaviour
	{
		public List<Vector3> surfacevecs;

		public float[] tdataFloat;

		public TerrainData terrainData;

		public int xStart = 0;

		public int zStart = 0;

		public GameObject roadSurface;

		public Mesh surfaceMesh;

		public MeshCollider surfaceCollider;

		public List<ERTerrainData> terrainDataStored = new List<ERTerrainData>();

		public List<ERTerrainChange> terrainChanges = new List<ERTerrainChange>();

		public List<ERTree> terrainTrees = new List<ERTree>();

		public List<List<tPoint>> detailInstancesOld = new List<List<tPoint>>();

		public List<tPoint> detailInstances = new List<tPoint>();

		public List<int> detailInstanceStarts = new List<int>();

		public List<GameObject> surfaceObjects = new List<GameObject>();

		public List<Vector3> terrainTestPoints = new List<Vector3>();

		public List<ERSplatmap> splatData = new List<ERSplatmap>();

		public List<ERTreeInstance> addedTrees = new List<ERTreeInstance>();

		public List<ERTerrainData> terrainHeightsBackup = new List<ERTerrainData>();

		public List<ERTree> terrainTreesBackup = new List<ERTree>();

		public List<tPoint> terrainDetailBackup = new List<tPoint>();

		public List<ERSplatmap> terrainSplatBackup = new List<ERSplatmap>();

		public List<int> detailInstanceStartsBackUp = new List<int>();

		public bool heightmapFlag;

		public bool splatmapFlag;

		public bool treeFlag;

		public bool detailFlag;

		public bool terrainDone;

		public bool backupFlagNotification = false;

		public GameObject backupObject;

		public TerrainData terrain;
	}
}

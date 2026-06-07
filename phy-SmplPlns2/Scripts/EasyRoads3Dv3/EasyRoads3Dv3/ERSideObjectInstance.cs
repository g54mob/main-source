using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[AddComponentMenu("")]
	[HelpURL("https://www.easyroads3d.com/v3/html/side_objects.html")]
	public class ERSideObjectInstance : MonoBehaviour
	{
		[HideInInspector]
		public SideObject so;

		[HideInInspector]
		public double id;

		[HideInInspector]
		public ERModularRoad roadScript;

		[HideInInspector]
		public List<GameObject> childs = new List<GameObject>();

		[HideInInspector]
		public List<Vector3> debugVecs = new List<Vector3>();

		public List<Vector3> points = new List<Vector3>();

		[HideInInspector]
		public List<bool> terrainIndexes = new List<bool>();

		[HideInInspector]
		public bool buildFlag;

		[HideInInspector]
		public bool postProcess;

		[HideInInspector]
		public bool batches = false;

		[HideInInspector]
		public bool combined = false;

		[HideInInspector]
		public List<GameObject> batchedObjects = new List<GameObject>();

		[HideInInspector]
		public List<Vector3> startEndPositions = new List<Vector3>();

		[HideInInspector]
		public List<Vector3> startEndMeshPositions = new List<Vector3>();

		[HideInInspector]
		public Vector3 start;

		[HideInInspector]
		public Vector3 end;

		[HideInInspector]
		public int startIndex;

		[HideInInspector]
		public int endIndex;

		[HideInInspector]
		public List<float> distances = new List<float>();

		[HideInInspector]
		public bool locked = false;

		[HideInInspector]
		public List<int> sectionEndIndexes = new List<int>();
	}
}

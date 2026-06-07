using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERSideObjectInstance : MonoBehaviour
	{
		public SideObject so;

		public double id;

		public ERModularRoad roadScript;

		public List<GameObject> childs = new List<GameObject>();

		public List<Vector3> vecs = new List<Vector3>();

		public List<bool> terrainIndexes = new List<bool>();

		public bool buildFlag;

		public bool batches = false;

		public bool combined = false;

		public List<GameObject> batchedObjects = new List<GameObject>();
	}
}

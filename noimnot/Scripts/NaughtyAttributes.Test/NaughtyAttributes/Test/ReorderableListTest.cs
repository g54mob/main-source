using System.Collections.Generic;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class ReorderableListTest : MonoBehaviour
	{
		[ReorderableList]
		public int[] intArray;

		[ReorderableList]
		public List<Vector3> vectorList;

		[ReorderableList]
		public List<SomeStruct> structList;

		[ReorderableList]
		public GameObject[] gameObjectsList;

		[ReorderableList]
		public List<Transform> transformsList;

		[ReorderableList]
		public List<MonoBehaviour> monoBehavioursList;
	}
}

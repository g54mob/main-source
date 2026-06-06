using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	public class GameObjectContainer : MonoBehaviour
	{
		[SerializeField]
		private List<GameObject> gameObjectList;

		private Dictionary<string, GameObject> gameObjectDict;

		protected void Awake()
		{
		}

		public bool Contains(string objName)
		{
			return false;
		}

		public GameObject GetGameObject(string objName)
		{
			return null;
		}
	}
}

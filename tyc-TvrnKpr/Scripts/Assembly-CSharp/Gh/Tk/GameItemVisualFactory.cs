using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class GameItemVisualFactory : MonoBehaviour
	{
		public List<GameObject> foodOrders;

		public Material blueprintMaterial;

		private GameObject _parent;

		private void Start()
		{
		}

		public GameObject Create(GameItem obj, bool toStore = false)
		{
			return null;
		}

		private GameObject CreateIngredient(GameItem obj, bool toStore)
		{
			return null;
		}
	}
}

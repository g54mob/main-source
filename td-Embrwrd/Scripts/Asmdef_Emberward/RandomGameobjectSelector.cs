using System;
using System.Collections.Generic;
using UnityEngine;

public class RandomGameobjectSelector : MonoBehaviour
{
	[Serializable]
	public class GameObjectWeight
	{
		public GameObject target;

		public float weight;
	}

	[SerializeField]
	private List<GameObjectWeight> gameObjects;

	private void OnEnable()
	{
	}

	private void FetchChildGameObjects()
	{
	}
}

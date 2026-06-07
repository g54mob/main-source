using System;
using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Collections.Managed
{
	public class CollectionManager : MonoBehaviour
	{
		private static CollectionManager _instance;

		private List<IManagedCollection> _collections;

		private static CollectionManager GetInstance()
		{
			if (_instance == null)
			{
				_instance = new GameObject().AddComponent<CollectionManager>();
				_instance.name = "CollectionManager";
			}
			return _instance;
		}

		private void Awake()
		{
			if (_instance == null)
			{
				_instance = this;
				_collections = new List<IManagedCollection>();
			}
			else
			{
				UnityEngine.Object.Destroy(this);
				Debug.LogException(new Exception("There can be only one active CollectionManager!"));
			}
		}

		private void OnDestroy()
		{
			foreach (IManagedCollection collection in _collections)
			{
				collection.OnDestroy();
			}
			_collections.Clear();
			if (_instance == this)
			{
				_instance = null;
			}
		}

		internal static void RegisterCollection(IManagedCollection collection)
		{
			GetInstance()._collections.AddUnique(collection);
		}
	}
}

using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[DisallowMultipleComponent]
public class InventoryAuxDataPrefabsAuthoring : MonoBehaviour
{
	[Serializable]
	public struct Prefab
	{
		public string name;

		public GameObject gameObject;
	}

	[InfoBox("The name is used as a key for looking up this prefab from save data.\nIf you change this then you will break saved data.", EInfoBoxType.Warning)]
	public List<Prefab> prefabs = new List<Prefab>();
}

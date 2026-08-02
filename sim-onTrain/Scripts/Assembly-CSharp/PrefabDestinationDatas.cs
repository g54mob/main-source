using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct PrefabDestinationDatas
{
	public GameObject prefab;

	[Range(0f, 10f)]
	public float destinationPerChunk;

	public List<SpeacialBiomAreas> specialBiomes;
}

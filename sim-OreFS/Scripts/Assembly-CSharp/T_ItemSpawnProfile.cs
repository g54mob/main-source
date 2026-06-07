using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "T_ItemSpawnProfile", menuName = "Game/Spawn Profile", order = 110)]
public class T_ItemSpawnProfile : ScriptableObject
{
	[Serializable]
	public class WeightedSO
	{
		public T_ItemSO so;

		[Min(0f)]
		public int minCount;

		[Min(0f)]
		public int maxCount;

		[Header("Grup Spawn")]
		[Tooltip("Bir grupta minimum kaç item spawn olacak")]
		[Min(1f)]
		public int spawnGroupMin = 1;

		[Tooltip("Bir grupta maksimum kaç item spawn olacak")]
		[Min(1f)]
		public int spawnGroupMax = 1;
	}

	[Serializable]
	public class LayerData
	{
		public PropertyLayerType layerType;

		public List<WeightedSO> items = new List<WeightedSO>();
	}

	[Header("Grup Spawn Ayarları")]
	[Tooltip("Grup içindeki itemler merkeze maksimum ne kadar uzakta olabilir")]
	[Min(0.1f)]
	public float groupSpawnRadius = 2f;

	[Tooltip("Grup merkezleri arasındaki minimum mesafe (farklı grupların üst üste gelmesini engeller)")]
	[Min(0f)]
	public float minGroupDistance = 2f;

	[Header("Katman Ayarları")]
	public LayerData surface = new LayerData
	{
		layerType = PropertyLayerType.Surface
	};

	public LayerData mid = new LayerData
	{
		layerType = PropertyLayerType.Middle
	};

	public LayerData deep = new LayerData
	{
		layerType = PropertyLayerType.Deep
	};
}

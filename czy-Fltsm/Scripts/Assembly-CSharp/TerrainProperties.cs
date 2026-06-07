using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Settings/TerrainProperties")]
public class TerrainProperties : ScriptableObject
{
	[Serializable]
	public struct RegionTiles
	{
		public WorldRegionType RegionType;

		public List<GameObject> Prefabs;
	}

	[Header("Properties")]
	[SerializeField]
	private float _tileWidth = 50f;

	[SerializeField]
	private float _tileLength = 50f;

	[SerializeField]
	[Tooltip("Should ideally be twice the destruction radius.")]
	private float _gridSize = 800f;

	[Header("Visuals")]
	[SerializeField]
	private List<RegionTiles> _regionTiles = new List<RegionTiles>();

	public IReadOnlyList<RegionTiles> Tiles => _regionTiles;

	public float TileWidth => _tileWidth;

	public float TileLength => _tileLength;

	public float GridSize => _gridSize;
}

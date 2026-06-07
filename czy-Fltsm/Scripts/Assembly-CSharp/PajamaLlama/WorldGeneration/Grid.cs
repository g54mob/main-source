using UnityEngine;

namespace PajamaLlama.WorldGeneration
{
	public class Grid : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The prefab used for the tiles.")]
		private GameObject _tilePrefab;

		[SerializeField]
		[Tooltip("Size of the grid to generate.")]
		private Vector2Int _gridSize = Vector2Int.one;

		public GameObject[,] Tiles;

		[ContextMenu("Generate Grid")]
		private void Generate()
		{
			Tiles = new GameObject[_gridSize.x, _gridSize.y];
			for (int i = 0; i < _gridSize.y; i++)
			{
				for (int j = 0; j < _gridSize.x; j++)
				{
					Tiles[j, i] = Object.Instantiate(_tilePrefab, new Vector3(j, 0f, i), Quaternion.identity, base.transform);
				}
			}
		}
	}
}

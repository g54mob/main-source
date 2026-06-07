using System.Collections;
using System.Linq;
using UnityEngine;

namespace DV.TerrainSystem
{
	public class MeshTerrain : MonoBehaviour
	{
		private const float WAIT_BEFORE_SWITCH = 1.5f;

		public TerrainGrid terrainGrid;

		private int tilesPerAxisTotal;

		private int tilesPerAxisDisabled;

		private int ringSize;

		private int[] disabledIndices;

		private int[] nextDisabledIndices;

		private IEnumerator moveCoro;

		private void Start()
		{
			float num = Mathf.Sqrt(base.transform.childCount);
			tilesPerAxisTotal = (int)num;
			if ((float)tilesPerAxisTotal != num)
			{
				Debug.LogError("Wrong number of mesh terrain tiles, mesh terrains will glitch", this);
			}
			ringSize = terrainGrid.loadingRingSize;
			tilesPerAxisDisabled = 2 * ringSize + 1;
			disabledIndices = Enumerable.Repeat(-1, tilesPerAxisDisabled * tilesPerAxisDisabled).ToArray();
			nextDisabledIndices = new int[disabledIndices.Length];
			terrainGrid.TerrainsMoved += OnTerrainsMoved;
		}

		private void ToggleMeshes(int xCurrentTile, int zCurrentTile)
		{
			for (int i = 0; i < tilesPerAxisDisabled; i++)
			{
				for (int j = 0; j < tilesPerAxisDisabled; j++)
				{
					int num = j + i * tilesPerAxisDisabled;
					int num2 = xCurrentTile + (j - ringSize);
					int num3 = zCurrentTile + (i - ringSize);
					if (num2 < 0 || num2 >= tilesPerAxisTotal || num3 < 0 || num3 >= tilesPerAxisTotal)
					{
						nextDisabledIndices[num] = -1;
						continue;
					}
					int num4 = num3 + num2 * tilesPerAxisTotal;
					nextDisabledIndices[num] = num4;
				}
			}
			for (int k = 0; k < disabledIndices.Length; k++)
			{
				if (disabledIndices[k] != -1 && !nextDisabledIndices.Contains(disabledIndices[k]))
				{
					base.transform.GetChild(disabledIndices[k]).gameObject.SetActive(value: true);
				}
				if (nextDisabledIndices[k] != -1)
				{
					base.transform.GetChild(nextDisabledIndices[k]).gameObject.SetActive(value: false);
				}
			}
			int[] array = disabledIndices;
			disabledIndices = nextDisabledIndices;
			nextDisabledIndices = array;
		}

		private void OnTerrainsMoved()
		{
			if (terrainGrid.currentCenterCoord.HasValue)
			{
				Vector2Int value = terrainGrid.currentCenterCoord.Value;
				ToggleMeshes(value.x, value.y);
			}
			else
			{
				Debug.LogWarning("TerrainGrid doesn't have a coordinate yet");
			}
		}
	}
}

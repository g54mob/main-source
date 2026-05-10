using NaughtyAttributes;
using UnityEngine;

public class GridFromTextureGeneration : MonoBehaviour
{
	[SerializeField]
	[BoxGroup("Grid")]
	private ConstructionGrid _grid;

	[SerializeField]
	[BoxGroup("Cell")]
	private ConstructionCell _cellPrefab;

	[SerializeField]
	[BoxGroup("Cell")]
	private float _cellSize = 1f;

	[SerializeField]
	[BoxGroup("Cell")]
	private Vector3 _cellPositionOffset = new Vector3(0.5f, 0f, 0.5f);

	[SerializeField]
	[BoxGroup("Navmesh")]
	private Transform _navmeshContainer;

	[SerializeField]
	[BoxGroup("Navmesh")]
	private GameObject _navmeshCellPrefab;

	[SerializeField]
	private Texture2D _mapTexture;

	private Color _constructionColor = Color.white;

	private Color _roadColor = Color.blue;

	private Color _walkColor = Color.green;

	[Button("Generate From Texture", EButtonEnableMode.Editor)]
	private void GenerateFromTexture()
	{
		int width = _mapTexture.width;
		int height = _mapTexture.height;
		ETextureSurfaceType[,] valuesMap = new ETextureSurfaceType[width, height];
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				Color pixel = _mapTexture.GetPixel(i, j);
				ETextureSurfaceType eTextureSurfaceType = valuesMap[i, j];
				if (pixel == _constructionColor)
				{
					eTextureSurfaceType |= ETextureSurfaceType.Constructable;
				}
				else if (pixel == _roadColor)
				{
					eTextureSurfaceType |= ETextureSurfaceType.Navigation;
				}
				else
				{
					if (pixel.g > 0.6f)
					{
						eTextureSurfaceType |= ETextureSurfaceType.EndMinusY;
					}
					else if (pixel.g > 0.1f)
					{
						eTextureSurfaceType |= ETextureSurfaceType.EndPlusY;
					}
					if (pixel.r > 0.6f)
					{
						eTextureSurfaceType |= ETextureSurfaceType.EndMinusX;
					}
					else if (pixel.r > 0.1f)
					{
						eTextureSurfaceType |= ETextureSurfaceType.EndPlusX;
					}
				}
				valuesMap[i, j] = eTextureSurfaceType;
			}
		}
		GenerateGrids(ref valuesMap);
		GenerateNavMesh(valuesMap);
	}

	public ETextureSurfaceType[,] GetMap()
	{
		int width = _mapTexture.width;
		int height = _mapTexture.height;
		ETextureSurfaceType[,] array = new ETextureSurfaceType[width, height];
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				Color pixel = _mapTexture.GetPixel(i, j);
				ETextureSurfaceType eTextureSurfaceType = array[i, j];
				if (pixel == _constructionColor)
				{
					eTextureSurfaceType |= ETextureSurfaceType.Constructable;
				}
				else if (pixel == _roadColor)
				{
					eTextureSurfaceType |= ETextureSurfaceType.Navigation;
				}
				else
				{
					if (pixel.g > 0.6f)
					{
						eTextureSurfaceType |= ETextureSurfaceType.EndMinusY;
					}
					else if (pixel.g > 0.1f)
					{
						eTextureSurfaceType |= ETextureSurfaceType.EndPlusY;
					}
					if (pixel.r > 0.6f)
					{
						eTextureSurfaceType |= ETextureSurfaceType.EndMinusX;
					}
					else if (pixel.r > 0.1f)
					{
						eTextureSurfaceType |= ETextureSurfaceType.EndPlusX;
					}
				}
				array[i, j] = eTextureSurfaceType;
			}
		}
		return array;
	}

	private void GenerateGrids(ref ETextureSurfaceType[,] valuesMap)
	{
		_grid.GenerateGrid(valuesMap.GetLength(0), valuesMap.GetLength(1), _cellPrefab, _cellSize, _cellPositionOffset);
	}

	private void GenerateNavMesh(ETextureSurfaceType[,] valuesMap)
	{
		while (_navmeshContainer.childCount > 0)
		{
			Object.DestroyImmediate(_navmeshContainer.GetChild(0).gameObject);
		}
		for (int i = 0; i < valuesMap.GetLength(0); i++)
		{
			for (int j = 0; j < valuesMap.GetLength(1); j++)
			{
				_mapTexture.GetPixel(i, j);
				if (valuesMap[i, j] == ETextureSurfaceType.Navigation)
				{
					Object.Instantiate(_navmeshCellPrefab, _navmeshContainer.transform.position + new Vector3(i, 0f, j), Quaternion.Euler(90f, 0f, 0f), _navmeshContainer);
				}
			}
		}
	}
}

using UnityEngine;

namespace CTS.GridSystem
{
	[DefaultExecutionOrder(-1)]
	public class GridController : MonoBehaviour
	{
		[SerializeField]
		private bool _debug = true;

		[SerializeField]
		private GridRenderer _gridRenderer;

		[SerializeField]
		private ConstructionGrid _constructionGrid;

		[SerializeField]
		private GridFromTextureGeneration _gridFromTextureGeneration;

		private ETextureSurfaceType[,] _valuesMap;

		[field: SerializeField]
		[field: Tooltip("Cell size in Unity unit - 1 = 1m")]
		public float CellSize { get; private set; } = 0.5f;

		public RoomBuilding CurrentRoom { get; private set; }

		public ETextureSurfaceType[,] ValuesMap
		{
			get
			{
				if (_valuesMap == null)
				{
					_valuesMap = _gridFromTextureGeneration.GetMap();
				}
				return _valuesMap;
			}
		}

		private void Awake()
		{
			MapEditor.OnBeginFurnituresLoading += ShowGrid;
			_gridRenderer.GenerateGrid((ValuesMap.GetLength(0) - 2) * 2, (ValuesMap.GetLength(1) - 2) * 2, CellSize);
			_gridRenderer.ShowGrid(p_value: false);
		}

		private void OnDestroy()
		{
			MapEditor.OnBeginFurnituresLoading -= ShowGrid;
		}

		public Vector3 GetClosestVerticeOnGrid(Vector3 p_posToCheck)
		{
			return _gridRenderer.GetGridClosestVerticeFromWorldPosition(p_posToCheck);
		}

		public void ShowGrid(bool p_value)
		{
			_gridRenderer.ShowGrid(p_value);
		}

		public void AssignRoom(RoomBuilding p_room)
		{
			CurrentRoom = p_room;
		}
	}
}

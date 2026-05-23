using System.Collections.Generic;
using System.Linq;
using Commands;
using Commands.ToolsCommands;
using Data.FactoryFloor;
using Data.FactoryFloor.Islands;
using Data.Operator;
using Data.Variables;
using Events;
using Events.FactoryFloor;
using Events.Generic;
using Logic.Factory.Blueprint;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Logic.FactoryTools.IslandEditor
{
	[CreateAssetMenu(menuName = "Factory/Tools/Islands/PaintBrushTool", fileName = "PaintBrushTool", order = 0)]
	public class PaintBrushTool : FactoryTool
	{
		[Header("Placement refs")]
		[SerializeField]
		private CurrentEditingIsland _currentEditingIsland;

		[SerializeField]
		protected FactoryLayer _terrainLayer;

		[SerializeField]
		protected GridLocator _gridLocator;

		[SerializeField]
		protected CommandManager _commandManager;

		[SerializeField]
		protected EnvironmentObjectsDatabase _environmentObjectsDatabase;

		[SerializeField]
		private BaseEvent _stopPreviewEvent;

		[SerializeField]
		private CreateFactoryObjectEvent _createFactoryObjectEvent;

		[SerializeField]
		private IntListEvent _factoryObjectsRemoveViewsEvent;

		[SerializeField]
		private BoxEvent _updateBoxSize;

		[SerializeField]
		private BaseEvent _disableBox;

		[SerializeField]
		private ColorEvent _updateSelectionBoxColor;

		[SerializeField]
		private BrushPositions _brushPositions;

		[SerializeField]
		private IntVariableSO _islandEditorBrushSize;

		private static List<Vector3Int> _mainPositions = new List<Vector3Int>();

		private EnvironmentBrushData _brushData;

		private List<Vector3Int> _adjacentPositions = new List<Vector3Int>();

		private bool _pressed;

		private bool _deleteMode;

		private Dictionary<Vector3Int, Color> _modifiedColors = new Dictionary<Vector3Int, Color>();

		private Dictionary<Vector3Int, Color> _modifiedOutsideColors = new Dictionary<Vector3Int, Color>();

		private Dictionary<Vector3Int, Color> _modifiedHeightColors = new Dictionary<Vector3Int, Color>();

		private List<FactoryObject> _createdObjects = new List<FactoryObject>();

		private List<FactoryObject> _deletedObjects = new List<FactoryObject>();

		public override bool CanAutoSwapAwayFrom => true;

		public void SetBrush(int brushId)
		{
			_brushData = _environmentObjectsDatabase.GetBrushDataWithId(brushId);
		}

		public override void SelectTool(Blueprint blueprint)
		{
			base.SelectTool(blueprint);
			_brushData.Initialize();
			_pressed = false;
			_deleteMode = false;
			_islandEditorBrushSize.ValueChanged += UpdateBrushSize;
			UpdateBrushSize(_islandEditorBrushSize.Value);
		}

		public override void DeSelectTool()
		{
			CancelAction();
			_islandEditorBrushSize.ValueChanged -= UpdateBrushSize;
			base.DeSelectTool();
		}

		private void UpdateBrushSize(int brushSize)
		{
			_mainPositions.Clear();
			_mainPositions = GetMainPositions(brushSize);
			_adjacentPositions.Clear();
			_adjacentPositions = GetAdjacentSides(brushSize);
			_updateSelectionBoxColor.Fire(_brushData.BoxColor);
		}

		private List<Vector3Int> GetMainPositions(int brushSize)
		{
			List<Vector3Int> list = new List<Vector3Int>();
			int num = brushSize / 2;
			int num2 = ((brushSize % 2 == 0) ? (-num) : (-num - 1));
			for (int i = num2; i <= num; i++)
			{
				for (int j = num2; j <= num; j++)
				{
					list.Add(new Vector3Int(i, 0, j));
				}
			}
			return list;
		}

		private List<Vector3Int> GetAdjacentSides(int brushSize)
		{
			List<Vector3Int> list = new List<Vector3Int>();
			HashSet<Vector3Int> hashSet = new HashSet<Vector3Int>(_mainPositions);
			int num = brushSize / 2;
			int num2 = ((brushSize % 2 == 0) ? (-num) : (-num - 1));
			for (int i = num2 - 1; i <= num + 1; i++)
			{
				for (int j = num2 - 1; j <= num + 1; j++)
				{
					Vector3Int item = new Vector3Int(i, 0, j);
					if (!hashSet.Contains(item))
					{
						list.Add(item);
					}
				}
			}
			return list;
		}

		public override void UpdateTool(Vector3Int gridPos, Vector3 mousePos)
		{
			if (_pressed && !_currentEditingIsland.Empty)
			{
				PaintWithBrush(_deleteMode ? ((Color)EnvironmentColorIDs.Default) : _brushData.FloorColor, gridPos);
			}
			List<Vector3Int> occupiedPositions = GetOccupiedPositions(gridPos, _mainPositions);
			_updateBoxSize.Fire(new BoxSize(occupiedPositions.First(), occupiedPositions.Last()));
		}

		private void PaintWithBrush(Color colorToPaint, Vector3Int position)
		{
			List<Vector3Int> occupiedPositions = GetOccupiedPositions(position, _mainPositions);
			foreach (Vector3Int item in occupiedPositions)
			{
				if (!_modifiedColors.ContainsKey(item) && _currentEditingIsland.PaintTexture(item, colorToPaint, out var previousColor))
				{
					if (_modifiedOutsideColors.ContainsKey(item))
					{
						previousColor = _modifiedOutsideColors[item];
						_modifiedOutsideColors.Remove(item);
					}
					_modifiedColors.Add(item, previousColor);
				}
				if (_brushData.PaintHeight)
				{
					Vector3Int vector3Int = item;
					vector3Int.y = 6;
					if (!_modifiedHeightColors.ContainsKey(vector3Int) && _currentEditingIsland.PaintTexture(vector3Int, _deleteMode ? EnvironmentColorIDs.Default : ((Color32)_brushData.HeightColor), out previousColor))
					{
						_modifiedHeightColors.Add(vector3Int, previousColor);
					}
				}
				if (_deleteMode)
				{
					if (_brushPositions.IsBrushAtPosition(item, _brushData.ID))
					{
						_brushPositions.RemoveBrushAtPosition(item);
					}
				}
				else
				{
					_brushPositions.SetBrushAtPosition(item, _brushData.ID);
				}
			}
			occupiedPositions.AddRange(GetOccupiedPositions(position, _adjacentPositions));
			if (_brushData.PaintOutside)
			{
				PaintOutside(occupiedPositions);
			}
			List<int> list = new List<int>();
			foreach (Vector3Int item2 in occupiedPositions)
			{
				if (!_deleteMode && !_brushPositions.IsBrushAtPosition(item2, _brushData.ID))
				{
					continue;
				}
				int rotation;
				int matchId;
				FactoryObjectData tileForGrid = _brushData.GetTileForGrid(GetGridForPosition(item2), out rotation, out matchId);
				if (_terrainLayer.TryGetObjectAt(item2, out var factoryObject))
				{
					_terrainLayer.RemoveObjectAt(item2);
					list.Add(factoryObject.CreatedId);
					if (_createdObjects.Contains(factoryObject))
					{
						_createdObjects.Remove(factoryObject);
					}
					else
					{
						_deletedObjects.Add(factoryObject);
					}
				}
				if (!(tileForGrid == null))
				{
					FactoryObject factoryObject2 = new FactoryObject(FactoryObject.GetOccupiedPositions(item2, tileForGrid.RelativePositions), tileForGrid, IntIdGenerator.GetNewId, rotation, mirrored: false, nonChangable: false, _terrainLayer);
					if (_terrainLayer.TryAddFactoryObject(factoryObject2))
					{
						_createdObjects.Add(factoryObject2);
						_createFactoryObjectEvent.Fire(new CreateFactoryObjectDto(_gridLocator.GetWorldPosition(factoryObject2.Position), factoryObject2.Rotation, factoryObject2.Mirrored, factoryObject2));
					}
				}
			}
			if (list.Count > 0)
			{
				_factoryObjectsRemoveViewsEvent.Fire(list);
			}
		}

		private void PaintOutside(List<Vector3Int> positions)
		{
			foreach (Vector3Int position in positions)
			{
				List<Vector3Int> occupiedPositions = GetOccupiedPositions(position, _adjacentPositions);
				if (_brushPositions.IsBrushAtPosition(position, _brushData.ID))
				{
					continue;
				}
				bool flag = false;
				Color32 previousColor;
				foreach (Vector3Int item in occupiedPositions)
				{
					if (position == item || !_brushPositions.IsAnyBrushAtPosition(item))
					{
						continue;
					}
					flag = true;
					if (_currentEditingIsland.PaintTexture(position, _brushData.OutsideColor, out previousColor) && !_modifiedOutsideColors.ContainsKey(position))
					{
						if (_modifiedColors.ContainsKey(position))
						{
							previousColor = _modifiedColors[position];
							_modifiedColors.Remove(position);
						}
						_modifiedOutsideColors.Add(position, previousColor);
					}
					break;
				}
				if (!flag && _currentEditingIsland.PaintTexture(position, EnvironmentColorIDs.Default, out previousColor) && !_modifiedOutsideColors.ContainsKey(position))
				{
					if (_modifiedColors.ContainsKey(position))
					{
						previousColor = _modifiedColors[position];
						_modifiedColors.Remove(position);
					}
					_modifiedOutsideColors.Add(position, previousColor);
				}
			}
		}

		private int[] GetGridForPosition(Vector3Int pos)
		{
			int[] array = new int[9];
			int num = 0;
			for (int i = -1; i <= 1; i++)
			{
				for (int j = -1; j <= 1; j++)
				{
					int x = pos.x + j;
					int z = pos.z + i;
					array[num] = (_brushPositions.IsBrushAtPosition(new Vector3Int(x, pos.y, z), _brushData.ID) ? 1 : 2);
					num++;
				}
			}
			return array;
		}

		public override void OnActionIntent(Vector3Int gridPos, Vector3 mousePos)
		{
			_disableBox.Fire();
			_pressed = true;
		}

		public override void DoAction(Vector3Int gridPos, Vector3 mousePos)
		{
			_pressed = false;
			_commandManager.DoCommand(new ConfirmBrushPaintCommand(_gridLocator, _createFactoryObjectEvent, _terrainLayer, _currentEditingIsland.IslandData, _createdObjects, _deletedObjects, _modifiedColors, _modifiedHeightColors, _modifiedOutsideColors));
			_modifiedColors = new Dictionary<Vector3Int, Color>();
			_createdObjects = new List<FactoryObject>();
			_deletedObjects = new List<FactoryObject>();
			_modifiedHeightColors = new Dictionary<Vector3Int, Color>();
			_modifiedOutsideColors = new Dictionary<Vector3Int, Color>();
		}

		private List<Vector3Int> GetOccupiedPositions(Vector3Int newPosition, List<Vector3Int> elementOccupiedPositions)
		{
			List<Vector3Int> list = new List<Vector3Int>(elementOccupiedPositions.Count);
			foreach (Vector3Int elementOccupiedPosition in elementOccupiedPositions)
			{
				list.Add(elementOccupiedPosition + newPosition);
			}
			return list;
		}

		public override void CancelAction()
		{
			_stopPreviewEvent.Fire();
			_disableBox.Fire();
			_modifiedColors = new Dictionary<Vector3Int, Color>();
			_createdObjects = new List<FactoryObject>();
			_deletedObjects = new List<FactoryObject>();
			_modifiedHeightColors = new Dictionary<Vector3Int, Color>();
		}

		public override void Mirror()
		{
			if (!_pressed)
			{
				_deleteMode = !_deleteMode;
				if (_deleteMode)
				{
					_updateSelectionBoxColor.Fire(Color.red);
				}
				else
				{
					_updateSelectionBoxColor.Fire(_brushData.FloorColor);
				}
			}
		}
	}
}

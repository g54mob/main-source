using System.Collections.Generic;
using Commands;
using Commands.ToolsCommands;
using Data.FactoryFloor;
using Data.FactoryFloor.Maps;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Events;
using Events.FactoryFloor;
using Events.Generic;
using Logic.Factory;
using Logic.Factory.Blueprint;
using Presentation.FactoryFloor;
using Presentation.FactoryFloor.FactoryObjectViews.Arrows;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Logic.FactoryTools
{
	[CreateAssetMenu(menuName = "Factory/Tools/PlaceConveyorsTool", fileName = "PlaceConveyorsTool", order = 0)]
	public class PlaceConveyorsTool : FactoryTool
	{
		private struct Anchor
		{
			public int Index;

			public Vector3Int Position;

			public bool xFirst;
		}

		private struct ConveyorLine
		{
			public Vector3Int LineStart;

			public Vector3Int LineEnd;

			public Vector3Int LineDir;

			public List<BlueprintElement> LineElements;
		}

		[Header("Conveyor refs")]
		[SerializeField]
		private int _conveyorId;

		[SerializeField]
		private FactoryObjectData _conveyorData;

		[SerializeField]
		private FactoryObjectData _extractorData;

		[SerializeField]
		private FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		private BluePrintEvent _startPreviewEvent;

		[SerializeField]
		private BluePrintEvent _updatePreviewEvent;

		[SerializeField]
		private BaseEvent _stopPreviewEvent;

		[SerializeField]
		private GridLocator _gridLocator;

		[SerializeField]
		private CurrentFactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		protected CommandManager _commandManager;

		[SerializeField]
		protected CreateFactoryObjectEvent _createFactoryObjectEvent;

		[SerializeField]
		protected IntListEvent _factoryObjectsRemoveViewsEvent;

		[SerializeField]
		private FactoryObjectData _inSkylineData;

		[SerializeField]
		private FactoryObjectData _outSkylineData;

		[SerializeField]
		private IntVariableSO _skylineLength;

		[SerializeField]
		private FactoryObjectData _inTunnelData;

		[SerializeField]
		private FactoryObjectData _outTunnelData;

		[SerializeField]
		private PlaceTunnelTool _tunnelTool;

		[SerializeField]
		private MouseToGridInput _mouseToGridInput;

		[SerializeField]
		private LockedFactoryObjectsPersistentSO _lockedFactoryObjects;

		[SerializeField]
		private IslandLayer _islandLayer;

		[Header("Arrows")]
		[SerializeField]
		private int _showArrowsDistance = 5;

		[Header("Constraints")]
		[SerializeField]
		private int _maxLineSegmentLength = 64;

		[SerializeField]
		private float _anchorAngleSwapDist = 2.5f;

		private Blueprint _selectedBlueprint;

		private BlueprintViewDto _blueprintViewDto;

		private FactoryObjectData _conveyorObjectData;

		private bool _dragStarted;

		private int _rotationLastTile;

		private Vector3Int _lastDragPosition;

		private bool _hasRotatedAtPos;

		private Vector3Int _rotatePos;

		private List<BlueprintElement> _path = new List<BlueprintElement>();

		private Dictionary<FactoryObjectView, FactoryObjectInputOutputArrows> _factoryObjectsArrowsShowing = new Dictionary<FactoryObjectView, FactoryObjectInputOutputArrows>();

		private bool _xFirstImpossible;

		private Anchor _currentAnchor;

		private List<BlueprintElement> _allConveyorElements = new List<BlueprintElement>();

		private List<ConveyorLine> _conveyorPath = new List<ConveyorLine>();

		private bool _previewStarted;

		public override bool CanAutoSwapAwayFrom => false;

		public override string BreadcrumbId => _conveyorData.BreadcrumbId;

		public override void SelectTool(Blueprint blueprint)
		{
			base.SelectTool(blueprint);
			_rotationLastTile = 0;
			_conveyorObjectData = _factoryObjectDatabase.GetObjectDataWithId(_conveyorId);
			_dragStarted = false;
			_path = new List<BlueprintElement>
			{
				new BlueprintElement(GetNewPosition(), _conveyorObjectData, _rotationLastTile, mirrored: false)
			};
			_selectedBlueprint = new Blueprint(Vector3Int.zero, 0, _path);
			_blueprintViewDto = BlueprintViewDto.Create(_selectedBlueprint, _gridLocator, _selectedBlueprint.Position);
		}

		private Anchor GetStartAnchor(Vector3Int position)
		{
			Anchor result = new Anchor
			{
				Index = 0,
				Position = position,
				xFirst = false
			};
			if (_factoryLayer.Value.TryGetObjectAt(position, out var factoryObject))
			{
				if (factoryObject.FactoryObjectData == _conveyorData)
				{
					return result;
				}
				bool flag = false;
				Vector3Int position2 = Vector3Int.one * int.MaxValue;
				float num = float.MaxValue;
				foreach (FactoryObjectData.OutputData dataOutputPosition in factoryObject.DataOutputPositions)
				{
					Vector3Int vector3Int = factoryObject.DataPosToWorldPos(dataOutputPosition.Position);
					if (!_factoryLayer.Value.TryGetObjectAt(vector3Int, out var factoryObject2) || !(factoryObject2.FactoryObjectData != _conveyorData))
					{
						flag = true;
						float num2 = (vector3Int - position).sqrMagnitude;
						if (num2 < num)
						{
							position2 = vector3Int;
							num = num2;
						}
					}
				}
				if (flag)
				{
					result.Position = position2;
				}
			}
			return result;
		}

		private void PlaceConveyors(Vector3Int position)
		{
			_xFirstImpossible = false;
			AddConveyorElements(position);
			List<BlueprintElement> allConveyorElements = new List<BlueprintElement>(_allConveyorElements);
			List<ConveyorLine> conveyorPath = new List<ConveyorLine>(_conveyorPath);
			if (!BlueprintPlacementValidator.CanBePlaced(Vector3Int.zero, _selectedBlueprint, _factoryLayer.Value, _terrainLayer))
			{
				_xFirstImpossible = true;
				AddConveyorElements(position);
				if (!BlueprintPlacementValidator.CanBePlaced(Vector3Int.zero, _selectedBlueprint, _factoryLayer.Value, _terrainLayer))
				{
					_xFirstImpossible = false;
					_allConveyorElements = allConveyorElements;
					_conveyorPath = conveyorPath;
				}
			}
			UpdateBlueprint();
		}

		private void AddConveyorElements(Vector3Int position)
		{
			_allConveyorElements.Clear();
			position = GetClosestOperatorInput(position);
			for (int num = _conveyorPath.Count - 1; num >= _currentAnchor.Index; num--)
			{
				RemoveConveyorLine(_conveyorPath[num]);
			}
			Vector3Int dir = position - _currentAnchor.Position;
			Vector3Int dir2;
			int length;
			int length2;
			if ((float)dir.sqrMagnitude < _anchorAngleSwapDist * _anchorAngleSwapDist)
			{
				GetConveyorLine(_currentAnchor.Position, position, out dir2, out length);
				_currentAnchor.xFirst = Mathf.Abs(dir2.x) > Mathf.Abs(dir2.z);
			}
			else
			{
				GetConveyorLine(_currentAnchor.Position, position, _currentAnchor.xFirst, out dir, out length2);
				if (length2 == 0)
				{
					GetConveyorLine(_currentAnchor.Position, position, out dir2, out length);
					_currentAnchor.xFirst = Mathf.Abs(dir2.x) > Mathf.Abs(dir2.z);
				}
			}
			bool flag = (_xFirstImpossible ? (!_currentAnchor.xFirst) : _currentAnchor.xFirst);
			GetConveyorLine(_currentAnchor.Position, position, flag, out dir2, out length2);
			AddConveyorLine(_currentAnchor.Position, dir2, position, length2, isLastConveyorLine: false, out var line);
			_selectedBlueprint.SetElements(_allConveyorElements);
			bool num2 = BlueprintPlacementValidator.CanBePlaced(Vector3Int.zero, _selectedBlueprint, _factoryLayer.Value, _terrainLayer);
			bool flag2 = IsPosEmptyOrConveyorInSameDir(line.LineEnd + line.LineDir, line.LineDir);
			if (!num2 || !flag2)
			{
				List<ConveyorLine> conveyorPath = _conveyorPath;
				RemoveConveyorLine(conveyorPath[conveyorPath.Count - 1]);
				GetConveyorLine(_currentAnchor.Position, position, !flag, out dir2, out var length3);
				AddConveyorLine(_currentAnchor.Position, dir2, position, length3, isLastConveyorLine: true, out var line2);
				_selectedBlueprint.SetElements(_allConveyorElements);
				if (!BlueprintPlacementValidator.CanBePlaced(position, _selectedBlueprint, _factoryLayer.Value, _terrainLayer))
				{
					List<ConveyorLine> conveyorPath2 = _conveyorPath;
					RemoveConveyorLine(conveyorPath2[conveyorPath2.Count - 1]);
					AddConveyorLine(_currentAnchor.Position, line.LineDir, position, length2, isLastConveyorLine: false, out line);
				}
				else
				{
					line = line2;
				}
			}
			if (line.LineEnd + line.LineDir != position && line.LineStart != position && line.LineEnd != position)
			{
				Vector3Int startPos = line.LineEnd + line.LineDir;
				GetConveyorLine(startPos, position, out var dir3, out var length4);
				AddConveyorLine(startPos, dir3, position, length4, isLastConveyorLine: true, out var _);
			}
			List<ConveyorLine> conveyorPath3 = _conveyorPath;
			ConveyorLine value = conveyorPath3[conveyorPath3.Count - 1];
			_rotationLastTile = GetRotation(value.LineDir.x, value.LineDir.z);
			if (!(value.LineEnd + value.LineDir == position))
			{
				return;
			}
			value.LineEnd += value.LineDir;
			bool hasSetInputRotation;
			int rotation = GetInputRotationAtPosition(value.LineEnd, value.LineDir, out hasSetInputRotation);
			if (!_factoryLayer.Value.TryGetObjectAt(position, out var factoryObject))
			{
				if (!_terrainLayer.TryGetObjectAt(position, out var _))
				{
					BlueprintElement item = new BlueprintElement(new List<Vector3Int> { value.LineEnd }, _conveyorObjectData, rotation, mirrored: false);
					value.LineElements.Add(item);
					_allConveyorElements.Add(item);
					List<ConveyorLine> conveyorPath4 = _conveyorPath;
					conveyorPath4[conveyorPath4.Count - 1] = value;
				}
			}
			else if (factoryObject.FactoryObjectData == _conveyorData)
			{
				Vector3Int vector3Int = factoryObject.DataDirToWorldDir(factoryObject.DataOutputPositions[0].Direction);
				if ((vector3Int + value.LineDir).sqrMagnitude != 0)
				{
					rotation = GetRotation(vector3Int.x, vector3Int.z);
				}
				BlueprintElement item2 = new BlueprintElement(new List<Vector3Int> { value.LineEnd }, _conveyorObjectData, rotation, mirrored: false);
				value.LineElements.Add(item2);
				_allConveyorElements.Add(item2);
				List<ConveyorLine> conveyorPath5 = _conveyorPath;
				conveyorPath5[conveyorPath5.Count - 1] = value;
			}
		}

		private Vector3Int GetClosestOperatorInput(Vector3Int position)
		{
			Vector3 hitPos;
			FactoryObjectView hoveredViewOrGridView = _mouseToGridInput.GetHoveredViewOrGridView(out hitPos);
			if (hoveredViewOrGridView == null || hoveredViewOrGridView.FactoryObject == null || hoveredViewOrGridView.FactoryObject.FactoryObjectData == _conveyorData)
			{
				return position;
			}
			position = _gridLocator.GetCellPosition(hitPos);
			FactoryObject factoryObject = hoveredViewOrGridView.FactoryObject;
			Vector3Int result = position;
			float num = float.MaxValue;
			foreach (FactoryObjectData.InputData dataInputPosition in factoryObject.DataInputPositions)
			{
				Vector3Int vector3Int = factoryObject.DataPosToWorldPos(dataInputPosition.Position - dataInputPosition.Direction);
				if (!_factoryLayer.Value.TryGetObjectAt(vector3Int, out var _))
				{
					float num2 = (position - vector3Int).sqrMagnitude;
					if (num2 < num)
					{
						result = vector3Int;
						num = num2;
					}
				}
			}
			return result;
		}

		private int GetInputRotationAtPosition(Vector3Int pos, Vector3Int dir, out bool hasSetInputRotation)
		{
			Vector3Int vector3Int = dir;
			int num = 0;
			Vector3Int[] neighboringPositions = GridUtils.GetNeighboringPositions(pos);
			foreach (Vector3Int position in neighboringPositions)
			{
				if (!_factoryLayer.Value.TryGetObjectAt(position, out var factoryObject))
				{
					continue;
				}
				if (num >= 2)
				{
					break;
				}
				foreach (FactoryObjectData.InputData dataInputPosition in factoryObject.DataInputPositions)
				{
					if (num >= 2)
					{
						break;
					}
					if (factoryObject.DataPosToWorldPos(dataInputPosition.Position - dataInputPosition.Direction) == pos)
					{
						num++;
						vector3Int = factoryObject.DataDirToWorldDir(dataInputPosition.Direction);
					}
				}
			}
			hasSetInputRotation = num == 1;
			Vector3Int vector3Int2 = ((num == 1) ? vector3Int : dir);
			return GetRotation(vector3Int2.x, vector3Int2.z);
		}

		private int GetOutputRotationAtPosition(Vector3Int pos, Vector3Int dir)
		{
			Vector3Int vector3Int = dir;
			int num = 0;
			Vector3Int[] neighboringPositions = GridUtils.GetNeighboringPositions(pos);
			foreach (Vector3Int position in neighboringPositions)
			{
				if (!_factoryLayer.Value.TryGetObjectAt(position, out var factoryObject))
				{
					continue;
				}
				if (num >= 2)
				{
					break;
				}
				foreach (FactoryObjectData.OutputData dataOutputPosition in factoryObject.DataOutputPositions)
				{
					if (num >= 2)
					{
						break;
					}
					if (factoryObject.DataPosToWorldPos(dataOutputPosition.Position) == pos)
					{
						num++;
						vector3Int = factoryObject.DataDirToWorldDir(dataOutputPosition.Direction);
					}
				}
			}
			Vector3Int vector3Int2 = ((num == 1) ? vector3Int : dir);
			return GetRotation(vector3Int2.x, vector3Int2.z);
		}

		private void GetConveyorLine(Vector3Int startPos, Vector3Int endPos, out Vector3Int dir, out int length)
		{
			Vector3Int vector3Int = endPos - startPos;
			int num = Mathf.Min(Mathf.Abs(vector3Int.x), _maxLineSegmentLength);
			int num2 = Mathf.Min(Mathf.Abs(vector3Int.z), _maxLineSegmentLength);
			bool flag = num > num2;
			dir = new Vector3Int(flag ? ((int)Mathf.Sign(vector3Int.x)) : 0, 0, (!flag) ? ((int)Mathf.Sign(vector3Int.z)) : 0);
			length = Mathf.Max(1, flag ? num : num2);
		}

		private void GetConveyorLine(Vector3Int startPos, Vector3Int endPos, bool xFirst, out Vector3Int dir, out int length)
		{
			Vector3Int vector3Int = endPos - startPos;
			int num = Mathf.Min(Mathf.Abs(vector3Int.x), _maxLineSegmentLength);
			int num2 = Mathf.Min(Mathf.Abs(vector3Int.z), _maxLineSegmentLength);
			dir = new Vector3Int(xFirst ? ((int)Mathf.Sign(vector3Int.x)) : 0, 0, (!xFirst) ? ((int)Mathf.Sign(vector3Int.z)) : 0);
			length = (xFirst ? num : num2);
		}

		private bool IsPosEmptyOrConveyorInSameDir(Vector3Int position, Vector3Int direction)
		{
			FactoryObject factoryObject;
			bool flag = _factoryLayer.Value.TryGetObjectAt(position, out factoryObject);
			FactoryObject factoryObject2;
			bool flag2 = _terrainLayer.TryGetObjectAt(position, out factoryObject2);
			if (!flag && !flag2)
			{
				return true;
			}
			if (flag && (factoryObject.FactoryObjectData == _conveyorData || factoryObject.FactoryObjectData == _extractorData))
			{
				return factoryObject.DataDirToWorldDir(factoryObject.DataOutputPositions[0].Direction) == direction;
			}
			return false;
		}

		private bool IsPosEmptyOrConveyor(Vector3Int position, Vector3Int direction)
		{
			FactoryObject factoryObject;
			bool flag = _factoryLayer.Value.TryGetObjectAt(position, out factoryObject);
			FactoryObject factoryObject2;
			bool flag2 = _terrainLayer.TryGetObjectAt(position, out factoryObject2);
			if (!flag && !flag2)
			{
				return true;
			}
			if (flag)
			{
				if (!(factoryObject.FactoryObjectData == _conveyorData))
				{
					if (factoryObject.FactoryObjectData == _extractorData)
					{
						return factoryObject.DataDirToWorldDir(factoryObject.DataOutputPositions[0].Direction) == direction;
					}
					return false;
				}
				return true;
			}
			return false;
		}

		private bool IsConveyorInSameDir(Vector3Int position, Vector3Int direction)
		{
			if (!_factoryLayer.Value.TryGetObjectAt(position, out var factoryObject))
			{
				return false;
			}
			if (factoryObject.FactoryObjectData == _conveyorData || factoryObject.FactoryObjectData == _extractorData)
			{
				return factoryObject.DataDirToWorldDir(factoryObject.DataOutputPositions[0].Direction) == direction;
			}
			return false;
		}

		private void AddConveyorLine(Vector3Int startPos, Vector3Int dir, Vector3Int mousePos, int length, bool isLastConveyorLine, out ConveyorLine line)
		{
			List<BlueprintElement> lineElements = new List<BlueprintElement>();
			int rotation = GetRotation(dir.x, dir.z);
			bool skipConveyorOnLastPosition = false;
			for (int i = 0; i < length; i++)
			{
				Vector3Int currPos = startPos + dir * i;
				if (TryPlaceSkyline(dir, length, lineElements, rotation, ref skipConveyorOnLastPosition, ref i, currPos, isLastConveyorLine))
				{
					continue;
				}
				if (_factoryLayer.Value.TryGetObjectAt(currPos + dir, out var factoryObject) && factoryObject.FactoryObjectData == _inTunnelData && factoryObject.DataDirToWorldDir(factoryObject.DataInputPositions[0].Direction) == dir && factoryObject.HardLinkedObjects[0].DataDirToWorldDir(factoryObject.HardLinkedObjects[0].DataOutputPositions[0].Direction) == dir)
				{
					InputTunnelBehavior factoryObjectBehaviour = factoryObject.GetFactoryObjectBehaviour<InputTunnelBehavior>();
					if (i + factoryObjectBehaviour.TunnelDistance < length)
					{
						PlaceConveyor();
						i += factoryObjectBehaviour.TunnelDistance;
						continue;
					}
				}
				bool flag = false;
				if (i < length - 1)
				{
					bool num = IsPosEmptyOrConveyorInSameDir(currPos + dir, dir);
					bool flag2 = IsPosEmptyOrConveyorInSameDir(currPos + dir, -dir);
					FactoryObject factoryObject2;
					bool flag3 = !_factoryLayer.Value.TryGetObjectAt(currPos, out factoryObject2) && !_terrainLayer.TryGetObjectAt(currPos, out factoryObject2);
					if (!num && !flag2 && flag3 && !TrySkipFromOperatorInputToOuput(dir, length, ref i, currPos))
					{
						flag = TryPlaceTunnel(dir, mousePos, length, lineElements, rotation, ref skipConveyorOnLastPosition, ref i, currPos);
					}
					if (flag)
					{
						continue;
					}
				}
				PlaceConveyor();
				void PlaceConveyor()
				{
					if (!IsConveyorInSameDir(currPos, dir))
					{
						BlueprintElement item = new BlueprintElement(new List<Vector3Int> { currPos }, _conveyorObjectData, rotation, mirrored: false);
						lineElements.Add(item);
						_allConveyorElements.Add(item);
					}
				}
			}
			line = new ConveyorLine
			{
				LineStart = startPos,
				LineEnd = startPos + dir * (skipConveyorOnLastPosition ? length : (length - 1)),
				LineDir = dir,
				LineElements = lineElements
			};
			_conveyorPath.Add(line);
		}

		private bool TryPlaceTunnel(Vector3Int dir, Vector3Int mousePos, int length, List<BlueprintElement> lineElements, int rotation, ref bool outputTunnelIsLastObject, ref int i, Vector3Int currPos)
		{
			if (_lockedFactoryObjects.IsFactoryObjectLocked(_inTunnelData))
			{
				return false;
			}
			for (int j = 2; j < _tunnelTool.MaxDistance + 1; j++)
			{
				outputTunnelIsLastObject = outputTunnelIsLastObject || currPos + dir * j == mousePos;
				if (i + j >= (outputTunnelIsLastObject ? (length + 1) : length) || (_allConveyorElements.Count > 0 && i == 0))
				{
					return false;
				}
				Vector3Int vector3Int = currPos + dir * j;
				if (IsPosEmptyOrConveyorInSameDir(vector3Int, dir) && IsPosEmptyOrConveyorInSameDir(vector3Int + dir, dir))
				{
					BlueprintElement item = new BlueprintElement(new List<Vector3Int> { currPos }, _inTunnelData, rotation, mirrored: false, isSoftLinked: false, isHardLinked: true, new List<Vector3Int>(), new List<Vector3Int> { vector3Int });
					lineElements.Add(item);
					_allConveyorElements.Add(item);
					BlueprintElement item2 = new BlueprintElement(new List<Vector3Int> { vector3Int }, _outTunnelData, rotation, mirrored: false, isSoftLinked: false, isHardLinked: true, new List<Vector3Int>(), new List<Vector3Int> { currPos });
					lineElements.Add(item2);
					_allConveyorElements.Add(item2);
					i += j;
					return true;
				}
			}
			return false;
		}

		private bool TryPlaceSkyline(Vector3Int dir, int length, List<BlueprintElement> lineElements, int rotation, ref bool skipConveyorOnLastPosition, ref int i, Vector3Int currPos, bool isLastConveyorLine)
		{
			int num = i + _skylineLength.Value;
			if (isLastConveyorLine && i == 0)
			{
				return false;
			}
			if (!isLastConveyorLine && num > length - 1)
			{
				return false;
			}
			if (_lockedFactoryObjects.IsFactoryObjectLocked(_inTunnelData))
			{
				return false;
			}
			if (!_islandLayer.TryGetIslandAtWorldPosition(currPos, out var islandObject) || !islandObject.IsPositionOnIsland(currPos) || islandObject.IsPositionOnIsland(currPos + dir))
			{
				return false;
			}
			Vector3Int item = currPos + dir * _skylineLength.Value;
			BlueprintElement item2 = new BlueprintElement(new List<Vector3Int> { currPos }, _inSkylineData, rotation, mirrored: false, isSoftLinked: false, isHardLinked: true, new List<Vector3Int>(), new List<Vector3Int> { item });
			lineElements.Add(item2);
			_allConveyorElements.Add(item2);
			BlueprintElement item3 = new BlueprintElement(new List<Vector3Int> { item }, _outSkylineData, rotation, mirrored: false, isSoftLinked: false, isHardLinked: true, new List<Vector3Int>(), new List<Vector3Int> { currPos });
			lineElements.Add(item3);
			_allConveyorElements.Add(item3);
			i = num;
			skipConveyorOnLastPosition = skipConveyorOnLastPosition || num >= length;
			return true;
		}

		private bool TrySkipFromOperatorInputToOuput(Vector3Int dir, int length, ref int i, Vector3Int currPos)
		{
			if (!DoesPosInputFrom(currPos, dir))
			{
				return false;
			}
			for (int j = 2; i + j < length + 1; j++)
			{
				Vector3Int vector3Int = currPos + dir * j;
				if (IsPosEmptyOrConveyor(vector3Int, dir) && DoesPosOutputTo(vector3Int, dir))
				{
					i += j - 1;
					return true;
				}
			}
			return false;
		}

		private bool DoesPosInputFrom(Vector3Int currPos, Vector3Int dir)
		{
			Vector3Int vector3Int = currPos + dir;
			if (!_factoryLayer.Value.TryGetObjectAt(vector3Int, out var factoryObject))
			{
				return false;
			}
			foreach (FactoryObjectData.InputData dataInputPosition in factoryObject.DataInputPositions)
			{
				if (factoryObject.DataPosToWorldPos(dataInputPosition.Position) == vector3Int && factoryObject.DataDirToWorldDir(dataInputPosition.Direction) == dir)
				{
					return true;
				}
			}
			return false;
		}

		private bool DoesPosOutputTo(Vector3Int currPos, Vector3Int dir)
		{
			if (!_factoryLayer.Value.TryGetObjectAt(currPos - dir, out var factoryObject))
			{
				return false;
			}
			foreach (FactoryObjectData.OutputData dataOutputPosition in factoryObject.DataOutputPositions)
			{
				if (factoryObject.DataPosToWorldPos(dataOutputPosition.Position) == currPos && factoryObject.DataDirToWorldDir(dataOutputPosition.Direction) == dir)
				{
					return true;
				}
			}
			return false;
		}

		private void RemoveConveyorLine(ConveyorLine conveyorLine)
		{
			for (int num = conveyorLine.LineElements.Count - 1; num >= 0; num--)
			{
				_allConveyorElements.Remove(conveyorLine.LineElements[num]);
			}
			_conveyorPath.Remove(conveyorLine);
		}

		private void UpdateBlueprint()
		{
			_selectedBlueprint.SetElements(_allConveyorElements);
			if (_allConveyorElements.Count > 0)
			{
				_blueprintViewDto = BlueprintViewDto.Create(_selectedBlueprint, _gridLocator, _selectedBlueprint.Position);
				UpdatePreview(Vector3Int.zero);
			}
			else
			{
				_stopPreviewEvent.Fire();
				_previewStarted = false;
			}
		}

		public override void UpdateTool(Vector3Int gridPos, Vector3 mousePos)
		{
			if (_hasRotatedAtPos && gridPos != _rotatePos)
			{
				_hasRotatedAtPos = false;
			}
			UpdateArrows(gridPos);
			if (!_dragStarted || (gridPos == _currentAnchor.Position && _path.Count <= 1))
			{
				Vector3Int direction = GetDirection(_rotationLastTile);
				bool hasSetInputRotation;
				int rotation = GetInputRotationAtPosition(gridPos, direction, out hasSetInputRotation);
				if (!hasSetInputRotation)
				{
					rotation = GetOutputRotationAtPosition(gridPos, direction);
				}
				if (_hasRotatedAtPos)
				{
					rotation = _rotationLastTile;
				}
				BlueprintElement item = new BlueprintElement(new List<Vector3Int> { gridPos }, _conveyorObjectData, rotation, mirrored: false);
				_allConveyorElements.Clear();
				_allConveyorElements.Add(item);
				UpdateBlueprint();
				_lastDragPosition = gridPos;
			}
			else if (gridPos != _lastDragPosition)
			{
				_lastDragPosition = gridPos;
				PlaceConveyors(gridPos);
				_audioManagerLocator.AudioManager.PlayPlaceConveyorPreview(gridPos);
			}
		}

		private void UpdateArrows(Vector3Int position)
		{
			Dictionary<FactoryObjectView, FactoryObjectInputOutputArrows> dictionary = new Dictionary<FactoryObjectView, FactoryObjectInputOutputArrows>();
			for (int i = position.z - _showArrowsDistance; i < position.z + _showArrowsDistance; i++)
			{
				for (int j = position.x - _showArrowsDistance; j < position.x + _showArrowsDistance; j++)
				{
					Vector3Int position2 = new Vector3Int(j, 0, i);
					if (_factoryLayer.Value.TryGetObjectAt(position2, out var factoryObject) && FactoryObjectViewManager.Instance.TryGetFactoryObjectView(factoryObject.CreatedId, out var view))
					{
						FactoryObjectInputOutputArrows componentInChildren = view.GetComponentInChildren<FactoryObjectInputOutputArrows>();
						if (!(componentInChildren == null))
						{
							dictionary.TryAdd(view, componentInChildren);
						}
					}
				}
			}
			foreach (KeyValuePair<FactoryObjectView, FactoryObjectInputOutputArrows> item in dictionary)
			{
				if (!_factoryObjectsArrowsShowing.ContainsKey(item.Key))
				{
					item.Value.ShowEmptyInputs();
					item.Value.ShowEmptyOutputs();
				}
				else
				{
					_factoryObjectsArrowsShowing.Remove(item.Key);
				}
			}
			foreach (KeyValuePair<FactoryObjectView, FactoryObjectInputOutputArrows> item2 in _factoryObjectsArrowsShowing)
			{
				item2.Value.HideAll();
			}
			_factoryObjectsArrowsShowing.Clear();
			_factoryObjectsArrowsShowing = dictionary;
		}

		private void HideAllArrows()
		{
			foreach (KeyValuePair<FactoryObjectView, FactoryObjectInputOutputArrows> item in _factoryObjectsArrowsShowing)
			{
				item.Value.HideAll();
			}
			_factoryObjectsArrowsShowing.Clear();
		}

		private void UpdatePreview(Vector3Int position)
		{
			_selectedBlueprint.SetRotation(0);
			_setCursorTextEvent.Fire(string.Empty);
			_failReasonEvent.Register(base.HandleFailReasonEvent);
			bool canBePlaced = BlueprintPlacementValidator.CanBePlaced(position, _selectedBlueprint, _factoryLayer.Value, _terrainLayer);
			_failReasonEvent.UnRegister(base.HandleFailReasonEvent);
			_blueprintViewDto.Position = _gridLocator.GetWorldPosition(position);
			if (!_previewStarted)
			{
				_startPreviewEvent.Fire(new BlueprintViewEventDto(_blueprintViewDto, canBePlaced));
				_previewStarted = true;
			}
			else
			{
				_updatePreviewEvent.Fire(new BlueprintViewEventDto(_blueprintViewDto, canBePlaced));
			}
			ShowFailReasons();
		}

		private List<Vector3Int> GetNewPosition()
		{
			List<Vector3Int> relativePositions = _conveyorObjectData.RelativePositions;
			List<Vector3Int> list = new List<Vector3Int>(relativePositions.Count);
			foreach (Vector3Int item in relativePositions)
			{
				list.Add(item);
			}
			return list;
		}

		private int GetRotation(int stepX, int stepZ)
		{
			return stepX switch
			{
				1 => 90, 
				-1 => 270, 
				_ => stepZ switch
				{
					1 => 0, 
					-1 => 180, 
					_ => 0, 
				}, 
			};
		}

		private Vector3Int GetDirection(int rotation)
		{
			return rotation switch
			{
				0 => new Vector3Int(0, 0, 1), 
				90 => new Vector3Int(1, 0, 0), 
				180 => new Vector3Int(0, 0, -1), 
				270 => new Vector3Int(-1, 0, 0), 
				_ => Vector3Int.zero, 
			};
		}

		public override void OnActionIntent(Vector3Int gridPos, Vector3 mousePos)
		{
			_dragStarted = true;
			_currentAnchor = GetStartAnchor(gridPos);
		}

		public override void Rotate(int rotation)
		{
			Vector3 selectedMapPosition = _mouseToGridInput.GetSelectedMapPosition();
			Vector3Int cellPosition = _gridLocator.GetCellPosition(selectedMapPosition);
			if (!_hasRotatedAtPos)
			{
				bool hasSetInputRotation;
				int inputRotationAtPosition = GetInputRotationAtPosition(cellPosition, GetDirection(_rotationLastTile), out hasSetInputRotation);
				if (hasSetInputRotation)
				{
					_rotationLastTile = inputRotationAtPosition;
				}
			}
			_rotationLastTile = _selectedBlueprint.ClampAngle(_rotationLastTile + rotation);
			if (IsRotationInValid())
			{
				_rotationLastTile = _selectedBlueprint.ClampAngle(_rotationLastTile + rotation);
			}
			if (_path.Count <= 1)
			{
				List<BlueprintElement> path = _path;
				path[path.Count - 1].Rotation = _rotationLastTile;
				Vector3 position = _blueprintViewDto.Position;
				_blueprintViewDto = BlueprintViewDto.Create(_selectedBlueprint, _gridLocator, _selectedBlueprint.Position);
				_audioManagerLocator.AudioManager.PlayRotateObject(position, _conveyorData.ObjectSize);
			}
			_selectedBlueprint.SetElements(_path);
			base.Rotate(rotation);
			_hasRotatedAtPos = true;
			_rotatePos = cellPosition;
			UpdateTool(_gridLocator.GetCellPosition(selectedMapPosition), selectedMapPosition);
		}

		private bool IsRotationInValid()
		{
			if (_path.Count > 1)
			{
				Blueprint selectedBlueprint = _selectedBlueprint;
				int rotationLastTile = _rotationLastTile;
				List<BlueprintElement> path = _path;
				return selectedBlueprint.ClampAngle(rotationLastTile - path[path.Count - 2].Rotation) == 180;
			}
			return false;
		}

		public override void Mirror()
		{
			_currentAnchor.xFirst = !_currentAnchor.xFirst;
			Vector3 selectedMapPosition = _mouseToGridInput.GetSelectedMapPosition();
			Vector3Int cellPosition = _gridLocator.GetCellPosition(selectedMapPosition);
			PlaceConveyors(cellPosition);
			_audioManagerLocator.AudioManager.PlayPlaceConveyorPreview(cellPosition);
		}

		public override void DoAction(Vector3Int gridPos, Vector3 mousePos)
		{
			PlaceBlueprintCommand command = new PlaceBlueprintCommand(_factoryLayer.Value, _terrainLayer, Vector3Int.zero, _selectedBlueprint.Rotation, _selectedBlueprint, _createFactoryObjectEvent, _gridLocator, _factoryObjectsRemoveViewsEvent, _audioManagerLocator);
			_commandManager.DoCommand(command);
			_dragStarted = false;
			_stopPreviewEvent.Fire();
			_previewStarted = false;
			int rotationLastTile = _rotationLastTile;
			SelectTool(null);
			_rotationLastTile = rotationLastTile;
			HideAllArrows();
			UpdateTool(gridPos, mousePos);
		}

		public override void CancelAction()
		{
			_dragStarted = false;
			_stopPreviewEvent.Fire();
			_previewStarted = false;
			HideAllArrows();
		}

		public override void DeSelectTool()
		{
			_path = new List<BlueprintElement>
			{
				new BlueprintElement(GetNewPosition(), _conveyorObjectData, 0, mirrored: false)
			};
			_stopPreviewEvent.Fire();
			_previewStarted = false;
			HideAllArrows();
		}
	}
}

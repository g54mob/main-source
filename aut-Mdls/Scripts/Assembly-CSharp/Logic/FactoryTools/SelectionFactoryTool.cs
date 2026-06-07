using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor;
using Data.FactoryFloor.Maps;
using Data.Operator;
using Data.Variables;
using Events;
using Events.FactoryFloor;
using Events.Generic;
using Logic.Factory;
using Logic.Factory.Blueprint;
using Presentation.FactoryFloor;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.Pool;

namespace Logic.FactoryTools
{
	public abstract class SelectionFactoryTool : FactoryTool
	{
		[Header("Selection Refs")]
		[SerializeField]
		protected CurrentFactoryLayer _factoryLayer;

		[SerializeField]
		protected MouseToGridInput _mouseToGridInput;

		[SerializeField]
		protected FactoryObjectDatabase _factoryObjectDatabase;

		[SerializeField]
		protected CranesLibrarySO _cranesLibrary;

		[SerializeField]
		private IntListEvent _newFactoryObjectsSelectedEvent;

		[SerializeField]
		private IntListEvent _factoryObjectsDeSelectedEvent;

		[SerializeField]
		private BoxEvent _updateSelectionBoxSizeEvent;

		[SerializeField]
		private BaseEvent _disableSelectionBoxEvent;

		[SerializeField]
		protected IslandLayer _islandLayer;

		[SerializeField]
		protected GridLocator _gridLocator;

		protected bool _isSelecting = true;

		protected Blueprint _selection;

		protected bool _singleSelectCanAffectNonChangeable;

		protected Vector3Int _initialGridPosition;

		protected Vector3Int _lastUpdatePosition;

		protected bool _actionStarted;

		private int _objectSize;

		private List<FactoryObject> _currentSelectedItems = new List<FactoryObject>();

		private FactoryObjectView _selectedObject;

		public override bool CanAutoSwapAwayFrom
		{
			get
			{
				if (!_actionStarted && !_isSelecting)
				{
					return _selection == null;
				}
				return false;
			}
		}

		public override void SelectTool(Blueprint blueprint)
		{
			base.SelectTool(blueprint);
			_actionStarted = false;
			_isSelecting = true;
			_singleSelectCanAffectNonChangeable = false;
			_lastUpdatePosition = new Vector3Int(0, 1000, 0);
		}

		public override void UpdateTool(Vector3Int gridPos, Vector3 mousePos)
		{
			if (_isSelecting)
			{
				SelectionUpdateTool(gridPos);
				return;
			}
			gridPos = _gridLocator.GetCellPosition(mousePos + _selection.MiddleOffset);
			ImplementedUpdateTool(gridPos);
		}

		public override void OnActionIntent(Vector3Int gridPos, Vector3 mousePos)
		{
			if (_isSelecting)
			{
				SelectionOnActionIntent(gridPos);
				return;
			}
			gridPos = _gridLocator.GetCellPosition(mousePos + _selection.MiddleOffset);
			ImplementedOnActionIntent(gridPos);
		}

		public override void DoAction(Vector3Int gridPos, Vector3 mousePos)
		{
			if (_isSelecting)
			{
				SelectionDoAction(gridPos);
				return;
			}
			gridPos = _gridLocator.GetCellPosition(mousePos + _selection.MiddleOffset);
			ImplementedDoAction(gridPos);
		}

		public override void CancelAction()
		{
			if (_isSelecting)
			{
				SelectionCancelAction();
				return;
			}
			_actionStarted = false;
			_isSelecting = true;
			ImplementedCancelAction();
		}

		public override void DeSelectTool()
		{
			_factoryObjectsDeSelectedEvent.Fire(_currentSelectedItems.Select((FactoryObject x) => x.CreatedId).ToList());
			_actionStarted = false;
			if (_selectedObject != null)
			{
				_selectedObject.DeSelect();
			}
			_selectedObject = null;
			_disableSelectionBoxEvent.Fire();
		}

		protected abstract void ImplementedSelectTool(Blueprint blueprint, bool singleObject = false);

		protected abstract void ImplementedUpdateTool(Vector3Int position);

		protected abstract void ImplementedOnActionIntent(Vector3Int position);

		protected abstract void ImplementedDoAction(Vector3Int position);

		protected abstract void ImplementedCancelAction();

		private void SelectionUpdateTool(Vector3Int position)
		{
			UpdateSelectedObject(position);
			if (!_actionStarted || _lastUpdatePosition == position)
			{
				return;
			}
			_lastUpdatePosition = position;
			if (position == _initialGridPosition)
			{
				ObjectInPointer(position);
				_disableSelectionBoxEvent.Fire();
				return;
			}
			List<FactoryObject> list = CollectionPool<List<FactoryObject>, FactoryObject>.Get();
			List<FactoryObject> list2 = CollectionPool<List<FactoryObject>, FactoryObject>.Get();
			_factoryLayer.Value.GetObjectsBetween(_initialGridPosition, position, list);
			foreach (FactoryObject currentSelectedItem in _currentSelectedItems)
			{
				if (!list.Contains(currentSelectedItem))
				{
					list2.Add(currentSelectedItem);
				}
			}
			RemoveNonSelectableObjectsFromSelection(list);
			_currentSelectedItems.Clear();
			_currentSelectedItems.AddRange(list);
			_factoryObjectsDeSelectedEvent.Fire(list2.Select((FactoryObject x) => x.CreatedId).ToList());
			_newFactoryObjectsSelectedEvent.Fire(_currentSelectedItems.Select((FactoryObject x) => x.CreatedId).ToList());
			_updateSelectionBoxSizeEvent.Fire(new BoxSize(_initialGridPosition, position));
			CollectionPool<List<FactoryObject>, FactoryObject>.Release(list);
			CollectionPool<List<FactoryObject>, FactoryObject>.Release(list2);
		}

		private void SelectionOnActionIntent(Vector3Int position)
		{
			_actionStarted = true;
			_initialGridPosition = position;
			_selection = null;
			_objectSize = 0;
		}

		private void SelectionDoAction(Vector3Int position)
		{
			if (!_actionStarted)
			{
				return;
			}
			_actionStarted = false;
			if (position == _initialGridPosition && (!_islandLayer.TryGetIslandAtWorldPosition(position, out var islandObject) || !islandObject.IsPositionOnIsland(position)))
			{
				NotOnIslandSelect();
				if (_selection != null)
				{
					ImplementedSelectTool(_selection, _initialGridPosition == position);
				}
				return;
			}
			if (_currentSelectedItems.Count > 0)
			{
				_factoryObjectsDeSelectedEvent.Fire(_currentSelectedItems.Select((FactoryObject x) => x.CreatedId).ToList());
				_currentSelectedItems.Clear();
			}
			List<FactoryObject> list = CollectionPool<List<FactoryObject>, FactoryObject>.Get();
			List<Vector3Int> list2 = CollectionPool<List<Vector3Int>, Vector3Int>.Get();
			_factoryLayer.Value.GetObjectsBetween(_initialGridPosition, position, list);
			_factoryLayer.Value.GetCranesBetween(_cranesLibrary, _initialGridPosition, position, list2);
			RemoveNonSelectableObjectsFromSelection(list);
			Vector3Int vector3Int = _initialGridPosition;
			if (list.Count > 0)
			{
				vector3Int = FindCenter(list);
			}
			List<BlueprintElement> blueprintElements = GetBlueprintElements(vector3Int, list);
			_selection = new Blueprint(vector3Int, 0, blueprintElements, list2);
			CollectionPool<List<FactoryObject>, FactoryObject>.Release(list);
			if (_selectedObject != null)
			{
				_selectedObject.DeSelect();
			}
			_selectedObject = null;
			_disableSelectionBoxEvent.Fire();
			_isSelecting = false;
			if (_initialGridPosition == position)
			{
				UpdateSelectedObject(Vector3Int.zero);
				if (_selectedObject != null && _selectedObject.FactoryObject != null)
				{
					List<FactoryObject> list3 = CollectionPool<List<FactoryObject>, FactoryObject>.Get();
					_factoryLayer.Value.GetObjectsBetween(_selectedObject.FactoryObject.Position, _selectedObject.FactoryObject.Position, list3);
					blueprintElements = GetBlueprintElements(vector3Int, list3);
					_selection = new Blueprint(vector3Int, 0, blueprintElements, list2);
					CollectionPool<List<FactoryObject>, FactoryObject>.Release(list3);
				}
			}
			CollectionPool<List<Vector3Int>, Vector3Int>.Release(list2);
			_objectSize = 0;
			foreach (BlueprintElement element in _selection.Elements)
			{
				_objectSize = Mathf.Max(_objectSize, element.ObjectData.ObjectSize);
			}
			ImplementedSelectTool(_selection, _initialGridPosition == position);
		}

		private void NotOnIslandSelect()
		{
			FactoryObjectView selectedFactoryObjectView = _mouseToGridInput.GetSelectedFactoryObjectView();
			if (selectedFactoryObjectView != null && selectedFactoryObjectView.FactoryObject != null)
			{
				SelectFactoryObject(selectedFactoryObjectView.FactoryObject);
			}
		}

		private void SelectionCancelAction()
		{
			_factoryObjectsDeSelectedEvent.Fire(_currentSelectedItems.Select((FactoryObject x) => x.CreatedId).ToList());
			_disableSelectionBoxEvent.Fire();
			_actionStarted = false;
			_lastUpdatePosition = new Vector3Int(0, 1000, 0);
		}

		protected void SelectFactoryObject(FactoryObject factoryObject)
		{
			List<FactoryObject> list = CollectionPool<List<FactoryObject>, FactoryObject>.Get();
			_factoryLayer.Value.GetObjectsBetween(factoryObject.Position, factoryObject.Position, list);
			List<Vector3Int> cranePositions = new List<Vector3Int>();
			RemoveNonSelectableObjectsFromSelection(list);
			List<BlueprintElement> blueprintElements = GetBlueprintElements(factoryObject.Position, list);
			_selection = new Blueprint(factoryObject.Position, 0, blueprintElements, cranePositions);
			_objectSize = factoryObject.FactoryObjectData.ObjectSize;
			CollectionPool<List<FactoryObject>, FactoryObject>.Release(list);
			if (_selectedObject != null)
			{
				_selectedObject.DeSelect();
			}
			_selectedObject = null;
			_disableSelectionBoxEvent.Fire();
			_isSelecting = false;
			if (_initialGridPosition == factoryObject.Position && _selectedObject != null)
			{
				blueprintElements = GetBlueprintElements(factoryObject.Position, new List<FactoryObject> { _selectedObject.FactoryObject });
				_selection = new Blueprint(factoryObject.Position, 0, blueprintElements, cranePositions);
			}
		}

		private void UpdateSelectedObject(Vector3Int position)
		{
			if (_actionStarted)
			{
				DeselectObj();
				return;
			}
			FactoryObjectView hoveredViewOrGridView = _mouseToGridInput.GetHoveredViewOrGridView();
			if (hoveredViewOrGridView == null)
			{
				DeselectObj();
			}
			else if (hoveredViewOrGridView.FactoryObject == null || CanSelectFactoryObject(hoveredViewOrGridView.FactoryObject, isSingle: true))
			{
				hoveredViewOrGridView.Select();
				if (_selectedObject != hoveredViewOrGridView)
				{
					DeselectObj();
					_selectedObject = hoveredViewOrGridView;
				}
			}
		}

		private void DeselectObj()
		{
			if (_selectedObject != null)
			{
				_selectedObject.DeSelect();
				_selectedObject = null;
			}
		}

		private void ObjectInPointer(Vector3Int position)
		{
			FactoryObjectView selectedFactoryObjectView = _mouseToGridInput.GetSelectedFactoryObjectView();
			FactoryObject factoryObject = ((!(selectedFactoryObjectView != null)) ? _factoryLayer.Value.GetObjectAt(position) : selectedFactoryObjectView.FactoryObject);
			if (factoryObject != null)
			{
				if (!CanSelectFactoryObject(factoryObject, isSingle: false) || _currentSelectedItems.Contains(factoryObject))
				{
					return;
				}
				if (_currentSelectedItems.Count > 0)
				{
					_factoryObjectsDeSelectedEvent.Fire(_currentSelectedItems.Select((FactoryObject x) => x.CreatedId).ToList());
					_currentSelectedItems.Clear();
				}
				_currentSelectedItems.Add(factoryObject);
				_newFactoryObjectsSelectedEvent.Fire(_currentSelectedItems.Select((FactoryObject x) => x.CreatedId).ToList());
			}
			else if (_currentSelectedItems.Count > 0)
			{
				_factoryObjectsDeSelectedEvent.Fire(_currentSelectedItems.Select((FactoryObject x) => x.CreatedId).ToList());
				_currentSelectedItems.Clear();
			}
		}

		private void RemoveNonSelectableObjectsFromSelection(List<FactoryObject> factoryObjects)
		{
			for (int num = factoryObjects.Count - 1; num >= 0; num--)
			{
				if (num < factoryObjects.Count)
				{
					FactoryObject factoryObject = factoryObjects[num];
					if (factoryObject == null)
					{
						factoryObjects.RemoveAt(num);
					}
					else if (!CanSelectFactoryObject(factoryObject, isSingle: false))
					{
						RemoveObjectAndHardLinksFromList(factoryObject, factoryObjects);
					}
				}
			}
		}

		protected virtual bool CanSelectFactoryObject(FactoryObject factoryObject, bool isSingle)
		{
			if (factoryObject.NonChangable)
			{
				return _singleSelectCanAffectNonChangeable;
			}
			return true;
		}

		private void RemoveObjectAndHardLinksFromList(FactoryObject objectToRemove, List<FactoryObject> selection)
		{
			selection.Remove(objectToRemove);
			foreach (FactoryObject hardLinkedObject in objectToRemove.HardLinkedObjects)
			{
				if (selection.Contains(hardLinkedObject))
				{
					RemoveObjectAndHardLinksFromList(hardLinkedObject, selection);
				}
			}
		}

		private List<BlueprintElement> GetBlueprintElements(Vector3Int parentPosition, IEnumerable<FactoryObject> factoryObjects)
		{
			List<BlueprintElement> list = new List<BlueprintElement>();
			foreach (FactoryObject factoryObject in factoryObjects)
			{
				list.Add(new BlueprintElement(GetRelativePositions(parentPosition, factoryObject.OccupiedPositions), _factoryObjectDatabase.GetObjectDataWithId(factoryObject.ObjectId), factoryObject.Rotation, factoryObject.Mirrored, factoryObject.IsSoftLinked, factoryObject.IsHardLinked, GetRelativePositions(parentPosition, factoryObject.SoftLinkedObjects), GetRelativePositions(parentPosition, factoryObject.HardLinkedObjects), factoryObject.GetConfigurations(), factoryObject.GetSaveStates(), factoryObject.CreatedId));
			}
			return list;
		}

		private List<Vector3Int> GetRelativePositions(Vector3Int parentPosition, List<FactoryObject> linkedObjects)
		{
			List<Vector3Int> list = new List<Vector3Int>();
			if (linkedObjects == null || linkedObjects.Count == 0)
			{
				return list;
			}
			foreach (FactoryObject linkedObject in linkedObjects)
			{
				if (linkedObject != null)
				{
					Vector3Int item = new Vector3Int(linkedObject.Position.x - parentPosition.x, linkedObject.Position.y - parentPosition.y, linkedObject.Position.z - parentPosition.z);
					list.Add(item);
				}
			}
			return list;
		}

		private List<Vector3Int> GetRelativePositions(Vector3Int parentPosition, List<Vector3Int> occupiedPositions)
		{
			List<Vector3Int> list = new List<Vector3Int>();
			foreach (Vector3Int occupiedPosition in occupiedPositions)
			{
				list.Add(new Vector3Int(occupiedPosition.x - parentPosition.x, occupiedPosition.y - parentPosition.y, occupiedPosition.z - parentPosition.z));
			}
			return list;
		}

		private Vector3Int FindCenter(List<FactoryObject> selectedItems)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			foreach (FactoryObject selectedItem in selectedItems)
			{
				num += selectedItem.OccupiedPositions[0].x;
				num2 += selectedItem.OccupiedPositions[0].y;
				num3 += selectedItem.OccupiedPositions[0].z;
			}
			int x = num / selectedItems.Count;
			int y = num2 / selectedItems.Count;
			int z = num3 / selectedItems.Count;
			return new Vector3Int(x, y, z);
		}

		public override void Rotate(int rotation)
		{
			base.Rotate(rotation);
			if (!_isSelecting)
			{
				_selection.Rotate(rotation);
				_audioManagerLocator.AudioManager.PlayRotateObject(_selection.Position, _objectSize);
			}
		}

		public override void Mirror()
		{
			base.Mirror();
			if (!_isSelecting)
			{
				_selection.Mirror();
				_audioManagerLocator.AudioManager.PlayRotateObject(_selection.Position, _objectSize);
			}
		}
	}
}

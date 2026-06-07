using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Islands;
using Events.FactoryFloor;
using Presentation.Locators;
using UnityEngine;

namespace Commands.ToolsCommands
{
	public class ConfirmBrushPaintCommand : ICommandUndo, ICommand
	{
		private readonly GridLocator _gridLocator;

		private readonly CreateFactoryObjectEvent _createFactoryObjectEvent;

		private readonly FactoryLayer _terrainLayer;

		private List<FactoryObject> _createdObjects;

		private List<FactoryObject> _deletedObjects;

		private Dictionary<Vector3Int, Color> _previousColors;

		private Dictionary<Vector3Int, Color> _previousHeightColors;

		private Dictionary<Vector3Int, Color> _previousOutsideColors;

		private readonly IslandData _islandData;

		private bool _undoDone;

		public ConfirmBrushPaintCommand(GridLocator gridLocator, CreateFactoryObjectEvent createFactoryObjectEvent, FactoryLayer terrainLayer, IslandData islandData, List<FactoryObject> createdObjects, List<FactoryObject> deletedObjects, Dictionary<Vector3Int, Color> previousColors, Dictionary<Vector3Int, Color> previousHeightColors, Dictionary<Vector3Int, Color> modifiedOutsideColors)
		{
			_gridLocator = gridLocator;
			_createFactoryObjectEvent = createFactoryObjectEvent;
			_terrainLayer = terrainLayer;
			_islandData = islandData;
			_createdObjects = createdObjects;
			_deletedObjects = deletedObjects;
			_previousColors = previousColors;
			_previousHeightColors = previousHeightColors;
			_previousOutsideColors = modifiedOutsideColors;
		}

		public bool TryDo()
		{
			if (!_undoDone)
			{
				return true;
			}
			return TryUnDo();
		}

		public bool TryReDo()
		{
			return TryDo();
		}

		public bool TryUnDo()
		{
			_undoDone = true;
			Dictionary<Vector3Int, Color> dictionary = new Dictionary<Vector3Int, Color>();
			foreach (KeyValuePair<Vector3Int, Color> previousColor4 in _previousColors)
			{
				if (_islandData.PaintTexture(previousColor4.Key, previousColor4.Value, out var previousColor))
				{
					dictionary.Add(previousColor4.Key, previousColor);
				}
			}
			_previousColors = dictionary;
			Dictionary<Vector3Int, Color> dictionary2 = new Dictionary<Vector3Int, Color>();
			foreach (KeyValuePair<Vector3Int, Color> previousHeightColor in _previousHeightColors)
			{
				if (_islandData.PaintTexture(previousHeightColor.Key, previousHeightColor.Value, out var previousColor2))
				{
					dictionary2.Add(previousHeightColor.Key, previousColor2);
				}
			}
			_previousHeightColors = dictionary2;
			Dictionary<Vector3Int, Color> dictionary3 = new Dictionary<Vector3Int, Color>();
			foreach (KeyValuePair<Vector3Int, Color> previousOutsideColor in _previousOutsideColors)
			{
				if (_islandData.PaintTexture(previousOutsideColor.Key, previousOutsideColor.Value, out var previousColor3))
				{
					dictionary3.Add(previousOutsideColor.Key, previousColor3);
				}
			}
			_previousOutsideColors = dictionary3;
			foreach (FactoryObject createdObject in _createdObjects)
			{
				_terrainLayer.RemoveObjectAt(createdObject.Position);
			}
			foreach (FactoryObject deletedObject in _deletedObjects)
			{
				if (_terrainLayer.TryAddFactoryObject(deletedObject))
				{
					_createFactoryObjectEvent.Fire(new CreateFactoryObjectDto(_gridLocator.GetWorldPosition(deletedObject.Position), deletedObject.Rotation, deletedObject.Mirrored, deletedObject));
				}
			}
			List<FactoryObject> deletedObjects = _deletedObjects;
			List<FactoryObject> createdObjects = _createdObjects;
			_createdObjects = deletedObjects;
			_deletedObjects = createdObjects;
			return true;
		}
	}
}

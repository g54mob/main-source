using System.Collections.Generic;
using Data.FactoryFloor;
using NaughtyAttributes;
using Presentation.FactoryFloor;
using Presentation.Locators;
using UnityEngine;

namespace Logic.Factory
{
	[CreateAssetMenu(menuName = "Factory/Tools/FactoryValidateViews", fileName = "FactoryValidateViews", order = 0)]
	public class FactoryValidateViews : ScriptableObject
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryLayer _terrainLayer;

		[SerializeField]
		private GridLocator _gridLocator;

		[Button(null, EButtonEnableMode.Always)]
		public void DoValidate()
		{
			IEnumerable<FactoryObject> allDistinctObjectLists = _factoryLayer.GetAllDistinctObjectLists();
			IEnumerable<FactoryObject> allDistinctObjectLists2 = _terrainLayer.GetAllDistinctObjectLists();
			FactoryObjectView[] array = Object.FindObjectsByType<FactoryObjectView>(FindObjectsSortMode.None);
			List<FactoryObject> list = new List<FactoryObject>();
			FactoryObjectView[] array2 = array;
			foreach (FactoryObjectView factoryObjectView in array2)
			{
				if (factoryObjectView.FactoryObject == null)
				{
					LogWarning("The FactoryObjectView " + factoryObjectView.name + " has no FactoryObject", factoryObjectView);
					continue;
				}
				list.Add(factoryObjectView.FactoryObject);
				if (ValidateObjectExistsInLayers(factoryObjectView, allDistinctObjectLists, allDistinctObjectLists2) && ValidateWithViewManager(factoryObjectView))
				{
					ValidatePositions(factoryObjectView);
				}
			}
			ValidateObjectsInLayerHaveViews(allDistinctObjectLists, list);
			ValidateObjectsInLayerHaveViews(allDistinctObjectLists2, list);
		}

		private void ValidateObjectsInLayerHaveViews(IEnumerable<FactoryObject> allFactoryObjects, List<FactoryObject> viewFactoryObjects)
		{
			foreach (FactoryObject allFactoryObject in allFactoryObjects)
			{
				if (!viewFactoryObjects.Contains(allFactoryObject))
				{
					LogError(string.Format("The {0}(CreatedId: {1}) {2} is not in use by any {3}", "FactoryObject", allFactoryObject.CreatedId, allFactoryObject.FactoryObjectData.name, "FactoryObjectView"), allFactoryObject.FactoryObjectData);
				}
			}
		}

		private bool ValidateObjectExistsInLayers(FactoryObjectView objectView, IEnumerable<FactoryObject> factoryObjectsFound, IEnumerable<FactoryObject> objectsInTerrainLayer)
		{
			if (objectView.FactoryObject.FactoryLayer == _factoryLayer)
			{
				foreach (FactoryObject item in factoryObjectsFound)
				{
					if (item == objectView.FactoryObject)
					{
						return true;
					}
				}
			}
			else
			{
				if (!(objectView.FactoryObject.FactoryLayer == _terrainLayer))
				{
					LogError(string.Format("The {0} {1}'s {2}(CreatedId: {3}) is not on the factory or terrain layers", "FactoryObjectView", objectView.name, "FactoryObject", objectView.FactoryObject.CreatedId), objectView);
					return false;
				}
				foreach (FactoryObject item2 in objectsInTerrainLayer)
				{
					if (item2 == objectView.FactoryObject)
					{
						return true;
					}
				}
			}
			LogError(string.Format("The {0} {1}'s {2}(CreatedId: {3}) is was not found in it's factory layer {4}", "FactoryObjectView", objectView.name, "FactoryObject", objectView.FactoryObject.CreatedId, objectView.FactoryObject.FactoryLayer), objectView);
			return false;
		}

		private bool ValidatePositions(FactoryObjectView objectView)
		{
			if (_gridLocator.GetWorldPosition(objectView.FactoryObject.Position) != objectView.transform.position)
			{
				LogError(string.Format("The {0} {1} has a different position than it's {2}(CreatedId: {3})", "FactoryObjectView", objectView.name, "FactoryObject", objectView.FactoryObject.CreatedId) + $"\n{objectView.FactoryObject.Position} != {objectView.transform.position}", objectView);
				return false;
			}
			return true;
		}

		private bool ValidateWithViewManager(FactoryObjectView objectView)
		{
			int createdId = objectView.FactoryObject.CreatedId;
			if (!FactoryObjectViewManager.Instance.TryGetFactoryObjectView(createdId, out var view))
			{
				LogError(string.Format("The {0} {1} could not be found in the {2} for it's {3} CreatedId: {4}", "FactoryObjectView", objectView.name, "FactoryObjectViewManager", "FactoryObject", createdId), objectView);
				return false;
			}
			if (view != objectView)
			{
				LogError(string.Format("The {0} {1} is not the same as the {2} found in the {3} for it's {4} CreatedId: {5}", "FactoryObjectView", objectView.name, "FactoryObjectView", "FactoryObjectViewManager", "FactoryObject", createdId), objectView);
				return false;
			}
			return true;
		}

		[HideInCallstack]
		private void LogWarning(string message, Object context)
		{
			Debug.LogWarning("FactoryValidateViews: " + message, context);
		}

		[HideInCallstack]
		private void LogError(string message, Object context)
		{
			Debug.LogError("FactoryValidateViews: " + message, context);
		}
	}
}

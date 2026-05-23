using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using FMODUnity;
using Logic.Factory;
using Logic.Factory.Blueprint;
using UnityEngine;
using UnityEngine.Pool;

namespace Logic.FactoryTools
{
	[CreateAssetMenu(menuName = "Factory/Tools/CleanConveyorsTool", fileName = "CleanConveyorsTool", order = 0)]
	public class CleanConveyorsTool : SelectionFactoryTool
	{
		[SerializeField]
		private CurrentFactoryLayer _currentFactoryLayer;

		[SerializeField]
		private EventReference _clearConveyorsSFX;

		private readonly List<FactoryObject> _objectsToClear = new List<FactoryObject>();

		protected override void ImplementedSelectTool(Blueprint blueprint, bool singleObject = false)
		{
			GetConveyorsInBlueprint(blueprint);
			ClearConveyors();
			SelectTool(null);
		}

		private void GetConveyorsInBlueprint(Blueprint blueprint)
		{
			_objectsToClear.Clear();
			if (blueprint == null || blueprint.Elements == null)
			{
				return;
			}
			foreach (BlueprintElement element in blueprint.Elements)
			{
				Vector3Int position = element.RelativePositions[0] + blueprint.Position;
				FactoryObject objectAt = _currentFactoryLayer.Value.GetObjectAt(position);
				if (objectAt != null && objectAt.HasFactoryObjectBehaviour(out ResourceHolderBehaviour _))
				{
					_objectsToClear.Add(objectAt);
				}
			}
		}

		private void ClearConveyors()
		{
			CollectionPool<List<ResourceHolderBehaviour>, ResourceHolderBehaviour>.Get(out var value);
			foreach (FactoryObject item in _objectsToClear)
			{
				foreach (FactoryObjectBehaviour factoryObjectBehaviour in item.GetFactoryObjectBehaviours())
				{
					if (factoryObjectBehaviour is ResourceHolderBehaviour resourceHolderBehaviour)
					{
						resourceHolderBehaviour.StopTryingToOutput();
						resourceHolderBehaviour.ClearResources();
						value.Add(resourceHolderBehaviour);
					}
				}
			}
			foreach (ResourceHolderBehaviour item2 in value)
			{
				item2.CallCanReceiveNewResources();
			}
			CollectionPool<List<ResourceHolderBehaviour>, ResourceHolderBehaviour>.Release(value);
			_audioManagerLocator.AudioManager.PlayToolOneShot(_clearConveyorsSFX, _selection.Position);
		}

		protected override void ImplementedDoAction(Vector3Int position)
		{
		}

		protected override void ImplementedUpdateTool(Vector3Int position)
		{
		}

		protected override void ImplementedOnActionIntent(Vector3Int position)
		{
		}

		protected override void ImplementedCancelAction()
		{
		}
	}
}

using System;
using System.Collections.Generic;
using Data.FactoryFloor.Drones.Freighter.SaveStateDtos;
using Data.FactoryFloor.Freighter.Actions;
using Events.FactoryFloor;
using Events.Generic;
using UnityEngine;

namespace Data.FactoryFloor.Freighter
{
	[CreateAssetMenu(fileName = "FreighterPathBehaviour", menuName = "Factory/FactoryBehaviour/Freighter/PathBehaviour")]
	public class FreighterPathBehaviour : ScriptableObject
	{
		[SerializeField]
		private ReferenceObjectDatabase _referenceObjectDatabase;

		[SerializeField]
		private FreighterSlotActionsDatabase _freighterSlotActionsDatabase;

		[Header("Events")]
		[SerializeField]
		private FreighterEventSO _freighterCreatedEvent;

		[SerializeField]
		private IntEvent _freighterDestroyedEvent;

		private List<FreighterStopConfiguration> _stopConfigurations = new List<FreighterStopConfiguration>();

		private bool _hasPath;

		private FreighterObject _freighterObject;

		private int _currentStopIndex;

		private int _nextStopIndex;

		public IReadOnlyList<FreighterStopConfiguration> Stops => _stopConfigurations;

		public FreighterStopConfiguration CurrentStop => _stopConfigurations[GetCurrentStopIndex()];

		public FreighterStopConfiguration NextStop => _stopConfigurations[GetNextStopIndex()];

		public event Action OnPathChangedEvent = delegate
		{
		};

		public event Action OnFreighterCreatedEvent = delegate
		{
		};

		public void Initialize(FreighterObject freighterObject)
		{
			_freighterObject = freighterObject;
		}

		private void CreateFreighter()
		{
			_freighterCreatedEvent.Fire(_freighterObject);
			this.OnFreighterCreatedEvent();
		}

		private void DestroyFreighter()
		{
			_freighterDestroyedEvent.Fire(_freighterObject.CreatedId);
			_freighterObject.StopFreighter();
		}

		public void Dispose()
		{
			SetHasPath(hasPath: false);
		}

		public void SetStopConfigurations(List<FreighterStopConfiguration> freighterStops)
		{
			_freighterObject.Movement.RemoveFromAllFreightHubQueues();
			_stopConfigurations = freighterStops;
			_currentStopIndex = freighterStops.Count - 1;
			_nextStopIndex = 0;
			CreateOrDestroyFreighterDependingOnStops();
			if (_hasPath)
			{
				this.OnPathChangedEvent();
			}
		}

		public void ClearStopConfigurations()
		{
			_freighterObject.Movement.RemoveFromAllFreightHubQueues();
			_stopConfigurations.Clear();
			SetHasPath(hasPath: false);
		}

		public void IncrementStopIndex()
		{
			_currentStopIndex = GetNextStopIndex();
			_nextStopIndex = GetNextStopIndex();
			if (_currentStopIndex == -1 || _nextStopIndex == -1)
			{
				Dispose();
			}
		}

		public bool TryGetCurrentFactoryObject(out FactoryObject factoryObject)
		{
			int currentStopIndex = GetCurrentStopIndex();
			if (currentStopIndex == -1)
			{
				factoryObject = null;
				return false;
			}
			factoryObject = GetFactoryObjectAtStopIndex(currentStopIndex);
			return true;
		}

		public bool TryGetNextFactoryObject(out FactoryObject factoryObject)
		{
			factoryObject = null;
			int nextStopIndex = GetNextStopIndex();
			if (_stopConfigurations.Count > nextStopIndex && nextStopIndex >= 0)
			{
				FactoryObject factoryObjectAtStopIndex = GetFactoryObjectAtStopIndex(nextStopIndex);
				if (factoryObjectAtStopIndex != null)
				{
					factoryObject = factoryObjectAtStopIndex;
					return true;
				}
			}
			return false;
		}

		public FactoryObject GetCurrentFactoryObject()
		{
			return _referenceObjectDatabase.GetObjectFromReferenceID(CurrentStop.freightHubReferenceId).FactoryObject;
		}

		public FactoryObject GetNextFactoryObject()
		{
			return _referenceObjectDatabase.GetObjectFromReferenceID(NextStop.freightHubReferenceId).FactoryObject;
		}

		public FactoryObject GetFactoryObjectAtStopIndex(int index)
		{
			if (!HasStops())
			{
				return null;
			}
			int stopAtIndex = GetStopAtIndex(index);
			return _referenceObjectDatabase.GetObjectFromReferenceID(_stopConfigurations[stopAtIndex].freightHubReferenceId).FactoryObject;
		}

		public void CreateOrDestroyFreighterDependingOnStops()
		{
			SetHasPath(HasStops());
		}

		private void SetHasPath(bool hasPath)
		{
			if (hasPath != _hasPath)
			{
				_hasPath = hasPath;
				if (_hasPath)
				{
					CreateFreighter();
				}
				else
				{
					DestroyFreighter();
				}
			}
		}

		public bool HasStops()
		{
			int num = 0;
			for (int i = 0; i < _stopConfigurations.Count; i++)
			{
				int freightHubReferenceId = _stopConfigurations[i].freightHubReferenceId;
				if (_referenceObjectDatabase.ContainsReferenceID(freightHubReferenceId))
				{
					num++;
				}
			}
			return num >= 2;
		}

		public bool HasInvalidStop()
		{
			for (int i = 0; i < _stopConfigurations.Count; i++)
			{
				int freightHubReferenceId = _stopConfigurations[i].freightHubReferenceId;
				if (!_referenceObjectDatabase.ContainsReferenceID(freightHubReferenceId))
				{
					return true;
				}
			}
			return false;
		}

		private int GetCurrentStopIndex()
		{
			return GetStopAtIndex(_currentStopIndex);
		}

		private int GetNextStopIndex()
		{
			if (!HasStops())
			{
				return -1;
			}
			int currentStopIndex = GetCurrentStopIndex();
			int num = currentStopIndex + 1;
			if (num >= _stopConfigurations.Count)
			{
				num = 0;
			}
			while (!_referenceObjectDatabase.ContainsReferenceID(_stopConfigurations[num].freightHubReferenceId))
			{
				num++;
				if (num >= _stopConfigurations.Count)
				{
					num = 0;
				}
			}
			if (num == currentStopIndex)
			{
				return -1;
			}
			return num;
		}

		private int GetStopAtIndex(int index)
		{
			if (!HasStops())
			{
				return -1;
			}
			int num = index;
			while (!_referenceObjectDatabase.ContainsReferenceID(_stopConfigurations[num].freightHubReferenceId))
			{
				num++;
				if (num >= _stopConfigurations.Count)
				{
					num = 0;
				}
			}
			return num;
		}

		public FreighterPathBehaviourSaveStateDto GetSaveState()
		{
			List<FreighterStopConfigurationSaveStateDto> list = new List<FreighterStopConfigurationSaveStateDto>();
			foreach (FreighterStopConfiguration stopConfiguration in _stopConfigurations)
			{
				int[] array = new int[stopConfiguration.freighterDockSlotActions.Length];
				for (int i = 0; i < stopConfiguration.freighterDockSlotActions.Length; i++)
				{
					array[i] = stopConfiguration.freighterDockSlotActions[i].DatabaseIndex;
				}
				list.Add(new FreighterStopConfigurationSaveStateDto
				{
					FreightHubReferenceID = stopConfiguration.freightHubReferenceId,
					FreighterSlotActionDatabaseIDs = array
				});
			}
			return new FreighterPathBehaviourSaveStateDto
			{
				CurrentStopIndex = _currentStopIndex,
				NextStopIndex = _nextStopIndex,
				FreighterStopConfigurations = list
			};
		}

		public void ApplySaveState(FreighterPathBehaviourSaveStateDto saveStateDto)
		{
			if (saveStateDto == null)
			{
				return;
			}
			List<FreighterStopConfiguration> list = new List<FreighterStopConfiguration>();
			foreach (FreighterStopConfigurationSaveStateDto freighterStopConfiguration in saveStateDto.FreighterStopConfigurations)
			{
				FreighterSlotAction[] array = new FreighterSlotAction[freighterStopConfiguration.FreighterSlotActionDatabaseIDs.Length];
				for (int i = 0; i < freighterStopConfiguration.FreighterSlotActionDatabaseIDs.Length; i++)
				{
					array[i] = _freighterSlotActionsDatabase.Actions[freighterStopConfiguration.FreighterSlotActionDatabaseIDs[i]];
				}
				list.Add(new FreighterStopConfiguration
				{
					freightHubReferenceId = freighterStopConfiguration.FreightHubReferenceID,
					freighterDockSlotActions = array
				});
			}
			SetStopConfigurations(list);
			_currentStopIndex = saveStateDto.CurrentStopIndex;
			_nextStopIndex = saveStateDto.NextStopIndex;
		}
	}
}

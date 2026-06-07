using Data.FactoryFloor.Drones.Freighter.SaveStateDtos;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Freighter.Actions;
using Data.FactoryFloor.Resources;
using Logic.Threading.Events;
using UnityEngine;

namespace Data.FactoryFloor.Freighter
{
	[CreateAssetMenu(fileName = "FreighterSlotsBehaviour", menuName = "Factory/FactoryBehaviour/Freighter/SlotsBehaviour")]
	public class FreighterSlotsBehaviour : ScriptableObject, IFreighterObjectStateBehaviour
	{
		[SerializeField]
		private int _stepsPerSlot = 12;

		[SerializeField]
		private int _additionalWaitSteps = 24;

		[SerializeField]
		private int _stepsToRotate = 24;

		[SerializeField]
		private ResourceFactory _resourceFactory;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabaseSo;

		private FreighterObject _freighterObject;

		private FreightHubBehaviour _freightHubBehaviour;

		private FreighterPathBehaviour _path;

		private readonly FreightHubBehaviour.FreightHubSlot[] _storageSlots = new FreightHubBehaviour.FreightHubSlot[4];

		private int _stepsToNextAction;

		private int _slotIndex;

		private int _actionIndex;

		public MainThreadEvent<int, FreighterSlotAction, int> OnFreighterSlotAction = new MainThreadEvent<int, FreighterSlotAction, int>();

		public MainThreadEvent<int, FreighterSlotAction, FreightHubBehaviour.FreightHubSlot, FreightHubBehaviour.FreightHubSlot> OnFreighterSlotAnimation = new MainThreadEvent<int, FreighterSlotAction, FreightHubBehaviour.FreightHubSlot, FreightHubBehaviour.FreightHubSlot>();

		public MainThreadEvent<FreighterObject> OnSaveStateApplied = new MainThreadEvent<FreighterObject>();

		public FreightHubBehaviour.FreightHubSlot[] StorageSlots => _storageSlots;

		public void Initialize(FreighterObject freighterObject, FreighterPathBehaviour freighterPathBehaviour)
		{
			_freighterObject = freighterObject;
			_path = freighterPathBehaviour;
			_actionIndex = 0;
		}

		public void Dispose()
		{
			EmptySlots();
		}

		void IFreighterObjectStateBehaviour.Enter()
		{
			_stepsToNextAction = _stepsToRotate;
			_slotIndex = 0;
			_actionIndex = 0;
			if (_path.TryGetCurrentFactoryObject(out var factoryObject) && factoryObject.TryGetFactoryObjectBehaviour<FreightHubBehaviour>(out _freightHubBehaviour))
			{
				_freightHubBehaviour.StartOccupying(_freighterObject);
			}
		}

		void IFreighterObjectStateBehaviour.Exit()
		{
			if ((bool)_freightHubBehaviour)
			{
				_freightHubBehaviour.StopOccupying(_freighterObject);
				_freightHubBehaviour = null;
			}
		}

		bool IFreighterObjectStateBehaviour.Tick()
		{
			return _actionIndex switch
			{
				0 => WaitBeforeSlotActionsTick(), 
				1 => SlotActionsTick(), 
				2 => WaitAfterSlotActionsTick(), 
				_ => false, 
			};
		}

		private bool WaitBeforeSlotActionsTick()
		{
			_stepsToNextAction--;
			if (_stepsToNextAction <= 0)
			{
				_stepsToNextAction = _stepsPerSlot;
				_actionIndex = 1;
			}
			return false;
		}

		private bool SlotActionsTick()
		{
			_stepsToNextAction--;
			if (_stepsToNextAction <= 0)
			{
				ApplyActionToSlot(_slotIndex);
				_slotIndex++;
				if (_slotIndex >= _storageSlots.Length)
				{
					_actionIndex = 2;
					_stepsToNextAction = _additionalWaitSteps;
					return false;
				}
				_stepsToNextAction = _stepsPerSlot;
			}
			return false;
		}

		private bool WaitAfterSlotActionsTick()
		{
			_stepsToNextAction--;
			if (_stepsToNextAction <= 0)
			{
				return true;
			}
			return false;
		}

		private void ApplyActionToSlot(int slotIndex)
		{
			if ((bool)_freightHubBehaviour)
			{
				FreighterSlotAction freighterSlotAction = _path.CurrentStop.freighterDockSlotActions[slotIndex];
				int amount = _storageSlots[slotIndex].Amount;
				FreightHubBehaviour.FreightHubSlot copy = _storageSlots[slotIndex].GetCopy();
				lock (_freightHubBehaviour)
				{
					freighterSlotAction.Apply(_freightHubBehaviour, _slotIndex, ref _storageSlots[slotIndex]);
				}
				OnFreighterSlotAction.Fire(slotIndex, freighterSlotAction, amount);
				OnFreighterSlotAnimation.Fire(slotIndex, freighterSlotAction, copy, _storageSlots[slotIndex]);
			}
		}

		public void EmptySlots()
		{
			for (int i = 0; i < _storageSlots.Length; i++)
			{
				int amount = _storageSlots[i].Amount;
				_storageSlots[i] = default(FreightHubBehaviour.FreightHubSlot);
				OnFreighterSlotAction.Fire(i, null, amount);
			}
		}

		public FreighterSlotsBehaviourSaveStateDto GetSaveState()
		{
			return new FreighterSlotsBehaviourSaveStateDto
			{
				StepsToNextAction = _stepsToNextAction,
				SlotIndex = _slotIndex,
				ActionIndex = _actionIndex,
				FreighterHubSlotsSaveData = FreighterHubSlotSaveStateDto.FromFreighterHubSlots(_storageSlots)
			};
		}

		public void ApplySaveState(FreighterSlotsBehaviourSaveStateDto saveStateDto)
		{
			if (saveStateDto != null)
			{
				_stepsToNextAction = saveStateDto.StepsToNextAction;
				_slotIndex = saveStateDto.SlotIndex;
				_actionIndex = saveStateDto.ActionIndex;
				for (int i = 0; i < saveStateDto.FreighterHubSlotsSaveData.Length; i++)
				{
					Resource resource = saveStateDto.FreighterHubSlotsSaveData[i].ResourceDto.ToResource(_resourceFactory, _resourceDatabaseSo);
					_storageSlots[i].Resource = resource;
					_storageSlots[i].Amount = ((resource != null) ? saveStateDto.FreighterHubSlotsSaveData[i].Amount : 0);
				}
				OnSaveStateApplied.Fire(_freighterObject);
			}
		}
	}
}

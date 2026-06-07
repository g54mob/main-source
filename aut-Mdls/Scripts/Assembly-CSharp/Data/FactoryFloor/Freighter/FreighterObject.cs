using System;
using Data.FactoryFloor.Drones.Freighter.SaveStateDtos;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Events.FactoryFloor;
using Logic.Factory;
using Logic.Freighters;
using Logic.Threading.Events;
using UnityEngine;

namespace Data.FactoryFloor.Freighter
{
	public class FreighterObject
	{
		private readonly int _createdId;

		private readonly FactoryStepEvent _factoryStepEvent;

		private readonly FreighterSlotsBehaviour _slotsBehaviour;

		private readonly FreighterMovementBehaviour _movementBehaviour;

		private readonly FreighterPathBehaviour _pathBehaviour;

		private FreightersNameGenerator _freightersNameGenerator;

		private string _name;

		private Color _color;

		private bool _isPaused;

		private IFreighterObjectStateBehaviour _currentState;

		private float _lastStepTime;

		public MainThreadEvent<IFreighterObjectStateBehaviour> OnStateChanged = new MainThreadEvent<IFreighterObjectStateBehaviour>();

		public string Name => _name;

		public Color Color => _color;

		public int CreatedId => _createdId;

		public bool IsPaused => _isPaused;

		public FreighterSlotsBehaviour Slots => _slotsBehaviour;

		public FreighterMovementBehaviour Movement => _movementBehaviour;

		public FreighterPathBehaviour Path => _pathBehaviour;

		public IFreighterObjectStateBehaviour CurrentState => _currentState;

		public event Action OnNameChanged = delegate
		{
		};

		public FreighterObject(int createdId, FreighterObjectData data, FactoryStepEvent factoryStepEvent, FreightersNameGenerator freightersNameGenerator)
		{
		}

		public void Dispose()
		{
			_freightersNameGenerator.ReturnFreighterName(_name);
			_factoryStepEvent.UnRegisterInline(Process);
			_factoryStepEvent.UnRegisterMainThread(ProcessMainThread);
			_pathBehaviour.OnPathChangedEvent -= OnPathChanged;
			_slotsBehaviour.Dispose();
			UnityEngine.Object.Destroy(_slotsBehaviour);
			_movementBehaviour.Dispose();
			UnityEngine.Object.Destroy(_movementBehaviour);
			_pathBehaviour.Dispose();
			UnityEngine.Object.Destroy(_pathBehaviour);
		}

		private void Process(int step)
		{
			throw new NotIncludedInDemoException();
		}

		private void ProcessMainThread(int step)
		{
			_lastStepTime = Time.time;
		}

		private void OnPathChanged()
		{
			if (!_pathBehaviour.HasStops())
			{
				SetState(null);
			}
			else
			{
				SetState(_movementBehaviour);
			}
		}

		private void SetState(IFreighterObjectStateBehaviour stateBehaviour)
		{
			_currentState?.Exit();
			_currentState = stateBehaviour;
			_currentState?.Enter();
			OnStateChanged.Fire(stateBehaviour);
		}

		private void NextState()
		{
			if (!_pathBehaviour.HasStops())
			{
				_pathBehaviour.Dispose();
			}
			else if (_currentState is FreighterMovementBehaviour)
			{
				_pathBehaviour.IncrementStopIndex();
				SetState(_slotsBehaviour);
			}
			else
			{
				SetState(_movementBehaviour);
			}
		}

		public float GetDeltaTime01()
		{
			return (Time.time - _lastStepTime) / (float)FactoryUpdater.Instance.WaitTime;
		}

		public void SetPaused(bool paused)
		{
			_isPaused = paused;
		}

		public void StopFreighter()
		{
			_slotsBehaviour.EmptySlots();
			SetState(null);
		}

		public void SetNewName(string name, Color color)
		{
			_freightersNameGenerator.ReturnFreighterName(_name);
			_name = name;
			_color = color;
			this.OnNameChanged();
		}

		public void EmptySlots()
		{
			_slotsBehaviour.EmptySlots();
		}

		public void ClearConfiguration()
		{
			_pathBehaviour.ClearStopConfigurations();
		}

		public void ResolveFreightHubInPathInit(int referenceId)
		{
			if (_isPaused)
			{
				SetPaused(paused: false);
			}
			_pathBehaviour.CreateOrDestroyFreighterDependingOnStops();
			if (_currentState is FreighterMovementBehaviour && _movementBehaviour.PathEndReferenceID == referenceId && _pathBehaviour.HasStops())
			{
				SetState(_movementBehaviour);
			}
			if (_currentState == null && _pathBehaviour.HasStops())
			{
				SetState(_movementBehaviour);
			}
		}

		public void ResolveFreightHubInPathUnInit(int referenceId, bool isBeingMoved)
		{
			if (isBeingMoved)
			{
				SetPaused(paused: true);
				return;
			}
			if (_currentState is FreighterMovementBehaviour && _movementBehaviour.PathEndReferenceID == referenceId)
			{
				SetState(_movementBehaviour);
			}
			_pathBehaviour.CreateOrDestroyFreighterDependingOnStops();
		}

		public FreighterObjectSaveStateDto GetSaveState()
		{
			return null;
		}

		public void ApplySaveState(FreighterObjectSaveStateDto saveStateDto)
		{
			if (saveStateDto == null)
			{
				return;
			}
			_freightersNameGenerator.ReturnFreighterName(_name);
			_name = saveStateDto.Name;
			_color = saveStateDto.Color;
			_freightersNameGenerator.UseFreighterName(_name);
			_pathBehaviour.ApplySaveState(saveStateDto.PathBehaviourSaveStateDto);
			if (!_pathBehaviour.HasStops())
			{
				SetState(null);
			}
			else
			{
				IFreighterObjectStateBehaviour state;
				if (!saveStateDto.IsMoving)
				{
					IFreighterObjectStateBehaviour slotsBehaviour = _slotsBehaviour;
					state = slotsBehaviour;
				}
				else
				{
					IFreighterObjectStateBehaviour slotsBehaviour = _movementBehaviour;
					state = slotsBehaviour;
				}
				SetState(state);
			}
			_movementBehaviour.ApplySaveState(saveStateDto.MovementBehaviourSaveStateDto);
			_slotsBehaviour.ApplySaveState(saveStateDto.SlotsBehaviourSaveStateDto);
			SetPaused(saveStateDto.IsPaused);
		}
	}
}

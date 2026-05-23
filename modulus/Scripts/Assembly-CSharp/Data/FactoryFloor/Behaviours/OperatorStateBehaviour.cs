using FMODUnity;
using Logic.Threading.Events;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/OperatorStateBehaviour", fileName = "OperatorStateBehaviour", order = 0)]
	public class OperatorStateBehaviour : FactoryObjectBehaviour
	{
		public enum StateType
		{
			Error = 0,
			Warning = 1,
			Other = 2,
			None = 3
		}

		public struct State
		{
			public StateType StateType;

			public Sprite Icon;

			public EventReference SFX;

			public string LocalizationKey;

			public State(StateType stateType, Sprite icon, EventReference sfx, string localizationKey)
			{
				StateType = stateType;
				Icon = icon;
				SFX = sfx;
				LocalizationKey = localizationKey;
			}
		}

		private State _currentState = new State
		{
			StateType = StateType.None
		};

		[SerializeField]
		private Sprite _unknownIcon;

		[SerializeField]
		private Sprite _configurationIcon;

		[SerializeField]
		private Sprite _blockedIcon;

		[SerializeField]
		private Sprite _awaitingDronesIcon;

		[LocaKey]
		[SerializeField]
		private string _expectingDifferentModuleLocKey;

		[LocaKey]
		[SerializeField]
		private string _noConfigLocKey;

		[LocaKey]
		[SerializeField]
		private string _wrongInputTypeLocKey;

		[LocaKey]
		[SerializeField]
		private string _wrongInputTypeGeneralLocKey;

		[LocaKey]
		[SerializeField]
		private string _noDroneLinkedLocKey;

		[LocaKey]
		[SerializeField]
		private string _expectingPaintLocKey;

		[LocaKey]
		[SerializeField]
		private string _expectingBotsLocKey;

		[LocaKey]
		[SerializeField]
		private string _noRecipeSelectedLocKey;

		[LocaKey]
		[SerializeField]
		private string _operatorFullLocKey;

		[LocaKey]
		[SerializeField]
		private string _maxInputBoundsExceededLocKey;

		[LocaKey]
		[SerializeField]
		private string _needsCoolantLocKey;

		[LocaKey]
		[SerializeField]
		private string _harvesterPadFulLocKey;

		[LocaKey]
		[SerializeField]
		private string _linkedHarvesterPadFulLocKey;

		[LocaKey]
		[SerializeField]
		private string _droneTooSlowLocaKey;

		[LocaKey]
		[SerializeField]
		private string _demoDeliveriesCapLocaKey;

		[LocaKey]
		[SerializeField]
		private string _needsGreyMonumentLocaKey;

		[LocaKey]
		[SerializeField]
		private string _needsBlueMonumentLocaKey;

		[LocaKey]
		[SerializeField]
		private string _needsYellowMonumentLocaKey;

		[LocaKey]
		[SerializeField]
		private string _needsAllMonumentsLocaKey;

		[SerializeField]
		private EventReference _warningUrgentSFX;

		[SerializeField]
		private EventReference _warningNonUrgentSFX;

		private bool _updateStateOnInitialize;

		private bool _resetStateOnInitialize;

		public static MainThreadEvent<FactoryObject, State> OnStateSet = new MainThreadEvent<FactoryObject, State>();

		public static MainThreadEvent<FactoryObject> OnStateReset = new MainThreadEvent<FactoryObject>();

		public static MainThreadEvent<FactoryObject> OnStateHide = new MainThreadEvent<FactoryObject>();

		public static MainThreadEvent<FactoryObject> OnStateShow = new MainThreadEvent<FactoryObject>();

		public MainThreadEvent<State> OnStateChanged = new MainThreadEvent<State>();

		public State CurrentState => _currentState;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			if (_resetStateOnInitialize)
			{
				OnStateReset.Fire(factoryObject);
			}
			if (_updateStateOnInitialize)
			{
				OnStateSet.Fire(factoryObject, _currentState);
			}
		}

		public override void UnInit()
		{
			base.UnInit();
			_currentState = new State
			{
				StateType = StateType.None
			};
			_initialized = false;
			OnStateReset.Fire(_factoryObject);
		}

		public override void Update()
		{
		}

		private void SetState(State state)
		{
			if (_currentState.StateType != state.StateType || !(_currentState.LocalizationKey == state.LocalizationKey))
			{
				_currentState = state;
				if (_initialized)
				{
					OnStateSet.Fire(_factoryObject, state);
				}
				else
				{
					_updateStateOnInitialize = true;
				}
				OnStateChanged.Fire(state);
			}
		}

		public void ResetState()
		{
			_currentState = new State
			{
				StateType = StateType.None
			};
			if (_initialized)
			{
				OnStateReset.Fire(_factoryObject);
			}
			else
			{
				_resetStateOnInitialize = true;
			}
			_updateStateOnInitialize = false;
		}

		public void HideState()
		{
			OnStateHide.Fire(_factoryObject);
		}

		public void ShowState()
		{
			OnStateShow.Fire(_factoryObject);
		}

		public void SetStateNeedsConfiguration()
		{
			SetState(new State(StateType.Warning, _configurationIcon, _warningNonUrgentSFX, _noConfigLocKey));
		}

		public void SetStateExpectingDifferentModule()
		{
			SetState(new State(StateType.Error, _unknownIcon, _warningUrgentSFX, _expectingDifferentModuleLocKey));
		}

		public void SetStateWrongInputType()
		{
			SetState(new State(StateType.Error, _blockedIcon, _warningUrgentSFX, _wrongInputTypeLocKey));
		}

		public void SetStateWrongInputTypeGeneral()
		{
			SetState(new State(StateType.Error, _blockedIcon, _warningUrgentSFX, _wrongInputTypeGeneralLocKey));
		}

		public void SetStateNoDroneLinked()
		{
			SetState(new State(StateType.Warning, _awaitingDronesIcon, _warningNonUrgentSFX, _noDroneLinkedLocKey));
		}

		public void SetStateExpectingPaint()
		{
			SetState(new State(StateType.Error, _blockedIcon, _warningUrgentSFX, _expectingPaintLocKey));
		}

		public void SetStateExpectingBots()
		{
			SetState(new State(StateType.Error, _blockedIcon, _warningUrgentSFX, _expectingBotsLocKey));
		}

		public void SetStateNoRecipeSelected()
		{
			SetState(new State(StateType.Warning, _configurationIcon, _warningNonUrgentSFX, _noRecipeSelectedLocKey));
		}

		public void SetStateOperatorFull()
		{
			SetState(new State(StateType.Error, _blockedIcon, _warningUrgentSFX, _operatorFullLocKey));
		}

		public void SetStateInputMaxBoundsExceeded()
		{
			SetState(new State(StateType.Error, _blockedIcon, _warningUrgentSFX, _maxInputBoundsExceededLocKey));
		}

		public void SetStateNeedsCoolant()
		{
			SetState(new State(StateType.Error, _blockedIcon, _warningUrgentSFX, _needsCoolantLocKey));
		}

		public void SetStateHarvesterPadFull()
		{
			SetState(new State(StateType.Error, _blockedIcon, _warningUrgentSFX, _harvesterPadFulLocKey));
		}

		public void SetStateLinkedHarvesterPadFull()
		{
			SetState(new State(StateType.Error, _blockedIcon, _warningUrgentSFX, _linkedHarvesterPadFulLocKey));
		}

		public void SetStateDroneTooSlow()
		{
			SetState(new State(StateType.Error, _blockedIcon, _warningUrgentSFX, _droneTooSlowLocaKey));
		}

		public void SetStateDemoDeliveriesCap()
		{
			SetState(new State(StateType.Error, _blockedIcon, _warningUrgentSFX, _demoDeliveriesCapLocaKey));
		}

		public void SetStateNeedsGreyCharge()
		{
			SetState(new State(StateType.Error, _blockedIcon, _warningUrgentSFX, _needsGreyMonumentLocaKey));
		}

		public void SetStateNeedsBlueCharge()
		{
			SetState(new State(StateType.Error, _blockedIcon, _warningUrgentSFX, _needsBlueMonumentLocaKey));
		}

		public void SetStateNeedsYellowCharge()
		{
			SetState(new State(StateType.Error, _blockedIcon, _warningUrgentSFX, _needsYellowMonumentLocaKey));
		}

		public void SetStateNeedsAllMonumentsCharged()
		{
			SetState(new State(StateType.Error, _blockedIcon, _warningUrgentSFX, _needsAllMonumentsLocaKey));
		}
	}
}

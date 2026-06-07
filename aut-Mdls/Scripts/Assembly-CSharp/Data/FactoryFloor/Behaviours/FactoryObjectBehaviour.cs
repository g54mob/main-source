using System;
using Data.Variables;
using Logic.Threading.Events;
using NaughtyAttributes;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;

namespace Data.FactoryFloor.Behaviours
{
	public abstract class FactoryObjectBehaviour : ScriptableObject, ITrackActivity
	{
		[SerializeField]
		private bool _updateBehaviour = true;

		[SerializeField]
		[ShowIf(EConditionOperator.And, new string[] { "_updateBehaviour", "NoVariableUpdateFrequency" })]
		private int _updateFrequency = 8;

		[SerializeField]
		[ShowIf("_updateBehaviour")]
		private IntVariableSO _variableUpdateFrequency;

		protected FactoryObject _factoryObject;

		protected bool _initialized;

		private int _internalUpdateFrequency;

		public bool Initialized => _initialized;

		public FactoryObject FactoryObject => _factoryObject;

		public Vector3Int Position => _factoryObject.Position;

		public int UpdateFrequency => _internalUpdateFrequency;

		public IntVariableSO VariableUpdateFrequency => _variableUpdateFrequency;

		public bool IsUpdateBehaviour => _updateBehaviour;

		private bool HasVariableUpdateFrequency => _variableUpdateFrequency != null;

		private bool NoVariableUpdateFrequency => _variableUpdateFrequency == null;

		public MainThreadEvent OnActivityStart { get; private set; } = new MainThreadEvent();

		public MainThreadEvent OnActivityEnd { get; private set; } = new MainThreadEvent();

		public event Action<FactoryObjectBehaviour> OnUnInit = delegate
		{
		};

		public virtual void Init(FactoryObject factoryObject)
		{
			_factoryObject = factoryObject;
			_initialized = true;
			if (HasVariableUpdateFrequency)
			{
				SetUpdateFrequency(_variableUpdateFrequency.Value);
				_variableUpdateFrequency.ValueChanged += SetUpdateFrequency;
			}
			else
			{
				SetUpdateFrequency(_updateFrequency);
			}
		}

		public virtual void UnInit()
		{
			if (HasVariableUpdateFrequency)
			{
				_variableUpdateFrequency.ValueChanged -= SetUpdateFrequency;
			}
			_initialized = false;
			this.OnUnInit(this);
			this.OnUnInit = delegate
			{
			};
		}

		private void SetUpdateFrequency(int updateFrequency)
		{
			_internalUpdateFrequency = updateFrequency;
		}

		public virtual void Process(int step)
		{
			if (_updateBehaviour && step % UpdateFrequency == 0)
			{
				Update();
			}
		}

		public abstract void Update();

		public virtual BehaviourSaveStateDto GetSaveState()
		{
			return null;
		}

		public virtual BehaviourConfigurationDto GetConfiguration()
		{
			return null;
		}

		public virtual void ApplyConfigurationDto(BehaviourConfigurationDto configDto)
		{
		}

		public void StartActivity()
		{
			OnActivityStart.Fire();
		}

		public void EndActivity()
		{
			OnActivityEnd.Fire();
		}
	}
}

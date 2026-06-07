using System;
using System.Collections.Generic;
using Data.FactoryFloor.Freighter;
using Data.FactoryFloor.Freighter.Actions;
using Data.FactoryFloor.Resources;
using Data.Variables;
using FMOD.Studio;
using FMODUnity;
using Presentation.FactoryFloor.FactoryObjectViews.OperatorViews.FreightHub;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class FreighterView : MonoBehaviour
	{
		private FreighterObject _freighter;

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private IntVariableSO _factoryStepsPerSecond;

		[SerializeField]
		private IntVariableSO _globalUpdateMultiplier;

		[SerializeField]
		private Transform _rotationPivot;

		[SerializeField]
		private List<FreightCrateView> _freightCrateViews;

		[SerializeField]
		private FreighterAnimationEvents _freighterAnimationEvents;

		[Header("Audio")]
		[SerializeField]
		protected AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private EventReference _loopSFX;

		[Header("Rotation")]
		[SerializeField]
		private float _rotationDuration = 5f;

		[SerializeField]
		private float _tiltAmount = 15f;

		[SerializeField]
		private float _tiltSpeed = 10f;

		private Color _color;

		private EventInstance _loopingSFXInstance;

		private EventInstance _loopSFXInstance;

		private Dictionary<Type, IFreighterBehaviourView> _freighterBehaviourViews = new Dictionary<Type, IFreighterBehaviourView>
		{
			{
				typeof(FreighterMovementBehaviour),
				new FreighterMovementBehaviourView()
			},
			{
				typeof(FreighterSlotsBehaviour),
				new FreighterSlotsBehaviourView()
			}
		};

		private IFreighterBehaviourView _currentStateView;

		public Animator Animator => _animator;

		public Transform RotationPivot => _rotationPivot;

		public AudioManagerLocator AudioManagerLocator => _audioManagerLocator;

		public EventInstance LoopSFXInstance => _loopSFXInstance;

		public float RotationDuration => _rotationDuration;

		public float TiltAmount => _tiltAmount;

		public float TiltSpeed => _tiltSpeed;

		public Color Color => _color;

		public event Action<Color> OnFreighterColorChanged = delegate
		{
		};

		public void AssignFreighter(FreighterObject freighterObject)
		{
			_freighter = freighterObject;
			_freighter.OnNameChanged += FreighterNameChanged;
			_freighterAnimationEvents.OnUpdateCrateResource += OnUpdateCrateResource;
			_freighter.Slots.OnSaveStateApplied.RegisterMainThread(OnSlotsSaveStateApplied);
			_freighter.OnStateChanged.RegisterMainThread(OnFreighterStateChanged);
			_freighter.Slots.OnFreighterSlotAction.RegisterMainThread(OnEmptyInventory);
			OnFreighterStateChanged(_freighter.CurrentState);
			FreighterNameChanged();
		}

		public void UnAssignFreighter()
		{
			_freighter.OnNameChanged -= FreighterNameChanged;
			_freighterAnimationEvents.OnUpdateCrateResource -= OnUpdateCrateResource;
			_freighter.Slots.OnSaveStateApplied.UnRegisterMainThread(OnSlotsSaveStateApplied);
			_freighter.OnStateChanged.UnRegisterMainThread(OnFreighterStateChanged);
			_freighter.Slots.OnFreighterSlotAction.UnRegisterMainThread(OnEmptyInventory);
			_freighter = null;
			for (int i = 0; i < 4; i++)
			{
				Animator.ResetTrigger(FreighterSlotsBehaviourView.DropCrateAnimatorTriggers[i]);
				Animator.ResetTrigger(FreighterSlotsBehaviourView.RetrieveCrateAnimatorTriggers[i]);
				Animator.ResetTrigger(FreighterSlotsBehaviourView.DropAndRetrieveCrateAnimatorTriggers[i]);
				_freightCrateViews[i].gameObject.SetActive(value: false);
			}
		}

		private void OnSlotsSaveStateApplied(FreighterObject freighterObject)
		{
			((FreighterSlotsBehaviourView)_freighterBehaviourViews[typeof(FreighterSlotsBehaviour)]).SetInitialState(freighterObject, this);
		}

		private void FreighterNameChanged()
		{
			_color = _freighter.Color;
			this.OnFreighterColorChanged(_color);
		}

		private void OnEmptyInventory(int slotIndex, FreighterSlotAction action, int _)
		{
			if (!(action != null))
			{
				Animator.SetTrigger(FreighterSlotsBehaviourView.DropCrateAnimatorTriggers[slotIndex]);
			}
		}

		private void OnUpdateCrateResource(int index)
		{
			SetCrateResource(index, _freighter.Slots.StorageSlots[index].Resource);
		}

		private void OnFreighterStateChanged(IFreighterObjectStateBehaviour state)
		{
			_currentStateView?.Exit();
			if (state == null)
			{
				_currentStateView = null;
				return;
			}
			IFreighterBehaviourView value;
			bool flag = _freighterBehaviourViews.TryGetValue(state.GetType(), out value);
			_currentStateView = (flag ? value : null);
			_currentStateView?.Enter(state, _freighter, this);
		}

		private void Start()
		{
			_loopSFXInstance = _audioManagerLocator.AudioManager.PlayFreighterFlyingWithSpeed(_loopSFX, base.gameObject, 0f);
		}

		private void OnDestroy()
		{
			if (_freighter != null)
			{
				UnAssignFreighter();
			}
			_audioManagerLocator.AudioManager.StopPlayFreighterFly(ref _loopSFXInstance);
		}

		private void Update()
		{
			_currentStateView?.Update();
		}

		private void OnDropResources()
		{
			_audioManagerLocator.AudioManager.PlayDroneDropOff(base.transform.position);
		}

		public void SetCrateResource(int index, Resource resource)
		{
			_freightCrateViews[index].SetResource(resource);
		}

		public void SetCrateActive(int index, bool active)
		{
			_freightCrateViews[index].gameObject.SetActive(active);
		}
	}
}

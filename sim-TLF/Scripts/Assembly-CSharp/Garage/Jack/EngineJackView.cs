using System;
using AssembleSystem.FSM.PlacedObject;
using Garage.Jack.InteractionZones;
using Items;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Observables;
using Loxodon.Framework.Views;
using MyBox;
using UnityEngine;
using Zenject;

namespace Garage.Jack
{
	public class EngineJackView : View, IGrabable
	{
		private ObservableProperty<float> _jackLeanProgress = new ObservableProperty<float>();

		private ObservableProperty<bool> _canInteract = new ObservableProperty<bool>();

		[SerializeField]
		private JackEngineRecoverZone _recoverZone;

		[SerializeField]
		private ConfigurableJoint _joint;

		[SerializeField]
		private GameObject _chain;

		[SerializeField]
		private Rigidbody _rb;

		[SerializeField]
		private Animation anim;

		[SerializeField]
		private string clipName;

		[SerializeField]
		private Transform _hangParent;

		[SerializeField]
		private GameObject _testGameObject;

		[SerializeField]
		[ReadOnly(new string[] { })]
		private GameObject _jackedObject;

		private Vector3 _hangParentOriginalPos;

		private bool _hasObject;

		[Inject]
		private DiContainer _container;

		Rigidbody IGrabable.Rigidbody => _rb;

		public JackEngineRecoverZone RecoverZone => _recoverZone;

		public GameObject JackedObject => _jackedObject;

		private void Awake()
		{
			if (anim == null)
			{
				anim = GetComponent<Animation>();
			}
			anim[clipName].speed = 0f;
			anim.Play(clipName);
			_hangParentOriginalPos = _hangParent.position;
			_jackLeanProgress.ValueChanged += JackValueChanged;
			_canInteract.ValueChanged += CanInteractValueChanged;
		}

		private void CanInteractValueChanged(object sender, EventArgs e)
		{
			Debug.Log($"Can Interact {_canInteract.Value}");
		}

		private void JackValueChanged(object sender, EventArgs e)
		{
			SetAnimation(Mathf.Clamp01(_jackLeanProgress.Value));
		}

		public void SetAnimation(float normalizedTime)
		{
			if ((bool)anim && !string.IsNullOrEmpty(clipName))
			{
				AnimationState animationState = anim[clipName];
				animationState.speed = 0f;
				animationState.normalizedTime = Mathf.Clamp01(normalizedTime);
				anim.Sample();
			}
		}

		private void Start()
		{
			BindingSet<EngineJackView, EngineJackViewModel> bindingSet = this.CreateBindingSet<EngineJackView, EngineJackViewModel>();
			EngineJackViewModel engineJackViewModel = new EngineJackViewModel();
			_container.Inject(engineJackViewModel);
			this.SetDataContext(engineJackViewModel);
			bindingSet.Bind(this).For((EngineJackView v) => v._jackLeanProgress).To((EngineJackViewModel vm) => vm.JackLeanProgress)
				.OneWay();
			bindingSet.Bind().For((EngineJackView v) => v.ToggleJack).To((EngineJackViewModel vm) => vm.ToggleJackRequest);
			bindingSet.Build();
			Debug.Log("Engine in Zone" + _recoverZone.EngineInZone);
			Debug.Log("Jacked Object Is Null" + _jackedObject == null);
			engineJackViewModel.JackLeanProgress.Value = 0.5f;
		}

		private void Release(object sender, InteractionEventArgs args)
		{
			_joint.connectedBody = null;
			_jackedObject.GetComponent<PlacedObjectStateMachine>().Placed = false;
			ClearJackedObject();
		}

		private void Pickup(object sender, InteractionEventArgs args)
		{
			if (_hangParent.transform.childCount != 0 && !(_hangParent.GetChild(0).gameObject == null))
			{
				SetJackedObject(_hangParent.GetChild(0).gameObject);
				_hangParent.position = _recoverZone.transform.position;
				_joint.connectedBody = _hangParent.GetComponent<Rigidbody>();
				_jackedObject.GetComponent<PlacedObjectStateMachine>().Placed = true;
			}
		}

		private void ToggleJack(object sender, InteractionEventArgs args)
		{
			if (_jackedObject == null)
			{
				Pickup(sender, args);
			}
			else
			{
				Release(sender, args);
			}
		}

		void IGrabable.Grab()
		{
			Debug.Log("Jack Grabbed");
		}

		void IGrabable.Ungrab()
		{
			Debug.Log("Jack Ungrabbed");
		}

		public void SetJackedObject(GameObject go)
		{
			Debug.Log("SettingJackedObject");
			_jackedObject = go;
		}

		public void ClearJackedObject()
		{
			_jackedObject = null;
		}
	}
}

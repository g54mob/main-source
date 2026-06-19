using System.Collections.Generic;
using System.Linq;
using AssembleSystem.FSM.Parts;
using AssembleSystem.FSM.PlacedObject;
using AssembleSystem.FSM.Plane.States;
using Loxodon.Framework.Contexts;
using Services.Save.Assemble;
using Services.Save.Plane;
using UI.HUD;
using UnityEngine;
using UnityHFSM;
using Vehicles;
using Vehicles.Plane;
using Zenject;

namespace AssembleSystem.FSM.Plane
{
	public class PlaneStateMachine : MonoBehaviour
	{
		public bool MotorPlaced;

		public bool MotorTightened;

		[SerializeField]
		private EngineSocket _engineSocket;

		[SerializeField]
		private List<PartObjectStateMachine> _mountParts;

		[SerializeField]
		private EngineMountChecker _mountChecker;

		[SerializeField]
		private Transform _engineMountPoint;

		[SerializeField]
		private PlacedObjectStateMachine _planeAssemblingStateMachine;

		[SerializeField]
		private AssembleObjectParent _planeAssembleParent;

		private StateMachine<StateIdentifier> fsm;

		[Inject]
		private PlaneSaveRegistry _planeSaveRegistry;

		private InfoCursorsViewModel _infoCursorViewModel;

		public StateMachine<StateIdentifier> Fsm => fsm;

		private void Awake()
		{
			CreateNewStateMachine();
			PopulateStates();
			InitStateMachine();
		}

		private void Start()
		{
			_infoCursorViewModel = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<InfoCursorsViewModel>();
		}

		private void Update()
		{
			fsm.OnLogic();
		}

		private void InitStateMachine()
		{
			fsm.Init();
		}

		private void CreateNewStateMachine()
		{
			fsm = new StateMachine<StateIdentifier>();
		}

		private void PopulateStates()
		{
			PlaneWithoutMotorState state = new PlaneWithoutMotorState(this);
			StateIdentifier stateIdentifier = new StateIdentifier("withoutMotor");
			PlaneMotorPlacedState state2 = new PlaneMotorPlacedState(this);
			StateIdentifier stateIdentifier2 = new StateIdentifier("motorPlaced");
			PlaneMotorTightenedState state3 = new PlaneMotorTightenedState(this);
			StateIdentifier to = new StateIdentifier("motorTightened");
			Transition<StateIdentifier> transition = new Transition<StateIdentifier>(stateIdentifier, stateIdentifier2, (Transition<StateIdentifier> transit) => _mountChecker.CanMount() || MotorPlaced, OnMotorPlaced);
			Transition<StateIdentifier> transition2 = new Transition<StateIdentifier>(stateIdentifier2, to, (Transition<StateIdentifier> transit) => MountPartsPlaced() || MotorTightened, OnMotorTightened);
			fsm.AddTwoWayTransition(transition);
			fsm.AddTwoWayTransition(transition2);
			fsm.AddState(stateIdentifier, state);
			fsm.AddState(stateIdentifier2, state2);
			fsm.AddState(to, state3);
			fsm.SetStartState(stateIdentifier);
		}

		private void OnMotorPlaced(Transition<StateIdentifier> transition)
		{
			bool canMount = _mountChecker.CanMount();
			_infoCursorViewModel.TickEnabled = false;
			if (_mountChecker.EngineParent == null)
			{
				Object.FindObjectsByType<SceneAssembleSaveHandler>(FindObjectsSortMode.None).FirstOrDefault((SceneAssembleSaveHandler x) => x.SaveKey.Contains("Engine"));
			}
			else
			{
				_mountChecker.EngineParent.transform.SetParent(null);
			}
			Object.FindObjectsByType<SceneAssembleSaveHandler>(FindObjectsSortMode.None).FirstOrDefault((SceneAssembleSaveHandler x) => x.SaveKey.Contains("Engine")).GetComponent<PlacedObjectStateMachine>();
			_mountParts.ForEach(delegate(PartObjectStateMachine x)
			{
				x.gameObject.SetActive(canMount);
			});
		}

		private void OnMotorTightened(Transition<StateIdentifier> transition)
		{
			Transform transform = null;
			PlaneEngine planeEngine = Object.FindFirstObjectByType<PlaneEngine>();
			transform = ((!(_mountChecker.EngineParent == null)) ? _mountChecker.EngineParent.transform : planeEngine.transform);
			_engineSocket.SetEngine(planeEngine);
			transform.SetParent(base.transform);
			transform.localPosition = _engineMountPoint.localPosition;
			transform.localRotation = Quaternion.identity;
			_planeAssembleParent.enabled = true;
			_planeAssemblingStateMachine.enabled = true;
			_planeAssemblingStateMachine.Placed = true;
			PlacedObjectStateMachine component = transform.GetComponent<PlacedObjectStateMachine>();
			component.Placed = true;
			component.PlacedParent = base.transform;
			component.PlacedPosition = _engineMountPoint.localPosition;
			component.PlacedRotation = Quaternion.identity;
			_mountParts.ForEach(delegate(PartObjectStateMachine x)
			{
				x.gameObject.SetActive(value: false);
			});
		}

		private bool MountPartsPlaced()
		{
			return _mountParts.TrueForAll((PartObjectStateMachine x) => x.Tightened);
		}
	}
}

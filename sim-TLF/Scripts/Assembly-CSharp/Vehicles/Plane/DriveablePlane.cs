using AssembleSystem.FSM.Plane;
using Player;
using Player.FSM;
using StarterAssets;
using UnityEngine;
using Vehicles.InteractionZones;
using Zenject;

namespace Vehicles.Plane
{
	public class DriveablePlane : DrivableVehicle
	{
		[SerializeField]
		private AirplaneController _planeController;

		[SerializeField]
		private AircraftPhysics _planePhysics;

		[SerializeField]
		private PlaneStateMachine _planeStateMachine;

		[SerializeField]
		private GameObject _fuselageCover;

		[SerializeField]
		private EnterVehicleInteractionZone _enterZone;

		[Tooltip("Layers the player may still describe/outline while piloting. Everything else — including the plane's own parts — is ignored. Set to Nothing to suppress all world-describe UI while flying.")]
		[SerializeField]
		private LayerMask _describeLayersWhilePiloting;

		[Inject]
		protected IPlayerInputService _inputService;

		[Inject]
		protected IPlayerStateMachineParametersManipulator _playerFSM;

		private FirstPersonController _fpc;

		private IDescriberRayMask _describerRayMask;

		private bool _isPiloting;

		private FirstPersonController GetFPC()
		{
			if (!(_fpc != null))
			{
				return _fpc = (_playerFSM as MonoBehaviour).transform.parent.GetComponent<FirstPersonController>();
			}
			return _fpc;
		}

		private IDescriberRayMask GetDescriberRayMask()
		{
			return _describerRayMask ?? (_describerRayMask = (_playerFSM as MonoBehaviour).transform.parent.GetComponentInChildren<IDescriberRayMask>());
		}

		public override void EnterVehicle()
		{
			_inputService.DisableMoveAction();
			_inputService.DisableCrouchAction();
			_inputService.DisableJumpAction();
			GetFPC().IsInVehicle = true;
			Debug.Log(_planeStateMachine.Fsm.ActiveStateName);
			_planeController.enabled = true;
			_planePhysics.enabled = true;
			_fuselageCover.SetActive(value: false);
			_enterZone.gameObject.SetActive(value: false);
			GetDescriberRayMask()?.RestrictToLayers(_describeLayersWhilePiloting);
			_isPiloting = true;
		}

		public override void ExitVehicle()
		{
			_inputService.EnableMoveAction();
			_inputService.EnableCrouchAction();
			_inputService.EnableJumpAction();
			GetFPC().IsInVehicle = false;
			_planeController.enabled = false;
			_fuselageCover.SetActive(value: true);
			_enterZone.gameObject.SetActive(value: true);
			GetDescriberRayMask()?.ClearRestriction();
			_isPiloting = false;
		}

		private void OnDisable()
		{
			if (_isPiloting)
			{
				GetDescriberRayMask()?.ClearRestriction();
				_isPiloting = false;
			}
		}
	}
}

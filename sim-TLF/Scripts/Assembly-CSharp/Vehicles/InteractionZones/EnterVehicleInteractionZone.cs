using Loxodon.Framework.Contexts;
using Player;
using StarterAssets;
using UI.HUD;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Vehicles.InteractionZones
{
	[RequireComponent(typeof(Collider))]
	public class EnterVehicleInteractionZone : MonoBehaviour
	{
		[SerializeField]
		private DrivableVehicle _vehicle;

		private IVehicleDriver _currentDriver;

		private InfoCursorsViewModel _infoCursorViewModel;

		[Inject]
		protected IPlayerInputService _inputService;

		private void Start()
		{
			_infoCursorViewModel = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<InfoCursorsViewModel>();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent<IVehicleDriver>(out var component))
			{
				_currentDriver = component;
				_infoCursorViewModel.EnableVehicleEnter(value: true);
				_inputService.OnPlayerMount -= EnterVehicle;
				_inputService.OnPlayerMount += EnterVehicle;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.TryGetComponent<IVehicleDriver>(out var _))
			{
				_infoCursorViewModel.EnableVehicleEnter(value: false);
				_inputService.OnPlayerMount -= EnterVehicle;
				_currentDriver = null;
			}
		}

		private void OnDisable()
		{
			_infoCursorViewModel.EnableVehicleEnter(value: false);
			_inputService.OnPlayerMount -= EnterVehicle;
		}

		private void EnterVehicle(InputAction.CallbackContext context)
		{
			if (!context.performed || _currentDriver == null)
			{
				return;
			}
			PlayerBehaviour player = _currentDriver.Player;
			if (player == null)
			{
				return;
			}
			float num = float.PositiveInfinity;
			VehiclePlace vehiclePlace = null;
			VehiclePlace[] places = _vehicle.Places;
			foreach (VehiclePlace vehiclePlace2 in places)
			{
				float num2 = Vector3.Distance(player.transform.position, vehiclePlace2.PlaceTransform.position);
				if (num2 < num)
				{
					num = num2;
					vehiclePlace = vehiclePlace2;
				}
			}
			if (!(vehiclePlace == null))
			{
				IVehicleDriver currentDriver = _currentDriver;
				_inputService.OnPlayerMount -= EnterVehicle;
				_infoCursorViewModel.EnableVehicleEnter(value: false);
				_currentDriver = null;
				currentDriver.GetOnVehicle(_vehicle);
				FirstPersonController componentInParent = player.GetComponentInParent<FirstPersonController>();
				componentInParent?.ForceUncrouch();
				Transform placeTransform = vehiclePlace.PlaceTransform;
				float y = player.CharacterController.center.y;
				player.transform.SetPositionAndRotation(placeTransform.position - placeTransform.up * y, placeTransform.rotation);
				componentInParent?.ResetLookPitch();
				currentDriver.IsDriving = vehiclePlace.IsDriverPlace;
			}
		}
	}
}

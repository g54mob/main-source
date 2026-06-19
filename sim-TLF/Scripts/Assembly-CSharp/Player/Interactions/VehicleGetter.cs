using Player.FSM;
using UnityEngine;
using UnityEngine.InputSystem;
using Vehicles;
using Zenject;

namespace Player.Interactions
{
	public class VehicleGetter : MonoBehaviour, IVehicleDriver
	{
		[Header("Links")]
		[SerializeField]
		private PlayerBehaviour _player;

		[SerializeField]
		private PlayerItemDropper _playerItemDropper;

		[SerializeField]
		private float _exitYOffset = 4f;

		private DrivableVehicle _currentVehicle;

		private bool _isDriving;

		[Inject]
		protected IPlayerInputService _inputService;

		[Inject]
		protected IPlayerStateMachineParametersManipulator _playerFSM;

		PlayerBehaviour IVehicleDriver.Player => _player;

		bool IVehicleDriver.IsDriving
		{
			get
			{
				return _isDriving;
			}
			set
			{
				_isDriving = value;
			}
		}

		void IVehicleDriver.GetOfTheVehicle(DrivableVehicle vehicle)
		{
			Debug.Log("Enabling player controll");
			_player.transform.position += Vector3.up * _exitYOffset;
			_player.DisableControllerAndCollision(value: true);
			_inputService.EnablePushAction();
			vehicle.ExitVehicle();
			_currentVehicle = null;
			_player.transform.SetParent(null);
			_playerItemDropper.enabled = true;
			Vector3 eulerAngles = _player.transform.rotation.eulerAngles;
			eulerAngles.z = 0f;
			eulerAngles.x = 0f;
			_player.transform.rotation = Quaternion.Euler(eulerAngles);
		}

		void IVehicleDriver.GetOnVehicle(DrivableVehicle vehicle)
		{
			Debug.Log("Disabling player controll");
			_player.DisableControllerAndCollision(value: false);
			_playerItemDropper.enabled = false;
			vehicle.EnterVehicle();
			_inputService.OnPlayerMount += TryLeaveVehicle;
			_inputService.DisablePushAction();
			_playerFSM.SetPushing(pushing: false);
			_currentVehicle = vehicle;
			_player.transform.SetParent(vehicle.transform);
		}

		private void TryLeaveVehicle(InputAction.CallbackContext context)
		{
			if (context.performed)
			{
				Debug.Log("Leaving Vehicle");
				_inputService.OnPlayerMount -= TryLeaveVehicle;
				((IVehicleDriver)this).GetOfTheVehicle(_currentVehicle);
			}
		}
	}
}

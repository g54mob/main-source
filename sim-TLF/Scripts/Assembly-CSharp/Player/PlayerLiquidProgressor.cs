using Items;
using Player.FSM;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
	public class PlayerLiquidProgressor : MonoBehaviour
	{
		public enum FlowDirection
		{
			ToPlayer = 0,
			FromPlayer = 1
		}

		[SerializeField]
		private RaycasterInfo _playerRaycastInfo;

		private IProgressable _currentProgressable;

		private FlowDirection _currentFlowDirection = FlowDirection.FromPlayer;

		[Inject]
		private IPlayerInputService _inputService;

		[Inject]
		private IPlayerEquipService _equipToolService;

		private void OnEnable()
		{
			_inputService.OnRotate += TryChangeDirection;
			_inputService.OnInteract += TryProgressAssembleObject;
		}

		private void OnDisable()
		{
			_inputService.OnRotate -= TryChangeDirection;
			_inputService.OnInteract -= TryProgressAssembleObject;
		}

		private void TryChangeDirection(float value)
		{
			if (value > 0f)
			{
				_currentFlowDirection = FlowDirection.ToPlayer;
			}
			else if (value < 0f)
			{
				_currentFlowDirection = FlowDirection.FromPlayer;
			}
		}

		private void TryProgressAssembleObject(InputAction.CallbackContext context)
		{
			if (!(_playerRaycastInfo.Hit.transform != null) || !_playerRaycastInfo.Hit.transform.TryGetComponent<IProgressable>(out var component))
			{
				return;
			}
			LiquidCan liquidCan = null;
			if (_equipToolService.GetEquipableAt(EquipSide.RIGHT_HAND) == null)
			{
				return;
			}
			liquidCan = _equipToolService.GetEquipableAt(EquipSide.RIGHT_HAND) as LiquidCan;
			if (!(liquidCan == null) && liquidCan.ToolObject.ToolType == component.ProgressTool)
			{
				if (liquidCan.ToolObject.ToolUseType != ToolObject.UseType.Hold)
				{
					_ = 1;
				}
				else if (context.started)
				{
					_currentProgressable = component;
				}
				else if (context.canceled)
				{
					_currentProgressable = null;
				}
			}
		}

		private void Update()
		{
			if (_currentProgressable == null)
			{
				return;
			}
			LiquidCan liquidCan = _equipToolService.EquippedItems[EquipSide.RIGHT_HAND] as LiquidCan;
			if (!(liquidCan.LiquidAmount <= 0f))
			{
				float num = liquidCan.ToolObject.Power;
				if (_currentFlowDirection == FlowDirection.FromPlayer)
				{
					num = Mathf.Abs(num);
				}
				else if (_currentFlowDirection == FlowDirection.ToPlayer)
				{
					num = 0f - Mathf.Abs(num);
				}
				liquidCan.ChangeLiquidAmount((0f - num) * Time.deltaTime);
				if (liquidCan != null)
				{
					_currentProgressable.AddProgress(num);
				}
			}
		}
	}
}

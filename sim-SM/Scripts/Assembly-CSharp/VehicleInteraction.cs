using System;
using PG;
using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleInteraction : Interaction
{
	public CarController CarControler;

	private PlayerInstance m_PlayerInstance;

	public Action<float> onGas;

	public Action<float> onBrake;

	public Action<bool> onHandBrake;

	public Action<float> onSteering;

	public Action onExitVehicle;

	public Action<Vector2> onLookAround;

	public Action onResetVehicle;

	public Action onOpenMap;

	public Action<bool> onRefuel;

	public Action<PlayerInstance> onForceExit;

	public override IInteractable Interactable
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public override bool Enable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private PlayerInstance PlayerInstance => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Awake()
	{
	}

	public void OnEnterVehicle(CarController _Vehicle)
	{
	}

	public void OnExitVehicle()
	{
	}

	private void OnSell(bool down)
	{
	}

	public void EnterVehicleMode()
	{
	}

	public void Refuel(InputAction.CallbackContext context)
	{
	}

	public void Gas(InputAction.CallbackContext context)
	{
	}

	public void Brake(InputAction.CallbackContext context)
	{
	}

	public void HandBrake(InputAction.CallbackContext context)
	{
	}

	public void Steer(InputAction.CallbackContext context)
	{
	}

	public void LookAround(InputAction.CallbackContext context)
	{
	}

	public void ExitVehicle(InputAction.CallbackContext context)
	{
	}

	public void ForceExitVehicle()
	{
	}

	public void ResetVehicle(InputAction.CallbackContext context)
	{
	}

	public void OpenMap(InputAction.CallbackContext context)
	{
	}
}

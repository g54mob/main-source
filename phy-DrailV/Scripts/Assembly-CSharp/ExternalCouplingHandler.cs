using System.Collections;
using DV;
using DV.Interaction.Inputs;
using DV.MultipleUnit;
using UnityEngine;
using VRTK;

public class ExternalCouplingHandler : MonoBehaviour
{
	public const float COUPLING_RANGE = 0.64f;

	private TrainCar train;

	private int numberOfCarsInFront;

	private int numberOfCarsInRear;

	private GameParams gameParams;

	private TouchpadInputInterpreter touchpadInterpreter;

	private bool IsHandbrakeBypassPressed
	{
		get
		{
			if (!VRManager.IsVREnabled())
			{
				return InputManager.NewPlayer.GetButton(InputManager.Actions.Run);
			}
			return TouchpadInputInterpreter.GetTouchDirectionBasedOnAngle(touchpadInterpreter.AxisValue) == TouchpadInputDirection.Up;
		}
	}

	private void Awake()
	{
		train = GetComponent<TrainCar>();
		gameParams = Globals.G.GameParams;
	}

	private IEnumerator Start()
	{
		CalculateForwardAndRearCars();
		train.TrainsetChanged += delegate
		{
			CalculateForwardAndRearCars();
		};
		if (VRManager.IsVREnabled())
		{
			while (!SetupDeviceSpecificControls.AreControlsSetRight)
			{
				yield return null;
			}
			Transform transform = VRTK_DeviceFinder.GetControllerRightHand(getActual: true).transform;
			touchpadInterpreter = transform.GetComponentInChildren<TouchpadInputInterpreter>();
		}
	}

	private void CalculateForwardAndRearCars()
	{
		numberOfCarsInFront = 0;
		numberOfCarsInRear = 0;
		int num = 0;
		Coupler coupled = train.frontCoupler.GetCoupled();
		while ((bool)coupled)
		{
			numberOfCarsInFront++;
			coupled = coupled.GetOppositeCoupler().GetCoupled();
			num++;
			if (num > 1000)
			{
				Debug.LogError("RemoteControllerModule iteration safety #1 hit 1000!");
				break;
			}
		}
		num = 0;
		coupled = train.rearCoupler.GetCoupled();
		while ((bool)coupled)
		{
			numberOfCarsInRear++;
			coupled = coupled.GetOppositeCoupler().GetCoupled();
			num++;
			if (num > 1000)
			{
				Debug.LogError("RemoteControllerModule iteration safety #2 hit 1000!");
				break;
			}
		}
	}

	public void Couple()
	{
		Coupler coupler = CouplerLogic.CoupleFirstInRange(train, 0.64f, !IsHandbrakeBypassPressed && gameParams.AutoHandbrakeViaRemoteControlCouplingAllowed);
		if (coupler != null)
		{
			MultipleUnitModule.ConnectCablesOfConnectedCouplersIfMultipleUnitSupported(coupler, coupler.coupledTo);
		}
	}

	public void Uncouple(int selectedCoupler)
	{
		Coupler coupler = CouplerLogic.UncoupleNth(train, selectedCoupler, !IsHandbrakeBypassPressed && gameParams.AutoHandbrakeViaRemoteControlCouplingAllowed);
		if (coupler != null)
		{
			MultipleUnitModule.DisconnectCablesIfMultipleUnitSupported(coupler.train, coupler.isFrontCoupler, !coupler.isFrontCoupler);
		}
	}

	public bool IsCouplerInRange(float range)
	{
		return CouplerLogic.AnyCouplerInRange(train, range);
	}

	public int GetNumberOfCarsInFront()
	{
		return numberOfCarsInFront;
	}

	public int GetNumberOfCarsInRear()
	{
		return numberOfCarsInRear;
	}
}

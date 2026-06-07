using System.Collections;
using DV.CabControls;
using DV.Interaction.Inputs;
using DV.Utils;
using UnityEngine;

public class DecouplerKnob : MonoBehaviour
{
	public DecouplerDeviceLogic device;

	private SteppedJoint joint;

	private IEnumerator Start()
	{
		yield return WaitFor.Seconds(0.1f);
		joint = GetComponent<SteppedJoint>();
		if (!joint)
		{
			Debug.LogError("DecouplerKnob couldn't find joint.");
		}
		joint.PositionChanged += RouteOffset;
	}

	private void OnDestroy()
	{
		joint.PositionChanged -= RouteOffset;
	}

	private void Update()
	{
		if (!SingletonBehaviour<InputFocusManager>.Instance.hasKeyboardFocus)
		{
			if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.CouplerSelect))
			{
				joint.InvokePositionChanged(1f);
			}
			if (InputManager.NewPlayer.GetNegativeButtonDown(InputManager.Actions.CouplerSelect))
			{
				joint.InvokePositionChanged(-1f);
			}
		}
	}

	public void RouteOffset(ValueChangedEventArgs e)
	{
		UpdateSelectedCoupler((int)e.delta);
	}

	private void UpdateSelectedCoupler(int delta)
	{
		if (device.numCarsFront + device.numCarsRear != 0)
		{
			int num = device.selectedCoupler + delta;
			if (num == 0)
			{
				num += ((delta > 0) ? 1 : (-1));
			}
			if (num > device.numCarsFront)
			{
				num = -device.numCarsRear;
			}
			else if (num < -device.numCarsRear)
			{
				num = device.numCarsFront;
			}
			device.selectedCoupler = num;
		}
	}
}

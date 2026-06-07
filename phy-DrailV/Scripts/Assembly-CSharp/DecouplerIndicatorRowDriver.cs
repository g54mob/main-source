using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DecouplerFBXController))]
public class DecouplerIndicatorRowDriver : MonoBehaviour
{
	public DecouplerDeviceLogic device;

	private DecouplerFBXController fbxController;

	private int blinkValue;

	private void Start()
	{
		fbxController = GetComponent<DecouplerFBXController>();
		StartCoroutine(Blinker());
	}

	private IEnumerator Blinker()
	{
		while (true)
		{
			blinkValue = (blinkValue + 1) % 2;
			yield return WaitFor.Seconds(0.4f);
		}
	}

	private void Update()
	{
		fbxController.selectedCoupler = device.selectedCoupler;
		fbxController.numFrontCars = device.numCarsFront;
		fbxController.numRearCars = device.numCarsRear;
		fbxController.blinkFlagsFront = device.blinkFlagsFront;
		fbxController.blinkFlagsRear = device.blinkFlagsRear;
		if ((bool)device.frontCouplerInRange)
		{
			fbxController.numFrontCars += blinkValue;
		}
		if ((bool)device.rearCouplerInRange)
		{
			fbxController.numRearCars += blinkValue;
		}
	}
}

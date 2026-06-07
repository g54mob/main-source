using System;
using NewGameplayScripts;
using UnityEngine;

public class ControlsTipsUI : MonoBehaviour
{
	[SerializeField]
	private Transform cameraTips;

	[SerializeField]
	private Transform plantTips;

	[SerializeField]
	private Transform lampHumidifierTips;

	[SerializeField]
	private Transform itemTips;

	private bool isPlantMoving;

	private bool isLampHumidifierMoving;

	private void Start()
	{
		MovementSystem.Instance.OnStartGrabbing += MovementSystem_OnStartGrabbing;
		MovementSystem.Instance.OnStartMovingPlant += MovementSystem_OnStartMovingPlant;
		MovementSystem.Instance.OnStartMovingLamp_Humidifier += MovementSystem_OnStartMovingLamp_Humidifier;
		MovementSystem.Instance.OnStopGrabbing += MovementSystem_OnStopGrabbing;
		ShowCameraTips();
	}

	private void CheckWhatIsMoving()
	{
		if (isPlantMoving || isLampHumidifierMoving)
		{
			if (isPlantMoving)
			{
				ShowPlantTips();
			}
			else
			{
				ShowLampHumidifierTips();
			}
		}
		else
		{
			ShowItemTips();
		}
	}

	private void MovementSystem_OnStopGrabbing(object sender, EventArgs e)
	{
		isPlantMoving = false;
		isLampHumidifierMoving = false;
		ShowCameraTips();
	}

	private void MovementSystem_OnStartGrabbing(object sender, EventArgs e)
	{
		Invoke("CheckWhatIsMoving", 0.01f);
	}

	private void MovementSystem_OnStartMovingPlant(object sender, EventArgs e)
	{
		isPlantMoving = true;
	}

	private void MovementSystem_OnStartMovingLamp_Humidifier(object sender, EventArgs e)
	{
		isLampHumidifierMoving = true;
	}

	private void ShowItemTips()
	{
		HideElement(cameraTips);
		HideElement(plantTips);
		HideElement(lampHumidifierTips);
		ShowElement(itemTips);
	}

	private void ShowLampHumidifierTips()
	{
		HideElement(cameraTips);
		HideElement(plantTips);
		ShowElement(lampHumidifierTips);
		HideElement(itemTips);
	}

	private void ShowCameraTips()
	{
		ShowElement(cameraTips);
		HideElement(plantTips);
		HideElement(lampHumidifierTips);
		HideElement(itemTips);
	}

	private void ShowPlantTips()
	{
		HideElement(cameraTips);
		ShowElement(plantTips);
		HideElement(lampHumidifierTips);
		HideElement(itemTips);
	}

	private void HideElement(Transform transform)
	{
		transform.gameObject.SetActive(value: false);
	}

	private void ShowElement(Transform transform)
	{
		transform.gameObject.SetActive(value: true);
	}

	private void OnDestroy()
	{
		MovementSystem.Instance.OnStartGrabbing -= MovementSystem_OnStartGrabbing;
		MovementSystem.Instance.OnStartMovingPlant -= MovementSystem_OnStartMovingPlant;
		MovementSystem.Instance.OnStartMovingLamp_Humidifier -= MovementSystem_OnStartMovingLamp_Humidifier;
		MovementSystem.Instance.OnStopGrabbing -= MovementSystem_OnStopGrabbing;
	}
}

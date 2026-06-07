using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class CabooseController : MonoBehaviour
{
	public GameObject cabTeleportDestinationCollidersGO;

	private TrainCar car;

	private void Awake()
	{
		car = GetComponent<TrainCar>();
		if (car == null)
		{
			Debug.LogError("TrainCar not attached to CabooseController! Destroying self.");
			Object.Destroy(this);
		}
	}

	private void OnEnable()
	{
		PlayerManager.CarChanged += OnPlayerCarChanged;
	}

	private void OnDisable()
	{
		PlayerManager.CarChanged -= OnPlayerCarChanged;
	}

	private void OnPlayerCarChanged(TrainCar currentCar)
	{
		if (currentCar == car)
		{
			if (cabTeleportDestinationCollidersGO.activeSelf)
			{
				cabTeleportDestinationCollidersGO.SetActive(value: false);
			}
		}
		else if (!cabTeleportDestinationCollidersGO.activeSelf)
		{
			cabTeleportDestinationCollidersGO.SetActive(value: true);
		}
	}

	public static bool PlayerCloseToAnyCaboose()
	{
		Transform playerTransform = PlayerManager.PlayerTransform;
		if (playerTransform == null)
		{
			Debug.LogError("Unexpected state: playerTransform not found! Returning false!");
			return false;
		}
		foreach (TrainCar allSpecialCar in SingletonBehaviour<CarSpawner>.Instance.AllSpecialCars)
		{
			if (CarTypes.IsCaboose(allSpecialCar.carLivery))
			{
				if ((playerTransform.position - allSpecialCar.transform.position).sqrMagnitude < 2250000f)
				{
					return true;
				}
				if (PlayerManager.LastLoco != null && PlayerManager.LastLoco.trainset.id == allSpecialCar.trainset.id)
				{
					return true;
				}
			}
		}
		return false;
	}
}

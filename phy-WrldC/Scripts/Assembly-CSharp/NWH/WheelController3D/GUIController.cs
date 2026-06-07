using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NWH.WheelController3D
{
	public class GUIController : MonoBehaviour
	{
		public GameObject currentVehicle;

		[SerializeField]
		public List<GameObject> vehicles;

		private WheelController[] wcs;

		public Text speedText;

		private int speed;

		private int vehicleSelector;

		public GameObject canvas;

		[HideInInspector]
		public CarController cc;

		private void Start()
		{
			currentVehicle = vehicles[vehicleSelector];
			currentVehicle.GetComponent<CarController>().Active(state: true);
			wcs = currentVehicle.GetComponentsInChildren<WheelController>();
			cc = currentVehicle.GetComponent<CarController>();
		}

		private void Update()
		{
			currentVehicle = vehicles[vehicleSelector];
			wcs = currentVehicle.GetComponentsInChildren<WheelController>();
			cc = currentVehicle.GetComponent<CarController>();
			Camera.main.GetComponent<CameraDefault>().TargetLookAt = currentVehicle.transform;
			SetMeter();
			SetSpeed(cc.velocity * 3.6f);
		}

		public void ChangeVehicle()
		{
			int num = vehicleSelector + 1;
			if (num >= vehicles.Count)
			{
				num = 0;
			}
			if (num != vehicleSelector)
			{
				vehicles[vehicleSelector].GetComponent<CarController>().Active(state: false);
				vehicles[num].GetComponent<CarController>().Active(state: true);
			}
			vehicleSelector = num;
		}

		private void SetMeter()
		{
			speedText.text = Mathf.Abs(speed).ToString();
		}

		public void SetSpeed(float currentSpeed)
		{
			speed = Mathf.RoundToInt(currentSpeed);
		}

		public void LevelReset()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		public void SurfaceTarmacDry()
		{
			AdjustFriction(WheelController.FrictionPreset.TarmacDry);
		}

		public void SurfaceTarmacWet()
		{
			AdjustFriction(WheelController.FrictionPreset.TarmacWet);
		}

		public void SurfaceGravel()
		{
			AdjustFriction(WheelController.FrictionPreset.Gravel);
		}

		public void SurfaceSnow()
		{
			AdjustFriction(WheelController.FrictionPreset.Snow);
		}

		public void SurfaceGeneric()
		{
			AdjustFriction(WheelController.FrictionPreset.Generic);
		}

		public void SurfaceIce()
		{
			AdjustFriction(WheelController.FrictionPreset.Ice);
		}

		public void IncreaseSpringLength()
		{
			WheelController[] array = wcs;
			foreach (WheelController wheelController in array)
			{
				wheelController.springLength += wheelController.springLength * 0.1f;
				wheelController.springLength = Mathf.Clamp(wheelController.springLength, 0.15f, 0.6f);
			}
		}

		public void DecreaseSpringLength()
		{
			WheelController[] array = wcs;
			foreach (WheelController wheelController in array)
			{
				wheelController.springLength -= wheelController.springLength * 0.1f;
				wheelController.springLength = Mathf.Clamp(wheelController.springLength, 0.15f, 0.6f);
			}
		}

		public void IncreaseSpringStrength()
		{
			WheelController[] array = wcs;
			foreach (WheelController wheelController in array)
			{
				wheelController.springMaximumForce += wheelController.springMaximumForce * 0.1f;
				wheelController.springMaximumForce = Mathf.Clamp(wheelController.springMaximumForce, 14000f, 45000f);
			}
		}

		public void DecreaseSpringStrength()
		{
			WheelController[] array = wcs;
			foreach (WheelController wheelController in array)
			{
				wheelController.springMaximumForce -= wheelController.springMaximumForce * 0.1f;
				wheelController.springMaximumForce = Mathf.Clamp(wheelController.springMaximumForce, 14000f, 45000f);
			}
		}

		public void IncreaseRebound()
		{
			WheelController[] array = wcs;
			foreach (WheelController wheelController in array)
			{
				wheelController.damperUnitReboundForce += wheelController.damperUnitReboundForce * 0.1f;
				wheelController.damperUnitReboundForce = Mathf.Clamp(wheelController.damperUnitReboundForce, 300f, 2500f);
			}
		}

		public void DecreaseRebound()
		{
			WheelController[] array = wcs;
			foreach (WheelController wheelController in array)
			{
				wheelController.damperUnitReboundForce -= wheelController.damperUnitReboundForce * 0.1f;
				wheelController.damperUnitReboundForce = Mathf.Clamp(wheelController.damperUnitReboundForce, 300f, 2500f);
			}
		}

		public void IncreaseBump()
		{
			WheelController[] array = wcs;
			foreach (WheelController wheelController in array)
			{
				wheelController.damperUnitBumpForce += wheelController.damperUnitBumpForce * 0.1f;
				wheelController.damperUnitBumpForce = Mathf.Clamp(wheelController.damperUnitBumpForce, 300f, 2500f);
			}
		}

		public void DecreaseBump()
		{
			WheelController[] array = wcs;
			foreach (WheelController wheelController in array)
			{
				wheelController.damperUnitBumpForce -= wheelController.damperUnitBumpForce * 0.1f;
				wheelController.damperUnitBumpForce = Mathf.Clamp(wheelController.damperUnitBumpForce, 300f, 2500f);
			}
		}

		public void IncreaseRimOffset()
		{
			WheelController[] array = wcs;
			foreach (WheelController obj in array)
			{
				obj.rimOffset += 0.05f;
				obj.rimOffset = Mathf.Clamp(obj.rimOffset, -0.2f, 0.2f);
			}
		}

		public void DecreaseRimOffset()
		{
			WheelController[] array = wcs;
			foreach (WheelController obj in array)
			{
				obj.rimOffset -= 0.05f;
				obj.rimOffset = Mathf.Clamp(obj.rimOffset, -0.2f, 0.2f);
			}
		}

		public void IncreaseCamber()
		{
			WheelController[] array = wcs;
			foreach (WheelController obj in array)
			{
				float value = obj.camber + 2f;
				value = Mathf.Clamp(value, -15f, 15f);
				obj.SetCamber(value);
			}
		}

		public void DecreaseCamber()
		{
			WheelController[] array = wcs;
			foreach (WheelController obj in array)
			{
				float value = obj.camber - 2f;
				value = Mathf.Clamp(value, -15f, 15f);
				obj.SetCamber(value);
			}
		}

		public void AdjustFriction(WheelController.FrictionPreset p)
		{
			WheelController[] array = wcs;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActiveFrictionPreset(p);
			}
		}
	}
}

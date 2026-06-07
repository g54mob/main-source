using DV.Utils;
using UnityEngine;

namespace DV.Testing
{
	[ExecutionOrder(-1000)]
	public class TestSceneRig : MonoBehaviour
	{
		public Light directionalLight;

		public GameObject weatherDV;

		public GameObject worldMover;

		public GameObject shopRoot;

		private bool weatherOn = true;

		private void Awake()
		{
			directionalLight.gameObject.SetActive(value: false);
			if (worldMover.activeInHierarchy)
			{
				TrainCar[] array = Object.FindObjectsOfType<TrainCar>();
				for (int i = 0; i < array.Length; i++)
				{
					Object.DestroyImmediate(array[i].gameObject);
				}
			}
		}

		public void ToggleShop()
		{
			shopRoot.SetActive(!shopRoot.activeSelf);
		}

		public void ToggleWeather()
		{
			weatherOn = !weatherOn;
			weatherDV.SetActive(weatherOn);
			directionalLight.gameObject.SetActive(!weatherOn);
		}
	}
}

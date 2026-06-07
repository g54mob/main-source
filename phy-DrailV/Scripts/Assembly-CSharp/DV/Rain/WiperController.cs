using System;
using UnityEngine;

namespace DV.Rain
{
	public class WiperController : MonoBehaviour
	{
		public float[] speeds = new float[4] { 0f, 1f, 1f, 2f };

		public float[] timeBetweenWipes = new float[4] { 4f, 4f, 0f, 0f };

		public WiperDriver[] wiperDrivers;

		public int speedIndex;

		[NonSerialized]
		public int usedSpeedIndex;

		private void Start()
		{
			WiperDriver[] array = wiperDrivers;
			foreach (WiperDriver wiperDriver in array)
			{
				if ((bool)wiperDriver.master)
				{
					Debug.LogError(string.Format("Wiper {0} shouldn't be assigned in {1}, it has a master!", wiperDriver, "WiperController"), base.gameObject);
				}
				wiperDriver.wiper.OnReleaseDroplets += ReleaseDroplets;
			}
		}

		private void OnDestroy()
		{
			WiperDriver[] array = wiperDrivers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].wiper.OnReleaseDroplets -= ReleaseDroplets;
			}
		}

		private void ReleaseDroplets(Wiper wiper)
		{
			if ((double)wiper.driver.currentPos < 0.5 && wiper.driver.speed > speeds[speedIndex])
			{
				wiper.driver.speed = speeds[speedIndex];
				usedSpeedIndex = speedIndex;
			}
		}

		private void Update()
		{
			WiperDriver[] array = wiperDrivers;
			foreach (WiperDriver wiperDriver in array)
			{
				if (wiperDriver.speed < speeds[speedIndex])
				{
					wiperDriver.speed = speeds[speedIndex];
					usedSpeedIndex = speedIndex;
				}
				if (wiperDriver.timeBetweenWipes != timeBetweenWipes[speedIndex])
				{
					wiperDriver.timeBetweenWipes = timeBetweenWipes[speedIndex];
				}
			}
		}

		public void SetSpeed(int speed)
		{
			speedIndex = Mathf.Clamp(speed, 0, speeds.Length - 1);
			WiperDriver[] array = wiperDrivers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RestartTimer();
			}
		}
	}
}

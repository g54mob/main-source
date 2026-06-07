using System.Collections.Generic;
using UnityEngine;

namespace NewGameplayScripts
{
	public class EnvironmentManager : MonoBehaviour
	{
		public List<EnvironmentHumidity> environmentHumiditiesList = new List<EnvironmentHumidity>();

		public List<EnvironmentSunlight> environmentSunlightsList = new List<EnvironmentSunlight>();

		public List<EnvironmentHumidity> humiditiesSecondFloor = new List<EnvironmentHumidity>();

		public List<EnvironmentSunlight> sunlightSecondFloor = new List<EnvironmentSunlight>();

		public List<EnvironmentHumidity> humiditiesFirstFloor = new List<EnvironmentHumidity>();

		public List<EnvironmentSunlight> sunlightFirstFloor = new List<EnvironmentSunlight>();

		public static EnvironmentManager Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
			CheckForEnvironments();
		}

		private void CheckForEnvironments()
		{
			environmentSunlightsList.Clear();
			environmentHumiditiesList.Clear();
			humiditiesFirstFloor.Clear();
			sunlightFirstFloor.Clear();
			humiditiesSecondFloor.Clear();
			sunlightSecondFloor.Clear();
			EnvironmentHumidity[] componentsInChildren = GetComponentsInChildren<EnvironmentHumidity>();
			EnvironmentSunlight[] componentsInChildren2 = GetComponentsInChildren<EnvironmentSunlight>();
			environmentHumiditiesList.AddRange(componentsInChildren);
			environmentSunlightsList.AddRange(componentsInChildren2);
			EnvironmentHumidity[] array = componentsInChildren;
			foreach (EnvironmentHumidity environmentHumidity in array)
			{
				if (environmentHumidity.transform.position.y > 0f)
				{
					humiditiesSecondFloor.Add(environmentHumidity);
				}
				else
				{
					humiditiesFirstFloor.Add(environmentHumidity);
				}
			}
			EnvironmentSunlight[] array2 = componentsInChildren2;
			foreach (EnvironmentSunlight environmentSunlight in array2)
			{
				if (environmentSunlight.transform.position.y > 0f)
				{
					sunlightSecondFloor.Add(environmentSunlight);
				}
				else
				{
					sunlightFirstFloor.Add(environmentSunlight);
				}
			}
		}

		public void ShowHumidity()
		{
			foreach (EnvironmentHumidity environmentHumidities in environmentHumiditiesList)
			{
				environmentHumidities.SetCanChange(value: false);
				environmentHumidities.Show();
			}
		}

		public void HideHumidity()
		{
			foreach (EnvironmentHumidity environmentHumidities in environmentHumiditiesList)
			{
				environmentHumidities.SetCanChange(value: true);
				environmentHumidities.Hide();
			}
		}

		public void ShowSunlight()
		{
			foreach (EnvironmentSunlight environmentSunlights in environmentSunlightsList)
			{
				environmentSunlights.SetCanChange(value: false);
				environmentSunlights.Show();
			}
		}

		public void HideSunlight()
		{
			foreach (EnvironmentSunlight environmentSunlights in environmentSunlightsList)
			{
				environmentSunlights.SetCanChange(value: true);
				environmentSunlights.Hide();
			}
		}

		public void SwitchFirstFloorEnvironments(bool turnOn)
		{
			ToggleEnvironment(humiditiesFirstFloor, sunlightFirstFloor, turnOn);
		}

		public void SwitchSecondFloorEnvironments(bool turnOn)
		{
			ToggleEnvironment(humiditiesSecondFloor, sunlightSecondFloor, turnOn);
		}

		private void ToggleEnvironment(List<EnvironmentHumidity> humidities, List<EnvironmentSunlight> sunlights, bool turnOn)
		{
			foreach (EnvironmentHumidity humidity in humidities)
			{
				humidity.transform.parent.gameObject.SetActive(turnOn);
			}
			foreach (EnvironmentSunlight sunlight in sunlights)
			{
				sunlight.transform.parent.gameObject.SetActive(turnOn);
			}
		}
	}
}

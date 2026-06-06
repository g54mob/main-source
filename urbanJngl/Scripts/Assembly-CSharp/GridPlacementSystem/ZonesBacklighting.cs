using System.Collections.Generic;
using UnityEngine;

namespace GridPlacementSystem
{
	public class ZonesBacklighting : MonoBehaviour
	{
		public List<ZoneColorController> ColorControllers;

		public void TurnOnColor(ObjectSO plant)
		{
			foreach (ZoneColorController colorController in ColorControllers)
			{
				if (plant.sunlight == colorController.Sunlight && plant.humidity == colorController.Humidity)
				{
					colorController.TurnOnGreenLight();
				}
				else if (plant.sunlight != colorController.Sunlight && plant.humidity != colorController.Humidity)
				{
					colorController.TurnOnBlueLight();
				}
				else
				{
					colorController.TurnOnYellowLight();
				}
			}
		}

		public void TurnOffColor()
		{
			foreach (ZoneColorController colorController in ColorControllers)
			{
				colorController.TurnOffLights();
			}
		}
	}
}

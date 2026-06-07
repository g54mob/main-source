using System.Collections.Generic;
using UnityEngine;

namespace PG
{
	[CreateAssetMenu(fileName = "GameSettings", menuName = "GameBalance/Settings/GameSettings")]
	public class GameSettings : ScriptableObject
	{
		public MeasurementSystem EnumMeasurementSystem;

		public Layer LayerForAiDetection;

		public List<VehicleController> AvailableVehicles;

		public static bool IsMobilePlatform => false;
	}
}

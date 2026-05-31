using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PG
{
	public class GameController : NoktaSingleton<GameController>
	{
		public TextMeshProUGUI TimeScaleText;

		public Transform[] StartPositions;

		public List<CarController> AllCars;

		private List<VehicleController> AllVehicles;

		public static bool SplitScreen => false;

		public InitializePlayer Player1 { get; private set; }

		public CarController PlayerCar1 { get; private set; }

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void SetNextCar()
		{
		}

		private void UpdateSelectedCars()
		{
		}

		private InitializePlayer UpdateSelectedCar(InitializePlayer player, CarController car)
		{
			return null;
		}

		public void RestartScene()
		{
		}

		public void ChangeTimeScale(float delta)
		{
		}
	}
}

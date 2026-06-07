using TMPro;
using UnityEngine;

namespace DV.UI.LocoHUD
{
	public class HUDTrainPlateInfo : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI carId;

		[SerializeField]
		private TextMeshProUGUI carType;

		[SerializeField]
		private TextMeshProUGUI carMassLength;

		[SerializeField]
		private TextMeshProUGUI vehicleCargo;

		[SerializeField]
		private TextMeshProUGUI healthPercentages;

		[SerializeField]
		private TextMeshProUGUI cargoType;

		[SerializeField]
		private TextMeshProUGUI cargoMassJobId;

		public void UnsubscribeCar(TrainCar car)
		{
			if (FindPlate(car, out var controller))
			{
				controller.ValueChanged -= UpdateFromPlate;
			}
		}

		public void SubscribeCar(TrainCar car)
		{
			if (FindPlate(car, out var controller))
			{
				controller.ValueChanged += UpdateFromPlate;
				UpdateFromPlate(controller);
				base.gameObject.SetActive(value: true);
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private bool FindPlate(TrainCar car, out TrainCarPlatesController controller)
		{
			controller = car.GetComponentInChildren<TrainCarPlatesController>(includeInactive: true);
			return controller != null;
		}

		private void UpdateFromPlate(TrainCarPlatesController controller)
		{
			carId.text = controller.carIdText;
			carType.text = controller.carTypeText;
			carMassLength.text = controller.carMassLengthText;
			vehicleCargo.text = controller.vehicleCargoText;
			healthPercentages.text = controller.healthPercentagesText;
			cargoType.text = controller.cargoTypeText;
			cargoMassJobId.text = controller.cargoMassJobIdText;
		}
	}
}

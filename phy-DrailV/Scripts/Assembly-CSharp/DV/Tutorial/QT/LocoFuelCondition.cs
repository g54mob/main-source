using DV.Simulation.Cars;
using DV.ThingTypes;
using LocoSim.Implementations;
using LocoSim.Resources;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class LocoFuelCondition : AQuickTutorialCondition
	{
		private readonly float minFuel;

		private readonly float maxFuel;

		private readonly string messageFuel;

		private readonly string messageCoal;

		private readonly string messageBattery;

		private TrainCar car;

		public LocoFuelCondition(float minFuel, float maxFuel, string messageFuel, string messageCoal, string messageBattery, TrainCar car = null)
		{
			this.minFuel = minFuel;
			this.maxFuel = maxFuel;
			this.messageFuel = messageFuel;
			this.messageCoal = messageCoal;
			this.messageBattery = messageBattery;
			this.car = car;
		}

		public override void Start()
		{
			base.Start();
			if (car == null)
			{
				car = PlayerManager.Car;
			}
		}

		private float TryGetResource(TrainCar car, ResourceContainerType resource, out bool resourceExists)
		{
			ResourceContainerController resourceContainerController = car?.SimController?.resourceContainerController;
			if (resourceContainerController != null)
			{
				ResourceContainer resourceContainer = resourceContainerController.GetResourceContainer(resource);
				if (resourceContainer != null && resourceContainer.normalizedReadOutPort != null)
				{
					resourceExists = true;
					return resourceContainer.normalizedReadOutPort.Value;
				}
			}
			resourceExists = false;
			return 0f;
		}

		public override string Check()
		{
			if (car != null && car.SimController != null && car.SimController.resourceContainerController != null)
			{
				float num = 0f;
				string result;
				if (CarTypes.IsSteamLocomotive(car.carLivery))
				{
					float num2 = 0f;
					float num3 = 0f;
					num2 = TryGetResource(car, ResourceContainerType.COAL, out var resourceExists);
					num3 = TryGetResource(car, ResourceContainerType.WATER, out resourceExists);
					if (car.GetComponent<SteamTenderAutoCoupleMechanism>() != null && car.rearCoupler.coupledTo != null && CarTypes.IsTender(car.rearCoupler.coupledTo.train.carLivery))
					{
						TrainCar train = car.rearCoupler.coupledTo.train;
						num2 = Mathf.Max(num2, TryGetResource(train, ResourceContainerType.COAL, out resourceExists));
						num3 = Mathf.Max(num3, TryGetResource(train, ResourceContainerType.WATER, out resourceExists));
					}
					num = Mathf.Min(num2, num3);
					result = messageCoal;
				}
				else
				{
					bool resourceExists2;
					float a = TryGetResource(car, ResourceContainerType.FUEL, out resourceExists2);
					bool resourceExists3;
					float b = TryGetResource(car, ResourceContainerType.ELECTRIC_CHARGE, out resourceExists3);
					if (!(resourceExists2 || resourceExists3))
					{
						return string.Empty;
					}
					result = (resourceExists3 ? messageBattery : messageFuel);
					num = Mathf.Max(a, b);
				}
				if (num < minFuel || num > maxFuel)
				{
					return result;
				}
			}
			return string.Empty;
		}
	}
}

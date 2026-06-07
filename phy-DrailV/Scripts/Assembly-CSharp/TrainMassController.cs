using DV.Simulation.Cars;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using UnityEngine;

public class TrainMassController
{
	private const float GRAVITY_CONST = 9.81f;

	private const float BOGIE_MASS_RATIO = 0.5f;

	private TrainCar car;

	private ResourceContainerController resourceContainerController;

	public float TotalMass { get; private set; }

	public float TotalCarMass => TotalMass * 0.5f;

	public float TotalBogiesMass => TotalMass * 0.5f;

	public float CarMass { get; private set; }

	public float CargoMass { get; private set; }

	public float ResourcesMass { get; private set; }

	public float DefaultCarRbMass => CarMass * 0.5f;

	public float DefaultBogieRbMass => CarMass * (0.5f / (float)car.Bogies.Length);

	public float WeightPerAxle => TotalMass / (float)car.NumberOfAxles * 9.81f;

	public TrainMassController(TrainCar trainCar)
	{
		car = trainCar;
		CarMass = car.carLivery.parentType.mass;
		TotalMass = CarMass;
		SetupListeners(set: true);
	}

	public void SetResourceContainerController(ResourceContainerController rcc)
	{
		if (rcc == null)
		{
			Debug.LogError("Unexpected state: rcc provided in SetResourceContainerController is null.");
			return;
		}
		if (resourceContainerController != null)
		{
			Debug.LogError("Unexpected state: resourceContainerController is already set.");
			return;
		}
		resourceContainerController = rcc;
		resourceContainerController.UpdateResourcesMass += UpdateTrainCarMass;
	}

	private void SetupListeners(bool set)
	{
		if (set)
		{
			car.CargoLoaded += UpdateTrainCarMass;
			car.CargoUnloaded += UpdateTrainCarMass;
			car.OnDerailed += UpdateTrainCarMass;
			car.OnRerailed += UpdateTrainCarMass;
			return;
		}
		car.CargoLoaded -= UpdateTrainCarMass;
		car.CargoUnloaded -= UpdateTrainCarMass;
		car.OnDerailed -= UpdateTrainCarMass;
		car.OnRerailed -= UpdateTrainCarMass;
		if (resourceContainerController != null)
		{
			resourceContainerController.UpdateResourcesMass -= UpdateTrainCarMass;
		}
	}

	private void UpdateTrainCarMass(CargoType _)
	{
		UpdateTrainCarMass();
	}

	private void UpdateTrainCarMass(TrainCar _)
	{
		UpdateTrainCarMass();
	}

	public void UpdateTrainCarMass()
	{
		CargoType loadedCargo = car.LoadedCargo;
		CargoMass = ((loadedCargo != CargoType.None) ? (loadedCargo.ToV2().massPerUnit * car.LoadedCargoAmount) : 0f);
		ResourcesMass = resourceContainerController?.GetResourcesMass() ?? 0f;
		TotalMass = CarMass + CargoMass + ResourcesMass;
		bool flag = false;
		if (!car.derailed)
		{
			for (int i = 0; i < car.Bogies.Length; i++)
			{
				if ((object)car.Bogies[i].rb == null)
				{
					flag = true;
					break;
				}
			}
		}
		if (car.derailed || flag)
		{
			car.rb.mass = TotalMass;
			return;
		}
		car.rb.mass = TotalMass * 0.5f;
		for (int j = 0; j < car.Bogies.Length; j++)
		{
			car.Bogies[j].rb.mass = TotalMass * (0.5f / (float)car.Bogies.Length);
			car.Bogies[j].SetupJointSettings(TotalMass);
		}
	}
}

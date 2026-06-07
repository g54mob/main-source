using DV.Simulation.Cars;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class MagicShoveling : MonoBehaviour
	{
		private TrainCar car;

		private FireboxSimController fireboxController;

		private void Awake()
		{
			car = TrainCar.Resolve(base.gameObject);
			SimController simController = car?.SimController;
			if (simController == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: couldn't find simController, MagicShoveling destroying self!");
				Object.Destroy(this);
				return;
			}
			fireboxController = simController.firebox;
			if (fireboxController == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: couldn't find FireboxSimController, MagicShoveling destroying self!");
				Object.Destroy(this);
			}
		}

		public void AddCoalToFirebox(byte chunkCount)
		{
			CoalPileSimController coalPileSimController = FindCoalPile(car);
			if (coalPileSimController == null && (bool)car.rearCoupler.coupledTo)
			{
				coalPileSimController = FindCoalPile(car.rearCoupler.coupledTo.train);
			}
			if (coalPileSimController == null)
			{
				Debug.LogWarning("Can't AddCoalToFirebox, no CoalPileSimController found");
			}
			else
			{
				coalPileSimController.TransferToFirebox(fireboxController, chunkCount);
			}
		}

		private CoalPileSimController FindCoalPile(TrainCar possibleCar)
		{
			return possibleCar.SimController?.coalPile;
		}
	}
}

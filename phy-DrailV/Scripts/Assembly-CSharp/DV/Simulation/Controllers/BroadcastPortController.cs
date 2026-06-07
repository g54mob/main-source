using System.Linq;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class BroadcastPortController : MonoBehaviour
	{
		public BroadcastPortValueProvider[] providers;

		public BroadcastPortValueConsumer[] consumers;

		private void OnValidate()
		{
			BroadcastPortValueProvider[] componentsInChildren = GetComponentsInChildren<BroadcastPortValueProvider>();
			if (providers == null || providers.Any((BroadcastPortValueProvider p) => p == null) || providers.Length != componentsInChildren.Length)
			{
				providers = componentsInChildren;
			}
			BroadcastPortValueConsumer[] componentsInChildren2 = GetComponentsInChildren<BroadcastPortValueConsumer>();
			if (consumers == null || consumers.Any((BroadcastPortValueConsumer p) => p == null) || consumers.Length != componentsInChildren2.Length)
			{
				consumers = componentsInChildren2;
			}
		}

		public void Init(TrainCar car, SimulationFlow simFlow)
		{
			BroadcastPortValueConsumer[] array = consumers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Init(car, simFlow);
			}
			BroadcastPortValueProvider[] array2 = providers;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Init(car, simFlow);
			}
		}
	}
}

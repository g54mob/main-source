using DV.Simulation.Controllers;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class S282VirtualHandbrakeOverrider : MonoBehaviour, BaseControlsOverrider.IHandbrakeOverrider
	{
		public HandbrakeControl GetHandbrake(TrainCar car)
		{
			return new S282VirtualHandbrake(car);
		}
	}
}

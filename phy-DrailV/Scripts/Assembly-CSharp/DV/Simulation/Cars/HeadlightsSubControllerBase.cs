using DV.MultipleUnit;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public abstract class HeadlightsSubControllerBase : MonoBehaviour
	{
		public enum HeadlightMUDependency
		{
			None = 0,
			Front = 1,
			Rear = 2
		}

		public bool isFront;

		[SerializeField]
		protected HeadlightMUDependency multipleUnityDependent;

		public Headlight[] headlights;

		public Light[] lightSources;

		protected MultipleUnitModule multipleUnitModule;

		protected Coupler coupler;

		protected CarLightsOptimizer optimizer;

		private bool initialized;

		private GameParams gameParams;

		protected bool OptimizerAllowsLights
		{
			get
			{
				if (!(optimizer == null))
				{
					return optimizer.HeadlightsOptimizationGroup.enabled;
				}
				return true;
			}
		}

		protected bool OptimizerAllowsGlares
		{
			get
			{
				if (!(optimizer == null))
				{
					return optimizer.GlaresOptimizationGroup.enabled;
				}
				return true;
			}
		}

		protected bool OptimizerAllowsBeams
		{
			get
			{
				if (!(optimizer == null))
				{
					return optimizer.BeamsOptimizationGroup.enabled;
				}
				return true;
			}
		}

		public abstract void UpdateHeadlights(HeadlightsMainController.HeadlightSetting setting);

		public virtual void Initialize(CarLightsOptimizer optimizer, TrainCar car)
		{
			if (!initialized)
			{
				this.optimizer = optimizer;
				coupler = (isFront ? car.frontCoupler : car.rearCoupler);
				multipleUnitModule = car.muModule;
				gameParams = Globals.G.GameParams;
				initialized = true;
			}
		}

		protected virtual bool MUAllowsHeadlight()
		{
			if (multipleUnitModule == null)
			{
				return true;
			}
			switch (multipleUnityDependent)
			{
			case HeadlightMUDependency.None:
				return true;
			case HeadlightMUDependency.Front:
				return !multipleUnitModule.ConnectedFront;
			case HeadlightMUDependency.Rear:
				return !multipleUnitModule.ConnectedRear;
			default:
				Debug.LogError("Unexpected headlight MU dependency. Assuming no dependency.");
				return true;
			}
		}

		protected virtual bool HoseConnectionAllowsHeadlights()
		{
			if (!gameParams.AutoHeadlightsDirectionAllowed && !gameParams.AutoHeadlightsOnOffAllowed)
			{
				return true;
			}
			return !coupler.hoseAndCock.IsHoseConnected;
		}
	}
}

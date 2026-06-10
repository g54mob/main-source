using System;
using NSEipix.Base;
using NSMedieval.State;
using NSMedieval.StatsSystem;

namespace NSMedieval.Controllers
{
	public class LifeController : MonoSingleton<LifeController>
	{
		public delegate void UpdateLifeDelegate(StatsInstance stats);

		public event UpdateLifeDelegate WakeUpEvent;

		public event UpdateLifeDelegate WakeUpAfterFaintEvent;

		public event UpdateLifeDelegate FallAsleepEvent;

		public event UpdateLifeDelegate OnFaintEvent;

		public event UpdateLifeDelegate DieFromStarvationEvent;

		public event UpdateLifeDelegate StartedStarvingEvent;

		public event UpdateLifeDelegate EndedStarvingEvent;

		public event UpdateLifeDelegate WorkerRestStartedEvent;

		public event Action<CreatureBase> OnStartBleedingEvent;

		public event Action<CreatureBase> OnStopBleedingEvent;

		public void WakeUp(StatsInstance instance)
		{
			this.WakeUpEvent?.Invoke(instance);
		}

		public void WakeUpAfterFaint(StatsInstance instance)
		{
			this.WakeUpAfterFaintEvent?.Invoke(instance);
		}

		public void OnFaint(StatsInstance instance)
		{
			this.OnFaintEvent?.Invoke(instance);
		}

		public void FallAsleep(StatsInstance instance)
		{
			this.FallAsleepEvent?.Invoke(instance);
		}

		public void DieFromStarvation(StatsInstance instance)
		{
			this.DieFromStarvationEvent?.Invoke(instance);
		}

		public void Starving(StatsInstance instance, bool isStarted)
		{
			if (isStarted)
			{
				this.StartedStarvingEvent?.Invoke(instance);
			}
			else
			{
				this.EndedStarvingEvent?.Invoke(instance);
			}
		}

		public void OnStartBleeding(CreatureBase creature)
		{
			this.OnStartBleedingEvent?.Invoke(creature);
			MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(creature, "IsBleeding", value: true);
		}

		public void OnStopBleeding(CreatureBase creature)
		{
			this.OnStopBleedingEvent?.Invoke(creature);
			MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(creature, "IsBleeding", value: false);
		}
	}
}

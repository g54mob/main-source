using Restory.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace Restory.TimeSystems
{
	public class TimeScalingServiceResetterFromGameStates : MonoBehaviour
	{
		private TimeScalingService timeScalingService;

		private GlobalStateObserver globalStateObserver;

		[Inject]
		private void Construct(TimeScalingService timeScalingService, GlobalStateObserver globalStateObserver)
		{
			this.globalStateObserver = globalStateObserver;
			this.timeScalingService = timeScalingService;
			if (base.isActiveAndEnabled)
			{
				globalStateObserver.AddSubscriber(this, ResolveGameStateChanged);
			}
		}

		private void OnEnable()
		{
			if (globalStateObserver != null)
			{
				globalStateObserver.AddSubscriber(this, ResolveGameStateChanged);
			}
		}

		private void OnDisable()
		{
			if (globalStateObserver != null)
			{
				globalStateObserver.RemoveSubscriber(this);
			}
		}

		private void ResolveGameStateChanged()
		{
			if (globalStateObserver.IsInInitializationState)
			{
				timeScalingService.ResetTimeScaleToDefault();
			}
		}
	}
}

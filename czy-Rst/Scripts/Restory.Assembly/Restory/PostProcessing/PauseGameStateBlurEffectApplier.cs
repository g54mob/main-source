using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Restory.PostProcessing
{
	public class PauseGameStateBlurEffectApplier : MonoBehaviour
	{
		[SerializeField]
		private PostProcessingEffectType effect = PostProcessingEffectType.MainSceneBlurred;

		[SerializeField]
		private float effectSwitchDuration = 0.5f;

		private GlobalStateObserver globalStateObserver;

		private PostProcessingEffectsService postProcessingEffectsService;

		[Inject]
		private void Construct(GlobalStateObserver globalStateObserver, PostProcessingEffectsService postProcessingEffectsService)
		{
			this.postProcessingEffectsService = postProcessingEffectsService;
			this.globalStateObserver = globalStateObserver;
			if (base.isActiveAndEnabled)
			{
				globalStateObserver.AddSubscriber(this, ResolveStateChanged);
			}
		}

		private void OnEnable()
		{
			if (globalStateObserver != null)
			{
				globalStateObserver.AddSubscriber(this, ResolveStateChanged);
			}
		}

		private void OnDisable()
		{
			if (globalStateObserver != null)
			{
				globalStateObserver.RemoveSubscriber(this);
			}
		}

		private void ResolveStateChanged()
		{
			if (globalStateObserver.ActiveState is GamePauseState)
			{
				postProcessingEffectsService.TurnOnEffectAnimated(effect, effectSwitchDuration);
			}
			else
			{
				postProcessingEffectsService.TurnOffEffectAnimated(effect, effectSwitchDuration);
			}
		}
	}
}

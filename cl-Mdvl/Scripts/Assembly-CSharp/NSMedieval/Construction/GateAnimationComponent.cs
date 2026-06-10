using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.BuildingComponents;
using NSMedieval.Enums;
using NSMedieval.Extensions;
using NSMedieval.Sound;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.Construction
{
	public class GateAnimationComponent : MonoBehaviour
	{
		[SerializeField]
		private Animator defaultGateAnimator;

		[SerializeField]
		private Animator invertedGateAnimator;

		[SerializeField]
		private DoorComponent doorComponent;

		[SerializeField]
		private BaseBuildingViewComponent baseBuildingViewComponent;

		[SerializeField]
		private AudioEventsComponent audioEventsComponent;

		private DoorComponentInstance DoorComponentInstance => doorComponent.ComponentInstance;

		public void StartOpeningAnimation(float animationSpeedMultiplier)
		{
			if (DoorComponentInstance != null && !DoorComponentInstance.HasDisposed)
			{
				StartOpeningAnimation(animationSpeedMultiplier, defaultGateAnimator, inverted: false);
				StartOpeningAnimation(animationSpeedMultiplier, invertedGateAnimator, inverted: true);
			}
		}

		public void StartClosingAnimation(float animationDuration)
		{
			if (DoorComponentInstance != null && !DoorComponentInstance.HasDisposed && DoorComponentInstance.LockState != LockState.ForcedOpen)
			{
				StartClosingAnimation(animationDuration, defaultGateAnimator, inverted: false);
				StartClosingAnimation(animationDuration, invertedGateAnimator, inverted: true);
			}
		}

		public void AbortGateOpening()
		{
			if (DoorComponentInstance != null && !DoorComponentInstance.HasDisposed && DoorComponentInstance.LockState != LockState.ForcedOpen)
			{
				AbortGateOpening(defaultGateAnimator);
				AbortGateOpening(invertedGateAnimator);
			}
		}

		public void AbortGateClosing()
		{
			if (DoorComponentInstance != null && !DoorComponentInstance.HasDisposed && DoorComponentInstance.LockState != LockState.ForcedOpen)
			{
				AbortGateClosing(defaultGateAnimator);
				AbortGateClosing(invertedGateAnimator);
			}
		}

		public void SetOpenCloseAnim(bool isOpen)
		{
			if (isOpen)
			{
				StartOpeningAnimation(1f);
			}
			else
			{
				StartClosingAnimation(1f);
			}
		}

		public void OnDoorAnimationEvent(string eventName)
		{
			if (DoorComponentInstance == null || DoorComponentInstance.HasDisposed)
			{
				return;
			}
			using PooledDictionary<string, string> parameters = DictionaryPool<string, string>.GetJanitor();
			parameters.Add("Material", DoorComponentInstance.OwnerBuilding.Blueprint.SoundMaterialCategory.ToString());
			bool isEnabled;
			switch (eventName)
			{
			case "OpenStart":
			{
				audioEventsComponent.SetEventParameters(DoorComponentInstance.Blueprint.OpenAudioEventId, parameters);
				audioEventsComponent.PlayEventInstance(DoorComponentInstance.Blueprint.OpenAudioEventId);
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(20, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Doors\\GateAnimationComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(" Play ");
					messageBuilder.AppendFormatted(DoorComponentInstance.Blueprint.OpenAudioEventId);
					messageBuilder.AppendLiteral(". Parameters: ");
					messageBuilder.AppendFormatted(parameters.Values.ToPrettyString());
				}
				Log.Debug(messageBuilder);
				break;
			}
			case "OpenEnd":
				audioEventsComponent.KeyOffEventInstance(DoorComponentInstance.Blueprint.OpenAudioEventId);
				break;
			case "CloseStart":
			{
				audioEventsComponent.SetEventParameters(DoorComponentInstance.Blueprint.CloseAudioEventId, parameters);
				audioEventsComponent.PlayEventInstance(DoorComponentInstance.Blueprint.CloseAudioEventId);
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(20, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Doors\\GateAnimationComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(" Play ");
					messageBuilder.AppendFormatted(DoorComponentInstance.Blueprint.CloseAudioEventId);
					messageBuilder.AppendLiteral(". Parameters: ");
					messageBuilder.AppendFormatted(parameters.Values.ToPrettyString());
				}
				Log.Debug(messageBuilder);
				break;
			}
			case "CloseEnd":
				audioEventsComponent.KeyOffEventInstance(DoorComponentInstance.Blueprint.CloseAudioEventId);
				break;
			}
		}

		private static void EnableAndRegisterAnimator(Animator animator)
		{
			if (!animator.enabled)
			{
				animator.enabled = true;
				VillageManager.ActiveVillage?.Map?.AnimatorDisableManager.Register(animator);
			}
		}

		private void StartOpeningAnimation(float animationSpeedMultiplier, Animator animator, bool inverted)
		{
			if (!(animator == null))
			{
				EnableAndRegisterAnimator(animator);
				SetBoolIfHasParameter(animator, "open_abort", value: false);
				SetBoolIfHasParameter(animator, "close_abort", value: false);
				SetFloatIfHasParameter(animator, "Multiplier", animationSpeedMultiplier);
				SetBoolIfHasParameter(animator, "close", value: false);
				if (DoorComponentInstance.Blueprint.CanChangeDirection)
				{
					SetBoolIfHasParameter(animator, "front", inverted);
				}
				SetBoolIfHasParameter(animator, "open", value: true);
				VillageManager.ActiveVillage?.Map?.AnimatorDisableManager.OnAnimatorParamModified(animator);
			}
		}

		private void StartClosingAnimation(float animationDuration, Animator animator, bool inverted)
		{
			if (!(animator == null))
			{
				EnableAndRegisterAnimator(animator);
				SetBoolIfHasParameter(animator, "open_abort", value: false);
				SetBoolIfHasParameter(animator, "close_abort", value: false);
				SetBoolIfHasParameter(animator, "Speed", value: false);
				SetBoolIfHasParameter(animator, "open", value: false);
				if (DoorComponentInstance.Blueprint.CanChangeDirection)
				{
					SetBoolIfHasParameter(animator, "front", inverted);
				}
				SetBoolIfHasParameter(animator, "close", value: true);
				VillageManager.ActiveVillage?.Map?.AnimatorDisableManager.OnAnimatorParamModified(animator);
			}
		}

		private void AbortGateOpening(Animator animator)
		{
			if (!(animator == null))
			{
				EnableAndRegisterAnimator(animator);
				SetBoolIfHasParameter(animator, "close_abort", value: false);
				SetBoolIfHasParameter(animator, "open_abort", value: true);
				SetBoolIfHasParameter(animator, "open", value: false);
				SetBoolIfHasParameter(animator, "close", value: true);
				VillageManager.ActiveVillage?.Map?.AnimatorDisableManager.OnAnimatorParamModified(animator);
			}
		}

		private void AbortGateClosing(Animator animator)
		{
			if (!(animator == null))
			{
				EnableAndRegisterAnimator(animator);
				SetBoolIfHasParameter(animator, "open_abort", value: false);
				SetBoolIfHasParameter(animator, "close_abort", value: true);
				SetBoolIfHasParameter(animator, "close", value: false);
				SetBoolIfHasParameter(animator, "open", value: true);
				VillageManager.ActiveVillage?.Map?.AnimatorDisableManager.OnAnimatorParamModified(animator);
			}
		}

		private void SetBoolIfHasParameter(Animator animator, string parameterName, bool value)
		{
			if (animator.parameters.Any((AnimatorControllerParameter x) => x.name == parameterName))
			{
				animator.SetBool(parameterName, value);
			}
		}

		private void SetFloatIfHasParameter(Animator animator, string parameterName, float value)
		{
			if (animator.parameters.Any((AnimatorControllerParameter x) => x.name == parameterName))
			{
				animator.SetFloat(parameterName, value);
			}
		}

		private void Start()
		{
			if (defaultGateAnimator != null)
			{
				defaultGateAnimator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
				defaultGateAnimator.updateMode = AnimatorUpdateMode.Normal;
				defaultGateAnimator.speed = 1f;
				defaultGateAnimator.gameObject.AddComponent<AnimationEventForwarder>().target = base.gameObject;
			}
			if (invertedGateAnimator != null)
			{
				invertedGateAnimator.fireEvents = false;
			}
		}

		private void OnDisable()
		{
			AnimatorDisableManager animatorDisableManager = VillageManager.ActiveVillage?.Map?.AnimatorDisableManager;
			if (animatorDisableManager != null)
			{
				animatorDisableManager.Unregister(defaultGateAnimator);
				animatorDisableManager.Unregister(invertedGateAnimator);
			}
		}
	}
}

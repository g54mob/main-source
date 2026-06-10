using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval.Sound
{
	[RequireComponent(typeof(AudioEventsComponent), typeof(HumanoidView))]
	public class CombatAudioComponent : MonoBehaviour
	{
		private HumanAudioEventsComponent audioEventsComponent;

		private HumanoidView view;

		private void Awake()
		{
			audioEventsComponent = GetComponent<HumanAudioEventsComponent>();
			if (audioEventsComponent == null)
			{
				Log.Error("Audio events component is missing!", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CombatAudioComponent.cs");
				return;
			}
			view = GetComponent<HumanoidView>();
			if (view == null)
			{
				Log.Error("Audio view is missing!", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CombatAudioComponent.cs");
			}
		}

		public void PlayAttackSound(AnimationEvent evt)
		{
			if (!IsValidInstance() || !view.HumanoidInstance.IsMidStrike)
			{
				return;
			}
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(43, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CombatAudioComponent.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Event fired | Clip: ");
				messageBuilder.AppendFormatted(evt.animatorClipInfo.clip.name);
				messageBuilder.AppendLiteral(" | Time: ");
				messageBuilder.AppendFormatted(evt.time);
				messageBuilder.AppendLiteral(" IsMidStrike: ");
				messageBuilder.AppendFormatted(view.HumanoidInstance.IsMidStrike);
			}
			Log.Trace(messageBuilder);
			EquipmentInstance weapon = GetWeapon();
			if (!string.IsNullOrEmpty(weapon?.ActiveWeaponMode?.WeaponSound))
			{
				FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(19, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CombatAudioComponent.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendFormatted(weapon);
					messageBuilder2.AppendLiteral(" PlayAttackSound() ");
					messageBuilder2.AppendFormatted(weapon.ActiveWeaponMode.WeaponSound);
				}
				Log.Debug(messageBuilder2);
				audioEventsComponent.PlayEventInstance(weapon.ActiveWeaponMode.WeaponSound);
				return;
			}
			if (view is WorkerView workerView)
			{
				string activeToolName = workerView.GetActiveToolName();
				if (activeToolName == "training_bow_item")
				{
					audioEventsComponent.PlayEventInstance("ShootBow");
					return;
				}
				if (activeToolName == "training_sword_item")
				{
					audioEventsComponent.PlayEventInstance("SwordSlash");
					return;
				}
			}
			Log.Debug("PlayAttackSound() No Weapon!", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CombatAudioComponent.cs");
			audioEventsComponent.PlayEventInstance("FistSlash");
		}

		private EquipmentInstance GetWeapon()
		{
			if (!IsValidInstance())
			{
				return null;
			}
			EquipmentInstance weapon = CombatUtils.GetWeapon(view.HumanoidInstance);
			if (weapon == null)
			{
				return null;
			}
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(12, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\CombatAudioComponent.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(view.HumanoidInstance.Info.FirstName);
				messageBuilder.AppendLiteral(" has weapon ");
				messageBuilder.AppendFormatted(weapon.Blueprint.GetID());
			}
			Log.Trace(messageBuilder);
			return weapon;
		}

		private bool IsValidInstance()
		{
			HumanoidInstance humanoidInstance = view.HumanoidInstance;
			if (humanoidInstance == null)
			{
				return false;
			}
			if (humanoidInstance.HasDisposed || humanoidInstance.HasDied || humanoidInstance.HasFainted)
			{
				return false;
			}
			return true;
		}
	}
}

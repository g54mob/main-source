using JUTPS.CharacterBrain;
using JUTPS.Events;
using UnityEngine;

namespace JUTPS.AnimatorStateMachineBehaviours
{
	public class JUAnimationEvent : StateMachineBehaviour
	{
		public enum JUAnimDefaultEvents
		{
			None = 0,
			ReloadRightHandWeapon = 1,
			ReloadLeftHandWeapon = 2,
			EmitBulletShell = 3,
			DisableMovement = 4,
			EnableMovement = 5,
			DisableRotation = 6,
			EnableRotation = 7,
			DisableFireModeIK = 8,
			EnableFireModeIK = 9,
			StopRolling = 10,
			StartRolling = 11,
			ThrowItem = 12
		}

		public JUAnimDefaultEvents DefaultEvent;

		[Range(0f, 1f)]
		public float Duration;

		public string AnimationEventName = "Custom Animation Event";

		public float Delay;

		private JUCharacterBrain Controller;

		[HideInInspector]
		public bool CalledAnimationEvent;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			CalledAnimationEvent = false;
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (!(stateInfo.normalizedTime >= Duration) || CalledAnimationEvent)
			{
				return;
			}
			if (DefaultEvent != JUAnimDefaultEvents.None)
			{
				if (Controller == null)
				{
					Controller = animator.gameObject.GetComponent<JUCharacterBrain>();
				}
				if (Controller == null)
				{
					Debug.LogError("The [JU Animation Event] of [Animation State: " + stateInfo.ToString() + "] is a default JUController Animation Event, but could not find a JU Controller");
				}
				CallDefaultEvent(DefaultEvent, Controller);
			}
			else
			{
				JUAnimationEventReceiver component = animator.gameObject.GetComponent<JUAnimationEventReceiver>();
				if (component != null)
				{
					CallCustomEvent(AnimationEventName, component);
				}
				else
				{
					Debug.LogError("[Default Event : " + DefaultEvent.ToString() + "] There is no JU Animation Event Receiver on GameObject '" + animator.gameObject.name + "', if you wanted to create a custom Animation Event, add the component 'JUAnimationEventReceiver'");
				}
			}
			CalledAnimationEvent = true;
		}

		public static void CallDefaultEvent(JUAnimDefaultEvents DefaultEvent, JUCharacterBrain TargetController)
		{
			switch (DefaultEvent)
			{
			case JUAnimDefaultEvents.None:
				Debug.LogWarning("None Event To Call");
				break;
			case JUAnimDefaultEvents.ReloadRightHandWeapon:
				TargetController.reloadRightHandWeapon();
				break;
			case JUAnimDefaultEvents.ReloadLeftHandWeapon:
				TargetController.reloadLeftHandWeapon();
				break;
			case JUAnimDefaultEvents.EmitBulletShell:
				TargetController.emitBulletShell();
				break;
			case JUAnimDefaultEvents.DisableMovement:
				TargetController.disableMove();
				break;
			case JUAnimDefaultEvents.EnableMovement:
				TargetController.enableMove();
				break;
			case JUAnimDefaultEvents.DisableRotation:
				TargetController.disableRotation();
				break;
			case JUAnimDefaultEvents.EnableRotation:
				TargetController.enableRotation();
				break;
			case JUAnimDefaultEvents.DisableFireModeIK:
				TargetController.disableFireModeIK();
				break;
			case JUAnimDefaultEvents.EnableFireModeIK:
				TargetController.enableFireModeIK();
				break;
			case JUAnimDefaultEvents.StopRolling:
				TargetController.stopRolling();
				break;
			case JUAnimDefaultEvents.StartRolling:
				TargetController.startRolling();
				break;
			case JUAnimDefaultEvents.ThrowItem:
				TargetController._ThrowCurrentThrowableItem();
				break;
			}
		}

		public static void CallCustomEvent(string EventName, JUAnimationEventReceiver Receiver)
		{
			Receiver.CallEvent(EventName);
		}
	}
}

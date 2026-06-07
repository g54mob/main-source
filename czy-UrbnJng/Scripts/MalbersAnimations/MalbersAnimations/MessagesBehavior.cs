using System.Linq;
using MalbersAnimations.Utilities;
using UnityEngine;
using UnityEngine.Animations;

namespace MalbersAnimations
{
	public class MessagesBehavior : StateMachineBehaviour
	{
		public bool UseSendMessage;

		public bool SendToChildren;

		public bool debug;

		public bool NormalizeTime = true;

		public MesssageItem[] onEnterMessage;

		public MesssageItem[] onExitMessage;

		public MesssageItem[] onTimeMessage;

		private IAnimatorListener[] listeners;

		private bool firstime;

		public bool OnEnter = true;

		public bool OnExit = true;

		public bool OnTime = true;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (!firstime)
			{
				if (SendToChildren)
				{
					listeners = animator.GetComponentsInChildren<IAnimatorListener>();
				}
				else
				{
					listeners = animator.GetComponents<IAnimatorListener>();
				}
				firstime = true;
			}
			if (OnTime)
			{
				MesssageItem[] array = onTimeMessage;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].sent = false;
				}
			}
			if (OnEnter)
			{
				MesssageItem[] array = onEnterMessage;
				foreach (MesssageItem onExitM in array)
				{
					SendAnimatorMessage(animator, onExitM);
				}
			}
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
		{
			MesssageItem[] array;
			if (OnExit)
			{
				array = onExitMessage;
				foreach (MesssageItem onExitM in array)
				{
					if (animator.GetCurrentAnimatorStateInfo(layerIndex).fullPathHash == stateInfo.fullPathHash && onEnterMessage != null && onEnterMessage.Length != 0 && onEnterMessage.ToList().Exists((MesssageItem x) => x.message == onExitM.message))
					{
						return;
					}
					SendAnimatorMessage(animator, onExitM);
				}
			}
			if (!OnTime)
			{
				return;
			}
			array = onTimeMessage;
			foreach (MesssageItem messsageItem in array)
			{
				if (!messsageItem.sent)
				{
					messsageItem.sent = true;
					SendAnimatorMessage(animator, messsageItem);
				}
			}
		}

		private void SendAnimatorMessage(Animator animator, MesssageItem onExitM)
		{
			if (UseSendMessage)
			{
				onExitM.DeliverMessage(animator, SendToChildren, debug);
			}
			else if (listeners != null && listeners.Length != 0)
			{
				IAnimatorListener[] array = listeners;
				foreach (IAnimatorListener listener in array)
				{
					onExitM.DeliverAnimListener(listener, debug);
				}
			}
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (!OnTime || stateInfo.fullPathHash == animator.GetNextAnimatorStateInfo(layerIndex).fullPathHash)
			{
				return;
			}
			MesssageItem[] array = onTimeMessage;
			foreach (MesssageItem messsageItem in array)
			{
				float num = (NormalizeTime ? (stateInfo.normalizedTime % 1f) : stateInfo.normalizedTime);
				if (!messsageItem.sent && num >= messsageItem.time)
				{
					messsageItem.sent = true;
					SendAnimatorMessage(animator, messsageItem);
				}
			}
		}
	}
}

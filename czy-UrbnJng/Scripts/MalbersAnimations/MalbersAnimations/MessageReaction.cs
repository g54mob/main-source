using System;
using MalbersAnimations.Reactions;
using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	[AddTypeMenu("Unity/Messages", 0)]
	public class MessageReaction : Reaction
	{
		[Tooltip("Send Messages also to the Component Children")]
		public bool sendToChildren = true;

		[Tooltip("Use Component.SendMessage Instead of ")]
		public bool UseSendMessage;

		public MesssageItem[] messages;

		public bool debug;

		public override Type ReactionType => typeof(Component);

		protected override bool _TryReact(Component reactor)
		{
			MesssageItem[] array = messages;
			foreach (MesssageItem m in array)
			{
				Deliver(m, reactor);
			}
			return true;
		}

		private void Deliver(MesssageItem m, Component go)
		{
			if (UseSendMessage)
			{
				m.DeliverMessage(go, sendToChildren, debug);
				return;
			}
			IAnimatorListener[] array = ((!sendToChildren) ? go.GetComponentsInParent<IAnimatorListener>() : go.GetComponentsInChildren<IAnimatorListener>());
			if (array != null && array.Length != 0)
			{
				IAnimatorListener[] array2 = array;
				foreach (IAnimatorListener listener in array2)
				{
					m.DeliverAnimListener(listener, debug);
				}
			}
		}
	}
}

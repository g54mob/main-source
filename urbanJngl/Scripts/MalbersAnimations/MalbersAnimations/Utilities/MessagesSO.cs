using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[CreateAssetMenu(menuName = "Malbers Animations/Message", fileName = "New Message", order = 3001)]
	public class MessagesSO : ScriptableObject
	{
		public List<MesssageItem> messages;

		public bool UseSendMessage = true;

		public bool SendToChildren;

		public bool debug;

		private IAnimatorListener[] listeners;

		public virtual void SendMessage(GameObject component)
		{
			SendMessage(component.transform);
		}

		public virtual void SendMessage(Component go)
		{
			foreach (MesssageItem message in messages)
			{
				if (message.message == string.Empty || !message.Active)
				{
					break;
				}
				Deliver(message, go);
			}
		}

		private void Deliver(MesssageItem m, Component go)
		{
			if (UseSendMessage)
			{
				m.DeliverMessage(go.transform.root, SendToChildren, debug);
				return;
			}
			if (SendToChildren)
			{
				listeners = go.GetComponentsInChildren<IAnimatorListener>();
			}
			else
			{
				listeners = go.GetComponents<IAnimatorListener>();
			}
			if (listeners != null && listeners.Length != 0)
			{
				IAnimatorListener[] array = listeners;
				foreach (IAnimatorListener listener in array)
				{
					m.DeliverAnimListener(listener, debug);
				}
			}
		}
	}
}

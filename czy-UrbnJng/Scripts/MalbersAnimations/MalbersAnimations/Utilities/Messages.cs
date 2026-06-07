using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Events/Messages")]
	public class Messages : MonoBehaviour
	{
		public MesssageItem[] messages;

		public bool UseSendMessage = true;

		public bool SendToChildren = true;

		public bool debug = true;

		public bool nextFrame;

		public Component Pinned;

		public virtual void SendMessage(GameObject component)
		{
			SendMessage(component.transform);
		}

		public virtual void Pin_Receiver(GameObject component)
		{
			Pinned = component.transform;
		}

		public virtual void Pin_Receiver(Component component)
		{
			Pinned = component;
		}

		public virtual void SendMessage(int index)
		{
			if (nextFrame)
			{
				this.Delay_Action(delegate
				{
					Deliver(messages[index], Pinned);
				});
			}
			else
			{
				Deliver(messages[index], Pinned);
			}
		}

		public virtual void SendMessageByIndex(int index)
		{
			SendMessage(index);
		}

		public virtual void SendMessage(Component go)
		{
			IObjectCore objectCore = go.FindInterface<IObjectCore>(includeInactive: false);
			Pinned = ((objectCore != null) ? objectCore.transform : go);
			MesssageItem[] array = messages;
			foreach (MesssageItem m in array)
			{
				if (nextFrame)
				{
					this.Delay_Action(delegate
					{
						Deliver(m, Pinned);
					});
				}
				else
				{
					Deliver(m, Pinned);
				}
			}
		}

		private void Deliver(MesssageItem m, Component go)
		{
			if (UseSendMessage)
			{
				m.DeliverMessage(go, SendToChildren, debug);
				return;
			}
			IAnimatorListener[] array = ((!SendToChildren) ? go.GetComponentsInParent<IAnimatorListener>() : go.GetComponentsInChildren<IAnimatorListener>());
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

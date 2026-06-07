using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[Serializable]
	public class MesssageItem
	{
		public string message;

		public TypeMessage typeM;

		public bool boolValue;

		public int intValue;

		public float floatValue;

		public string stringValue;

		public IntVar intVarValue;

		public Transform transformValue;

		public GameObject GoValue;

		public Component ComponentValue;

		public float time;

		public bool sent;

		public bool Active = true;

		public bool IsActive
		{
			get
			{
				if (Active)
				{
					return !string.IsNullOrEmpty(message);
				}
				return false;
			}
		}

		public MesssageItem()
		{
			message = string.Empty;
			Active = true;
		}

		public void DeliverAnimListener(IAnimatorListener listener, bool debug = false)
		{
			if (IsActive)
			{
				string arg = "";
				bool flag = false;
				switch (typeM)
				{
				case TypeMessage.Bool:
					flag = listener.OnAnimatorBehaviourMessage(message, boolValue);
					arg = boolValue.ToString();
					break;
				case TypeMessage.Int:
					flag = listener.OnAnimatorBehaviourMessage(message, intValue);
					arg = intValue.ToString();
					break;
				case TypeMessage.Float:
					flag = listener.OnAnimatorBehaviourMessage(message, floatValue);
					arg = floatValue.ToString();
					break;
				case TypeMessage.String:
					flag = listener.OnAnimatorBehaviourMessage(message, stringValue);
					arg = stringValue.ToString();
					break;
				case TypeMessage.Void:
					flag = listener.OnAnimatorBehaviourMessage(message, null);
					arg = "Void";
					break;
				case TypeMessage.IntVar:
					flag = listener.OnAnimatorBehaviourMessage(message, (int)intVarValue);
					arg = intVarValue.name.ToString();
					break;
				case TypeMessage.Transform:
					flag = listener.OnAnimatorBehaviourMessage(message, transformValue);
					arg = transformValue.name.ToString();
					break;
				case TypeMessage.GameObject:
					flag = listener.OnAnimatorBehaviourMessage(message, GoValue);
					arg = GoValue.name.ToString();
					break;
				case TypeMessage.Component:
					flag = listener.OnAnimatorBehaviourMessage(message, ComponentValue);
					arg = GoValue.name.ToString();
					break;
				}
				if (debug && flag)
				{
					Debug.Log($"<b>Anim Message: [<color=yellow>{message}->{arg}</color>]</b> T:{Time.time:F2}", listener.transform);
				}
			}
		}

		public void DeliverMessage(Component anim, bool SendToChildren, bool debug = false)
		{
			if (IsActive)
			{
				switch (typeM)
				{
				case TypeMessage.Bool:
					SendMessage(anim, message, boolValue, SendToChildren);
					break;
				case TypeMessage.Int:
					SendMessage(anim, message, intValue, SendToChildren);
					break;
				case TypeMessage.Float:
					SendMessage(anim, message, floatValue, SendToChildren);
					break;
				case TypeMessage.String:
					SendMessage(anim, message, stringValue, SendToChildren);
					break;
				case TypeMessage.Void:
					SendMessageVoid(anim, message, SendToChildren);
					break;
				case TypeMessage.IntVar:
					SendMessage(anim, message, (int)intVarValue, SendToChildren);
					break;
				case TypeMessage.Transform:
					SendMessage(anim, message, transformValue, SendToChildren);
					break;
				case TypeMessage.GameObject:
					SendMessage(anim, message, GoValue, SendToChildren);
					break;
				case TypeMessage.Component:
					SendMessage(anim, message, ComponentValue, SendToChildren);
					break;
				}
				if (debug)
				{
					Debug.Log($"<b>[Send Msg: {message}->] [{typeM}]</b> T:{Time.time:F3}", anim);
				}
			}
		}

		private void SendMessage(Component anim, string message, object value, bool SendToChildren)
		{
			if (SendToChildren)
			{
				anim.BroadcastMessage(message, value, SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				anim.SendMessage(message, value, SendMessageOptions.DontRequireReceiver);
			}
		}

		private void SendMessageVoid(Component anim, string message, bool SendToChildren)
		{
			if (SendToChildren)
			{
				anim.BroadcastMessage(message, SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				anim.SendMessage(message, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}

using System.Collections.Generic;
using UnityEngine;

namespace DV.Utils
{
	public class ReliableOnTriggerExit : MonoBehaviour
	{
		public delegate void _OnTriggerExit(Collider c);

		private Collider thisCollider;

		private bool ignoreNotifyTriggerExit;

		private Dictionary<GameObject, _OnTriggerExit> waitingForOnTriggerExit = new Dictionary<GameObject, _OnTriggerExit>();

		public static void NotifyTriggerEnter(Collider c, GameObject caller, _OnTriggerExit onTriggerExit)
		{
			ReliableOnTriggerExit reliableOnTriggerExit = null;
			ReliableOnTriggerExit[] components = c.gameObject.GetComponents<ReliableOnTriggerExit>();
			foreach (ReliableOnTriggerExit reliableOnTriggerExit2 in components)
			{
				if (reliableOnTriggerExit2.thisCollider == c)
				{
					reliableOnTriggerExit = reliableOnTriggerExit2;
					break;
				}
			}
			if (reliableOnTriggerExit == null)
			{
				reliableOnTriggerExit = c.gameObject.AddComponent<ReliableOnTriggerExit>();
				reliableOnTriggerExit.thisCollider = c;
			}
			if (!reliableOnTriggerExit.waitingForOnTriggerExit.ContainsKey(caller))
			{
				reliableOnTriggerExit.waitingForOnTriggerExit.Add(caller, onTriggerExit);
				reliableOnTriggerExit.enabled = true;
			}
			else
			{
				reliableOnTriggerExit.ignoreNotifyTriggerExit = true;
				reliableOnTriggerExit.waitingForOnTriggerExit[caller](c);
				reliableOnTriggerExit.ignoreNotifyTriggerExit = false;
			}
		}

		public static void NotifyTriggerExit(Collider c, GameObject caller)
		{
			if (c == null)
			{
				return;
			}
			ReliableOnTriggerExit reliableOnTriggerExit = null;
			ReliableOnTriggerExit[] components = c.gameObject.GetComponents<ReliableOnTriggerExit>();
			foreach (ReliableOnTriggerExit reliableOnTriggerExit2 in components)
			{
				if (reliableOnTriggerExit2.thisCollider == c)
				{
					reliableOnTriggerExit = reliableOnTriggerExit2;
					break;
				}
			}
			if (reliableOnTriggerExit != null && !reliableOnTriggerExit.ignoreNotifyTriggerExit)
			{
				reliableOnTriggerExit.waitingForOnTriggerExit.Remove(caller);
				if (reliableOnTriggerExit.waitingForOnTriggerExit.Count == 0)
				{
					reliableOnTriggerExit.enabled = false;
				}
			}
		}

		private void OnDisable()
		{
			if (!UnloadWatcher.isUnloading)
			{
				CallCallbacks();
			}
		}

		private void Update()
		{
			if (thisCollider == null)
			{
				try
				{
					CallCallbacks();
					return;
				}
				finally
				{
					Object.Destroy(this);
				}
			}
			if (!thisCollider.enabled)
			{
				CallCallbacks();
			}
		}

		private void CallCallbacks()
		{
			ignoreNotifyTriggerExit = true;
			foreach (KeyValuePair<GameObject, _OnTriggerExit> item in waitingForOnTriggerExit)
			{
				if (!(item.Key == null))
				{
					item.Value(thisCollider);
				}
			}
			ignoreNotifyTriggerExit = false;
			waitingForOnTriggerExit.Clear();
			base.enabled = false;
		}
	}
}

using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	public class TriggerTarget : MonoBehaviour
	{
		public Collider m_collider;

		public List<TriggerProxy> Proxies;

		public static List<TriggerTarget> set;

		private void Awake()
		{
			if (set == null)
			{
				set = new List<TriggerTarget>();
			}
			base.hideFlags = HideFlags.HideInInspector;
		}

		private void OnEnable()
		{
			set.Add(this);
		}

		private void OnDisable()
		{
			if (Proxies != null)
			{
				foreach (TriggerProxy proxy in Proxies)
				{
					if (proxy != null)
					{
						proxy.RemoveTrigger(m_collider, remove: false);
					}
				}
			}
			Proxies = new List<TriggerProxy>();
			set.Remove(this);
		}

		public void AddProxy(TriggerProxy trigger, Collider col)
		{
			if (Proxies == null)
			{
				Proxies = new List<TriggerProxy>();
			}
			Proxies.Add(trigger);
			m_collider = col;
		}

		public void RemoveProxy(TriggerProxy trigger)
		{
			Proxies.Remove(trigger);
		}
	}
}

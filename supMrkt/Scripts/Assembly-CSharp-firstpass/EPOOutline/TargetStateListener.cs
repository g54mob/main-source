using System;
using System.Collections.Generic;
using UnityEngine;

namespace EPOOutline
{
	[ExecuteAlways]
	public class TargetStateListener : MonoBehaviour
	{
		public struct Callback
		{
			public readonly Outlinable Target;

			public readonly Action Action;

			public Callback(Outlinable target, Action action)
			{
				Target = null;
				Action = null;
			}
		}

		private List<Callback> callbacks;

		private static readonly Predicate<Callback> _nullTargetPredicate;

		public void AddCallback(Outlinable outlinable, Action action)
		{
		}

		public void RemoveCallback(Outlinable outlinable, Action callback)
		{
		}

		private void Awake()
		{
		}

		public void ForceUpdate()
		{
		}

		private void OnBecameVisible()
		{
		}

		private void OnBecameInvisible()
		{
		}
	}
}

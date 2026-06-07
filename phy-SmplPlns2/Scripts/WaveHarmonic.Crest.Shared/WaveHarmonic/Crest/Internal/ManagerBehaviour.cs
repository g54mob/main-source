using System;
using System.Collections.Generic;
using UnityEngine;

namespace WaveHarmonic.Crest.Internal
{
	public abstract class ManagerBehaviour<T> : CustomBehaviour where T : ManagerBehaviour<T>
	{
		internal static readonly List<Action<T>> s_OnUpdate = new List<Action<T>>();

		internal static readonly List<Action<T>> s_OnLateUpdate = new List<Action<T>>();

		internal static readonly List<Action<T>> s_OnFixedUpdate = new List<Action<T>>();

		internal static readonly List<Action<T>> s_OnEnable = new List<Action<T>>();

		internal static readonly List<Action<T>> s_OnDisable = new List<Action<T>>();

		public static T Instance { get; private set; }

		private void Broadcast(List<Action<T>> listeners, T instance)
		{
			for (int num = listeners.Count - 1; num >= 0; num--)
			{
				listeners[num](instance);
			}
		}

		private void Broadcast(List<Action<T>> listeners)
		{
			Broadcast(listeners, Instance);
		}

		private protected virtual void Enable()
		{
			Instance = (T)this;
			Broadcast(s_OnEnable);
		}

		private protected virtual void Disable()
		{
			Broadcast(s_OnDisable);
			Instance = null;
		}

		private protected virtual void FixedUpdate()
		{
			Broadcast(s_OnFixedUpdate);
		}

		private protected void BroadcastUpdate()
		{
			Broadcast(s_OnUpdate);
		}

		private protected virtual void LateUpdate()
		{
			Broadcast(s_OnLateUpdate);
		}

		internal static void AfterRuntimeLoad()
		{
			Instance = null;
		}

		internal static void AfterScriptReload()
		{
			Instance = UnityEngine.Object.FindAnyObjectByType<T>();
		}
	}
}

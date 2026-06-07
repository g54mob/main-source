using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations
{
	public abstract class ScriptableCoroutine : ScriptableObject
	{
		internal Dictionary<Component, IEnumerator> Coroutine;

		internal void StartCoroutine(Component component, IEnumerator ICoroutine)
		{
			if (Coroutine == null)
			{
				Coroutine = new Dictionary<Component, IEnumerator>();
			}
			if (!Coroutine.ContainsKey(component))
			{
				Coroutine.Add(component, ICoroutine);
				MScriptableCoroutine.PlayCoroutine(this, ICoroutine);
			}
		}

		internal virtual void Stop(Component component)
		{
			if (Coroutine != null && Coroutine.TryGetValue(component, out var value))
			{
				MScriptableCoroutine.Stop_Coroutine(value);
				Coroutine.Remove(component);
			}
		}

		internal abstract void Evaluate(MonoBehaviour mono, Transform target, float time, AnimationCurve curve);

		internal virtual void CleanCoroutine()
		{
			if (Coroutine != null)
			{
				foreach (KeyValuePair<Component, IEnumerator> item in Coroutine)
				{
					ExitValue(item.Key);
				}
			}
			Coroutine = null;
		}

		internal virtual void ExitValue(Component compoennt)
		{
		}
	}
}

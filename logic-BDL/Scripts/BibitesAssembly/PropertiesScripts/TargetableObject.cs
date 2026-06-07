using System;
using UnityEngine;
using UnityEngine.Events;

namespace PropertiesScripts
{
	public class TargetableObject : MonoBehaviour
	{
		[NonSerialized]
		public readonly UnityEvent onDestroy = new UnityEvent();

		public static bool CanInvoke = true;

		private void OnDestroy()
		{
			if (CanInvoke)
			{
				onDestroy.Invoke();
			}
		}
	}
}

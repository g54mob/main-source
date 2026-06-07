using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gh.Tk
{
	public class AnimUnityEvent : MonoBehaviour
	{
		public string eventName;

		public List<UnityEvent> unityEvents;

		public void InvokeUnityEvent(string name)
		{
		}
	}
}

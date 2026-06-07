using System;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public class OnEnterExitSpeed
	{
		[Tooltip("Which is the Speed Set (By its Name) changed. Case Sensitive")]
		public string SpeedSet;

		[Tooltip("Which is the Speed Modifier (By its Name) changed. This is Ignored if is set to 1. Case Sensitive")]
		public int SpeedIndex;

		public UnityEvent OnEnter;

		public UnityEvent OnExit;
	}
}

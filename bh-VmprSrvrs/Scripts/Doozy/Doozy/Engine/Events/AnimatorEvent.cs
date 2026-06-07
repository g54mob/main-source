using System;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.Events
{
	[Serializable]
	public class AnimatorEvent
	{
		public enum ParameterType
		{
			Bool = 0,
			Float = 1,
			Int = 2,
			Trigger = 3
		}

		public Animator Animator;

		public bool BoolValue;

		public float FloatValue;

		public int IntValue;

		public string ParameterName;

		public bool ResetTrigger;

		public ParameterType TargetParameterType;

		public AnimatorEvent()
		{
		}

		public AnimatorEvent(Animator animator, string parameterName, bool boolValue)
		{
		}

		public AnimatorEvent(Animator animator, string parameterName, int intValue)
		{
		}

		public AnimatorEvent(Animator animator, string parameterName, float floatValue)
		{
		}

		public AnimatorEvent(Animator animator, string parameterName)
		{
		}

		public void Invoke(UnityAction<bool> callback = null)
		{
		}

		public void Reset()
		{
		}

		public void SetValue()
		{
		}

		private static void InvokeCallback(UnityAction<bool> callback, bool value)
		{
		}
	}
}

using System;
using MalbersAnimations.Scriptables;
using UnityEngine.Events;

namespace MalbersAnimations
{
	[Serializable]
	public class AdvancedBoolEvent
	{
		public bool active = true;

		public string name;

		public ComparerBool comparer;

		public BoolReference Value = new BoolReference();

		public UnityEvent Response = new UnityEvent();

		public void ExecuteAdvanceBoolEvent(bool boolValue)
		{
			if (!active)
			{
				return;
			}
			switch (comparer)
			{
			case ComparerBool.Equal:
				if (boolValue == (bool)Value)
				{
					Response.Invoke();
				}
				break;
			case ComparerBool.NotEqual:
				if (boolValue != (bool)Value)
				{
					Response.Invoke();
				}
				break;
			}
		}

		public void SetValue(bool value)
		{
			Value.Value = value;
		}
	}
}

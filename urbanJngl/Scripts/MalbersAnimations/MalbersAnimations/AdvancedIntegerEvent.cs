using System;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	public class AdvancedIntegerEvent
	{
		public bool active = true;

		public string name;

		public string description;

		public ComparerInt comparer;

		public IntReference Value = new IntReference();

		public IntEvent Response = new IntEvent();

		[Tooltip("Update the value of the comparer with the incoming Master Value after the comparison")]
		public bool UpdateAfterCompare;

		public void ExecuteAdvanceIntegerEvent(int IntValue)
		{
			if (!active)
			{
				return;
			}
			switch (comparer)
			{
			case ComparerInt.Equal:
				if (IntValue == (int)Value)
				{
					Response.Invoke(IntValue);
				}
				break;
			case ComparerInt.Greater:
				if (IntValue > (int)Value)
				{
					Response.Invoke(IntValue);
				}
				break;
			case ComparerInt.Less:
				if (IntValue < (int)Value)
				{
					Response.Invoke(IntValue);
				}
				break;
			case ComparerInt.NotEqual:
				if (IntValue != (int)Value)
				{
					Response.Invoke(IntValue);
				}
				break;
			}
			if (UpdateAfterCompare)
			{
				Value.Value = IntValue;
			}
		}

		public void SetValue(int value)
		{
			Value.Value = value;
		}

		public AdvancedIntegerEvent()
		{
			active = true;
			name = "NameHere";
			description = "";
			comparer = ComparerInt.Equal;
			Value = new IntReference();
			Response = new IntEvent();
		}
	}
}

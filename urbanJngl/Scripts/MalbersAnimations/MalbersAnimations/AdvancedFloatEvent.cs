using System;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	public class AdvancedFloatEvent
	{
		public bool active = true;

		public string name;

		public string description;

		public ComparerInt comparer;

		public FloatReference Value = new FloatReference();

		public FloatEvent Response = new FloatEvent();

		[Tooltip("Update the value of the comparer with the incoming Master Value after the comparison")]
		public bool UpdateAfterCompare;

		public void ExecuteAdvanceFloatEvent(float v)
		{
			if (!active)
			{
				return;
			}
			switch (comparer)
			{
			case ComparerInt.Equal:
				if (v == (float)Value)
				{
					Response.Invoke(v);
				}
				break;
			case ComparerInt.Greater:
				if (v > (float)Value)
				{
					Response.Invoke(v);
				}
				break;
			case ComparerInt.Less:
				if (v < (float)Value)
				{
					Response.Invoke(v);
				}
				break;
			case ComparerInt.NotEqual:
				if (v != (float)Value)
				{
					Response.Invoke(v);
				}
				break;
			}
			if (UpdateAfterCompare)
			{
				Value.Value = v;
			}
		}

		public void SetValue(float value)
		{
			Value.Value = value;
		}
	}
}

using System;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations
{
	[Serializable]
	public class AdvancedStringEvent
	{
		public bool active = true;

		public string name;

		public string description;

		public ComparerString comparer;

		public StringReference Value = new StringReference();

		public StringEvent Response = new StringEvent();

		public UnityEvent OnTrue = new UnityEvent();

		public UnityEvent OnFalse = new UnityEvent();

		[Tooltip("Update the value of the comparer with the incoming Master Value after the comparison")]
		public bool UpdateAfterCompare;

		public bool ExecuteAdvanceStringEvent(string val)
		{
			return comparer switch
			{
				ComparerString.Equal => StringComparisonResult(val, val == Value.Value), 
				ComparerString.NotEqual => StringComparisonResult(val, val != Value.Value), 
				ComparerString.Empty => StringComparisonResult(val, string.IsNullOrEmpty(val)), 
				ComparerString.Contains => StringComparisonResult(val, val.Contains(Value.Value)), 
				ComparerString.DoesNotContains => StringComparisonResult(val, !val.Contains(Value.Value)), 
				_ => false, 
			};
		}

		private bool StringComparisonResult(string value, bool result)
		{
			Response.Invoke(value);
			if (result)
			{
				OnTrue.Invoke();
			}
			else
			{
				OnFalse.Invoke();
			}
			if (UpdateAfterCompare)
			{
				Value.Value = value;
			}
			return result;
		}

		public void SetValue(string value)
		{
			Value.Value = value;
		}
	}
}

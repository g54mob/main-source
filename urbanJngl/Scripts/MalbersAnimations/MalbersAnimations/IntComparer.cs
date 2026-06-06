using System;
using System.Collections.Generic;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Variables/Int Comparer")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/secondary-components/variable-listeners-and-comparers")]
	public class IntComparer : IntVarListener
	{
		public List<AdvancedIntegerEvent> compare = new List<AdvancedIntegerEvent>();

		public IntEvent OnValueChanged = new IntEvent();

		private AdvancedIntegerEvent Pin;

		public int SetCompareFirstValue
		{
			get
			{
				return compare[0].Value.Value;
			}
			set
			{
				compare[0].Value.Value = value;
			}
		}

		public override int Value
		{
			set
			{
				base.Value = value;
				if (Auto)
				{
					OnValueChanged.Invoke(value);
					Compare();
				}
			}
		}

		public int this[int index]
		{
			get
			{
				return compare[index].Value.Value;
			}
			set
			{
				compare[index].Value.Value = value;
			}
		}

		public void Pin_Comparer(int index)
		{
			Pin = compare[index];
		}

		public void Pin_Comparer_SetValue(int value)
		{
			Pin?.SetValue(value);
		}

		public void Pin_Comparer_SetValue(float value)
		{
			Pin?.SetValue((int)value);
		}

		public void Pin_Comparer_SetValue(IntVar value)
		{
			Pin?.SetValue(value.Value);
		}

		public void Pin_Comparer_SetValue(IDs value)
		{
			Pin?.SetValue(value.ID);
		}

		public void AddWithBool(bool value)
		{
			SetValue(value ? (Value + 1) : (Value - 1));
		}

		private void OnEnable()
		{
			if ((bool)value.Variable && Auto)
			{
				IntVar variable = value.Variable;
				variable.OnValueChanged = (Action<int>)Delegate.Combine(variable.OnValueChanged, new Action<int>(Compare));
				IntVar variable2 = value.Variable;
				variable2.OnValueChanged = (Action<int>)Delegate.Combine(variable2.OnValueChanged, new Action<int>(Invoke));
			}
			Raise.Invoke(Value);
		}

		private void OnDisable()
		{
			if ((bool)value.Variable && Auto)
			{
				IntVar variable = value.Variable;
				variable.OnValueChanged = (Action<int>)Delegate.Remove(variable.OnValueChanged, new Action<int>(Compare));
				IntVar variable2 = value.Variable;
				variable2.OnValueChanged = (Action<int>)Delegate.Remove(variable2.OnValueChanged, new Action<int>(Invoke));
			}
		}

		private void Reset()
		{
			compare = new List<AdvancedIntegerEvent>
			{
				new AdvancedIntegerEvent
				{
					Value = new IntReference(0),
					active = true,
					comparer = ComparerInt.Equal,
					name = "Compare"
				}
			};
		}

		public void Value_Add(int value)
		{
			Value += value;
		}

		public void Value_Substract(int value)
		{
			Value -= value;
		}

		public void Value_Multiply(int value)
		{
			Value *= value;
		}

		public void Value_Divide(int value)
		{
			Value /= value;
		}

		public virtual void Compare()
		{
			if (!base.enabled)
			{
				return;
			}
			foreach (AdvancedIntegerEvent item in compare)
			{
				item.ExecuteAdvanceIntegerEvent(value);
			}
		}

		public virtual void Compare(int value)
		{
			if (!base.enabled)
			{
				return;
			}
			foreach (AdvancedIntegerEvent item in compare)
			{
				item.ExecuteAdvanceIntegerEvent(value);
			}
		}

		public virtual void Compare(IntVar value)
		{
			if (!base.enabled)
			{
				return;
			}
			foreach (AdvancedIntegerEvent item in compare)
			{
				item.ExecuteAdvanceIntegerEvent(value.Value);
			}
		}

		public void Index_Disable(int index)
		{
			compare[index].active = false;
		}

		public void Index_Enable(int index)
		{
			compare[index].active = true;
		}
	}
}

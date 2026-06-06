using System;
using System.Collections.Generic;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Variables/Float Comparer")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/secondary-components/variable-listeners-and-comparers")]
	public class FloatComparer : FloatVarListener
	{
		public List<AdvancedFloatEvent> compare = new List<AdvancedFloatEvent>();

		private AdvancedFloatEvent Pin;

		public FloatEvent OnValueChanged = new FloatEvent();

		public float SetCompareFirstValue
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

		public override float Value
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

		public float this[int index]
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

		public void Pin_Comparer_SetValue(float value)
		{
			if (Pin != null)
			{
				Pin.Value.Value = value;
			}
		}

		public void Pin_Comparer_SetValue(FloatVar value)
		{
			if (Pin != null)
			{
				Pin.Value.Value = value;
			}
		}

		private void OnEnable()
		{
			if ((bool)value.Variable && Auto)
			{
				Debug.Log("auto = ", this);
				FloatVar variable = value.Variable;
				variable.OnValueChanged = (Action<float>)Delegate.Combine(variable.OnValueChanged, new Action<float>(Compare));
				FloatVar variable2 = value.Variable;
				variable2.OnValueChanged = (Action<float>)Delegate.Combine(variable2.OnValueChanged, new Action<float>(Invoke));
			}
			Raise.Invoke(Value);
		}

		private void OnDisable()
		{
			if ((bool)value.Variable && Auto)
			{
				FloatVar variable = value.Variable;
				variable.OnValueChanged = (Action<float>)Delegate.Remove(variable.OnValueChanged, new Action<float>(Compare));
				FloatVar variable2 = value.Variable;
				variable2.OnValueChanged = (Action<float>)Delegate.Remove(variable2.OnValueChanged, new Action<float>(Invoke));
			}
		}

		public virtual void Compare()
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			foreach (AdvancedFloatEvent item in compare)
			{
				item.ExecuteAdvanceFloatEvent(value);
			}
		}

		public virtual void Compare(float value)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			foreach (AdvancedFloatEvent item in compare)
			{
				item.ExecuteAdvanceFloatEvent(value);
			}
		}

		public virtual void Compare(FloatVar value)
		{
			if (!base.enabled)
			{
				return;
			}
			foreach (AdvancedFloatEvent item in compare)
			{
				item.ExecuteAdvanceFloatEvent(value.Value);
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

		public void Index_Enable_Only(int index)
		{
			compare[index].active = true;
			for (int i = 0; i < compare.Count; i++)
			{
				if (i != index)
				{
					compare[i].active = false;
				}
			}
		}

		public void Index_Disable_Only(int index)
		{
			compare[index].active = false;
			for (int i = 0; i < compare.Count; i++)
			{
				if (i != index)
				{
					compare[i].active = true;
				}
			}
		}

		public void SetRandomValue01()
		{
			Value = UnityEngine.Random.Range(0f, 1f);
		}
	}
}

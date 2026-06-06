using System;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[AddComponentMenu("Malbers/Variables/String Comparer")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/secondary-components/variable-listeners-and-comparers")]
	public class StringComparer : StringVarListener
	{
		public List<AdvancedStringEvent> compare = new List<AdvancedStringEvent>();

		private AdvancedStringEvent Pin;

		public string CompareFirst
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

		public override string Value
		{
			set
			{
				base.Value = value;
				if (Auto)
				{
					Compare();
				}
			}
		}

		public string this[int index]
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

		public void Pin_Comparer_SetValue(string value)
		{
			if (Pin != null)
			{
				Pin.Value.Value = value;
			}
		}

		public void Pin_Comparer_SetValue(StringVar value)
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
				StringVar variable = value.Variable;
				variable.OnValueChanged = (Action<string>)Delegate.Combine(variable.OnValueChanged, new Action<string>(Compare));
			}
			if (InvokeOnEnable)
			{
				Compare();
			}
		}

		private void OnDisable()
		{
			if ((bool)value.Variable && Auto)
			{
				StringVar variable = value.Variable;
				variable.OnValueChanged = (Action<string>)Delegate.Remove(variable.OnValueChanged, new Action<string>(Compare));
			}
		}

		public virtual void Compare(string value)
		{
			foreach (AdvancedStringEvent item in compare)
			{
				if (item.active)
				{
					bool flag = item.ExecuteAdvanceStringEvent(value);
					if (debug)
					{
						Debug.Log($"String Comparer: {base.name} <color=orange><B>'{value}'</B></color> <B>[{item.comparer}]</B> <color=orange><B>'{item.Value.Value}'</B>  </color><B>[{flag}]</B>", this);
					}
				}
			}
		}

		public virtual void Compare()
		{
			Compare(value.Value);
		}

		public virtual void Compare(StringReference value)
		{
			Compare(value);
		}

		public virtual void Compare(StringVar value)
		{
			Compare(value.Value);
		}

		public virtual void Compare(UnityEngine.Object value)
		{
			Compare((value != null) ? value.name : string.Empty);
		}

		public virtual void SetValue(string value)
		{
			Value = value;
		}

		public virtual void SetValue(UnityEngine.Object value)
		{
			Value = ((value != null) ? value.name : string.Empty);
		}

		public virtual void SetValue(StringVar value)
		{
			Value = value.Value;
		}

		public virtual void SetValue(StringReference value)
		{
			Value = value.Value;
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

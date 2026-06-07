using System;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Variables/String Listener")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/secondary-components/variable-listeners-and-comparers")]
	public class StringVarListener : VarListener
	{
		public StringReference value;

		public StringEvent Raise = new StringEvent();

		public virtual string Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value.Value = value;
				if (Auto)
				{
					Invoke(value);
				}
			}
		}

		private void OnEnable()
		{
			if (value.Variable != null && Auto)
			{
				StringVar variable = value.Variable;
				variable.OnValueChanged = (Action<string>)Delegate.Combine(variable.OnValueChanged, new Action<string>(Invoke));
			}
			if (InvokeOnEnable)
			{
				Raise.Invoke(value);
			}
		}

		private void OnDisable()
		{
			if (value.Variable != null && Auto)
			{
				StringVar variable = value.Variable;
				variable.OnValueChanged = (Action<string>)Delegate.Remove(variable.OnValueChanged, new Action<string>(Invoke));
			}
		}

		public virtual void Invoke(string value)
		{
			if (base.Enable)
			{
				Raise.Invoke(value);
			}
		}

		public virtual void Invoke(UnityEngine.Object value)
		{
			Invoke(value.name);
		}

		public virtual void Invoke()
		{
			Invoke(Value);
		}

		public virtual void _Add(string var)
		{
			Value += var;
		}

		public virtual void _Add(StringVar var)
		{
			Value += var.Value;
		}

		public virtual void _Add(char var)
		{
			Value += var;
		}

		public virtual void _Clear()
		{
			Value = string.Empty;
		}

		public virtual void _RemoveFirst()
		{
			if (!string.IsNullOrEmpty(Value))
			{
				string text = Value;
				Value = text.Substring(1, text.Length - 1);
			}
		}

		public virtual void _RemoveLast()
		{
			if (!string.IsNullOrEmpty(Value))
			{
				string text = Value;
				Value = text.Substring(0, text.Length - 1);
			}
		}
	}
}

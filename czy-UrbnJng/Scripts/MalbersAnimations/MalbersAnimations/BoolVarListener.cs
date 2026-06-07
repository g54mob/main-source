using System;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations
{
	[DefaultExecutionOrder(750)]
	[AddComponentMenu("Malbers/Variables/Bool Listener (Local Bool)")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/secondary-components/variable-listeners-and-comparers")]
	public class BoolVarListener : VarListener
	{
		public BoolReference value = new BoolReference();

		[Tooltip("When the events are invoked the value will be inverted")]
		public bool invert;

		public BoolEvent OnValueChanged = new BoolEvent();

		public UnityEvent OnTrue = new UnityEvent();

		public UnityEvent OnFalse = new UnityEvent();

		public bool Value
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
				BoolVar variable = value.Variable;
				variable.OnValueChanged = (Action<bool>)Delegate.Combine(variable.OnValueChanged, new Action<bool>(Invoke));
			}
			if (InvokeOnEnable)
			{
				Invoke(value);
			}
		}

		private void OnDisable()
		{
			if (value.Variable != null && Auto)
			{
				BoolVar variable = value.Variable;
				variable.OnValueChanged = (Action<bool>)Delegate.Remove(variable.OnValueChanged, new Action<bool>(Invoke));
			}
		}

		public virtual void Invoke(bool value)
		{
			if (invert)
			{
				value = !value;
			}
			if (base.Enable)
			{
				OnValueChanged.Invoke(value);
				if (value)
				{
					OnTrue.Invoke();
				}
				else
				{
					OnFalse.Invoke();
				}
				Debuggin(value);
			}
		}

		public virtual void SetValue(int value)
		{
			Value = value != 0;
		}

		public virtual void SetValue(UnityEngine.Object value)
		{
			Value = value != null;
		}

		public virtual void SetValue(GameObject value)
		{
			Value = value != null;
		}

		public virtual void SetValue(float value)
		{
			Value = value != 0f;
		}

		public virtual void SetValue(string value)
		{
			Value = string.IsNullOrEmpty(value);
		}

		public virtual void SetValueV3_X(Vector3 value)
		{
			Value = value.x != 0f;
		}

		public virtual void SetValueV3_Y(Vector3 value)
		{
			Value = value.y != 0f;
		}

		public virtual void SetValueV3_Z(Vector3 value)
		{
			Value = value.z != 0f;
		}

		public virtual void Invoke()
		{
			Invoke(Value);
		}

		public virtual void Toggle_Value()
		{
			if (base.Enable)
			{
				Value = !Value;
			}
		}

		public void ShowCursor(bool value)
		{
			UnityUtils.ShowCursor(value);
		}

		private void Debuggin(bool value)
		{
		}
	}
}

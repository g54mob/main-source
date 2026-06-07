using System;
using MalbersAnimations.Events;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Scriptables
{
	[AddComponentMenu("Malbers/Variables/Transform Listener")]
	public class TransformListener : VarListener
	{
		public TransformReference value;

		public TransformEvent OnValueChanged = new TransformEvent();

		public UnityEvent OnValueNull = new UnityEvent();

		public virtual Transform Value
		{
			get
			{
				return value.Value;
			}
			set
			{
				if (Auto)
				{
					this.value.Value = value;
				}
				Invoke(value);
			}
		}

		private void OnEnable()
		{
			if (value.Variable != null)
			{
				TransformVar variable = value.Variable;
				variable.OnValueChanged = (Action<Transform>)Delegate.Combine(variable.OnValueChanged, new Action<Transform>(Invoke));
			}
			if (InvokeOnEnable)
			{
				Invoke(value.Value);
			}
		}

		private void OnDisable()
		{
			if (value.Variable != null)
			{
				TransformVar variable = value.Variable;
				variable.OnValueChanged = (Action<Transform>)Delegate.Remove(variable.OnValueChanged, new Action<Transform>(Invoke));
			}
			Invoke(value.Value);
		}

		public virtual void SetValue(TransformReference value)
		{
			Value = value.Value;
		}

		public virtual void Invoke(Transform value)
		{
			OnValueChanged.Invoke(value);
			if (!value)
			{
				OnValueNull.Invoke();
			}
		}
	}
}

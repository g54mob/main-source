using System;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Scriptables
{
	[AddComponentMenu("Malbers/Variables/Transform Comparer")]
	public class TransformComparer : VarListener
	{
		public enum TransformCondition
		{
			Null = 0,
			Equal = 1,
			ChildOf = 2,
			ParentOf = 3,
			Name = 4
		}

		public TransformReference value;

		public TransformCondition Condition;

		public TransformReference compareTo;

		public StringReference T_Name;

		public UnityEvent Then = new UnityEvent();

		public UnityEvent Else = new UnityEvent();

		private void OnEnable()
		{
			if (value.Variable != null)
			{
				TransformVar variable = value.Variable;
				variable.OnValueChanged = (Action<Transform>)Delegate.Combine(variable.OnValueChanged, new Action<Transform>(Invoke));
			}
			if (compareTo.Variable != null)
			{
				TransformVar variable2 = compareTo.Variable;
				variable2.OnValueChanged = (Action<Transform>)Delegate.Combine(variable2.OnValueChanged, new Action<Transform>(Invoke));
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
			if (compareTo.Variable != null)
			{
				TransformVar variable2 = compareTo.Variable;
				variable2.OnValueChanged = (Action<Transform>)Delegate.Remove(variable2.OnValueChanged, new Action<Transform>(Invoke));
			}
		}

		public virtual void Invoke(Transform value)
		{
			switch (Condition)
			{
			case TransformCondition.Null:
				Response(value == null);
				Debbuging($"Value is Null ? [{value == null}]");
				break;
			case TransformCondition.Equal:
				Response(value == compareTo.Value);
				Debbuging($"{value} == {compareTo.Value} -> [{value == compareTo.Value}]");
				break;
			case TransformCondition.ChildOf:
				if ((bool)value)
				{
					Response(value.IsChildOf(compareTo.Value));
				}
				break;
			case TransformCondition.ParentOf:
				if ((bool)compareTo.Value)
				{
					Response(compareTo.Value.IsChildOf(value));
				}
				break;
			case TransformCondition.Name:
				if ((bool)value)
				{
					Response(value.name.Contains(T_Name));
				}
				Debbuging($"Name is Equal to {value}");
				break;
			}
		}

		public virtual void Invoke()
		{
			Invoke(value.Value);
		}

		public void SetValue(Component target)
		{
			SetTarget(target);
		}

		public void SetTarget(Component target)
		{
			value.Value = (target ? target.transform : null);
			Invoke();
		}

		private void Debbuging(string log)
		{
			if (debug)
			{
				Debug.Log(base.name + ": <B>" + log + "</B>", this);
			}
		}

		public void SetValue(GameObject target)
		{
			SetTarget(target);
		}

		public void SetTarget(GameObject target)
		{
			value.Value = (target ? target.transform : null);
			Invoke();
		}

		public void SetCompareTo(Component target)
		{
			compareTo.Value = (target ? target.transform : null);
			Invoke();
		}

		public void SetCompareTo(GameObject target)
		{
			compareTo.Value = (target ? target.transform : null);
			Invoke();
		}

		public void ClearValue()
		{
			ClearTarget();
		}

		public void ClearTarget()
		{
			if (value.Value != null)
			{
				value.Value = null;
				Invoke();
			}
		}

		public void ClearComparteTo()
		{
			if (compareTo.Value != null)
			{
				compareTo.Value = null;
				Invoke();
			}
		}

		private void Response(bool value)
		{
			if (value)
			{
				Then.Invoke();
			}
			else
			{
				Else.Invoke();
			}
		}
	}
}

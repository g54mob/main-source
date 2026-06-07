using System;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[DefaultExecutionOrder(750)]
	[AddComponentMenu("Malbers/Variables/Vector3 Listener")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/secondary-components/variable-listeners-and-comparers")]
	public class Vector3VarListener : VarListener
	{
		public Vector3Reference value = new Vector3Reference();

		public Vector3Event OnValue = new Vector3Event();

		public Vector3 Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value.Value = value;
				Invoke(value);
			}
		}

		private void OnEnable()
		{
			if (value.Variable != null)
			{
				Vector3Var variable = value.Variable;
				variable.OnValueChanged = (Action<Vector3>)Delegate.Combine(variable.OnValueChanged, new Action<Vector3>(Invoke));
			}
			Invoke(value);
		}

		private void OnDisable()
		{
			if (value.Variable != null)
			{
				Vector3Var variable = value.Variable;
				variable.OnValueChanged = (Action<Vector3>)Delegate.Remove(variable.OnValueChanged, new Action<Vector3>(Invoke));
			}
		}

		public void TransformUp(Transform tr)
		{
			tr.up = Value.normalized;
		}

		public void TransforDown(Transform tr)
		{
			tr.up = -Value.normalized;
		}

		public void TransforForward(Transform tr)
		{
			tr.forward = Value.normalized;
		}

		public void TransformBackwards(Transform tr)
		{
			tr.forward = -Value.normalized;
		}

		public void TransformRight(Transform tr)
		{
			tr.right = Value.normalized;
		}

		public void TransformLeft(Transform tr)
		{
			tr.right = -Value.normalized;
		}

		public void SetValueDirectionFromObject(Transform Target)
		{
			Value = base.transform.DirectionTo(Target).normalized;
		}

		public void SetValueDirectionFromObjectInverse(Transform Target)
		{
			Value = Target.DirectionTo(base.transform);
		}

		public void SetValueDirectionFromObject(GameObject Target)
		{
			SetValueDirectionFromObject(Target.transform);
		}

		public void SetValueDirectionFromObjectInverse(GameObject Target)
		{
			SetValueDirectionFromObjectInverse(Target.transform);
		}

		public virtual void Invoke(Vector3 value)
		{
			if (base.Enable)
			{
				OnValue.Invoke(value);
			}
		}

		private void OnDrawGizmosSelected()
		{
			Debug.DrawRay(base.transform.position, Value, Color.white);
		}
	}
}

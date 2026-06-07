using System;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[DefaultExecutionOrder(750)]
	[AddComponentMenu("Malbers/Variables/Vector2 Listener")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/secondary-components/variable-listeners-and-comparers")]
	public class Vector2VarListener : VarListener
	{
		public Vector2Reference value = new Vector2Reference();

		public Vector2Event OnValue = new Vector2Event();

		public Vector2 Value
		{
			get
			{
				return value;
			}
			set
			{
				if (base.Enable)
				{
					this.value.Value = value;
					Invoke(value);
				}
			}
		}

		private void OnEnable()
		{
			if (value.Variable != null)
			{
				Vector2Var variable = value.Variable;
				variable.OnValueChanged = (Action<Vector2>)Delegate.Combine(variable.OnValueChanged, new Action<Vector2>(Invoke));
			}
			Invoke(value);
		}

		private void OnDisable()
		{
			if (value.Variable != null)
			{
				Vector2Var variable = value.Variable;
				variable.OnValueChanged = (Action<Vector2>)Delegate.Remove(variable.OnValueChanged, new Action<Vector2>(Invoke));
			}
		}

		public virtual void TransformRotateUp(Transform tr)
		{
			TransformRotate(tr, tr.up);
		}

		public virtual void TransformRotateForward(Transform tr)
		{
			TransformRotate(tr, tr.forward);
		}

		public virtual void TransformRotateRight(Transform tr)
		{
			TransformRotate(tr, tr.right);
		}

		public virtual void TransformRotateDown(Transform tr)
		{
			TransformRotate(tr, -tr.up);
		}

		public virtual void TransformRotateBack(Transform tr)
		{
			TransformRotate(tr, -tr.forward);
		}

		public virtual void TransformRotateLeft(Transform tr)
		{
			TransformRotate(tr, -tr.right);
		}

		public virtual void TransformRotate(Transform tr, Vector3 axis)
		{
			if (!(Value == Vector2.zero))
			{
				float angle = Mathf.Atan2(Value.x, Value.y) * 57.29578f;
				tr.rotation = Quaternion.AngleAxis(angle, axis);
			}
		}

		public virtual void Invoke(Vector2 value)
		{
			if (base.Enable)
			{
				OnValue.Invoke(value);
			}
		}
	}
}

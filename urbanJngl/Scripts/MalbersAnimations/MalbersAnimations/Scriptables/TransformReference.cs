using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[Serializable]
	public class TransformReference : ReferenceVar
	{
		public Transform ConstantValue;

		[RequiredField]
		public TransformVar Variable;

		public Transform Value
		{
			get
			{
				if (!UseConstant)
				{
					if (!(Variable != null))
					{
						return null;
					}
					return Variable.Value;
				}
				return ConstantValue;
			}
			set
			{
				if (UseConstant || Variable == null)
				{
					UseConstant = true;
					ConstantValue = value;
				}
				else
				{
					Variable.Value = value;
				}
			}
		}

		public Vector3 position => Value.position;

		public Quaternion rotation => Value.rotation;

		public Vector3 localPosition => Value.localPosition;

		public Quaternion localRotation => Value.localRotation;

		public TransformReference()
		{
			UseConstant = true;
		}

		public TransformReference(Transform value)
		{
			Value = value;
		}

		public TransformReference(TransformVar value)
		{
			Variable = value;
			UseConstant = false;
		}

		public virtual void SetPosition(Vector3 pos)
		{
			if ((bool)Value)
			{
				Value.position = pos;
			}
		}

		public virtual void SetRotation(Quaternion rot)
		{
			if ((bool)Value)
			{
				Value.rotation = rot;
			}
		}

		public virtual void SetPositionAndRotation(Vector3 pos, Quaternion rot)
		{
			if ((bool)Value)
			{
				Value.SetPositionAndRotation(pos, rot);
			}
		}

		public static implicit operator Transform(TransformReference reference)
		{
			return reference.Value;
		}

		public static implicit operator GameObject(TransformReference reference)
		{
			return reference.Value.gameObject;
		}

		public static implicit operator TransformReference(Transform reference)
		{
			return new TransformReference(reference);
		}
	}
}

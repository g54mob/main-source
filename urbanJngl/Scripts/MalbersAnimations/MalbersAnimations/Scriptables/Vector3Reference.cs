using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[Serializable]
	public class Vector3Reference : ReferenceVar
	{
		public Vector3 ConstantValue = Vector3.zero;

		[RequiredField]
		public Vector3Var Variable;

		public Vector3 Value
		{
			get
			{
				if (!UseConstant && !(Variable == null))
				{
					return Variable.Value;
				}
				return ConstantValue;
			}
			set
			{
				if (UseConstant)
				{
					ConstantValue = value;
				}
				else
				{
					Variable.Value = value;
				}
			}
		}

		public float x
		{
			get
			{
				if (!UseConstant)
				{
					return Variable.x;
				}
				return ConstantValue.x;
			}
			set
			{
				if (UseConstant)
				{
					ConstantValue.x = value;
				}
				else
				{
					Variable.x = value;
				}
			}
		}

		public float y
		{
			get
			{
				if (!UseConstant)
				{
					return Variable.y;
				}
				return ConstantValue.y;
			}
			set
			{
				if (UseConstant)
				{
					ConstantValue.y = value;
				}
				else
				{
					Variable.y = value;
				}
			}
		}

		public float z
		{
			get
			{
				if (!UseConstant)
				{
					return Variable.z;
				}
				return ConstantValue.z;
			}
			set
			{
				if (UseConstant)
				{
					ConstantValue.z = value;
				}
				else
				{
					Variable.z = value;
				}
			}
		}

		public Vector3Reference()
		{
			UseConstant = true;
			ConstantValue = Vector3.zero;
		}

		public Vector3Reference(bool variable)
		{
			UseConstant = !variable;
			if (!variable)
			{
				ConstantValue = Vector3.zero;
				return;
			}
			Variable = ScriptableObject.CreateInstance<Vector3Var>();
			Variable.Value = Vector3.zero;
		}

		public Vector3Reference(Vector3 value)
		{
			Value = value;
		}

		public Vector3Reference(float x, float y, float z)
		{
			Value = new Vector3(x, y, z);
		}

		public static implicit operator Vector3(Vector3Reference reference)
		{
			return reference.Value;
		}

		public static implicit operator Vector2(Vector3Reference reference)
		{
			return reference.Value;
		}
	}
}

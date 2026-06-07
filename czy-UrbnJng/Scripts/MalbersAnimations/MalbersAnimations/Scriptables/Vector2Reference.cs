using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[Serializable]
	public class Vector2Reference : ReferenceVar
	{
		public Vector2 ConstantValue = Vector2.zero;

		[RequiredField]
		public Vector2Var Variable;

		public Vector2 Value
		{
			get
			{
				if (!UseConstant)
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
					return Variable.Value.x;
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
					return Variable.Value.y;
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

		public Vector2Reference()
		{
			UseConstant = true;
			ConstantValue = Vector2.zero;
		}

		public Vector2Reference(bool variable)
		{
			UseConstant = !variable;
			if (!variable)
			{
				ConstantValue = Vector2.zero;
				return;
			}
			Variable = ScriptableObject.CreateInstance<Vector2Var>();
			Variable.Value = Vector2.zero;
		}

		public Vector2Reference(Vector2 value)
		{
			Value = value;
		}

		public Vector2Reference(float x, float y)
		{
			UseConstant = true;
			Value = new Vector2(x, y);
		}

		public static implicit operator Vector2(Vector2Reference reference)
		{
			return reference.Value;
		}

		public static implicit operator Vector2Reference(Vector2 reference)
		{
			return new Vector2Reference(reference);
		}
	}
}

using System;

namespace MalbersAnimations.Scriptables
{
	[Serializable]
	public class FloatReference : ReferenceVar
	{
		public float ConstantValue;

		[RequiredField]
		public FloatVar Variable;

		public float Value
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
				if (UseConstant || Variable == null)
				{
					ConstantValue = value;
				}
				else
				{
					Variable.Value = value;
				}
			}
		}

		public FloatReference()
		{
			Value = 0f;
		}

		public FloatReference(float value)
		{
			Value = value;
		}

		public FloatReference(FloatVar value)
		{
			Variable = value;
			UseConstant = false;
		}

		public static implicit operator float(FloatReference reference)
		{
			return reference.Value;
		}

		public static implicit operator FloatReference(float reference)
		{
			return new FloatReference(reference);
		}

		public static implicit operator FloatReference(FloatVar reference)
		{
			return new FloatReference(reference.Value);
		}
	}
}

using System;

namespace MalbersAnimations.Scriptables
{
	[Serializable]
	public class BoolReference : ReferenceVar
	{
		public bool ConstantValue;

		[RequiredField]
		public BoolVar Variable;

		public bool Value
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

		public BoolReference()
		{
			Value = false;
		}

		public BoolReference(bool value)
		{
			Value = value;
		}

		public BoolReference(BoolVar value)
		{
			Value = value.Value;
		}

		public static implicit operator bool(BoolReference reference)
		{
			return reference.Value;
		}
	}
}

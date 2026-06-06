using System;

namespace MalbersAnimations.Scriptables
{
	[Serializable]
	public class IntReference : ReferenceVar
	{
		public int ConstantValue;

		[RequiredField]
		public IntVar Variable;

		public int Value
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

		public IntReference()
		{
			Value = 0;
		}

		public IntReference(int value)
		{
			Value = value;
		}

		public IntReference(IntVar value)
		{
			Value = value.Value;
		}

		public static implicit operator int(IntReference reference)
		{
			return reference.Value;
		}

		public static implicit operator IntReference(int reference)
		{
			return new IntReference(reference);
		}

		public static implicit operator IntReference(IntVar reference)
		{
			return new IntReference(reference);
		}
	}
}

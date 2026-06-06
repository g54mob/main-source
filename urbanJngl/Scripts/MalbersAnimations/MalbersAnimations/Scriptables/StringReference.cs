using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[Serializable]
	public class StringReference : ReferenceVar
	{
		public string ConstantValue;

		[RequiredField]
		public StringVar Variable;

		public string Value
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

		public bool Empty => string.IsNullOrEmpty(Value);

		public StringReference()
		{
			UseConstant = true;
			ConstantValue = string.Empty;
		}

		public StringReference(StringVar newValue)
		{
			UseConstant = false;
			Variable = newValue;
		}

		public StringReference(bool variable = false)
		{
			UseConstant = !variable;
			if (!variable)
			{
				ConstantValue = string.Empty;
				return;
			}
			Variable = ScriptableObject.CreateInstance<StringVar>();
			Variable.Value = string.Empty;
		}

		public StringReference(string value)
		{
			Value = value;
		}

		public static implicit operator string(StringReference reference)
		{
			return reference.Value;
		}
	}
}

using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[Serializable]
	public class ColorReference : ReferenceVar
	{
		public Color ConstantValue = Color.white;

		public ColorVar Variable;

		public Color Value
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

		public ColorReference()
		{
			UseConstant = true;
			ConstantValue = Color.white;
		}

		public ColorReference(bool variable = false)
		{
			UseConstant = !variable;
			if (!variable)
			{
				ConstantValue = Color.white;
				return;
			}
			Variable = ScriptableObject.CreateInstance<ColorVar>();
			Variable.Value = Color.white;
		}

		public ColorReference(Color value)
		{
			Value = value;
		}

		public static implicit operator Color(ColorReference reference)
		{
			return reference.Value;
		}
	}
}

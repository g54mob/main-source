using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[Serializable]
	public class LayerReference : ReferenceVar
	{
		public LayerMask ConstantValue = -1;

		[RequiredField]
		public LayerVar Variable;

		public LayerMask Value
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

		public LayerReference()
		{
			Value = -1;
		}

		public LayerReference(LayerMask value)
		{
			UseConstant = true;
			Value = value;
		}

		public LayerReference(LayerVar value)
		{
			UseConstant = false;
			Value = value.Value;
		}

		public static implicit operator int(LayerReference reference)
		{
			return reference.Value;
		}

		public static implicit operator LayerMask(LayerReference reference)
		{
			return reference.Value;
		}
	}
}

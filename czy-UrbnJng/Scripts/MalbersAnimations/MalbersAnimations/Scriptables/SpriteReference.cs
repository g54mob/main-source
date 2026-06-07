using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[Serializable]
	public class SpriteReference : ReferenceVar
	{
		public Sprite ConstantValue;

		[RequiredField]
		public SpriteVar Variable;

		public Sprite Value
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

		public SpriteReference()
		{
			UseConstant = true;
		}

		public SpriteReference(Sprite value)
		{
			Value = value;
		}

		public SpriteReference(SpriteVar value)
		{
			Value = value.Value;
		}
	}
}

using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[Serializable]
	public class GameObjectReference : ReferenceVar
	{
		public GameObject ConstantValue;

		[RequiredField]
		public GameObjectVar Variable;

		public GameObject Value
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
					ConstantValue = value;
					UseConstant = true;
				}
				else
				{
					Variable.Value = value;
				}
			}
		}

		public GameObjectReference()
		{
			UseConstant = true;
		}

		public GameObjectReference(GameObject value)
		{
			Value = value;
		}

		public GameObjectReference(GameObjectVar value)
		{
			Variable = value;
			UseConstant = false;
		}

		public static implicit operator GameObject(GameObjectReference reference)
		{
			return reference.Value;
		}
	}
}

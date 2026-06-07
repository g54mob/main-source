using System;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	public class OverrideCapsuleColliderReference : ReferenceVar
	{
		public OverrideCapsuleCollider ConstantValue;

		[RequiredField]
		public CapsuleColliderPreset Variable;

		public OverrideCapsuleCollider Value
		{
			get
			{
				if (!UseConstant && !(Variable == null))
				{
					return Variable.modifier;
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
					Variable.modifier = value;
				}
			}
		}

		public OverrideCapsuleColliderReference()
		{
			Value = default(OverrideCapsuleCollider);
		}

		public OverrideCapsuleColliderReference(CapsuleColliderPreset value)
		{
			Value = value.modifier;
		}

		public void Modify(CapsuleCollider collider)
		{
			Value.Modify(collider);
		}
	}
}

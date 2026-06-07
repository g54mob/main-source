using System;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[Serializable]
	public struct MAnimatorParameter
	{
		[Tooltip("Name of the Parameter in the Animator")]
		public string param;

		[Tooltip("Type of the Animator Parameter")]
		public AnimatorControllerParameterType type;

		[Tooltip("Value to set on the Parameter. Float and Int parameters are represented by this variable. Bool is calculated if this value is not equal to 0")]
		public float Value;

		public int ParamHash { get; set; }

		public void GetHashValue()
		{
			ParamHash = Animator.StringToHash(param);
		}

		public void Set(Animator anim)
		{
			if (ParamHash == 0)
			{
				GetHashValue();
			}
			if (!(anim == null))
			{
				switch (type)
				{
				case AnimatorControllerParameterType.Float:
					anim.SetFloat(ParamHash, Value);
					break;
				case AnimatorControllerParameterType.Int:
					anim.SetInteger(ParamHash, (int)Value);
					break;
				case AnimatorControllerParameterType.Bool:
					anim.SetBool(ParamHash, Value != 0f);
					break;
				case AnimatorControllerParameterType.Trigger:
					anim.SetTrigger(ParamHash);
					break;
				}
			}
		}

		public void Set(Component comp)
		{
			Set(comp.FindComponent<Animator>());
		}

		public void Set(GameObject go)
		{
			Set(go.FindComponent<Animator>());
		}
	}
}

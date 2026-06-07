using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Animator/Set Animator Parameter")]
	public class SetAnimatorParameter : MonoBehaviour
	{
		public Animator animator;

		public List<MAnimatorParameter> parameters = new List<MAnimatorParameter>();

		public void Set()
		{
			foreach (MAnimatorParameter parameter in parameters)
			{
				parameter.Set(animator);
			}
		}

		public void Set(Animator anim)
		{
			foreach (MAnimatorParameter parameter in parameters)
			{
				parameter.Set(anim);
			}
		}

		public void Set(Component comp)
		{
			Set(comp.FindComponent<Animator>());
		}

		public void Set(GameObject comp)
		{
			Set(comp.FindComponent<Animator>());
		}
	}
}

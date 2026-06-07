using UnityEngine;

namespace Gh.Tk
{
	public class AnimParam
	{
		public AnimatorControllerParameterType type;

		public string paramName;

		public object data;

		public AnimParam()
		{
		}

		public AnimParam(Animator anim, string paramName, AnimatorControllerParameterType type)
		{
		}
	}
}

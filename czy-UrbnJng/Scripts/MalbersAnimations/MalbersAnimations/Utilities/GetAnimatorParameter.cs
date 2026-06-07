using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Animator/Get Animator Parameter")]
	public class GetAnimatorParameter : MonoBehaviour
	{
		[RequiredField]
		public Animator animator;

		public string parameter = "Param Name";

		public AnimatorType type;

		public BoolEvent BoolParam = new BoolEvent();

		public IntEvent IntParam = new IntEvent();

		public FloatEvent FloatParam = new FloatEvent();

		public int ParameterHash { get; private set; }

		public void Get()
		{
			if (ParameterHash == 0)
			{
				ParameterHash = Animator.StringToHash(parameter);
			}
			if (ParameterHash != 0 && (bool)animator)
			{
				switch (type)
				{
				case AnimatorType.Float:
					FloatParam.Invoke(animator.GetFloat(ParameterHash));
					break;
				case AnimatorType.Int:
					IntParam.Invoke(animator.GetInteger(ParameterHash));
					break;
				case AnimatorType.Bool:
					BoolParam.Invoke(animator.GetBool(ParameterHash));
					break;
				}
			}
		}

		private void Reset()
		{
			animator = this.FindComponent<Animator>();
		}
	}
}

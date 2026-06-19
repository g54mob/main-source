using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class AnimatorPlaybackRandomizer : MonoBehaviour
	{
		[SerializeField]
		private Animator[] _animators;

		private void Awake()
		{
			Animator[] animators = _animators;
			for (int i = 0; i < animators.Length; i++)
			{
				animators[i].Play(0, 0, RandomUtils.GlobalRandomInstance.NextFloat(0f, 1f));
			}
		}
	}
}

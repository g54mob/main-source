using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ModifyAnimatorStartTimeComponent : MonoBehaviour
	{
		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private float _percentage;

		private void Awake()
		{
			AnimatorStateInfo currentAnimatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
			_animator.Play(currentAnimatorStateInfo.shortNameHash, 0, _percentage);
		}
	}
}

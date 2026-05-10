using UnityEngine;

namespace RootMotion.Demos
{
	public class CharacterAnimationSimple : CharacterAnimationBase
	{
		public CharacterThirdPerson characterController;

		public float pivotOffset;

		public AnimationCurve moveSpeed;

		private Animator animator;

		protected override void Start()
		{
		}

		public override Vector3 GetPivotPoint()
		{
			return default(Vector3);
		}

		private void Update()
		{
		}
	}
}

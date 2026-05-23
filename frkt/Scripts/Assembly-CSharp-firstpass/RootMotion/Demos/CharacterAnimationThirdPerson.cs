using UnityEngine;

namespace RootMotion.Demos
{
	public class CharacterAnimationThirdPerson : bqo
	{
		public bqs characterController;

		[SerializeField]
		private float turnSensitivity;

		[SerializeField]
		private float turnSpeed;

		[SerializeField]
		private float runCycleLegOffset;

		[Range(0.1f, 3f)]
		[SerializeField]
		private float animSpeedMultiplier;

		protected Animator ulr;

		private Vector3 uls;

		private const string ult = "Grounded Directional";

		private const string ulu = "Grounded Strafe";

		private float ulv;

		private float ulw;

		private bool ulx;

		public override bool xuh => false;

		protected override void Start()
		{
		}

		public override Vector3 lhd()
		{
			return default(Vector3);
		}

		protected virtual void Update()
		{
		}

		private void OnAnimatorMove()
		{
		}
	}
}

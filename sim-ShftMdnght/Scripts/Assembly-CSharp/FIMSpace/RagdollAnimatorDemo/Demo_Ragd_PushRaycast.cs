using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_PushRaycast : FimpossibleComponent
	{
		public LayerMask RaycastMask;

		[Header("Use Left mouse button to apply impact on any detected ragdoll limb")]
		public float PowerMul = 3f;

		[Range(0f, 0.65f)]
		public float ImpactDuration = 0.2f;

		[Space(6f)]
		[Range(0f, 1f)]
		public float FadeMusclesTo = 0.175f;

		[Range(0f, 1.25f)]
		public float FadeMusclesDuration = 0.75f;

		[Space(4f)]
		[Tooltip("Used in demos to play animations on dragged character")]
		public bool PlayAnimations;

		public override string HeaderInfo => "Ragdoll needs to have added bone indicators with Extra Features in order to make this component work!";

		private void Update()
		{
			if (!Input.GetMouseButtonDown(0))
			{
				return;
			}
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (!Physics.Raycast(ray, out var hitInfo, float.PositiveInfinity, RaycastMask) || !hitInfo.rigidbody)
			{
				return;
			}
			RagdollAnimator2BoneIndicator component = hitInfo.transform.GetComponent<RagdollAnimator2BoneIndicator>();
			if (!(component == null))
			{
				RagdollHandler parentHandler = component.ParentHandler;
				Rigidbody dummyBoneRigidbody = component.DummyBoneRigidbody;
				parentHandler.User_SwitchFallState(RagdollHandler.EAnimatingMode.Falling);
				parentHandler.User_AddRigidbodyImpact(dummyBoneRigidbody, ray.direction * PowerMul, ImpactDuration);
				parentHandler.User_FadeMusclesPowerMultiplicator(FadeMusclesTo, FadeMusclesDuration);
				if (PlayAnimations)
				{
					parentHandler.Mecanim.CrossFadeInFixedTime("Fall", 0.05f);
					parentHandler.Mecanim.SetBool("Action", value: true);
				}
			}
		}
	}
}

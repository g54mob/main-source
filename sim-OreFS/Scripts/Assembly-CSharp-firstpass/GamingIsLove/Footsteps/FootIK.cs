using UnityEngine;

namespace GamingIsLove.Footsteps
{
	[AddComponentMenu("Footstepper/Foot IK")]
	public class FootIK : MonoBehaviour
	{
		public class Smooth
		{
			public float current;

			public float target;

			public float velocity;

			public void Update(float smoothTime)
			{
				if (smoothTime > 0f)
				{
					current = Mathf.SmoothDamp(current, target, ref velocity, smoothTime);
				}
				else
				{
					current = target;
				}
			}
		}

		[Tooltip("The animator that will be used.")]
		public Animator animator;

		[Tooltip("Enables IK foot placement.")]
		[Space(10f)]
		public bool enableIK = true;

		[Tooltip("Smooth the transition between IK placement and non-placement (e.g. when the raycast didn't hit the ground).")]
		[Range(0f, 1f)]
		public float smoothing = 0.1f;

		[Header("Feet Settings")]
		[Tooltip("The IK position weight of the right foot.")]
		[Range(0f, 1f)]
		public float rightPositionWeight = 1f;

		[Tooltip("The IK rotation weight of the right foot.")]
		[Range(0f, 1f)]
		public float rightRotationWeight = 1f;

		[Tooltip("The offset added to the right foot's IK position.")]
		public Vector3 rightOffset = Vector3.zero;

		[Space(10f)]
		[Tooltip("The IK position weight of the left foot.")]
		[Range(0f, 1f)]
		public float leftPositionWeight = 1f;

		[Tooltip("The IK rotation weight of the left foot.")]
		[Range(0f, 1f)]
		public float leftRotationWeight = 1f;

		[Tooltip("The offset added to the left foot's IK position.")]
		public Vector3 leftOffset = Vector3.zero;

		[Header("Raycast Settings")]
		[Tooltip("Select if 3D or 2D raycasting is used.")]
		public RaycastMode raycastMode;

		[Tooltip("Finding the ground below a foot uses raycasting.\nThe layer mask defines which layers will be checked.")]
		public LayerMask layerMask = -1;

		[Tooltip("The distance used for raycasting.")]
		public float rayDistance = 0.6f;

		[Tooltip("The offset to the foot's (or game object's) position when raycasting.")]
		public Vector3 rayOffset = new Vector3(0f, 0.5f, 0f);

		[Tooltip("The offset is added in the local space of the foot, otherwise in local space of this game object.")]
		public bool inFootSpace;

		protected Smooth rightSmooth = new Smooth();

		protected Smooth leftSmooth = new Smooth();

		protected virtual void Reset()
		{
			animator = GetComponent<Animator>();
		}

		public virtual RaycastResult Raycast(Vector3 position, Quaternion rotation)
		{
			if (raycastMode == RaycastMode.Raycast3D)
			{
				return RaycastResult.Raycast3D(inFootSpace ? (position + rotation * rayOffset) : (position + base.transform.rotation * rayOffset), rayDistance, layerMask);
			}
			return RaycastResult.Raycast2D(inFootSpace ? (position + rotation * rayOffset) : (position + base.transform.rotation * rayOffset), rayDistance, layerMask);
		}

		protected virtual void OnAnimatorIK()
		{
			if (animator != null)
			{
				if (enableIK)
				{
					SetIK(AvatarIKGoal.RightFoot, rightPositionWeight, rightRotationWeight, rightOffset, rightSmooth);
					SetIK(AvatarIKGoal.LeftFoot, leftPositionWeight, leftRotationWeight, leftOffset, leftSmooth);
					return;
				}
				rightSmooth.target = 0f;
				leftSmooth.target = 0f;
				animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0f);
				animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0f);
				animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0f);
				animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0f);
			}
		}

		protected virtual void SetIK(AvatarIKGoal goal, float positionWeight, float rotationWeight, Vector3 offset, Smooth smooth)
		{
			RaycastResult raycastResult = Raycast(animator.GetIKPosition(goal), animator.GetIKRotation(goal));
			if (raycastResult != null)
			{
				smooth.target = 1f;
				animator.SetIKPosition(goal, raycastResult.point + offset);
				if (rotationWeight > 0f)
				{
					animator.SetIKRotation(goal, Quaternion.LookRotation(Vector3.ProjectOnPlane(base.transform.forward, raycastResult.normal), raycastResult.normal));
				}
			}
			else
			{
				smooth.target = 0f;
			}
			animator.SetIKPositionWeight(goal, positionWeight * smooth.current);
			animator.SetIKRotationWeight(goal, rotationWeight * smooth.current);
		}

		protected virtual void Update()
		{
			rightSmooth.Update(smoothing);
			leftSmooth.Update(smoothing);
		}

		protected virtual void OnDrawGizmos()
		{
			Gizmos.DrawIcon(base.transform.position, "/GamingIsLove/Footsteps/FootIK Icon.png");
		}
	}
}

using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Weapons
{
	[CreateAssetMenu(menuName = "Malbers Animations/Weapons/IK Profile")]
	public class IKProfile : ScriptableObject
	{
		[Tooltip("Use Animator.SetLookAtWeight() Function")]
		public bool LookAtIK;

		[Hide("LookAtIK")]
		[Tooltip("(0-1) the global weight of the LookAt, multiplier for other parameters.")]
		public float Weight = 1f;

		[Hide("LookAtIK")]
		[Tooltip("(0-1) determines how much the body is involved in the LookAt.")]
		public float BodyWeight = 1f;

		[Hide("LookAtIK")]
		[Tooltip("(0-1) determines how much the head is involved in the LookAt.")]
		public float HeadWeight = 1f;

		[Hide("LookAtIK")]
		[Tooltip("(0-1) determines how much the eyes is involved in the LookAt.")]
		public float EyesWeight = 1f;

		[Hide("LookAtIK")]
		[Tooltip("(0-1) 0.0 means the character is completely unrestrained in motion, 1.0 means he's completely clamped (look at becomes impossible), and 0.5 means he'll be able to move on half of the possible range (180 degrees).")]
		public float ClampWeight;

		[Hide("LookAtIK")]
		[Tooltip("(0-1) Distance to Determine the LookAtPosition")]
		public float Distance = 100f;

		[Hide("LookAtIK")]
		[Tooltip("Offset of the LookAt Ray Horizontally")]
		public float HorizontalOffset;

		[Tooltip("Offset applied to the Horizontal Offset while aiming Up or Down")]
		[Hide("LookAtIK")]
		public AnimationCurve horizontalToVOffset = new AnimationCurve(new Keyframe(-1f, 0f), new Keyframe(0f, 0f), new Keyframe(1f, 0f));

		[Hide("LookAtIK")]
		[Tooltip("Offset of the LookAt Ray Vertically")]
		public float VerticalOffset;

		[Tooltip("Offset applied to the Vertical Offset while aiming Up or Down")]
		[Hide("LookAtIK")]
		public AnimationCurve verticalToHOffset = new AnimationCurve(new Keyframe(-1f, 0f), new Keyframe(0f, 0f), new Keyframe(1f, 0f));

		[Space]
		public List<BoneOfsset> offsets;

		public virtual void ApplyLookAt(Animator Anim, Vector3 origin, Vector3 Dir, float weight)
		{
			float num = horizontalToVOffset.Evaluate(Dir.y);
			float num2 = verticalToHOffset.Evaluate(Dir.y);
			Dir = Quaternion.AngleAxis(HorizontalOffset + num, Vector3.up) * Dir;
			Vector3 axis = Vector3.Cross(Dir, Vector3.up);
			Dir = Quaternion.AngleAxis(VerticalOffset + num2, axis) * Dir;
			Vector3 point = new Ray(origin, Dir).GetPoint(Distance);
			Debug.DrawLine(origin, point, Color.cyan);
			Anim.SetLookAtWeight(Weight * weight, BodyWeight, HeadWeight, EyesWeight, ClampWeight);
			Anim.SetLookAtPosition(point);
		}

		public virtual void ApplyOffsets(Animator Anim, Vector3 Origin, Vector3 Direction, float Weight)
		{
			Transform transform = Anim.transform;
			for (int i = 0; i < offsets.Count; i++)
			{
				if (!(Direction == Vector3.zero))
				{
					BoneOfsset boneOfsset = offsets[i];
					Transform boneTransform = Anim.GetBoneTransform(boneOfsset.bone);
					if (boneTransform == null)
					{
						return;
					}
					Quaternion quaternion = Quaternion.Euler(boneOfsset.RotationOffset);
					Quaternion quaternion2 = Quaternion.Inverse(boneTransform.parent.rotation);
					Quaternion localRotation = boneTransform.localRotation;
					Quaternion b = Quaternion.identity;
					switch (boneOfsset.rotationType)
					{
					case BoneOfsset.IKType.AdditiveOffset:
						b = boneTransform.localRotation * quaternion;
						break;
					case BoneOfsset.IKType.OffsetOnly:
						b = quaternion;
						break;
					case BoneOfsset.IKType.WorldRotation:
						b = quaternion2 * quaternion;
						break;
					case BoneOfsset.IKType.LookAtDir:
						b = quaternion2 * Quaternion.LookRotation(Direction, transform.up) * quaternion;
						break;
					case BoneOfsset.IKType.RootRotation:
						b = quaternion2 * transform.rotation * quaternion;
						break;
					case BoneOfsset.IKType.LootAtYAxis:
					{
						Vector3 normalized = Vector3.Cross(transform.up, Direction).normalized;
						b = Quaternion.AngleAxis(Vector3.Angle(transform.up, Direction) - 90f, normalized);
						b = quaternion2 * b * quaternion;
						Debug.DrawRay(boneTransform.position, normalized, Color.red);
						Debug.DrawRay(boneTransform.position, Direction, Color.green);
						break;
					}
					}
					float num = boneOfsset.Weight * Weight;
					if (num > 0f)
					{
						Quaternion rotation = Quaternion.Lerp(localRotation, b, num);
						Anim.SetBoneLocalRotation(boneOfsset.bone, rotation);
					}
				}
			}
			if (LookAtIK)
			{
				ApplyLookAt(Anim, Origin, Direction, Weight);
			}
		}

		private void OnValidate()
		{
			Weight = Mathf.Clamp01(Weight);
			BodyWeight = Mathf.Clamp01(BodyWeight);
			HeadWeight = Mathf.Clamp01(HeadWeight);
			EyesWeight = Mathf.Clamp01(EyesWeight);
			ClampWeight = Mathf.Clamp01(ClampWeight);
			foreach (BoneOfsset offset in offsets)
			{
				offset.name = offset.rotationType.ToString() + " [" + offset.bone.ToString() + "]";
			}
		}
	}
}

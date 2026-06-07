using System;
using UnityEngine;

namespace MalbersAnimations.Weapons
{
	[Serializable]
	public class BoneOfsset
	{
		public enum IKType
		{
			[InspectorName("Additive Local Rotation")]
			AdditiveOffset = 0,
			[InspectorName("Override Local Rotation")]
			OffsetOnly = 1,
			[InspectorName("World Rotation")]
			WorldRotation = 2,
			[InspectorName("World Rotation Relative to Root")]
			RootRotation = 3,
			[InspectorName("LookAt Aimer Direction")]
			LookAtDir = 4,
			[InspectorName("LookAt Aimer Direction No Horizontal")]
			LootAtYAxis = 5
		}

		[HideInInspector]
		public string name;

		public IKType rotationType;

		[SearcheableEnum]
		public HumanBodyBones bone;

		public Vector3 RotationOffset;

		[Range(0f, 1f)]
		public float Weight;

		public Quaternion ParentBoneOffset { get; set; }
	}
}

using System;
using UnityEngine;

namespace Synty.Tools.SyntyPropBoneTool
{
	[Serializable]
	public struct PropBoneDefinition
	{
		[Tooltip("The name of the bone in your character's rig to attach the prop bone.")]
		public string parentBoneName;

		[Tooltip("The name of the prop bone to instantiate.")]
		public string boneName;

		[Tooltip("The name of the additional transform created to attach props under.")]
		public string socketName;

		[Tooltip("Rotation offset used to compensate for differences in orientation of the parent bone between the source rig and the target rig.")]
		public Vector3 rotationOffset;

		[Tooltip("Scalar used to compensate for differences in size between the source rig and the target rig. 1 = target rig is the same scale as the reference rig, 2 = target rig is twice the size as the reference rig.")]
		public float scale;

		[Tooltip("Bone to use to calculate scalar value automatically.")]
		public string scaleCalculationBone1;

		[Tooltip("Bone to use to calculate scalar value automatically.")]
		public string scaleCalculationBone2;
	}
}

using System;
using UniGLTF;
using UniJSON;
using UnityEngine;

namespace VRM
{
	[Serializable]
	[JsonSchema(Title = "vrm.humanoid.bone")]
	public class glTF_VRM_HumanoidBone : JsonSerializableBase
	{
		[JsonSchema(Description = "Human bone name.", EnumValues = new object[]
		{
			"hips", "leftUpperLeg", "rightUpperLeg", "leftLowerLeg", "rightLowerLeg", "leftFoot", "rightFoot", "spine", "chest", "neck",
			"head", "leftShoulder", "rightShoulder", "leftUpperArm", "rightUpperArm", "leftLowerArm", "rightLowerArm", "leftHand", "rightHand", "leftToes",
			"rightToes", "leftEye", "rightEye", "jaw", "leftThumbProximal", "leftThumbIntermediate", "leftThumbDistal", "leftIndexProximal", "leftIndexIntermediate", "leftIndexDistal",
			"leftMiddleProximal", "leftMiddleIntermediate", "leftMiddleDistal", "leftRingProximal", "leftRingIntermediate", "leftRingDistal", "leftLittleProximal", "leftLittleIntermediate", "leftLittleDistal", "rightThumbProximal",
			"rightThumbIntermediate", "rightThumbDistal", "rightIndexProximal", "rightIndexIntermediate", "rightIndexDistal", "rightMiddleProximal", "rightMiddleIntermediate", "rightMiddleDistal", "rightRingProximal", "rightRingIntermediate",
			"rightRingDistal", "rightLittleProximal", "rightLittleIntermediate", "rightLittleDistal", "upperChest"
		}, EnumSerializationType = EnumSerializationType.AsString)]
		public string bone;

		[JsonSchema(Description = "Reference node index", Minimum = 0.0)]
		public int node = -1;

		[JsonSchema(Description = "Unity's HumanLimit.useDefaultValues")]
		public bool useDefaultValues = true;

		[JsonSchema(Description = "Unity's HumanLimit.min")]
		public Vector3 min;

		[JsonSchema(Description = "Unity's HumanLimit.max")]
		public Vector3 max;

		[JsonSchema(Description = "Unity's HumanLimit.center")]
		public Vector3 center;

		[JsonSchema(Description = "Unity's HumanLimit.axisLength")]
		public float axisLength;

		public VRMBone vrmBone
		{
			get
			{
				return CacheEnum.Parse<VRMBone>(bone, ignoreCase: true);
			}
			set
			{
				bone = value.ToString();
			}
		}

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.Key("bone");
			f.Value(bone.ToString());
			f.KeyValue(() => node);
			f.KeyValue(() => useDefaultValues);
			if (!useDefaultValues)
			{
				f.KeyValue(() => min);
				f.KeyValue(() => max);
				f.KeyValue(() => center);
				f.KeyValue(() => axisLength);
			}
		}
	}
}

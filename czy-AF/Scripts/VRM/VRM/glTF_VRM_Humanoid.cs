using System;
using System.Collections.Generic;
using System.Linq;
using UniGLTF;
using UniHumanoid;
using UniJSON;
using UnityEngine;

namespace VRM
{
	[Serializable]
	[JsonSchema(Title = "vrm.humanoid")]
	public class glTF_VRM_Humanoid : JsonSerializableBase
	{
		public List<glTF_VRM_HumanoidBone> humanBones = new List<glTF_VRM_HumanoidBone>();

		[JsonSchema(Description = "Unity's HumanDescription.armStretch")]
		public float armStretch = 0.05f;

		[JsonSchema(Description = "Unity's HumanDescription.legStretch")]
		public float legStretch = 0.05f;

		[JsonSchema(Description = "Unity's HumanDescription.upperArmTwist")]
		public float upperArmTwist = 0.5f;

		[JsonSchema(Description = "Unity's HumanDescription.lowerArmTwist")]
		public float lowerArmTwist = 0.5f;

		[JsonSchema(Description = "Unity's HumanDescription.upperLegTwist")]
		public float upperLegTwist = 0.5f;

		[JsonSchema(Description = "Unity's HumanDescription.lowerLegTwist")]
		public float lowerLegTwist = 0.5f;

		[JsonSchema(Description = "Unity's HumanDescription.feetSpacing")]
		public float feetSpacing;

		[JsonSchema(Description = "Unity's HumanDescription.hasTranslationDoF")]
		public bool hasTranslationDoF;

		public void SetNodeIndex(HumanBodyBones _key, int node)
		{
			VRMBone key = _key.FromHumanBodyBone();
			int num = humanBones.FindIndex((glTF_VRM_HumanoidBone x) => x.vrmBone == key);
			if (num == -1 || humanBones[num] == null)
			{
				humanBones.Add(new glTF_VRM_HumanoidBone
				{
					vrmBone = key,
					node = node
				});
			}
			else
			{
				humanBones[num].node = node;
			}
		}

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.Key("humanBones");
			f.GLTFValue(humanBones);
			f.KeyValue(() => armStretch);
			f.KeyValue(() => legStretch);
			f.KeyValue(() => upperArmTwist);
			f.KeyValue(() => lowerArmTwist);
			f.KeyValue(() => upperLegTwist);
			f.KeyValue(() => lowerLegTwist);
			f.KeyValue(() => feetSpacing);
			f.KeyValue(() => hasTranslationDoF);
		}

		public void Apply(AvatarDescription desc, List<Transform> nodes)
		{
			armStretch = desc.armStretch;
			legStretch = desc.legStretch;
			upperArmTwist = desc.upperArmTwist;
			lowerArmTwist = desc.lowerArmTwist;
			upperLegTwist = desc.upperLegTwist;
			lowerLegTwist = desc.lowerArmTwist;
			feetSpacing = desc.feetSpacing;
			hasTranslationDoF = desc.hasTranslationDoF;
			BoneLimit[] human = desc.human;
			for (int i = 0; i < human.Length; i++)
			{
				BoneLimit x = human[i];
				VRMBone key = x.humanBone.FromHumanBodyBone();
				glTF_VRM_HumanoidBone glTF_VRM_HumanoidBone2 = humanBones.FirstOrDefault((glTF_VRM_HumanoidBone y) => y.vrmBone == key);
				if (glTF_VRM_HumanoidBone2 == null)
				{
					glTF_VRM_HumanoidBone2 = new glTF_VRM_HumanoidBone
					{
						vrmBone = key
					};
					humanBones.Add(glTF_VRM_HumanoidBone2);
				}
				glTF_VRM_HumanoidBone2.node = nodes.FindIndex((Transform y) => y.name == x.boneName);
				glTF_VRM_HumanoidBone2.useDefaultValues = x.useDefaultValues;
				glTF_VRM_HumanoidBone2.axisLength = x.axisLength;
				glTF_VRM_HumanoidBone2.center = x.center;
				glTF_VRM_HumanoidBone2.max = x.max;
				glTF_VRM_HumanoidBone2.min = x.min;
			}
		}

		public AvatarDescription ToDescription(List<Transform> nodes)
		{
			AvatarDescription avatarDescription = ScriptableObject.CreateInstance<AvatarDescription>();
			avatarDescription.upperLegTwist = upperLegTwist;
			avatarDescription.lowerLegTwist = lowerLegTwist;
			avatarDescription.upperArmTwist = upperArmTwist;
			avatarDescription.lowerArmTwist = lowerArmTwist;
			avatarDescription.armStretch = armStretch;
			avatarDescription.legStretch = legStretch;
			avatarDescription.hasTranslationDoF = hasTranslationDoF;
			BoneLimit[] array = new BoneLimit[humanBones.Count];
			int num = 0;
			foreach (glTF_VRM_HumanoidBone humanBone in humanBones)
			{
				if (humanBone.node >= 0 && humanBone.node < nodes.Count)
				{
					array[num] = new BoneLimit
					{
						boneName = nodes[humanBone.node].name,
						useDefaultValues = humanBone.useDefaultValues,
						axisLength = humanBone.axisLength,
						center = humanBone.center,
						min = humanBone.min,
						max = humanBone.max,
						humanBone = humanBone.vrmBone.ToHumanBodyBone()
					};
					num++;
				}
			}
			avatarDescription.human = array;
			return avatarDescription;
		}
	}
}

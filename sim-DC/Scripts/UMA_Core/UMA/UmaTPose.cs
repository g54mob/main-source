using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UMA
{
	[Serializable]
	[PreferBinarySerialization]
	public class UmaTPose : ScriptableObject
	{
		[NonSerialized]
		public SkeletonBone[] boneInfo;

		[NonSerialized]
		public HumanBone[] humanInfo;

		[NonSerialized]
		public float armStretch;

		[NonSerialized]
		public float feetSpacing;

		[NonSerialized]
		public float legStretch;

		[NonSerialized]
		public float lowerArmTwist;

		[NonSerialized]
		public float lowerLegTwist;

		[NonSerialized]
		public float upperArmTwist;

		[NonSerialized]
		public float upperLegTwist;

		[NonSerialized]
		public bool extendedInfo;

		[HideInInspector]
		public byte[] serializedChunk;

		public void Serialize()
		{
		}

		public void DeSerialize()
		{
		}

		public UmaTPose Clone()
		{
			return null;
		}

		private SkeletonBone DeSerializeSkeletonBone(BinaryReader br)
		{
			return default(SkeletonBone);
		}

		private Quaternion DeSerializeQuaternion(BinaryReader br)
		{
			return default(Quaternion);
		}

		private HumanBone DeSerializeHumanBone(BinaryReader br)
		{
			return default(HumanBone);
		}

		private HumanLimit DeSerializeHumanLimit(BinaryReader br)
		{
			return default(HumanLimit);
		}

		private Vector3 DeserializeVector3(BinaryReader br)
		{
			return default(Vector3);
		}

		private void Serialize(BinaryWriter bn, HumanBone value)
		{
		}

		private void Serialize(BinaryWriter bn, HumanLimit value)
		{
		}

		private void Serialize(BinaryWriter bn, SkeletonBone bone)
		{
		}

		private void Serialize(BinaryWriter bn, Quaternion value)
		{
		}

		private void Serialize(BinaryWriter bn, Vector3 value)
		{
		}

		public void ReadFromHumanDescription(HumanDescription description)
		{
		}

		public void ReadFromTransform(Animator rootAnimator)
		{
		}

		private void ExtractHumanInfo(Animator animator, List<HumanBone> humanInfoList)
		{
		}

		private void AddRecursively(List<SkeletonBone> boneInfoList, Transform root)
		{
		}

		public string BoneNameFromHumanName(string humanName)
		{
			return null;
		}
	}
}

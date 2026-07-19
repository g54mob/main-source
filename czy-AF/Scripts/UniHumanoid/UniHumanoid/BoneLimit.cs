using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniHumanoid
{
	[Serializable]
	public struct BoneLimit
	{
		public HumanBodyBones humanBone;

		public string boneName;

		public bool useDefaultValues;

		public Vector3 min;

		public Vector3 max;

		public Vector3 center;

		public float axisLength;

		private static string[] cashedHumanTraitBoneName;

		public static BoneLimit From(HumanBone bone)
		{
			return new BoneLimit
			{
				humanBone = (HumanBodyBones)Enum.Parse(typeof(HumanBodyBones), bone.humanName.Replace(" ", ""), ignoreCase: true),
				boneName = bone.boneName,
				useDefaultValues = bone.limit.useDefaultValues,
				min = bone.limit.min,
				max = bone.limit.max,
				center = bone.limit.center,
				axisLength = bone.limit.axisLength
			};
		}

		public static string ToHumanBoneName(HumanBodyBones b)
		{
			if (cashedHumanTraitBoneName == null)
			{
				cashedHumanTraitBoneName = HumanTrait.BoneName;
			}
			string[] array = cashedHumanTraitBoneName;
			foreach (string text in array)
			{
				if (text.Replace(" ", "") == b.ToString())
				{
					return text;
				}
			}
			throw new KeyNotFoundException();
		}

		public HumanBone ToHumanBone()
		{
			return new HumanBone
			{
				boneName = boneName,
				humanName = ToHumanBoneName(humanBone),
				limit = new HumanLimit
				{
					useDefaultValues = useDefaultValues,
					axisLength = axisLength,
					center = center,
					max = max,
					min = min
				}
			};
		}
	}
}

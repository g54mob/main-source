using System.Collections.Generic;
using Synty.SidekickCharacters.Enums;
using UnityEngine;

namespace Synty.SidekickCharacters.Blendshapes
{
	public static class BlendshapeJointAdjustment
	{
		private static readonly Vector3 FEMININE_OFFSET_HIP_ATTACH_BACK;

		private static readonly Vector3 FEMININE_OFFSET_HIP_ATTACH_L;

		private static readonly Vector3 FEMININE_OFFSET_HIP_ATTACH_FRONT;

		private static readonly Vector3 FEMININE_OFFSET_KNEE_ATTACH_L;

		private static readonly Vector3 FEMININE_OFFSET_KNEE_ATTACH_R;

		private static readonly Vector3 FEMININE_OFFSET_HIP_ATTACH_R;

		private static readonly Vector3 FEMININE_OFFSET_ELBOW_ATTACH_R;

		private static readonly Vector3 FEMININE_OFFSET_SHOULDER_ATTACH_R;

		private static readonly Vector3 FEMININE_OFFSET_BACK_ATTACH;

		private static readonly Vector3 FEMININE_OFFSET_SHOULDER_ATTACH_L;

		private static readonly Vector3 FEMININE_OFFSET_ELBOW_ATTACH_L;

		private static readonly Vector3 HEAVY_OFFSET_HIP_ATTACH_BACK;

		private static readonly Vector3 HEAVY_OFFSET_HIP_ATTACH_L;

		private static readonly Vector3 HEAVY_OFFSET_HIP_ATTACH_FRONT;

		private static readonly Vector3 HEAVY_OFFSET_KNEE_ATTACH_L;

		private static readonly Vector3 HEAVY_OFFSET_KNEE_ATTACH_R;

		private static readonly Vector3 HEAVY_OFFSET_HIP_ATTACH_R;

		private static readonly Vector3 HEAVY_OFFSET_ELBOW_ATTACH_R;

		private static readonly Vector3 HEAVY_OFFSET_SHOULDER_ATTACH_R;

		private static readonly Vector3 HEAVY_OFFSET_BACK_ATTACH;

		private static readonly Vector3 HEAVY_OFFSET_SHOULDER_ATTACH_L;

		private static readonly Vector3 HEAVY_OFFSET_ELBOW_ATTACH_L;

		private static readonly Vector3 SKINNY_OFFSET_HIP_ATTACH_BACK;

		private static readonly Vector3 SKINNY_OFFSET_HIP_ATTACH_L;

		private static readonly Vector3 SKINNY_OFFSET_HIP_ATTACH_FRONT;

		private static readonly Vector3 SKINNY_OFFSET_KNEE_ATTACH_L;

		private static readonly Vector3 SKINNY_OFFSET_KNEE_ATTACH_R;

		private static readonly Vector3 SKINNY_OFFSET_HIP_ATTACH_R;

		private static readonly Vector3 SKINNY_OFFSET_ELBOW_ATTACH_R;

		private static readonly Vector3 SKINNY_OFFSET_SHOULDER_ATTACH_R;

		private static readonly Vector3 SKINNY_OFFSET_BACK_ATTACH;

		private static readonly Vector3 SKINNY_OFFSET_SHOULDER_ATTACH_L;

		private static readonly Vector3 SKINNY_OFFSET_ELBOW_ATTACH_L;

		private static readonly Vector3 BULK_OFFSET_HIP_ATTACH_BACK;

		private static readonly Vector3 BULK_OFFSET_HIP_ATTACH_L;

		private static readonly Vector3 BULK_OFFSET_HIP_ATTACH_FRONT;

		private static readonly Vector3 BULK_OFFSET_KNEE_ATTACH_L;

		private static readonly Vector3 BULK_OFFSET_KNEE_ATTACH_R;

		private static readonly Vector3 BULK_OFFSET_HIP_ATTACH_R;

		private static readonly Vector3 BULK_OFFSET_ELBOW_ATTACH_R;

		private static readonly Vector3 BULK_OFFSET_SHOULDER_ATTACH_R;

		private static readonly Vector3 BULK_OFFSET_BACK_ATTACH;

		private static readonly Vector3 BULK_OFFSET_SHOULDER_ATTACH_L;

		private static readonly Vector3 BULK_OFFSET_ELBOW_ATTACH_L;

		public static readonly Dictionary<CharacterPartType, string> PART_TYPE_JOINT_MAP;

		public static Vector3 GetCombinedOffsetValue(float blendValueFeminine, float blendValueSize, float blendValueMuscle, Vector3 currentPosition, CharacterPartType partType)
		{
			return default(Vector3);
		}
	}
}

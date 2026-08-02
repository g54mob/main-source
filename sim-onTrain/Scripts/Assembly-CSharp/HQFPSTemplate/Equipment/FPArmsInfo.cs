using System;
using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	[Serializable]
	public struct FPArmsInfo
	{
		public string Name;

		[Space(3f)]
		public SkinnedMeshRenderer LeftArm;

		public SkinnedMeshRenderer RightArm;
	}
}

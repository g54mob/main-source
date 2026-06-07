using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public class UMADynamicBoneJiggle : MonoBehaviour
	{
		[Header("General Settings")]
		public string jiggleBoneName;

		public string[] AdditionalBones;

		public List<string> exceptions;

		[Range(0f, 1f)]
		public float reduceEffect;

		[Header("Removable Bone Settings")]
		public bool deleteBoneWithSlot;

		public string slotToWatch;

		private string linkedRecipe;

		public void AddJiggle(UMAData umaData)
		{
		}

		public void AddBoneJiggle(UMAData umaData, Transform rootBone, UMABoneCleaner cleaner)
		{
		}
	}
}

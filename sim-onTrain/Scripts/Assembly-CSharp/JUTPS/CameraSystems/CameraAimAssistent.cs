using System;
using System.Collections.Generic;
using JUTPS.AI;
using UnityEngine;

namespace JUTPS.CameraSystems
{
	[AddComponentMenu("JU TPS/Third Person System/Cameras/Additional/Aim Assistent")]
	public class CameraAimAssistent : MonoBehaviour
	{
		[Serializable]
		public class TargetTagOffset
		{
			public string Tag = "Enemy";

			public float UpOffset;

			public TargetTagOffset(string tag, float upOffset)
			{
				Tag = tag;
				UpOffset = upOffset;
			}

			public static float GetUpOffset(TargetTagOffset[] targetTagList, GameObject objectTag)
			{
				if (objectTag == null || targetTagList == null)
				{
					return 0f;
				}
				foreach (TargetTagOffset targetTagOffset in targetTagList)
				{
					if (targetTagOffset.Tag == objectTag.tag)
					{
						return targetTagOffset.UpOffset;
					}
				}
				return 0f;
			}
		}

		private JUCameraController targetCamera;

		public float DistanceToDetect = 50f;

		public float AssistentForce = 3f;

		public LayerMask TargetLayer;

		public TargetTagOffset[] TargetsTagsAndOffsets = new TargetTagOffset[1]
		{
			new TargetTagOffset("Enemy", 1f)
		};

		private string[] AllTags;

		private GameObject ObjectInCameraCenter;

		private float UpOffset => TargetTagOffset.GetUpOffset(TargetsTagsAndOffsets, ObjectInCameraCenter);

		private void Start()
		{
			targetCamera = GetComponent<JUCameraController>();
			List<string> list = new List<string>();
			TargetTagOffset[] targetsTagsAndOffsets = TargetsTagsAndOffsets;
			foreach (TargetTagOffset targetTagOffset in targetsTagsAndOffsets)
			{
				list.Add(targetTagOffset.Tag);
			}
			AllTags = list.ToArray();
		}

		private void Update()
		{
			ObjectInCameraCenter = targetCamera.GetObjectOnCameraCenter(DistanceToDetect, TargetLayer);
			if (!(ObjectInCameraCenter == null) && JUCharacterArtificialInteligenceBrain.TagMatches(ObjectInCameraCenter.tag, AllTags))
			{
				Vector3 eulerAngles = Quaternion.LookRotation((ObjectInCameraCenter.transform.position + base.transform.up * UpOffset - targetCamera.mCamera.transform.position).normalized).eulerAngles;
				targetCamera.rotytarget = Mathf.LerpAngle(targetCamera.rotytarget, eulerAngles.y, AssistentForce * Time.deltaTime);
				targetCamera.rotxtarget = Mathf.LerpAngle(targetCamera.rotxtarget, eulerAngles.x, AssistentForce * Time.deltaTime);
			}
		}
	}
}

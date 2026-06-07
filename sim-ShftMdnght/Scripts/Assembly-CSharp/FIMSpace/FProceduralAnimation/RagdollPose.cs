using System;
using System.Collections.Generic;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[Serializable]
	public class RagdollPose
	{
		[Serializable]
		public struct BonePose
		{
			public Transform SourceBone;

			public Vector3 localPosition;

			public Vector3 rootSpacePosition;

			public Quaternion localRotation;

			public Quaternion rootSpaceRotation;

			public void RefreshData(Transform baseTransform)
			{
				if (!(SourceBone == null))
				{
					localPosition = SourceBone.localPosition;
					localRotation = SourceBone.localRotation;
					rootSpacePosition = baseTransform.InverseTransformPoint(SourceBone.position);
					rootSpaceRotation = baseTransform.rotation.QToLocal(SourceBone.rotation);
				}
			}

			public void ApplyOnScene()
			{
				SourceBone.localPosition = localPosition;
				SourceBone.localRotation = localRotation;
				OnChange();
			}

			public void ApplyOnScene(Transform baseTransform)
			{
				SourceBone.position = baseTransform.TransformPoint(rootSpacePosition);
				SourceBone.rotation = baseTransform.rotation.QToWorld(rootSpaceRotation);
				OnChange();
			}

			private void OnChange()
			{
			}
		}

		[HideInInspector]
		public List<BonePose> BonePoses = new List<BonePose>();

		public Transform LastBaseTransform;

		public void ClearPose()
		{
			BonePoses.Clear();
		}

		public void UpdateBone(Transform bone, Transform baseTransform)
		{
			LastBaseTransform = baseTransform;
			for (int i = 0; i < BonePoses.Count; i++)
			{
				if (BonePoses[i].SourceBone == bone)
				{
					BonePoses[i].RefreshData(baseTransform);
					return;
				}
			}
			BonePose item = default(BonePose);
			item.SourceBone = bone;
			item.RefreshData(baseTransform);
			BonePoses.Add(item);
		}

		public BonePose? Contains(Transform bone)
		{
			for (int i = 0; i < BonePoses.Count; i++)
			{
				if (BonePoses[i].SourceBone == bone)
				{
					return BonePoses[i];
				}
			}
			return null;
		}

		public bool CheckIfAnyDiffers(Transform baseTransform)
		{
			if (LastBaseTransform != baseTransform)
			{
				return true;
			}
			CheckForNulls();
			for (int i = 0; i < BonePoses.Count; i++)
			{
				BonePose bonePose = BonePoses[i];
				if (bonePose.localPosition != bonePose.SourceBone.localPosition)
				{
					return true;
				}
				if (bonePose.localRotation != bonePose.SourceBone.localRotation)
				{
					return true;
				}
			}
			return false;
		}

		public void CheckForNulls()
		{
			for (int num = BonePoses.Count - 1; num >= 0; num--)
			{
				if (BonePoses[num].SourceBone == null)
				{
					BonePoses.RemoveAt(num);
				}
			}
		}

		public void ApplyPose(Transform baseTransform)
		{
			if (baseTransform != null && baseTransform == LastBaseTransform)
			{
				for (int i = 0; i < BonePoses.Count; i++)
				{
					BonePoses[i].ApplyOnScene(baseTransform);
				}
			}
			else
			{
				for (int j = 0; j < BonePoses.Count; j++)
				{
					BonePoses[j].ApplyOnScene();
				}
			}
		}
	}
}

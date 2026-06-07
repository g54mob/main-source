using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-80)]
public class OVRCustomSkeleton : OVRSkeleton
{
	[SerializeField]
	private bool _applyBoneTranslations = true;

	[HideInInspector]
	[SerializeField]
	private List<Transform> _customBones_V2 = new List<Transform>(new Transform[50]);

	public List<Transform> CustomBones => _customBones_V2;

	protected override void InitializeBones()
	{
		bool flag = _skeletonType == SkeletonType.HandLeft || _skeletonType == SkeletonType.HandRight;
		if (_bones == null || _bones.Count != _skeleton.NumBones)
		{
			_bones = new List<OVRBone>(new OVRBone[_skeleton.NumBones]);
			base.Bones = _bones.AsReadOnly();
		}
		for (int i = 0; i < _bones.Count; i++)
		{
			OVRBone oVRBone = _bones[i] ?? (_bones[i] = new OVRBone());
			oVRBone.Id = (BoneId)_skeleton.Bones[i].Id;
			oVRBone.ParentBoneIndex = _skeleton.Bones[i].ParentBoneIndex;
			oVRBone.Transform = _customBones_V2[(int)oVRBone.Id];
			if (_applyBoneTranslations)
			{
				oVRBone.Transform.localPosition = (flag ? _skeleton.Bones[i].Pose.Position.FromFlippedXVector3f() : _skeleton.Bones[i].Pose.Position.FromFlippedZVector3f());
			}
			oVRBone.Transform.localRotation = (flag ? _skeleton.Bones[i].Pose.Orientation.FromFlippedXQuatf() : _skeleton.Bones[i].Pose.Orientation.FromFlippedZQuatf());
		}
	}
}

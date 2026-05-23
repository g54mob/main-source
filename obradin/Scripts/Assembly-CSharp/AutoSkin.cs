using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AutoSkin : MonoBehaviour
{
	[Serializable]
	public class AttachInfo
	{
		public List<Matrix4x4> bindPoses = new List<Matrix4x4>();

		public List<Transform> boneTransforms = new List<Transform>();
	}

	public AttachInfo attachInfo;

	private void OnEnable()
	{
		if (attachInfo != null)
		{
			SkinnedMeshRenderer component = base.gameObject.GetComponent<SkinnedMeshRenderer>();
			component.sharedMesh.bindposes = attachInfo.bindPoses.ToArray();
			component.bones = attachInfo.boneTransforms.ToArray();
		}
	}
}

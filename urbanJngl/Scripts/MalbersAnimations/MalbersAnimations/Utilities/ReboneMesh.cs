using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Mesh/Rebone Mesh")]
	public class ReboneMesh : MonoBehaviour
	{
		[ContextMenuItem("Transfer Bones From Root", "TransferRootBone")]
		public Transform RootBone;

		[ContextMenu("Transfer Bones From Root")]
		public void TransferRootBone()
		{
			if (RootBone != null)
			{
				CopyBonesSameBones();
			}
		}

		private void CopyBonesSameBones()
		{
			if (!TryGetComponent<SkinnedMeshRenderer>(out var component))
			{
				return;
			}
			Transform rootBone = component.rootBone;
			Transform[] componentsInChildren = RootBone.GetComponentsInChildren<Transform>();
			Dictionary<string, Transform> dictionary = new Dictionary<string, Transform>();
			Transform[] array = componentsInChildren;
			foreach (Transform transform in array)
			{
				dictionary[transform.name] = transform;
			}
			Transform[] bones = component.bones;
			for (int j = 0; j < bones.Length; j++)
			{
				string text = bones[j].name;
				if (!dictionary.TryGetValue(text, out bones[j]))
				{
					Debug.LogError("failed to get bone: " + text);
				}
			}
			component.bones = bones;
			if (dictionary.TryGetValue(rootBone.name, out var value))
			{
				component.rootBone = value;
			}
			Debug.Log("Bone Trasfer Completed: " + base.name);
		}

		private void Reset()
		{
			if (RootBone == null)
			{
				SkinnedMeshRenderer[] componentsInChildren = base.transform.root.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				SkinnedMeshRenderer thisRenderer = GetComponent<SkinnedMeshRenderer>();
				SkinnedMeshRenderer skinnedMeshRenderer = componentsInChildren.ToList().Find((SkinnedMeshRenderer x) => x.name == base.name && x != thisRenderer);
				if (skinnedMeshRenderer != null)
				{
					RootBone = skinnedMeshRenderer.rootBone;
				}
			}
		}
	}
}

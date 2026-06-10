using FoxyVoxel.Logging;
using UnityEngine;

namespace NSMedieval
{
	public class SkinnedMeshAdding : MonoBehaviour
	{
		[SerializeField]
		public Transform newArmature;

		[SerializeField]
		private string rootBoneName = "Motion";

		[SerializeField]
		private GameObject partToAdd;

		[SerializeField]
		private Material materialForNewPart;

		public void Rebind()
		{
			if (newArmature == null)
			{
				Log.Info("No new armature assigned", "C:\\GIT\\dev\\Assets\\Scripts\\SkinedMeshDressing\\SkinnedMeshAdding.cs");
			}
			if (newArmature.Find(rootBoneName) == null)
			{
				Log.Info("Root bone not found", "C:\\GIT\\dev\\Assets\\Scripts\\SkinedMeshDressing\\SkinnedMeshAdding.cs");
				return;
			}
			SkinnedMeshRenderer componentInChildren = base.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
			Transform[] bones = componentInChildren.bones;
			componentInChildren.rootBone = newArmature.Find(rootBoneName);
			Transform[] componentsInChildren = newArmature.GetComponentsInChildren<Transform>();
			for (int i = 0; i < bones.Length; i++)
			{
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					if (bones[i].name == componentsInChildren[j].name)
					{
						bones[i] = componentsInChildren[j];
						break;
					}
				}
			}
			componentInChildren.bones = bones;
		}
	}
}

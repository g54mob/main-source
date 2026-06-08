using System.Collections.Generic;
using UnityEngine;

namespace Kitchen
{
	public class PlayerOutfitComponent : MonoBehaviour
	{
		public SkinnedMeshRenderer Source;

		public List<SkinnedMeshRenderer> Renderers = new List<SkinnedMeshRenderer>();

		public List<Renderer> Hats = new List<Renderer>();

		public GameObject AttachToHeadBone;

		private void Start()
		{
			if (Source != null)
			{
				SetupBones(Source);
			}
		}

		public void SetHatVisibility(bool visible)
		{
			if (Hats == null)
			{
				return;
			}
			foreach (Renderer hat in Hats)
			{
				if (hat != null)
				{
					hat.gameObject.SetActive(visible);
				}
			}
		}

		public void SetupBones(SkinnedMeshRenderer source)
		{
			foreach (SkinnedMeshRenderer renderer in Renderers)
			{
				renderer.bones = source.bones;
				renderer.updateWhenOffscreen = true;
			}
			Transform[] bones = source.bones;
			foreach (Transform transform in bones)
			{
				if (transform.name == "Head" && AttachToHeadBone != null)
				{
					AttachToHeadBone.transform.parent = transform.transform;
					AttachToHeadBone.transform.Reset();
				}
			}
		}

		private void OnDestroy()
		{
			if (AttachToHeadBone != null)
			{
				Object.Destroy(AttachToHeadBone);
			}
		}
	}
}

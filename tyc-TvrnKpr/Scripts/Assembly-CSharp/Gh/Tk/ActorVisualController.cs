using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class ActorVisualController : MonoBehaviour
	{
		[Serializable]
		public struct ActorPrefabDescr
		{
			public string type;

			public string prefabId;
		}

		[SerializeField]
		private MB3_MeshBaker _meshBaker;

		public ActorPrefabDescr[] ActorTypePrefabs;

		private Dictionary<string, ActorPrefabDescr> _actorTypePrefabDictionary;

		public List<string> excludeStaffVariantsWhenPicking;

		private static string _variantPrefix;

		public List<GameObject> staffServiceModels;

		public Material staffOutfitMaterial;

		public Texture2D[] staffOutfitTextures;

		public Texture2D dogsbodySkinPixelsTexture;

		[Tooltip("Index 0-4 refers to tier 1-5 of the entertainer profile")]
		[SerializeField]
		private List<GameObject> _entertainerModels;

		[SerializeField]
		private List<GameObject> eyePrefabs;

		private void Start()
		{
		}

		private void CheckPrefabs()
		{
		}

		public ActorPrefabDescr GetDescription(string actorTemplateId)
		{
			return default(ActorPrefabDescr);
		}

		public GameObject GetPyjamaModel(ActorData data)
		{
			return null;
		}

		private void PickPrefabVariant(Staff staff)
		{
		}

		public GameObject GetStaffModel(Staff staff, int skillTier)
		{
			return null;
		}

		private GameObject FindStaffModel(string key)
		{
			return null;
		}

		private void CopyBones(SkinnedMeshRenderer smr)
		{
		}

		public static string GetBonePath(Transform rootBone, Transform boneTransform)
		{
			return null;
		}

		private void MergeBones(SkinnedMeshRenderer main, SkinnedMeshRenderer secondary)
		{
		}

		public GameObject GetEntertainerModel(int profileTier)
		{
			return null;
		}

		public GameObject GetEyePrefab(string headModelName)
		{
			return null;
		}

		public void PrepareActorAnimator(GameObject model, ActorData data)
		{
		}
	}
}

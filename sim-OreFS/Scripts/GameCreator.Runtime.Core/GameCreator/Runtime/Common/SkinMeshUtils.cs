using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	internal static class SkinMeshUtils
	{
		private const string NAME = "Armature-{0}";

		public static GameObject PutOn(GameObject prefab, Animator animator)
		{
			if (prefab == null || animator == null)
			{
				return null;
			}
			Transform transform = animator.transform;
			Armature armature = new Armature(animator.GetComponentInParent<Character>(), transform);
			GameObject gameObject = Object.Instantiate(prefab, transform.position, transform.rotation);
			gameObject.name = $"Armature-{prefab.name}";
			SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
			Transform transform2 = SetupSkin(gameObject.transform, transform);
			SkinnedMeshRenderer[] array = componentsInChildren;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
			{
				AddSkinnedMeshRenderer(skinnedMeshRenderer, transform2).bones = GetTransforms(skinnedMeshRenderer.bones, armature);
			}
			return transform2.gameObject;
		}

		public static void TakeOff(GameObject instance)
		{
			if (!(instance == null))
			{
				Object.Destroy(instance);
			}
		}

		public static void TakeOff(GameObject prefab, Animator animator)
		{
			if (!(prefab == null) && !(animator == null))
			{
				string n = $"Armature-{prefab.name}";
				Transform transform = animator.transform.Find(n);
				if (!(transform == null))
				{
					Object.Destroy(transform.gameObject);
				}
			}
		}

		private static Transform SetupSkin(Transform source, Transform parent)
		{
			Animator component = source.GetComponent<Animator>();
			if (component != null)
			{
				Object.Destroy(component);
			}
			source.SetParent(parent);
			for (int num = source.childCount - 1; num >= 0; num--)
			{
				Object.Destroy(source.GetChild(num).gameObject);
			}
			return source;
		}

		private static SkinnedMeshRenderer AddSkinnedMeshRenderer(SkinnedMeshRenderer source, Transform parent)
		{
			GameObject gameObject = new GameObject(source.name);
			gameObject.transform.SetParent(parent);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			SkinnedMeshRenderer skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();
			skinnedMeshRenderer.sharedMesh = source.sharedMesh;
			skinnedMeshRenderer.sharedMaterials = source.sharedMaterials;
			return skinnedMeshRenderer;
		}

		private static Transform[] GetTransforms(Transform[] sources, Armature armature)
		{
			Transform[] array = new Transform[sources.Length];
			for (int i = 0; i < sources.Length; i++)
			{
				array[i] = armature.Get(sources[i].name);
			}
			return array;
		}
	}
}

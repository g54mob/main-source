using System;
using System.Collections.Generic;
using System.Linq;
using UniGLTF;
using UnityEngine;

namespace VRM
{
	public class VRMFirstPerson : MonoBehaviour
	{
		[Serializable]
		public struct RendererFirstPersonFlags
		{
			public Renderer Renderer;

			public FirstPersonFlag FirstPersonFlag;

			public Mesh SharedMesh
			{
				get
				{
					SkinnedMeshRenderer skinnedMeshRenderer = Renderer as SkinnedMeshRenderer;
					if (skinnedMeshRenderer != null)
					{
						return skinnedMeshRenderer.sharedMesh;
					}
					MeshFilter component = Renderer.GetComponent<MeshFilter>();
					if (component != null)
					{
						return component.sharedMesh;
					}
					return null;
				}
			}
		}

		public static bool TriedSetupLayer = false;

		public static int FIRSTPERSON_ONLY_LAYER = 9;

		public static int THIRDPERSON_ONLY_LAYER = 10;

		[SerializeField]
		public Transform FirstPersonBone;

		[SerializeField]
		public Vector3 FirstPersonOffset;

		[SerializeField]
		public List<RendererFirstPersonFlags> Renderers = new List<RendererFirstPersonFlags>();

		private bool m_done;

		private List<Mesh> m_headlessMeshes = new List<Mesh>();

		private static IEnumerable<Transform> Traverse(Transform parent)
		{
			yield return parent;
			foreach (Transform item in parent)
			{
				foreach (Transform item2 in Traverse(item))
				{
					yield return item2;
				}
			}
		}

		public void CopyTo(GameObject _dst, Dictionary<Transform, Transform> map)
		{
			VRMFirstPerson vRMFirstPerson = _dst.AddComponent<VRMFirstPerson>();
			vRMFirstPerson.FirstPersonBone = map[FirstPersonBone];
			vRMFirstPerson.FirstPersonOffset = FirstPersonOffset;
			vRMFirstPerson.Renderers = Renderers.Select(delegate(RendererFirstPersonFlags x)
			{
				Renderer component = map[x.Renderer.transform].GetComponent<Renderer>();
				return new RendererFirstPersonFlags
				{
					Renderer = component,
					FirstPersonFlag = x.FirstPersonFlag
				};
			}).ToList();
		}

		public void SetDefault()
		{
			FirstPersonOffset = new Vector3(0f, 0.06f, 0f);
			Animator component = GetComponent<Animator>();
			if (component != null)
			{
				FirstPersonBone = component.GetBoneTransform(HumanBodyBones.Head);
			}
		}

		private void Reset()
		{
			SetDefault();
			TraverseRenderers();
		}

		public void TraverseRenderers(VRMImporterContext context = null)
		{
			Renderers.Clear();
			Renderer[] componentsInChildren = base.transform.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				RendererFirstPersonFlags item = new RendererFirstPersonFlags
				{
					Renderer = renderer,
					FirstPersonFlag = ((context != null) ? GetFirstPersonFlag(context, renderer) : FirstPersonFlag.Auto)
				};
				Renderers.Add(item);
			}
		}

		private static FirstPersonFlag GetFirstPersonFlag(VRMImporterContext context, Renderer r)
		{
			Mesh mesh = r.transform.GetSharedMesh();
			if (mesh == null)
			{
				return FirstPersonFlag.Auto;
			}
			int num = context.Meshes.FindIndex((MeshWithMaterials x) => x.Mesh == mesh);
			if (num == -1)
			{
				return FirstPersonFlag.Auto;
			}
			foreach (glTF_VRM_MeshAnnotation meshAnnotation in context.GLTF.extensions.VRM.firstPerson.meshAnnotations)
			{
				if (meshAnnotation.mesh == num)
				{
					return CacheEnum.TryParseOrDefault(meshAnnotation.firstPersonFlag, ignoreCase: true, FirstPersonFlag.Auto);
				}
			}
			return FirstPersonFlag.Auto;
		}

		private Mesh CreateHeadlessModel(Renderer _renderer, Transform EraseRoot)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = _renderer as SkinnedMeshRenderer;
			if (skinnedMeshRenderer != null)
			{
				return CreateHeadlessModelForSkinnedMeshRenderer(skinnedMeshRenderer, EraseRoot);
			}
			MeshRenderer meshRenderer = _renderer as MeshRenderer;
			if (meshRenderer != null)
			{
				CreateHeadlessModelForMeshRenderer(meshRenderer, EraseRoot);
				return null;
			}
			return null;
		}

		public static void SetupLayers()
		{
			if (!TriedSetupLayer)
			{
				TriedSetupLayer = true;
				int num = LayerMask.NameToLayer("VRMFirstPersonOnly");
				FIRSTPERSON_ONLY_LAYER = ((num == -1) ? FIRSTPERSON_ONLY_LAYER : num);
				num = LayerMask.NameToLayer("VRMThirdPersonOnly");
				THIRDPERSON_ONLY_LAYER = ((num == -1) ? THIRDPERSON_ONLY_LAYER : num);
			}
		}

		private static void CreateHeadlessModelForMeshRenderer(MeshRenderer renderer, Transform eraseRoot)
		{
			if (renderer.transform.Ancestors().Any((Transform x) => x == eraseRoot))
			{
				SetupLayers();
				renderer.gameObject.layer = THIRDPERSON_ONLY_LAYER;
			}
		}

		private static Mesh CreateHeadlessModelForSkinnedMeshRenderer(SkinnedMeshRenderer renderer, Transform eraseRoot)
		{
			SetupLayers();
			Transform[] bones = renderer.bones;
			int[] array = (from x in bones.Select(delegate(Transform x, int i)
				{
					bool erase = x.Ancestor().Any((Transform y) => y == eraseRoot);
					return new { i, erase };
				})
				where x.erase
				select x.i).ToArray();
			if (array.Length == 0)
			{
				return null;
			}
			renderer.gameObject.layer = THIRDPERSON_ONLY_LAYER;
			Mesh mesh = BoneMeshEraser.CreateErasedMesh(renderer.sharedMesh, array);
			if (mesh.triangles.Length == 0)
			{
				UnityEngine.Object.Destroy(mesh);
				return null;
			}
			GameObject obj = new GameObject("_headless_" + renderer.name);
			obj.layer = FIRSTPERSON_ONLY_LAYER;
			obj.transform.SetParent(renderer.transform, worldPositionStays: false);
			SkinnedMeshRenderer skinnedMeshRenderer = obj.AddComponent<SkinnedMeshRenderer>();
			skinnedMeshRenderer.sharedMesh = mesh;
			skinnedMeshRenderer.sharedMaterials = renderer.sharedMaterials;
			skinnedMeshRenderer.bones = bones;
			skinnedMeshRenderer.rootBone = renderer.rootBone;
			skinnedMeshRenderer.updateWhenOffscreen = true;
			return mesh;
		}

		public void Setup()
		{
			SetupLayers();
			if (m_done)
			{
				return;
			}
			m_done = true;
			foreach (RendererFirstPersonFlags renderer in Renderers)
			{
				switch (renderer.FirstPersonFlag)
				{
				case FirstPersonFlag.Auto:
				{
					Mesh mesh = CreateHeadlessModel(renderer.Renderer, FirstPersonBone);
					if (mesh != null)
					{
						m_headlessMeshes.Add(mesh);
					}
					break;
				}
				case FirstPersonFlag.FirstPersonOnly:
					renderer.Renderer.gameObject.layer = FIRSTPERSON_ONLY_LAYER;
					break;
				case FirstPersonFlag.ThirdPersonOnly:
					renderer.Renderer.gameObject.layer = THIRDPERSON_ONLY_LAYER;
					break;
				}
			}
		}

		private void OnDestroy()
		{
			foreach (Mesh headlessMesh in m_headlessMeshes)
			{
				if (headlessMesh != null)
				{
					UnityEngine.Object.Destroy(headlessMesh);
				}
			}
			m_headlessMeshes.Clear();
		}
	}
}

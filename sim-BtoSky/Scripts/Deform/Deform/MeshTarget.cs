using System;
using UnityEngine;

namespace Deform
{
	[Serializable]
	public class MeshTarget
	{
		[SerializeField]
		[HideInInspector]
		private MeshFilter meshFilter;

		[SerializeField]
		[HideInInspector]
		private SkinnedMeshRenderer skinnedMeshRenderer;

		public static bool IsValid(GameObject target)
		{
			if (target.GetComponent<MeshFilter>() == null && target.GetComponent<SkinnedMeshRenderer>() == null)
			{
				return false;
			}
			return true;
		}

		public static bool IsValid(Transform target)
		{
			return IsValid(target.gameObject);
		}

		public bool Initialize(GameObject target)
		{
			if (target == null)
			{
				return false;
			}
			if (Exists())
			{
				meshFilter = null;
				skinnedMeshRenderer = null;
			}
			meshFilter = target.GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				skinnedMeshRenderer = target.GetComponent<SkinnedMeshRenderer>();
				if (skinnedMeshRenderer == null)
				{
					return false;
				}
				skinnedMeshRenderer.updateWhenOffscreen = true;
			}
			return true;
		}

		public bool Exists()
		{
			if (!(meshFilter != null))
			{
				return skinnedMeshRenderer != null;
			}
			return true;
		}

		public bool HasMesh()
		{
			return GetMesh() != null;
		}

		public Mesh GetMesh()
		{
			if (meshFilter != null)
			{
				return meshFilter.sharedMesh;
			}
			if (skinnedMeshRenderer != null)
			{
				return skinnedMeshRenderer.sharedMesh;
			}
			return null;
		}

		public void SetMesh(Mesh mesh)
		{
			if (!(mesh == null))
			{
				if (meshFilter != null)
				{
					meshFilter.sharedMesh = mesh;
				}
				else if (skinnedMeshRenderer != null)
				{
					skinnedMeshRenderer.sharedMesh = mesh;
				}
				else
				{
					Debug.LogError("Deformable doesn't have a target. Mesh cannot be set.");
				}
			}
		}

		public Renderer GetRenderer()
		{
			if (skinnedMeshRenderer != null)
			{
				return skinnedMeshRenderer;
			}
			if (meshFilter != null)
			{
				return meshFilter.GetComponent<MeshRenderer>();
			}
			return null;
		}

		public GameObject GetGameObject()
		{
			if (meshFilter != null)
			{
				return meshFilter.gameObject;
			}
			if (skinnedMeshRenderer != null)
			{
				return skinnedMeshRenderer.gameObject;
			}
			return null;
		}

		public Transform GetTransform()
		{
			if (meshFilter != null)
			{
				return meshFilter.transform;
			}
			if (skinnedMeshRenderer != null)
			{
				return skinnedMeshRenderer.transform;
			}
			return null;
		}
	}
}

using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro
{
	public static class GPUIColliderUtility
	{
		public static Collider CopyColliderValues(Collider source, Vector3 centerOffset, GameObject target)
		{
			if (source == null || target == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Source or Target is null.");
				return null;
			}
			Collider result = null;
			if (source is BoxCollider source2)
			{
				BoxCollider boxCollider = target.AddComponent<BoxCollider>();
				CopyBoxColliderValues(source2, boxCollider, centerOffset);
				result = boxCollider;
			}
			else if (source is SphereCollider source3)
			{
				SphereCollider sphereCollider = target.AddComponent<SphereCollider>();
				CopySphereColliderValues(source3, sphereCollider, centerOffset);
				result = sphereCollider;
			}
			else if (source is CapsuleCollider source4)
			{
				CapsuleCollider capsuleCollider = target.AddComponent<CapsuleCollider>();
				CopyCapsuleColliderValues(source4, capsuleCollider, centerOffset);
				result = capsuleCollider;
			}
			else if (source is MeshCollider source5)
			{
				MeshCollider meshCollider = target.AddComponent<MeshCollider>();
				CopyMeshColliderValues(source5, meshCollider, centerOffset);
				result = meshCollider;
			}
			return result;
		}

		public static void CopyBoxColliderValues(BoxCollider source, BoxCollider target, Vector3 offset)
		{
			target.center = source.center + offset;
			target.size = source.size;
			CopyColliderValues(source, target);
		}

		public static void CopySphereColliderValues(SphereCollider source, SphereCollider target, Vector3 offset)
		{
			target.center = source.center + offset;
			target.radius = source.radius;
			CopyColliderValues(source, target);
		}

		public static void CopyCapsuleColliderValues(CapsuleCollider source, CapsuleCollider target, Vector3 offset)
		{
			target.center = source.center + offset;
			target.radius = source.radius;
			target.height = source.height;
			target.direction = source.direction;
			CopyColliderValues(source, target);
		}

		public static void CopyMeshColliderValues(MeshCollider source, MeshCollider target, Vector3 offset)
		{
			target.sharedMesh = source.sharedMesh;
			target.convex = source.convex;
			CopyColliderValues(source, target);
		}

		private static void CopyColliderValues(Collider source, Collider target)
		{
			target.isTrigger = source.isTrigger;
			target.contactOffset = source.contactOffset;
			target.sharedMaterial = source.sharedMaterial;
			target.excludeLayers = source.excludeLayers;
		}

		public static void ReplaceOtherCollidersWithMeshColliders(GameObject parentGO, out List<Collider> disabledColliders, out List<MeshCollider> addedColliders, int layerMask)
		{
			disabledColliders = new List<Collider>(parentGO.GetComponentsInChildren<Collider>());
			for (int i = 0; i < disabledColliders.Count; i++)
			{
				Collider collider = disabledColliders[i];
				if (!(collider is MeshCollider) && collider.enabled && GPUIUtility.IsInLayer(layerMask, collider.gameObject.layer))
				{
					collider.enabled = false;
					continue;
				}
				disabledColliders.RemoveAt(i);
				i--;
			}
			addedColliders = new List<MeshCollider>();
			AddMeshCollidersForEachMeshFilter(parentGO.transform, ref addedColliders, layerMask);
		}

		private static void AddMeshCollidersForEachMeshFilter(Transform parentTransform, ref List<MeshCollider> addedColliders, int layerMask)
		{
			if (!parentTransform.HasComponent<MeshCollider>() && GPUIUtility.IsInLayer(layerMask, parentTransform.gameObject.layer) && parentTransform.TryGetComponent<MeshFilter>(out var component) && component.sharedMesh != null)
			{
				MeshCollider meshCollider = parentTransform.gameObject.AddComponent<MeshCollider>();
				meshCollider.sharedMesh = component.sharedMesh;
				addedColliders.Add(meshCollider);
			}
			for (int i = 0; i < parentTransform.childCount; i++)
			{
				AddMeshCollidersForEachMeshFilter(parentTransform.GetChild(i), ref addedColliders, layerMask);
			}
		}

		public static void RevertAddedMeshCollidersAndDisabledColliders(List<Collider> disabledColliders, List<MeshCollider> addedColliders)
		{
			foreach (MeshCollider addedCollider in addedColliders)
			{
				addedCollider.DestroyGeneric();
			}
			foreach (Collider disabledCollider in disabledColliders)
			{
				disabledCollider.enabled = true;
			}
		}

		public static void CopyRigidbodySettings(Rigidbody source, Rigidbody target)
		{
			target.linearDamping = source.linearDamping;
			target.angularDamping = source.angularDamping;
			target.interpolation = source.interpolation;
			target.collisionDetectionMode = source.collisionDetectionMode;
			target.useGravity = source.useGravity;
			target.isKinematic = source.isKinematic;
			target.constraints = source.constraints;
			target.maxAngularVelocity = source.maxAngularVelocity;
			target.sleepThreshold = source.sleepThreshold;
		}
	}
}

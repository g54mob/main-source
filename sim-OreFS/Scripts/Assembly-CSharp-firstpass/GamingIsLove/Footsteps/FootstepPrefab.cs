using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamingIsLove.Footsteps
{
	[Serializable]
	public class FootstepPrefab
	{
		[Tooltip("The prefab that will be used.")]
		public GameObject prefab;

		[Space(10f)]
		[Tooltip("The prefab will be placed at the position that was hit by the raycast, otherwise the position of the foot is used.")]
		public bool atHitPosition = true;

		[Tooltip("Offset added to the prefab's position.")]
		public Vector3 positionOffset = Vector3.zero;

		[Space(10f)]
		[Tooltip("Use the rotation of the foot, otherwise uses the rotation of the footstepper's game object.")]
		public bool useFootRotation;

		[Tooltip("Uses the normal of the position that was hit by the racast, aligning the prefab with the surface.")]
		public bool useHitNormal = true;

		[Tooltip("Offset added to the prefab's rotation.")]
		public Vector3 rotationOffset = Vector3.zero;

		[Space(10f)]
		[Tooltip("The time in seconds after which particle systems on the prefab are stopped.\nSet to 0 or below to not stop particles.")]
		public float stopAfter = 1f;

		[Tooltip("The time in seconds after which the prefab will be removed (disabled when using pooling, destroyed otherwise).\nCounted after stopping the prefab's particles - or instantiation if not stopping particles.")]
		public float removeAfter;

		public virtual IEnumerator CreatePrefab(Transform origin, Transform foot, Vector3 hitPosition, Vector3 hitNormal)
		{
			Queue<GameObject> pool = ((FootstepManager.Instance != null) ? FootstepManager.Instance.GetPool(prefab) : null);
			GameObject instance = ((pool != null && pool.Count > 0) ? pool.Dequeue() : null);
			Quaternion rotation = (useHitNormal ? (Quaternion.FromToRotation(Vector3.up, hitNormal) * Quaternion.Euler((useFootRotation ? foot.eulerAngles : origin.eulerAngles) + rotationOffset)) : Quaternion.Euler((useFootRotation ? foot.eulerAngles : origin.eulerAngles) + rotationOffset));
			if (instance == null)
			{
				instance = ((!(FootstepManager.Instance != null)) ? UnityEngine.Object.Instantiate(prefab, (atHitPosition ? hitPosition : foot.position) + positionOffset, rotation) : UnityEngine.Object.Instantiate(prefab, (atHitPosition ? hitPosition : foot.position) + positionOffset, rotation, FootstepManager.Instance.transform));
			}
			else
			{
				instance.transform.SetPositionAndRotation((atHitPosition ? hitPosition : foot.position) + positionOffset, rotation);
				instance.SetActive(value: true);
			}
			if (stopAfter > 0f)
			{
				yield return new WaitForSeconds(stopAfter);
				ParticleSystem[] componentsInChildren = instance.GetComponentsInChildren<ParticleSystem>();
				if (componentsInChildren != null)
				{
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						componentsInChildren[i].Stop(withChildren: true);
					}
				}
			}
			yield return new WaitForSeconds((removeAfter >= 0f) ? removeAfter : 0f);
			if (pool != null)
			{
				instance.SetActive(value: false);
				pool.Enqueue(instance);
			}
			else
			{
				UnityEngine.Object.Destroy(instance);
			}
		}
	}
}

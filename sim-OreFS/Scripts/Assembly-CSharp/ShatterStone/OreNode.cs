using System;
using System.Collections;
using UnityEngine;

namespace ShatterStone
{
	public class OreNode : MonoBehaviour
	{
		[Header("Drop Settings")]
		[SerializeField]
		protected GameObject pieces;

		[SerializeField]
		protected GameObject refinedPickup;

		[SerializeField]
		[Min(0f)]
		protected int dropOnHit;

		[SerializeField]
		[Min(1f)]
		protected int hitsToDestroy;

		[SerializeField]
		[Min(0f)]
		protected int dropOnDestroy;

		[Header("Knockback Settings")]
		[SerializeField]
		protected Vector3 knockAngle;

		[SerializeField]
		protected AnimationCurve knockCurve;

		[SerializeField]
		protected float knockDuration = 1f;

		[Header("Respawn Settings")]
		[SerializeField]
		protected bool enableRespawn = true;

		[SerializeField]
		protected float respawnDelay = 30f;

		[Header("Configuration")]
		[SerializeField]
		protected bool cacheVisualBoundaries = true;

		[SerializeField]
		protected MiningNodeAudio nodeAudio;

		[SerializeField]
		protected Collider nodeCollider;

		[SerializeField]
		protected Renderer[] childRenderers;

		private OreNodeBounds nodeBounds;

		private int hitIndex;

		private const float DelayDestroySeconds = 5f;

		protected virtual void Start()
		{
			if (nodeAudio == null)
			{
				nodeAudio = GetComponent<MiningNodeAudio>();
			}
			if (nodeCollider == null)
			{
				nodeCollider = GetComponent<Collider>();
			}
			if (childRenderers == null || childRenderers.Length == 0)
			{
				childRenderers = GetComponentsInChildren<Renderer>();
			}
		}

		public virtual void Interact()
		{
			Interact(1);
		}

		public virtual void Interact(int hits)
		{
			if (ShouldCalculateNodeBounds())
			{
				nodeBounds = CalculateNodeBounds();
			}
			InflictHit(GetDropCount(hits));
			if (hitIndex < hitsToDestroy)
			{
				StartCoroutine(Animate());
				nodeAudio?.PlayImpactSound();
			}
			else
			{
				ReplaceNodeVisualsWithBrokenOne();
			}
		}

		[Obsolete("Use Interact(hits) instead")]
		public void oreHit()
		{
			Interact(1);
		}

		protected virtual int GetDropCount(int hits)
		{
			int num = dropOnHit * hits;
			if (hitIndex + hits >= hitsToDestroy)
			{
				num += dropOnDestroy;
			}
			return num;
		}

		protected virtual bool ShouldCalculateNodeBounds()
		{
			if (cacheVisualBoundaries)
			{
				return hitIndex == 0;
			}
			return true;
		}

		protected virtual OreNodeBounds CalculateNodeBounds()
		{
			MeshRenderer component;
			Renderer renderer = (TryGetComponent<MeshRenderer>(out component) ? component : GetComponentInChildren<Renderer>());
			if (renderer == null)
			{
				return default(OreNodeBounds);
			}
			Bounds bounds = renderer.bounds;
			return new OreNodeBounds(bounds.min.x, bounds.max.x, bounds.min.z, bounds.max.z, bounds.center.y);
		}

		protected virtual void InflictHit(int dropCount)
		{
			hitIndex++;
			for (int i = 0; i < dropCount; i++)
			{
				Vector3 position = CalculateRandomDropPosition(nodeBounds);
				UnityEngine.Object.Instantiate(refinedPickup, position, Quaternion.Euler(0f, UnityEngine.Random.Range(0, 360), 0f));
			}
		}

		protected virtual Vector3 CalculateRandomDropPosition(OreNodeBounds bounds)
		{
			return new Vector3(UnityEngine.Random.Range(bounds.minX, bounds.maxX), bounds.centerY, UnityEngine.Random.Range(bounds.minZ, bounds.maxZ));
		}

		protected virtual void ReplaceNodeVisualsWithBrokenOne()
		{
			pieces.transform.localScale = base.transform.localScale;
			UnityEngine.Object.Instantiate(pieces, base.transform.position, base.transform.rotation);
			if ((bool)nodeCollider)
			{
				nodeCollider.enabled = false;
			}
			Renderer[] array = childRenderers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = false;
			}
			nodeAudio?.PlayShatterSound();
			if (enableRespawn)
			{
				ResetNode(respawnDelay);
			}
			else
			{
				StartCoroutine(DelayDestroy());
			}
		}

		protected virtual IEnumerator Animate()
		{
			if ((bool)nodeCollider)
			{
				nodeCollider.enabled = false;
			}
			Quaternion originalRotation = base.transform.localRotation;
			Quaternion knockRotation = Quaternion.Euler(knockAngle);
			float t = 0f;
			while (t < knockDuration)
			{
				float t2 = knockCurve.Evaluate(t / knockDuration);
				base.transform.localRotation = originalRotation * Quaternion.Slerp(Quaternion.identity, knockRotation, t2);
				t += Time.deltaTime;
				yield return null;
			}
			base.transform.localRotation = originalRotation;
			if ((bool)nodeCollider)
			{
				nodeCollider.enabled = true;
			}
		}

		public virtual void ResetNode(float respawnDelay)
		{
			StartCoroutine(ResetAsync(respawnDelay));
		}

		public virtual IEnumerator ResetAsync(float respawnDelay)
		{
			yield return new WaitForSeconds(respawnDelay);
			RevertToInitialState();
		}

		protected virtual void RevertToInitialState()
		{
			hitIndex = 0;
			if ((bool)nodeCollider)
			{
				nodeCollider.enabled = true;
			}
			Renderer[] array = childRenderers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = true;
			}
		}

		protected virtual IEnumerator DelayDestroy()
		{
			yield return new WaitForSeconds(5f);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}

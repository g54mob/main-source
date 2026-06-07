using System;
using System.Collections;
using UnityEngine;

namespace ShatterStone
{
	public class PickupController : MonoBehaviour
	{
		[Header("Animation Settings")]
		[SerializeField]
		private float jumpDuration = 1f;

		[SerializeField]
		private float jumpDistance = 3f;

		[SerializeField]
		private float jumpHeight = 2f;

		[SerializeField]
		private float spinRate = 20f;

		[SerializeField]
		private AnimationCurve jumpCurve;

		[Space]
		[Header("Despawn Settings")]
		[SerializeField]
		private bool enableDespawn = true;

		[SerializeField]
		private float timeToDespawn = 60f;

		[Space]
		[Header("Audio Settings")]
		[SerializeField]
		private float volume = 1f;

		[SerializeField]
		private Vector2 pitchRange = new Vector2(0.95f, 1.05f);

		[SerializeField]
		private AudioClip[] pickupClips;

		private bool jumpTrigger = true;

		private AudioSource audioSource;

		private void Awake()
		{
			audioSource = GetComponent<AudioSource>();
			audioSource.spatialBlend = 1f;
			audioSource.playOnAwake = false;
			if (enableDespawn)
			{
				StartCoroutine(DespawnTimer());
			}
		}

		private void Update()
		{
			if (jumpTrigger)
			{
				StartCoroutine(SpawnAnimate());
			}
			else
			{
				base.transform.Rotate(0f, spinRate * Time.deltaTime, 0f);
			}
		}

		private IEnumerator SpawnAnimate()
		{
			float t = 0f;
			Vector3 origin = base.transform.position;
			Vector3 jumpTo = base.transform.forward * jumpDistance + origin;
			jumpTrigger = false;
			while (t < jumpDuration)
			{
				Vector3 vector = Vector3.up * Mathf.Sin(t / jumpDuration * MathF.PI) * jumpHeight;
				float t2 = jumpCurve.Evaluate(t / jumpDuration);
				base.transform.position = Vector3.Lerp(origin, jumpTo, t2) + vector;
				t += Time.deltaTime;
				yield return null;
			}
			TrailRenderer componentInChildren = GetComponentInChildren<TrailRenderer>();
			if (componentInChildren != null)
			{
				componentInChildren.emitting = false;
				componentInChildren.Clear();
			}
		}

		public void CollectItem()
		{
			PlayRandomClip(pickupClips);
			StartCoroutine(CollectDestroy(base.transform));
		}

		public IEnumerator CollectDestroy(Transform target)
		{
			float duration = 0.2f;
			float elapsed = 0f;
			Vector3 startPos = target.position;
			Vector3 endPos = startPos + Vector3.up * 2f;
			Vector3 startScale = target.localScale;
			Vector3 endScale = Vector3.zero;
			ParticleSystem[] componentsInChildren = target.GetComponentsInChildren<ParticleSystem>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
			}
			while (elapsed < duration)
			{
				float t = elapsed / duration;
				target.position = Vector3.Lerp(startPos, endPos, t);
				target.localScale = Vector3.Lerp(startScale, endScale, t);
				elapsed += Time.deltaTime;
				yield return null;
			}
			target.position = endPos;
			target.localScale = endScale;
			yield return new WaitForSeconds(5f);
			UnityEngine.Object.Destroy(target.gameObject);
		}

		private void PlayRandomClip(AudioClip[] clipArray)
		{
			if (clipArray != null && clipArray.Length != 0)
			{
				AudioClip clip = clipArray[UnityEngine.Random.Range(0, clipArray.Length)];
				audioSource.pitch = UnityEngine.Random.Range(pitchRange.x, pitchRange.y);
				audioSource.PlayOneShot(clip, volume);
			}
		}

		public void DespawnItem()
		{
			StartCoroutine(DespawnTimer());
		}

		private IEnumerator DespawnTimer()
		{
			yield return new WaitForSeconds(timeToDespawn);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}

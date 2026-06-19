using System;
using UnityEngine;
using UnityEngine.Events;

namespace Items.Interactions
{
	public class ImpactHandler : MonoBehaviour
	{
		[Serializable]
		public class ImpactEvent
		{
			public float minVelocity = 2f;

			public float maxVelocity = float.PositiveInfinity;

			public LayerMask layerMask = -1;

			public AudioClip sound;

			[Range(0f, 1f)]
			public float volume = 1f;

			public float cooldown = 0.5f;

			public UnityEvent<float> onImpact;
		}

		[Header("Impact Events")]
		public ImpactEvent[] impactEvents;

		[Header("Fall Damage")]
		public bool enableFallDamage;

		public float minFallVelocity = 8f;

		public float damageMultiplier = 1f;

		public float fallDamageCooldownTime = 1f;

		public float minAirTime = 0.3f;

		public LayerMask fallDamageLayerMask = -1;

		public UnityEvent<float> onFallDamage;

		[SerializeField]
		private AudioSource audioSource;

		[SerializeField]
		private CharacterController _controller;

		private float[] _impactCooldowns;

		private float _fallDamageCooldown;

		private float _airTime;

		protected virtual void Awake()
		{
			if (audioSource == null)
			{
				audioSource = base.gameObject.AddComponent<AudioSource>();
			}
			_impactCooldowns = new float[impactEvents.Length];
		}

		protected virtual void Update()
		{
			if (!(_controller == null))
			{
				if (_controller.isGrounded)
				{
					_airTime = 0f;
				}
				else
				{
					_airTime += Time.deltaTime;
				}
			}
		}

		protected virtual void OnControllerColliderHit(ControllerColliderHit hit)
		{
			if (_controller == null)
			{
				return;
			}
			float magnitude = _controller.velocity.magnitude;
			int layer = hit.gameObject.layer;
			for (int i = 0; i < impactEvents.Length; i++)
			{
				TryFireEvent(impactEvents[i], magnitude, layer, ref _impactCooldowns[i]);
			}
			HandleCodeEvents(hit.rigidbody, magnitude, layer);
			if (enableFallDamage)
			{
				float num = 0f - _controller.velocity.y;
				if (num >= minFallVelocity && Time.time >= _fallDamageCooldown && _airTime >= minAirTime && (fallDamageLayerMask.value & (1 << layer)) != 0)
				{
					_fallDamageCooldown = Time.time + fallDamageCooldownTime;
					onFallDamage?.Invoke((num - minFallVelocity) * damageMultiplier);
				}
			}
		}

		protected virtual void OnCollisionEnter(Collision collision)
		{
			float magnitude = collision.relativeVelocity.magnitude;
			int layer = collision.gameObject.layer;
			for (int i = 0; i < impactEvents.Length; i++)
			{
				TryFireEvent(impactEvents[i], magnitude, layer, ref _impactCooldowns[i]);
			}
			HandleCodeEvents(collision.rigidbody, magnitude, layer);
			if (enableFallDamage)
			{
				float num = 0f - collision.relativeVelocity.y;
				if (num >= minFallVelocity && Time.time >= _fallDamageCooldown && _airTime >= minAirTime && (fallDamageLayerMask.value & (1 << layer)) != 0)
				{
					_fallDamageCooldown = Time.time + fallDamageCooldownTime;
					onFallDamage?.Invoke((num - minFallVelocity) * damageMultiplier);
				}
			}
		}

		protected virtual void HandleCodeEvents(Rigidbody rb, float speed, int layer)
		{
		}

		protected void TryFireEvent(ImpactEvent evt, float speed, int layer, ref float cooldownUntil)
		{
			if (!(Time.time < cooldownUntil) && !(speed < evt.minVelocity) && !(speed > evt.maxVelocity) && (evt.layerMask.value & (1 << layer)) != 0)
			{
				cooldownUntil = Time.time + evt.cooldown;
				if (evt.sound != null)
				{
					float t = Mathf.InverseLerp(evt.minVelocity, Mathf.Min(evt.maxVelocity, evt.minVelocity + 20f), speed);
					audioSource.PlayOneShot(evt.sound, evt.volume * Mathf.Lerp(0.3f, 1f, t));
				}
				evt.onImpact?.Invoke(speed);
			}
		}

		protected void PlaySound(AudioClip clip, float volume = 1f)
		{
			if (clip != null)
			{
				audioSource.PlayOneShot(clip, volume);
			}
		}
	}
}

using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Sound
{
	[RequireComponent(typeof(ParticleSystem))]
	public class ParticleAudioComponent : MonoBehaviour
	{
		[SerializeField]
		private string startEventId;

		[SerializeField]
		private string stopEventId;

		[SerializeField]
		private string collisionEventId;

		[SerializeField]
		private bool playCollisionOnceDuringLifetime = true;

		private ParticleSystem ps;

		private List<ParticleCollisionEvent> collisionEvents;

		private bool collisionPlayed;

		private void Start()
		{
			if (!string.IsNullOrEmpty(collisionEventId))
			{
				ps = GetComponent<ParticleSystem>();
				collisionEvents = new List<ParticleCollisionEvent>();
				ParticleSystem.CollisionModule collision = ps.collision;
				collision.enabled = true;
				collision.sendCollisionMessages = true;
			}
		}

		private void OnParticleCollision(GameObject other)
		{
			if (!string.IsNullOrEmpty(collisionEventId) && (!playCollisionOnceDuringLifetime || !collisionPlayed))
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(15, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\ParticleAudioComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(" Collided with ");
					messageBuilder.AppendFormatted(other.name);
				}
				Log.Trace(messageBuilder);
				collisionPlayed = true;
				MonoSingleton<AudioManager>.Instance.PlaySoundAtPosition(collisionEventId, base.transform.position);
			}
		}

		private void OnEnable()
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\ParticleAudioComponent.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(base.gameObject.name);
				messageBuilder.AppendLiteral(" Particle system enabled");
			}
			Log.Trace(messageBuilder);
			collisionPlayed = false;
			MonoSingleton<AudioManager>.Instance.PlaySoundAtPosition(startEventId, base.transform.position);
		}

		private void OnDisable()
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(26, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\ParticleAudioComponent.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(base.gameObject.name);
				messageBuilder.AppendLiteral(" Particle system disabled!");
			}
			Log.Trace(messageBuilder);
			if (MonoSingleton<AudioManager>.IsInstantiated())
			{
				MonoSingleton<AudioManager>.Instance.PlaySoundAtPosition(stopEventId, base.transform.position);
			}
		}
	}
}

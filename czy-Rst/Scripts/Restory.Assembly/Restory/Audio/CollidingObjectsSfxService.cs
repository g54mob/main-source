using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using Restory.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace Restory.Audio
{
	public class CollidingObjectsSfxService : MonoBehaviour
	{
		private struct CollisionSoundCoroutine
		{
			public Vector3 SoundSourcePosition;

			public Coroutine Coroutine;

			public EventReference CollisionSound;
		}

		[SerializeField]
		private float collisionSoundSourceDistanceThreshold = 0.3f;

		[SerializeField]
		private float soundBlockingTime = 0.2f;

		private IAudioPlayerService audioPlayer;

		private GlobalStateObserver globalStateObserver;

		private readonly List<CollisionSoundCoroutine> collisionSoundBlockingCoroutines = new List<CollisionSoundCoroutine>();

		[Inject]
		public void Construct(IAudioPlayerService audioPlayer, GlobalStateObserver globalStateObserver)
		{
			this.globalStateObserver = globalStateObserver;
			this.audioPlayer = audioPlayer;
		}

		private void OnDisable()
		{
			foreach (CollisionSoundCoroutine collisionSoundBlockingCoroutine in collisionSoundBlockingCoroutines)
			{
				StopCoroutine(collisionSoundBlockingCoroutine.Coroutine);
			}
			collisionSoundBlockingCoroutines.Clear();
		}

		public void TryToPlayCollisionSound(Vector3 contactPointPosition, EventReference collisionSound)
		{
			if (!globalStateObserver.IsInGameLoop)
			{
				return;
			}
			foreach (CollisionSoundCoroutine collisionSoundBlockingCoroutine in collisionSoundBlockingCoroutines)
			{
				if (collisionSoundBlockingCoroutine.CollisionSound.Guid == collisionSound.Guid && Vector3.Distance(collisionSoundBlockingCoroutine.SoundSourcePosition, contactPointPosition) < collisionSoundSourceDistanceThreshold)
				{
					return;
				}
			}
			audioPlayer.PlaySoundEventOneShot(collisionSound, contactPointPosition);
			collisionSoundBlockingCoroutines.Add(new CollisionSoundCoroutine
			{
				CollisionSound = collisionSound,
				Coroutine = StartCoroutine(CollisionSoundsBlockingCoroutine(collisionSound, contactPointPosition)),
				SoundSourcePosition = contactPointPosition
			});
		}

		private IEnumerator CollisionSoundsBlockingCoroutine(EventReference collisionSound, Vector3 contactPointPosition)
		{
			yield return new WaitForSeconds(soundBlockingTime);
			for (int num = collisionSoundBlockingCoroutines.Count - 1; num >= 0; num--)
			{
				CollisionSoundCoroutine collisionSoundCoroutine = collisionSoundBlockingCoroutines[num];
				if (collisionSoundCoroutine.CollisionSound.Guid == collisionSound.Guid && collisionSoundCoroutine.SoundSourcePosition == contactPointPosition)
				{
					collisionSoundBlockingCoroutines.RemoveAt(num);
					break;
				}
			}
		}
	}
}

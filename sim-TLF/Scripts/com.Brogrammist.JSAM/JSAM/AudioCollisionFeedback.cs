using UnityEngine;

namespace JSAM
{
	[AddComponentMenu("AudioManager/Audio Collision Feedback")]
	public class AudioCollisionFeedback : BaseAudioFeedback<SoundFileObject>
	{
		private enum CollisionEvent
		{
			OnCollisionEnter = 0,
			OnCollisionExit = 1,
			OnCollisionStay = 2
		}

		[Header("Collision Settings")]
		[SerializeField]
		[Tooltip("Will only play sound on collision with another object on these layers")]
		private LayerMask collidesWith = 0;

		[SerializeField]
		[Tooltip("The collision event that triggers the sound to play")]
		private CollisionEvent triggerEvent;

		private void TriggerSound(Collision collision)
		{
			if (collidesWith.Contains(collision.gameObject.layer))
			{
				AudioManager.PlaySound(audio, collision.GetContact(0).point);
			}
		}

		private void TriggerSound(Collision2D collision)
		{
			if (collidesWith.Contains(collision.gameObject.layer))
			{
				AudioManager.PlaySound(audio, collision.GetContact(0).point);
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (triggerEvent == CollisionEvent.OnCollisionEnter)
			{
				TriggerSound(collision);
			}
		}

		private void OnCollisionStay(Collision collision)
		{
			if (triggerEvent == CollisionEvent.OnCollisionStay)
			{
				TriggerSound(collision);
			}
		}

		private void OnCollisionExit(Collision collision)
		{
			if (triggerEvent == CollisionEvent.OnCollisionExit)
			{
				TriggerSound(collision);
			}
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (triggerEvent == CollisionEvent.OnCollisionEnter)
			{
				TriggerSound(collision);
			}
		}

		private void OnCollisionStay2D(Collision2D collision)
		{
			if (triggerEvent == CollisionEvent.OnCollisionStay)
			{
				TriggerSound(collision);
			}
		}

		private void OnCollisionExit2D(Collision2D collision)
		{
			if (triggerEvent == CollisionEvent.OnCollisionExit)
			{
				TriggerSound(collision);
			}
		}
	}
}

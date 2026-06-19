using UnityEngine;

namespace JSAM
{
	[AddComponentMenu("AudioManager/Audio Trigger Feedback")]
	public class AudioTriggerFeedback : BaseAudioFeedback<SoundFileObject>
	{
		private enum TriggerEvent
		{
			OnTriggerEnter = 0,
			OnTriggerStay = 1,
			OnTriggerExit = 2
		}

		[Header("Trigger Settings")]
		[SerializeField]
		[Tooltip("Will only play sound on trigger with another object on these layers")]
		private LayerMask triggersWith = 0;

		[SerializeField]
		[Tooltip("The intersection event that triggers the sound to play")]
		private TriggerEvent triggerEvent;

		private void TriggerSound(Collider other)
		{
			if (triggersWith.Contains(other.gameObject.layer))
			{
				AudioManager.PlaySound(audio, base.transform);
			}
		}

		private void TriggerSound(Collider2D collision)
		{
			if (triggersWith.Contains(collision.gameObject.layer))
			{
				AudioManager.PlaySound(audio, base.transform);
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (triggerEvent == TriggerEvent.OnTriggerEnter)
			{
				TriggerSound(other);
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (triggerEvent == TriggerEvent.OnTriggerStay)
			{
				TriggerSound(other);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (triggerEvent == TriggerEvent.OnTriggerExit)
			{
				TriggerSound(other);
			}
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (triggerEvent == TriggerEvent.OnTriggerEnter)
			{
				TriggerSound(collision);
			}
		}

		private void OnTriggerStay2D(Collider2D collision)
		{
			if (triggerEvent == TriggerEvent.OnTriggerStay)
			{
				TriggerSound(collision);
			}
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			if (triggerEvent == TriggerEvent.OnTriggerExit)
			{
				TriggerSound(collision);
			}
		}
	}
}

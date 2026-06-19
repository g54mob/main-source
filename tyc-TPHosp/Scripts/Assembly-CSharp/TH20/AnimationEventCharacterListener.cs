using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public class AnimationEventCharacterListener : MonoBehaviour
	{
		public Character Character { private get; set; }

		[UsedImplicitly]
		public void InvokeGenderAudioEvent(string audioEvent)
		{
			if (Character.Gender == Character.Sex.Male)
			{
				audioEvent = $"{audioEvent}:Male:{Character.EmoteID}";
			}
			else if (Character.Gender == Character.Sex.Female)
			{
				audioEvent = $"{audioEvent}:Female:{Character.EmoteID}";
			}
			if (AudioManager.Instance != null)
			{
				AudioManager.Instance.Play(audioEvent, base.gameObject);
			}
		}
	}
}

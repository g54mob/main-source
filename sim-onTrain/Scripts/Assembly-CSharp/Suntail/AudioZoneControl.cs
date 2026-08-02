using UnityEngine;
using UnityEngine.Audio;

namespace Suntail
{
	public class AudioZoneControl : MonoBehaviour
	{
		[Tooltip("Snapshot for outdoor enviroment")]
		[SerializeField]
		private AudioMixerSnapshot outdoorSnapshot;

		[Tooltip("Snapshot for indoor enviroment")]
		[SerializeField]
		private AudioMixerSnapshot indoorSnapshot;

		[Tooltip("Transition time between snapshots")]
		[SerializeField]
		private float crossfadeTime = 0.5f;

		[Tooltip("Trigger tag for updating audio zones")]
		[SerializeField]
		private string triggerTag = "Player";

		private int zoneCount;

		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == triggerTag)
			{
				zoneCount++;
				UpdateAudioZoneSnapshot();
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.tag == triggerTag)
			{
				zoneCount--;
				UpdateAudioZoneSnapshot();
			}
		}

		private void UpdateAudioZoneSnapshot()
		{
			if (zoneCount > 0)
			{
				indoorSnapshot.TransitionTo(crossfadeTime);
			}
			else
			{
				outdoorSnapshot.TransitionTo(crossfadeTime);
			}
		}
	}
}

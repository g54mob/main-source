using UnityEngine;

namespace ScheduleOne.Audio
{
	[CreateAssetMenu(fileName = "AudioSettings", menuName = "ScriptableObjects/Audio/Audio Settings")]
	public class AudioSettings : ScriptableObject
	{
		[SerializeField]
		[Header("Settings")]
		private string _id;

		[SerializeField]
		private AudioSettingsWrapper _settings;

		public string Id => null;

		public AudioSettingsWrapper Wrapper => null;
	}
}

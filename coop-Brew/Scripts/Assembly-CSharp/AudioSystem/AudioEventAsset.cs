using UnityEngine;

namespace AudioSystem
{
	[CreateAssetMenu(fileName = "AudioEventAsset", menuName = "Audio/Audio Event Asset", order = 1)]
	public class AudioEventAsset : ScriptableObject
	{
		[Header("Event Reference")]
		[Tooltip("The unique ID of the audio event in the database.")]
		[SerializeField]
		private string eventId;

		[Header("Optional: Direct Reference")]
		[Tooltip("Optional reference to the database for validation. Not required at runtime.")]
		[SerializeField]
		private AudioDatabase database;

		public string EventId => null;

		public bool IsValid => false;

		public AudioEvent GetEvent()
		{
			return null;
		}

		public AudioSource Play(Vector3 position, Transform parent = null)
		{
			return null;
		}

		public void PlayNetworked(Vector3 position)
		{
		}
	}
}

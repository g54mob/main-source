using System.Collections.Generic;
using UnityEngine;

namespace AudioSystem
{
	[CreateAssetMenu(fileName = "AudioDatabase", menuName = "Audio/Audio Database", order = 0)]
	public class AudioDatabase : ScriptableObject
	{
		[Header("Audio Events")]
		[Tooltip("All audio events in the database.")]
		[SerializeField]
		private List<AudioEvent> events;

		private Dictionary<string, AudioEvent> _eventLookup;

		private bool _isInitialized;

		public IReadOnlyList<AudioEvent> Events => null;

		public int Count => 0;

		public void InitializeLookup()
		{
		}

		private void EnsureInitialized()
		{
		}

		public AudioEvent GetEventById(string id)
		{
			return null;
		}

		public bool HasEvent(string id)
		{
			return false;
		}

		public List<AudioEvent> GetEventsByCategory(AudioCategory category)
		{
			return null;
		}

		public List<AudioEvent> GetEventsByTag(string tag)
		{
			return null;
		}

		public List<string> GetAllEventIds()
		{
			return null;
		}

		public List<string> Validate()
		{
			return null;
		}

		public void LogValidationIssues()
		{
		}

		private void OnEnable()
		{
		}
	}
}

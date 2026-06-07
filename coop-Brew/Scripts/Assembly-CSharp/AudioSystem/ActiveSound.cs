using UnityEngine;

namespace AudioSystem
{
	public struct ActiveSound
	{
		public AudioSource Source;

		public string EventId;

		public AudioCategory Category;

		public float StartTime;
	}
}

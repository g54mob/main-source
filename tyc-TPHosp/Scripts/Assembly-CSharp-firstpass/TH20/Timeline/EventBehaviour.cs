using UnityEngine;

namespace TH20.Timeline
{
	public abstract class EventBehaviour : MonoBehaviour
	{
		public virtual void OnClipStart(string eventName, string tag)
		{
		}

		public virtual void OnClipPlaying(string eventName, string tag, double time)
		{
		}
	}
}

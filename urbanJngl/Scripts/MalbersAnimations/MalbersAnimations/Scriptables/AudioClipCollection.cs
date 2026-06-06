using MalbersAnimations.Events;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Collections/Audio Clip Collection", fileName = "New Audio Collection", order = 1000)]
	public class AudioClipCollection : RuntimeCollection<AudioClip>
	{
		public AudioEvent OnItemAdded = new AudioEvent();

		public AudioEvent OnItemRemoved = new AudioEvent();

		protected override void OnAddEvent(AudioClip newItem)
		{
			OnItemAdded.Invoke(newItem);
		}

		protected override void OnRemoveEvent(AudioClip newItem)
		{
			OnItemRemoved.Invoke(newItem);
		}
	}
}

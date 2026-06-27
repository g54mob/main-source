using FMOD.Studio;
using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Views.ToDoList
{
	public sealed class GUI_ToDoListViewSFX : MonoBehaviour
	{
		[SerializeField]
		private GUI_ToDoListView toDoListView;

		[SerializeField]
		private EventReference showSound;

		[SerializeField]
		private EventReference hideSound;

		private IAudioPlayerService audioPlayer;

		private EventInstance soundInstance;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			toDoListView.OnShowAnimationStarted += ResolveShowAnimationStarted;
			toDoListView.OnHideAnimationStarted += ResolveHideAnimationStarted;
		}

		private void OnDisable()
		{
			if (toDoListView.MonoShellExists())
			{
				toDoListView.OnShowAnimationStarted -= ResolveShowAnimationStarted;
				toDoListView.OnHideAnimationStarted -= ResolveHideAnimationStarted;
			}
		}

		private void ResolveShowAnimationStarted()
		{
			audioPlayer.StopSoundEventInstance(soundInstance, allowFadeOut: false);
			audioPlayer.TryToStartSoundEvent(showSound, out soundInstance);
		}

		private void ResolveHideAnimationStarted()
		{
			audioPlayer.StopSoundEventInstance(soundInstance, allowFadeOut: false);
			audioPlayer.TryToStartSoundEvent(hideSound, out soundInstance);
		}
	}
}

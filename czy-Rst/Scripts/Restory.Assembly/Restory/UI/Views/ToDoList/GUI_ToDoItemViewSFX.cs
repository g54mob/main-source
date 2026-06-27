using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Views.ToDoList
{
	public sealed class GUI_ToDoItemViewSFX : MonoBehaviour
	{
		[SerializeField]
		private GUI_ToDoItemView toDoItemView;

		[SerializeField]
		private EventReference penCrossSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			toDoItemView.OnCompletionAnimationStarted += ResolveCompletionAnimationStarted;
		}

		private void OnDisable()
		{
			if (toDoItemView.MonoShellExists())
			{
				toDoItemView.OnCompletionAnimationStarted -= ResolveCompletionAnimationStarted;
			}
		}

		private void ResolveCompletionAnimationStarted()
		{
			audioPlayer.PlaySoundEventOneShot(penCrossSound);
		}
	}
}

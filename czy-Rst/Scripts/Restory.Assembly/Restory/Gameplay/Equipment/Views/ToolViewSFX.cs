using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Views
{
	public sealed class ToolViewSFX : MonoBehaviour
	{
		[SerializeField]
		private ToolView toolView;

		[SerializeField]
		private EventReference placementSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			toolView.OnToolPlaced += ResolveToolPlaced;
		}

		private void OnDisable()
		{
			if (toolView.MonoShellExists())
			{
				toolView.OnToolPlaced -= ResolveToolPlaced;
			}
		}

		private void ResolveToolPlaced()
		{
			audioPlayer.PlaySoundEventOneShot(placementSound, base.gameObject);
		}
	}
}

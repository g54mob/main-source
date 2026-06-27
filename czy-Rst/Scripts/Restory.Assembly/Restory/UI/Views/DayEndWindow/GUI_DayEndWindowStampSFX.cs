using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Views.DayEndWindow
{
	public class GUI_DayEndWindowStampSFX : MonoBehaviour
	{
		[SerializeField]
		private GUI_DayEndWindowStamp stamp;

		[SerializeField]
		private EventReference stampHighlightedSound;

		[SerializeField]
		private EventReference stampPickedUpSound;

		[SerializeField]
		private EventReference stampAppliedSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			stamp.OnStampHighlighted += ResolveOnStampHighlighted;
			stamp.OnStampPickedUp += ResolveStampPickedUp;
			stamp.OnStampingDone += ResolveStampingDone;
		}

		private void OnDisable()
		{
			if (stamp.MonoShellExists())
			{
				stamp.OnStampHighlighted -= ResolveOnStampHighlighted;
				stamp.OnStampPickedUp -= ResolveStampPickedUp;
				stamp.OnStampingDone -= ResolveStampingDone;
			}
		}

		private void ResolveOnStampHighlighted()
		{
			audioPlayer.PlaySoundEventOneShot(stampHighlightedSound);
		}

		private void ResolveStampPickedUp()
		{
			audioPlayer.PlaySoundEventOneShot(stampPickedUpSound);
		}

		private void ResolveStampingDone()
		{
			audioPlayer.PlaySoundEventOneShot(stampAppliedSound);
		}
	}
}

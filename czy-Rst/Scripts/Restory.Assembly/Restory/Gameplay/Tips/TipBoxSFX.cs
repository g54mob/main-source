using FMODUnity;
using Restory.Audio;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tips
{
	public class TipBoxSFX : MonoBehaviour
	{
		[SerializeField]
		private TipBox tipBox;

		[SerializeField]
		private EventReference moneyAddedSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			tipBox.OnTipsAdded += ResolveTipsAdded;
			tipBox.OnTipsReturned += ResolveTipsAdded;
		}

		private void OnDisable()
		{
			tipBox.OnTipsAdded -= ResolveTipsAdded;
			tipBox.OnTipsReturned -= ResolveTipsAdded;
		}

		private void ResolveTipsAdded(int _)
		{
			audioPlayer.PlaySoundEventOneShot(moneyAddedSound, base.transform.position);
		}
	}
}

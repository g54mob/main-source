using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace UI
{
	public class ChoiceMenuWaveButton : ChoiceMenuButtonBase
	{
		public Image waveImage;

		public override void InitComponent(ChoiceMenuButtonInitBase init)
		{
		}

		private void WaveSpriteLoaded(AsyncOperationHandle<Sprite> obj)
		{
		}
	}
}

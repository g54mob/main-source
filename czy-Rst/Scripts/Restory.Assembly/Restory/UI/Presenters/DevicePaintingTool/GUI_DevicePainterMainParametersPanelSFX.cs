using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public sealed class GUI_DevicePainterMainParametersPanelSFX : MonoBehaviour
	{
		[SerializeField]
		private GUI_DevicePainterMainParametersPanel painterMainParametersPanel;

		[SerializeField]
		private EventReference sliderMoveSound;

		[SerializeField]
		private EventReference paletteSelectionMenuOpenSound;

		[SerializeField]
		private EventReference paletteSelectedSound;

		[SerializeField]
		private EventReference brushTypeSwitchSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			painterMainParametersPanel.OnBrushOpacityChanged += ResolveSliderChangedValue;
			painterMainParametersPanel.OnBrushSizeChanged += ResolveSliderChangedValue;
			painterMainParametersPanel.OnPaletteSelectionChanged += ResolvePaletteSelectionChanged;
			painterMainParametersPanel.OnPaletteSelectionMenuOpened += ResolvePaletteSelectionMenuOpened;
			painterMainParametersPanel.OnBrushTypeChanged += ResolveBrushTypeChanged;
		}

		private void OnDisable()
		{
			if (painterMainParametersPanel.MonoShellExists())
			{
				painterMainParametersPanel.OnBrushOpacityChanged -= ResolveSliderChangedValue;
				painterMainParametersPanel.OnBrushSizeChanged -= ResolveSliderChangedValue;
				painterMainParametersPanel.OnPaletteSelectionChanged -= ResolvePaletteSelectionChanged;
				painterMainParametersPanel.OnPaletteSelectionMenuOpened -= ResolvePaletteSelectionMenuOpened;
				painterMainParametersPanel.OnBrushTypeChanged -= ResolveBrushTypeChanged;
			}
		}

		private void ResolveSliderChangedValue()
		{
			audioPlayer.PlaySoundEventOneShot(sliderMoveSound);
		}

		private void ResolvePaletteSelectionChanged()
		{
			audioPlayer.PlaySoundEventOneShot(paletteSelectedSound);
		}

		private void ResolvePaletteSelectionMenuOpened()
		{
			audioPlayer.PlaySoundEventOneShot(paletteSelectionMenuOpenSound);
		}

		private void ResolveBrushTypeChanged()
		{
			audioPlayer.PlaySoundEventOneShot(brushTypeSwitchSound);
		}
	}
}

using System.Collections;
using CTS.BBT;
using CTS.Core;
using CTS.UI;

namespace CTS
{
	public class CutsceneAudio : CTSBehaviour
	{
		private static readonly StringKey _cutsceneCanvas = "UI_Cutscenes";

		private CanvasGroupController _canvas;

		protected override void OnAwake()
		{
			base.OnAwake();
			_canvas = BBTUI.GetCanvas(_cutsceneCanvas);
			_canvas.CanvasShowned += OnCanvasShowed;
			_canvas.CanvasShowning += OnCanvasShowing;
			NewsCutscene.PageShown += OnPageShown;
		}

		private void OnDestroy()
		{
			_canvas.CanvasShowned -= OnCanvasShowed;
			_canvas.CanvasShowning -= OnCanvasShowing;
			NewsCutscene.PageShown -= OnPageShown;
		}

		private void OnCanvasShowed(bool isOpened)
		{
			if (!isOpened)
			{
				OnClosed();
			}
		}

		private void OnCanvasShowing(bool isOpening)
		{
			if (isOpening)
			{
				OnOpened();
			}
		}

		private void OnOpened()
		{
			MonoSingleton<MusicManager>.Instance.PlayMenuMusic();
		}

		private void OnClosed()
		{
			MonoSingleton<MusicManager>.Instance.PlayBarMusic();
		}

		private void OnPageShown(CutscenePageData obj)
		{
			if ((bool)obj.MainCharacter)
			{
				if ((bool)obj.MainCharacter.DialogueNeutral)
				{
					StartCoroutine(PlaySound(obj.MainCharacter.DialogueNeutral));
				}
				else if ((bool)obj.MainCharacter.DialogueHonored)
				{
					StartCoroutine(PlaySound(obj.MainCharacter.DialogueHonored));
				}
				else if ((bool)obj.MainCharacter.DialogueAngry)
				{
					StartCoroutine(PlaySound(obj.MainCharacter.DialogueAngry));
				}
			}
		}

		private IEnumerator PlaySound(AudioAsset audio)
		{
			yield return Coroutines.WaitForSecondsRealtime(0.5f);
			MonoSingleton<SoundManager>.Instance.PlayAudioAsset(audio);
		}
	}
}

using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Presenters.PC.Apps.Hacking.Lines
{
	public class GUI_TypingCaret : MonoBehaviour
	{
		[SerializeField]
		private Graphic caretGraphic;

		[SerializeField]
		private Color brightCaretColor;

		[SerializeField]
		private Color dimCaretColor;

		[SerializeField]
		[Min(0.02f)]
		private float brightenDuration = 0.07f;

		[SerializeField]
		[Min(0.02f)]
		private float dimDuration = 0.42f;

		[SerializeField]
		private Ease brightenEase = Ease.OutCubic;

		[SerializeField]
		private Ease dimEase = Ease.InOutSine;

		private TweenSequencesService tweenSequences;

		private Sequence pulseSequence;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		private void OnEnable()
		{
			PlayPulse();
		}

		private void OnDisable()
		{
			if (pulseSequence != null)
			{
				tweenSequences.Kill(pulseSequence);
				pulseSequence = null;
			}
		}

		private void PlayPulse()
		{
			if (pulseSequence != null)
			{
				tweenSequences.Kill(pulseSequence);
				pulseSequence = null;
			}
			caretGraphic.color = dimCaretColor;
			pulseSequence = tweenSequences.Create();
			pulseSequence.Append(caretGraphic.DOColor(brightCaretColor, brightenDuration).SetEase(brightenEase)).Append(caretGraphic.DOColor(dimCaretColor, dimDuration).SetEase(dimEase)).SetLoops(-1, LoopType.Restart);
		}
	}
}

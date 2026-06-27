using System;
using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UI.Presenters.CleaningToolsSelectionWindow
{
	public class GUI_CleaningToolCountAndCurrentUsesLeftErrorAnimator : MonoBehaviour
	{
		[SerializeField]
		private Graphic[] graphicsToAnimate = Array.Empty<Graphic>();

		[SerializeField]
		private Color errorColor = Color.red;

		[SerializeField]
		[Min(0.01f)]
		private float errorDuration = 1f;

		[SerializeField]
		[Min(0f)]
		private int errorLoops = 2;

		private TweenSequencesService tweenSequences;

		private Sequence currentSequence;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		private void OnDisable()
		{
			if (currentSequence != null)
			{
				tweenSequences.Kill(currentSequence);
				Graphic[] array = graphicsToAnimate;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].color = Color.white;
				}
				currentSequence = null;
			}
		}

		public void PlayError()
		{
			if (!currentSequence.IsActive() || !currentSequence.IsPlaying())
			{
				if (currentSequence != null)
				{
					tweenSequences.Kill(currentSequence);
				}
				currentSequence = tweenSequences.Create();
				Graphic[] array = graphicsToAnimate;
				foreach (Graphic target in array)
				{
					currentSequence.Join(target.DOColor(errorColor, errorDuration).SetLoops(errorLoops, LoopType.Yoyo));
				}
			}
		}
	}
}

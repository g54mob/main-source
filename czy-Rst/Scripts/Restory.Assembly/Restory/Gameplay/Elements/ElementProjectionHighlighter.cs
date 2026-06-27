using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class ElementProjectionHighlighter : ProjectionHighlighterBase
	{
		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			base.tweenSequences = tweenSequences;
		}

		public void HighlightProjection(ElementProjection elementProjection)
		{
			if (!isSequenceJustCompleted)
			{
				highlightedProjections.Add(elementProjection);
				elementProjection.OutlinableAdapter.OverridePreset = outlinePresetInstance;
				if (transitionSequence == null)
				{
					transitionSequence = tweenSequences.Create();
					PlaySequence(transitionSequence);
				}
			}
		}

		protected override void CompleteTransitionSequence()
		{
			isSequenceJustCompleted = true;
			foreach (ElementProjection highlightedProjection in highlightedProjections)
			{
				if ((bool)highlightedProjection)
				{
					highlightedProjection.MakeDim();
					highlightedProjection.transform.localScale = Vector3.one;
				}
			}
			highlightedProjections.Clear();
			if (transitionSequence != null)
			{
				transitionSequence.Kill();
				transitionSequence = null;
			}
			isSequenceJustCompleted = false;
		}
	}
}

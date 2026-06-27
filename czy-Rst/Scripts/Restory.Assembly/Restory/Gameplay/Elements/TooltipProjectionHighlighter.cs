using System;
using DG.Tweening;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class TooltipProjectionHighlighter : ProjectionHighlighterBase, IInitializable, IDisposable
	{
		private ElementProjectionFactory elementProjectionFactory;

		private DisassembleStateMachine disassembleStateMachine;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences, ElementProjectionFactory elementProjectionFactory, DisassembleStateMachine disassembleStateMachine)
		{
			base.tweenSequences = tweenSequences;
			this.elementProjectionFactory = elementProjectionFactory;
			this.disassembleStateMachine = disassembleStateMachine;
		}

		public void Initialize()
		{
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
		}

		public void Dispose()
		{
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
		}

		public void CreateAndHighlightProjection(ElementProjectionData projectionData, Transform parent)
		{
			if (!isSequenceJustCompleted)
			{
				ElementProjection elementProjection = elementProjectionFactory.CreateSmallElementProjection(detectable: false, projectionData, parent);
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
					elementProjectionFactory.DestroySmallElementProjection(highlightedProjection);
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

		private void ResolveDisassembleStateChanged()
		{
			if (disassembleStateMachine.ActiveState is DisabledDisassembleState && transitionSequence != null)
			{
				CompleteTransitionSequence();
			}
		}
	}
}

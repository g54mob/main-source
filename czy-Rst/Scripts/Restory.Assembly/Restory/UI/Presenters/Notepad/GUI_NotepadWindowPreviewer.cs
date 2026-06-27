using System;
using DG.Tweening;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Restory.UserInterface.CommonElements;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Notepad
{
	public class GUI_NotepadWindowPreviewer : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		[Range(1f, 5f)]
		private float notepadPreviewDuration = 2.5f;

		[SerializeField]
		private GUI_NotepadWindow notepadWindow;

		private DisassembleStateMachine disassembleStateMachine;

		private TweenSequencesService tweenSequences;

		private Sequence delayAndHideSequence;

		private bool isActivated;

		private bool wasInEmptyDisassembleStateRecently;

		[Inject]
		private void Construct(DisassembleStateMachine disassembleStateMachine, TweenSequencesService tweenSequences)
		{
			this.disassembleStateMachine = disassembleStateMachine;
			this.tweenSequences = tweenSequences;
		}

		public void Initialize()
		{
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
			notepadWindow.OnSlidingStateChanged += ResolveSlidingStateChanged;
		}

		public void Dispose()
		{
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
			notepadWindow.OnSlidingStateChanged -= ResolveSlidingStateChanged;
			ClearSequence();
		}

		public void PreviewNotepad()
		{
			if (!isActivated && IsAllowedDisassembleState())
			{
				notepadWindow.RollOut();
				isActivated = true;
			}
		}

		private void ResolveDisassembleStateChanged()
		{
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (!(activeState is DisabledDisassembleState))
			{
				if (!(activeState is EmptyDisassembleState))
				{
					if (activeState is DetectionDisassembleState && wasInEmptyDisassembleStateRecently)
					{
						wasInEmptyDisassembleStateRecently = false;
						PreviewNotepad();
					}
				}
				else
				{
					wasInEmptyDisassembleStateRecently = true;
				}
			}
			else
			{
				wasInEmptyDisassembleStateRecently = false;
			}
		}

		private void ResolveSlidingStateChanged(SlidingPanelState state)
		{
			if (isActivated)
			{
				if (state == SlidingPanelState.Open)
				{
					PlayDelayAndHideSequence(notepadPreviewDuration);
					return;
				}
				ClearSequence();
				isActivated = false;
			}
		}

		private void PlayDelayAndHideSequence(float duration)
		{
			ClearSequence();
			delayAndHideSequence = tweenSequences.Create();
			delayAndHideSequence.AppendInterval(duration).OnComplete(Complete);
		}

		private void Complete()
		{
			ClearSequence();
			isActivated = false;
			if (IsAllowedDisassembleState())
			{
				notepadWindow.RollIn();
			}
		}

		private bool IsAllowedDisassembleState()
		{
			IExitableState activeState = disassembleStateMachine.ActiveState;
			return activeState is DetectionDisassembleState || activeState is EmptyDisassembleState;
		}

		private void ClearSequence()
		{
			if (delayAndHideSequence != null)
			{
				tweenSequences.Kill(delayAndHideSequence);
				delayAndHideSequence = null;
			}
		}
	}
}

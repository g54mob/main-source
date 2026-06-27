using System;
using DG.Tweening;
using Restory.Gameplay.TimeSystems;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States;
using Restory.UI.Presenters.DayStartScreen;
using Restory.Utils;
using Zenject;

namespace Restory.Gameplay.DayStartScreen
{
	public class DayScreenWorkService : IInitializable, IDisposable
	{
		private readonly float transitionDuration = 5f;

		private readonly GlobalStateMachine globalStateMachine;

		private readonly GameCalendar gameCalendar;

		private readonly GUI_DayStartScreen dayStartScreen;

		private readonly TweenSequencesService tweenSequences;

		private Sequence transitionSequence;

		public float DayScreenCurrentVisibility => dayStartScreen.ViewCanvasGroupAlphaValue;

		public bool IsDayScreenActive
		{
			get
			{
				if (!transitionSequence.IsActive())
				{
					return dayStartScreen.ViewCanvasGroupAlphaValue > 0f;
				}
				return true;
			}
		}

		public event Action OnTransitionEndedAndScreenFullyHidden;

		public event Action OnTransitionStarted;

		[Inject]
		public DayScreenWorkService(float transitionDuration, GlobalStateMachine globalStateMachine, GameCalendar gameCalendar, GUI_DayStartScreen dayStartScreen, TweenSequencesService tweenSequences)
		{
			this.transitionDuration = transitionDuration;
			this.globalStateMachine = globalStateMachine;
			this.gameCalendar = gameCalendar;
			this.dayStartScreen = dayStartScreen;
			this.tweenSequences = tweenSequences;
		}

		public void Initialize()
		{
			globalStateMachine.OnActiveStateChanged += ResolveGlobalStateChanged;
		}

		public void Dispose()
		{
			globalStateMachine.OnActiveStateChanged -= ResolveGlobalStateChanged;
		}

		private void OnTransitionStart()
		{
			dayStartScreen.Show(gameCalendar.CurrentDayNumber, gameCalendar.CurrentDayOfWeek, instantly: true);
			this.OnTransitionStarted?.Invoke();
		}

		private void OnTransitionComplete()
		{
			transitionSequence = null;
			dayStartScreen.Hide(instantly: false, this.OnTransitionEndedAndScreenFullyHidden);
			globalStateMachine.Enter<GameLoopState>();
		}

		private void ResolveGlobalStateChanged()
		{
			if (globalStateMachine.ActiveState is GameLauncherState)
			{
				if (transitionSequence != null)
				{
					tweenSequences.Kill(transitionSequence);
				}
				transitionSequence = tweenSequences.Create();
				transitionSequence.AppendCallback(OnTransitionStart);
				transitionSequence.AppendInterval(transitionDuration);
				transitionSequence.AppendCallback(OnTransitionComplete);
			}
		}
	}
}

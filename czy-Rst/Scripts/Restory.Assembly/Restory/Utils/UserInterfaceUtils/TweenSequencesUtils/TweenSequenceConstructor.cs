using System;
using DG.Tweening;
using Mandragora.Utils;
using Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements;
using Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.FinalStates;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils
{
	public class TweenSequenceConstructor : SerializedMonoBehaviour
	{
		private static class Style
		{
			public const string FinalStates = "Finalization Options/Final States";

			public const string Loops = "Loops";

			public const string FinalizationOptions = "Finalization Options";
		}

		public UnityEvent OnSequenceStarted = new UnityEvent();

		public UnityEvent OnSequenceCompleted = new UnityEvent();

		public UnityEvent OnSequenceKilled = new UnityEvent();

		[SerializeField]
		private RealTimeMeasuringUnit timeMeasuringUnit;

		[OdinSerialize]
		private TweenSequenceElement[] sequenceElements = Array.Empty<TweenSequenceElement>();

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool setSequenceLoops;

		[SerializeField]
		private int loops;

		[SerializeField]
		private LoopType loopType;

		[SerializeField]
		private UpdateType updateType;

		[SerializeField]
		private bool isIndependentUpdate;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool autoRewindOnCompletion;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool autoRewindOnDisable;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool allowRewindingSequenceExternally;

		[SerializeField]
		private TweenSequenceTransformFinalState[] transformFinalStates = Array.Empty<TweenSequenceTransformFinalState>();

		[SerializeField]
		private TweenSequenceImageFinalState[] imageFinalStates = Array.Empty<TweenSequenceImageFinalState>();

		[SerializeField]
		private CanvasGroupFinalState[] canvasGroupFinalStates = Array.Empty<CanvasGroupFinalState>();

		[SerializeField]
		private TextFinalState[] textFinalStates = Array.Empty<TextFinalState>();

		[SerializeField]
		private GradientColorFinalState[] gradientColorFinalStates = Array.Empty<GradientColorFinalState>();

		private TweenSequencesService tweenSequencesService;

		private Sequence sequence;

		private bool isInPreviewMode;

		public bool IsSequenceActive => sequence.IsActive();

		[BoolButton(25, 0, Red = false)]
		private bool IsInPreviewMode
		{
			get
			{
				return isInPreviewMode;
			}
			set
			{
				isInPreviewMode = value;
				if (sequence.IsActive())
				{
					sequence.Rewind();
				}
				KillSequence();
			}
		}

		[Inject]
		public void Construct(TweenSequencesService tweenSequencesService)
		{
			this.tweenSequencesService = tweenSequencesService;
		}

		private void OnDisable()
		{
			if (IsSequenceActive && autoRewindOnDisable)
			{
				RewindSequenceToInitialState();
			}
			KillSequence();
		}

		public void StartSequence()
		{
			if (sequence.IsActive())
			{
				return;
			}
			sequence = tweenSequencesService.Create();
			if (isInPreviewMode || allowRewindingSequenceExternally)
			{
				sequence.SetAutoKill(autoKillOnCompletion: false);
			}
			TweenSequenceElement[] array = sequenceElements;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetTimeMeasuringUnit(timeMeasuringUnit);
			}
			sequence.OnStart(delegate
			{
				OnSequenceStarted?.Invoke();
			}).OnComplete(delegate
			{
				OnSequenceCompleted?.Invoke();
				if (autoRewindOnCompletion)
				{
					sequence.Rewind();
					sequence.Kill();
				}
				else if (!allowRewindingSequenceExternally)
				{
					sequence.Kill();
				}
			}).OnKill(delegate
			{
				if (!autoRewindOnCompletion && !allowRewindingSequenceExternally)
				{
					ApplyFinalStatesSettings();
				}
				OnSequenceKilled?.Invoke();
			});
			array = sequenceElements;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].AddToSequence(sequence);
			}
			if (setSequenceLoops)
			{
				sequence.SetLoops(loops, loopType);
			}
			sequence.SetUpdate(updateType, isIndependentUpdate);
		}

		public void RestartActiveSequence()
		{
			if (sequence.IsActive())
			{
				sequence.Restart();
			}
		}

		public void PauseActiveSequence()
		{
			if (sequence.IsActive() && sequence.IsPlaying())
			{
				sequence.Pause();
			}
		}

		public void ResumePausedSequence()
		{
			if (sequence.IsActive() && !sequence.IsPlaying())
			{
				sequence.Play();
			}
		}

		public void RewindSequenceToInitialState()
		{
			if (sequence.IsActive())
			{
				sequence.Rewind();
				sequence.Kill();
			}
			else
			{
				Debug.LogWarning("[TweenSequenceConstructor] tried to rewind sequence, but the sequence is null. It was either not yet started, or already killed. Check if 'Allow Rewinding Sequence Externally' option in the component is on, otherwise a sequence can't be rewound after it is completed.");
			}
		}

		public void KillSequence()
		{
			if (sequence.IsActive())
			{
				sequence.Kill();
				sequence = null;
			}
		}

		private void ApplyFinalStatesSettings()
		{
			TweenSequenceTransformFinalState[] array = transformFinalStates;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].ApplySettings();
			}
			TweenSequenceImageFinalState[] array2 = imageFinalStates;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].ApplySettings();
			}
			CanvasGroupFinalState[] array3 = canvasGroupFinalStates;
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i].ApplySettings();
			}
			TextFinalState[] array4 = textFinalStates;
			for (int i = 0; i < array4.Length; i++)
			{
				array4[i].ApplySettings();
			}
			GradientColorFinalState[] array5 = gradientColorFinalStates;
			for (int i = 0; i < array5.Length; i++)
			{
				array5[i].ApplySettings();
			}
		}
	}
}

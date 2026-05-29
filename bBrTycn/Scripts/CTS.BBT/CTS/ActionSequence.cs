using System;
using System.Collections;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class ActionSequence : CTSBehaviour, IGive<Agent>
	{
		private enum EStartEvent
		{
			OnActionStarting = 0,
			OnActionStarted = 1,
			OnActionFinished = 2
		}

		[SerializeField]
		private SequenceAction _autoStartWith;

		[ShowIf("HasAutomaticStart")]
		[SerializeField]
		private EStartEvent _startEvent;

		[ShowIf(EConditionOperator.And, new string[] { "HasAutomaticStart", "_startEventIsFinished" })]
		[SerializeField]
		private bool _onlyStartOnSuccess = true;

		private SequenceAction[] _actions;

		private SequenceAction _currentAction;

		private int _currentActionIndex;

		[field: SerializeField]
		public SoftReference<Agent> Agent { get; private set; }

		private bool _startEventIsFinished => _startEvent == EStartEvent.OnActionFinished;

		public Agent PlayerAgent
		{
			get
			{
				if (Agent.HasValue)
				{
					return Agent.Get();
				}
				Agent componentInParent = GetComponentInParent<Agent>();
				if (componentInParent != null)
				{
					Agent = SoftReference.Create(componentInParent);
					return Agent.Get();
				}
				IGive<Agent> componentInParent2 = GetComponentInParent<IGive<Agent>>();
				if (componentInParent2 != null)
				{
					Agent = SoftReference.Create(componentInParent2);
				}
				return Agent.Get();
			}
		}

		private bool HasAutomaticStart => _autoStartWith;

		[Button(null, EButtonEnableMode.Always)]
		public void PlaySequence()
		{
			if (Application.isPlaying)
			{
				_actions = GetComponents<SequenceAction>();
				if (_actions != null && _actions.Length != 0 && _currentActionIndex == 0)
				{
					StartAction(0);
				}
			}
		}

		protected override void OnAwake()
		{
			if (!_autoStartWith)
			{
				return;
			}
			if (_autoStartWith.transform == base.transform)
			{
				_autoStartWith = null;
				return;
			}
			switch (_startEvent)
			{
			case EStartEvent.OnActionStarting:
				_autoStartWith.Started += delegate(bool started)
				{
					if (!started)
					{
						PlaySequence();
					}
				};
				break;
			case EStartEvent.OnActionStarted:
				_autoStartWith.Started += delegate(bool started)
				{
					if (started)
					{
						PlaySequence();
					}
				};
				break;
			case EStartEvent.OnActionFinished:
				_autoStartWith.Stopped += delegate(bool success)
				{
					if (success || !_onlyStartOnSuccess)
					{
						PlaySequence();
					}
				};
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private void StartAction(int index)
		{
			if (index.IsCorrectArrayIndex(_actions))
			{
				_currentActionIndex = index;
				_currentAction = _actions[_currentActionIndex];
				if (!_currentAction.IsValid())
				{
					throw new NullReferenceException($"Action of index {index} is invalid");
				}
				StartCoroutine(PlayCurrentAction());
			}
		}

		private IEnumerator PlayCurrentAction()
		{
			float startDelay = _actions[_currentActionIndex].StartDelay;
			if (_actions[_currentActionIndex].IsUnscaledTimeDelay)
			{
				yield return new WaitForSecondsRealtime(startDelay);
			}
			else
			{
				yield return new WaitForSeconds(startDelay);
			}
			if ((object)_currentAction != null)
			{
				_currentAction.Stopped += OnActionStopped;
				_currentAction.Play(this);
			}
		}

		private void OnActionStopped(bool success)
		{
			StopAction();
			if (success)
			{
				StartAction(_currentActionIndex + 1);
			}
		}

		private void StopAction()
		{
			if ((object)_currentAction != null)
			{
				_currentAction.Stopped -= OnActionStopped;
				_currentAction = null;
			}
		}

		public Agent Get()
		{
			return PlayerAgent;
		}
	}
}

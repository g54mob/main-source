using System.Collections;
using Febucci.TextAnimatorCore.Typing;
using Febucci.TextAnimatorForUnity.Actions.Core;
using Febucci.TextAnimatorForUnity.Core;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Actions
{
	public abstract class TypewriterActionScriptable : ActionScriptableBase
	{
		private class CoroutineState : IActionState
		{
			private readonly TypewriterActionScriptable scriptable;

			private readonly MonoBehaviour runner;

			private Coroutine activeCoroutine;

			private bool hasFinished;

			public CoroutineState(TypewriterActionScriptable scriptable, MonoBehaviour runner)
			{
				this.scriptable = scriptable;
				this.runner = runner;
			}

			public ActionStatus Progress(float deltaTime, ref TypingInfo typingInfo)
			{
				if (runner == null || !runner.isActiveAndEnabled)
				{
					return ActionStatus.Finished;
				}
				if (activeCoroutine == null)
				{
					activeCoroutine = runner.StartCoroutine(PerformCoroutineWrapper());
				}
				if (!hasFinished)
				{
					return ActionStatus.Running;
				}
				return ActionStatus.Finished;
			}

			private IEnumerator PerformCoroutineWrapper()
			{
				yield return scriptable.PerformAction();
				hasFinished = true;
			}

			public void Cancel()
			{
				if (activeCoroutine != null && runner != null)
				{
					runner.StopCoroutine(activeCoroutine);
					activeCoroutine = null;
				}
				hasFinished = true;
			}
		}

		[SerializeField]
		private string tagID;

		public override string TagID
		{
			get
			{
				return tagID;
			}
			set
			{
				tagID = value;
			}
		}

		public override IActionState CreateActionFrom(ActionMarker marker, object typewriter)
		{
			OnActionCreated(marker, typewriter);
			IActionState actionState = CreateCustomState(marker, typewriter);
			if (actionState != null)
			{
				return actionState;
			}
			if (typewriter is MonoBehaviour runner)
			{
				return new CoroutineState(this, runner);
			}
			MonoDispatcher instance = MonoDispatcher.Instance;
			if (instance != null)
			{
				return new CoroutineState(this, instance);
			}
			Debug.LogWarning("TypewriterActionScriptable '" + base.name + "': Neither CreateCustomState nor PerformAction was overridden, or typewriter is not a MonoBehaviour. Action will not execute.", this);
			return null;
		}

		protected virtual void OnActionCreated(ActionMarker marker, object typewriter)
		{
		}

		protected virtual IActionState CreateCustomState(ActionMarker marker, object typewriter)
		{
			return null;
		}

		protected virtual IEnumerator PerformAction()
		{
			yield break;
		}
	}
}

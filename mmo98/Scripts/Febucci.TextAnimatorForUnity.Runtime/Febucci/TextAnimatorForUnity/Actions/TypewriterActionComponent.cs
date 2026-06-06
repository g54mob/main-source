using System.Collections;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.Typing;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity.Actions
{
	public abstract class TypewriterActionComponent : MonoBehaviour, ITypewriterAction, ITagProvider
	{
		private class CoroutineState : IActionState
		{
			private TypingInfo typingInfo;

			private readonly TypewriterActionComponent component;

			private Coroutine activeCoroutine;

			private bool hasFinished;

			public CoroutineState(TypewriterActionComponent component)
			{
				this.component = component;
			}

			public ActionStatus Progress(float deltaTime, ref TypingInfo typingInfo)
			{
				if (component == null || !component.isActiveAndEnabled)
				{
					return ActionStatus.Finished;
				}
				if (activeCoroutine == null)
				{
					this.typingInfo = typingInfo;
					activeCoroutine = component.StartCoroutine(PerformCoroutineWrapper());
				}
				if (!hasFinished)
				{
					return ActionStatus.Running;
				}
				return ActionStatus.Finished;
			}

			private IEnumerator PerformCoroutineWrapper()
			{
				yield return component.PerformAction(typingInfo);
				hasFinished = true;
			}

			public void Cancel()
			{
				if (activeCoroutine != null && component != null)
				{
					component.StopCoroutine(activeCoroutine);
					activeCoroutine = null;
				}
				hasFinished = true;
			}
		}

		[SerializeField]
		private string tagID;

		[SerializeField]
		private bool makeAvailableGlobally;

		public string TagID
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

		private void Awake()
		{
			OnAwake();
		}

		protected virtual void OnAwake()
		{
		}

		private void OnEnable()
		{
			if (makeAvailableGlobally)
			{
				GlobalActionComponentsDatabase.Instance?.Register(this);
			}
			OnEnableCalled();
		}

		protected virtual void OnEnableCalled()
		{
		}

		private void OnDisable()
		{
			if (makeAvailableGlobally)
			{
				GlobalActionComponentsDatabase.Instance?.Unregister(this);
			}
			OnDisableCalled();
		}

		protected virtual void OnDisableCalled()
		{
		}

		public IActionState CreateActionFrom(ActionMarker marker, object typewriter)
		{
			OnActionCreated(marker, typewriter);
			IActionState actionState = CreateCustomState(marker, typewriter);
			if (actionState != null)
			{
				return actionState;
			}
			return new CoroutineState(this);
		}

		protected virtual void OnActionCreated(ActionMarker marker, object typewriter)
		{
		}

		protected virtual IActionState CreateCustomState(ActionMarker marker, object typewriter)
		{
			return null;
		}

		protected virtual IEnumerator PerformAction(TypingInfo typingInfo)
		{
			yield break;
		}
	}
}

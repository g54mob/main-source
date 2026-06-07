using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MalbersAnimations.Events
{
	[AddComponentMenu("Malbers/Events/Unity Event Raiser [On Enable]")]
	public class UnityEventRaiser : UnityUtils
	{
		[Tooltip("Delayed time for invoking the Events, or the Repeated time  when Repeat is enable")]
		public FloatReference Delayed = new FloatReference();

		public FloatReference RepeatTime = new FloatReference();

		public bool Repeat;

		[FormerlySerializedAs("OnEnableEvent")]
		public UnityEvent onEnable = new UnityEvent();

		public string Description = "";

		[HideInInspector]
		public bool ShowDescription;

		[ContextMenu("Show Description")]
		internal void EditDescription()
		{
			ShowDescription = !ShowDescription;
		}

		public void OnEnable()
		{
			if (Repeat && (float)RepeatTime > 0f)
			{
				InvokeRepeating("StartEvent", Delayed, RepeatTime);
			}
			else if ((float)Delayed > 0f)
			{
				Invoke("StartEvent", Delayed);
			}
			else
			{
				onEnable.Invoke();
			}
		}

		public void StartEvent()
		{
			onEnable.Invoke();
		}

		private void OnDisable()
		{
			CancelInvoke();
			StopAllCoroutines();
		}

		public virtual void Restart()
		{
			base.enabled = true;
			CancelInvoke();
			OnEnable();
		}
	}
}

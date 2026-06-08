using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace MalbersAnimations.Events
{
	public class UnityEventRaiser : UnityUtils
	{
		public float Delayed;

		public float RepeatTime;

		public bool Repeat;

		public string desc;

		[FormerlySerializedAs("OnEnableEvent")]
		public UnityEvent onEnable;

		public string Description = "";

		public bool editDescription;

		[ContextMenu("Edit Description")]
		internal void EditDescription()
		{
			editDescription = !editDescription;
		}

		public void OnEnable()
		{
			if (Repeat && RepeatTime > 0f)
			{
				InvokeRepeating("StartEvent", Delayed, RepeatTime);
			}
			else if (Delayed > 0f)
			{
				Invoke("StartEvent", Delayed);
			}
			else
			{
				onEnable.Invoke();
			}
		}

		[ContextMenu("Invoke on Editor")]
		private void StartEvent()
		{
			onEnable.Invoke();
		}

		private void OnDisable()
		{
			CancelInvoke();
		}
	}
}

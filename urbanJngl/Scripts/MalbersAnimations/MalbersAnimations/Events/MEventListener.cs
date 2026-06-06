using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Events
{
	[AddComponentMenu("Malbers/Events/Event Listener")]
	public class MEventListener : MonoBehaviour
	{
		public List<MEventItemListener> Events = new List<MEventItemListener>();

		[HideInInspector]
		[SerializeField]
		private bool ShowEvents = true;

		[HideInInspector]
		[SerializeField]
		private int SelectedEvent;

		private void OnEnable()
		{
			foreach (MEventItemListener @event in Events)
			{
				if ((bool)@event.Event)
				{
					@event.Event.RegisterListener(@event);
				}
				@event.Owner = base.transform;
			}
		}

		private void OnDisable()
		{
			foreach (MEventItemListener @event in Events)
			{
				if ((bool)@event.Event)
				{
					@event.Event.UnregisterListener(@event);
				}
			}
		}

		public void Pause()
		{
			Debug.Log("Pause Editor", this);
			Debug.Break();
		}

		public void Behaviour_EnableNextFrame(Behaviour behaviour)
		{
			behaviour.enabled = false;
			this.Delay_Action(delegate
			{
				behaviour.enabled = true;
			});
		}
	}
}

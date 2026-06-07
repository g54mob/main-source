using UnityEngine;
using UnityEngine.Events;

namespace CTS
{
	public class ActionTriggerEvent : InstantAction
	{
		[SerializeField]
		private UnityEvent _event;

		protected override bool PlayAction(ActionSequence sequence)
		{
			_event.Invoke();
			return true;
		}
	}
}

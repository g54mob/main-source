using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Receive Signal")]
	[Category("Logic/On Receive Signal")]
	[Description("Executed when receiving a specific signal name from the dispatcher")]
	[Image(typeof(IconSignal), ColorTheme.Type.Red)]
	[Keywords(new string[] { "Event", "Command", "Fire", "Trigger", "Dispatch", "Execute" })]
	public class EventOnReceiveSignal : Event
	{
		[SerializeField]
		private Signal m_Signal;

		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			Signals.Subscribe(trigger, m_Signal.Value);
		}

		protected internal override void OnDisable(Trigger trigger)
		{
			base.OnDisable(trigger);
			Signals.Unsubscribe(trigger, m_Signal.Value);
		}

		protected internal override void OnReceiveSignal(Trigger trigger, SignalArgs args)
		{
			base.OnReceiveSignal(trigger, args);
			if (!(m_Signal.Value != args.signal))
			{
				m_Trigger.Execute(args.invoker);
			}
		}
	}
}

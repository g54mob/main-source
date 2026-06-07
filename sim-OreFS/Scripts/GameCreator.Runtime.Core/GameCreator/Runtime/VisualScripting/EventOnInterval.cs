using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Interval")]
	[Category("Lifecycle/On Interval")]
	[Description("Executes after an amount of seconds have passed between each call")]
	[Parameter("Time Mode", "The time scale in which the interval is calculated")]
	[Parameter("Interval", "Amount of seconds between each iteration")]
	[Image(typeof(IconLoop), ColorTheme.Type.Blue, typeof(OverlayDot))]
	[Keywords(new string[] { "Loop", "Tick", "Continuous", "FPS" })]
	public class EventOnInterval : Event
	{
		[SerializeField]
		private TimeMode m_TimeMode = new TimeMode(TimeMode.UpdateMode.GameTime);

		[SerializeField]
		private PropertyGetDecimal m_Interval = new PropertyGetDecimal(1f);

		private double m_NextInterval = double.MinValue;

		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			m_NextInterval = (double)m_TimeMode.Time + m_Interval.Get(trigger.gameObject);
		}

		protected internal override void OnDisable(Trigger trigger)
		{
			base.OnDisable(trigger);
			m_NextInterval = double.MinValue;
		}

		protected internal override void OnUpdate(Trigger trigger)
		{
			base.OnUpdate(trigger);
			if (!((double)m_TimeMode.Time < m_NextInterval))
			{
				m_NextInterval = (double)m_TimeMode.Time + m_Interval.Get(trigger.gameObject);
				trigger.Execute(base.Self);
			}
		}
	}
}

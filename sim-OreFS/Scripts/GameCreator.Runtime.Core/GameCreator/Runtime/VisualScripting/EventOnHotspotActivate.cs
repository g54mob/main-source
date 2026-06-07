using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Hotspot Activate")]
	[Category("Logic/On Hotspot Activate")]
	[Description("Executed when its associated Hotspot is activated")]
	[Image(typeof(IconHotspot), ColorTheme.Type.Green)]
	[Keywords(new string[] { "Spot" })]
	public class EventOnHotspotActivate : Event
	{
		[SerializeField]
		private PropertyGetGameObject m_Hotspot = GetGameObjectSelf.Create();

		[NonSerialized]
		private Hotspot m_Cache;

		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			m_Cache = m_Hotspot.Get<Hotspot>(base.Self);
			if (!(m_Cache == null))
			{
				m_Cache.EventOnActivate -= OnActivate;
				m_Cache.EventOnActivate += OnActivate;
			}
		}

		protected internal override void OnDisable(Trigger trigger)
		{
			base.OnDisable(trigger);
			if (!(m_Cache == null))
			{
				m_Cache.EventOnActivate -= OnActivate;
			}
		}

		private void OnActivate()
		{
			m_Trigger.Execute(base.Self);
		}
	}
}

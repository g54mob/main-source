using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Hotspot Deactivate")]
	[Category("Logic/On Hotspot Deactivate")]
	[Description("Executed when its associated Hotspot is deactivated")]
	[Image(typeof(IconHotspot), ColorTheme.Type.Red)]
	[Keywords(new string[] { "Spot" })]
	public class EventOnHotspotDeactivate : Event
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
				m_Cache.EventOnDeactivate -= OnDeactivate;
				m_Cache.EventOnDeactivate += OnDeactivate;
			}
		}

		protected internal override void OnDisable(Trigger trigger)
		{
			base.OnDisable(trigger);
			if (!(m_Cache == null))
			{
				m_Cache.EventOnDeactivate -= OnDeactivate;
			}
		}

		private void OnDeactivate()
		{
			m_Trigger.Execute(base.Self);
		}
	}
}

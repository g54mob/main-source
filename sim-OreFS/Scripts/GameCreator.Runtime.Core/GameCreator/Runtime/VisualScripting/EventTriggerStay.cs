using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Trigger Stay")]
	[Category("Physics/On Trigger Stay")]
	[Description("Executed while a game object stays inside the Trigger collider")]
	[Image(typeof(IconTriggerStay), ColorTheme.Type.Blue)]
	[Keywords(new string[] { "Pass", "Through", "Touch", "Collision", "Collide" })]
	public class EventTriggerStay : TEventPhysics
	{
		protected internal override void OnTriggerStay3D(Trigger trigger, Collider collider)
		{
			base.OnTriggerStay3D(trigger, collider);
			if (base.IsActive && Match(collider.gameObject))
			{
				m_Trigger.Execute(collider.gameObject);
			}
		}

		protected internal override void OnTriggerStay2D(Trigger trigger, Collider2D collider)
		{
			base.OnTriggerStay2D(trigger, collider);
			if (base.IsActive && Match(collider.gameObject))
			{
				m_Trigger.Execute(collider.gameObject);
			}
		}
	}
}

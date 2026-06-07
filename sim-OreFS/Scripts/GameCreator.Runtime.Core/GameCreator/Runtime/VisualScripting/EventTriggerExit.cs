using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Trigger Exit")]
	[Category("Physics/On Trigger Exit")]
	[Description("Executed when a game object leaves the Trigger collider")]
	[Image(typeof(IconTriggerExit), ColorTheme.Type.Red)]
	[Keywords(new string[] { "Leave", "Through", "Touch", "Collision", "Collide" })]
	public class EventTriggerExit : TEventPhysics
	{
		protected internal override void OnTriggerExit3D(Trigger trigger, Collider collider)
		{
			base.OnTriggerExit3D(trigger, collider);
			if (base.IsActive && Match(collider.gameObject))
			{
				GetGameObjectLastTriggerExit.Instance = collider.gameObject;
				m_Trigger.Execute(collider.gameObject);
			}
		}

		protected internal override void OnTriggerExit2D(Trigger trigger, Collider2D collider)
		{
			base.OnTriggerExit2D(trigger, collider);
			if (base.IsActive && Match(collider.gameObject))
			{
				GetGameObjectLastTriggerExit.Instance = collider.gameObject;
				m_Trigger.Execute(collider.gameObject);
			}
		}
	}
}

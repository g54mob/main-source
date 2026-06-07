using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Collide")]
	[Category("Physics/On Collide")]
	[Description("Executed when the Trigger collides with a game object")]
	[Image(typeof(IconCollision), ColorTheme.Type.Blue)]
	[Keywords(new string[] { "Crash", "Touch", "Bump", "Collision" })]
	public class EventCollideWith : TEventPhysics
	{
		protected internal override void OnCollisionEnter3D(Trigger trigger, Collision collision)
		{
			base.OnCollisionEnter3D(trigger, collision);
			if (base.IsActive && Match(collision.gameObject))
			{
				GetGameObjectLastCollidedEnter.Instance = collision.gameObject;
				m_Trigger.Execute(collision.gameObject);
			}
		}

		protected internal override void OnCollisionEnter2D(Trigger trigger, Collision2D collision)
		{
			base.OnCollisionEnter2D(trigger, collision);
			if (base.IsActive && Match(collision.gameObject))
			{
				GetGameObjectLastCollidedEnter.Instance = collision.gameObject;
				m_Trigger.Execute(collision.gameObject);
			}
		}
	}
}

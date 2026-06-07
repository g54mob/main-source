using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Collide Exit")]
	[Category("Physics/On Collide Exit")]
	[Description("Executed when the Trigger that collided with a game object, stops colliding")]
	[Image(typeof(IconCollision), ColorTheme.Type.Red)]
	[Keywords(new string[] { "Crash", "Touch", "Bump", "Collision", "Stop" })]
	public class EventCollideExitWith : TEventPhysics
	{
		protected internal override void OnCollisionExit3D(Trigger trigger, Collision collision)
		{
			base.OnCollisionExit3D(trigger, collision);
			if (base.IsActive && Match(collision.gameObject))
			{
				GetGameObjectLastCollidedExit.Instance = collision.gameObject;
				m_Trigger.Execute(collision.gameObject);
			}
		}

		protected internal override void OnCollisionExit2D(Trigger trigger, Collision2D collision)
		{
			base.OnCollisionExit2D(trigger, collision);
			if (base.IsActive && Match(collision.gameObject))
			{
				GetGameObjectLastCollidedExit.Instance = collision.gameObject;
				m_Trigger.Execute(collision.gameObject);
			}
		}
	}
}

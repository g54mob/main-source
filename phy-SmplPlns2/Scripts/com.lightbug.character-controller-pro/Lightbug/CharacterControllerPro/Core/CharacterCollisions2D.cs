using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Core
{
	public class CharacterCollisions2D : CharacterCollisions
	{
		public override float ContactOffset => Physics2D.defaultContactOffset;

		public override float CollisionRadius => base.CharacterActor.BodySize.x / 2f;

		protected override void Awake()
		{
			base.Awake();
			base.PhysicsComponent = base.gameObject.AddComponent<PhysicsComponent2D>();
		}
	}
}

using System;
using System.Collections.Generic;
using Ludiq;
using UnityEngine;

namespace Bolt
{
	[UnitCategory("Events/Physics")]
	public sealed class OnParticleCollision : GameObjectEventUnit<GameObject>
	{
		public override Type MessageListenerType => typeof(UnityOnParticleCollisionMessageListener);

		protected override string hookName => "OnParticleCollision";

		[DoNotSerialize]
		public ValueOutput other { get; private set; }

		[DoNotSerialize]
		public ValueOutput collisionEvents { get; private set; }

		protected override void Definition()
		{
			base.Definition();
			other = ValueOutput<GameObject>("other");
			collisionEvents = ValueOutput<List<ParticleCollisionEvent>>("collisionEvents");
		}

		protected override void AssignArguments(Flow flow, GameObject other)
		{
			flow.SetValue(this.other, other);
			List<ParticleCollisionEvent> value = new List<ParticleCollisionEvent>();
			Data elementData = flow.stack.GetElementData<Data>(this);
			elementData.target.GetComponent<ParticleSystem>().GetCollisionEvents(other, value);
			flow.SetValue(collisionEvents, value);
		}
	}
}

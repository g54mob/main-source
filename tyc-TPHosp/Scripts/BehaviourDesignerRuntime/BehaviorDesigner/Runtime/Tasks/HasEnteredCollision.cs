using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
	[TaskDescription("Returns success when a collision starts.")]
	[TaskCategory("Physics")]
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=110")]
	public class HasEnteredCollision : Conditional
	{
		[Tooltip("The tag of the GameObject to check for a collision against")]
		public SharedString tag = "";

		[Tooltip("The object that started the collision")]
		public SharedGameObject collidedGameObject;

		private bool enteredCollision;

		public override TaskStatus OnUpdate()
		{
			if (!enteredCollision)
			{
				return TaskStatus.Failure;
			}
			return TaskStatus.Success;
		}

		public override void OnEnd()
		{
			enteredCollision = false;
		}

		public override void OnCollisionEnter(Collision collision)
		{
			if (string.IsNullOrEmpty(tag.Value) || tag.Value.Equals(collision.gameObject.tag))
			{
				collidedGameObject.Value = collision.gameObject;
				enteredCollision = true;
			}
		}

		public override void OnReset()
		{
			tag = "";
			collidedGameObject = null;
		}
	}
}

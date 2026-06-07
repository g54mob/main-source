using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Kinematic")]
	[Description("Returns true if the game object's Rigidbody or Rigidbody2D is marked as Kinematic")]
	[Category("Physics/Is Kinematic")]
	[Parameter("Game Object", "The game object instance with a Rigidbody or Rigidbody2D")]
	[Keywords(new string[] { "Affect", "Physics", "Force", "Rigidbody" })]
	[Image(typeof(IconPhysics), ColorTheme.Type.Green)]
	public class ConditionPhysicsIsKinematic : Condition
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = new PropertyGetGameObject();

		protected override string Summary => $"{m_GameObject} is Kinematic";

		protected override bool Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return false;
			}
			Rigidbody rigidbody = gameObject.Get<Rigidbody>();
			if (rigidbody != null)
			{
				return rigidbody.isKinematic;
			}
			Rigidbody2D rigidbody2D = gameObject.Get<Rigidbody2D>();
			if (rigidbody2D != null)
			{
				return rigidbody2D.bodyType == RigidbodyType2D.Kinematic;
			}
			return false;
		}
	}
}

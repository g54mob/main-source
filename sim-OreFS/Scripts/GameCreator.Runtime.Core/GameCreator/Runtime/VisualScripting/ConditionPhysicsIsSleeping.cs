using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Sleeping")]
	[Description("Returns true if the game object's Rigidbody or Rigidbody2D is sleeping")]
	[Category("Physics/Is Sleeping")]
	[Parameter("Game Object", "The game object instance with a Rigidbody or Rigidbody2D")]
	[Keywords(new string[] { "Affect", "Physics", "Force", "Rigidbody", "Awake" })]
	[Image(typeof(IconPhysics), ColorTheme.Type.Green, typeof(OverlayZ))]
	public class ConditionPhysicsIsSleeping : Condition
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = new PropertyGetGameObject();

		protected override string Summary => $"{m_GameObject} is Sleeping";

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
				return rigidbody.IsSleeping();
			}
			Rigidbody2D rigidbody2D = gameObject.Get<Rigidbody2D>();
			if (rigidbody2D != null)
			{
				return rigidbody2D.IsSleeping();
			}
			return false;
		}
	}
}

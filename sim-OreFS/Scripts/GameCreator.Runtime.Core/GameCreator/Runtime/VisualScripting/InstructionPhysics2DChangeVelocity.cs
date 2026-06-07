using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Velocity 2D")]
	[Description("Changes the current velocity of a Rigidbody2D")]
	[Category("Physics 2D/Change Velocity 2D")]
	[Parameter("Rigidbody", "The game object with a Rigidbody2D attached that will change its velocity")]
	[Parameter("Velocity", "The velocity the game object will change to")]
	[Keywords(new string[] { "Speed", "Movement" })]
	[Keywords(new string[] { "Physics", "Rigidbody" })]
	[Image(typeof(IconPhysics), ColorTheme.Type.Yellow)]
	public class InstructionPhysics2DChangeVelocity : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Rigidbody = GetGameObjectSelf.Create();

		[Space]
		[SerializeField]
		private ChangeDirection m_Velocity = new ChangeDirection(Vector3.forward);

		public override string Title => $"Velocity of {m_Rigidbody} {m_Velocity}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_Rigidbody.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			Rigidbody2D rigidbody2D = gameObject.Get<Rigidbody2D>();
			if (rigidbody2D == null)
			{
				return Instruction.DefaultResult;
			}
			rigidbody2D.linearVelocity = m_Velocity.Get(rigidbody2D.linearVelocity, args);
			return Instruction.DefaultResult;
		}
	}
}

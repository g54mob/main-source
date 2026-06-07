using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Velocity 3D")]
	[Description("Changes the current velocity of a Rigidbody")]
	[Category("Physics 3D/Change Velocity 3D")]
	[Parameter("Rigidbody", "The game object with a Rigidbody attached that changes its velocity")]
	[Parameter("Velocity", "The velocity the game object changes to")]
	[Keywords(new string[] { "Speed", "Movement" })]
	[Keywords(new string[] { "Physics", "Rigidbody" })]
	[Image(typeof(IconPhysics), ColorTheme.Type.Yellow)]
	public class InstructionPhysics3DChangeVelocity : Instruction
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
			Rigidbody rigidbody = gameObject.Get<Rigidbody>();
			if (rigidbody == null)
			{
				return Instruction.DefaultResult;
			}
			rigidbody.linearVelocity = m_Velocity.Get(rigidbody.linearVelocity, args);
			return Instruction.DefaultResult;
		}
	}
}

using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Mass 3D")]
	[Description("Changes the mass of a Rigidbody")]
	[Category("Physics 3D/Change Mass 3D")]
	[Parameter("Rigidbody", "The game object with a Rigidbody attached that changes its mass")]
	[Parameter("Mass", "The new mass the game object")]
	[Keywords(new string[] { "Weight" })]
	[Keywords(new string[] { "Physics", "Rigidbody" })]
	[Image(typeof(IconPhysics), ColorTheme.Type.Yellow)]
	public class InstructionPhysics3DChangeMass : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Rigidbody = GetGameObjectSelf.Create();

		[Space]
		[SerializeField]
		private ChangeDecimal m_Mass = new ChangeDecimal(10f);

		public override string Title => $"Change Mass of {m_Rigidbody} {m_Mass}";

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
			rigidbody.mass = (float)m_Mass.Get(rigidbody.mass, args);
			return Instruction.DefaultResult;
		}
	}
}

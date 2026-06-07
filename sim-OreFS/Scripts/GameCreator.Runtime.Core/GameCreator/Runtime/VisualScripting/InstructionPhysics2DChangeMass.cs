using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Mass 2D")]
	[Description("Changes the mass of a Rigidbody2D")]
	[Category("Physics 2D/Change Mass 2D")]
	[Parameter("Rigidbody", "The game object with a Rigidbody2D attached that will change its mass")]
	[Parameter("Mass", "The new mass the game object will be set to have")]
	[Keywords(new string[] { "Weight" })]
	[Keywords(new string[] { "Physics", "Rigidbody" })]
	[Image(typeof(IconPhysics), ColorTheme.Type.Yellow)]
	public class InstructionPhysics2DChangeMass : Instruction
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
			Rigidbody2D rigidbody2D = gameObject.Get<Rigidbody2D>();
			if (rigidbody2D == null)
			{
				return Instruction.DefaultResult;
			}
			rigidbody2D.mass = (float)m_Mass.Get(rigidbody2D.mass, args);
			return Instruction.DefaultResult;
		}
	}
}

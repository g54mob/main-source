using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Gravity Scale 2D")]
	[Description("Controls whether how gravity affects the Rigidbody2D")]
	[Category("Physics 2D/Gravity Scale 2D")]
	[Parameter("Rigidbody", "The game object with a Rigidbody2D attached that changes its gravity scale")]
	[Parameter("Gravity Scale", "The degree to which this object is affected by gravity")]
	[Keywords(new string[] { "Physics", "Rigidbody" })]
	[Image(typeof(IconPhysics), ColorTheme.Type.Yellow)]
	public class InstructionPhysics2DGravityScale : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Rigidbody = GetGameObjectSelf.Create();

		[Space]
		[SerializeField]
		private PropertyGetDecimal m_GravityScale = GetDecimalDecimal.Create(1f);

		public override string Title => $"Set Gravity Scale on {m_Rigidbody}";

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
			rigidbody2D.gravityScale = (float)m_GravityScale.Get(args);
			return Instruction.DefaultResult;
		}
	}
}

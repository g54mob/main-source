using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Add Explosion Force 2D")]
	[Description("Applies a force to a Rigidbody2D that simulates explosion effects")]
	[Category("Physics 2D/Add Explosion Force 2D")]
	[Parameter("Rigidbody", "The game object with a Rigidbody2D component that receives the force")]
	[Parameter("Origin", "The position where the explosion originates")]
	[Parameter("Radius", "How far the blast reaches")]
	[Parameter("Force", "The force of the explosion, which its at its maximum at the origin")]
	[Parameter("Force Mode", "How the force is applied")]
	[Keywords(new string[] { "Apply", "Velocity", "Impulse", "Propel", "Push", "Pull", "Boom" })]
	[Keywords(new string[] { "Physics", "Rigidbody" })]
	[Image(typeof(IconPhysics), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	public class InstructionPhysics2DExplosion : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Rigidbody = GetGameObjectSelf.Create();

		[Space]
		[SerializeField]
		private PropertyGetPosition m_Origin = new PropertyGetPosition();

		[SerializeField]
		private PropertyGetDecimal m_Radius = new PropertyGetDecimal(5f);

		[Space]
		[SerializeField]
		private PropertyGetDecimal m_Force = new PropertyGetDecimal(10f);

		[SerializeField]
		private ForceMode2D m_ForceMode = ForceMode2D.Impulse;

		public override string Title => $"Add Explode on {m_Rigidbody} at {m_Origin}";

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
			Vector3 vector = m_Origin.Get(args);
			double num = m_Radius.Get(args);
			double num2 = m_Force.Get(args);
			Vector2 vector2 = (gameObject.transform.position - vector).XY();
			double num3 = 1.0 - Math.Clamp((double)vector2.magnitude / num, 0.0, 1.0);
			rigidbody2D.AddForce(vector2.normalized * (float)(num2 * num3), m_ForceMode);
			return Instruction.DefaultResult;
		}
	}
}

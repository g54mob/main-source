using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Add Explosion Force 3D")]
	[Description("Applies a force to a Rigidbody that simulates explosion effects")]
	[Category("Physics 3D/Add Explosion Force 3D")]
	[Parameter("Rigidbody", "The game object with a Rigidbody component that receives the force")]
	[Parameter("Origin", "The position where the explosion originates")]
	[Parameter("Radius", "How far the blast reaches")]
	[Parameter("Force", "The force of the explosion, which its at its maximum at the origin")]
	[Parameter("Force Mode", "How the force is applied")]
	[Keywords(new string[] { "Apply", "Velocity", "Impulse", "Propel", "Push", "Pull", "Boom" })]
	[Keywords(new string[] { "Physics", "Rigidbody" })]
	[Image(typeof(IconPhysics), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	public class InstructionPhysics3DExplosion : Instruction
	{
		private const float RELAY_UPWARDS_MODIFIER = 0.2f;

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
		private ForceMode m_ForceMode = ForceMode.Impulse;

		public override string Title => $"Add Explode on {m_Rigidbody} at {m_Origin}";

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
			Vector3 explosionPosition = m_Origin.Get(args);
			float explosionRadius = (float)m_Radius.Get(args);
			float num = (float)m_Force.Get(args);
			rigidbody.AddExplosionForce(num, explosionPosition, explosionRadius, num * 0.2f, m_ForceMode);
			return Instruction.DefaultResult;
		}
	}
}

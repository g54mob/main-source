using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Add Force 2D")]
	[Description("Adds a force to a game object with a Rigidbody2D")]
	[Category("Physics 2D/Add Force 2D")]
	[Parameter("Rigidbody", "The game object that will receive the force. A Rigidbody2D attached is required")]
	[Parameter("Direction", "The direction in which the force will be applied")]
	[Parameter("Force", "The amount of force applied")]
	[Parameter("Force Mode", "The type of force applied")]
	[Keywords(new string[] { "Apply", "Velocity", "Impulse", "Propel", "Push", "Pull" })]
	[Keywords(new string[] { "Physics", "Rigidbody" })]
	[Image(typeof(IconPhysics), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	public class InstructionPhysics2DAddForce : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Rigidbody = GetGameObjectSelf.Create();

		[Space]
		[SerializeField]
		private PropertyGetRotation m_Direction = new PropertyGetRotation();

		[SerializeField]
		private PropertyGetDecimal m_Force = new PropertyGetDecimal(10f);

		[SerializeField]
		private ForceMode2D m_ForceMode = ForceMode2D.Impulse;

		[SerializeField]
		private Space m_SpaceMode;

		public override string Title => $"Add {m_ForceMode} {m_Force} to {m_Rigidbody}";

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
			Quaternion quaternion = m_Direction.Get(args);
			float num = (float)m_Force.Get(args);
			Vector3 vector = quaternion * Vector3.forward;
			Vector2 vector2 = new Vector2(vector.x, vector.y).normalized * num;
			if (m_SpaceMode == Space.Self)
			{
				vector2 = gameObject.transform.InverseTransformDirection(vector2);
			}
			rigidbody2D.AddForce(vector2, m_ForceMode);
			return Instruction.DefaultResult;
		}
	}
}

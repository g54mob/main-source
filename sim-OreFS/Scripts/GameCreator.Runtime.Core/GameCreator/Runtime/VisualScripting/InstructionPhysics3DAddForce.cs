using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Add Force 3D")]
	[Description("Adds a force to a game object with a Rigidbody")]
	[Category("Physics 3D/Add Force 3D")]
	[Parameter("Rigidbody", "The game object with a Rigidbody component that receives the force")]
	[Parameter("Direction", "The direction in which the force is applied")]
	[Parameter("Force", "The amount of force applied")]
	[Parameter("Force Mode", "The type of force applied")]
	[Parameter("Space Mode", "Whether the force is applied in local or world space")]
	[Keywords(new string[] { "Apply", "Velocity", "Impulse", "Propel", "Push", "Pull" })]
	[Keywords(new string[] { "Physics", "Rigidbody" })]
	[Image(typeof(IconPhysics), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	public class InstructionPhysics3DAddForce : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Rigidbody = GetGameObjectSelf.Create();

		[Space]
		[SerializeField]
		private PropertyGetRotation m_Direction = new PropertyGetRotation();

		[SerializeField]
		private PropertyGetDecimal m_Force = new PropertyGetDecimal(10f);

		[SerializeField]
		private ForceMode m_ForceMode = ForceMode.Impulse;

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
			Rigidbody rigidbody = gameObject.Get<Rigidbody>();
			if (rigidbody == null)
			{
				return Instruction.DefaultResult;
			}
			Quaternion quaternion = m_Direction.Get(args);
			float num = (float)m_Force.Get(args);
			Vector3 vector = (quaternion * Vector3.forward).normalized * num;
			if (m_SpaceMode == Space.Self)
			{
				vector = gameObject.transform.InverseTransformDirection(vector);
			}
			rigidbody.AddForce(vector, m_ForceMode);
			return Instruction.DefaultResult;
		}
	}
}

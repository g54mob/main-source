using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Kinematic 2D")]
	[Description("Controls whether physics affects the Rigidbody2D")]
	[Category("Physics 2D/Is Kinematic 2D")]
	[Parameter("Rigidbody", "The game object with a Rigidbody2D attached that changes its kinematic usage")]
	[Parameter("Is Kinematic", "If enabled, forces, collisions or joints do not affect the rigidbody anymore")]
	[Keywords(new string[] { "Physics", "Rigidbody" })]
	[Image(typeof(IconPhysics), ColorTheme.Type.Yellow)]
	public class InstructionPhysics2DIsKinematic : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Rigidbody = GetGameObjectSelf.Create();

		[Space]
		[SerializeField]
		private PropertyGetBool m_IsKinematic = GetBoolValue.Create(value: false);

		public override string Title => $"Set Is Kinematic = {m_IsKinematic} on {m_Rigidbody}";

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
			rigidbody2D.bodyType = (m_IsKinematic.Get(args) ? RigidbodyType2D.Kinematic : RigidbodyType2D.Dynamic);
			return Instruction.DefaultResult;
		}
	}
}

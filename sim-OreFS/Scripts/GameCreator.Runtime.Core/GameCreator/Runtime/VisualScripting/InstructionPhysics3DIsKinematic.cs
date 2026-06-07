using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Kinematic 3D")]
	[Description("Controls whether physics affects the Rigidbody")]
	[Category("Physics 3D/Is Kinematic 3D")]
	[Parameter("Rigidbody", "The game object with a Rigidbody attached that changes its kinematic usage")]
	[Parameter("Is Kinematic", "If enabled, forces, collisions or joints do not affect the rigidbody anymore")]
	[Keywords(new string[] { "Physics", "Rigidbody" })]
	[Image(typeof(IconPhysics), ColorTheme.Type.Yellow)]
	public class InstructionPhysics3DIsKinematic : Instruction
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
			Rigidbody rigidbody = gameObject.Get<Rigidbody>();
			if (rigidbody == null)
			{
				return Instruction.DefaultResult;
			}
			rigidbody.isKinematic = m_IsKinematic.Get(args);
			return Instruction.DefaultResult;
		}
	}
}

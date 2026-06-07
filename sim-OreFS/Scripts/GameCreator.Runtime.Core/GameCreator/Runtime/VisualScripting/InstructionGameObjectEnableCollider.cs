using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Enable Collider")]
	[Description("Enables a Collider component from the game object")]
	[Category("Game Objects/Components/Enable Collider")]
	[Keywords(new string[] { "Active", "Turn", "On", "Box", "Sphere", "Capsule", "Mesh" })]
	[Image(typeof(IconPhysics), ColorTheme.Type.Yellow)]
	public class InstructionGameObjectEnableCollider : TInstructionGameObject
	{
		public override string Title => $"Enable Collider from {m_GameObject}";

		protected override Task Run(Args args)
		{
			Collider collider = m_GameObject.Get<Collider>(args);
			if (collider != null)
			{
				collider.enabled = true;
			}
			return Instruction.DefaultResult;
		}
	}
}

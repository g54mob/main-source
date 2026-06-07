using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Disable Collider")]
	[Description("Disables a Collider component from the game object")]
	[Category("Game Objects/Components/Disable Collider")]
	[Keywords(new string[] { "Inactive", "Turn", "Off", "Box", "Sphere", "Capsule", "Mesh" })]
	[Image(typeof(IconPhysics), ColorTheme.Type.Red)]
	public class InstructionGameObjectDisableCollider : TInstructionGameObject
	{
		public override string Title => $"Disable Collider from {m_GameObject}";

		protected override Task Run(Args args)
		{
			Collider collider = m_GameObject.Get<Collider>(args);
			if (collider != null)
			{
				collider.enabled = false;
			}
			return Instruction.DefaultResult;
		}
	}
}

using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Disable Renderer")]
	[Description("Disables a Renderer component from the game object")]
	[Category("Game Objects/Components/Disable Renderer")]
	[Keywords(new string[] { "Inactive", "Turn", "Off", "Mesh" })]
	[Image(typeof(IconSkinMesh), ColorTheme.Type.Red)]
	public class InstructionGameObjectDisableRenderer : TInstructionGameObject
	{
		public override string Title => $"Disable Renderer from {m_GameObject}";

		protected override Task Run(Args args)
		{
			Renderer renderer = m_GameObject.Get<Renderer>(args);
			if (renderer != null)
			{
				renderer.enabled = false;
			}
			return Instruction.DefaultResult;
		}
	}
}

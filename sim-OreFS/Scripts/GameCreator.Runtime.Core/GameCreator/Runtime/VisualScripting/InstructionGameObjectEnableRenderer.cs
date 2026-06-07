using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Enable Renderer")]
	[Description("Enables a Renderer component from the game object")]
	[Category("Game Objects/Components/Enable Renderer")]
	[Keywords(new string[] { "Inactive", "Turn", "Off", "Mesh" })]
	[Image(typeof(IconSkinMesh), ColorTheme.Type.Yellow)]
	public class InstructionGameObjectEnableRenderer : TInstructionGameObject
	{
		public override string Title => $"Enable Renderer from {m_GameObject}";

		protected override Task Run(Args args)
		{
			Renderer renderer = m_GameObject.Get<Renderer>(args);
			if (renderer != null)
			{
				renderer.enabled = true;
			}
			return Instruction.DefaultResult;
		}
	}
}

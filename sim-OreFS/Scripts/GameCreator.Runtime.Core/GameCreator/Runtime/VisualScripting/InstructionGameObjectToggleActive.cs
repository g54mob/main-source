using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Toggle Active")]
	[Description("Toggles the state of a game object to active or to inactive")]
	[Category("Game Objects/Toggle Active")]
	[Keywords(new string[] { "Activate", "Deactivate", "Enable", "Disable", "Switch", "Swap" })]
	[Keywords(new string[] { "MonoBehaviour", "Behaviour", "Script" })]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Yellow)]
	public class InstructionGameObjectToggleActive : TInstructionGameObject
	{
		public override string Title => $"Toggle Active {m_GameObject}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			bool activeSelf = gameObject.activeSelf;
			gameObject.SetActive(!activeSelf);
			return Instruction.DefaultResult;
		}
	}
}

using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Destroy")]
	[Description("Destroys a game object scene instance")]
	[Category("Game Objects/Destroy")]
	[Keywords(new string[] { "Remove", "Delete", "Flush", "MonoBehaviour", "Behaviour", "Script" })]
	[Image(typeof(IconCubeOutline), ColorTheme.Type.Red, typeof(OverlayMinus))]
	public class InstructionGameObjectDestroy : TInstructionGameObject
	{
		public override string Title => $"Destroy {m_GameObject}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			UnityEngine.Object.Destroy(gameObject);
			return Instruction.DefaultResult;
		}
	}
}

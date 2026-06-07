using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Tag")]
	[Description("Changes the Tag of a game object")]
	[Parameter("Tag", "The tag value which the game object belongs to")]
	[Category("Game Objects/Change Tag")]
	[Keywords(new string[] { "MonoBehaviour", "Behaviour", "Script" })]
	[Image(typeof(IconTag), ColorTheme.Type.Yellow)]
	public class InstructionGameObjectTag : TInstructionGameObject
	{
		[SerializeField]
		private TagValue m_Tag = new TagValue();

		public override string Title => $"Change Tag to {m_Tag} on {m_GameObject}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			gameObject.tag = m_Tag.Value;
			return Instruction.DefaultResult;
		}
	}
}

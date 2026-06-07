using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Change Sprite")]
	[Description("Sets the Sprite value")]
	[Category("Renderer/Change Sprite")]
	[Parameter("To", "Where to store the new Sprite value")]
	[Parameter("Sprite", "The Sprite value to be stored")]
	[Keywords(new string[] { "Texture", "Renderer" })]
	[Image(typeof(IconSprite), ColorTheme.Type.Purple)]
	public class InstructionSetSprite : Instruction
	{
		[SerializeField]
		protected PropertySetSprite m_To = new PropertySetSprite();

		[SerializeField]
		private PropertyGetSprite m_Sprite = GetSpriteInstance.Create();

		public override string Title => $"Set {m_To} = {m_Sprite}";

		protected override Task Run(Args args)
		{
			Sprite value = m_Sprite.Get(args);
			m_To.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}

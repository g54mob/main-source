using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Time Mode")]
	[Description("Changes the Character's Time Mode")]
	[Category("Characters/Properties/Change Time Mode")]
	[Parameter("Time Mode", "The target Time Mode for the Character")]
	[Keywords(new string[] { "Scale", "Game" })]
	[Image(typeof(IconTimer), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyTimeMode : TInstructionCharacterProperty
	{
		[SerializeField]
		private TimeMode.UpdateMode m_TimeMode;

		public override string Title => $"Time Mode {m_Character} = {m_TimeMode}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			character.Time = new TimeMode(m_TimeMode);
			return Instruction.DefaultResult;
		}
	}
}

using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Set Color")]
	[Description("Sets the value of a Color")]
	[Category("Math/Shading/Set Color")]
	[Parameter("Color", "The Color value to set")]
	[Keywords(new string[] { "Change", "Value" })]
	[Image(typeof(IconColor), ColorTheme.Type.Yellow)]
	public class InstructionShadingSetColor : TInstructionShading
	{
		[SerializeField]
		private PropertyGetColor m_Color = GetColorColorsWhite.Create;

		public override string Title => $"Set {m_Set} = {m_Color}";

		protected override Task Run(Args args)
		{
			Color value = m_Color.Get(args);
			m_Set.Set(value, args);
			return Instruction.DefaultResult;
		}
	}
}

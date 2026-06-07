using System;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Set", "Where the resulting Color value is set")]
	[Keywords(new string[] { "Shade", "Tint", "Hue", "Colour", "Color", "Paint", "Tone" })]
	public abstract class TInstructionShading : Instruction
	{
		[SerializeField]
		protected PropertySetColor m_Set = SetColorGlobalName.Create;
	}
}

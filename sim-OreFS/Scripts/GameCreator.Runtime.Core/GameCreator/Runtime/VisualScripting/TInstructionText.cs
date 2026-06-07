using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Set", "Where the resulting value is set")]
	[Keywords(new string[] { "String", "Text", "Character" })]
	public abstract class TInstructionText : Instruction
	{
		[SerializeField]
		protected PropertySetString m_Set = SetStringNone.Create;
	}
}

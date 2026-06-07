using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.Events;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Invoke Method")]
	[Description("Invokes a method from any script attached to a game object")]
	[Category("Visual Scripting/Invoke Method")]
	[Parameter("Method", "The method/function that is called on a game object reference")]
	[Keywords(new string[] { "Execute", "Call", "Invoke", "Function" })]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	public class InstructionLogicCallMethod : Instruction
	{
		[SerializeField]
		private UnityEvent m_Method;

		public override string Title => "Invoke Methods";

		protected override Task Run(Args args)
		{
			m_Method.Invoke();
			return Instruction.DefaultResult;
		}
	}
}

using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Clear List")]
	[Description("Removes all elements of a given Local or Global List Variables")]
	[Image(typeof(IconClear), ColorTheme.Type.Teal)]
	[Category("Variables/Clear List")]
	[Parameter("List Variable", "Local List or Global List which elements are removed")]
	[Keywords(new string[] { "Clean", "Remove", "Delete", "Destroy", "Size", "Array", "List", "Variables" })]
	public class InstructionVariablesClear : Instruction
	{
		[SerializeField]
		private CollectorListVariable m_ListVariable = new CollectorListVariable();

		public override string Title => $"Clear {m_ListVariable}";

		protected override Task Run(Args args)
		{
			m_ListVariable.Clear(args);
			return Instruction.DefaultResult;
		}
	}
}

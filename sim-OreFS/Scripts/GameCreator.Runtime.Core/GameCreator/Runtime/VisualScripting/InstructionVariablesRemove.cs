using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Remove from List")]
	[Description("Deletes an element from a given Local or Global List Variables")]
	[Image(typeof(IconTrashOutline), ColorTheme.Type.Teal)]
	[Category("Variables/Remove from List")]
	[Parameter("List Variable", "Local List or Global List which elements are removed")]
	[Keywords(new string[] { "Delete", "Destroy", "Size", "Array", "List", "Variables" })]
	public class InstructionVariablesRemove : Instruction
	{
		[SerializeField]
		private CollectorListVariable m_ListVariable = new CollectorListVariable();

		[SerializeReference]
		private TListGetPick m_Select = new GetPickFirst();

		public override string Title => $"Remove {m_ListVariable}[{m_Select}]";

		protected override Task Run(Args args)
		{
			m_ListVariable.Remove(m_Select, args);
			return Instruction.DefaultResult;
		}
	}
}

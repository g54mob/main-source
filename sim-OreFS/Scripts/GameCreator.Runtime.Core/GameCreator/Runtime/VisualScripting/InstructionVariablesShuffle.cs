using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Shuffle List")]
	[Description("Randomly shuffles the position of each element on a List Variable")]
	[Image(typeof(IconShuffle), ColorTheme.Type.Teal)]
	[Category("Variables/Shuffle List")]
	[Parameter("List Variable", "Local List or Global List which elements are shuffled")]
	[Keywords(new string[] { "Randomize", "Sort", "Array", "List", "Variables" })]
	public class InstructionVariablesShuffle : Instruction
	{
		[SerializeField]
		private CollectorListVariable m_ListVariable = new CollectorListVariable();

		public override string Title => $"Shuffle {m_ListVariable}";

		protected override Task Run(Args args)
		{
			List<object> list = m_ListVariable.Get(args);
			list.Shuffle();
			m_ListVariable.Fill(list.ToArray(), args);
			return Instruction.DefaultResult;
		}
	}
}

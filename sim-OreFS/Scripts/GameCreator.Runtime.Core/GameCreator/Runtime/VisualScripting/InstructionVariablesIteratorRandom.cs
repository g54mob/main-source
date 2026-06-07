using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Iterator Random")]
	[Description("Sets a random value between zero and the list count")]
	[Category("Variables/Iterator Random")]
	[Parameter("Index", "The numeric value used as an index")]
	[Parameter("List Variables", "The List Variable targeted")]
	[Keywords(new string[] { "Iterate", "Index", "For", "Loop", "Access" })]
	[Image(typeof(IconListIndex), ColorTheme.Type.Teal, typeof(OverlayDice))]
	public class InstructionVariablesIteratorRandom : Instruction
	{
		[SerializeField]
		private PropertySetNumber m_Index = SetNumberGlobalName.Create;

		[SerializeField]
		private CollectorListVariable m_ListVariable = new CollectorListVariable();

		public override string Title => $"Random {m_Index} Index for {m_ListVariable}";

		protected override Task Run(Args args)
		{
			List<object> list = m_ListVariable.Get(args);
			if (list == null)
			{
				return Instruction.DefaultResult;
			}
			int num = UnityEngine.Random.Range(0, list.Count);
			m_Index.Set(num, args);
			return Instruction.DefaultResult;
		}
	}
}

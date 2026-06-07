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
	[Title("Iterator Previous")]
	[Description("Decreases in one unit the value used as an iterator for a List Variable")]
	[Category("Variables/Iterator Previous")]
	[Parameter("Index", "The numeric value used as an index")]
	[Parameter("List Variables", "The List Variable targeted")]
	[Parameter("Mode", "Whether the index loops back to the last index or is clamped at zero")]
	[Keywords(new string[] { "Iterate", "Index", "For", "Loop", "Access" })]
	[Image(typeof(IconListIndex), ColorTheme.Type.Teal, typeof(OverlayArrowLeft))]
	public class InstructionVariablesIteratorPrevious : Instruction
	{
		private enum Mode
		{
			Circular = 0,
			Clamp = 1
		}

		[SerializeField]
		private PropertySetNumber m_Index = SetNumberGlobalName.Create;

		[SerializeField]
		private CollectorListVariable m_ListVariable = new CollectorListVariable();

		[SerializeField]
		private Mode m_Mode;

		public override string Title => $"Previous {m_Index} Index for {m_ListVariable}";

		protected override Task Run(Args args)
		{
			List<object> list = m_ListVariable.Get(args);
			if (list == null)
			{
				return Instruction.DefaultResult;
			}
			int num = (int)m_Index.Get(args) - 1;
			switch (m_Mode)
			{
			case Mode.Circular:
				if (num < 0)
				{
					num = list.Count - 1;
				}
				break;
			case Mode.Clamp:
				num = Math.Clamp(num, 0, list.Count - 1);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			m_Index.Set(num, args);
			return Instruction.DefaultResult;
		}
	}
}

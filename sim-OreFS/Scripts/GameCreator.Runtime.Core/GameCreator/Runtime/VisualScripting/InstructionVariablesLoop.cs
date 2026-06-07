using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Loop List")]
	[Description("Loops a Game Object List Variables and executes an Actions component for each value")]
	[Image(typeof(IconInstructions), ColorTheme.Type.Blue, typeof(OverlayListVariable))]
	[Category("Variables/Loop List")]
	[Parameter("List Variable", "Local List or Global List which elements are iterated")]
	[Parameter("Actions", "The Actions component executed for each element in the list. The Target argument of any Instruction contains the object inspected")]
	[Keywords(new string[] { "Iterate", "Cycle", "Every", "All", "Stack" })]
	public class InstructionVariablesLoop : Instruction
	{
		[SerializeField]
		private CollectorListVariable m_ListVariable = new CollectorListVariable();

		[SerializeField]
		private PropertyGetGameObject m_Actions = GetGameObjectActions.Create();

		public override string Title => $"Loop {m_ListVariable}";

		protected override async Task Run(Args args)
		{
			Args actionsArgs = new Args(args.Self, null);
			List<object> source = m_ListVariable.Get(args);
			Actions actions = m_Actions.Get<Actions>(args);
			if (actions == null)
			{
				return;
			}
			int i = 0;
			while (i < source.Count)
			{
				GameObject gameObject = source[i] as GameObject;
				if (gameObject != null)
				{
					actionsArgs.ChangeTarget(gameObject);
				}
				await actions.Run(actionsArgs);
				int num = i + 1;
				i = num;
			}
		}
	}
}

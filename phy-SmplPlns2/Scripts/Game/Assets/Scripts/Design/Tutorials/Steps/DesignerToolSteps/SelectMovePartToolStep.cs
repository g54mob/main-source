using Assets.Scripts.Design.Tools;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps.DesignerToolSteps
{
	public class SelectMovePartToolStep : SelectDesignerToolStep<MovePartTool>
	{
		public SelectMovePartToolStep(TutorialStepBuilderContext context, string stepText = null)
			: base(context, context.Designer.Designer.Tools.MovePartTool, stepText)
		{
		}

		protected override void OnSelectDesignerToolStepUpdate()
		{
			if (HighlightUIElement("btn-move-tool", new Vector2(15f, 15f)))
			{
				base.InstructionText = "[Click:] the indicated button to activate the move part tool.";
			}
			else if (HighlightUIElement("btn-selected-tool", new Vector2(15f, 15f)))
			{
				base.InstructionText = "[Click:] the indicated button to open the tool list.";
			}
		}
	}
}

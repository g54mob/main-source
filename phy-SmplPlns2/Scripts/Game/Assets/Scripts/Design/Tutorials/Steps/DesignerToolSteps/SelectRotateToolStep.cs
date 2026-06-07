using Assets.Scripts.Design.Tools;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps.DesignerToolSteps
{
	public class SelectRotateToolStep : SelectDesignerToolStep<RotateTool>
	{
		public SelectRotateToolStep(TutorialStepBuilderContext context, string stepText = null)
			: base(context, context.Designer.Designer.Tools.RotateTool, stepText)
		{
		}

		protected override void OnSelectDesignerToolStepUpdate()
		{
			if (HighlightUIElement("btn-rotate-tool", new Vector2(15f, 15f)))
			{
				base.InstructionText = "[Click:] the indicated button to activate the rotate tool.";
			}
			else if (HighlightUIElement("btn-selected-tool", new Vector2(15f, 15f)))
			{
				base.InstructionText = "[Click:] the indicated button to open the tool list.";
			}
		}
	}
}

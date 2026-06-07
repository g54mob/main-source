using Assets.Scripts.Design.Tools;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps.DesignerToolSteps
{
	public class SelectViewToolStep : SelectDesignerToolStep<ViewTool>
	{
		public SelectViewToolStep(TutorialStepBuilderContext context, string stepText = null)
			: base(context, context.Designer.Designer.Tools.ViewTool, stepText)
		{
		}

		protected override void OnSelectDesignerToolStepUpdate()
		{
			if (HighlightUIElement("btn-view-tool", new Vector2(15f, 15f)))
			{
				base.InstructionText = "[Click:] the indicated button to activate the view tool.";
			}
			else if (HighlightUIElement("btn-selected-tool", new Vector2(15f, 15f)))
			{
				base.InstructionText = "[Click:] the indicated button to open the tool list.";
			}
		}
	}
}

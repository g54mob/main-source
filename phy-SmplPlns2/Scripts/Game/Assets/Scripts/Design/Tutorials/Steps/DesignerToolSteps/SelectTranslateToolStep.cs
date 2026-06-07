using Assets.Scripts.Design.Tools;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps.DesignerToolSteps
{
	public class SelectTranslateToolStep : SelectDesignerToolStep<TranslateTool>
	{
		public SelectTranslateToolStep(TutorialStepBuilderContext context, string stepText = null)
			: base(context, context.Designer.Designer.Tools.TranslateTool, stepText)
		{
		}

		protected override void OnSelectDesignerToolStepUpdate()
		{
			if (HighlightUIElement("btn-translate-tool", new Vector2(15f, 15f)))
			{
				base.InstructionText = "[Click:] the indicated button to activate the translate tool.";
			}
			else if (HighlightUIElement("btn-selected-tool", new Vector2(15f, 15f)))
			{
				base.InstructionText = "[Click:] the indicated button to open the tool list.";
			}
		}
	}
}

using Assets.Scripts.Design.Tools;

namespace Assets.Scripts.Design.Tutorials.Steps.DesignerToolSteps
{
	public abstract class SelectDesignerToolStep<T> : TutorialStep where T : DesignerTool
	{
		public override bool SkipOnRewind => Tool.IsActive;

		protected T Tool { get; }

		protected SelectDesignerToolStep(TutorialStepBuilderContext context, T tool, string stepText = null)
			: base(context, stepText)
		{
			Tool = tool;
		}

		protected abstract void OnSelectDesignerToolStepUpdate();

		protected override void OnUpdate()
		{
			base.OnUpdate();
			DisableUIHighlight();
			if (Tool.IsActive)
			{
				CompleteStep();
			}
			else
			{
				OnSelectDesignerToolStepUpdate();
			}
		}
	}
}

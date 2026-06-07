using Assets.Scripts.Design.Tutorials.Steps;
using Assets.Scripts.Design.Tutorials.Steps.DesignerToolSteps;

namespace Assets.Scripts.Design.Tutorials.Definitions
{
	public class DesignerBasicsTutorial : Tutorial
	{
		public DesignerBasicsTutorial(TutorialDatabase.TutorialInfo tutorialInfo)
			: base(tutorialInfo)
		{
		}

		protected override void BuildSteps(TutorialStepBuilderContext context)
		{
			context.SetCraftXml("__TutorialProp__");
			context.LoadAllParts();
			context.AddStep(new InfoStep(context, "Welcome to the SimplePlanes 2 Designer! Let's start with some camera basics."));
			context.AddStep(new CameraStep(context));
			context.AddStep(new InfoStep(context, "The designer has many buttons. Don't worry, we'll just hit the highlights."));
			context.AddStep(new InfoStep(context, "Look at the flashing button at the top right. This shows the list of parts you can add to your craft.", "btn-add-parts", showTooltip: true));
			context.AddStep(new InfoStep(context, "This button enables/disables symmetry, which automatically mirrors your work to the other side of the craft. It's really nice and a big time saver.", "btn-designer-symmetry", showTooltip: true));
			context.AddStep(new InfoStep(context, "This button opens the paint panel where you can customize the colors and textures of your craft.", "btn-paint", showTooltip: true));
			context.AddStep(new InfoStep(context, "This button opens the Search Parts panel where you can easily find parts in your craft and toggle their visibility.", "btn-search-parts", showTooltip: true));
			context.AddStep(new InfoStep(context, "Fuselage 2", "Some buttons only appear when a part is selected. Click the indicated part to continue.")).Configure(delegate(InfoStep x)
			{
				x.AdvanceAfterPartSelected = true;
			});
			context.AddStep(new InfoStep(context, "Fuselage 2", "This button opens Part Properties for the selected part. SP2 parts are highly customizable and this is where you dig in.", "button-part-properties", showTooltip: true));
			context.AddStep(new InfoStep(context, "This shows your active tool. Click it to see more tools.", "btn-selected-tool", false)).Configure(delegate(InfoStep x)
			{
				x.AdvanceAfterWidgetClicked = true;
			});
			context.AddStep(new SelectTranslateToolStep(context, "Select the Translate Tool."));
			context.AddStep(new InfoStep(context, "The Translate Tool - moves a part without disturbing its part connections. Handy for fine adjustments."));
			context.AddStep(new SelectRotateToolStep(context, "Select the Rotate Tool."));
			context.AddStep(new InfoStep(context, "The Rotate Tool - for precise part rotation without breaking part connections."));
			context.AddStep(new SelectViewToolStep(context, "Select the View Tool."));
			context.AddStep(new InfoStep(context, "The View Tool - move around and inspect your craft without accidentally grabbing anything."));
			context.AddStep(new SelectMovePartToolStep(context, "Select the Move Tool."));
			context.AddStep(new InfoStep(context, "The Move Tool - your most-used tool by a mile. Click and drag parts to reposition and connect them to your craft."));
			context.AddStep(new InfoStep(context, "Pro tip: You can right-click and drag a part to clone it. It's a big time saver!"));
			context.AddStep(new CompleteTutorialStep(context, "That's it for the designer basics! We recommend trying the Build Your First Plane tutorial next."));
		}
	}
}

using System;
using Assets.Scripts.Craft.Parts.Fuselage;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Design.UI.PartProperties;
using Assets.Scripts.UI;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps.FuselageSteps
{
	public abstract class FuselageShapeStep : TutorialStep
	{
		protected enum FuselageModificationType
		{
			Corners = 0,
			Edges = 1,
			Cutting = 2,
			Properties = 3
		}

		public JFuselageGizmoController.FuselageGizmoID HighlightedGizmo { get; protected set; }

		public bool HighlightGoalFuselage { get; private set; }

		protected IFlyout Flyout { get; private set; }

		protected JFuselageData FuselageData { get; private set; }

		protected JFuselageData GoalFuselage { get; private set; }

		protected FuselageModificationType? ModificationType { get; }

		protected Widget ModTypeButtonWidget { get; private set; }

		protected Widget ModTypeWidget { get; private set; }

		protected FuselageSectionType SectionType { get; }

		protected JFuselageTool Tool { get; private set; }

		protected FuselageShapeStep(TutorialStepBuilderContext context, int partId, FuselageSectionType sectionType, FuselageModificationType? modificationType, bool highlightGoalFuselage, string stepText = null)
			: base(context, partId, stepText)
		{
			SectionType = sectionType;
			ModificationType = modificationType;
			HighlightGoalFuselage = highlightGoalFuselage;
		}

		protected FuselageShapeStep(TutorialStepBuilderContext context, string partName, FuselageSectionType sectionType, FuselageModificationType? modificationType, bool highlightGoalFuselage, string stepText = null)
			: this(context, context.GetPartIdByName(partName), sectionType, modificationType, highlightGoalFuselage, stepText)
		{
		}

		protected virtual SectionParams GetSectionParams(JFuselageData fuselage, FuselageEndType endType)
		{
			if (endType != FuselageEndType.Front)
			{
				return fuselage.SectionA;
			}
			return fuselage.SectionB;
		}

		protected abstract bool IsFuselageChangeComplete();

		protected abstract void OnFuselageStepUpdate();

		protected override void OnStart()
		{
			Flyout = base.Designer.DesignerUI.Flyouts.JFuselageShape;
			Tool = base.Designer.Designer.Tools.JFuselageTool;
			FuselageData = base.TargetPart.GetModifier<JFuselageData>();
			switch (ModificationType)
			{
			case FuselageModificationType.Corners:
				ModTypeWidget = Flyout.Widget.FindWidget("tab-0");
				ModTypeButtonWidget = Flyout.Widget.FindWidget("tab-btn-0");
				break;
			case FuselageModificationType.Edges:
				ModTypeWidget = Flyout.Widget.FindWidget("tab-1");
				ModTypeButtonWidget = Flyout.Widget.FindWidget("tab-btn-1");
				break;
			case FuselageModificationType.Cutting:
				ModTypeWidget = Flyout.Widget.FindWidget("tab-2");
				ModTypeButtonWidget = Flyout.Widget.FindWidget("tab-btn-2");
				break;
			case FuselageModificationType.Properties:
				ModTypeWidget = Flyout.Widget.FindWidget("tab-3");
				ModTypeButtonWidget = Flyout.Widget.FindWidget("tab-btn-3");
				break;
			default:
				ModTypeWidget = null;
				ModTypeButtonWidget = null;
				break;
			}
		}

		protected override void OnStartBeforePartChanges()
		{
			base.OnStartBeforePartChanges();
			GoalFuselage = ConfigurePartForNonInteractableHighlight(base.TargetPart, duplicatePart: true)?.GetModifier<JFuselageData>();
			if (GoalFuselage == null)
			{
				throw new Exception("The target goal fuselage for this tutorial step could not be found.");
			}
		}

		protected override void OnUpdate()
		{
			base.OnUpdate();
			DisableUIHighlight();
			HighlightedGizmo = JFuselageGizmoController.FuselageGizmoID.None;
			ClearHighlightedPart(base.TargetPart);
			if (HighlightGoalFuselage)
			{
				HighlightPart(GoalFuselage.Part);
			}
			SelectionTarget? currentTarget = Tool.CurrentTarget;
			if (FuselageData?.Part?.PartScript == null)
			{
				base.InstructionText = "The fuselage to be modified cannot be found. Please restart this tutorial step.";
				return;
			}
			if (IsFuselageChangeComplete())
			{
				CompleteStep();
			}
			else if (base.Designer.Designer.SelectedPart?.Part != base.TargetPart)
			{
				base.InstructionText = "Select the indicated fuselage part.";
				HighlightPart(base.TargetPart);
				ClearHighlightedPart(GoalFuselage.Part);
			}
			else if (!Tool.IsActive || !Flyout.IsOpen)
			{
				base.InstructionText = "Open the fuselage shape tool. This can be done by double [clicking:] the part or it can be accessed via its part properties.";
				GenericPartPropertiesScript propertiesByType = PartPropertiesPanelScript.GetPropertiesByType<JFuselageData>();
				IConfigurableProperty configurableProperty = propertiesByType?.GetProperty("_editButton");
				if (!base.Designer.DesignerUI.Flyouts.PartProperties.IsOpen)
				{
					HighlightUIElement("button-part-properties", new Vector2(5f, 5f));
				}
				else if (propertiesByType.Header.Collapsed)
				{
					HighlightUIElement(propertiesByType.Header.Widget, new Vector2(20f, 20f), highlightEvenIfInactive: false);
				}
				else
				{
					HighlightUIElement(configurableProperty.RootWidget, new Vector2(20f, 20f), highlightEvenIfInactive: false);
				}
			}
			else if (!currentTarget.HasValue || currentTarget.Value.Fuselage != FuselageData)
			{
				base.InstructionText = "Select the indicated fuselage part.";
			}
			else if (SectionType == FuselageSectionType.Middle && Tool.Section == null)
			{
				if (currentTarget.Value.IsSlice && Tool.IdentifyNavigation(currentTarget.Value, forwards: true)?.Fuselage == FuselageData)
				{
					base.InstructionText = "Select the main section of the fuselage by [clicking:] the 'Forwards' button. Alternatively, you can [click:] on the middle of the part directly.";
					HighlightUIElement(Flyout.Widget, "next-btn", new Vector2(15f, 15f));
				}
				else if (currentTarget.Value.IsSlice && Tool.IdentifyNavigation(currentTarget.Value, forwards: false)?.Fuselage == FuselageData)
				{
					base.InstructionText = "Select the main section of the fuselage by [clicking:] the 'Backwards' button. Alternatively, you can [click:] on the middle of the part directly.";
					HighlightUIElement(Flyout.Widget, "prev-btn", new Vector2(15f, 15f));
				}
				else
				{
					base.InstructionText = "An error occurred with the tutorial. Select the main section of the fuselage to continue.";
				}
			}
			else if (SectionType != FuselageSectionType.Middle && Tool.Slice?.PrimarySliceIndex != (int?)SectionType)
			{
				SelectionTarget? selectionTarget = Tool.IdentifyNavigation(currentTarget.Value, forwards: true);
				SelectionTarget? selectionTarget2 = (selectionTarget.HasValue ? Tool.IdentifyNavigation(selectionTarget.Value, forwards: true) : ((SelectionTarget?)null));
				SelectionTarget? selectionTarget3 = Tool.IdentifyNavigation(currentTarget.Value, forwards: false);
				SelectionTarget? selectionTarget4 = (selectionTarget3.HasValue ? Tool.IdentifyNavigation(selectionTarget3.Value, forwards: false) : ((SelectionTarget?)null));
				if ((selectionTarget.HasValue && selectionTarget.Value.IsSlice && selectionTarget.Value.Fuselage == FuselageData && selectionTarget.Value.Index == (int)SectionType) || (selectionTarget2.HasValue && selectionTarget2.Value.IsSlice && selectionTarget2.Value.Fuselage == FuselageData && selectionTarget2.Value.Index == (int)SectionType))
				{
					base.InstructionText = "Select the front of the fuselage by [clicking:] the 'Forwards' button. Alternatively, you can [click:] on the front of the part directly.";
					HighlightUIElement(Flyout.Widget, "next-btn", new Vector2(15f, 15f));
				}
				else if ((selectionTarget3.HasValue && selectionTarget3.Value.IsSlice && selectionTarget3.Value.Fuselage == FuselageData && selectionTarget3.Value.Index == (int)SectionType) || (selectionTarget4.HasValue && selectionTarget4.Value.IsSlice && selectionTarget4.Value.Fuselage == FuselageData && selectionTarget4.Value.Index == (int)SectionType))
				{
					base.InstructionText = "Select the back of the fuselage by [clicking:] the 'Backwards' button. Alternatively, you can [click:] on the back of the part directly.";
					HighlightUIElement(Flyout.Widget, "prev-btn", new Vector2(15f, 15f));
				}
				else
				{
					base.InstructionText = "An error occurred with the tutorial. Select the " + ((SectionType == FuselageSectionType.Back) ? "back" : "front") + " of the fuselage to continue.";
				}
			}
			else if (ModificationType.HasValue && !ModTypeWidget.Visible)
			{
				switch (ModificationType)
				{
				case FuselageModificationType.Corners:
					base.InstructionText = "Select the 'Corners' tab to modify the corner properties of the fuselage.";
					break;
				case FuselageModificationType.Edges:
					base.InstructionText = "Select the 'Edges' tab to modify the edge properties of the fuselage.";
					break;
				case FuselageModificationType.Cutting:
					base.InstructionText = "Select the 'Cutting' tab to modify the cutting properties of the fuselage.";
					break;
				case FuselageModificationType.Properties:
					base.InstructionText = "Select the 'Properties' tab to modify the general properties of the fuselage.";
					break;
				}
				HighlightUIElement(ModTypeButtonWidget, new Vector2(15f, 15f), highlightEvenIfInactive: false);
			}
			else
			{
				OnFuselageStepUpdate();
			}
			if (Tool?.GizmoController != null)
			{
				Tool.GizmoController.EnableTutorialHighlight(HighlightedGizmo);
			}
		}
	}
}

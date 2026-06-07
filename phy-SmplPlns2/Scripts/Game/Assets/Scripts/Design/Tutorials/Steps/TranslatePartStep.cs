using System;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Design.Tutorials.Steps.PartChanges;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps
{
	public class TranslatePartStep : TutorialStep
	{
		private Widget _toolWidget;

		public float PositionTolerance { get; set; } = 0.075f;

		public bool UseConnectedMode { get; }

		public bool UseLocalSpace { get; }

		protected PartData GoalPart { get; private set; }

		protected Vector3 RequiredTranslation { get; private set; }

		protected TranslateTool Tool { get; private set; }

		public TranslatePartStep(TutorialStepBuilderContext context, int partId, Vector3 translation, bool useConnectedMode, bool useLocalSpace, string stepText = null)
			: base(context, partId, stepText)
		{
			RequiredTranslation = translation;
			UseConnectedMode = useConnectedMode;
			UseLocalSpace = useLocalSpace;
			base.AppliedPartChanges.Add(new PartPositionRelativeChange(partId, translation, useLocalSpace));
			_toolWidget = base.Designer.DesignerUI.RootWidget.FindWidget("tool-panel-translate");
		}

		public TranslatePartStep(TutorialStepBuilderContext context, string partName, Vector3 translation, bool useConnectedMode, bool useLocalSpace, string stepText = null)
			: this(context, context.GetPartIdByName(partName), translation, useConnectedMode, useLocalSpace, stepText)
		{
		}

		protected override void OnStart()
		{
			base.OnStart();
			Tool = base.Designer.Designer.Tools.TranslateTool;
		}

		protected override void OnStartBeforePartChanges()
		{
			base.OnStartBeforePartChanges();
			GoalPart = ConfigurePartForNonInteractableHighlight(base.TargetPart, duplicatePart: true);
			if (GoalPart == null)
			{
				throw new Exception("The target goal part for this tutorial step could not be found.");
			}
		}

		protected override void OnUpdate()
		{
			base.OnUpdate();
			DisableUIHighlight();
			ClearHighlightedPart(base.TargetPart);
			HighlightPart(GoalPart);
			if (base.TargetPart?.PartScript == null)
			{
				base.InstructionText = "The part to be moved cannot be found. Please restart this tutorial step.";
			}
			else if (GoalPart?.PartScript == null)
			{
				base.InstructionText = "The highlighted goal part cannot be found. Please restart this tutorial step.";
			}
			else if (Utilities.CompareVector3s(base.TargetPart.PartScript.transform.position, GoalPart.PartScript.transform.position, PositionTolerance))
			{
				CompleteStep();
			}
			else if (base.Designer.Designer.SelectedPart?.Part != base.TargetPart)
			{
				base.InstructionText = "Select the indicated part.";
				HighlightPart(base.TargetPart);
				ClearHighlightedPart(GoalPart);
			}
			else if (!Tool.IsActive)
			{
				if (HighlightUIElement("btn-translate-tool", new Vector2(15f, 15f)))
				{
					base.InstructionText = "[Click:] the indicated button to activate the translate tool.";
				}
				else if (HighlightUIElement("btn-selected-tool", new Vector2(15f, 15f)))
				{
					base.InstructionText = "We need to activate the translate tool. [Click:] the indicated button to open the tool list.";
				}
			}
			else if (UseConnectedMode != Tool.InConnectedMode)
			{
				HighlightUIElement(_toolWidget, "selection-spinner", new Vector2(15f, 15f));
				if (UseConnectedMode)
				{
					base.InstructionText = "We want to move all connected parts. [Click:] the indicated button to enable connected mode.";
				}
				else
				{
					base.InstructionText = "We want to move only this part. [Click:] the indicated button to disable connected mode.";
				}
			}
			else if (UseLocalSpace != Tool.UseLocalSpace)
			{
				HighlightUIElement(_toolWidget, "space-spinner", new Vector2(15f, 15f));
				if (UseLocalSpace)
				{
					base.InstructionText = "We want to move the part along its local axes. [Click:] the indicated button to switch to local space.";
				}
				else
				{
					base.InstructionText = "We want to move the part along the global axes. [Click:] the indicated button to switch to world space.";
				}
			}
			else
			{
				base.InstructionText = "Use the translation tool gizmos to move the part so that it matches the indicated position.";
			}
		}
	}
}

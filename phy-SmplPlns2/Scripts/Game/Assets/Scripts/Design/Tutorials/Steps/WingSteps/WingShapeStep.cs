using System;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Wings;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Design.Tutorials.Steps.PartChanges;
using Assets.Scripts.Design.UI.PartProperties;
using Assets.Scripts.UI;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps.WingSteps
{
	public class WingShapeStep : TutorialStep
	{
		protected class WingShapeChange : ITutorialStepPartChange
		{
			public List<(float Position, float Scale, float Offset)> NewValues { get; }

			public int PartId { get; }

			public List<(float Position, float Scale, float Offset)> PreviousValues { get; }

			public WingShapeChange(int partId, List<(float Position, float Scale, float Offset)> previousValues, List<(float Position, float Scale, float Offset)> newValues)
			{
				PartId = partId;
				PreviousValues = previousValues;
				NewValues = newValues;
			}

			public WingShapeChange(int partId, float previousSlice0Position, float previousSlice0Scale, float previousSlice0Offset, float previousSlice1Position, float previousSlice1Scale, float previousSlice1Offset, float newSlice0Position, float newSlice0Scale, float newSlice0Offset, float newSlice1Position, float newSlice1Scale, float newSlice1Offset)
				: this(partId, new List<(float, float, float)>
				{
					(previousSlice0Position, previousSlice0Scale, previousSlice0Offset),
					(previousSlice1Position, previousSlice1Scale, previousSlice1Offset)
				}, new List<(float, float, float)>
				{
					(newSlice0Position, newSlice0Scale, newSlice0Offset),
					(newSlice1Position, newSlice1Scale, newSlice1Offset)
				})
			{
			}

			public void Apply(AircraftData craft)
			{
				SetValues(craft, NewValues);
			}

			public void Revert(AircraftData craft)
			{
				SetValues(craft, PreviousValues);
			}

			private void SetValues(AircraftData craft, List<(float Position, float Scale, float Offset)> values)
			{
				JWingData jWingData = craft.Assembly.GetPartById(PartId)?.GetModifier<JWingData>();
				if (jWingData != null)
				{
					for (int i = 0; i < values.Count; i++)
					{
						(float, float, float) tuple = values[i];
						InputWingSlice inputWingSlice = jWingData.WingSlices[i];
						inputWingSlice.Position = tuple.Item1;
						inputWingSlice.Scale = tuple.Item2;
						inputWingSlice.Offset = tuple.Item3;
					}
					jWingData.UpdateMeshes();
				}
			}
		}

		public float OffsetTolerance { get; set; } = 0.1f;

		public float ScaleTolerance { get; set; } = 0.1f;

		protected IFlyout Flyout { get; private set; }

		protected JWingData GoalWing { get; private set; }

		protected JWingTool Tool { get; private set; }

		protected JWingData WingData { get; private set; }

		public WingShapeStep(TutorialStepBuilderContext context, int partId, float previousSlice0Position, float previousSlice0Scale, float previousSlice0Offset, float previousSlice1Position, float previousSlice1Scale, float previousSlice1Offset, float newSlice0Position, float newSlice0Scale, float newSlice0Offset, float newSlice1Position, float newSlice1Scale, float newSlice1Offset, string stepText = null)
			: base(context, partId, stepText)
		{
			base.AppliedPartChanges.Add(new WingShapeChange(partId, previousSlice0Position, previousSlice0Scale, previousSlice0Offset, previousSlice1Position, previousSlice1Scale, previousSlice1Offset, newSlice0Position, newSlice0Scale, newSlice0Offset, newSlice1Position, newSlice1Scale, newSlice1Offset));
		}

		public WingShapeStep(TutorialStepBuilderContext context, string partName, float previousSlice0Position, float previousSlice0Scale, float previousSlice0Offset, float previousSlice1Position, float previousSlice1Scale, float previousSlice1Offset, float newSlice0Position, float newSlice0Scale, float newSlice0Offset, float newSlice1Position, float newSlice1Scale, float newSlice1Offset, string stepText = null)
			: this(context, context.GetPartIdByName(partName), previousSlice0Position, previousSlice0Scale, previousSlice0Offset, previousSlice1Position, previousSlice1Scale, previousSlice1Offset, newSlice0Position, newSlice0Scale, newSlice0Offset, newSlice1Position, newSlice1Scale, newSlice1Offset, stepText)
		{
		}

		protected bool IsWingChangeComplete()
		{
			if (WingData?.Part.PartScript == null || GoalWing?.Part.PartScript == null)
			{
				return false;
			}
			for (int i = 0; i < GoalWing.WingSlices.Count; i++)
			{
				bool num = Utilities.CompareFloats(WingData.WingSlices[i].Scale, GoalWing.WingSlices[i].Scale, ScaleTolerance);
				bool flag = Utilities.CompareFloats(WingData.WingSlices[i].Offset, GoalWing.WingSlices[i].Offset, OffsetTolerance);
				if (!num || !flag)
				{
					return false;
				}
			}
			return true;
		}

		protected override void OnStart()
		{
			base.OnStart();
			Flyout = base.Designer.DesignerUI.Flyouts.WingEditor;
			Tool = base.Designer.Designer.Tools.JWingTool;
			WingData = base.TargetPart.GetModifier<JWingData>();
		}

		protected override void OnStartBeforePartChanges()
		{
			base.OnStartBeforePartChanges();
			GoalWing = ConfigurePartForNonInteractableHighlight(base.TargetPart, duplicatePart: true)?.GetModifier<JWingData>();
			if (GoalWing == null)
			{
				throw new Exception("The target goal wing for this tutorial step could not be found.");
			}
		}

		protected override void OnUpdate()
		{
			base.OnUpdate();
			DisableUIHighlight();
			ClearHighlightedPart(base.TargetPart);
			HighlightPart(GoalWing.Part);
			if (WingData?.Part?.PartScript == null)
			{
				base.InstructionText = "The wing to be modified cannot be found. Please restart this tutorial step.";
			}
			else if (base.Designer.Designer.SelectedPart?.Part != base.TargetPart)
			{
				base.InstructionText = "Select the indicated wing part.";
				HighlightPart(base.TargetPart);
				ClearHighlightedPart(GoalWing.Part);
			}
			else if (!Tool.IsActive || !Flyout.IsOpen)
			{
				base.InstructionText = "Open the wing shape tool. This can be done by double [clicking:] the part or it can be accessed via its part properties.";
				GenericPartPropertiesScript propertiesByType = PartPropertiesPanelScript.GetPropertiesByType<JWingData>();
				IConfigurableProperty configurableProperty = propertiesByType?.GetProperty("_editShape");
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
			else if (Tool.CurrentWing != WingData)
			{
				base.InstructionText = "Select the indicated wing part.";
			}
			else if (IsWingChangeComplete())
			{
				CompleteStep();
			}
			else
			{
				base.InstructionText = "Use the arrows to adjust the wing's shape to match that of the indicated shape.";
			}
		}
	}
}

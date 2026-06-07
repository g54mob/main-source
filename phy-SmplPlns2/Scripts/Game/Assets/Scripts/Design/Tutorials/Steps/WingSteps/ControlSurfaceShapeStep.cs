using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Design.Tutorials.Steps.PartChanges;
using Assets.Scripts.Design.UI.PartProperties;
using Assets.Scripts.UI;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps.WingSteps
{
	public class ControlSurfaceShapeStep : TutorialStep
	{
		protected class ControlSurfaceShapeChange : ITutorialStepPartChange
		{
			public Vector2 NewRange { get; }

			public Vector2 NewStartPosition { get; }

			public int PartId { get; }

			public Vector2 PreviousRange { get; }

			public Vector2 PreviousStartPosition { get; }

			public ControlSurfaceShapeChange(int partId, Vector2 previousRange, Vector2 previousStartPosition, Vector2 newRange, Vector2 newStartPosition)
			{
				PartId = partId;
				PreviousRange = previousRange;
				PreviousStartPosition = previousStartPosition;
				NewRange = newRange;
				NewStartPosition = newStartPosition;
			}

			public void Apply(AircraftData craft)
			{
				SetValues(craft, NewRange, NewStartPosition);
			}

			public void Revert(AircraftData craft)
			{
				SetValues(craft, PreviousRange, PreviousStartPosition);
			}

			private void SetValues(AircraftData craft, Vector2 range, Vector2 startPosition)
			{
				ControlSurfacePartData controlSurfacePartData = craft.Assembly.GetPartById(PartId)?.GetModifier<ControlSurfacePartData>();
				if (controlSurfacePartData != null)
				{
					if (!(controlSurfacePartData.ControlSurface is EdgeSurfaceBase edgeSurfaceBase))
					{
						Debug.LogError(string.Format("A control surface of type {0} could not be found on part '{1}'", "EdgeSurfaceBase", PartId));
						return;
					}
					edgeSurfaceBase.Range = range;
					edgeSurfaceBase.StartPos = startPosition;
					controlSurfacePartData.UpdateMeshes();
				}
			}
		}

		public float RangeTolerance { get; set; } = 0.1f;

		public float StartPositionTolerance { get; set; } = 0.1f;

		protected ControlSurfacePartData ControlSurfaceData { get; private set; }

		protected IFlyout Flyout { get; private set; }

		protected ControlSurfacePartData GoalControlSurface { get; private set; }

		protected JWingTool Tool { get; private set; }

		public ControlSurfaceShapeStep(TutorialStepBuilderContext context, int partId, float previousRangeX, float previousRangeY, float previousStartPositionX, float previousStartPositionY, float newRangeX, float newRangeY, float newStartPositionX, float newStartPositionY, string stepText = null)
			: base(context, partId, stepText)
		{
			base.AppliedPartChanges.Add(new ControlSurfaceShapeChange(partId, new Vector2(previousRangeX, previousRangeY), new Vector2(previousStartPositionX, previousStartPositionY), new Vector2(newRangeX, newRangeY), new Vector2(newStartPositionX, newStartPositionY)));
		}

		public ControlSurfaceShapeStep(TutorialStepBuilderContext context, string partName, float previousRangeX, float previousRangeY, float previousStartPositionX, float previousStartPositionY, float newRangeX, float newRangeY, float newStartPositionX, float newStartPositionY, string stepText = null)
			: this(context, context.GetPartIdByName(partName), previousRangeX, previousRangeY, previousStartPositionX, previousStartPositionY, newRangeX, newRangeY, newStartPositionX, newStartPositionY, stepText)
		{
		}

		protected bool IsControlSurfaceChangeComplete()
		{
			if (ControlSurfaceData?.Part.PartScript == null || GoalControlSurface?.Part.PartScript == null)
			{
				return false;
			}
			if (!(ControlSurfaceData.ControlSurface is EdgeSurfaceBase edgeSurfaceBase))
			{
				Debug.LogError(string.Format("A control surface of type {0} could not be found on part '{1}'", "EdgeSurfaceBase", ControlSurfaceData.Part.Id));
				return false;
			}
			if (!(GoalControlSurface.ControlSurface is EdgeSurfaceBase edgeSurfaceBase2))
			{
				Debug.LogError(string.Format("A control surface of type {0} could not be found on part '{1}'", "EdgeSurfaceBase", GoalControlSurface.Part.Id));
				return false;
			}
			bool flag = Utilities.CompareVector2s(edgeSurfaceBase.Range, edgeSurfaceBase2.Range, RangeTolerance);
			bool flag2 = Utilities.CompareVector2s(edgeSurfaceBase.StartPos, edgeSurfaceBase2.StartPos, StartPositionTolerance);
			return flag && flag2;
		}

		protected override void OnStart()
		{
			base.OnStart();
			Flyout = base.Designer.DesignerUI.Flyouts.WingEditor;
			Tool = base.Designer.Designer.Tools.JWingTool;
			ControlSurfaceData = base.TargetPart.GetModifier<ControlSurfacePartData>();
		}

		protected override void OnStartBeforePartChanges()
		{
			base.OnStartBeforePartChanges();
			GoalControlSurface = ConfigurePartForNonInteractableHighlight(base.TargetPart, duplicatePart: true)?.GetModifier<ControlSurfacePartData>();
			if (GoalControlSurface == null)
			{
				throw new Exception("The target goal control surface for this tutorial step could not be found.");
			}
		}

		protected override void OnUpdate()
		{
			base.OnUpdate();
			DisableUIHighlight();
			ClearHighlightedPart(base.TargetPart);
			PartData part = GoalControlSurface.Part;
			bool? useZTest = false;
			HighlightPart(part, null, null, useZTest);
			if (ControlSurfaceData?.Part?.PartScript == null)
			{
				base.InstructionText = "The control surface to be modified cannot be found. Please restart this tutorial step.";
			}
			else if (base.Designer.Designer.SelectedPart?.Part != base.TargetPart)
			{
				base.InstructionText = "Select the indicated control surface part.";
				PartData targetPart = base.TargetPart;
				useZTest = false;
				HighlightPart(targetPart, null, null, useZTest);
				ClearHighlightedPart(GoalControlSurface.Part);
			}
			else if (!Tool.IsActive || !Flyout.IsOpen)
			{
				base.InstructionText = "Open the wing shape tool. This can be done by double [clicking:] the part or it can be accessed via its part properties.";
				GenericPartPropertiesScript propertiesByType = PartPropertiesPanelScript.GetPropertiesByType<ControlSurfacePartData>();
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
			else if (IsControlSurfaceChangeComplete())
			{
				CompleteStep();
			}
			else
			{
				base.InstructionText = "Use the arrows to adjust the control surface's shape to match that of the indicated shape.";
			}
		}
	}
}

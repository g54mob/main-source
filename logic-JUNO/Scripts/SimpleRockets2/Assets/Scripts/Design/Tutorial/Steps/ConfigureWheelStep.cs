using System;
using Assets.Scripts.Craft.Parts.Modifiers;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class ConfigureWheelStep : TutorialStep
	{
		private bool _complete;

		private ResizableWheelData _designerWheel;

		private bool _error;

		public int PartId { get; private set; }

		public string PartName { get; set; }

		public float TargetGearRatio { get; private set; }

		public float TargetTorque { get; private set; }

		public float TargetWheelAngle { get; private set; }

		public ConfigureWheelStep(int partId, string partName, TutorialScript tutorialScript)
			: base(-1, tutorialScript)
		{
			PartName = partName;
			PartId = partId;
		}

		public override void Start()
		{
			base.Start();
			_error = false;
			_complete = false;
			PartData craftPart = base.TutorialScript.GetCraftPart(PartId);
			ResizableWheelData designerPartModifier = TutorialStep.GetDesignerPartModifier<ResizableWheelData>(base.TutorialScript, PartName);
			ResizableWheelData modifier = craftPart.GetModifier<ResizableWheelData>();
			TargetTorque = modifier.MotorTorque;
			TargetWheelAngle = modifier.TurningAngle;
			TargetGearRatio = modifier.GearRatio;
			modifier.MotorTorque = designerPartModifier.MotorTorque;
			modifier.TurningAngle = designerPartModifier.TurningAngle;
			modifier.BaseGearRatio = designerPartModifier.BaseGearRatio;
			Symmetry.SynchronizePartModifiers(craftPart.PartScript);
		}

		public override void Update()
		{
			IDesignerUi designerUi = base.TutorialScript.DesignerUi;
			if (_error)
			{
				base.TutorialScript.DisableUiHighlight();
				DisplayRetryMessage();
			}
			else if (!_complete)
			{
				PartData craftPart = base.TutorialScript.GetCraftPart(PartId);
				if (craftPart == null)
				{
					_error = true;
				}
				else
				{
					if (!EnsurePartSelected(craftPart, PartName))
					{
						return;
					}
					ResizableWheelData modifier = craftPart.GetModifier<ResizableWheelData>();
					if (designerUi.SelectedFlyout == designerUi.Flyouts.PartProperties)
					{
						if (!Utilities.CompareFloats(modifier.TurningAngle, TargetWheelAngle))
						{
							base.TutorialScript.HighlightUiElement("PartProperties.Turning Angle", new Vector2(16f, 8f));
							DisplayInstruction("Change the Turning Angle to " + Units.GetAngleString(TargetWheelAngle, 0));
						}
						else if (!Utilities.CompareFloats(modifier.MotorTorque, TargetTorque, TargetTorque * 0.05f))
						{
							base.TutorialScript.HighlightUiElement("PartProperties.Torque", new Vector2(16f, 8f));
							float num = modifier.ComputeTorque(TargetTorque) * modifier.GearRatio;
							DisplayInstruction($"Change the Torque to {Math.Round(num, 1)}");
						}
						else if (TargetTorque > 0f && !Utilities.CompareFloats(modifier.GearRatio, TargetGearRatio, TargetGearRatio * 0.05f))
						{
							base.TutorialScript.HighlightUiElement("PartProperties.Gear Ratio", new Vector2(16f, 8f));
							string text = $"Change the Gear Ratio to {Math.Round(TargetGearRatio, 2)}";
							if (TargetGearRatio == 1f)
							{
								text += " to maximize for top speed.";
							}
							DisplayInstruction(text);
						}
						else
						{
							_complete = true;
						}
					}
					else
					{
						base.TutorialScript.HighlightUiElement("ButtonPanel.PartProperties", Vector2.zero);
						DisplayInstruction("Click the Part Properties button on the left.");
					}
				}
			}
			else
			{
				base.TutorialScript.NextStep(playSound: true);
			}
		}
	}
}

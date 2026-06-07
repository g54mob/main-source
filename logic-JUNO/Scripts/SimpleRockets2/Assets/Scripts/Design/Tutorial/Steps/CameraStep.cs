using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Settings;
using ModApi.Settings.Core;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class CameraStep : TutorialStep
	{
		public enum CameraStepType
		{
			Rotate = 0,
			Pan = 1,
			Zoom = 2,
			Focus = 3,
			ResetView = 4
		}

		private DesignerCameraScript _designerCamera;

		private MouseInputSettingsDesigner _mouseInputSettings;

		private Vector2 _pan;

		private Vector2 _rotation;

		private float _zoom;

		public CameraStepType StepType { get; set; }

		public CameraStep(TutorialScript tutorialScript, CameraStepType stepType)
			: base(-1, tutorialScript)
		{
			StepType = stepType;
			_mouseInputSettings = Game.Instance.Settings.Game.MouseInputDesigner;
		}

		public override void End()
		{
			base.End();
			_designerCamera.CameraMoved -= OnCameraMoved;
			_designerCamera.CameraViewDirectionSet -= OnCameraViewDirectionSet;
			_designerCamera.CameraFocusOnPart -= OnCameraFocusOnPart;
		}

		public override void Start()
		{
			base.Start();
			_designerCamera = base.TutorialScript.DesignerScript.DesignerCamera as DesignerCameraScript;
			_designerCamera.CameraMoved += OnCameraMoved;
			_designerCamera.CameraViewDirectionSet += OnCameraViewDirectionSet;
			_designerCamera.CameraFocusOnPart += OnCameraFocusOnPart;
		}

		public override void Update()
		{
			bool flag = !Game.Instance.Device.IsMobileBuild;
			string empty = string.Empty;
			if (StepType == CameraStepType.Rotate)
			{
				float num = (int)(_rotation.magnitude / 250f * 100f);
				if (num < 100f)
				{
					MouseInputSettings.MouseDragOrScrollType mouseInput = GetMouseInput(_mouseInputSettings.RotateCamera, _mouseInputSettings.RotateCameraAlt);
					if (MouseInputIsButton(mouseInput))
					{
						string text = GetMouseInputButtonTextLower(mouseInput) ?? "left";
						DisplayStep(base.StepText + "\n\nRotate the view by [" + text + "-clicking|tapping] on the background and dragging.");
					}
					else
					{
						string text2 = (MouseInputIsHorizontalScroll(mouseInput) ? "side-" : string.Empty);
						DisplayStep(base.StepText + "\n\nRotate the view by [" + text2 + "scrolling the mouse|tapping on the background and dragging].");
					}
					empty = ((!(num < 25f)) ? "That's it, you got it! Keep rotating." : "Go ahead and try.");
					base.TutorialScript.DisplayInstructionText(empty + "\n" + num + "% complete.");
				}
				else
				{
					base.TutorialScript.NextStep(playSound: true);
				}
			}
			else if (StepType == CameraStepType.Pan)
			{
				float num2 = (int)(_pan.magnitude / 40f * 100f);
				if (num2 < 100f)
				{
					if (num2 < 25f)
					{
						if (flag)
						{
							MouseInputSettings.MouseDragOrScrollType mouseInput2 = GetMouseInput(_mouseInputSettings.PanCamera, _mouseInputSettings.PanCameraAlt);
							if (MouseInputIsButton(mouseInput2))
							{
								string text3 = GetMouseInputButtonTextLower(mouseInput2) ?? "right";
								DisplayStep("Move the view around by " + text3.ToUpper() + "-clicking on the background and dragging.");
								empty = "Now try moving the view by " + text3 + "-clicking on the background and dragging.";
							}
							else
							{
								string text4 = (MouseInputIsHorizontalScroll(mouseInput2) ? "side-" : string.Empty);
								DisplayStep("Move the view around by " + text4 + "scrolling the mouse wheel.");
								empty = "Now try moving the view by " + text4 + "scrolling the mouse wheel.";
							}
						}
						else
						{
							DisplayStep("Move the view around with a two-finger drag.");
							empty = "Now try moving the view with a two-finger drag on the background.";
						}
					}
					else
					{
						empty = "That's it, you got it! Keep moving the view.";
					}
					DisplayInstruction(empty + "\n" + num2 + "% complete.");
				}
				else
				{
					base.TutorialScript.NextStep(playSound: true);
				}
			}
			else if (StepType == CameraStepType.Focus)
			{
				DisplayStep("You can double-click on a part to make the camera focus on it.");
				DisplayInstruction("Double click on the Command Pod part.");
			}
			else if (StepType == CameraStepType.Zoom)
			{
				float num3 = (int)(_zoom / 22f * 100f);
				if (num3 < 100f)
				{
					if (num3 < 25f)
					{
						if (flag)
						{
							MouseInputSettings.MouseDragOrScrollType mouseInput3 = GetMouseInput(_mouseInputSettings.ZoomCamera, _mouseInputSettings.ZoomCameraAlt);
							if (MouseInputIsButton(mouseInput3))
							{
								string text5 = (GetMouseInputButtonTextLower(mouseInput3) ?? "?").ToUpper();
								DisplayStep("You can also zoom in and out by holding down the " + text5 + " mouse button and dragging up or down.");
							}
							else if (MouseInputIsHorizontalScroll(mouseInput3))
							{
								DisplayStep("You can also zoom in and out with the mouse wheel's horizontal axis.");
							}
							else
							{
								DisplayStep("You can also zoom in and out with the mouse wheel.");
							}
						}
						else
						{
							DisplayStep("You can also zoom in and out by pinching with two fingers.");
						}
						empty = "Go ahead and try it out.";
					}
					else
					{
						empty = "That's it, you got it! Keep zooming in and out.";
					}
					DisplayInstruction(empty + "\n" + num3 + "% complete.");
				}
				else
				{
					base.TutorialScript.NextStep(playSound: true);
				}
			}
			else if (StepType == CameraStepType.ResetView)
			{
				DisplayStep("Great! Now, let's reset the view back to the front of the rocket.");
				if (base.TutorialScript.HighlightUiElement("ViewOptions.ViewFront", new Vector2(0f, 0f)))
				{
					DisplayInstruction("Now click the View Front button.");
					return;
				}
				base.TutorialScript.HighlightUiElement("ButtonPanel.ViewOptions", Vector2.zero);
				DisplayInstruction("Click the View Options button on the left. It's flashing green.");
			}
		}

		private MouseInputSettings.MouseDragOrScrollType GetMouseInput(EnumSetting<MouseInputSettings.MouseDragOrScrollType> setting, EnumSetting<MouseInputSettings.MouseDragOrScrollType> altSetting)
		{
			MouseInputSettings.MouseDragOrScrollType mouseDragOrScrollType = setting.Value;
			if (mouseDragOrScrollType == MouseInputSettings.MouseDragOrScrollType.None)
			{
				mouseDragOrScrollType = altSetting?.Value ?? MouseInputSettings.MouseDragOrScrollType.None;
			}
			return mouseDragOrScrollType;
		}

		private string GetMouseInputButtonTextLower(MouseInputSettings.MouseDragOrScrollType input)
		{
			switch (input)
			{
			case MouseInputSettings.MouseDragOrScrollType.LeftClickDrag:
			case MouseInputSettings.MouseDragOrScrollType.LeftClickDragInverted:
				return "left";
			case MouseInputSettings.MouseDragOrScrollType.RightClickDrag:
			case MouseInputSettings.MouseDragOrScrollType.RightClickDragInverted:
				return "right";
			case MouseInputSettings.MouseDragOrScrollType.MiddleClickDrag:
			case MouseInputSettings.MouseDragOrScrollType.MiddleClickDragInverted:
				return "middle";
			default:
				return null;
			}
		}

		private bool MouseInputIsButton(MouseInputSettings.MouseDragOrScrollType input)
		{
			switch (input)
			{
			case MouseInputSettings.MouseDragOrScrollType.MouseScrollVertical:
			case MouseInputSettings.MouseDragOrScrollType.MouseScrollHorizontal:
			case MouseInputSettings.MouseDragOrScrollType.MouseScrollVerticalInverted:
			case MouseInputSettings.MouseDragOrScrollType.MouseScrollHorizontalInverted:
				return false;
			default:
				return true;
			}
		}

		private bool MouseInputIsHorizontalScroll(MouseInputSettings.MouseDragOrScrollType input)
		{
			if (input != MouseInputSettings.MouseDragOrScrollType.MouseScrollHorizontal)
			{
				return input == MouseInputSettings.MouseDragOrScrollType.MouseScrollHorizontalInverted;
			}
			return true;
		}

		private void OnCameraFocusOnPart(IPartScript partScript)
		{
			if (StepType == CameraStepType.Focus)
			{
				base.TutorialScript.NextStep(playSound: true);
			}
		}

		private void OnCameraMoved(Vector2 rotation, Vector2 pan, float zoomAmount)
		{
			_rotation += new Vector2(Mathf.Abs(rotation.x), Mathf.Abs(rotation.y));
			_pan += new Vector2(Mathf.Abs(pan.x), Mathf.Abs(pan.y));
			_zoom += Mathf.Abs(zoomAmount);
		}

		private void OnCameraViewDirectionSet(DesignerCameraViewDirection viewDirection)
		{
			if (StepType == CameraStepType.ResetView)
			{
				base.TutorialScript.NextStep(playSound: true);
			}
		}
	}
}

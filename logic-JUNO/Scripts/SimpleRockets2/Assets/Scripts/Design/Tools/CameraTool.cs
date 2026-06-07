using ModApi.Design;
using ModApi.Input.Events;
using ModApi.Settings;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class CameraTool : DesignerToolBase
	{
		private MouseInputSettingsDesigner _mouseInputSettings;

		private bool _pinching;

		public bool CameraIsMoving { get; private set; }

		public bool CanPinch { get; private set; }

		public override bool IsBaseTool => true;

		public CameraTool(DesignerScript designer)
			: base(designer)
		{
			CanPinch = true;
			_mouseInputSettings = Game.Instance.Settings.Game.MouseInputDesigner;
		}

		public override bool HandleClick(ClickEventArgs e)
		{
			bool result = false;
			base.HandleClick(e);
			if (!base.Designer.DisableCameraMovement && !_pinching)
			{
				if (e.InputState == InputState.Begin)
				{
					result = true;
					HideFlyouts(hide: true);
				}
				else if (e.InputState == InputState.Updated)
				{
					CameraIsMoving = true;
				}
				else if (e.InputState == InputState.End)
				{
					if (!CameraIsMoving && _mouseInputSettings.CanFocusCameraOnPart(e.InputButton))
					{
						PartRaycastResult partAtScreenPosition = base.Designer.GetPartAtScreenPosition(e.Position);
						if (partAtScreenPosition.PartScript != null)
						{
							base.Designer.DesignerCamera.FocusOnPart(partAtScreenPosition.PartScript);
						}
					}
					CameraIsMoving = false;
					HideFlyouts(hide: false);
				}
				if (CameraIsMoving)
				{
					bool inverted = false;
					if (e.IsTouchPrimary || _mouseInputSettings.CanRotateCamera(e.InputButton, out inverted))
					{
						float num = 0.25f * (float)((!inverted) ? 1 : (-1));
						base.Designer.DesignerCamera.Rotate(new Vector2((0f - e.DeltaPosition.y) * num, e.DeltaPosition.x * num));
					}
					else if (_mouseInputSettings.CanPanCamera(e.InputButton, out inverted))
					{
						float num2 = 0.025f * (float)((!inverted) ? 1 : (-1));
						base.Designer.DesignerCamera.Move(new Vector2(0f - e.DeltaPosition.x, 0f - e.DeltaPosition.y) * num2);
					}
					else if (_mouseInputSettings.CanZoomCamera(e.InputButton, out inverted))
					{
						float num3 = 1f - e.DeltaPosition.y * 0.005f;
						base.Designer.DesignerCamera.Zoom(num3 * (float)((!inverted) ? 1 : (-1)));
					}
					else if (_mouseInputSettings.CanMoveCameraVertically(e.InputButton, out inverted))
					{
						float num4 = 0.1f * (float)((!inverted) ? 1 : (-1));
						base.Designer.DesignerCamera.MoveUpDown(e.DeltaPosition.y * num4);
					}
				}
			}
			else
			{
				if (base.IsInputCaptured)
				{
					HideFlyouts(hide: false);
				}
				result = false;
			}
			return result;
		}

		public override bool HandlePinch(PinchEventArgs e)
		{
			base.HandlePinch(e);
			if (CanPinch)
			{
				if (e.InputState == InputState.Begin)
				{
					_pinching = true;
				}
				else if (e.InputState == InputState.Updated)
				{
					_pinching = true;
					float zoomPercentage = 0f;
					if (e.Distance > 0f)
					{
						zoomPercentage = (e.Distance - e.DistanceDelta) / e.Distance;
					}
					base.Designer.DesignerCamera.Zoom(zoomPercentage);
					base.Designer.DesignerCamera.Move(-e.MidpointDelta * 0.025f);
				}
				else
				{
					_pinching = false;
				}
			}
			else
			{
				_pinching = false;
			}
			return false;
		}

		public override bool HandleScroll(ScrollEventArgs e)
		{
			base.HandleScroll(e);
			if (e.Delta.x != 0f)
			{
				bool inverted = false;
				if (_mouseInputSettings.CanZoomCamera(InputAxis.ScrollHorizontal, out inverted))
				{
					float num = 1f - e.Delta.x * 0.1f;
					base.Designer.DesignerCamera.Zoom(num * (float)((!inverted) ? 1 : (-1)));
				}
				else if (_mouseInputSettings.CanRotateCamera(InputAxis.ScrollHorizontal, out inverted))
				{
					float num2 = 15f * (float)((!inverted) ? 1 : (-1));
					base.Designer.DesignerCamera.Rotate(new Vector2(0f, e.Delta.x * num2));
				}
				else if (_mouseInputSettings.CanPanCamera(InputAxis.ScrollHorizontal, out inverted))
				{
					float num3 = 1f * (float)(inverted ? 1 : (-1));
					base.Designer.DesignerCamera.Move(new Vector2(0f - e.Delta.x, 0f) * num3);
				}
				else if (_mouseInputSettings.CanMoveCameraVertically(InputAxis.ScrollHorizontal, out inverted))
				{
					float num4 = 1.5f * (float)((!inverted) ? 1 : (-1));
					base.Designer.DesignerCamera.MoveUpDown(e.Delta.x * num4);
				}
			}
			if (e.Delta.y != 0f)
			{
				bool inverted2 = false;
				if (_mouseInputSettings.CanZoomCamera(InputAxis.ScrollVertical, out inverted2))
				{
					float num5 = 1f - e.Delta.y * 0.1f;
					base.Designer.DesignerCamera.Zoom(num5 * (float)((!inverted2) ? 1 : (-1)));
				}
				else if (_mouseInputSettings.CanRotateCamera(InputAxis.ScrollVertical, out inverted2))
				{
					float num6 = 15f * (float)((!inverted2) ? 1 : (-1));
					base.Designer.DesignerCamera.Rotate(new Vector2(0f, e.Delta.y * num6));
				}
				else if (_mouseInputSettings.CanPanCamera(InputAxis.ScrollVertical, out inverted2))
				{
					float num7 = 1f * (float)(inverted2 ? 1 : (-1));
					base.Designer.DesignerCamera.Move(new Vector2(0f, 0f - e.Delta.y) * num7);
				}
				else if (_mouseInputSettings.CanMoveCameraVertically(InputAxis.ScrollVertical, out inverted2))
				{
					float num8 = 1.5f * (float)((!inverted2) ? 1 : (-1));
					base.Designer.DesignerCamera.MoveUpDown(e.Delta.y * num8);
				}
			}
			return false;
		}

		private void HideFlyouts(bool hide)
		{
			IFlyout selectedFlyout = base.Designer.DesignerUi.SelectedFlyout;
			if (selectedFlyout != null)
			{
				selectedFlyout.IsHidden = hide;
			}
		}
	}
}

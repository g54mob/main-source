using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps
{
	public class CameraStep : TutorialStep
	{
		private const float PanTarget = 15f;

		private const float RotationTarget = 150f;

		private const float ZoomTarget = 10f;

		private Vector2 _pan;

		private Vector2 _rotation;

		private bool _sideViewSelected;

		private bool _statePanned;

		private bool _stateRotated;

		private bool _stateZoomed;

		private float _zoom;

		public CameraStep(TutorialStepBuilderContext context)
			: base(context)
		{
		}

		protected override void OnEnd()
		{
			base.OnEnd();
			base.Designer.Designer.CameraController.CameraMoved -= CameraMoved;
			base.Designer.DesignerUI.SideViewButtonClicked -= OnSideViewButtonClicked;
		}

		protected override void OnStart()
		{
			base.OnStart();
			base.Designer.Designer.CameraController.CameraMoved += CameraMoved;
			base.Designer.DesignerUI.SideViewButtonClicked += OnSideViewButtonClicked;
		}

		protected override void OnUpdate()
		{
			base.OnUpdate();
			if (!_stateRotated)
			{
				UpdateRotationPhase();
			}
			else if (!_statePanned)
			{
				UpdatePanPhase();
			}
			else if (!_stateZoomed)
			{
				UpdateZoomPhase();
			}
			else if (!_sideViewSelected)
			{
				UpdateSideViewPhase();
			}
			else
			{
				CompleteStep();
			}
		}

		private void CameraMoved(Vector2 rotation, Vector2 pan, float zoomAmount)
		{
			_rotation += new Vector2(Mathf.Abs(rotation.x), Mathf.Abs(rotation.y));
			_pan += new Vector2(Mathf.Abs(pan.x), Mathf.Abs(pan.y));
			_zoom += Mathf.Abs(zoomAmount);
		}

		private void ClearCameraInput()
		{
			_rotation = Vector2.zero;
			_pan = Vector2.zero;
			_zoom = 0f;
			base.InstructionText = string.Empty;
		}

		private void OnSideViewButtonClicked()
		{
			_sideViewSelected = true;
		}

		private void UpdatePanPhase()
		{
			DisableUIHighlight();
			float num = (int)(_pan.magnitude / 15f * 100f);
			if (num < 100f)
			{
				if (num < 25f)
				{
					base.StepText = "[mobile:You can also pan the view around with a two-finger drag. Go ahead and give it a try.|keyboard:You can also pan the view around by right [click:]ing and dragging. Go ahead and give it a try.]";
				}
				else
				{
					base.StepText = "That's it, you got it! Keep panning.";
				}
				base.InstructionText = $"{num}% complete.";
			}
			else
			{
				_statePanned = true;
				ClearCameraInput();
			}
		}

		private void UpdateRotationPhase()
		{
			DisableUIHighlight();
			float num = (int)(_rotation.magnitude / 150f * 100f);
			if (num < 100f)
			{
				if (num < 25f)
				{
					base.StepText = "You can rotate the view around by [click:]ing and dragging. Go ahead and try, just try not to [click:] on any parts.";
				}
				else
				{
					base.StepText = "That's it, you got it! Keep rotating.";
				}
				base.InstructionText = $"{num}% complete.";
			}
			else
			{
				_stateRotated = true;
				ClearCameraInput();
			}
		}

		private void UpdateSideViewPhase()
		{
			base.InstructionText = string.Empty;
			if (!base.Designer.DesignerUI.IsViewPanelOpen)
			{
				base.StepText = "Let's reset the view now. [Click:] the flashing button in the top right.";
				HighlightUIElement("btn-panel-view", new Vector2(5f, 5f));
			}
			else
			{
				base.StepText = "Now [click:] the Side View button.";
				HighlightUIElement("button-side-view", new Vector2(5f, 5f));
			}
		}

		private void UpdateZoomPhase()
		{
			DisableUIHighlight();
			float num = (int)(_zoom / 10f * 100f);
			if (num < 100f)
			{
				if (num < 25f)
				{
					base.StepText = "[mobile:You can also zoom in and out by pinching with two fingers. Go ahead and try it out.|keyboard:You can also zoom in and out with the mouse wheel. Go ahead and try it out.]";
				}
				else
				{
					base.StepText = "That's it, you got it! Keep zooming in and out.";
				}
				base.InstructionText = $"{num}% complete.";
			}
			else
			{
				_stateZoomed = true;
				_sideViewSelected = false;
				ClearCameraInput();
			}
		}
	}
}

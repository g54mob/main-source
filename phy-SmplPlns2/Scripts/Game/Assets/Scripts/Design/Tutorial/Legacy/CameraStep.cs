using Assets.Scripts.Design.UI;
using Assets.Scripts.Input;
using Jundroo.SocialPlatforms;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Legacy
{
	public class CameraStep : TutorialStep
	{
		private Vector2 _pan;

		private Vector2 _rotation;

		private bool _sideViewSelected;

		private bool _statePanned;

		private bool _stateRotated;

		private bool _stateZoomed;

		private float _zoom;

		public CameraStep(TutorialScript tutorialScript)
			: base(0, tutorialScript)
		{
		}

		public override void End()
		{
			_tutorialScript.DesignerScript.Designer.CameraController.CameraMoved -= CameraMoved;
			_tutorialScript.UIScript.SideViewButtonClicked -= SideViewButtonClicked;
		}

		public override void Skip()
		{
			DesignerUIScript.TutorialCenterViewOnPart(_tutorialScript.DesignerScript.Aircraft.MainCockpit);
		}

		public override void Start()
		{
			_tutorialScript.DesignerScript.Designer.CameraController.CameraMoved += CameraMoved;
			_tutorialScript.UIScript.SideViewButtonClicked += SideViewButtonClicked;
		}

		public override void Update()
		{
			bool flag = SocialExt.IsSteam && (SocialExt.Steam.IsRunningOnSteamDeck() || SocialExt.Steam.IsRunningInBigPicture());
			string text = string.Empty;
			if (!_stateRotated)
			{
				float num = (int)(_rotation.magnitude / 250f * 100f);
				if (num < 100f)
				{
					if (num < 25f)
					{
						if (flag)
						{
							GameInputs instance = GameInputs.Instance;
							string text2 = instance.DesignerCameraRotateLeftRight.GetControllerBindingText() ?? instance.DesignerCameraLeftRight.GetControllerBindingText();
							string text3 = instance.DesignerCameraRotateUpDown.GetControllerBindingText() ?? instance.DesignerCameraUpDown.GetControllerBindingText();
							if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3))
							{
								text = "You can rotate the view around by clicking and dragging or by using " + text2 + " and " + text3 + ". Go ahead and try. Just try not to click on any parts.";
							}
						}
						if (string.IsNullOrWhiteSpace(text))
						{
							text = "You can rotate the view around by clicking and dragging. Go ahead and try. Just try not to click on any parts.";
						}
					}
					else
					{
						text = "That's it, you got it! Keep rotating.";
					}
					_tutorialScript.DisplayMessage(text + "\n" + num + "% complete.");
				}
				else
				{
					_tutorialScript.Accomplishment("Rotated");
					_stateRotated = true;
					_statePanned = true;
					ClearCameraStuff();
				}
			}
			else if (!_statePanned)
			{
				float num2 = (int)(_pan.magnitude / 40f * 100f);
				if (num2 < 100f)
				{
					if (num2 < 25f)
					{
						if (Game.Instance.Device.IsDesktopBuild)
						{
							if (flag)
							{
								GameInputs instance2 = GameInputs.Instance;
								string text4 = instance2.DesignerCameraTranslateLeftRight.GetControllerBindingText() ?? instance2.DesignerCameraLeftRight.GetControllerBindingText();
								string text5 = instance2.DesignerCameraTranslateUpDown.GetControllerBindingText() ?? instance2.DesignerCameraUpDown.GetControllerBindingText();
								if (!string.IsNullOrWhiteSpace(text4) && !string.IsNullOrWhiteSpace(text5))
								{
									text = "You can also pan the view around by right clicking and dragging or by using " + text4 + " and " + text5 + ". Go ahead and give it a try.";
								}
							}
							if (string.IsNullOrWhiteSpace(text))
							{
								text = "You can also pan the view around by right clicking and dragging. Go ahead and give it a try.";
							}
						}
						else
						{
							text = "You can also pan the view around with a two-finger drag. Go ahead and give it a try.";
						}
					}
					else
					{
						text = "That's it, you got it! Keep panning.";
					}
					_tutorialScript.DisplayMessage(text + "\n" + num2 + "% complete.");
				}
				else
				{
					_tutorialScript.Accomplishment("Panned");
					_statePanned = true;
					ClearCameraStuff();
				}
			}
			else if (!_stateZoomed)
			{
				float num3 = (int)(_zoom / 22f * 100f);
				if (num3 < 100f)
				{
					if (num3 < 25f)
					{
						if (Game.Instance.Device.IsDesktopBuild)
						{
							if (flag)
							{
								GameInputs instance3 = GameInputs.Instance;
								string text6 = instance3.DesignerCameraZoom.GetControllerBindingText() ?? instance3.DesignerCameraInOut.GetControllerBindingText();
								if (!string.IsNullOrWhiteSpace(text6))
								{
									text = "You can also zoom in and out with the mouse wheel or by using " + text6 + ". Go ahead and try it out.";
								}
							}
							if (string.IsNullOrWhiteSpace(text))
							{
								text = "You can also zoom in and out with the mouse wheel. Go ahead and try it out.";
							}
						}
						else
						{
							text = "You can also zoom in and out by pinching with two fingers. Go ahead and try it out.";
						}
					}
					else
					{
						text = "That's it, you got it! Keep zooming in and out.";
					}
					_tutorialScript.DisplayMessage(text + "\n" + num3 + "% complete.");
				}
				else
				{
					_tutorialScript.Accomplishment("Zoomed");
					_stateZoomed = true;
					ClearCameraStuff();
					_sideViewSelected = false;
				}
			}
			else if (!_sideViewSelected)
			{
				if (!_tutorialScript.UIScript.IsViewPanelOpen)
				{
					_tutorialScript.HighlightUiElement("ViewButton", new Vector2(0f, 0f), new Vector2(75f, 75f), highlightEvenIfInactive: true);
					_tutorialScript.DisplayMessage("Let's reset the view now. Click the button with the eye icon.");
				}
				else
				{
					_tutorialScript.HighlightUiElement("ViewAircraftSideButton", new Vector2(0f, 0f), new Vector2(75f, 75f), highlightEvenIfInactive: true);
					_tutorialScript.DisplayMessage("Now click the View Side button.");
				}
			}
			else
			{
				_tutorialScript.NextStep();
			}
		}

		private void CameraMoved(Vector2 rotation, Vector2 pan, float zoomAmount)
		{
			_rotation += new Vector2(Mathf.Abs(rotation.x), Mathf.Abs(rotation.y));
			_pan += new Vector2(Mathf.Abs(pan.x), Mathf.Abs(pan.y));
			_zoom += Mathf.Abs(zoomAmount);
		}

		private void ClearCameraStuff()
		{
			_rotation = Vector2.zero;
			_pan = Vector2.zero;
			_zoom = 0f;
		}

		private void SideViewButtonClicked()
		{
			_sideViewSelected = true;
		}
	}
}

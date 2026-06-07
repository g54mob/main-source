using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Input.Events;
using Assets.Scripts.UI;
using Jundroo.Common.Math;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public abstract class DesignerTool
	{
		private Designer _designer;

		private Vector3 _pinchCameraStartPosition;

		private bool _pinching;

		private Vector3 _pinchTargetStartPosition;

		private PartScript _playHoverSoundPart;

		private float _playHoverSoundTime;

		public static bool PreventRotationAfterPinch { get; set; }

		public bool AllowFingerAid { get; set; }

		public bool AllowPartSelection { get; set; }

		public CameraController CameraController { get; private set; }

		public bool CanPinch { get; set; }

		public bool IsActive { get; private set; }

		public PartScript PartScript => _designer.SelectedPart;

		public bool PreventRotation { get; private set; }

		public bool ShowSelectionHighlight { get; set; }

		public virtual bool UseDragThreshold => true;

		public bool ViewPortIsMoving { get; private set; }

		protected Designer Designer => _designer;

		protected virtual bool PartHighlightEnabled => false;

		public DesignerTool(Designer designer, CameraController cameraController)
		{
			_designer = designer;
			CameraController = cameraController;
			AllowPartSelection = true;
			AllowFingerAid = true;
			ShowSelectionHighlight = true;
			CanPinch = true;
		}

		public virtual void AircraftStructureChanged()
		{
		}

		public virtual string GetAircraftInformationDisplay()
		{
			if (Designer.Aircraft != null)
			{
				float loadedMass = Designer.Aircraft.CenterOfMass.LoadedMass;
				float fuelCapacity = Designer.Aircraft.FuelCapacity;
				string text = (loadedMass / 0.01f).Format(UnitType.Mass);
				string text2 = fuelCapacity.Format(UnitType.Volume);
				return text + " / " + text2;
			}
			return string.Empty;
		}

		public virtual void HandleInput(InputEvent e)
		{
			if (e.InputState == InputState.Begin)
			{
				PreventRotation = false;
			}
			if (!Designer.EnableViewportPanningAndRotation || _pinching)
			{
				return;
			}
			if (e.InputState == InputState.Updated)
			{
				Designer.DesignerScript.DesignerUI.HideMainUI(hide: true);
				ViewPortIsMoving = true;
				Camera.main.GetComponent<MoveObjectScript>().ResetPanning();
			}
			else if (e.InputState == InputState.End)
			{
				ViewPortIsMoving = false;
				Designer.DesignerScript.DesignerUI.HideMainUI(hide: false);
			}
			if ((e.InputButton == InputButton.Primary || e.InputButton == InputButton.Middle) && !PreventRotation && e.InputState != InputState.End && !Camera.main.GetComponent<MoveObjectScript>().ObjectIsPanning)
			{
				float num = 0.25f;
				if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
				{
					num *= 0.1f;
				}
				CameraController.Rotate(new Vector2(e.DeltaPosition.x * num, (0f - e.DeltaPosition.y) * num));
			}
			if (e.InputButton == InputButton.Secondary && !Camera.main.GetComponent<MoveObjectScript>().ObjectIsPanning)
			{
				float num2 = (Camera.main.orthographic ? (2f * Camera.main.orthographicSize / (float)Screen.height) : 0.025f);
				if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
				{
					num2 *= 0.1f;
				}
				CameraController.Move(-e.DeltaPosition * num2);
			}
			if (Camera.main.orthographic)
			{
				Designer.Environment.ShowPlatform(CameraController.Camera.transform.forward.y <= 0f);
			}
			else
			{
				Designer.Environment.ShowPlatform(CameraController.Camera.transform.position.y > 0f);
			}
		}

		public virtual void HandlePinch(PinchEvent e)
		{
			if (CanPinch)
			{
				if (e.InputState == InputState.Begin)
				{
					_pinching = true;
					_pinchCameraStartPosition = CameraController.Camera.transform.localPosition;
					_pinchTargetStartPosition = CameraController.Camera.transform.parent.position;
				}
				else if (e.InputState == InputState.Updated)
				{
					if (PreventRotationAfterPinch)
					{
						PreventRotation = true;
					}
					_pinching = true;
					CameraController.Camera.transform.parent.position = _pinchTargetStartPosition;
					CameraController.Camera.transform.localPosition = _pinchCameraStartPosition;
					CameraController.Zoom(e.TotalDistanceDelta / 50f);
					CameraController.Move(-e.TotalMidpointDelta * 0.0125f);
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
		}

		public void HandleScroll(MouseScrollEvent e)
		{
			float num = e.Delta;
			if (num != 0f)
			{
				if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
				{
					num *= 0.05f;
				}
				CameraController.Zoom(num);
				Camera.main.GetComponent<MoveObjectScript>().ResetPanning();
			}
		}

		public virtual void MouseHover(Vector3? screenPosition)
		{
			if (screenPosition.HasValue && PartHighlightEnabled)
			{
				PartScript partAtScreenPosition = Designer.DesignerScript.GetPartAtScreenPosition(screenPosition.Value);
				if (Designer.HighlightedPart != partAtScreenPosition)
				{
					Designer.HighlightedPart = partAtScreenPosition;
					_playHoverSoundTime = Time.unscaledTime + 0.05f;
					_playHoverSoundPart = partAtScreenPosition;
				}
			}
			else
			{
				Designer.HighlightedPart = null;
			}
		}

		public virtual void OnAircraftRepositionEnd(Vector3 delta)
		{
		}

		public virtual void OnAircraftRepositionStart(Vector3 delta)
		{
		}

		public virtual void Start()
		{
			if (IsActive)
			{
				Debug.LogError("Designer tool '" + GetType().FullName + "' attempted to execute its Start() method while currently active. Ensure Stop() is called on the previous activation before attempting to restart the tool.");
			}
			IsActive = true;
			Designer.EnableViewportPanningAndRotation = true;
			Designer.SelectedPartChangedEvent += SelectedPartChanged;
		}

		public virtual void Stop()
		{
			IsActive = false;
			Designer.SelectedPartChangedEvent -= SelectedPartChanged;
		}

		public virtual void Update()
		{
			if (_playHoverSoundPart != null && Time.unscaledTime > _playHoverSoundTime)
			{
				if (_playHoverSoundPart == Designer.HighlightedPart && !_playHoverSoundPart.PartMaterialScript.IsSelected)
				{
					Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerHoverPart);
				}
				_playHoverSoundTime = 0f;
				_playHoverSoundPart = null;
			}
		}

		protected virtual void SelectedPartChanged(PartScript newPart)
		{
		}
	}
}

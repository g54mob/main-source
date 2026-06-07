using System;
using Assets.Scripts.Flight.GameView.Cameras;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Design;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CameraVantageScript : PartModifierScript<CameraVantageData>, ICameraTarget, IFlightUpdate, IGameLoopItem, IFlightStart, IStart
	{
		private Transform _cameraPosition;

		private IInputController _input;

		private bool _mouseLook;

		private bool _registered;

		public bool AutoCenterCamera
		{
			get
			{
				return base.Data.AutoCenterCamera;
			}
			set
			{
				base.Data.AutoCenterCamera = value;
			}
		}

		public bool AutoOrient
		{
			get
			{
				return base.Data.AutoOrient;
			}
			set
			{
				base.Data.AutoOrient = value;
			}
		}

		public CameraController CameraController { get; set; }

		public Transform CameraPosition => _cameraPosition;

		public Transform CameraTarget => base.transform;

		public Vector3 CameraTargetPlanetPosition => (Vector3)Game.Instance.FlightScene.ViewManager.GameView.ReferenceFrame.FrameToPlanetPosition(base.transform.position);

		public CameraVantageData CameraVantage => base.Data;

		public float CurrentFieldOfView
		{
			get
			{
				if (base.Data.VariableZoom)
				{
					float t = Mathf.Clamp01(_input.Value);
					return Mathf.Lerp(base.Data.FieldOfViewMax, base.Data.FieldOfViewMin, t);
				}
				return base.Data.FieldOfView;
			}
		}

		public Vector3 FirstPersonVantagePosition
		{
			get
			{
				Vector3 vector = (base.Data.PadPosition ? (base.transform.up * 0.5f) : Vector3.zero);
				return _cameraPosition.position + vector;
			}
		}

		public bool HidePart { get; private set; }

		public bool LookAtCommandPod
		{
			get
			{
				return base.Data.LookAtCommandPod;
			}
			set
			{
				base.Data.LookAtCommandPod = value;
			}
		}

		public bool MouseLook
		{
			get
			{
				return _mouseLook;
			}
			set
			{
				_mouseLook = value;
				if (CameraController is InteractiveCameraController interactiveCameraController)
				{
					interactiveCameraController.MouseLook = _mouseLook;
				}
			}
		}

		public Action OnRegistered { get; set; }

		public IOrbitNode OrbitNode
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ViewMode ViewMode
		{
			get
			{
				return base.Data.ViewMode;
			}
			set
			{
				base.Data.ViewMode = value;
			}
		}

		public override void FlightEnd()
		{
			UnregisterFromCameraManager();
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			_cameraPosition = new GameObject("CameraPosition").transform;
			_cameraPosition.parent = base.transform;
			_cameraPosition.localRotation = Quaternion.Euler(base.Data.CameraRotationOffset);
			_cameraPosition.localPosition = base.Data.CameraOffset;
			_input = GetInputController("Zoom");
			if (_input == null)
			{
				_input = GetInputController((CraftControls x) => x.Slider1);
				if (_input is SimpleInputController simpleInputController)
				{
					simpleInputController.IgnorePartActivated = true;
				}
			}
			ViewMode = ViewMode.FirstPerson;
			Game.Instance.FlightScene.CraftChanged += OnCraftChanged;
			if (!base.Data.ManualRegister && base.PartScript.CraftScript == Game.Instance.FlightScene.CraftNode.CraftScript)
			{
				Register();
			}
			if (HidePart)
			{
				base.gameObject.SetActive(value: false);
			}
			UpdateScale();
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			_cameraPosition.localPosition = base.Data.CameraOffset;
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			UpdateScale();
		}

		void IStart.Start(in FrameData frame)
		{
			if (!Game.InFlightScene)
			{
				UpdateScale();
			}
		}

		public void UpdateScale()
		{
			if (!(base.Data.Part.PartType.Id == "Camera1"))
			{
				return;
			}
			Transform transform = base.transform.Find("Scalar");
			if (!(transform != null))
			{
				return;
			}
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 0.2f * base.Data.Scale;
			}
			transform.localScale = Vector3.one * base.Data.Scale;
			transform.localPosition = new Vector3(0f, 0f, 0f);
			transform.Find("Base").gameObject.SetActive(!base.Data.HideBase);
		}

		private void OnCraftChanged(ICraftNode craftNode)
		{
			if (!_registered && craftNode == base.PartScript.CraftScript.CraftNode)
			{
				Register();
			}
		}

		private void OnDestroy()
		{
			UnregisterFromCameraManager();
			if (Game.Instance?.FlightScene != null)
			{
				Game.Instance.FlightScene.CraftChanged -= OnCraftChanged;
			}
		}

		private void Register()
		{
			CameraController = CameraManagerScript.Instance?.RegisterCustomCameraVantage(this);
			if (CameraController is InteractiveCameraController interactiveCameraController)
			{
				interactiveCameraController.MouseLook = MouseLook;
			}
			_registered = true;
			OnRegistered?.Invoke();
		}

		private void UnregisterFromCameraManager()
		{
			if (_registered)
			{
				_registered = false;
				CameraManagerScript.Instance?.UnRegisterCustomCameraVantage(this);
				CameraController?.OnDestroy();
				CameraController = null;
			}
		}
	}
}

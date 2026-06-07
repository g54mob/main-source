using System;
using System.Collections.Generic;
using Assets.Scripts.Design;
using Assets.Scripts.Flight.GameView.Cameras;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using ModApi.Scripts.State.Validation;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("CameraVantage")]
	public class CameraVantageData : PartModifierData<CameraVantageScript>
	{
		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _autoCenterCamera;

		private bool _autoOrient;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _cameraOffset = new Vector3(0f, 0f, 0f);

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _cameraRotationOffset = new Vector3(0f, 0f, 0f);

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _dirtIntensity;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _enabledByDefault = true;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Hide Base", Order = 14, Tooltip = "Toggles the visibility of the base on/off.")]
		private bool _hideBase;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Label = "Size", Order = 1, Tooltip = "Changes the overall size of the camera.")]
		private float _scale = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 51, Order = 11, Label = "Field of View", Tooltip = "The field of view of this camera.")]
		private float _fieldOfView = 60f;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 51, Order = 12, Label = "Zoomed Out Field of View", Tooltip = "The field of view to use when the camera is fully zoomed out.")]
		private float _fieldOfViewMax = 100f;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 51, Order = 13, Label = "Zoomed In Field of View", Tooltip = "The field of view to use when the camera is fully zoomed in.")]
		private float _fieldOfViewMin = 40f;

		private bool _hidePart;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _isHidden;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Night Vision", Order = 15, Tooltip = "Toggles the night vision mode on/off.")]
		private bool _isNight;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _nightVisionColor = "#80FF8080";

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Look at Command Pod", Order = 2, Tooltip = "Force the camera to always look directly at the command pod.")]
		private bool _lookAtCommandPod;

		private Vector2 _lookBackTranslation;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _manualRegister;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Pad Position", Order = 3, Tooltip = "Automatically move the viewpoint up by half a meter to reduce view clipping and seeing inside the craft.")]
		private bool _padPosition = true;

		[SerializeField]
		[DesignerPropertyToggleButton(Order = 10, Label = "Variable Zoom", Tooltip = "Enables smoothly changing between two FOVs based on input specified below.")]
		private bool _variableZoom;

		public bool AutoCenterCamera
		{
			get
			{
				return _autoCenterCamera;
			}
			set
			{
				_autoCenterCamera = value;
			}
		}

		public bool AutoOrient
		{
			get
			{
				return _autoOrient;
			}
			set
			{
				_autoOrient = value;
			}
		}

		public Vector3 CameraOffset
		{
			get
			{
				return _cameraOffset * Scale;
			}
			set
			{
				_cameraOffset = value;
			}
		}

		public Vector3 CameraRotationOffset
		{
			get
			{
				return _cameraRotationOffset;
			}
			set
			{
				_cameraRotationOffset = value;
			}
		}

		public float DirtIntensity => _dirtIntensity;

		public bool EnabledByDefault
		{
			get
			{
				return _enabledByDefault;
			}
			set
			{
				_enabledByDefault = value;
			}
		}

		public float FieldOfView
		{
			get
			{
				if (base.Version != 1)
				{
					return Mathf.Lerp(Mathf.Min(40f / _scale / _scale / _scale, 120f), 120f, _fieldOfView);
				}
				return _fieldOfView;
			}
		}

		public float FieldOfViewMax
		{
			get
			{
				if (base.Version != 1)
				{
					return Mathf.Lerp(Mathf.Min(40f / _scale / _scale / _scale, 120f), 120f, _fieldOfViewMax);
				}
				return _fieldOfViewMax;
			}
		}

		public float FieldOfViewMin
		{
			get
			{
				if (base.Version != 1)
				{
					return Mathf.Lerp(Mathf.Min(40f / _scale / _scale / _scale, 120f), FieldOfViewMax, _fieldOfViewMin);
				}
				return _fieldOfViewMin;
			}
		}

		public bool HideBase => _hideBase;

		public bool IsHidden
		{
			get
			{
				return _isHidden;
			}
			set
			{
				_isHidden = value;
			}
		}

		public bool IsNight
		{
			get
			{
				return _isNight;
			}
			set
			{
				_isNight = value && Game.Instance.GameState.Validator.IsItemAvailable("Camera.NightVision");
			}
		}

		public bool LookAtCommandPod
		{
			get
			{
				return _lookAtCommandPod;
			}
			set
			{
				_lookAtCommandPod = value;
			}
		}

		public Vector2 LookBackTranslation
		{
			get
			{
				return _lookBackTranslation;
			}
			set
			{
				_lookBackTranslation = value;
			}
		}

		public bool ManualRegister
		{
			get
			{
				return _manualRegister;
			}
			set
			{
				_manualRegister = value;
			}
		}

		public override float MassDry => 10f * Scale * Scale * Scale * 0.01f;

		public Color NightVisionColor => Utilities.HexToColor(_nightVisionColor);

		public bool PadPosition => _padPosition;

		public override long Price => (int)(500f * Scale * Scale * (float)((!IsNight) ? 1 : 5));

		public override float Scale
		{
			get
			{
				if (!(base.Part.PartType.Id != "Camera1"))
				{
					return _scale;
				}
				return 1f;
			}
			set
			{
				_scale = ((base.Part.PartType.Id != "Camera1") ? 1f : value);
			}
		}

		public List<ViewMode> SupportedViewModes { get; set; }

		public bool VariableZoom => _variableZoom;

		public ViewMode ViewMode { get; set; }

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			d.OnVisibilityRequested(() => _scale, (bool x) => base.Part.PartType.Id == "Camera1");
			d.OnVisibilityRequested(() => _hideBase, (bool x) => base.Part.PartType.Id == "Camera1");
			d.OnVisibilityRequested(() => _isNight, (bool x) => base.Part.PartType.Id == "Camera1");
			d.OnVisibilityRequested(() => _fieldOfView, (bool x) => !_variableZoom);
			d.OnVisibilityRequested(() => _fieldOfViewMin, (bool x) => _variableZoom);
			d.OnVisibilityRequested(() => _fieldOfViewMax, (bool x) => _variableZoom);
			d.OnValueLabelRequested(() => _fieldOfView, (float x) => Mathf.Round(FieldOfView).ToString());
			d.OnValueLabelRequested(() => _fieldOfViewMin, (float x) => Mathf.Round(FieldOfViewMin).ToString());
			d.OnValueLabelRequested(() => _fieldOfViewMax, (float x) => Mathf.Round(FieldOfViewMax).ToString());
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(x));
			d.OnPropertyChanged(() => _hideBase, delegate
			{
				UpdateSymmetricParts();
			});
			d.OnPropertyChanged(() => _scale, delegate
			{
				UpdateSymmetricParts();
			});
			d.OnPropertyChanged(() => _fieldOfViewMin, delegate
			{
				_fieldOfViewMin = Mathf.Min(_fieldOfViewMin, _fieldOfViewMax);
				d.Manager.RefreshUI();
				Symmetry.SynchronizePartModifiers(base.Script.PartScript);
			});
			d.OnPropertyChanged(() => _fieldOfViewMax, delegate
			{
				_fieldOfViewMin = Mathf.Min(_fieldOfViewMin, _fieldOfViewMax);
				d.Manager.RefreshUI();
				Symmetry.SynchronizePartModifiers(base.Script.PartScript);
			});
			d.OnPropertyChanged(() => _isNight, delegate(bool newVal, bool oldVal)
			{
				if (!validator.IsItemAvailable("Camera.NightVision") && newVal)
				{
					_isNight = false;
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = "You haven't unlocked the night vision yet. You can unlock it in the Tech Tree.";
				}
				d.Manager.RefreshUI();
				Symmetry.SynchronizePartModifiers(base.Script.PartScript);
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
		}

		private void UpdateSymmetricParts()
		{
			Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, this, delegate(CameraVantageData t, CameraVantageData s)
			{
				t.Script.UpdateScale();
			});
			base.Part.PartScript.CraftScript.SetStructureChanged();
		}
	}
}

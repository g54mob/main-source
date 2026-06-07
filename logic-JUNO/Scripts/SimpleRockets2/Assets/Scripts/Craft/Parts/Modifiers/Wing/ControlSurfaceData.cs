using System;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Wing
{
	[Serializable]
	[DesignerPartModifier("Control Surface", PanelOrder = 1900)]
	public class ControlSurfaceData : PartModifierData<ControlSurfaceScript>
	{
		public delegate void PropertyChangedHandler(ControlSurfaceData source);

		public static class AssignmentType
		{
			public const string Auto = "Auto";

			public const string Manual = "Manual";
		}

		[SerializeField]
		[DesignerPropertySlider(0f, 2.5f, 51, Label = "Deflection Speed", Order = 1, Tooltip = "The speed that the control surface deflects.")]
		private float _deflectionSpeed = 1f;

		[SerializeField]
		[DesignerPropertyLabel(PreserveState = false, Label = "Axes")]
		private string _designerAutoAxesInfo = "n/a";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _end = 7;

		[SerializeField]
		[DesignerPropertySpinner(new string[] { "Auto", "Pitch", "Roll", "Yaw", "Throttle", "Brake", "Slider1", "Slider2", "Slider3", "Slider4" }, TextFormat = DesignerPropertySpinnerTextFormat.InputAuto)]
		private string _input = "Auto";

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Invert", Tooltip = "If enabled, the deflection angle of the control surface will be inverted.")]
		private bool _invert;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Invert on Mirror", Tooltip = "If enabled, then the Invert setting will be flipped when the part is mirrored to the other side.")]
		private bool _invertOnMirror;

		[SerializeField]
		[DesignerPropertySlider(0f, 45f, 46, Label = "Deflection Angle", Order = 1, Tooltip = "The max amount of angle the control surface can deflect.")]
		private float _maxDeflectionDegree = 35f;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Single Axis")]
		private bool _singleAxisWhenAuto = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _start = 4;

		public float DeflectionSpeed => _deflectionSpeed;

		public string DesignerAutoAxesInfo
		{
			get
			{
				return _designerAutoAxesInfo;
			}
			set
			{
				_designerAutoAxesInfo = value;
				base.DesignerPartProperties?.Manager?.RefreshUI();
			}
		}

		public int End
		{
			get
			{
				return _end;
			}
			set
			{
				_end = value;
			}
		}

		public string Input
		{
			get
			{
				return _input;
			}
			set
			{
				_input = value;
			}
		}

		public bool Invert
		{
			get
			{
				return _invert;
			}
			set
			{
				_invert = value;
			}
		}

		public bool InvertOnMirror
		{
			get
			{
				if (_invertOnMirror)
				{
					return _input != "Auto";
				}
				return false;
			}
			set
			{
				_invertOnMirror = value;
			}
		}

		public int Length => End - Start;

		public float MaxDeflectionDegree
		{
			get
			{
				return _maxDeflectionDegree;
			}
			set
			{
				_maxDeflectionDegree = value;
			}
		}

		public bool SingleAxisWhenAuto
		{
			get
			{
				return _singleAxisWhenAuto;
			}
			set
			{
				_singleAxisWhenAuto = value;
			}
		}

		public int Start
		{
			get
			{
				return _start;
			}
			set
			{
				_start = value;
			}
		}

		public event PropertyChangedHandler AutoPropertyChanged;

		public static ControlSurfaceData Create(PartData partData, int start, int length, string input, int maxDeflectionDegree, bool invert, bool invertOnMirror = false)
		{
			ControlSurfaceData controlSurfaceData = PartModifierData.CreateFromDefaultXml<ControlSurfaceData>(partData);
			controlSurfaceData.Start = start;
			controlSurfaceData.End = start + length;
			controlSurfaceData.Input = input;
			controlSurfaceData.MaxDeflectionDegree = maxDeflectionDegree;
			controlSurfaceData.Invert = invert;
			controlSurfaceData.InvertOnMirror = invertOnMirror;
			return controlSurfaceData;
		}

		protected override ControlSurfaceScript CreateScriptComponent(IPartScript partScript)
		{
			GameObject gameObject = new GameObject("ControlSurface");
			gameObject.name = $"{gameObject.name} {gameObject.GetInstanceID()}";
			gameObject.transform.SetParent(partScript.GameObject.transform);
			gameObject.layer = 31;
			return gameObject.AddComponent<ControlSurfaceScript>();
		}

		protected override void DestroyScriptComponent(IPartScript partScript)
		{
			UnityEngine.Object.Destroy(base.Script.gameObject);
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnVisibilityRequested(() => _invert, (bool x) => _input != "Auto");
			d.OnVisibilityRequested(() => _invertOnMirror, (bool x) => _input != "Auto");
			d.OnPropertyChanged(() => _input, delegate
			{
				OnAutoPropertyChanged();
			});
			d.OnVisibilityRequested(() => _designerAutoAxesInfo, (bool x) => _input == "Auto");
			d.OnValueLabelRequested(() => _deflectionSpeed, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _maxDeflectionDegree, (float x) => x + "°");
			d.OnVisibilityRequested(() => _singleAxisWhenAuto, (bool x) => _input == "Auto");
			d.OnPropertyChanged(() => _singleAxisWhenAuto, delegate
			{
				OnAutoPropertyChanged();
			});
		}

		private void OnAutoPropertyChanged()
		{
			this.AutoPropertyChanged?.Invoke(this);
		}
	}
}

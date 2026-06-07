using ModApi.Craft;
using ModApi.Craft.Program.Craft;

namespace Assets.Scripts.Vizzy.Craft
{
	public class CraftInputs : ICraftInputs
	{
		private CraftControls _controls;

		public float Brake
		{
			get
			{
				return _controls.Brake;
			}
			set
			{
				_controls.OffsetBrake = value;
				_controls.Brake = value;
			}
		}

		public float Pitch
		{
			get
			{
				return _controls.Pitch;
			}
			set
			{
				_controls.OffsetPitch = value;
				_controls.Pitch = value;
			}
		}

		public float Roll
		{
			get
			{
				return _controls.Roll;
			}
			set
			{
				_controls.OffsetRoll = value;
				_controls.Roll = value;
				_controls.RollInputReceived = value != 0f;
			}
		}

		public float Slider1
		{
			get
			{
				return _controls.Slider1;
			}
			set
			{
				_controls.OffsetSlider1 = value;
				_controls.Slider1 = value;
			}
		}

		public float Slider2
		{
			get
			{
				return _controls.Slider2;
			}
			set
			{
				_controls.OffsetSlider2 = value;
				_controls.Slider2 = value;
			}
		}

		public float Slider3
		{
			get
			{
				return _controls.Slider3;
			}
			set
			{
				_controls.OffsetSlider3 = value;
				_controls.Slider3 = value;
			}
		}

		public float Slider4
		{
			get
			{
				return _controls.Slider4;
			}
			set
			{
				_controls.OffsetSlider4 = value;
				_controls.Slider4 = value;
			}
		}

		public float Throttle
		{
			get
			{
				return _controls.Throttle;
			}
			set
			{
				_controls.Throttle = value;
			}
		}

		public float TranslateForward
		{
			get
			{
				return _controls.TranslateForward;
			}
			set
			{
				_controls.OffsetTranslateForward = value;
				_controls.TranslateForward = value;
			}
		}

		public float TranslateRight
		{
			get
			{
				return _controls.TranslateRight;
			}
			set
			{
				_controls.OffsetTranslateRight = value;
				_controls.TranslateRight = value;
			}
		}

		public float TranslateUp
		{
			get
			{
				return _controls.TranslateUp;
			}
			set
			{
				_controls.OffsetTranslateUp = value;
				_controls.TranslateUp = value;
			}
		}

		public bool TranslationMode
		{
			get
			{
				return _controls.TranslationModeEnabled;
			}
			set
			{
				_controls.TranslationModeEnabled = value;
			}
		}

		public float Yaw
		{
			get
			{
				return _controls.Yaw;
			}
			set
			{
				_controls.OffsetYaw = value;
				_controls.Yaw = value;
			}
		}

		public CraftInputs(CraftControls controls)
		{
			_controls = controls;
		}
	}
}

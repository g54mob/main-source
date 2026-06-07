using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Rewired.Internal
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class StandaloneAxis
	{
		[CustomObfuscation(rename = false)]
		public delegate void AxisValueChangedEventHandler(float value);

		[CustomObfuscation(rename = false)]
		public delegate void ButtonValueChangedEventHandler(bool value);

		[CustomObfuscation(rename = false)]
		public delegate void ButtonDownEventHandler();

		[CustomObfuscation(rename = false)]
		public delegate void ButtonUpEventHandler();

		[Tooltip("The axis value at or above which the buttonValue property will return True. This will also return true for negative values below the inverse of this threshold.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 1f)]
		private float _buttonActivationThreshold;

		[Tooltip("Contains calibration settings for the axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisCalibration _calibration;

		[CustomObfuscation(rename = false)]
		private float _valueRaw;

		[CustomObfuscation(rename = false)]
		private float _valueRawPrev;

		[CompilerGenerated]
		private AxisValueChangedEventHandler JAgDGBwbvVGotCchtjKIHoDEQYdS;

		[CompilerGenerated]
		private AxisValueChangedEventHandler CgPgluwKUIgWuWYnngCyBgDTISmx;

		[CompilerGenerated]
		private ButtonDownEventHandler rASKVDxpCotrUnoiRWahTINxIhkU;

		[CompilerGenerated]
		private ButtonUpEventHandler LuWDJTJChunKslHfcqwbfWWbbkCE;

		[CompilerGenerated]
		private ButtonValueChangedEventHandler uNiaVYeWRhevwcJXjkOoTSnXLQthA;

		[CompilerGenerated]
		private ButtonDownEventHandler ekeDrJsFjAefFEsYJlXqGzCkYOUx;

		[CompilerGenerated]
		private ButtonUpEventHandler uBjNglTHAGouQWyWomqASJbclBMB;

		[CompilerGenerated]
		private ButtonValueChangedEventHandler jSRXSPfavRVUIkHdGjeeWwyBbNIn;

		public float buttonActivationThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AxisCalibration calibration
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public float valueRaw
		{
			get
			{
				return 0f;
			}
			private set
			{
			}
		}

		public float valueRawPrev
		{
			get
			{
				return 0f;
			}
			private set
			{
			}
		}

		public float valueRawDelta => 0f;

		public float value => 0f;

		public float valuePrev => 0f;

		public float valueDelta => 0f;

		public bool rawButtonValue => false;

		public bool rawButtonValuePrev => false;

		public bool buttonValue => false;

		public bool buttonValuePrev => false;

		internal float rawMin => 0f;

		internal float rawMax => 0f;

		internal float rawZero => 0f;

		private event AxisValueChangedEventHandler _AxisValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event AxisValueChangedEventHandler AxisValueChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private event AxisValueChangedEventHandler _RawAxisValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event AxisValueChangedEventHandler RawAxisValueChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private event ButtonDownEventHandler _ButtonDownEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event ButtonDownEventHandler ButtonDownEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private event ButtonUpEventHandler _ButtonUpEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event ButtonUpEventHandler ButtonUpEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private event ButtonValueChangedEventHandler _ButtonValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event ButtonValueChangedEventHandler ButtonValueChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private event ButtonDownEventHandler _RawButtonDownEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event ButtonDownEventHandler RawButtonDownEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private event ButtonUpEventHandler _RawButtonUpEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event ButtonUpEventHandler RawButtonUpEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		private event ButtonValueChangedEventHandler _RawButtonValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event ButtonValueChangedEventHandler RawButtonValueChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		internal StandaloneAxis()
		{
		}

		public void SetRawValue(float value)
		{
		}

		public void Clear()
		{
		}

		[CustomObfuscation(rename = false)]
		internal static StandaloneAxis CreateRelative()
		{
			return null;
		}
	}
}

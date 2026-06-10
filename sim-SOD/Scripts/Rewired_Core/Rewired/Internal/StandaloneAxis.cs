using System;
using UnityEngine;

namespace Rewired.Internal
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
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
		[Range(0f, 1f)]
		[CustomObfuscation(rename = false)]
		private float _buttonActivationThreshold;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Contains calibration settings for the axis.")]
		private AxisCalibration _calibration;

		[CustomObfuscation(rename = false)]
		private float _valueRaw;

		[CustomObfuscation(rename = false)]
		private float _valueRawPrev;

		private AxisValueChangedEventHandler BbMdxuHlboLNPjgchXCiMWrgSutq;

		private AxisValueChangedEventHandler poOAsCCgEVmVsdIchEoyvIejPES;

		private ButtonDownEventHandler qoeXDThbFKLantPKCowfPMjNGdv;

		private ButtonUpEventHandler ORFYFYUJfEaHfenCpZuBaJdlcVXy;

		private ButtonValueChangedEventHandler YggbtdYVGeTUbPEGweeoXETcTFK;

		private ButtonDownEventHandler UFmafdIodODdMJwvJdcQdkCgnZgj;

		private ButtonUpEventHandler JVjfvxgoYjKwAxKkpmsvXSrtfSc;

		private ButtonValueChangedEventHandler NzGpwNsxFVRGuHJuizsotBgVSok;

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
			add
			{
			}
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
			add
			{
			}
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
			add
			{
			}
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
			add
			{
			}
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
			add
			{
			}
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
			add
			{
			}
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
			add
			{
			}
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
			add
			{
			}
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

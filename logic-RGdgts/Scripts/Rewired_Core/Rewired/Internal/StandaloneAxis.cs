using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Rewired.Internal
{
	[Serializable]
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal sealed class StandaloneAxis
	{
		[CustomObfuscation]
		public delegate void AxisValueChangedEventHandler(float value);

		[CustomObfuscation]
		public delegate void ButtonValueChangedEventHandler(bool value);

		[CustomObfuscation]
		public delegate void ButtonDownEventHandler();

		[CustomObfuscation]
		public delegate void ButtonUpEventHandler();

		[SerializeField]
		[CustomObfuscation]
		private float _buttonActivationThreshold;

		[SerializeField]
		[CustomObfuscation]
		private AxisCalibration _calibration;

		[CustomObfuscation]
		private float _valueRaw;

		[CustomObfuscation]
		private float _valueRawPrev;

		[CompilerGenerated]
		private AxisValueChangedEventHandler HLGKyrdafUQHhqdCIWgbSLWXcXmr;

		[CompilerGenerated]
		private AxisValueChangedEventHandler vYAnFHWAArJwOhWLkEFntBmgpcLe;

		[CompilerGenerated]
		private ButtonDownEventHandler gAgpMStGFovyDpFwRgYebDIMuEuWA;

		[CompilerGenerated]
		private ButtonUpEventHandler SCJNWFEwnmGRZnuaqVAEXQKeraEo;

		[CompilerGenerated]
		private ButtonValueChangedEventHandler AkceaWMYCeXPJFaxFGzyTaxnqDqA;

		[CompilerGenerated]
		private ButtonDownEventHandler MRyeeWMdbuxGaqXXEIqTolpmkfxc;

		[CompilerGenerated]
		private ButtonUpEventHandler HmjfsserMRiombxAoFCsEPMuodryA;

		[CompilerGenerated]
		private ButtonValueChangedEventHandler FKUqUakHpdTSgRMvZRtUdFIMrlSA;

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

		[CustomObfuscation]
		internal static StandaloneAxis CreateRelative()
		{
			return null;
		}
	}
}

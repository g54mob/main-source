using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomInputSource : IDisposable
	{
		public abstract class Controller
		{
			protected bool _isConnected;

			protected string _deviceName;

			protected string _customName;

			public string customName => null;

			public bool isConnected
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public string deviceName => null;

			protected Controller(string P_0)
			{
			}

			public void Disconnect()
			{
			}

			public void Connect()
			{
			}

			public abstract void Update();
		}

		public abstract class Joystick : Controller
		{
			private long? ruhDRnGUVdyexXxflaZPBlXwuqYl;

			private int kQhTCblAYSuvmyinRJJGwAKFBIfj;

			private readonly Axis[] brSuYimOuyWJoTIlcMgUhFfimdIf;

			private readonly Button[] ZvPFEBoODFIFAalgjPuHlidSttRw;

			private readonly ReadOnlyCollection<Axis> rEtiIIgRDKkgbtYvpdyAuMMnTsTo;

			private readonly ReadOnlyCollection<Button> egRIWCsrRvLJBNoTeDGKlOMtsehu;

			private bool NlEsLwrKCjqFrmBfZfjrECLGFIHGb;

			private Rewired.Controller.Extension twcsiuijVoCQoRBtCRDysXzVVTPD;

			public long? systemId
			{
				get
				{
					return null;
				}
				protected set
				{
				}
			}

			public int unityId
			{
				get
				{
					return 0;
				}
				protected set
				{
				}
			}

			public IList<Axis> Axes => null;

			public IList<Button> Buttons => null;

			public bool supportsVibration
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public int buttonCount => 0;

			public int axisCount => 0;

			public Joystick(string P_0, long? P_1, int P_2, int P_3, int P_4)
				: base(null)
			{
			}

			public virtual float GetAxisValue(int index)
			{
				return 0f;
			}

			public virtual bool GetButtonValue(int index)
			{
				return false;
			}
		}

		public abstract class Element
		{
		}

		public sealed class Axis : Element
		{
			public float value;
		}

		public sealed class Button : Element
		{
			public bool value;
		}

		private readonly InputSource lIrFNebwcrngtQQhQmkKXzYuwXAQ;

		private readonly List<Joystick> oCXEcyRhtMITnowBWsFAeLPwifRc;

		private readonly ReadOnlyCollection<Joystick> XvqMFijxmUADXJFzfGHVoakngFAeA;

		private bool XjBRApvlPvxLzkSiyfPhMXTCETUw;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

		public bool useApproximateMatching
		{
			get
			{
				return false;
			}
			protected set
			{
			}
		}

		internal InputSource ieYluIwipVjyjzLjHAiijAxmNxsP => default(InputSource);

		public abstract bool isReady { get; }

		private event Action sUdPXjzcLarSzrpLfsOWFngKgaCEA
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

		private event Action XnyYTRgAHpuSHeBOqlDYoLPZSgqS
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

		internal event Action HkgLSNgaikfVJMXFCOLwlYKoKjXn
		{
			add
			{
			}
			remove
			{
			}
		}

		internal event Action awbLkeOTVRZgLsHbnGFZWHDPJWeh
		{
			add
			{
			}
			remove
			{
			}
		}

		public CustomInputSource(int P_0)
		{
		}

		public void AddJoystick(Joystick joystick)
		{
		}

		public void RemoveJoystick(Joystick joystick)
		{
		}

		public IList<Joystick> GetJoysticks()
		{
			return null;
		}

		protected virtual void OnJoystickConnected()
		{
		}

		protected virtual void OnJoystickDisconnected()
		{
		}

		internal Joystick[] UnZxRhjmPsfNFewaWfIuSCfLXlOVA()
		{
			return null;
		}

		public virtual void Dispose()
		{
		}

		~CustomInputSource()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public abstract void Update();
	}
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomInputSource : IDisposable
	{
		public abstract class Controller
		{
			protected bool _isConnected;

			protected string _deviceName;

			protected string _customName;

			public string customName => _customName;

			public bool isConnected
			{
				get
				{
					return _isConnected;
				}
				set
				{
					if (value != _isConnected)
					{
						_ = _isConnected;
						_isConnected = value;
					}
				}
			}

			public string deviceName => _deviceName;

			protected Controller(string P_0)
			{
				_deviceName = P_0;
			}

			public void Disconnect()
			{
				if (_isConnected)
				{
					_isConnected = false;
				}
			}

			public void Connect()
			{
				if (!_isConnected)
				{
					_isConnected = true;
				}
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
					return ruhDRnGUVdyexXxflaZPBlXwuqYl;
				}
				protected set
				{
					ruhDRnGUVdyexXxflaZPBlXwuqYl = value;
				}
			}

			public int unityId
			{
				get
				{
					return kQhTCblAYSuvmyinRJJGwAKFBIfj;
				}
				protected set
				{
					kQhTCblAYSuvmyinRJJGwAKFBIfj = value;
				}
			}

			public IList<Axis> Axes => rEtiIIgRDKkgbtYvpdyAuMMnTsTo;

			public IList<Button> Buttons => egRIWCsrRvLJBNoTeDGKlOMtsehu;

			public bool supportsVibration
			{
				get
				{
					return NlEsLwrKCjqFrmBfZfjrECLGFIHGb;
				}
				set
				{
					NlEsLwrKCjqFrmBfZfjrECLGFIHGb = value;
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					return twcsiuijVoCQoRBtCRDysXzVVTPD;
				}
				set
				{
					twcsiuijVoCQoRBtCRDysXzVVTPD = value;
				}
			}

			public int buttonCount => ZvPFEBoODFIFAalgjPuHlidSttRw.Length;

			public int axisCount => brSuYimOuyWJoTIlcMgUhFfimdIf.Length;

			public Joystick(string P_0, long? P_1, int P_2, int P_3, int P_4)
				: base(P_0)
			{
				if (P_3 < 0)
				{
					P_3 = 0;
				}
				if (P_4 < 0)
				{
					P_4 = 0;
				}
				ruhDRnGUVdyexXxflaZPBlXwuqYl = P_1;
				kQhTCblAYSuvmyinRJJGwAKFBIfj = P_2;
				brSuYimOuyWJoTIlcMgUhFfimdIf = new Axis[P_3];
				ZvPFEBoODFIFAalgjPuHlidSttRw = new Button[P_4];
				for (int i = 0; i < P_3; i++)
				{
					brSuYimOuyWJoTIlcMgUhFfimdIf[i] = new Axis();
				}
				for (int j = 0; j < P_4; j++)
				{
					ZvPFEBoODFIFAalgjPuHlidSttRw[j] = new Button();
				}
				rEtiIIgRDKkgbtYvpdyAuMMnTsTo = new ReadOnlyCollection<Axis>(brSuYimOuyWJoTIlcMgUhFfimdIf);
				egRIWCsrRvLJBNoTeDGKlOMtsehu = new ReadOnlyCollection<Button>(ZvPFEBoODFIFAalgjPuHlidSttRw);
			}

			public virtual float GetAxisValue(int index)
			{
				if (index < 0 || index >= brSuYimOuyWJoTIlcMgUhFfimdIf.Length)
				{
					return 0f;
				}
				return brSuYimOuyWJoTIlcMgUhFfimdIf[index].value;
			}

			public virtual bool GetButtonValue(int index)
			{
				if (index < 0 || index >= ZvPFEBoODFIFAalgjPuHlidSttRw.Length)
				{
					return false;
				}
				return ZvPFEBoODFIFAalgjPuHlidSttRw[index].value;
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

		private bool XjBRApvlPvxLzkSiyfPhMXTCETUw = true;

		[CompilerGenerated]
		private Action m_sUdPXjzcLarSzrpLfsOWFngKgaCEA;

		[CompilerGenerated]
		private Action m_XnyYTRgAHpuSHeBOqlDYoLPZSgqS;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

		public bool useApproximateMatching
		{
			get
			{
				return XjBRApvlPvxLzkSiyfPhMXTCETUw;
			}
			protected set
			{
				XjBRApvlPvxLzkSiyfPhMXTCETUw = value;
			}
		}

		internal InputSource ieYluIwipVjyjzLjHAiijAxmNxsP => lIrFNebwcrngtQQhQmkKXzYuwXAQ;

		public abstract bool isReady { get; }

		private event Action sUdPXjzcLarSzrpLfsOWFngKgaCEA
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_sUdPXjzcLarSzrpLfsOWFngKgaCEA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_sUdPXjzcLarSzrpLfsOWFngKgaCEA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_sUdPXjzcLarSzrpLfsOWFngKgaCEA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_sUdPXjzcLarSzrpLfsOWFngKgaCEA, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		private event Action XnyYTRgAHpuSHeBOqlDYoLPZSgqS
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_XnyYTRgAHpuSHeBOqlDYoLPZSgqS;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_XnyYTRgAHpuSHeBOqlDYoLPZSgqS, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_XnyYTRgAHpuSHeBOqlDYoLPZSgqS;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_XnyYTRgAHpuSHeBOqlDYoLPZSgqS, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		internal event Action HkgLSNgaikfVJMXFCOLwlYKoKjXn
		{
			add
			{
				sUdPXjzcLarSzrpLfsOWFngKgaCEA += action;
			}
			remove
			{
				sUdPXjzcLarSzrpLfsOWFngKgaCEA -= action;
			}
		}

		internal event Action awbLkeOTVRZgLsHbnGFZWHDPJWeh
		{
			add
			{
				XnyYTRgAHpuSHeBOqlDYoLPZSgqS += action;
			}
			remove
			{
				XnyYTRgAHpuSHeBOqlDYoLPZSgqS -= action;
			}
		}

		public CustomInputSource(int P_0)
		{
			if (!Enum.IsDefined(typeof(InputSource), P_0))
			{
				Logger.LogError("Unknown InputSource (" + P_0 + ")!");
			}
			lIrFNebwcrngtQQhQmkKXzYuwXAQ = (InputSource)P_0;
			oCXEcyRhtMITnowBWsFAeLPwifRc = new List<Joystick>();
			XvqMFijxmUADXJFzfGHVoakngFAeA = new ReadOnlyCollection<Joystick>(oCXEcyRhtMITnowBWsFAeLPwifRc);
		}

		public void AddJoystick(Joystick joystick)
		{
			if (joystick != null)
			{
				if (oCXEcyRhtMITnowBWsFAeLPwifRc.Contains(joystick))
				{
					Logger.LogWarning("The joystick is already in the list. Cannot add again.");
				}
				else
				{
					oCXEcyRhtMITnowBWsFAeLPwifRc.Add(joystick);
				}
			}
		}

		public void RemoveJoystick(Joystick joystick)
		{
			if (joystick != null)
			{
				if (!oCXEcyRhtMITnowBWsFAeLPwifRc.Contains(joystick))
				{
					Logger.LogWarning("The joystick was not found in the list. Cannot remove.");
				}
				else
				{
					oCXEcyRhtMITnowBWsFAeLPwifRc.Remove(joystick);
				}
			}
		}

		public IList<Joystick> GetJoysticks()
		{
			return XvqMFijxmUADXJFzfGHVoakngFAeA;
		}

		protected virtual void OnJoystickConnected()
		{
			if (this.sUdPXjzcLarSzrpLfsOWFngKgaCEA != null)
			{
				this.sUdPXjzcLarSzrpLfsOWFngKgaCEA();
			}
		}

		protected virtual void OnJoystickDisconnected()
		{
			if (this.XnyYTRgAHpuSHeBOqlDYoLPZSgqS != null)
			{
				this.XnyYTRgAHpuSHeBOqlDYoLPZSgqS();
			}
		}

		internal Joystick[] UnZxRhjmPsfNFewaWfIuSCfLXlOVA()
		{
			List<Joystick> list = new List<Joystick>(oCXEcyRhtMITnowBWsFAeLPwifRc.Count);
			for (int i = 0; i < oCXEcyRhtMITnowBWsFAeLPwifRc.Count; i++)
			{
				Joystick joystick = oCXEcyRhtMITnowBWsFAeLPwifRc[i];
				if (joystick != null && joystick.isConnected)
				{
					list.Add(joystick);
				}
			}
			return list.ToArray();
		}

		public virtual void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~CustomInputSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!JChPmMbeaoLOGQvosPYqDDInSiCs)
			{
				JChPmMbeaoLOGQvosPYqDDInSiCs = true;
			}
		}

		public abstract void Update();
	}
}

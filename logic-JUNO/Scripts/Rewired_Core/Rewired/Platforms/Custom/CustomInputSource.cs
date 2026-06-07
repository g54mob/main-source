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
			private long? SlWkFWIHjFkWnjlfcngzXheJuriJ;

			private int esGYrLPKNBpVRLHlzBRUfCGuCwNY;

			private readonly Axis[] AVSDxXgLjvFhvWzoGksOucNamiJKA;

			private readonly Button[] AaJxZgiMCjUsNTtpShfCFNbSRpOb;

			private readonly ReadOnlyCollection<Axis> tEYnRrmmGHkeUuuFpaDwlHVYtlGH;

			private readonly ReadOnlyCollection<Button> STJaSFEmBtKbzcFIItRWLmrsEVai;

			private bool RAFPFhFEtAzoEedqyXRburkSFJyM;

			private Rewired.Controller.Extension SjFGRxEBTIDPHhgrOWMgBeloTNaqA;

			public long? systemId
			{
				get
				{
					return SlWkFWIHjFkWnjlfcngzXheJuriJ;
				}
				protected set
				{
					SlWkFWIHjFkWnjlfcngzXheJuriJ = value;
				}
			}

			public int unityId
			{
				get
				{
					return esGYrLPKNBpVRLHlzBRUfCGuCwNY;
				}
				protected set
				{
					esGYrLPKNBpVRLHlzBRUfCGuCwNY = value;
				}
			}

			public IList<Axis> Axes => tEYnRrmmGHkeUuuFpaDwlHVYtlGH;

			public IList<Button> Buttons => STJaSFEmBtKbzcFIItRWLmrsEVai;

			public bool supportsVibration
			{
				get
				{
					return RAFPFhFEtAzoEedqyXRburkSFJyM;
				}
				set
				{
					RAFPFhFEtAzoEedqyXRburkSFJyM = value;
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					return SjFGRxEBTIDPHhgrOWMgBeloTNaqA;
				}
				set
				{
					SjFGRxEBTIDPHhgrOWMgBeloTNaqA = value;
				}
			}

			public int buttonCount => AaJxZgiMCjUsNTtpShfCFNbSRpOb.Length;

			public int axisCount => AVSDxXgLjvFhvWzoGksOucNamiJKA.Length;

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
				SlWkFWIHjFkWnjlfcngzXheJuriJ = P_1;
				esGYrLPKNBpVRLHlzBRUfCGuCwNY = P_2;
				AVSDxXgLjvFhvWzoGksOucNamiJKA = new Axis[P_3];
				AaJxZgiMCjUsNTtpShfCFNbSRpOb = new Button[P_4];
				for (int i = 0; i < P_3; i++)
				{
					AVSDxXgLjvFhvWzoGksOucNamiJKA[i] = new Axis();
				}
				for (int j = 0; j < P_4; j++)
				{
					AaJxZgiMCjUsNTtpShfCFNbSRpOb[j] = new Button();
				}
				tEYnRrmmGHkeUuuFpaDwlHVYtlGH = new ReadOnlyCollection<Axis>(AVSDxXgLjvFhvWzoGksOucNamiJKA);
				STJaSFEmBtKbzcFIItRWLmrsEVai = new ReadOnlyCollection<Button>(AaJxZgiMCjUsNTtpShfCFNbSRpOb);
			}

			public virtual float GetAxisValue(int index)
			{
				if (index < 0 || index >= AVSDxXgLjvFhvWzoGksOucNamiJKA.Length)
				{
					return 0f;
				}
				return AVSDxXgLjvFhvWzoGksOucNamiJKA[index].value;
			}

			public virtual bool GetButtonValue(int index)
			{
				if (index < 0 || index >= AaJxZgiMCjUsNTtpShfCFNbSRpOb.Length)
				{
					return false;
				}
				return AaJxZgiMCjUsNTtpShfCFNbSRpOb[index].value;
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

		private readonly InputSource hkatjCeJWMPeFfLnfmtzxRyJHjhj;

		private readonly List<Joystick> LVIBaturkepMVxvnLFGDtXovlSae;

		private readonly ReadOnlyCollection<Joystick> gIzxVIfycsiSGXstRYLgiRmTbzh;

		private bool USdRqYMAAQygaGpBPfPzduHcJenGA = true;

		[CompilerGenerated]
		private Action m_WCvMNHgONcBFYaRmclAyKoligGyhA;

		[CompilerGenerated]
		private Action m_CkcDOcYjexOMagcxzbZhdYKKcZoN;

		private bool scfxPIjlzStgXxwEUImbAMuftXvi;

		public bool useApproximateMatching
		{
			get
			{
				return USdRqYMAAQygaGpBPfPzduHcJenGA;
			}
			protected set
			{
				USdRqYMAAQygaGpBPfPzduHcJenGA = value;
			}
		}

		internal InputSource byneCVecOfLQLwZAqjbLTkmNJxMgb => hkatjCeJWMPeFfLnfmtzxRyJHjhj;

		public abstract bool isReady { get; }

		private event Action WCvMNHgONcBFYaRmclAyKoligGyhA
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_WCvMNHgONcBFYaRmclAyKoligGyhA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_WCvMNHgONcBFYaRmclAyKoligGyhA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_WCvMNHgONcBFYaRmclAyKoligGyhA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_WCvMNHgONcBFYaRmclAyKoligGyhA, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		private event Action CkcDOcYjexOMagcxzbZhdYKKcZoN
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_CkcDOcYjexOMagcxzbZhdYKKcZoN;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_CkcDOcYjexOMagcxzbZhdYKKcZoN, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_CkcDOcYjexOMagcxzbZhdYKKcZoN;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_CkcDOcYjexOMagcxzbZhdYKKcZoN, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		internal event Action JTFdCGfzIKYWZoERpDXXYIZdLjGD
		{
			add
			{
				WCvMNHgONcBFYaRmclAyKoligGyhA += action;
			}
			remove
			{
				WCvMNHgONcBFYaRmclAyKoligGyhA -= action;
			}
		}

		internal event Action jOYgdhCpNDMLSpHoOyasRIQSdPkgb
		{
			add
			{
				CkcDOcYjexOMagcxzbZhdYKKcZoN += action;
			}
			remove
			{
				CkcDOcYjexOMagcxzbZhdYKKcZoN -= action;
			}
		}

		public CustomInputSource(int P_0)
		{
			if (!Enum.IsDefined(typeof(InputSource), P_0))
			{
				Logger.LogError("Unknown InputSource (" + P_0 + ")!");
			}
			hkatjCeJWMPeFfLnfmtzxRyJHjhj = (InputSource)P_0;
			LVIBaturkepMVxvnLFGDtXovlSae = new List<Joystick>();
			gIzxVIfycsiSGXstRYLgiRmTbzh = new ReadOnlyCollection<Joystick>(LVIBaturkepMVxvnLFGDtXovlSae);
		}

		public void AddJoystick(Joystick joystick)
		{
			if (joystick != null)
			{
				if (LVIBaturkepMVxvnLFGDtXovlSae.Contains(joystick))
				{
					Logger.LogWarning("The joystick is already in the list. Cannot add again.");
				}
				else
				{
					LVIBaturkepMVxvnLFGDtXovlSae.Add(joystick);
				}
			}
		}

		public void RemoveJoystick(Joystick joystick)
		{
			if (joystick != null)
			{
				if (!LVIBaturkepMVxvnLFGDtXovlSae.Contains(joystick))
				{
					Logger.LogWarning("The joystick was not found in the list. Cannot remove.");
				}
				else
				{
					LVIBaturkepMVxvnLFGDtXovlSae.Remove(joystick);
				}
			}
		}

		public IList<Joystick> GetJoysticks()
		{
			return gIzxVIfycsiSGXstRYLgiRmTbzh;
		}

		protected virtual void OnJoystickConnected()
		{
			if (this.WCvMNHgONcBFYaRmclAyKoligGyhA != null)
			{
				this.WCvMNHgONcBFYaRmclAyKoligGyhA();
			}
		}

		protected virtual void OnJoystickDisconnected()
		{
			if (this.CkcDOcYjexOMagcxzbZhdYKKcZoN != null)
			{
				this.CkcDOcYjexOMagcxzbZhdYKKcZoN();
			}
		}

		internal Joystick[] TcTBrVKPjpjkfMKpUGBkhEZYHzhd()
		{
			List<Joystick> list = new List<Joystick>(LVIBaturkepMVxvnLFGDtXovlSae.Count);
			for (int i = 0; i < LVIBaturkepMVxvnLFGDtXovlSae.Count; i++)
			{
				Joystick joystick = LVIBaturkepMVxvnLFGDtXovlSae[i];
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

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~CustomInputSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!scfxPIjlzStgXxwEUImbAMuftXvi)
			{
				scfxPIjlzStgXxwEUImbAMuftXvi = true;
			}
		}

		public abstract void Update();
	}
}

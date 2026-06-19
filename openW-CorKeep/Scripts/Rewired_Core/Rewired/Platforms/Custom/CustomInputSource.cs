using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Interfaces;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomInputSource : IDisposable
	{
		public abstract class Controller
		{
			protected bool _isConnected;

			protected string _deviceName;

			protected string _customName;

			protected object _customIdentifier;

			protected Guid _persistentGuid;

			private Action<bool> FPouuLUqoKKRaRKevhquycQGtynd;

			public string customName => _customName;

			public bool isConnected
			{
				get
				{
					return _isConnected;
				}
				set
				{
					if (value == _isConnected)
					{
						return;
					}
					_isConnected = value;
					Action<bool> fPouuLUqoKKRaRKevhquycQGtynd = FPouuLUqoKKRaRKevhquycQGtynd;
					if (fPouuLUqoKKRaRKevhquycQGtynd == null)
					{
						return;
					}
					try
					{
						fPouuLUqoKKRaRKevhquycQGtynd(value);
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("CustomInputSource.Controller.ConnectedStateChangedEvent", exception);
					}
				}
			}

			public string deviceName => _deviceName;

			public object customIdentifier
			{
				get
				{
					return _customIdentifier;
				}
				set
				{
					_customIdentifier = value;
				}
			}

			public Guid deviceInstanceGuid
			{
				get
				{
					return _persistentGuid;
				}
				set
				{
					_persistentGuid = value;
				}
			}

			public event Action<bool> ConnectedStateChangedEvent
			{
				add
				{
					FPouuLUqoKKRaRKevhquycQGtynd = (Action<bool>)Delegate.Combine(FPouuLUqoKKRaRKevhquycQGtynd, value);
				}
				remove
				{
					FPouuLUqoKKRaRKevhquycQGtynd = (Action<bool>)Delegate.Remove(FPouuLUqoKKRaRKevhquycQGtynd, value);
				}
			}

			protected Controller(string P_0)
			{
				_deviceName = P_0;
			}

			public void Disconnect()
			{
				if (_isConnected)
				{
					isConnected = false;
				}
			}

			public void Connect()
			{
				if (!_isConnected)
				{
					isConnected = true;
				}
			}

			public abstract void Update();
		}

		public abstract class Joystick : Controller
		{
			private long? UrQFgzuzxuGdfseVuRevVPndzHhX;

			private int iSWhDgfQnqUgHKaRfeKOvCXIfHOZ;

			private readonly Axis[] UjYafilPHCpmjkQQEknAkEWSyVEv;

			private readonly Button[] OdaJjeQigEMNgWNZfTorPfEeAmqGA;

			private readonly ReadOnlyCollection<Axis> pfKGfsSASeBhIHbKxMpcxtIuRWXoA;

			private readonly ReadOnlyCollection<Button> YTPRiwwwAUpZfphkYTmOPhuQqppp;

			private bool BbNFOInRutzvUfQuoKLrupHisqxC;

			private Rewired.Controller.Extension WQLNEzkvgrQVJvBbAHeJmweWstac;

			public long? systemId
			{
				get
				{
					return UrQFgzuzxuGdfseVuRevVPndzHhX;
				}
				protected set
				{
					UrQFgzuzxuGdfseVuRevVPndzHhX = value;
				}
			}

			public int unityId
			{
				get
				{
					return iSWhDgfQnqUgHKaRfeKOvCXIfHOZ;
				}
				protected set
				{
					iSWhDgfQnqUgHKaRfeKOvCXIfHOZ = value;
				}
			}

			public IList<Axis> Axes => pfKGfsSASeBhIHbKxMpcxtIuRWXoA;

			public IList<Button> Buttons => YTPRiwwwAUpZfphkYTmOPhuQqppp;

			public bool supportsVibration
			{
				get
				{
					return BbNFOInRutzvUfQuoKLrupHisqxC;
				}
				set
				{
					BbNFOInRutzvUfQuoKLrupHisqxC = value;
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					return WQLNEzkvgrQVJvBbAHeJmweWstac;
				}
				set
				{
					WQLNEzkvgrQVJvBbAHeJmweWstac = value;
					if (WQLNEzkvgrQVJvBbAHeJmweWstac is IControllerVibrator)
					{
						BbNFOInRutzvUfQuoKLrupHisqxC = true;
					}
				}
			}

			public int buttonCount => OdaJjeQigEMNgWNZfTorPfEeAmqGA.Length;

			public int axisCount => UjYafilPHCpmjkQQEknAkEWSyVEv.Length;

			protected Joystick(string P_0, long P_1, int P_2, int P_3)
				: this(P_0, P_1, 0, P_2, P_3)
			{
			}

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
				UrQFgzuzxuGdfseVuRevVPndzHhX = P_1;
				iSWhDgfQnqUgHKaRfeKOvCXIfHOZ = P_2;
				UjYafilPHCpmjkQQEknAkEWSyVEv = new Axis[P_3];
				OdaJjeQigEMNgWNZfTorPfEeAmqGA = new Button[P_4];
				for (int i = 0; i < P_3; i++)
				{
					UjYafilPHCpmjkQQEknAkEWSyVEv[i] = new Axis();
				}
				for (int j = 0; j < P_4; j++)
				{
					OdaJjeQigEMNgWNZfTorPfEeAmqGA[j] = new Button();
				}
				pfKGfsSASeBhIHbKxMpcxtIuRWXoA = new ReadOnlyCollection<Axis>(UjYafilPHCpmjkQQEknAkEWSyVEv);
				YTPRiwwwAUpZfphkYTmOPhuQqppp = new ReadOnlyCollection<Button>(OdaJjeQigEMNgWNZfTorPfEeAmqGA);
			}

			public virtual float GetAxisValue(int index)
			{
				if (index < 0 || index >= UjYafilPHCpmjkQQEknAkEWSyVEv.Length)
				{
					return 0f;
				}
				return UjYafilPHCpmjkQQEknAkEWSyVEv[index].value;
			}

			public virtual bool GetButtonValue(int index)
			{
				if (index < 0 || index >= OdaJjeQigEMNgWNZfTorPfEeAmqGA.Length)
				{
					return false;
				}
				return OdaJjeQigEMNgWNZfTorPfEeAmqGA[index].boolValue;
			}

			public virtual float GetButtonFloatValue(int index)
			{
				if (index < 0 || index >= OdaJjeQigEMNgWNZfTorPfEeAmqGA.Length)
				{
					return 0f;
				}
				return OdaJjeQigEMNgWNZfTorPfEeAmqGA[index].floatValue;
			}

			public virtual void SetAxisValue(int index, float value)
			{
				if (index >= 0 && index < UjYafilPHCpmjkQQEknAkEWSyVEv.Length)
				{
					UjYafilPHCpmjkQQEknAkEWSyVEv[index].value = value;
				}
			}

			public virtual void SetButtonValue(int index, bool value)
			{
				if (index >= 0 && index < OdaJjeQigEMNgWNZfTorPfEeAmqGA.Length)
				{
					OdaJjeQigEMNgWNZfTorPfEeAmqGA[index].boolValue = value;
				}
			}

			public virtual void SetButtonFloatValue(int index, float value)
			{
				if (index >= 0 && index < OdaJjeQigEMNgWNZfTorPfEeAmqGA.Length)
				{
					OdaJjeQigEMNgWNZfTorPfEeAmqGA[index].floatValue = value;
				}
			}

			internal void anJpKhKcqGVLJivUEsqvvkloyCCK(int P_0, out bool P_1, out float P_2)
			{
				if (P_0 < 0 || P_0 >= OdaJjeQigEMNgWNZfTorPfEeAmqGA.Length)
				{
					P_1 = false;
					P_2 = 0f;
				}
				else
				{
					P_1 = OdaJjeQigEMNgWNZfTorPfEeAmqGA[P_0].DtACBpjlDtMUvEpbhfIbhLcDrNYkc;
					P_2 = OdaJjeQigEMNgWNZfTorPfEeAmqGA[P_0].floatValue;
				}
			}

			internal virtual void jXjAOOeiVexXqEZIVMalnsxHhMjC()
			{
				for (int i = 0; i < OdaJjeQigEMNgWNZfTorPfEeAmqGA.Length; i++)
				{
					if (OdaJjeQigEMNgWNZfTorPfEeAmqGA[i] != null)
					{
						OdaJjeQigEMNgWNZfTorPfEeAmqGA[i].ClPrdWlMkAJqdXVwvnAyedBhuAtU();
					}
				}
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
			[Obsolete("Deprecated. Use boolValue instead.", false)]
			public bool value;

			private float tcEePuPbKcZGLzgHVsnqQGDFQQkR;

			private bool UvGDTYEHznICNvEQcXnzacwyITXK;

			public bool boolValue
			{
				get
				{
					return value;
				}
				set
				{
					_ = this.value;
					if (!this.value && value)
					{
						UvGDTYEHznICNvEQcXnzacwyITXK = true;
					}
					this.value = value;
				}
			}

			public float floatValue
			{
				get
				{
					return tcEePuPbKcZGLzgHVsnqQGDFQQkR;
				}
				set
				{
					tcEePuPbKcZGLzgHVsnqQGDFQQkR = value;
				}
			}

			internal bool DtACBpjlDtMUvEpbhfIbhLcDrNYkc
			{
				get
				{
					if (!value)
					{
						return UvGDTYEHznICNvEQcXnzacwyITXK;
					}
					return true;
				}
			}

			internal void ClPrdWlMkAJqdXVwvnAyedBhuAtU()
			{
				UvGDTYEHznICNvEQcXnzacwyITXK = false;
			}
		}

		private readonly InputSource hWoOjrMwwhhWVgIDpOrhfolzfewCA;

		private readonly List<Joystick> DhCEZWMmNNCyByoLLdIBhZWFHCto;

		private readonly ReadOnlyCollection<Joystick> eaKlbkgjELTnMLzWnDEDkdWMKmaN;

		private bool OSnottoqErbSsVnGLSltqKtALrad = true;

		private IUnifiedKeyboardSource qszYhBKYFzgBszbQbaRHePiAsvIEA;

		private IUnifiedMouseSource UPjDJGjonDDDubwSDeLQAdGwPVoIc;

		[CompilerGenerated]
		private Action m_ShuNmIXdFwKArrEoVBiKcsKerrFA;

		[CompilerGenerated]
		private Action m_ApmnHNyUUUnNwbhBdtMpdMDgqQhm;

		private bool idxLynJUJtkZNypkYDutKmvHOIiH;

		public bool useApproximateMatching
		{
			get
			{
				return OSnottoqErbSsVnGLSltqKtALrad;
			}
			protected set
			{
				OSnottoqErbSsVnGLSltqKtALrad = value;
			}
		}

		internal InputSource bLnaYaOcwMGBBAKowoyPgsxgfIRHB => hWoOjrMwwhhWVgIDpOrhfolzfewCA;

		public abstract bool isReady { get; }

		private event Action ShuNmIXdFwKArrEoVBiKcsKerrFA
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_ShuNmIXdFwKArrEoVBiKcsKerrFA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_ShuNmIXdFwKArrEoVBiKcsKerrFA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_ShuNmIXdFwKArrEoVBiKcsKerrFA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_ShuNmIXdFwKArrEoVBiKcsKerrFA, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		private event Action ApmnHNyUUUnNwbhBdtMpdMDgqQhm
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_ApmnHNyUUUnNwbhBdtMpdMDgqQhm;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_ApmnHNyUUUnNwbhBdtMpdMDgqQhm, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_ApmnHNyUUUnNwbhBdtMpdMDgqQhm;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_ApmnHNyUUUnNwbhBdtMpdMDgqQhm, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		internal event Action PEDundHsobIJDExszbKNoSPTEwBNA
		{
			add
			{
				ShuNmIXdFwKArrEoVBiKcsKerrFA += action;
			}
			remove
			{
				ShuNmIXdFwKArrEoVBiKcsKerrFA -= action;
			}
		}

		internal event Action znSvNANBdcJAKYbCSGxwCPFueizkA
		{
			add
			{
				ApmnHNyUUUnNwbhBdtMpdMDgqQhm += action;
			}
			remove
			{
				ApmnHNyUUUnNwbhBdtMpdMDgqQhm -= action;
			}
		}

		internal IUnifiedKeyboardSource VfDFosXAxNHisBveamNjBMdoEblEA()
		{
			return qszYhBKYFzgBszbQbaRHePiAsvIEA;
		}

		internal IUnifiedMouseSource KNNmHhsEvsKWVztdXBolepStAmgc()
		{
			return UPjDJGjonDDDubwSDeLQAdGwPVoIc;
		}

		public CustomInputSource(int P_0)
		{
			if (!Enum.IsDefined(typeof(InputSource), P_0))
			{
				Logger.LogError("Unknown InputSource (" + P_0 + ")!");
			}
			hWoOjrMwwhhWVgIDpOrhfolzfewCA = (InputSource)P_0;
			DhCEZWMmNNCyByoLLdIBhZWFHCto = new List<Joystick>();
			eaKlbkgjELTnMLzWnDEDkdWMKmaN = new ReadOnlyCollection<Joystick>(DhCEZWMmNNCyByoLLdIBhZWFHCto);
		}

		internal CustomInputSource(int P_0, IUnifiedKeyboardSource P_1, IUnifiedMouseSource P_2)
			: this(P_0)
		{
			qszYhBKYFzgBszbQbaRHePiAsvIEA = P_1;
			UPjDJGjonDDDubwSDeLQAdGwPVoIc = P_2;
		}

		internal virtual void ClXPqQHQbxEYbLGYANIBDPkrIbwHA()
		{
			OnInitialize();
		}

		protected virtual void OnInitialize()
		{
		}

		public void AddJoystick(Joystick joystick)
		{
			if (joystick == null)
			{
				return;
			}
			if (DhCEZWMmNNCyByoLLdIBhZWFHCto.Contains(joystick))
			{
				Logger.LogWarning("The joystick is already in the list. Cannot add again.");
				return;
			}
			DhCEZWMmNNCyByoLLdIBhZWFHCto.Add(joystick);
			joystick.ConnectedStateChangedEvent += TkhmkGPDXRiMcYWrKbnbATYkeIzd;
			if (joystick.isConnected)
			{
				OnJoystickConnected();
			}
		}

		public void RemoveJoystick(Joystick joystick)
		{
			if (joystick == null)
			{
				return;
			}
			if (!DhCEZWMmNNCyByoLLdIBhZWFHCto.Contains(joystick))
			{
				Logger.LogWarning("The joystick was not found in the list. Cannot remove.");
				return;
			}
			DhCEZWMmNNCyByoLLdIBhZWFHCto.Remove(joystick);
			joystick.ConnectedStateChangedEvent -= TkhmkGPDXRiMcYWrKbnbATYkeIzd;
			if (joystick.isConnected)
			{
				OnJoystickDisconnected();
			}
		}

		public IList<Joystick> GetJoysticks()
		{
			return eaKlbkgjELTnMLzWnDEDkdWMKmaN;
		}

		protected virtual void OnJoystickConnected()
		{
			if (this.ShuNmIXdFwKArrEoVBiKcsKerrFA != null)
			{
				this.ShuNmIXdFwKArrEoVBiKcsKerrFA();
			}
		}

		protected virtual void OnJoystickDisconnected()
		{
			if (this.ApmnHNyUUUnNwbhBdtMpdMDgqQhm != null)
			{
				this.ApmnHNyUUUnNwbhBdtMpdMDgqQhm();
			}
		}

		private void TkhmkGPDXRiMcYWrKbnbATYkeIzd(bool P_0)
		{
			if (P_0)
			{
				OnJoystickConnected();
			}
			else
			{
				OnJoystickDisconnected();
			}
		}

		internal Joystick[] TCVGTCmshWaexcHsYzLeunIqYgwIA()
		{
			List<Joystick> list = new List<Joystick>(DhCEZWMmNNCyByoLLdIBhZWFHCto.Count);
			for (int i = 0; i < DhCEZWMmNNCyByoLLdIBhZWFHCto.Count; i++)
			{
				Joystick joystick = DhCEZWMmNNCyByoLLdIBhZWFHCto[i];
				if (joystick != null && joystick.isConnected)
				{
					list.Add(joystick);
				}
			}
			return list.ToArray();
		}

		internal virtual void yJJiJyHClDKYfyDcnimKwpopQEQH()
		{
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
			if (idxLynJUJtkZNypkYDutKmvHOIiH)
			{
				return;
			}
			if (disposing)
			{
				if (qszYhBKYFzgBszbQbaRHePiAsvIEA is IDisposable)
				{
					try
					{
						(qszYhBKYFzgBszbQbaRHePiAsvIEA as IDisposable).Dispose();
					}
					catch (Exception msg)
					{
						Logger.LogError(msg);
					}
				}
				if (UPjDJGjonDDDubwSDeLQAdGwPVoIc is IDisposable)
				{
					try
					{
						(UPjDJGjonDDDubwSDeLQAdGwPVoIc as IDisposable).Dispose();
					}
					catch (Exception msg2)
					{
						Logger.LogError(msg2);
					}
				}
			}
			idxLynJUJtkZNypkYDutKmvHOIiH = true;
		}

		public abstract void Update();
	}
}

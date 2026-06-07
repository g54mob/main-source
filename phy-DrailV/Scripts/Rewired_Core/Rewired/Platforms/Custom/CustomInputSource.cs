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

			private Action<bool> ntiSVwfRntYOJNErmIwKTtqzCBRj;

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
					Action<bool> action = ntiSVwfRntYOJNErmIwKTtqzCBRj;
					if (action == null)
					{
						return;
					}
					try
					{
						action(value);
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
					ntiSVwfRntYOJNErmIwKTtqzCBRj = (Action<bool>)Delegate.Combine(ntiSVwfRntYOJNErmIwKTtqzCBRj, value);
				}
				remove
				{
					ntiSVwfRntYOJNErmIwKTtqzCBRj = (Action<bool>)Delegate.Remove(ntiSVwfRntYOJNErmIwKTtqzCBRj, value);
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
			private long? ClpbIocOfjuVFcRPCslxGKsbMgGS;

			private int XnxPMcDVeYJBWHnXiEncxXfStLbv;

			private readonly Axis[] MNGRtxShqkbjICkiFyeohwkjacEvA;

			private readonly Button[] cmXHQZIxDUukeRCdGAxvuSrRrVmb;

			private readonly ReadOnlyCollection<Axis> EdOFFWWnUbTJOqFSwSejKneKmZV;

			private readonly ReadOnlyCollection<Button> JWDZHTCtclgWxkfZDspagfjemahf;

			private bool eOQMBxZDovuMPZyZcDkTHGyJSrJh;

			private Rewired.Controller.Extension OFqIbfCUNqUzQiOnvNfKvZuUmZBo;

			public long? systemId
			{
				get
				{
					return ClpbIocOfjuVFcRPCslxGKsbMgGS;
				}
				protected set
				{
					ClpbIocOfjuVFcRPCslxGKsbMgGS = value;
				}
			}

			public int unityId
			{
				get
				{
					return XnxPMcDVeYJBWHnXiEncxXfStLbv;
				}
				protected set
				{
					XnxPMcDVeYJBWHnXiEncxXfStLbv = value;
				}
			}

			public IList<Axis> Axes => EdOFFWWnUbTJOqFSwSejKneKmZV;

			public IList<Button> Buttons => JWDZHTCtclgWxkfZDspagfjemahf;

			public bool supportsVibration
			{
				get
				{
					return eOQMBxZDovuMPZyZcDkTHGyJSrJh;
				}
				set
				{
					eOQMBxZDovuMPZyZcDkTHGyJSrJh = value;
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					return OFqIbfCUNqUzQiOnvNfKvZuUmZBo;
				}
				set
				{
					OFqIbfCUNqUzQiOnvNfKvZuUmZBo = value;
					if (OFqIbfCUNqUzQiOnvNfKvZuUmZBo is IControllerVibrator)
					{
						eOQMBxZDovuMPZyZcDkTHGyJSrJh = true;
					}
				}
			}

			public int buttonCount => cmXHQZIxDUukeRCdGAxvuSrRrVmb.Length;

			public int axisCount => MNGRtxShqkbjICkiFyeohwkjacEvA.Length;

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
				ClpbIocOfjuVFcRPCslxGKsbMgGS = P_1;
				XnxPMcDVeYJBWHnXiEncxXfStLbv = P_2;
				MNGRtxShqkbjICkiFyeohwkjacEvA = new Axis[P_3];
				cmXHQZIxDUukeRCdGAxvuSrRrVmb = new Button[P_4];
				for (int i = 0; i < P_3; i++)
				{
					MNGRtxShqkbjICkiFyeohwkjacEvA[i] = new Axis();
				}
				for (int j = 0; j < P_4; j++)
				{
					cmXHQZIxDUukeRCdGAxvuSrRrVmb[j] = new Button();
				}
				EdOFFWWnUbTJOqFSwSejKneKmZV = new ReadOnlyCollection<Axis>(MNGRtxShqkbjICkiFyeohwkjacEvA);
				JWDZHTCtclgWxkfZDspagfjemahf = new ReadOnlyCollection<Button>(cmXHQZIxDUukeRCdGAxvuSrRrVmb);
			}

			public virtual float GetAxisValue(int index)
			{
				if (index < 0 || index >= MNGRtxShqkbjICkiFyeohwkjacEvA.Length)
				{
					return 0f;
				}
				return MNGRtxShqkbjICkiFyeohwkjacEvA[index].value;
			}

			public virtual bool GetButtonValue(int index)
			{
				if (index < 0 || index >= cmXHQZIxDUukeRCdGAxvuSrRrVmb.Length)
				{
					return false;
				}
				return cmXHQZIxDUukeRCdGAxvuSrRrVmb[index].boolValue;
			}

			public virtual float GetButtonFloatValue(int index)
			{
				if (index < 0 || index >= cmXHQZIxDUukeRCdGAxvuSrRrVmb.Length)
				{
					return 0f;
				}
				return cmXHQZIxDUukeRCdGAxvuSrRrVmb[index].floatValue;
			}

			public virtual void SetAxisValue(int index, float value)
			{
				if (index >= 0 && index < MNGRtxShqkbjICkiFyeohwkjacEvA.Length)
				{
					MNGRtxShqkbjICkiFyeohwkjacEvA[index].value = value;
				}
			}

			public virtual void SetButtonValue(int index, bool value)
			{
				if (index >= 0 && index < cmXHQZIxDUukeRCdGAxvuSrRrVmb.Length)
				{
					cmXHQZIxDUukeRCdGAxvuSrRrVmb[index].boolValue = value;
				}
			}

			public virtual void SetButtonFloatValue(int index, float value)
			{
				if (index >= 0 && index < cmXHQZIxDUukeRCdGAxvuSrRrVmb.Length)
				{
					cmXHQZIxDUukeRCdGAxvuSrRrVmb[index].floatValue = value;
				}
			}

			internal void FsGdhSEhMGjXNdbYItAJZWIAjGZkb(int P_0, out bool P_1, out float P_2)
			{
				if (P_0 < 0 || P_0 >= cmXHQZIxDUukeRCdGAxvuSrRrVmb.Length)
				{
					P_1 = false;
					P_2 = 0f;
				}
				else
				{
					P_1 = cmXHQZIxDUukeRCdGAxvuSrRrVmb[P_0].mqCccCzYneTNCxkJcnLcaeYtWNRj;
					P_2 = cmXHQZIxDUukeRCdGAxvuSrRrVmb[P_0].floatValue;
				}
			}

			internal virtual void bxYiqDXXeENnZsQaaUdUCxkYeQOq()
			{
				for (int i = 0; i < cmXHQZIxDUukeRCdGAxvuSrRrVmb.Length; i++)
				{
					if (cmXHQZIxDUukeRCdGAxvuSrRrVmb[i] != null)
					{
						cmXHQZIxDUukeRCdGAxvuSrRrVmb[i].WhtIakgWUZoLwcMgqgKkCszheDfBA();
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

			private float iDNNWKrYkOjFPlBAAxSmEoLxEAoK;

			private bool FeLAMmTNtzpmQkEOZaZkoMrJKeCW;

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
						FeLAMmTNtzpmQkEOZaZkoMrJKeCW = true;
					}
					this.value = value;
				}
			}

			public float floatValue
			{
				get
				{
					return iDNNWKrYkOjFPlBAAxSmEoLxEAoK;
				}
				set
				{
					iDNNWKrYkOjFPlBAAxSmEoLxEAoK = value;
				}
			}

			internal bool mqCccCzYneTNCxkJcnLcaeYtWNRj
			{
				get
				{
					if (!value)
					{
						return FeLAMmTNtzpmQkEOZaZkoMrJKeCW;
					}
					return true;
				}
			}

			internal void WhtIakgWUZoLwcMgqgKkCszheDfBA()
			{
				FeLAMmTNtzpmQkEOZaZkoMrJKeCW = false;
			}
		}

		private readonly InputSource OzvdYbGIWbBMHriJhAscgDbndRAX;

		private readonly List<Joystick> PmJeDnpQDGJjjDwWldGyhwglhuhs;

		private readonly ReadOnlyCollection<Joystick> msaYNvNvUKlWnwZPYdYttkPqVqWJ;

		private bool eaFFxsHFdzuYTTpYJreXZBcBZvKH = true;

		private IUnifiedKeyboardSource PzCGgWIamxzzSMcCojDohlTbTTqTb;

		private IUnifiedMouseSource vXGhHLNKblfcbAJFWpwHMnLSDRar;

		[CompilerGenerated]
		private Action m_XltYmaTEzgnHVGadWgpoCIPBiuIi;

		[CompilerGenerated]
		private Action m_kQoMiMORdhhZbXmsTfBujiqOcGsl;

		private bool wFtxnVROnubhehGUBaPWAtQsiPAD;

		public bool useApproximateMatching
		{
			get
			{
				return eaFFxsHFdzuYTTpYJreXZBcBZvKH;
			}
			protected set
			{
				eaFFxsHFdzuYTTpYJreXZBcBZvKH = value;
			}
		}

		internal InputSource JNMBmPSsDBEFBkOLyoQWUaGjLnyvA => OzvdYbGIWbBMHriJhAscgDbndRAX;

		public abstract bool isReady { get; }

		private event Action XltYmaTEzgnHVGadWgpoCIPBiuIi
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_XltYmaTEzgnHVGadWgpoCIPBiuIi;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_XltYmaTEzgnHVGadWgpoCIPBiuIi, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_XltYmaTEzgnHVGadWgpoCIPBiuIi;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_XltYmaTEzgnHVGadWgpoCIPBiuIi, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		private event Action kQoMiMORdhhZbXmsTfBujiqOcGsl
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_kQoMiMORdhhZbXmsTfBujiqOcGsl;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_kQoMiMORdhhZbXmsTfBujiqOcGsl, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_kQoMiMORdhhZbXmsTfBujiqOcGsl;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_kQoMiMORdhhZbXmsTfBujiqOcGsl, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		internal event Action utcbOSfIUgHkpApnzrrYIirhDhVCb
		{
			add
			{
				XltYmaTEzgnHVGadWgpoCIPBiuIi += action;
			}
			remove
			{
				XltYmaTEzgnHVGadWgpoCIPBiuIi -= action;
			}
		}

		internal event Action BFpjGlqLjXCgxIDjCiyfgLkbIHgRB
		{
			add
			{
				kQoMiMORdhhZbXmsTfBujiqOcGsl += action;
			}
			remove
			{
				kQoMiMORdhhZbXmsTfBujiqOcGsl -= action;
			}
		}

		internal IUnifiedKeyboardSource ufjIvKCyejCncZnncxoHsJXMAdU()
		{
			return PzCGgWIamxzzSMcCojDohlTbTTqTb;
		}

		internal IUnifiedMouseSource IIhpAaXiKsDxxPRINWMLIdgMdsoS()
		{
			return vXGhHLNKblfcbAJFWpwHMnLSDRar;
		}

		public CustomInputSource(int P_0)
		{
			if (!Enum.IsDefined(typeof(InputSource), P_0))
			{
				Logger.LogError("Unknown InputSource (" + P_0 + ")!");
			}
			OzvdYbGIWbBMHriJhAscgDbndRAX = (InputSource)P_0;
			PmJeDnpQDGJjjDwWldGyhwglhuhs = new List<Joystick>();
			msaYNvNvUKlWnwZPYdYttkPqVqWJ = new ReadOnlyCollection<Joystick>(PmJeDnpQDGJjjDwWldGyhwglhuhs);
		}

		internal CustomInputSource(int P_0, IUnifiedKeyboardSource P_1, IUnifiedMouseSource P_2)
			: this(P_0)
		{
			PzCGgWIamxzzSMcCojDohlTbTTqTb = P_1;
			vXGhHLNKblfcbAJFWpwHMnLSDRar = P_2;
		}

		internal virtual void TlzckGoQDITHcUYaslQXPQBOhTwq()
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
			if (PmJeDnpQDGJjjDwWldGyhwglhuhs.Contains(joystick))
			{
				Logger.LogWarning("The joystick is already in the list. Cannot add again.");
				return;
			}
			PmJeDnpQDGJjjDwWldGyhwglhuhs.Add(joystick);
			joystick.ConnectedStateChangedEvent += nXESuuVNcXfKIewAKwYGJoGTZfcoA;
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
			if (!PmJeDnpQDGJjjDwWldGyhwglhuhs.Contains(joystick))
			{
				Logger.LogWarning("The joystick was not found in the list. Cannot remove.");
				return;
			}
			PmJeDnpQDGJjjDwWldGyhwglhuhs.Remove(joystick);
			joystick.ConnectedStateChangedEvent -= nXESuuVNcXfKIewAKwYGJoGTZfcoA;
			if (joystick.isConnected)
			{
				OnJoystickDisconnected();
			}
		}

		public IList<Joystick> GetJoysticks()
		{
			return msaYNvNvUKlWnwZPYdYttkPqVqWJ;
		}

		protected virtual void OnJoystickConnected()
		{
			if (this.XltYmaTEzgnHVGadWgpoCIPBiuIi != null)
			{
				this.XltYmaTEzgnHVGadWgpoCIPBiuIi();
			}
		}

		protected virtual void OnJoystickDisconnected()
		{
			if (this.kQoMiMORdhhZbXmsTfBujiqOcGsl != null)
			{
				this.kQoMiMORdhhZbXmsTfBujiqOcGsl();
			}
		}

		private void nXESuuVNcXfKIewAKwYGJoGTZfcoA(bool P_0)
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

		internal Joystick[] nQJGOcXPfsgelZsYveOAHeAYhGIi()
		{
			List<Joystick> list = new List<Joystick>(PmJeDnpQDGJjjDwWldGyhwglhuhs.Count);
			for (int i = 0; i < PmJeDnpQDGJjjDwWldGyhwglhuhs.Count; i++)
			{
				Joystick joystick = PmJeDnpQDGJjjDwWldGyhwglhuhs[i];
				if (joystick != null && joystick.isConnected)
				{
					list.Add(joystick);
				}
			}
			return list.ToArray();
		}

		internal virtual void cwOErHdoGDKEsFmyGHskstVlrOhbB()
		{
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
			if (wFtxnVROnubhehGUBaPWAtQsiPAD)
			{
				return;
			}
			if (disposing)
			{
				if (PzCGgWIamxzzSMcCojDohlTbTTqTb is IDisposable)
				{
					try
					{
						(PzCGgWIamxzzSMcCojDohlTbTTqTb as IDisposable).Dispose();
					}
					catch (Exception msg)
					{
						Logger.LogError(msg);
					}
				}
				if (vXGhHLNKblfcbAJFWpwHMnLSDRar is IDisposable)
				{
					try
					{
						(vXGhHLNKblfcbAJFWpwHMnLSDRar as IDisposable).Dispose();
					}
					catch (Exception msg2)
					{
						Logger.LogError(msg2);
					}
				}
			}
			wFtxnVROnubhehGUBaPWAtQsiPAD = true;
		}

		public abstract void Update();
	}
}

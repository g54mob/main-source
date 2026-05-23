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

			private Action<bool> eWAXWkwgVYTTDFAbSYtobaHDsfkH;

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
					Action<bool> action = eWAXWkwgVYTTDFAbSYtobaHDsfkH;
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
					eWAXWkwgVYTTDFAbSYtobaHDsfkH = (Action<bool>)Delegate.Combine(eWAXWkwgVYTTDFAbSYtobaHDsfkH, value);
				}
				remove
				{
					eWAXWkwgVYTTDFAbSYtobaHDsfkH = (Action<bool>)Delegate.Remove(eWAXWkwgVYTTDFAbSYtobaHDsfkH, value);
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
			private long? rhgCLGjOGgIqWFywCFLlDWMTkAmob;

			private int JVyImNJYBkDCuABwSxASuUwPECZh;

			private readonly Axis[] pcvEZDPaEflMkonpmAAfhrcZGFzB;

			private readonly Button[] jVQgYPgsHYsAXrEcWAFlWAhpVhzY;

			private readonly ReadOnlyCollection<Axis> GugbWFwLjadcdCfpGjIovopbkNUEb;

			private readonly ReadOnlyCollection<Button> jExxLXMMzOeWGtrDrvTSWrLTmuqW;

			private bool kRvcwlPMupcCxhshBbCjpAUvbzsR;

			private Rewired.Controller.Extension bdxEwlYxQfuTsvsynrywjtFZjbaM;

			public long? systemId
			{
				get
				{
					return rhgCLGjOGgIqWFywCFLlDWMTkAmob;
				}
				protected set
				{
					rhgCLGjOGgIqWFywCFLlDWMTkAmob = value;
				}
			}

			public int unityId
			{
				get
				{
					return JVyImNJYBkDCuABwSxASuUwPECZh;
				}
				protected set
				{
					JVyImNJYBkDCuABwSxASuUwPECZh = value;
				}
			}

			public IList<Axis> Axes => GugbWFwLjadcdCfpGjIovopbkNUEb;

			public IList<Button> Buttons => jExxLXMMzOeWGtrDrvTSWrLTmuqW;

			public bool supportsVibration
			{
				get
				{
					return kRvcwlPMupcCxhshBbCjpAUvbzsR;
				}
				set
				{
					kRvcwlPMupcCxhshBbCjpAUvbzsR = value;
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					return bdxEwlYxQfuTsvsynrywjtFZjbaM;
				}
				set
				{
					bdxEwlYxQfuTsvsynrywjtFZjbaM = value;
					if (bdxEwlYxQfuTsvsynrywjtFZjbaM is IControllerVibrator)
					{
						kRvcwlPMupcCxhshBbCjpAUvbzsR = true;
					}
				}
			}

			public int buttonCount => jVQgYPgsHYsAXrEcWAFlWAhpVhzY.Length;

			public int axisCount => pcvEZDPaEflMkonpmAAfhrcZGFzB.Length;

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
				rhgCLGjOGgIqWFywCFLlDWMTkAmob = P_1;
				JVyImNJYBkDCuABwSxASuUwPECZh = P_2;
				pcvEZDPaEflMkonpmAAfhrcZGFzB = new Axis[P_3];
				jVQgYPgsHYsAXrEcWAFlWAhpVhzY = new Button[P_4];
				for (int i = 0; i < P_3; i++)
				{
					pcvEZDPaEflMkonpmAAfhrcZGFzB[i] = new Axis();
				}
				for (int j = 0; j < P_4; j++)
				{
					jVQgYPgsHYsAXrEcWAFlWAhpVhzY[j] = new Button();
				}
				GugbWFwLjadcdCfpGjIovopbkNUEb = new ReadOnlyCollection<Axis>(pcvEZDPaEflMkonpmAAfhrcZGFzB);
				jExxLXMMzOeWGtrDrvTSWrLTmuqW = new ReadOnlyCollection<Button>(jVQgYPgsHYsAXrEcWAFlWAhpVhzY);
			}

			public virtual float GetAxisValue(int index)
			{
				if (index < 0 || index >= pcvEZDPaEflMkonpmAAfhrcZGFzB.Length)
				{
					return 0f;
				}
				return pcvEZDPaEflMkonpmAAfhrcZGFzB[index].value;
			}

			public virtual bool GetButtonValue(int index)
			{
				if (index < 0 || index >= jVQgYPgsHYsAXrEcWAFlWAhpVhzY.Length)
				{
					return false;
				}
				return jVQgYPgsHYsAXrEcWAFlWAhpVhzY[index].boolValue;
			}

			public virtual float GetButtonFloatValue(int index)
			{
				if (index < 0 || index >= jVQgYPgsHYsAXrEcWAFlWAhpVhzY.Length)
				{
					return 0f;
				}
				return jVQgYPgsHYsAXrEcWAFlWAhpVhzY[index].floatValue;
			}

			public virtual void SetAxisValue(int index, float value)
			{
				if (index >= 0 && index < pcvEZDPaEflMkonpmAAfhrcZGFzB.Length)
				{
					pcvEZDPaEflMkonpmAAfhrcZGFzB[index].value = value;
				}
			}

			public virtual void SetButtonValue(int index, bool value)
			{
				if (index >= 0 && index < jVQgYPgsHYsAXrEcWAFlWAhpVhzY.Length)
				{
					jVQgYPgsHYsAXrEcWAFlWAhpVhzY[index].boolValue = value;
				}
			}

			public virtual void SetButtonFloatValue(int index, float value)
			{
				if (index >= 0 && index < jVQgYPgsHYsAXrEcWAFlWAhpVhzY.Length)
				{
					jVQgYPgsHYsAXrEcWAFlWAhpVhzY[index].floatValue = value;
				}
			}

			internal void JafKEWccZWCEqaqrhtFtsEYjJfLW(int P_0, out bool P_1, out float P_2)
			{
				if (P_0 < 0 || P_0 >= jVQgYPgsHYsAXrEcWAFlWAhpVhzY.Length)
				{
					P_1 = false;
					P_2 = 0f;
				}
				else
				{
					P_1 = jVQgYPgsHYsAXrEcWAFlWAhpVhzY[P_0].saqncOFmcluZCrECIufbIWLetCZy;
					P_2 = jVQgYPgsHYsAXrEcWAFlWAhpVhzY[P_0].floatValue;
				}
			}

			internal virtual void UPHCvhWpNgGmuMtugfpncxPIRkon()
			{
				for (int i = 0; i < jVQgYPgsHYsAXrEcWAFlWAhpVhzY.Length; i++)
				{
					if (jVQgYPgsHYsAXrEcWAFlWAhpVhzY[i] != null)
					{
						jVQgYPgsHYsAXrEcWAFlWAhpVhzY[i].dixXAxVwBMnxYRiVCavqvngsLQwJ();
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

			private float WqisHFbfByRCuvkWuMryVuTGHvfd;

			private bool vwiwJjgvGpLgidgdDgatpAJfETCDA;

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
						vwiwJjgvGpLgidgdDgatpAJfETCDA = true;
					}
					this.value = value;
				}
			}

			public float floatValue
			{
				get
				{
					return WqisHFbfByRCuvkWuMryVuTGHvfd;
				}
				set
				{
					WqisHFbfByRCuvkWuMryVuTGHvfd = value;
				}
			}

			internal bool saqncOFmcluZCrECIufbIWLetCZy
			{
				get
				{
					if (!value)
					{
						return vwiwJjgvGpLgidgdDgatpAJfETCDA;
					}
					return true;
				}
			}

			internal void dixXAxVwBMnxYRiVCavqvngsLQwJ()
			{
				vwiwJjgvGpLgidgdDgatpAJfETCDA = false;
			}
		}

		private readonly InputSource QxYXGIwFRzzZskYiIOSzkYIipufj;

		private readonly List<Joystick> aQuDwpewyDNpatkwoHrBCklMjVmDb;

		private readonly ReadOnlyCollection<Joystick> FvaeQFgIxVGuxCFxCKdBLvhRJbtdB;

		private bool pZDRXUSBHfaAZXPWczrljvxTYEhF = true;

		private IUnifiedKeyboardSource HBTQMosKetbKDCrnKwiDsEZTasZKA;

		private IUnifiedMouseSource zDJeezUYWDSUHwdhFFkSoQtMLIlX;

		[CompilerGenerated]
		private Action m_zIDkVJiBWTVfllDlXikuJSLBmaoq;

		[CompilerGenerated]
		private Action m_ndKvaqQInCfEDdJmSWdhoRgfHpkv;

		private bool TPLwmQfJmntXywCLzelfPjQYPXvK;

		public bool useApproximateMatching
		{
			get
			{
				return pZDRXUSBHfaAZXPWczrljvxTYEhF;
			}
			protected set
			{
				pZDRXUSBHfaAZXPWczrljvxTYEhF = value;
			}
		}

		internal InputSource UBbrNuHNAOPoYVpJFeDjfSwRqCj => QxYXGIwFRzzZskYiIOSzkYIipufj;

		public abstract bool isReady { get; }

		private event Action zIDkVJiBWTVfllDlXikuJSLBmaoq
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_zIDkVJiBWTVfllDlXikuJSLBmaoq;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_zIDkVJiBWTVfllDlXikuJSLBmaoq, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_zIDkVJiBWTVfllDlXikuJSLBmaoq;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_zIDkVJiBWTVfllDlXikuJSLBmaoq, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		private event Action ndKvaqQInCfEDdJmSWdhoRgfHpkv
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_ndKvaqQInCfEDdJmSWdhoRgfHpkv;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_ndKvaqQInCfEDdJmSWdhoRgfHpkv, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_ndKvaqQInCfEDdJmSWdhoRgfHpkv;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_ndKvaqQInCfEDdJmSWdhoRgfHpkv, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		internal event Action oNvoGGbDJblCgrLPUWfBTbwANtUU
		{
			add
			{
				zIDkVJiBWTVfllDlXikuJSLBmaoq += action;
			}
			remove
			{
				zIDkVJiBWTVfllDlXikuJSLBmaoq -= action;
			}
		}

		internal event Action GiREvAnIBmXviKvGhMDyHyTjlBae
		{
			add
			{
				ndKvaqQInCfEDdJmSWdhoRgfHpkv += action;
			}
			remove
			{
				ndKvaqQInCfEDdJmSWdhoRgfHpkv -= action;
			}
		}

		internal IUnifiedKeyboardSource sMlcFzxGJhzRyPBLoqhjYWrIacIA()
		{
			return HBTQMosKetbKDCrnKwiDsEZTasZKA;
		}

		internal IUnifiedMouseSource pZdBVaUjniuFnvHCmEeeCzCqaLzbb()
		{
			return zDJeezUYWDSUHwdhFFkSoQtMLIlX;
		}

		public CustomInputSource(int P_0)
		{
			if (!Enum.IsDefined(typeof(InputSource), P_0))
			{
				Logger.LogError("Unknown InputSource (" + P_0 + ")!");
			}
			QxYXGIwFRzzZskYiIOSzkYIipufj = (InputSource)P_0;
			aQuDwpewyDNpatkwoHrBCklMjVmDb = new List<Joystick>();
			FvaeQFgIxVGuxCFxCKdBLvhRJbtdB = new ReadOnlyCollection<Joystick>(aQuDwpewyDNpatkwoHrBCklMjVmDb);
		}

		internal CustomInputSource(int P_0, IUnifiedKeyboardSource P_1, IUnifiedMouseSource P_2)
			: this(P_0)
		{
			HBTQMosKetbKDCrnKwiDsEZTasZKA = P_1;
			zDJeezUYWDSUHwdhFFkSoQtMLIlX = P_2;
		}

		internal virtual void dipzRrboOzPXSHQrvmpVGGDsZefo()
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
			if (aQuDwpewyDNpatkwoHrBCklMjVmDb.Contains(joystick))
			{
				Logger.LogWarning("The joystick is already in the list. Cannot add again.");
				return;
			}
			aQuDwpewyDNpatkwoHrBCklMjVmDb.Add(joystick);
			joystick.ConnectedStateChangedEvent += cjHBHnpQyNfhXIyvpfWtPcgtCbmgA;
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
			if (!aQuDwpewyDNpatkwoHrBCklMjVmDb.Contains(joystick))
			{
				Logger.LogWarning("The joystick was not found in the list. Cannot remove.");
				return;
			}
			aQuDwpewyDNpatkwoHrBCklMjVmDb.Remove(joystick);
			joystick.ConnectedStateChangedEvent -= cjHBHnpQyNfhXIyvpfWtPcgtCbmgA;
			if (joystick.isConnected)
			{
				OnJoystickDisconnected();
			}
		}

		public IList<Joystick> GetJoysticks()
		{
			return FvaeQFgIxVGuxCFxCKdBLvhRJbtdB;
		}

		protected virtual void OnJoystickConnected()
		{
			if (this.zIDkVJiBWTVfllDlXikuJSLBmaoq != null)
			{
				this.zIDkVJiBWTVfllDlXikuJSLBmaoq();
			}
		}

		protected virtual void OnJoystickDisconnected()
		{
			if (this.ndKvaqQInCfEDdJmSWdhoRgfHpkv != null)
			{
				this.ndKvaqQInCfEDdJmSWdhoRgfHpkv();
			}
		}

		private void cjHBHnpQyNfhXIyvpfWtPcgtCbmgA(bool P_0)
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

		internal Joystick[] cRxAkxCSAWSjOHLBrFyedupAtzpIB()
		{
			List<Joystick> list = new List<Joystick>(aQuDwpewyDNpatkwoHrBCklMjVmDb.Count);
			for (int i = 0; i < aQuDwpewyDNpatkwoHrBCklMjVmDb.Count; i++)
			{
				Joystick joystick = aQuDwpewyDNpatkwoHrBCklMjVmDb[i];
				if (joystick != null && joystick.isConnected)
				{
					list.Add(joystick);
				}
			}
			return list.ToArray();
		}

		internal virtual void BEfVFJbaEZHDUohPIZLChbFkiDBZ()
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
			if (TPLwmQfJmntXywCLzelfPjQYPXvK)
			{
				return;
			}
			if (disposing)
			{
				if (HBTQMosKetbKDCrnKwiDsEZTasZKA is IDisposable)
				{
					try
					{
						(HBTQMosKetbKDCrnKwiDsEZTasZKA as IDisposable).Dispose();
					}
					catch (Exception msg)
					{
						Logger.LogError(msg);
					}
				}
				if (zDJeezUYWDSUHwdhFFkSoQtMLIlX is IDisposable)
				{
					try
					{
						(zDJeezUYWDSUHwdhFFkSoQtMLIlX as IDisposable).Dispose();
					}
					catch (Exception msg2)
					{
						Logger.LogError(msg2);
					}
				}
			}
			TPLwmQfJmntXywCLzelfPjQYPXvK = true;
		}

		public abstract void Update();
	}
}

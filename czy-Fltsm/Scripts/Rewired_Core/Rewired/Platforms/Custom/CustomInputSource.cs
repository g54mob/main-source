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

			private Action<bool> HUgimKcRIOKbUaFsmdeLzxufGcfT;

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
					Action<bool> hUgimKcRIOKbUaFsmdeLzxufGcfT = HUgimKcRIOKbUaFsmdeLzxufGcfT;
					if (hUgimKcRIOKbUaFsmdeLzxufGcfT == null)
					{
						return;
					}
					try
					{
						hUgimKcRIOKbUaFsmdeLzxufGcfT(value);
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
					HUgimKcRIOKbUaFsmdeLzxufGcfT = (Action<bool>)Delegate.Combine(HUgimKcRIOKbUaFsmdeLzxufGcfT, value);
				}
				remove
				{
					HUgimKcRIOKbUaFsmdeLzxufGcfT = (Action<bool>)Delegate.Remove(HUgimKcRIOKbUaFsmdeLzxufGcfT, value);
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
			private long? AWOdakcAVgQbJoVhrnfKCKnIYWhqB;

			private int gUAxCnReFmSijxgtkeLnqEHrhEMAA;

			private readonly Axis[] UJOlbrRltGoQVLmAXaUpvEmnCdYC;

			private readonly Button[] OIcczfuGMYyTSnlzahfSHCWBZlqiA;

			private readonly ReadOnlyCollection<Axis> beEjxfHmesMtwSIeeKwNCsWiBJJlc;

			private readonly ReadOnlyCollection<Button> WRDVutYwyQPJFYJKBidlEQyrckzcA;

			private bool DfVBUFBnxpnXgWyMlBNSzhyBzgvD;

			private Rewired.Controller.Extension YOLXoLObJlQrpUgtHJIPdRujPfdV;

			public long? systemId
			{
				get
				{
					return AWOdakcAVgQbJoVhrnfKCKnIYWhqB;
				}
				protected set
				{
					AWOdakcAVgQbJoVhrnfKCKnIYWhqB = value;
				}
			}

			public int unityId
			{
				get
				{
					return gUAxCnReFmSijxgtkeLnqEHrhEMAA;
				}
				protected set
				{
					gUAxCnReFmSijxgtkeLnqEHrhEMAA = value;
				}
			}

			public IList<Axis> Axes => beEjxfHmesMtwSIeeKwNCsWiBJJlc;

			public IList<Button> Buttons => WRDVutYwyQPJFYJKBidlEQyrckzcA;

			public bool supportsVibration
			{
				get
				{
					return DfVBUFBnxpnXgWyMlBNSzhyBzgvD;
				}
				set
				{
					DfVBUFBnxpnXgWyMlBNSzhyBzgvD = value;
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					return YOLXoLObJlQrpUgtHJIPdRujPfdV;
				}
				set
				{
					YOLXoLObJlQrpUgtHJIPdRujPfdV = value;
					if (YOLXoLObJlQrpUgtHJIPdRujPfdV is IControllerVibrator)
					{
						DfVBUFBnxpnXgWyMlBNSzhyBzgvD = true;
					}
				}
			}

			public int buttonCount => OIcczfuGMYyTSnlzahfSHCWBZlqiA.Length;

			public int axisCount => UJOlbrRltGoQVLmAXaUpvEmnCdYC.Length;

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
				AWOdakcAVgQbJoVhrnfKCKnIYWhqB = P_1;
				gUAxCnReFmSijxgtkeLnqEHrhEMAA = P_2;
				UJOlbrRltGoQVLmAXaUpvEmnCdYC = new Axis[P_3];
				OIcczfuGMYyTSnlzahfSHCWBZlqiA = new Button[P_4];
				for (int i = 0; i < P_3; i++)
				{
					UJOlbrRltGoQVLmAXaUpvEmnCdYC[i] = new Axis();
				}
				for (int j = 0; j < P_4; j++)
				{
					OIcczfuGMYyTSnlzahfSHCWBZlqiA[j] = new Button();
				}
				beEjxfHmesMtwSIeeKwNCsWiBJJlc = new ReadOnlyCollection<Axis>(UJOlbrRltGoQVLmAXaUpvEmnCdYC);
				WRDVutYwyQPJFYJKBidlEQyrckzcA = new ReadOnlyCollection<Button>(OIcczfuGMYyTSnlzahfSHCWBZlqiA);
			}

			public virtual float GetAxisValue(int index)
			{
				if (index < 0 || index >= UJOlbrRltGoQVLmAXaUpvEmnCdYC.Length)
				{
					return 0f;
				}
				return UJOlbrRltGoQVLmAXaUpvEmnCdYC[index].value;
			}

			public virtual bool GetButtonValue(int index)
			{
				if (index < 0 || index >= OIcczfuGMYyTSnlzahfSHCWBZlqiA.Length)
				{
					return false;
				}
				return OIcczfuGMYyTSnlzahfSHCWBZlqiA[index].boolValue;
			}

			public virtual float GetButtonFloatValue(int index)
			{
				if (index < 0 || index >= OIcczfuGMYyTSnlzahfSHCWBZlqiA.Length)
				{
					return 0f;
				}
				return OIcczfuGMYyTSnlzahfSHCWBZlqiA[index].floatValue;
			}

			public virtual void SetAxisValue(int index, float value)
			{
				if (index >= 0 && index < UJOlbrRltGoQVLmAXaUpvEmnCdYC.Length)
				{
					UJOlbrRltGoQVLmAXaUpvEmnCdYC[index].value = value;
				}
			}

			public virtual void SetButtonValue(int index, bool value)
			{
				if (index >= 0 && index < OIcczfuGMYyTSnlzahfSHCWBZlqiA.Length)
				{
					OIcczfuGMYyTSnlzahfSHCWBZlqiA[index].boolValue = value;
				}
			}

			public virtual void SetButtonFloatValue(int index, float value)
			{
				if (index >= 0 && index < OIcczfuGMYyTSnlzahfSHCWBZlqiA.Length)
				{
					OIcczfuGMYyTSnlzahfSHCWBZlqiA[index].floatValue = value;
				}
			}

			internal void mKDxRauoOORzvBksDhPUkTlHftIJ(int P_0, out bool P_1, out float P_2)
			{
				if (P_0 < 0 || P_0 >= OIcczfuGMYyTSnlzahfSHCWBZlqiA.Length)
				{
					P_1 = false;
					P_2 = 0f;
				}
				else
				{
					P_1 = OIcczfuGMYyTSnlzahfSHCWBZlqiA[P_0].HNSfBeZWfzQIFMJLyhFSIEiQIYCab;
					P_2 = OIcczfuGMYyTSnlzahfSHCWBZlqiA[P_0].floatValue;
				}
			}

			internal virtual void zdtEQHAhYudtnhGnCtRGmJeoXkvv()
			{
				for (int i = 0; i < OIcczfuGMYyTSnlzahfSHCWBZlqiA.Length; i++)
				{
					if (OIcczfuGMYyTSnlzahfSHCWBZlqiA[i] != null)
					{
						OIcczfuGMYyTSnlzahfSHCWBZlqiA[i].AjVUdXXlAUvoHacSuAVBcfLUAXpeb();
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

			private float ndAFhDxqEcAjhUhSCgFDFBHuBbsg;

			private bool MZORzDmkXhGRvGboxUqWpDwRPJVL;

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
						MZORzDmkXhGRvGboxUqWpDwRPJVL = true;
					}
					this.value = value;
				}
			}

			public float floatValue
			{
				get
				{
					return ndAFhDxqEcAjhUhSCgFDFBHuBbsg;
				}
				set
				{
					ndAFhDxqEcAjhUhSCgFDFBHuBbsg = value;
				}
			}

			internal bool HNSfBeZWfzQIFMJLyhFSIEiQIYCab
			{
				get
				{
					if (!value)
					{
						return MZORzDmkXhGRvGboxUqWpDwRPJVL;
					}
					return true;
				}
			}

			internal void AjVUdXXlAUvoHacSuAVBcfLUAXpeb()
			{
				MZORzDmkXhGRvGboxUqWpDwRPJVL = false;
			}
		}

		private readonly InputSource tuusxockErjIpZnzaZeUawnWVfmP;

		private readonly List<Joystick> BhWGJPcapNngzcPdImFwmyUgdZtVA;

		private readonly ReadOnlyCollection<Joystick> weWdhjMueZDtweXqidLwjUQlzluo;

		private bool SwfuKkSpUxdQEqrZIVzGxOTjAbwg = true;

		private IUnifiedKeyboardSource aOrNdWswxrDFOCHoeAUoiGepSuSRA;

		private IUnifiedMouseSource QqbITZKJFPwZKLmolAvvugKaiIuP;

		[CompilerGenerated]
		private Action m_UixbRjkXVVTUyMhaphSNIJsxpqdQA;

		[CompilerGenerated]
		private Action m_GuoVBGIhkGaRSKYbefDQCuRJwfrz;

		private bool mEhTnuxfdfcdjPGIHMyCVWboJSij;

		public bool useApproximateMatching
		{
			get
			{
				return SwfuKkSpUxdQEqrZIVzGxOTjAbwg;
			}
			protected set
			{
				SwfuKkSpUxdQEqrZIVzGxOTjAbwg = value;
			}
		}

		internal InputSource nmvMaliKWKVVtnEotrcihrnQRPHD => tuusxockErjIpZnzaZeUawnWVfmP;

		public abstract bool isReady { get; }

		private event Action UixbRjkXVVTUyMhaphSNIJsxpqdQA
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_UixbRjkXVVTUyMhaphSNIJsxpqdQA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_UixbRjkXVVTUyMhaphSNIJsxpqdQA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_UixbRjkXVVTUyMhaphSNIJsxpqdQA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_UixbRjkXVVTUyMhaphSNIJsxpqdQA, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		private event Action GuoVBGIhkGaRSKYbefDQCuRJwfrz
		{
			[CompilerGenerated]
			add
			{
				Action action = this.m_GuoVBGIhkGaRSKYbefDQCuRJwfrz;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, b);
					action = Interlocked.CompareExchange(ref this.m_GuoVBGIhkGaRSKYbefDQCuRJwfrz, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = this.m_GuoVBGIhkGaRSKYbefDQCuRJwfrz;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value3);
					action = Interlocked.CompareExchange(ref this.m_GuoVBGIhkGaRSKYbefDQCuRJwfrz, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		internal event Action NBPqvcntSfuVxALUiCBwFVDuixLCA
		{
			add
			{
				UixbRjkXVVTUyMhaphSNIJsxpqdQA += action;
			}
			remove
			{
				UixbRjkXVVTUyMhaphSNIJsxpqdQA -= action;
			}
		}

		internal event Action bPSrLptPisUqejgpVgLlRDuVzzCc
		{
			add
			{
				GuoVBGIhkGaRSKYbefDQCuRJwfrz += action;
			}
			remove
			{
				GuoVBGIhkGaRSKYbefDQCuRJwfrz -= action;
			}
		}

		internal IUnifiedKeyboardSource VZDDvpxLFXkIreYsfAIRCvBwyrBb()
		{
			return aOrNdWswxrDFOCHoeAUoiGepSuSRA;
		}

		internal IUnifiedMouseSource OnPuJOAXguOMgIKLSOoPvezSBQuK()
		{
			return QqbITZKJFPwZKLmolAvvugKaiIuP;
		}

		public CustomInputSource(int P_0)
		{
			if (!Enum.IsDefined(typeof(InputSource), P_0))
			{
				Logger.LogError("Unknown InputSource (" + P_0 + ")!");
			}
			tuusxockErjIpZnzaZeUawnWVfmP = (InputSource)P_0;
			BhWGJPcapNngzcPdImFwmyUgdZtVA = new List<Joystick>();
			weWdhjMueZDtweXqidLwjUQlzluo = new ReadOnlyCollection<Joystick>(BhWGJPcapNngzcPdImFwmyUgdZtVA);
		}

		internal CustomInputSource(int P_0, IUnifiedKeyboardSource P_1, IUnifiedMouseSource P_2)
			: this(P_0)
		{
			aOrNdWswxrDFOCHoeAUoiGepSuSRA = P_1;
			QqbITZKJFPwZKLmolAvvugKaiIuP = P_2;
		}

		internal virtual void AjJwsLldBlpITmjcHENsWTmMTamU()
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
			if (BhWGJPcapNngzcPdImFwmyUgdZtVA.Contains(joystick))
			{
				Logger.LogWarning("The joystick is already in the list. Cannot add again.");
				return;
			}
			BhWGJPcapNngzcPdImFwmyUgdZtVA.Add(joystick);
			joystick.ConnectedStateChangedEvent += RiruxXldbDDuKrakBFkOFJXDjbfAA;
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
			if (!BhWGJPcapNngzcPdImFwmyUgdZtVA.Contains(joystick))
			{
				Logger.LogWarning("The joystick was not found in the list. Cannot remove.");
				return;
			}
			BhWGJPcapNngzcPdImFwmyUgdZtVA.Remove(joystick);
			joystick.ConnectedStateChangedEvent -= RiruxXldbDDuKrakBFkOFJXDjbfAA;
			if (joystick.isConnected)
			{
				OnJoystickDisconnected();
			}
		}

		public IList<Joystick> GetJoysticks()
		{
			return weWdhjMueZDtweXqidLwjUQlzluo;
		}

		protected virtual void OnJoystickConnected()
		{
			if (this.UixbRjkXVVTUyMhaphSNIJsxpqdQA != null)
			{
				this.UixbRjkXVVTUyMhaphSNIJsxpqdQA();
			}
		}

		protected virtual void OnJoystickDisconnected()
		{
			if (this.GuoVBGIhkGaRSKYbefDQCuRJwfrz != null)
			{
				this.GuoVBGIhkGaRSKYbefDQCuRJwfrz();
			}
		}

		private void RiruxXldbDDuKrakBFkOFJXDjbfAA(bool P_0)
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

		internal Joystick[] JBZIJTFKHSXwTLqWFPEZjcQLmfuJA()
		{
			List<Joystick> list = new List<Joystick>(BhWGJPcapNngzcPdImFwmyUgdZtVA.Count);
			for (int i = 0; i < BhWGJPcapNngzcPdImFwmyUgdZtVA.Count; i++)
			{
				Joystick joystick = BhWGJPcapNngzcPdImFwmyUgdZtVA[i];
				if (joystick != null && joystick.isConnected)
				{
					list.Add(joystick);
				}
			}
			return list.ToArray();
		}

		internal virtual void ugDiQtlpJXWlRXrEwhijlruENhKI()
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
			if (mEhTnuxfdfcdjPGIHMyCVWboJSij)
			{
				return;
			}
			if (disposing)
			{
				if (aOrNdWswxrDFOCHoeAUoiGepSuSRA is IDisposable)
				{
					try
					{
						(aOrNdWswxrDFOCHoeAUoiGepSuSRA as IDisposable).Dispose();
					}
					catch (Exception msg)
					{
						Logger.LogError(msg);
					}
				}
				if (QqbITZKJFPwZKLmolAvvugKaiIuP is IDisposable)
				{
					try
					{
						(QqbITZKJFPwZKLmolAvvugKaiIuP as IDisposable).Dispose();
					}
					catch (Exception msg2)
					{
						Logger.LogError(msg2);
					}
				}
			}
			mEhTnuxfdfcdjPGIHMyCVWboJSij = true;
		}

		public abstract void Update();
	}
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
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

			private Action<bool> TVWaEkaTMCCaDPaCrgvWwYMzFGLCA;

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

			public object customIdentifier
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public Guid deviceInstanceGuid
			{
				get
				{
					return default(Guid);
				}
				set
				{
				}
			}

			public event Action<bool> ConnectedStateChangedEvent
			{
				add
				{
				}
				remove
				{
				}
			}

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
			private long? QOmIZOrcVmNYSVnFosqLjGJMiLTF;

			private int yscEHNaNLuhoucfPbUEqhZxjroimA;

			private readonly Axis[] MLeoPZaejKbWSeZMQMxurCibGkeib;

			private readonly Button[] YcUFDTXWYSlcHbBJlyfBrOcLPQCj;

			private readonly ReadOnlyCollection<Axis> zeeZqLTQceZsbEqQztNIDFoXjnlq;

			private readonly ReadOnlyCollection<Button> ArlBGNllmCPlCOIoUzycxlWvrYNQ;

			private bool XgvErfGijtZRdtKIeLEBPGTToXLWA;

			private Rewired.Controller.Extension SwjWhrhXThlkgYETUaZWMuOfARDfA;

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

			protected Joystick(string P_0, long P_1, int P_2, int P_3)
				: base(null)
			{
			}

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

			public virtual float GetButtonFloatValue(int index)
			{
				return 0f;
			}

			public virtual void SetAxisValue(int index, float value)
			{
			}

			public virtual void SetButtonValue(int index, bool value)
			{
			}

			public virtual void SetButtonFloatValue(int index, float value)
			{
			}

			internal void ctpgHGcNIGoxyITQMUiTBBFZbFepA(int P_0, out bool P_1, out float P_2)
			{
				P_1 = default(bool);
				P_2 = default(float);
			}

			internal virtual void rdFZklzACiPBmjJLFOIVTdAcYQBT()
			{
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

			private float jcaufJENyoMscQUNFLzEuLdaPjGV;

			private bool OzoFbpKPBvxioGSGslBZEWMNgtfwA;

			public bool boolValue
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public float floatValue
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			internal bool PPapEAoFppcYMAdvbWxDhhCMczeg => false;

			internal void IltbRzmwMIVEKyHqbVOYWQtYDzZs()
			{
			}
		}

		private readonly InputSource vVSTRGRzUtkUuBQBpxqPLETUkHOR;

		private readonly List<Joystick> VewjFjHPlPACyZQRFIahVymiphPk;

		private readonly ReadOnlyCollection<Joystick> szgZADjYeNVbjafCzWTvMEyrTVGl;

		private bool QYVaEIhpGrtTNewlNGUTmUozIcYgb;

		private IUnifiedKeyboardSource cmBXcyTzEvpIFUWpxLObnYRdSwqD;

		private IUnifiedMouseSource IkDdXvbPaHpRZBUhaPmoXevsicSC;

		private bool yDDIlYOdbrTAwFYmKLXHcyBeujWt;

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

		internal InputSource lOLNkPFQOOipajJgioshSEBMztdu => default(InputSource);

		public abstract bool isReady { get; }

		private event Action InRSdXZJPDWypIBCuDNKwbUrCELgA
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

		private event Action MMQlkghzcKliTMUBpWtXDAxLTOHf
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

		internal event Action FzPlEKWlxjcgIgytQHboankDHlm
		{
			add
			{
			}
			remove
			{
			}
		}

		internal event Action poylVnSmRgGozllMKalGsRnJhBDW
		{
			add
			{
			}
			remove
			{
			}
		}

		internal IUnifiedKeyboardSource JIjlxDEnTPhWRkpkgeRHnPLVdIRcA()
		{
			return null;
		}

		internal IUnifiedMouseSource WtnVQihGuoyglEcdLeHObEVKuvYgA()
		{
			return null;
		}

		public CustomInputSource(int P_0)
		{
		}

		internal CustomInputSource(int P_0, IUnifiedKeyboardSource P_1, IUnifiedMouseSource P_2)
		{
		}

		internal virtual void IlrcMxSLTnbiWImYCRStJvKEDSQqA()
		{
		}

		protected virtual void OnInitialize()
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

		private void RqPyCdQonJNYXzPMGcrLmYxJJXLN(bool P_0)
		{
		}

		internal Joystick[] HcpbqbhVJYKaKypcWXxIBkuTTCQj()
		{
			return null;
		}

		internal virtual void ynpgQLGMFNzcCHRwfDissQQGMveFA()
		{
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

			protected Controller(string deviceName)
			{
				_deviceName = deviceName;
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
			private long? zDPnjZHaLRdBKekxEKYFrQRqwLO;

			private int gfRejPemhyrlXBFjuSIUeEWTIFdB;

			private readonly Axis[] rEwCUWdrnAvHNmyWPMTQEZZqEeEa;

			private readonly Button[] BSdobvxzcvULrRIsWxFTPPpGtUR;

			private readonly ReadOnlyCollection<Axis> zpHkpilrcetqGYInYjsIElKteuN;

			private readonly ReadOnlyCollection<Button> uHtwIoxVsZKiaojHBDRKZOEjbsjH;

			private bool FKavmUmzhTUsUTKzquAriSPWQHJ;

			private Rewired.Controller.Extension hROuCGhdASTVBaBVhwSmSNLFQTP;

			public long? systemId
			{
				get
				{
					return zDPnjZHaLRdBKekxEKYFrQRqwLO;
				}
				protected set
				{
					zDPnjZHaLRdBKekxEKYFrQRqwLO = value;
				}
			}

			public int unityId
			{
				get
				{
					return gfRejPemhyrlXBFjuSIUeEWTIFdB;
				}
				protected set
				{
					gfRejPemhyrlXBFjuSIUeEWTIFdB = value;
				}
			}

			public IList<Axis> Axes => zpHkpilrcetqGYInYjsIElKteuN;

			public IList<Button> Buttons => uHtwIoxVsZKiaojHBDRKZOEjbsjH;

			public bool supportsVibration
			{
				get
				{
					return FKavmUmzhTUsUTKzquAriSPWQHJ;
				}
				set
				{
					FKavmUmzhTUsUTKzquAriSPWQHJ = value;
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					return hROuCGhdASTVBaBVhwSmSNLFQTP;
				}
				set
				{
					hROuCGhdASTVBaBVhwSmSNLFQTP = value;
				}
			}

			public int buttonCount => BSdobvxzcvULrRIsWxFTPPpGtUR.Length;

			public int axisCount => rEwCUWdrnAvHNmyWPMTQEZZqEeEa.Length;

			public Joystick(string deviceName, long? systemId, int unityId, int axisCount, int buttonCount)
				: base(deviceName)
			{
				if (axisCount < 0)
				{
					axisCount = 0;
				}
				if (buttonCount < 0)
				{
					buttonCount = 0;
				}
				zDPnjZHaLRdBKekxEKYFrQRqwLO = systemId;
				gfRejPemhyrlXBFjuSIUeEWTIFdB = unityId;
				rEwCUWdrnAvHNmyWPMTQEZZqEeEa = new Axis[axisCount];
				BSdobvxzcvULrRIsWxFTPPpGtUR = new Button[buttonCount];
				for (int i = 0; i < axisCount; i++)
				{
					rEwCUWdrnAvHNmyWPMTQEZZqEeEa[i] = new Axis();
				}
				for (int j = 0; j < buttonCount; j++)
				{
					BSdobvxzcvULrRIsWxFTPPpGtUR[j] = new Button();
				}
				zpHkpilrcetqGYInYjsIElKteuN = new ReadOnlyCollection<Axis>(rEwCUWdrnAvHNmyWPMTQEZZqEeEa);
				uHtwIoxVsZKiaojHBDRKZOEjbsjH = new ReadOnlyCollection<Button>(BSdobvxzcvULrRIsWxFTPPpGtUR);
			}

			public virtual float GetAxisValue(int index)
			{
				if (index < 0 || index >= rEwCUWdrnAvHNmyWPMTQEZZqEeEa.Length)
				{
					return 0f;
				}
				return rEwCUWdrnAvHNmyWPMTQEZZqEeEa[index].value;
			}

			public virtual bool GetButtonValue(int index)
			{
				if (index < 0 || index >= BSdobvxzcvULrRIsWxFTPPpGtUR.Length)
				{
					return false;
				}
				return BSdobvxzcvULrRIsWxFTPPpGtUR[index].value;
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

		private readonly InputSource rGFnYGjLzRhYsnnHlhHIJMtuZKY;

		private readonly List<Joystick> yTvwuKOiGyRNsHiwfnWCSADmawz;

		private readonly ReadOnlyCollection<Joystick> RbChwQyZXwpVuwMbAAONWUifBLA;

		private bool FgdAmPuJqPIWWVJoTNCjoJFEZXK = true;

		private Action yAVlxVmFqOBHEMLNMbJEdtuYlgC;

		private Action RQuvhjIqRPFaHHKFjSWkMXNkgol;

		private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

		public bool useApproximateMatching
		{
			get
			{
				return FgdAmPuJqPIWWVJoTNCjoJFEZXK;
			}
			protected set
			{
				FgdAmPuJqPIWWVJoTNCjoJFEZXK = value;
			}
		}

		internal InputSource inputSource => rGFnYGjLzRhYsnnHlhHIJMtuZKY;

		public abstract bool isReady { get; }

		private event Action _JoystickConnectedEvent
		{
			add
			{
				Action action = yAVlxVmFqOBHEMLNMbJEdtuYlgC;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref yAVlxVmFqOBHEMLNMbJEdtuYlgC, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = yAVlxVmFqOBHEMLNMbJEdtuYlgC;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref yAVlxVmFqOBHEMLNMbJEdtuYlgC, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		private event Action _JoystickDisconnectedEvent
		{
			add
			{
				Action action = RQuvhjIqRPFaHHKFjSWkMXNkgol;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref RQuvhjIqRPFaHHKFjSWkMXNkgol, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = RQuvhjIqRPFaHHKFjSWkMXNkgol;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref RQuvhjIqRPFaHHKFjSWkMXNkgol, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		internal event Action JoystickConnectedEvent
		{
			add
			{
				_JoystickConnectedEvent += value;
			}
			remove
			{
				_JoystickConnectedEvent -= value;
			}
		}

		internal event Action JoystickDisconnectedEvent
		{
			add
			{
				_JoystickDisconnectedEvent += value;
			}
			remove
			{
				_JoystickDisconnectedEvent -= value;
			}
		}

		public CustomInputSource(int inputSource)
		{
			if (!Enum.IsDefined(typeof(InputSource), inputSource))
			{
				Logger.LogError("Unknown InputSource (" + inputSource + ")!");
			}
			rGFnYGjLzRhYsnnHlhHIJMtuZKY = (InputSource)inputSource;
			yTvwuKOiGyRNsHiwfnWCSADmawz = new List<Joystick>();
			RbChwQyZXwpVuwMbAAONWUifBLA = new ReadOnlyCollection<Joystick>(yTvwuKOiGyRNsHiwfnWCSADmawz);
		}

		public void AddJoystick(Joystick joystick)
		{
			if (joystick != null)
			{
				if (yTvwuKOiGyRNsHiwfnWCSADmawz.Contains(joystick))
				{
					Logger.LogWarning("The joystick is already in the list. Cannot add again.");
				}
				else
				{
					yTvwuKOiGyRNsHiwfnWCSADmawz.Add(joystick);
				}
			}
		}

		public void RemoveJoystick(Joystick joystick)
		{
			if (joystick != null)
			{
				if (!yTvwuKOiGyRNsHiwfnWCSADmawz.Contains(joystick))
				{
					Logger.LogWarning("The joystick was not found in the list. Cannot remove.");
				}
				else
				{
					yTvwuKOiGyRNsHiwfnWCSADmawz.Remove(joystick);
				}
			}
		}

		public IList<Joystick> GetJoysticks()
		{
			return RbChwQyZXwpVuwMbAAONWUifBLA;
		}

		protected virtual void OnJoystickConnected()
		{
			if (yAVlxVmFqOBHEMLNMbJEdtuYlgC != null)
			{
				yAVlxVmFqOBHEMLNMbJEdtuYlgC();
			}
		}

		protected virtual void OnJoystickDisconnected()
		{
			if (RQuvhjIqRPFaHHKFjSWkMXNkgol != null)
			{
				RQuvhjIqRPFaHHKFjSWkMXNkgol();
			}
		}

		internal Joystick[] SbTdVeFiGmCkZpwtbZusMxZHtY()
		{
			List<Joystick> list = new List<Joystick>(yTvwuKOiGyRNsHiwfnWCSADmawz.Count);
			for (int i = 0; i < yTvwuKOiGyRNsHiwfnWCSADmawz.Count; i++)
			{
				Joystick joystick = yTvwuKOiGyRNsHiwfnWCSADmawz[i];
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
			if (!JtZAxieDBYjDdfBgPPJgrNSxYmS)
			{
				JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
			}
		}

		public abstract void Update();
	}
}

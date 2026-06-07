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

			public string customName
			{
				get
				{
					return _customName;
				}
			}

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
					while (true)
					{
						bool isConnected2 = _isConnected;
						int num = -1862703333;
						while (true)
						{
							switch (num ^ -1862703335)
							{
							case 0:
								num = -1862703336;
								continue;
							default:
								return;
							case 1:
								break;
							case 2:
								_isConnected = value;
								num = -1862703334;
								continue;
							case 3:
								return;
							}
							break;
						}
					}
				}
			}

			public string deviceName
			{
				get
				{
					return _deviceName;
				}
			}

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
				if (_isConnected)
				{
					goto IL_0008;
				}
				goto IL_0032;
				IL_0008:
				int num = 1547045218;
				goto IL_000d;
				IL_000d:
				switch (num ^ 0x5C360961)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					return;
				case 0:
					goto IL_0032;
				case 1:
					return;
				}
				goto IL_0008;
				IL_0032:
				_isConnected = true;
				num = 1547045216;
				goto IL_000d;
			}

			public abstract void Update();
		}

		public abstract class Joystick : Controller
		{
			private long? gEmWeJYfBgnlltFGfhGUfHSHmACI;

			private int hByaRVpMQNtgYWGKTUTkcHssvjs;

			private readonly Axis[] qbVJMDgYpnJuvznLeFDMdGeZUGX;

			private readonly Button[] WXIRxjkGHEWEQMEDrfdCKrevQRBu;

			private readonly ReadOnlyCollection<Axis> qUwOjuiiHRUnpVEQpCzDHwXUBGDm;

			private readonly ReadOnlyCollection<Button> viYopkgjFozOPpuuwOXRrmFKiWf;

			private bool IiTfkCbREebWvYqCHcsghMOrzoHE;

			private Rewired.Controller.Extension iKrPwKwbznPAureDUGtpiCKudaT;

			public long? systemId
			{
				get
				{
					return gEmWeJYfBgnlltFGfhGUfHSHmACI;
				}
				protected set
				{
					gEmWeJYfBgnlltFGfhGUfHSHmACI = value;
				}
			}

			public int unityId
			{
				get
				{
					return hByaRVpMQNtgYWGKTUTkcHssvjs;
				}
				protected set
				{
					hByaRVpMQNtgYWGKTUTkcHssvjs = value;
				}
			}

			public IList<Axis> Axes
			{
				get
				{
					return qUwOjuiiHRUnpVEQpCzDHwXUBGDm;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					return viYopkgjFozOPpuuwOXRrmFKiWf;
				}
			}

			public bool supportsVibration
			{
				get
				{
					return IiTfkCbREebWvYqCHcsghMOrzoHE;
				}
				set
				{
					IiTfkCbREebWvYqCHcsghMOrzoHE = value;
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					return iKrPwKwbznPAureDUGtpiCKudaT;
				}
				set
				{
					iKrPwKwbznPAureDUGtpiCKudaT = value;
				}
			}

			public int buttonCount
			{
				get
				{
					return WXIRxjkGHEWEQMEDrfdCKrevQRBu.Length;
				}
			}

			public int axisCount
			{
				get
				{
					return qbVJMDgYpnJuvznLeFDMdGeZUGX.Length;
				}
			}

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
				gEmWeJYfBgnlltFGfhGUfHSHmACI = systemId;
				hByaRVpMQNtgYWGKTUTkcHssvjs = unityId;
				qbVJMDgYpnJuvznLeFDMdGeZUGX = new Axis[axisCount];
				WXIRxjkGHEWEQMEDrfdCKrevQRBu = new Button[buttonCount];
				for (int i = 0; i < axisCount; i++)
				{
					qbVJMDgYpnJuvznLeFDMdGeZUGX[i] = new Axis();
				}
				for (int j = 0; j < buttonCount; j++)
				{
					WXIRxjkGHEWEQMEDrfdCKrevQRBu[j] = new Button();
				}
				qUwOjuiiHRUnpVEQpCzDHwXUBGDm = new ReadOnlyCollection<Axis>(qbVJMDgYpnJuvznLeFDMdGeZUGX);
				viYopkgjFozOPpuuwOXRrmFKiWf = new ReadOnlyCollection<Button>(WXIRxjkGHEWEQMEDrfdCKrevQRBu);
			}

			public virtual float GetAxisValue(int index)
			{
				if (index >= 0)
				{
					while (true)
					{
						int num = -1216571682;
						while (true)
						{
							switch (num ^ -1216571681)
							{
							case 2:
								break;
							case 1:
								goto IL_0022;
							default:
								goto end_IL_0004;
							}
							break;
							IL_0022:
							if (index >= qbVJMDgYpnJuvznLeFDMdGeZUGX.Length)
							{
								num = -1216571681;
								continue;
							}
							return qbVJMDgYpnJuvznLeFDMdGeZUGX[index].value;
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				return 0f;
			}

			public virtual bool GetButtonValue(int index)
			{
				if (index < 0 || index >= WXIRxjkGHEWEQMEDrfdCKrevQRBu.Length)
				{
					return false;
				}
				return WXIRxjkGHEWEQMEDrfdCKrevQRBu[index].value;
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

		private readonly InputSource sIivcCoCkwTtlsLUOdbFtQRFopY;

		private readonly List<Joystick> tRQjCMLJvJRYLWjJSrlPeIMLIOn;

		private readonly ReadOnlyCollection<Joystick> WxdpkSvboTeBPzpQfaIOqIbQfhYc;

		private bool UJUipBxFFoYInKbDkdKiAKIbhrEu = true;

		private Action tEmHeBxLNxHBhZHafQNVLUxzSEK;

		private Action ELtBwtAmXgyNNWMreEWBmoOonCmZ;

		private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

		public bool useApproximateMatching
		{
			get
			{
				return UJUipBxFFoYInKbDkdKiAKIbhrEu;
			}
			protected set
			{
				UJUipBxFFoYInKbDkdKiAKIbhrEu = value;
			}
		}

		internal InputSource inputSource
		{
			get
			{
				return sIivcCoCkwTtlsLUOdbFtQRFopY;
			}
		}

		public abstract bool isReady { get; }

		private event Action _JoystickConnectedEvent
		{
			add
			{
				Action action = tEmHeBxLNxHBhZHafQNVLUxzSEK;
				Action action2 = default(Action);
				while (true)
				{
					int num = 1316724263;
					while (true)
					{
						switch (num ^ 0x4E7B9E26)
						{
						case 0:
							break;
						case 1:
							action2 = action;
							num = 1316724261;
							continue;
						case 3:
						{
							Action value2 = (Action)Delegate.Combine(action2, value);
							action = Interlocked.CompareExchange(ref tEmHeBxLNxHBhZHafQNVLUxzSEK, value2, action2);
							num = 1316724260;
							continue;
						}
						default:
							if ((object)action == action2)
							{
								return;
							}
							goto case 1;
						}
						break;
					}
				}
			}
			remove
			{
				Action action = tEmHeBxLNxHBhZHafQNVLUxzSEK;
				Action action2 = default(Action);
				while (true)
				{
					int num = -1631131861;
					while (true)
					{
						switch (num ^ -1631131863)
						{
						case 0:
							break;
						case 2:
							goto IL_0025;
						default:
						{
							Action value2 = (Action)Delegate.Remove(action2, value);
							action = Interlocked.CompareExchange(ref tEmHeBxLNxHBhZHafQNVLUxzSEK, value2, action2);
							if ((object)action != action2)
							{
								goto IL_0025;
							}
							return;
						}
						}
						break;
						IL_0025:
						action2 = action;
						num = -1631131864;
					}
				}
			}
		}

		private event Action _JoystickDisconnectedEvent
		{
			add
			{
				Action action = ELtBwtAmXgyNNWMreEWBmoOonCmZ;
				Action action2 = default(Action);
				while (true)
				{
					int num = -414811821;
					while (true)
					{
						switch (num ^ -414811822)
						{
						case 3:
							break;
						default:
							return;
						case 1:
							action2 = action;
							num = -414811822;
							continue;
						case 0:
						{
							Action value2 = (Action)Delegate.Combine(action2, value);
							action = Interlocked.CompareExchange(ref ELtBwtAmXgyNNWMreEWBmoOonCmZ, value2, action2);
							int num2;
							if ((object)action == action2)
							{
								num = -414811824;
								num2 = num;
							}
							else
							{
								num = -414811821;
								num2 = num;
							}
							continue;
						}
						case 2:
							return;
						}
						break;
					}
				}
			}
			remove
			{
				Action action = ELtBwtAmXgyNNWMreEWBmoOonCmZ;
				Action action2 = default(Action);
				Action value2 = default(Action);
				while (true)
				{
					int num = -1120362217;
					while (true)
					{
						switch (num ^ -1120362221)
						{
						case 3:
							break;
						default:
							return;
						case 0:
						{
							int num2;
							if ((object)action == action2)
							{
								num = -1120362222;
								num2 = num;
							}
							else
							{
								num = -1120362217;
								num2 = num;
							}
							continue;
						}
						case 2:
							action = Interlocked.CompareExchange(ref ELtBwtAmXgyNNWMreEWBmoOonCmZ, value2, action2);
							num = -1120362221;
							continue;
						case 4:
							action2 = action;
							value2 = (Action)Delegate.Remove(action2, value);
							num = -1120362223;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
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
			while (true)
			{
				int num = -675498364;
				while (true)
				{
					switch (num ^ -675498363)
					{
					case 4:
						break;
					default:
						return;
					case 1:
					{
						int num2;
						if (!Enum.IsDefined(typeof(InputSource), inputSource))
						{
							num = -675498361;
							num2 = num;
						}
						else
						{
							num = -675498362;
							num2 = num;
						}
						continue;
					}
					case 5:
						tRQjCMLJvJRYLWjJSrlPeIMLIOn = new List<Joystick>();
						WxdpkSvboTeBPzpQfaIOqIbQfhYc = new ReadOnlyCollection<Joystick>(tRQjCMLJvJRYLWjJSrlPeIMLIOn);
						num = -675498363;
						continue;
					case 2:
						Logger.LogError("Unknown InputSource (" + inputSource + ")!");
						num = -675498362;
						continue;
					case 3:
						sIivcCoCkwTtlsLUOdbFtQRFopY = (InputSource)inputSource;
						num = -675498368;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		public void AddJoystick(Joystick joystick)
		{
			if (joystick == null)
			{
				goto IL_0003;
			}
			goto IL_003c;
			IL_0003:
			int num = 2119392858;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x7E535E5E)
			{
			case 3:
				break;
			default:
				return;
			case 0:
				goto IL_0029;
			case 1:
				goto IL_003c;
			case 4:
				return;
			case 2:
				return;
			}
			goto IL_0003;
			IL_003c:
			if (tRQjCMLJvJRYLWjJSrlPeIMLIOn.Contains(joystick))
			{
				Logger.LogWarning("The joystick is already in the list. Cannot add again.");
				return;
			}
			goto IL_0029;
			IL_0029:
			tRQjCMLJvJRYLWjJSrlPeIMLIOn.Add(joystick);
			num = 2119392860;
			goto IL_0008;
		}

		public void RemoveJoystick(Joystick joystick)
		{
			if (joystick == null)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!tRQjCMLJvJRYLWjJSrlPeIMLIOn.Contains(joystick))
				{
					num = -2047813179;
					num2 = num;
				}
				else
				{
					num = -2047813178;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -2047813178)
					{
					case 2:
						num = -2047813182;
						continue;
					default:
						return;
					case 4:
						break;
					case 0:
						tRQjCMLJvJRYLWjJSrlPeIMLIOn.Remove(joystick);
						num = -2047813177;
						continue;
					case 3:
						Logger.LogWarning("The joystick was not found in the list. Cannot remove.");
						return;
					case 1:
						return;
					}
					break;
				}
			}
		}

		public IList<Joystick> GetJoysticks()
		{
			return WxdpkSvboTeBPzpQfaIOqIbQfhYc;
		}

		protected virtual void OnJoystickConnected()
		{
			if (tEmHeBxLNxHBhZHafQNVLUxzSEK != null)
			{
				tEmHeBxLNxHBhZHafQNVLUxzSEK();
			}
		}

		protected virtual void OnJoystickDisconnected()
		{
			if (ELtBwtAmXgyNNWMreEWBmoOonCmZ != null)
			{
				ELtBwtAmXgyNNWMreEWBmoOonCmZ();
			}
		}

		internal Joystick[] DLWawRDhJxuKFmUZYwNxkUomlPWH()
		{
			List<Joystick> list = new List<Joystick>(tRQjCMLJvJRYLWjJSrlPeIMLIOn.Count);
			int num = 0;
			while (num < tRQjCMLJvJRYLWjJSrlPeIMLIOn.Count)
			{
				while (true)
				{
					Joystick joystick = tRQjCMLJvJRYLWjJSrlPeIMLIOn[num];
					int num2;
					if (joystick != null && joystick.isConnected)
					{
						list.Add(joystick);
						num2 = -1925681622;
						goto IL_001a;
					}
					goto IL_005d;
					IL_005d:
					num++;
					num2 = -1925681624;
					goto IL_001a;
					IL_001a:
					while (true)
					{
						switch (num2 ^ -1925681622)
						{
						case 3:
							num2 = -1925681621;
							continue;
						case 1:
							break;
						case 0:
							goto IL_005d;
						default:
							goto end_IL_0037;
						}
						break;
					}
					continue;
					end_IL_0037:
					break;
				}
			}
			return list.ToArray();
		}

		public virtual void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~CustomInputSource()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (QQqHByfwytAJSuMZiCPjJlZYHKG)
			{
				while (true)
				{
					switch (0xFBCE8A ^ 0xFBCE8B)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			QQqHByfwytAJSuMZiCPjJlZYHKG = true;
		}

		public abstract void Update();
	}
}

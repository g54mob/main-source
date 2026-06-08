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
					if (value == _isConnected)
					{
						return;
					}
					while (true)
					{
						_ = _isConnected;
						int num = 238811910;
						while (true)
						{
							switch (num ^ 0xE3BFB04)
							{
							case 0:
								goto IL_000a;
							case 1:
								break;
							default:
								_isConnected = value;
								return;
							}
							break;
							IL_000a:
							num = 238811909;
						}
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
			private long? XcwVCJqiNcgcNAxYsxBgTcGENhR;

			private int EDcwRUJrjTccxnNnAhrMmqhjdqO;

			private readonly Axis[] PdPvqHQYrfTEtGcYrKwAnNuIEVr;

			private readonly Button[] duQdUwWCoAwHNtdgoIMHHlMkZKgA;

			private readonly ReadOnlyCollection<Axis> LQyAGvAhoRvyiuQpeuKKwdxPVXu;

			private readonly ReadOnlyCollection<Button> WjYYSvUAasAXIMCTfymAbybBbLC;

			private bool djBZHDTutwTBqdLjSLIzCiNydAe;

			private Rewired.Controller.Extension XRrbuPDOAbJMnDUNcTrqkgwkvwmk;

			public long? systemId
			{
				get
				{
					return XcwVCJqiNcgcNAxYsxBgTcGENhR;
				}
				protected set
				{
					XcwVCJqiNcgcNAxYsxBgTcGENhR = value;
				}
			}

			public int unityId
			{
				get
				{
					return EDcwRUJrjTccxnNnAhrMmqhjdqO;
				}
				protected set
				{
					EDcwRUJrjTccxnNnAhrMmqhjdqO = value;
				}
			}

			public IList<Axis> Axes => LQyAGvAhoRvyiuQpeuKKwdxPVXu;

			public IList<Button> Buttons => WjYYSvUAasAXIMCTfymAbybBbLC;

			public bool supportsVibration
			{
				get
				{
					return djBZHDTutwTBqdLjSLIzCiNydAe;
				}
				set
				{
					djBZHDTutwTBqdLjSLIzCiNydAe = value;
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					return XRrbuPDOAbJMnDUNcTrqkgwkvwmk;
				}
				set
				{
					XRrbuPDOAbJMnDUNcTrqkgwkvwmk = value;
				}
			}

			public int buttonCount => duQdUwWCoAwHNtdgoIMHHlMkZKgA.Length;

			public int axisCount => PdPvqHQYrfTEtGcYrKwAnNuIEVr.Length;

			public Joystick(string deviceName, long? systemId, int unityId, int axisCount, int buttonCount)
				: base(deviceName)
			{
				int num4 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = -978378405;
					while (true)
					{
						switch (num ^ -978378403)
						{
						case 2:
							break;
						case 5:
						{
							int num5;
							if (num4 >= buttonCount)
							{
								num = -978378402;
								num5 = num;
							}
							else
							{
								num = -978378403;
								num5 = num;
							}
							continue;
						}
						case 9:
							EDcwRUJrjTccxnNnAhrMmqhjdqO = unityId;
							num = -978378413;
							continue;
						case 7:
							XcwVCJqiNcgcNAxYsxBgTcGENhR = systemId;
							num = -978378412;
							continue;
						case 4:
							num2 = 0;
							num = -978378410;
							continue;
						case 13:
						{
							int num6;
							if (buttonCount < 0)
							{
								num = -978378404;
								num6 = num;
							}
							else
							{
								num = -978378406;
								num6 = num;
							}
							continue;
						}
						case 6:
							if (axisCount < 0)
							{
								axisCount = 0;
								num = -978378416;
								continue;
							}
							goto case 13;
						case 14:
							PdPvqHQYrfTEtGcYrKwAnNuIEVr = new Axis[axisCount];
							duQdUwWCoAwHNtdgoIMHHlMkZKgA = new Button[buttonCount];
							num = -978378407;
							continue;
						case 0:
							duQdUwWCoAwHNtdgoIMHHlMkZKgA[num4] = new Button();
							num4++;
							num = -978378408;
							continue;
						case 1:
							buttonCount = 0;
							num = -978378406;
							continue;
						case 3:
							LQyAGvAhoRvyiuQpeuKKwdxPVXu = new ReadOnlyCollection<Axis>(PdPvqHQYrfTEtGcYrKwAnNuIEVr);
							num = -978378415;
							continue;
						case 10:
							PdPvqHQYrfTEtGcYrKwAnNuIEVr[num2] = new Axis();
							num = -978378411;
							continue;
						case 15:
							num4 = 0;
							num = -978378408;
							continue;
						case 8:
							num2++;
							num = -978378410;
							continue;
						case 11:
						{
							int num3;
							if (num2 < axisCount)
							{
								num = -978378409;
								num3 = num;
							}
							else
							{
								num = -978378414;
								num3 = num;
							}
							continue;
						}
						default:
							WjYYSvUAasAXIMCTfymAbybBbLC = new ReadOnlyCollection<Button>(duQdUwWCoAwHNtdgoIMHHlMkZKgA);
							return;
						}
						break;
					}
				}
			}

			public virtual float GetAxisValue(int index)
			{
				if (index < 0 || index >= PdPvqHQYrfTEtGcYrKwAnNuIEVr.Length)
				{
					return 0f;
				}
				return PdPvqHQYrfTEtGcYrKwAnNuIEVr[index].value;
			}

			public virtual bool GetButtonValue(int index)
			{
				if (index >= 0)
				{
					while (true)
					{
						int num = -1504552373;
						while (true)
						{
							switch (num ^ -1504552375)
							{
							case 0:
								break;
							case 2:
								goto IL_0022;
							default:
								goto end_IL_0004;
							}
							break;
							IL_0022:
							if (index >= duQdUwWCoAwHNtdgoIMHHlMkZKgA.Length)
							{
								num = -1504552376;
								continue;
							}
							return duQdUwWCoAwHNtdgoIMHHlMkZKgA[index].value;
						}
						continue;
						end_IL_0004:
						break;
					}
				}
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

		private readonly InputSource RGiPJkMDpueuMBxNNWOIhzCOavB;

		private readonly List<Joystick> OuGeULadUXMEYbbsHIWUFukGUTWd;

		private readonly ReadOnlyCollection<Joystick> rbznYTVwXDEEGKMboQnLsiZPjyd;

		private bool pFUSOYJqcqRqulbonjPbShskcbz = true;

		private Action YAuHPAZogdAfqgyTcatYLADeDmb;

		private Action hJhPSoIsVaIOCzMsdveYqsxnLTa;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public bool useApproximateMatching
		{
			get
			{
				return pFUSOYJqcqRqulbonjPbShskcbz;
			}
			protected set
			{
				pFUSOYJqcqRqulbonjPbShskcbz = value;
			}
		}

		internal InputSource inputSource => RGiPJkMDpueuMBxNNWOIhzCOavB;

		public abstract bool isReady { get; }

		private event Action _JoystickConnectedEvent
		{
			add
			{
				Action action = YAuHPAZogdAfqgyTcatYLADeDmb;
				Action value2 = default(Action);
				Action action2 = default(Action);
				while (true)
				{
					int num = 869771321;
					while (true)
					{
						switch (num ^ 0x33D7A83A)
						{
						case 0:
							break;
						case 4:
							action = Interlocked.CompareExchange(ref YAuHPAZogdAfqgyTcatYLADeDmb, value2, action2);
							num = 869771320;
							continue;
						case 1:
							value2 = (Action)Delegate.Combine(action2, value);
							num = 869771326;
							continue;
						case 3:
							action2 = action;
							num = 869771323;
							continue;
						default:
							if ((object)action == action2)
							{
								return;
							}
							goto case 3;
						}
						break;
					}
				}
			}
			remove
			{
				Action action = YAuHPAZogdAfqgyTcatYLADeDmb;
				Action action2 = default(Action);
				while (true)
				{
					int num = 537434717;
					while (true)
					{
						switch (num ^ 0x20089A5F)
						{
						case 0:
							break;
						case 2:
							goto IL_0025;
						default:
							if ((object)action != action2)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						action2 = action;
						Action value2 = (Action)Delegate.Remove(action2, value);
						action = Interlocked.CompareExchange(ref YAuHPAZogdAfqgyTcatYLADeDmb, value2, action2);
						num = 537434718;
					}
				}
			}
		}

		private event Action _JoystickDisconnectedEvent
		{
			add
			{
				Action action = hJhPSoIsVaIOCzMsdveYqsxnLTa;
				Action action2 = default(Action);
				while (true)
				{
					int num = -1333552872;
					while (true)
					{
						switch (num ^ -1333552870)
						{
						case 0:
							break;
						case 2:
							goto IL_0025;
						default:
							if ((object)action != action2)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						action2 = action;
						Action value2 = (Action)Delegate.Combine(action2, value);
						action = Interlocked.CompareExchange(ref hJhPSoIsVaIOCzMsdveYqsxnLTa, value2, action2);
						num = -1333552869;
					}
				}
			}
			remove
			{
				Action action = hJhPSoIsVaIOCzMsdveYqsxnLTa;
				Action value2 = default(Action);
				Action action2 = default(Action);
				while (true)
				{
					int num = -2035392924;
					while (true)
					{
						switch (num ^ -2035392928)
						{
						case 3:
							break;
						case 0:
							action = Interlocked.CompareExchange(ref hJhPSoIsVaIOCzMsdveYqsxnLTa, value2, action2);
							num = -2035392926;
							continue;
						case 1:
							value2 = (Action)Delegate.Remove(action2, value);
							num = -2035392928;
							continue;
						case 4:
							action2 = action;
							num = -2035392927;
							continue;
						default:
							if ((object)action == action2)
							{
								return;
							}
							goto case 4;
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
			if (!Enum.IsDefined(typeof(InputSource), inputSource))
			{
				Logger.LogError("Unknown InputSource (" + inputSource + ")!");
			}
			RGiPJkMDpueuMBxNNWOIhzCOavB = (InputSource)inputSource;
			OuGeULadUXMEYbbsHIWUFukGUTWd = new List<Joystick>();
			rbznYTVwXDEEGKMboQnLsiZPjyd = new ReadOnlyCollection<Joystick>(OuGeULadUXMEYbbsHIWUFukGUTWd);
		}

		public void AddJoystick(Joystick joystick)
		{
			if (joystick == null)
			{
				return;
			}
			while (!OuGeULadUXMEYbbsHIWUFukGUTWd.Contains(joystick))
			{
				while (true)
				{
					IL_0046:
					OuGeULadUXMEYbbsHIWUFukGUTWd.Add(joystick);
					int num = -934057396;
					while (true)
					{
						switch (num ^ -934057393)
						{
						case 0:
							num = -934057395;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							goto IL_0046;
						case 3:
							return;
						}
						break;
					}
					break;
				}
			}
			Logger.LogWarning("The joystick is already in the list. Cannot add again.");
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
				if (!OuGeULadUXMEYbbsHIWUFukGUTWd.Contains(joystick))
				{
					Logger.LogWarning("The joystick was not found in the list. Cannot remove.");
					num = -512741248;
					goto IL_0009;
				}
				goto IL_0049;
				IL_0009:
				while (true)
				{
					switch (num ^ -512741246)
					{
					case 0:
						num = -512741247;
						continue;
					default:
						return;
					case 3:
						break;
					case 1:
						goto IL_0049;
					case 2:
						return;
					case 4:
						return;
					}
					break;
				}
				continue;
				IL_0049:
				OuGeULadUXMEYbbsHIWUFukGUTWd.Remove(joystick);
				num = -512741242;
				goto IL_0009;
			}
		}

		public IList<Joystick> GetJoysticks()
		{
			return rbznYTVwXDEEGKMboQnLsiZPjyd;
		}

		protected virtual void OnJoystickConnected()
		{
			if (YAuHPAZogdAfqgyTcatYLADeDmb == null)
			{
				return;
			}
			while (true)
			{
				int num = -706900028;
				while (true)
				{
					switch (num ^ -706900027)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0026;
					case 2:
						return;
					}
					break;
					IL_0026:
					YAuHPAZogdAfqgyTcatYLADeDmb();
					num = -706900025;
				}
			}
		}

		protected virtual void OnJoystickDisconnected()
		{
			if (hJhPSoIsVaIOCzMsdveYqsxnLTa != null)
			{
				hJhPSoIsVaIOCzMsdveYqsxnLTa();
			}
		}

		internal Joystick[] iJGVmIFyHnFtOlccHagmOiUvOnb()
		{
			List<Joystick> list = new List<Joystick>(OuGeULadUXMEYbbsHIWUFukGUTWd.Count);
			int num = 0;
			Joystick joystick = default(Joystick);
			while (true)
			{
				int num2;
				int num3;
				if (num >= OuGeULadUXMEYbbsHIWUFukGUTWd.Count)
				{
					num2 = -1099117427;
					num3 = num2;
				}
				else
				{
					num2 = -1099117430;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1099117425)
					{
					case 3:
						num2 = -1099117430;
						continue;
					case 5:
						joystick = OuGeULadUXMEYbbsHIWUFukGUTWd[num];
						if (joystick != null)
						{
							int num4;
							if (!joystick.isConnected)
							{
								num2 = -1099117429;
								num4 = num2;
							}
							else
							{
								num2 = -1099117426;
								num4 = num2;
							}
							continue;
						}
						goto case 4;
					case 1:
						list.Add(joystick);
						num2 = -1099117429;
						continue;
					case 4:
						num++;
						num2 = -1099117425;
						continue;
					case 0:
						break;
					default:
						return list.ToArray();
					}
					break;
				}
			}
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
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				while (true)
				{
					switch (-1424504700 ^ -1424504699)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			xRygqjRmTtURDPiwlgMmFcdNBrr = true;
		}

		public abstract void Update();
	}
}

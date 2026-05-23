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
						goto IL_0009;
					}
					goto IL_0033;
					IL_0009:
					int num = -1019683544;
					goto IL_000e;
					IL_000e:
					switch (num ^ -1019683543)
					{
					case 3:
						break;
					case 1:
						return;
					case 2:
						goto IL_0033;
					default:
						_isConnected = value;
						return;
					}
					goto IL_0009;
					IL_0033:
					bool isConnected2 = _isConnected;
					num = -1019683543;
					goto IL_000e;
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
				if (!_isConnected)
				{
					goto IL_0008;
				}
				goto IL_0032;
				IL_0008:
				int num = -461831458;
				goto IL_000d;
				IL_000d:
				switch (num ^ -461831457)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					return;
				case 2:
					goto IL_0032;
				case 3:
					return;
				}
				goto IL_0008;
				IL_0032:
				_isConnected = false;
				num = -461831460;
				goto IL_000d;
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
			private long? JJkBjQCiHgwWIGHDBEAYPgCRjNJZ;

			private int YAsnSUHUHZSXPqVPdYXTHFQokii;

			private readonly Axis[] PbFORHCAibynPVwQMVeRWSjVVbJ;

			private readonly Button[] lgAkyeKCNYSjxkICDjzKgIcrtWEL;

			private readonly ReadOnlyCollection<Axis> XPokcnKJNNUAUtIRBGdBJVNIoHAw;

			private readonly ReadOnlyCollection<Button> YUEEutEHRiXnwNizOlBTOCVAsZw;

			private bool fAXOjZJLQkAzMaiFlKooHbCzXfGr;

			private Rewired.Controller.Extension RlhCPmWdFbcKPPhKmYBnLApskyE;

			public long? systemId
			{
				get
				{
					return JJkBjQCiHgwWIGHDBEAYPgCRjNJZ;
				}
				protected set
				{
					JJkBjQCiHgwWIGHDBEAYPgCRjNJZ = value;
				}
			}

			public int unityId
			{
				get
				{
					return YAsnSUHUHZSXPqVPdYXTHFQokii;
				}
				protected set
				{
					YAsnSUHUHZSXPqVPdYXTHFQokii = value;
				}
			}

			public IList<Axis> Axes
			{
				get
				{
					return XPokcnKJNNUAUtIRBGdBJVNIoHAw;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					return YUEEutEHRiXnwNizOlBTOCVAsZw;
				}
			}

			public bool supportsVibration
			{
				get
				{
					return fAXOjZJLQkAzMaiFlKooHbCzXfGr;
				}
				set
				{
					fAXOjZJLQkAzMaiFlKooHbCzXfGr = value;
				}
			}

			public Rewired.Controller.Extension extension
			{
				get
				{
					return RlhCPmWdFbcKPPhKmYBnLApskyE;
				}
				set
				{
					RlhCPmWdFbcKPPhKmYBnLApskyE = value;
				}
			}

			public int buttonCount
			{
				get
				{
					return lgAkyeKCNYSjxkICDjzKgIcrtWEL.Length;
				}
			}

			public int axisCount
			{
				get
				{
					return PbFORHCAibynPVwQMVeRWSjVVbJ.Length;
				}
			}

			public Joystick(string deviceName, long? systemId, int unityId, int axisCount, int buttonCount)
				: base(deviceName)
			{
				int num3 = default(int);
				int num2 = default(int);
				while (true)
				{
					int num = -1779004518;
					while (true)
					{
						switch (num ^ -1779004526)
						{
						case 6:
							break;
						case 1:
							PbFORHCAibynPVwQMVeRWSjVVbJ[num3] = new Axis();
							num3++;
							num = -1779004523;
							continue;
						case 3:
							JJkBjQCiHgwWIGHDBEAYPgCRjNJZ = systemId;
							YAsnSUHUHZSXPqVPdYXTHFQokii = unityId;
							PbFORHCAibynPVwQMVeRWSjVVbJ = new Axis[axisCount];
							lgAkyeKCNYSjxkICDjzKgIcrtWEL = new Button[buttonCount];
							num3 = 0;
							num = -1779004523;
							continue;
						case 2:
							buttonCount = 0;
							num = -1779004527;
							continue;
						case 7:
							if (num3 >= axisCount)
							{
								num2 = 0;
								num = -1779004522;
								continue;
							}
							goto case 1;
						case 8:
							if (axisCount < 0)
							{
								axisCount = 0;
								num = -1779004521;
								continue;
							}
							goto case 5;
						case 0:
							lgAkyeKCNYSjxkICDjzKgIcrtWEL[num2] = new Button();
							num2++;
							num = -1779004522;
							continue;
						case 5:
						{
							int num4;
							if (buttonCount >= 0)
							{
								num = -1779004527;
								num4 = num;
							}
							else
							{
								num = -1779004528;
								num4 = num;
							}
							continue;
						}
						case 4:
							if (num2 >= buttonCount)
							{
								XPokcnKJNNUAUtIRBGdBJVNIoHAw = new ReadOnlyCollection<Axis>(PbFORHCAibynPVwQMVeRWSjVVbJ);
								num = -1779004517;
								continue;
							}
							goto case 0;
						default:
							YUEEutEHRiXnwNizOlBTOCVAsZw = new ReadOnlyCollection<Button>(lgAkyeKCNYSjxkICDjzKgIcrtWEL);
							return;
						}
						break;
					}
				}
			}

			public virtual float GetAxisValue(int index)
			{
				if (index < 0 || index >= PbFORHCAibynPVwQMVeRWSjVVbJ.Length)
				{
					return 0f;
				}
				return PbFORHCAibynPVwQMVeRWSjVVbJ[index].value;
			}

			public virtual bool GetButtonValue(int index)
			{
				if (index < 0 || index >= lgAkyeKCNYSjxkICDjzKgIcrtWEL.Length)
				{
					return false;
				}
				return lgAkyeKCNYSjxkICDjzKgIcrtWEL[index].value;
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

		private readonly InputSource FXkavZACisNCWLIPykvLbGBTlyBs;

		private readonly List<Joystick> INKeeLdtIZyPgwCXkbuBLQHVLuw;

		private readonly ReadOnlyCollection<Joystick> lKvoWJPksBkfaRJJBWkMLqzYwJT;

		private bool pTGniWBxToLpUuqOInIctlSthaB = true;

		private Action QEcMzQDATbeyElEnDAJZizfvvJP;

		private Action vclxbmAbBeTwcgbeMcUXaZQkDLri;

		private bool vsurYtRlepcrpAzAENwjqjJEZPT;

		public bool useApproximateMatching
		{
			get
			{
				return pTGniWBxToLpUuqOInIctlSthaB;
			}
			protected set
			{
				pTGniWBxToLpUuqOInIctlSthaB = value;
			}
		}

		internal InputSource inputSource
		{
			get
			{
				return FXkavZACisNCWLIPykvLbGBTlyBs;
			}
		}

		public abstract bool isReady { get; }

		private event Action _JoystickConnectedEvent
		{
			add
			{
				Action action = QEcMzQDATbeyElEnDAJZizfvvJP;
				Action action2 = default(Action);
				while (true)
				{
					int num = -725130937;
					while (true)
					{
						switch (num ^ -725130938)
						{
						case 3:
							break;
						case 1:
							action2 = action;
							num = -725130938;
							continue;
						case 0:
						{
							Action value2 = (Action)Delegate.Combine(action2, value);
							action = Interlocked.CompareExchange(ref QEcMzQDATbeyElEnDAJZizfvvJP, value2, action2);
							num = -725130940;
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
				Action action = QEcMzQDATbeyElEnDAJZizfvvJP;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref QEcMzQDATbeyElEnDAJZizfvvJP, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		private event Action _JoystickDisconnectedEvent
		{
			add
			{
				Action action = vclxbmAbBeTwcgbeMcUXaZQkDLri;
				Action action2 = default(Action);
				while (true)
				{
					int num = -934123236;
					while (true)
					{
						switch (num ^ -934123240)
						{
						case 2:
							break;
						default:
							return;
						case 4:
							action2 = action;
							num = -934123240;
							continue;
						case 1:
						{
							int num2;
							if ((object)action != action2)
							{
								num = -934123236;
								num2 = num;
							}
							else
							{
								num = -934123237;
								num2 = num;
							}
							continue;
						}
						case 0:
						{
							Action value2 = (Action)Delegate.Combine(action2, value);
							action = Interlocked.CompareExchange(ref vclxbmAbBeTwcgbeMcUXaZQkDLri, value2, action2);
							num = -934123239;
							continue;
						}
						case 3:
							return;
						}
						break;
					}
				}
			}
			remove
			{
				Action action = vclxbmAbBeTwcgbeMcUXaZQkDLri;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref vclxbmAbBeTwcgbeMcUXaZQkDLri, value2, action2);
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
			while (true)
			{
				int num = 1224389436;
				while (true)
				{
					switch (num ^ 0x48FAB33D)
					{
					case 3:
						break;
					case 1:
					{
						int num2;
						if (!Enum.IsDefined(typeof(InputSource), inputSource))
						{
							num = 1224389437;
							num2 = num;
						}
						else
						{
							num = 1224389439;
							num2 = num;
						}
						continue;
					}
					case 0:
						Logger.LogError("Unknown InputSource (" + inputSource + ")!");
						num = 1224389439;
						continue;
					default:
						FXkavZACisNCWLIPykvLbGBTlyBs = (InputSource)inputSource;
						INKeeLdtIZyPgwCXkbuBLQHVLuw = new List<Joystick>();
						lKvoWJPksBkfaRJJBWkMLqzYwJT = new ReadOnlyCollection<Joystick>(INKeeLdtIZyPgwCXkbuBLQHVLuw);
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
				return;
			}
			while (!INKeeLdtIZyPgwCXkbuBLQHVLuw.Contains(joystick))
			{
				while (true)
				{
					IL_0046:
					INKeeLdtIZyPgwCXkbuBLQHVLuw.Add(joystick);
					int num = 1548634970;
					while (true)
					{
						switch (num ^ 0x5C4E4B58)
						{
						case 0:
							num = 1548634971;
							continue;
						default:
							return;
						case 3:
							break;
						case 1:
							goto IL_0046;
						case 2:
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
				goto IL_0003;
			}
			goto IL_0049;
			IL_0003:
			int num = -324513652;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ -324513649)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					return;
				case 1:
					INKeeLdtIZyPgwCXkbuBLQHVLuw.Remove(joystick);
					num = -324513654;
					continue;
				case 4:
					goto IL_0049;
				case 2:
					Logger.LogWarning("The joystick was not found in the list. Cannot remove.");
					return;
				case 5:
					return;
				}
				break;
			}
			goto IL_0003;
			IL_0049:
			int num2;
			if (INKeeLdtIZyPgwCXkbuBLQHVLuw.Contains(joystick))
			{
				num = -324513650;
				num2 = num;
			}
			else
			{
				num = -324513651;
				num2 = num;
			}
			goto IL_0008;
		}

		public IList<Joystick> GetJoysticks()
		{
			return lKvoWJPksBkfaRJJBWkMLqzYwJT;
		}

		protected virtual void OnJoystickConnected()
		{
			if (QEcMzQDATbeyElEnDAJZizfvvJP != null)
			{
				QEcMzQDATbeyElEnDAJZizfvvJP();
			}
		}

		protected virtual void OnJoystickDisconnected()
		{
			if (vclxbmAbBeTwcgbeMcUXaZQkDLri != null)
			{
				vclxbmAbBeTwcgbeMcUXaZQkDLri();
			}
		}

		internal Joystick[] wcCVtOLMXtslsqKKaATjxgsaWWV()
		{
			List<Joystick> list = new List<Joystick>(INKeeLdtIZyPgwCXkbuBLQHVLuw.Count);
			int num2 = default(int);
			while (true)
			{
				int num = 1602720442;
				while (true)
				{
					switch (num ^ 0x5F8792BB)
					{
					case 5:
						break;
					case 0:
					{
						int num3;
						if (num2 < INKeeLdtIZyPgwCXkbuBLQHVLuw.Count)
						{
							num = 1602720447;
							num3 = num;
						}
						else
						{
							num = 1602720440;
							num3 = num;
						}
						continue;
					}
					case 4:
					{
						Joystick joystick = INKeeLdtIZyPgwCXkbuBLQHVLuw[num2];
						if (joystick != null && joystick.isConnected)
						{
							list.Add(joystick);
							num = 1602720441;
							continue;
						}
						goto case 2;
					}
					case 2:
						num2++;
						num = 1602720443;
						continue;
					case 1:
						num2 = 0;
						num = 1602720443;
						continue;
					default:
						return list.ToArray();
					}
					break;
				}
			}
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
			if (vsurYtRlepcrpAzAENwjqjJEZPT)
			{
				return;
			}
			while (true)
			{
				vsurYtRlepcrpAzAENwjqjJEZPT = true;
				int num = 1554984453;
				while (true)
				{
					switch (num ^ 0x5CAF2E05)
					{
					case 2:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0009:
					num = 1554984452;
				}
			}
		}

		public abstract void Update();
	}
}

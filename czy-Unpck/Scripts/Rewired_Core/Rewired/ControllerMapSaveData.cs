using System;

namespace Rewired
{
	public abstract class ControllerMapSaveData
	{
		protected Controller _controller;

		protected ControllerMap _map;

		internal readonly int vuPDNwATQFuTZgAqTRoviXUGAgFM;

		public ControllerMap map
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				return _map;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return -1;
				}
				return _map.categoryId;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return -1;
				}
				return _map.layoutId;
			}
		}

		public Type mapType
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				return _map.GetType();
			}
		}

		public string mapTypeString
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return string.Empty;
				}
				return _controller.mapTypeString;
			}
		}

		public Controller controller
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				return _controller;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return ControllerType.Keyboard;
				}
				return _controller.type;
			}
		}

		public string controllerHardwareIdentifier
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return string.Empty;
				}
				return _controller.hardwareIdentifier;
			}
		}

		public T GetMap<T>() where T : ControllerMap
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			return _map as T;
		}

		internal ControllerMapSaveData(Controller controller, ControllerMap map)
		{
			_controller = controller;
			_map = map;
			vuPDNwATQFuTZgAqTRoviXUGAgFM = ReInput.id;
		}

		internal static T GIHuiEkmFihgdjpqkqIhwXanlmm<T>(Controller P_0, ControllerMap P_1) where T : ControllerMapSaveData
		{
			return (T)GIHuiEkmFihgdjpqkqIhwXanlmm(P_0, P_1);
		}

		internal static ControllerMapSaveData GIHuiEkmFihgdjpqkqIhwXanlmm(Controller P_0, ControllerMap P_1)
		{
			ControllerType type = P_0.type;
			while (true)
			{
				int num = -886028932;
				while (true)
				{
					switch (num ^ -886028931)
					{
					case 3:
						break;
					case 1:
						switch (type)
						{
						default:
							goto IL_003b;
						case ControllerType.Joystick:
							break;
						case ControllerType.Keyboard:
							return new KeyboardMapSaveData((Keyboard)P_0, (KeyboardMap)P_1);
						case ControllerType.Mouse:
							return new MouseMapSaveData((Mouse)P_0, (MouseMap)P_1);
						}
						goto default;
					case 0:
						if (type == ControllerType.Custom)
						{
							return new CustomControllerMapSaveData((CustomController)P_0, (CustomControllerMap)P_1);
						}
						throw new ArgumentNullException();
					default:
						return new JoystickMapSaveData((Joystick)P_0, (JoystickMap)P_1);
					}
					break;
					IL_003b:
					num = -886028931;
				}
			}
		}
	}
}

using System;

namespace Rewired
{
	public abstract class ControllerMapSaveData
	{
		protected Controller _controller;

		protected ControllerMap _map;

		internal readonly int oLUDKIBSDOGsiswKzVsPEXOleBcs;

		public ControllerMap map
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return _map;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return -1;
				}
				return _map.categoryId;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return -1;
				}
				return _map.layoutId;
			}
		}

		public Type mapType
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return _map.GetType();
			}
		}

		public string mapTypeString
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return string.Empty;
				}
				return _controller.mapTypeString;
			}
		}

		public Controller controller
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return _controller;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return ControllerType.Keyboard;
				}
				return _controller.type;
			}
		}

		public string controllerHardwareIdentifier
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return string.Empty;
				}
				return _controller.hardwareIdentifier;
			}
		}

		public T GetMap<T>() where T : ControllerMap
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			return _map as T;
		}

		internal ControllerMapSaveData(Controller P_0, ControllerMap P_1)
		{
			_controller = P_0;
			_map = P_1;
			oLUDKIBSDOGsiswKzVsPEXOleBcs = ReInput.id;
		}

		internal static _0001 VxSNvmooWfTkIVcICGUZnqoUJPDW<_0001>(Controller P_0, ControllerMap P_1) where _0001 : ControllerMapSaveData
		{
			return (_0001)VxSNvmooWfTkIVcICGUZnqoUJPDW(P_0, P_1);
		}

		internal static ControllerMapSaveData VxSNvmooWfTkIVcICGUZnqoUJPDW(Controller P_0, ControllerMap P_1)
		{
			switch (P_0.type)
			{
			case ControllerType.Joystick:
				return new JoystickMapSaveData((Joystick)P_0, (JoystickMap)P_1);
			case ControllerType.Keyboard:
				return new KeyboardMapSaveData((Keyboard)P_0, (KeyboardMap)P_1);
			case ControllerType.Mouse:
				return new MouseMapSaveData((Mouse)P_0, (MouseMap)P_1);
			case ControllerType.Custom:
				return new CustomControllerMapSaveData((CustomController)P_0, (CustomControllerMap)P_1);
			default:
				throw new ArgumentNullException();
			}
		}
	}
}

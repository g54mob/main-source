using System;

namespace Rewired
{
	public abstract class ControllerMapSaveData
	{
		protected Controller _controller;

		protected ControllerMap _map;

		internal readonly int znFtIaPrJLvdjPGCwXFaaAeLKcr;

		public ControllerMap map
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				return _map;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return -1;
				}
				return _map.categoryId;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return -1;
				}
				return _map.layoutId;
			}
		}

		public Type mapType
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				return _map.GetType();
			}
		}

		public string mapTypeString
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return string.Empty;
				}
				return _controller.mapTypeString;
			}
		}

		public Controller controller
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return null;
				}
				return _controller;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return ControllerType.Keyboard;
				}
				return _controller.type;
			}
		}

		public string controllerHardwareIdentifier
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return string.Empty;
				}
				return _controller.hardwareIdentifier;
			}
		}

		public T GetMap<T>() where T : ControllerMap
		{
			T result = default(T);
			if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
			{
				while (true)
				{
					int num = 1739077109;
					while (true)
					{
						switch (num ^ 0x67A835F4)
						{
						case 2:
							break;
						case 1:
							goto IL_002b;
						default:
							return result;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
						result = null;
						num = 1739077108;
					}
				}
			}
			return _map as T;
		}

		internal ControllerMapSaveData(Controller controller, ControllerMap map)
		{
			_controller = controller;
			_map = map;
			znFtIaPrJLvdjPGCwXFaaAeLKcr = ReInput.id;
		}

		internal static T MdLShCgeucAqBomYFlMaHVWokJC<T>(Controller P_0, ControllerMap P_1) where T : ControllerMapSaveData
		{
			return (T)MdLShCgeucAqBomYFlMaHVWokJC(P_0, P_1);
		}

		internal static ControllerMapSaveData MdLShCgeucAqBomYFlMaHVWokJC(Controller P_0, ControllerMap P_1)
		{
			ControllerType type = P_0.type;
			while (true)
			{
				switch (0x315DED21 ^ 0x315DED20)
				{
				case 2:
					continue;
				case 1:
					switch (type)
					{
					case ControllerType.Joystick:
						break;
					case ControllerType.Keyboard:
						return new KeyboardMapSaveData((Keyboard)P_0, (KeyboardMap)P_1);
					case ControllerType.Mouse:
						return new MouseMapSaveData((Mouse)P_0, (MouseMap)P_1);
					case ControllerType.Custom:
						return new CustomControllerMapSaveData((CustomController)P_0, (CustomControllerMap)P_1);
					default:
						throw new ArgumentNullException();
					}
					break;
				}
				break;
			}
			return new JoystickMapSaveData((Joystick)P_0, (JoystickMap)P_1);
		}
	}
}

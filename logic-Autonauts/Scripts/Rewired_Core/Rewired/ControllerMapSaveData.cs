using System;

namespace Rewired
{
	public abstract class ControllerMapSaveData
	{
		protected Controller _controller;

		protected ControllerMap _map;

		internal readonly int SsPwhbdijXONOlkRKHOkXryZrDq;

		public ControllerMap map
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				return _map;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return -1;
				}
				return _map.categoryId;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return -1;
				}
				return _map.layoutId;
			}
		}

		public Type mapType
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					while (true)
					{
						int num = -156912907;
						while (true)
						{
							switch (num ^ -156912908)
							{
							case 0:
								break;
							case 1:
								goto IL_002b;
							default:
								return null;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
							num = -156912906;
						}
					}
				}
				return _map.GetType();
			}
		}

		public string mapTypeString
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return string.Empty;
				}
				return _controller.mapTypeString;
			}
		}

		public Controller controller
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				return _controller;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return ControllerType.Keyboard;
				}
				return _controller.type;
			}
		}

		public string controllerHardwareIdentifier
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return string.Empty;
				}
				return _controller.hardwareIdentifier;
			}
		}

		public T GetMap<T>() where T : ControllerMap
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return null;
			}
			return _map as T;
		}

		internal ControllerMapSaveData(Controller controller, ControllerMap map)
		{
			_controller = controller;
			_map = map;
			SsPwhbdijXONOlkRKHOkXryZrDq = ReInput.id;
		}

		internal static T rHXUBQoqejbkONabpWgwEqatBJ<T>(Controller P_0, ControllerMap P_1) where T : ControllerMapSaveData
		{
			return (T)rHXUBQoqejbkONabpWgwEqatBJ(P_0, P_1);
		}

		internal static ControllerMapSaveData rHXUBQoqejbkONabpWgwEqatBJ(Controller P_0, ControllerMap P_1)
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

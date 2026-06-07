using System;

namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element uLXtOJWFVkSakMKrKISOhGpQNHo;

		private AxisRange ObWitXNhWFZMnOJBWvYTcBBfVnG;

		public int elementIdentifierId
		{
			get
			{
				if (uLXtOJWFVkSakMKrKISOhGpQNHo == null)
				{
					return -1;
				}
				return uLXtOJWFVkSakMKrKISOhGpQNHo.id;
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return ObWitXNhWFZMnOJBWvYTcBBfVnG;
			}
			set
			{
				ObWitXNhWFZMnOJBWvYTcBBfVnG = value;
			}
		}

		public bool hasTarget
		{
			get
			{
				return uLXtOJWFVkSakMKrKISOhGpQNHo != null;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				if (uLXtOJWFVkSakMKrKISOhGpQNHo == null)
				{
					return ControllerElementType.Axis;
				}
				return uLXtOJWFVkSakMKrKISOhGpQNHo.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (uLXtOJWFVkSakMKrKISOhGpQNHo == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifier = uLXtOJWFVkSakMKrKISOhGpQNHo.elementIdentifier;
				while (true)
				{
					int num = 1989746954;
					while (true)
					{
						switch (num ^ 0x7699210B)
						{
						case 2:
							break;
						case 1:
							if (elementIdentifier == null)
							{
								goto IL_003b;
							}
							return elementIdentifier.GetDisplayName(uLXtOJWFVkSakMKrKISOhGpQNHo.type, ObWitXNhWFZMnOJBWvYTcBBfVnG);
						default:
							return string.Empty;
						}
						break;
						IL_003b:
						num = 1989746955;
					}
				}
			}
		}

		public Controller controller
		{
			get
			{
				if (uLXtOJWFVkSakMKrKISOhGpQNHo == null)
				{
					return null;
				}
				return uLXtOJWFVkSakMKrKISOhGpQNHo.HUdfNKdOgxfoxjMZAKUlkQYPszXh;
			}
		}

		public Controller.Element element
		{
			get
			{
				return uLXtOJWFVkSakMKrKISOhGpQNHo;
			}
			set
			{
				uLXtOJWFVkSakMKrKISOhGpQNHo = value;
			}
		}

		public ControllerElementTarget(ActionElementMap actionElementMap)
		{
			if (actionElementMap == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (actionElementMap.JdetZGSYAxuUPraClBlCSLMWOmU != null)
			{
				Controller controller = ReInput.uzYFVAOPCugnffcKSwcZmFfGUjB.lHAHnEiPErByQLPNWMxnJGMpiHF(actionElementMap.JdetZGSYAxuUPraClBlCSLMWOmU.controllerType, actionElementMap.JdetZGSYAxuUPraClBlCSLMWOmU.controllerId);
				uLXtOJWFVkSakMKrKISOhGpQNHo = controller.GetElementById(actionElementMap._elementIdentifierId);
			}
			else
			{
				uLXtOJWFVkSakMKrKISOhGpQNHo = null;
			}
			ObWitXNhWFZMnOJBWvYTcBBfVnG = actionElementMap._axisRange;
		}

		public ControllerElementTarget(ControllerElementTarget other)
		{
			uLXtOJWFVkSakMKrKISOhGpQNHo = other.uLXtOJWFVkSakMKrKISOhGpQNHo;
			ObWitXNhWFZMnOJBWvYTcBBfVnG = other.ObWitXNhWFZMnOJBWvYTcBBfVnG;
		}

		public ControllerElementTarget(IControllerElementTarget other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			uLXtOJWFVkSakMKrKISOhGpQNHo = other.element;
			ObWitXNhWFZMnOJBWvYTcBBfVnG = other.axisRange;
		}

		public static implicit operator ControllerElementTarget(ActionElementMap actionElementMap)
		{
			if (actionElementMap == null)
			{
				return default(ControllerElementTarget);
			}
			return new ControllerElementTarget(actionElementMap);
		}
	}
}

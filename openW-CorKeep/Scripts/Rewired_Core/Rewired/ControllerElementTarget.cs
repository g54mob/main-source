using System;

namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element WvNeZjYpaxWseXTQIdHcdcwJdjTR;

		private AxisRange KAJWWazuotouvlyVJzaJqndHgLHi;

		public int elementIdentifierId
		{
			get
			{
				if (WvNeZjYpaxWseXTQIdHcdcwJdjTR == null)
				{
					return -1;
				}
				return WvNeZjYpaxWseXTQIdHcdcwJdjTR.id;
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return KAJWWazuotouvlyVJzaJqndHgLHi;
			}
			set
			{
				KAJWWazuotouvlyVJzaJqndHgLHi = value;
			}
		}

		public bool hasTarget => WvNeZjYpaxWseXTQIdHcdcwJdjTR != null;

		public ControllerElementType elementType
		{
			get
			{
				if (WvNeZjYpaxWseXTQIdHcdcwJdjTR == null)
				{
					return ControllerElementType.Axis;
				}
				return WvNeZjYpaxWseXTQIdHcdcwJdjTR.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (WvNeZjYpaxWseXTQIdHcdcwJdjTR == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifier = WvNeZjYpaxWseXTQIdHcdcwJdjTR.elementIdentifier;
				if (elementIdentifier == null)
				{
					return string.Empty;
				}
				return elementIdentifier.GetDisplayName(WvNeZjYpaxWseXTQIdHcdcwJdjTR.type, KAJWWazuotouvlyVJzaJqndHgLHi);
			}
		}

		public Controller controller
		{
			get
			{
				if (WvNeZjYpaxWseXTQIdHcdcwJdjTR == null)
				{
					return null;
				}
				return WvNeZjYpaxWseXTQIdHcdcwJdjTR.EgUglMdQPxeOPRBRobiAurmBPQhJ;
			}
		}

		public Controller.Element element
		{
			get
			{
				return WvNeZjYpaxWseXTQIdHcdcwJdjTR;
			}
			set
			{
				WvNeZjYpaxWseXTQIdHcdcwJdjTR = value;
			}
		}

		public ControllerElementTarget(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (P_0.SgUAVzrEwbiOfhsWRrWLFXPetVee != null)
			{
				Controller controller = ReInput.YNZnkUUWdETsfnFwfyPUjVPxExCq.FJiNERFMwUDilNHrWEgQjOqbPMAh(P_0.SgUAVzrEwbiOfhsWRrWLFXPetVee.controllerType, P_0.SgUAVzrEwbiOfhsWRrWLFXPetVee.controllerId);
				WvNeZjYpaxWseXTQIdHcdcwJdjTR = controller.GetElementById(P_0._elementIdentifierId);
			}
			else
			{
				WvNeZjYpaxWseXTQIdHcdcwJdjTR = null;
			}
			KAJWWazuotouvlyVJzaJqndHgLHi = P_0._axisRange;
		}

		public ControllerElementTarget(ControllerElementTarget P_0)
		{
			WvNeZjYpaxWseXTQIdHcdcwJdjTR = P_0.WvNeZjYpaxWseXTQIdHcdcwJdjTR;
			KAJWWazuotouvlyVJzaJqndHgLHi = P_0.KAJWWazuotouvlyVJzaJqndHgLHi;
		}

		public ControllerElementTarget(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("other");
			}
			WvNeZjYpaxWseXTQIdHcdcwJdjTR = P_0.element;
			KAJWWazuotouvlyVJzaJqndHgLHi = P_0.axisRange;
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

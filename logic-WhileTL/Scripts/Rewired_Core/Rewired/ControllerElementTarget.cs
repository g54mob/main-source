using System;

namespace Rewired
{
	public struct ControllerElementTarget
	{
		private Controller.Element MwCBVmeZjbozNOJFcXjTAjixqQbH;

		private AxisRange emLkZqjpKMMiQMkdaETOTOIMfGJq;

		public int elementIdentifierId
		{
			get
			{
				if (MwCBVmeZjbozNOJFcXjTAjixqQbH == null)
				{
					return -1;
				}
				return MwCBVmeZjbozNOJFcXjTAjixqQbH.id;
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return emLkZqjpKMMiQMkdaETOTOIMfGJq;
			}
			set
			{
				emLkZqjpKMMiQMkdaETOTOIMfGJq = value;
			}
		}

		public bool hasTarget => MwCBVmeZjbozNOJFcXjTAjixqQbH != null;

		public ControllerElementType elementType
		{
			get
			{
				if (MwCBVmeZjbozNOJFcXjTAjixqQbH == null)
				{
					return ControllerElementType.Axis;
				}
				return MwCBVmeZjbozNOJFcXjTAjixqQbH.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (MwCBVmeZjbozNOJFcXjTAjixqQbH == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifier = MwCBVmeZjbozNOJFcXjTAjixqQbH.elementIdentifier;
				if (elementIdentifier == null)
				{
					return string.Empty;
				}
				return elementIdentifier.GetDisplayName(MwCBVmeZjbozNOJFcXjTAjixqQbH.type, emLkZqjpKMMiQMkdaETOTOIMfGJq);
			}
		}

		public Controller controller
		{
			get
			{
				if (MwCBVmeZjbozNOJFcXjTAjixqQbH == null)
				{
					return null;
				}
				return MwCBVmeZjbozNOJFcXjTAjixqQbH.nEgdvbuTaiHYWdQfyyXkKnXDhOQcb;
			}
		}

		public Controller.Element element
		{
			get
			{
				return MwCBVmeZjbozNOJFcXjTAjixqQbH;
			}
			set
			{
				MwCBVmeZjbozNOJFcXjTAjixqQbH = value;
			}
		}

		public ControllerElementTarget(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("actionElementMap");
			}
			if (P_0.xnhNfzyqGuCronbiVjqLrzXhjTDR != null)
			{
				Controller controller = ReInput.OkLkjfkBGntRAvakyAvYRRgphMAiA.BXBKHrCmMwnClRajoDNsKgTWBgIcb(P_0.xnhNfzyqGuCronbiVjqLrzXhjTDR.controllerType, P_0.xnhNfzyqGuCronbiVjqLrzXhjTDR.controllerId);
				MwCBVmeZjbozNOJFcXjTAjixqQbH = controller.GetElementById(P_0._elementIdentifierId);
			}
			else
			{
				MwCBVmeZjbozNOJFcXjTAjixqQbH = null;
			}
			emLkZqjpKMMiQMkdaETOTOIMfGJq = P_0._axisRange;
		}

		public ControllerElementTarget(ControllerElementTarget P_0)
		{
			MwCBVmeZjbozNOJFcXjTAjixqQbH = P_0.MwCBVmeZjbozNOJFcXjTAjixqQbH;
			emLkZqjpKMMiQMkdaETOTOIMfGJq = P_0.emLkZqjpKMMiQMkdaETOTOIMfGJq;
		}

		public ControllerElementTarget(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("other");
			}
			MwCBVmeZjbozNOJFcXjTAjixqQbH = P_0.element;
			emLkZqjpKMMiQMkdaETOTOIMfGJq = P_0.axisRange;
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

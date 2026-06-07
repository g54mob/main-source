using System;
using UnityEngine;

namespace Rewired
{
	public sealed class ElementAssignmentInfo
	{
		private readonly ControllerMap xnhNfzyqGuCronbiVjqLrzXhjTDR;

		private readonly ControllerElementType QoNNWCBWhstwCjczWDBfosWZEUNR;

		private readonly int qPgurrkgzcUtWHqPCZykHtadMtSs;

		private readonly int MToyChcGWGmeBbeiJGjHlICtSgbd;

		private readonly AxisRange emLkZqjpKMMiQMkdaETOTOIMfGJq;

		private readonly KeyCode PbCOhxlQRBbrGiRFIpZTeKPbNoms;

		private readonly ModifierKeyFlags ckQxpADOjVaaMJciryKJvIwODZeCA;

		private readonly int WtxqRhyewFhRCZexgGgTPAkliDAd;

		private readonly Pole xBLbApMnHgwbIBXRhstMIevzfxtFA;

		private readonly bool TuEulFuaNAxVEPsDuesLtgKLMgQw;

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (xnhNfzyqGuCronbiVjqLrzXhjTDR == null)
				{
					return null;
				}
				return xnhNfzyqGuCronbiVjqLrzXhjTDR.player;
			}
		}

		public InputAction action
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.mapping.GetAction(WtxqRhyewFhRCZexgGgTPAkliDAd);
			}
		}

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (xnhNfzyqGuCronbiVjqLrzXhjTDR == null)
				{
					return null;
				}
				return ReInput.controllers.GetController(xnhNfzyqGuCronbiVjqLrzXhjTDR.controllerType, xnhNfzyqGuCronbiVjqLrzXhjTDR.controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (!ReInput.isReady || xnhNfzyqGuCronbiVjqLrzXhjTDR == null)
				{
					return ControllerType.Keyboard;
				}
				return xnhNfzyqGuCronbiVjqLrzXhjTDR.controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				if (!ReInput.isReady || xnhNfzyqGuCronbiVjqLrzXhjTDR == null)
				{
					return -1;
				}
				return xnhNfzyqGuCronbiVjqLrzXhjTDR.controllerId;
			}
		}

		public ControllerMap controllerMap => xnhNfzyqGuCronbiVjqLrzXhjTDR;

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(MToyChcGWGmeBbeiJGjHlICtSgbd);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (xnhNfzyqGuCronbiVjqLrzXhjTDR == null)
				{
					return null;
				}
				return xnhNfzyqGuCronbiVjqLrzXhjTDR.GetElementMap(qPgurrkgzcUtWHqPCZykHtadMtSs);
			}
		}

		public ControllerElementType elementType => QoNNWCBWhstwCjczWDBfosWZEUNR;

		public Pole axisContribution => xBLbApMnHgwbIBXRhstMIevzfxtFA;

		public AxisRange axisRange => emLkZqjpKMMiQMkdaETOTOIMfGJq;

		public bool invert => TuEulFuaNAxVEPsDuesLtgKLMgQw;

		public KeyCode keyCode => PbCOhxlQRBbrGiRFIpZTeKPbNoms;

		public ModifierKeyFlags modifierKeyFlags => ckQxpADOjVaaMJciryKJvIwODZeCA;

		public string elementDisplayName
		{
			get
			{
				if (xnhNfzyqGuCronbiVjqLrzXhjTDR == null)
				{
					return string.Empty;
				}
				if (controllerType == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(keyCode, modifierKeyFlags);
				}
				Controller controller = this.controller;
				if (controller == null)
				{
					return string.Empty;
				}
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(MToyChcGWGmeBbeiJGjHlICtSgbd);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				if (QoNNWCBWhstwCjczWDBfosWZEUNR == ControllerElementType.Axis)
				{
					if (emLkZqjpKMMiQMkdaETOTOIMfGJq == AxisRange.Full)
					{
						return elementIdentifierById.name;
					}
					if (emLkZqjpKMMiQMkdaETOTOIMfGJq == AxisRange.Positive)
					{
						return elementIdentifierById.positiveName;
					}
					if (emLkZqjpKMMiQMkdaETOTOIMfGJq == AxisRange.Negative)
					{
						return elementIdentifierById.negativeName;
					}
				}
				return elementIdentifierById.name;
			}
		}

		internal ElementAssignmentInfo(ControllerMap P_0, ElementAssignment P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerMap");
			}
			WtxqRhyewFhRCZexgGgTPAkliDAd = P_1.actionId;
			xnhNfzyqGuCronbiVjqLrzXhjTDR = P_0;
			qPgurrkgzcUtWHqPCZykHtadMtSs = P_1.elementMapId;
			MToyChcGWGmeBbeiJGjHlICtSgbd = P_1.elementIdentifierId;
			PbCOhxlQRBbrGiRFIpZTeKPbNoms = P_1.keyboardKey;
			ckQxpADOjVaaMJciryKJvIwODZeCA = P_1.modifierKeyFlags;
			TuEulFuaNAxVEPsDuesLtgKLMgQw = P_1.invert;
			QoNNWCBWhstwCjczWDBfosWZEUNR = DXYiJElpUHxcPboaihvPaElwMWxMA.aCQAIhcPWADBaJBnivAKwIRUgnHRA(P_1.type);
			xBLbApMnHgwbIBXRhstMIevzfxtFA = P_1.axisContribution;
			emLkZqjpKMMiQMkdaETOTOIMfGJq = P_1.axisRange;
			if (xnhNfzyqGuCronbiVjqLrzXhjTDR.controllerType == ControllerType.Keyboard)
			{
				Keyboard.VEtEFJdPkgAIPgWrifMLJrFsdpef(ref MToyChcGWGmeBbeiJGjHlICtSgbd, ref PbCOhxlQRBbrGiRFIpZTeKPbNoms);
			}
		}
	}
}

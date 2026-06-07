using System;
using UnityEngine;

namespace Rewired
{
	public sealed class ElementAssignmentInfo
	{
		private readonly ControllerMap SeHOyFSTmmgJFmsTYWFnlvkdtXng;

		private readonly ControllerElementType lBWUwtyEFNccYHxiKmnoUyAfCUww;

		private readonly int GVnlDlXMDETXGELvZsXFoXrmbJdP;

		private readonly int wwdgLWZTYMsFfgvpRyHinniGBOEG;

		private readonly AxisRange fkNbygCyxMKMcroeIsSBxluNwYwuA;

		private readonly KeyCode lFgYHZRqqcjmEIvJuWMtKROPVrol;

		private readonly ModifierKeyFlags HbAyHXqywYjhIgpQTJEYlxLAagbl;

		private readonly int nDkWxeHkiTxvbQPmFmWIGFFwZgvj;

		private readonly Pole KGsyKxCPPWPUQAdeKinfHeSlMpuEA;

		private readonly bool egbsaxBHnErZSLrnZLRtrFvkdYBp;

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (SeHOyFSTmmgJFmsTYWFnlvkdtXng == null)
				{
					return null;
				}
				return SeHOyFSTmmgJFmsTYWFnlvkdtXng.player;
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
				return ReInput.mapping.GetAction(nDkWxeHkiTxvbQPmFmWIGFFwZgvj);
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
				if (SeHOyFSTmmgJFmsTYWFnlvkdtXng == null)
				{
					return null;
				}
				return ReInput.controllers.GetController(SeHOyFSTmmgJFmsTYWFnlvkdtXng.controllerType, SeHOyFSTmmgJFmsTYWFnlvkdtXng.controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (!ReInput.isReady || SeHOyFSTmmgJFmsTYWFnlvkdtXng == null)
				{
					return ControllerType.Keyboard;
				}
				return SeHOyFSTmmgJFmsTYWFnlvkdtXng.controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				if (!ReInput.isReady || SeHOyFSTmmgJFmsTYWFnlvkdtXng == null)
				{
					return -1;
				}
				return SeHOyFSTmmgJFmsTYWFnlvkdtXng.controllerId;
			}
		}

		public ControllerMap controllerMap => SeHOyFSTmmgJFmsTYWFnlvkdtXng;

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(wwdgLWZTYMsFfgvpRyHinniGBOEG);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (SeHOyFSTmmgJFmsTYWFnlvkdtXng == null)
				{
					return null;
				}
				return SeHOyFSTmmgJFmsTYWFnlvkdtXng.GetElementMap(GVnlDlXMDETXGELvZsXFoXrmbJdP);
			}
		}

		public ControllerElementType elementType => lBWUwtyEFNccYHxiKmnoUyAfCUww;

		public Pole axisContribution => KGsyKxCPPWPUQAdeKinfHeSlMpuEA;

		public AxisRange axisRange => fkNbygCyxMKMcroeIsSBxluNwYwuA;

		public bool invert => egbsaxBHnErZSLrnZLRtrFvkdYBp;

		public KeyCode keyCode => lFgYHZRqqcjmEIvJuWMtKROPVrol;

		public ModifierKeyFlags modifierKeyFlags => HbAyHXqywYjhIgpQTJEYlxLAagbl;

		public string elementDisplayName
		{
			get
			{
				if (SeHOyFSTmmgJFmsTYWFnlvkdtXng == null)
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
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(wwdgLWZTYMsFfgvpRyHinniGBOEG);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				if (lBWUwtyEFNccYHxiKmnoUyAfCUww == ControllerElementType.Axis)
				{
					if (fkNbygCyxMKMcroeIsSBxluNwYwuA == AxisRange.Full)
					{
						return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
					}
					if (fkNbygCyxMKMcroeIsSBxluNwYwuA == AxisRange.Positive)
					{
						return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName;
					}
					if (fkNbygCyxMKMcroeIsSBxluNwYwuA == AxisRange.Negative)
					{
						return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName;
					}
				}
				return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
			}
		}

		internal ElementAssignmentInfo(ControllerMap P_0, ElementAssignment P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerMap");
			}
			nDkWxeHkiTxvbQPmFmWIGFFwZgvj = P_1.actionId;
			SeHOyFSTmmgJFmsTYWFnlvkdtXng = P_0;
			GVnlDlXMDETXGELvZsXFoXrmbJdP = P_1.elementMapId;
			wwdgLWZTYMsFfgvpRyHinniGBOEG = P_1.elementIdentifierId;
			lFgYHZRqqcjmEIvJuWMtKROPVrol = P_1.keyboardKey;
			HbAyHXqywYjhIgpQTJEYlxLAagbl = P_1.modifierKeyFlags;
			egbsaxBHnErZSLrnZLRtrFvkdYBp = P_1.invert;
			lBWUwtyEFNccYHxiKmnoUyAfCUww = tqmHLUqTfYnnflPJaWxRPIPYjlrx.puzVnKjbWWaKIdOxIXdDkfWaAHYeA(P_1.type);
			KGsyKxCPPWPUQAdeKinfHeSlMpuEA = P_1.axisContribution;
			fkNbygCyxMKMcroeIsSBxluNwYwuA = P_1.axisRange;
			if (SeHOyFSTmmgJFmsTYWFnlvkdtXng.controllerType == ControllerType.Keyboard)
			{
				Keyboard.MErBeKKWydGjCGddAMBfOvLVvvaP(ref wwdgLWZTYMsFfgvpRyHinniGBOEG, ref lFgYHZRqqcjmEIvJuWMtKROPVrol);
			}
		}
	}
}

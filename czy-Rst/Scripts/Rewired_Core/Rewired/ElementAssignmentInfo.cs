using System;
using UnityEngine;

namespace Rewired
{
	public sealed class ElementAssignmentInfo
	{
		private readonly ControllerMap DEqYGmBFzZCZEcUJydfUFPeBmpRP;

		private readonly ControllerElementType uUtMbWneEqhDBZKoyGCZgYUVdGGT;

		private readonly int TuCgLQWeArAwFAIphGwovGlAFRTgb;

		private readonly int jqMcLvWCDtFPqaYlhPLRPHgePLwR;

		private readonly AxisRange uJaYqLfpofEnvAccoIxqPZunHOWNA;

		private readonly KeyCode snXbNgFCxTvHVaUJCvzMpgWrLXUtA;

		private readonly ModifierKeyFlags SYjaGcdbbpFYJwrQzAibVXLyJyRN;

		private readonly int ifJbCLCBngpUkCdkbeVdaoFWHVHfb;

		private readonly Pole FNZaIAaVQhLrXaQyIuMMrMWlRvEib;

		private readonly bool jEWfqESJqpAuLeZjvTiQMPtCXKvKA;

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (DEqYGmBFzZCZEcUJydfUFPeBmpRP == null)
				{
					return null;
				}
				return DEqYGmBFzZCZEcUJydfUFPeBmpRP.player;
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
				return ReInput.mapping.GetAction(ifJbCLCBngpUkCdkbeVdaoFWHVHfb);
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
				if (DEqYGmBFzZCZEcUJydfUFPeBmpRP == null)
				{
					return null;
				}
				return ReInput.controllers.GetController(DEqYGmBFzZCZEcUJydfUFPeBmpRP.controllerType, DEqYGmBFzZCZEcUJydfUFPeBmpRP.controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (!ReInput.isReady || DEqYGmBFzZCZEcUJydfUFPeBmpRP == null)
				{
					return ControllerType.Keyboard;
				}
				return DEqYGmBFzZCZEcUJydfUFPeBmpRP.controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				if (!ReInput.isReady || DEqYGmBFzZCZEcUJydfUFPeBmpRP == null)
				{
					return -1;
				}
				return DEqYGmBFzZCZEcUJydfUFPeBmpRP.controllerId;
			}
		}

		public ControllerMap controllerMap => DEqYGmBFzZCZEcUJydfUFPeBmpRP;

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(jqMcLvWCDtFPqaYlhPLRPHgePLwR);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (DEqYGmBFzZCZEcUJydfUFPeBmpRP == null)
				{
					return null;
				}
				return DEqYGmBFzZCZEcUJydfUFPeBmpRP.GetElementMap(TuCgLQWeArAwFAIphGwovGlAFRTgb);
			}
		}

		public ControllerElementType elementType => uUtMbWneEqhDBZKoyGCZgYUVdGGT;

		public Pole axisContribution => FNZaIAaVQhLrXaQyIuMMrMWlRvEib;

		public AxisRange axisRange => uJaYqLfpofEnvAccoIxqPZunHOWNA;

		public bool invert => jEWfqESJqpAuLeZjvTiQMPtCXKvKA;

		public KeyCode keyCode => snXbNgFCxTvHVaUJCvzMpgWrLXUtA;

		public ModifierKeyFlags modifierKeyFlags => SYjaGcdbbpFYJwrQzAibVXLyJyRN;

		public string elementDisplayName
		{
			get
			{
				if (DEqYGmBFzZCZEcUJydfUFPeBmpRP == null)
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
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(jqMcLvWCDtFPqaYlhPLRPHgePLwR);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				if (uUtMbWneEqhDBZKoyGCZgYUVdGGT == ControllerElementType.Axis)
				{
					if (uJaYqLfpofEnvAccoIxqPZunHOWNA == AxisRange.Full)
					{
						return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
					}
					if (uJaYqLfpofEnvAccoIxqPZunHOWNA == AxisRange.Positive)
					{
						return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName;
					}
					if (uJaYqLfpofEnvAccoIxqPZunHOWNA == AxisRange.Negative)
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
			ifJbCLCBngpUkCdkbeVdaoFWHVHfb = P_1.actionId;
			DEqYGmBFzZCZEcUJydfUFPeBmpRP = P_0;
			TuCgLQWeArAwFAIphGwovGlAFRTgb = P_1.elementMapId;
			jqMcLvWCDtFPqaYlhPLRPHgePLwR = P_1.elementIdentifierId;
			snXbNgFCxTvHVaUJCvzMpgWrLXUtA = P_1.keyboardKey;
			SYjaGcdbbpFYJwrQzAibVXLyJyRN = P_1.modifierKeyFlags;
			jEWfqESJqpAuLeZjvTiQMPtCXKvKA = P_1.invert;
			uUtMbWneEqhDBZKoyGCZgYUVdGGT = moNrVnhMyxFSevnVWYTclYHmdtVI.cTKZnruLFvxhZtYhgEqaKiQIZvgl(P_1.type);
			FNZaIAaVQhLrXaQyIuMMrMWlRvEib = P_1.axisContribution;
			uJaYqLfpofEnvAccoIxqPZunHOWNA = P_1.axisRange;
			if (DEqYGmBFzZCZEcUJydfUFPeBmpRP.controllerType == ControllerType.Keyboard)
			{
				Keyboard.NdOuanZOdKWfFCmxswwYgmFhjWAj(ref jqMcLvWCDtFPqaYlhPLRPHgePLwR, ref snXbNgFCxTvHVaUJCvzMpgWrLXUtA);
			}
		}
	}
}

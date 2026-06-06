using System;
using UnityEngine;

namespace Rewired
{
	public sealed class ElementAssignmentInfo
	{
		private readonly ControllerMap UAHTMjYauBkhjYQNFbWCskpqXvkK;

		private readonly ControllerElementType bjYeMRgjNeUvspLaZJhBJoLqpchy;

		private readonly int YmjLrLDRTzMhewJjURHulHyzfKig;

		private readonly int qSjRkmNWGtmxFKMhCNsBgFdPenRZ;

		private readonly AxisRange jTOcSfctKxPCHAylNEaUshSMenQc;

		private readonly KeyCode pVyZNdRciTdNqeRTlWrYBRTArAfF;

		private readonly ModifierKeyFlags PkQRalqcgfYgeEuUMNQbsiCDkUsS;

		private readonly int jZqMGSZHuwMmFgQoKCcfEBYhSbsPA;

		private readonly Pole AwqSpBMPttPCsscuTxnGlcBeJlrF;

		private readonly bool sXpkTPLxdbSlwndjMHHWoxehkpSG;

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (UAHTMjYauBkhjYQNFbWCskpqXvkK == null)
				{
					return null;
				}
				return UAHTMjYauBkhjYQNFbWCskpqXvkK.player;
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
				return ReInput.mapping.GetAction(jZqMGSZHuwMmFgQoKCcfEBYhSbsPA);
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
				if (UAHTMjYauBkhjYQNFbWCskpqXvkK == null)
				{
					return null;
				}
				return ReInput.controllers.GetController(UAHTMjYauBkhjYQNFbWCskpqXvkK.controllerType, UAHTMjYauBkhjYQNFbWCskpqXvkK.controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (!ReInput.isReady || UAHTMjYauBkhjYQNFbWCskpqXvkK == null)
				{
					return ControllerType.Keyboard;
				}
				return UAHTMjYauBkhjYQNFbWCskpqXvkK.controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				if (!ReInput.isReady || UAHTMjYauBkhjYQNFbWCskpqXvkK == null)
				{
					return -1;
				}
				return UAHTMjYauBkhjYQNFbWCskpqXvkK.controllerId;
			}
		}

		public ControllerMap controllerMap => UAHTMjYauBkhjYQNFbWCskpqXvkK;

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(qSjRkmNWGtmxFKMhCNsBgFdPenRZ);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (UAHTMjYauBkhjYQNFbWCskpqXvkK == null)
				{
					return null;
				}
				return UAHTMjYauBkhjYQNFbWCskpqXvkK.GetElementMap(YmjLrLDRTzMhewJjURHulHyzfKig);
			}
		}

		public ControllerElementType elementType => bjYeMRgjNeUvspLaZJhBJoLqpchy;

		public Pole axisContribution => AwqSpBMPttPCsscuTxnGlcBeJlrF;

		public AxisRange axisRange => jTOcSfctKxPCHAylNEaUshSMenQc;

		public bool invert => sXpkTPLxdbSlwndjMHHWoxehkpSG;

		public KeyCode keyCode => pVyZNdRciTdNqeRTlWrYBRTArAfF;

		public ModifierKeyFlags modifierKeyFlags => PkQRalqcgfYgeEuUMNQbsiCDkUsS;

		public string elementDisplayName
		{
			get
			{
				if (UAHTMjYauBkhjYQNFbWCskpqXvkK == null)
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
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(qSjRkmNWGtmxFKMhCNsBgFdPenRZ);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				if (bjYeMRgjNeUvspLaZJhBJoLqpchy == ControllerElementType.Axis)
				{
					if (jTOcSfctKxPCHAylNEaUshSMenQc == AxisRange.Full)
					{
						return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
					}
					if (jTOcSfctKxPCHAylNEaUshSMenQc == AxisRange.Positive)
					{
						return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName;
					}
					if (jTOcSfctKxPCHAylNEaUshSMenQc == AxisRange.Negative)
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
			jZqMGSZHuwMmFgQoKCcfEBYhSbsPA = P_1.actionId;
			UAHTMjYauBkhjYQNFbWCskpqXvkK = P_0;
			YmjLrLDRTzMhewJjURHulHyzfKig = P_1.elementMapId;
			qSjRkmNWGtmxFKMhCNsBgFdPenRZ = P_1.elementIdentifierId;
			pVyZNdRciTdNqeRTlWrYBRTArAfF = P_1.keyboardKey;
			PkQRalqcgfYgeEuUMNQbsiCDkUsS = P_1.modifierKeyFlags;
			sXpkTPLxdbSlwndjMHHWoxehkpSG = P_1.invert;
			bjYeMRgjNeUvspLaZJhBJoLqpchy = bVcNkmaJvbHeBNQRpaleQvWHeXqv.hprGByjpElSVqTapPvrydgHxKrZq(P_1.type);
			AwqSpBMPttPCsscuTxnGlcBeJlrF = P_1.axisContribution;
			jTOcSfctKxPCHAylNEaUshSMenQc = P_1.axisRange;
			if (UAHTMjYauBkhjYQNFbWCskpqXvkK.controllerType == ControllerType.Keyboard)
			{
				Keyboard.OzdkyeOPiCpqmcUxHuPGZPSCqHpq(ref qSjRkmNWGtmxFKMhCNsBgFdPenRZ, ref pVyZNdRciTdNqeRTlWrYBRTArAfF);
			}
		}
	}
}

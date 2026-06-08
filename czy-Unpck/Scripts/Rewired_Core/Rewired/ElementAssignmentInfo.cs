using System;
using UnityEngine;

namespace Rewired
{
	public sealed class ElementAssignmentInfo
	{
		private readonly ControllerMap FcwxSEAqxlQQhiIiSEyJjkwZaAa;

		private readonly ControllerElementType iDCCUtfTWxxiRkkzZhazaAppvzo;

		private readonly int GAfvfYIUUhdJTSAPLfSuRJNXfCpf;

		private readonly int yBWjkrHKbDlkjegyONinAthRElAh;

		private readonly AxisRange ULUBoZXZbPaLHXiblpGEJyjatZk;

		private readonly KeyCode zvVrLCNqeWrMDfcLTvPLsgsTFBT;

		private readonly ModifierKeyFlags YfXbVhhWcSuyNKacqoMLhXaiabR;

		private readonly int qxoYaUQyNIsvDIFklnqXHPrHJLd;

		private readonly Pole DqGgYWkBubghVSQVgMNYCIGRYGK;

		private readonly bool tUFnrkODyJPzZYlBlWfDpcjhjBr;

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (FcwxSEAqxlQQhiIiSEyJjkwZaAa == null)
				{
					return null;
				}
				return FcwxSEAqxlQQhiIiSEyJjkwZaAa.player;
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
				return ReInput.mapping.GetAction(qxoYaUQyNIsvDIFklnqXHPrHJLd);
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
				if (FcwxSEAqxlQQhiIiSEyJjkwZaAa == null)
				{
					return null;
				}
				return ReInput.controllers.GetController(FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerType, FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (!ReInput.isReady || FcwxSEAqxlQQhiIiSEyJjkwZaAa == null)
				{
					return ControllerType.Keyboard;
				}
				return FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				if (!ReInput.isReady || FcwxSEAqxlQQhiIiSEyJjkwZaAa == null)
				{
					return -1;
				}
				return FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerId;
			}
		}

		public ControllerMap controllerMap => FcwxSEAqxlQQhiIiSEyJjkwZaAa;

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(yBWjkrHKbDlkjegyONinAthRElAh);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (FcwxSEAqxlQQhiIiSEyJjkwZaAa == null)
				{
					return null;
				}
				return FcwxSEAqxlQQhiIiSEyJjkwZaAa.GetElementMap(GAfvfYIUUhdJTSAPLfSuRJNXfCpf);
			}
		}

		public ControllerElementType elementType => iDCCUtfTWxxiRkkzZhazaAppvzo;

		public Pole axisContribution => DqGgYWkBubghVSQVgMNYCIGRYGK;

		public AxisRange axisRange => ULUBoZXZbPaLHXiblpGEJyjatZk;

		public bool invert => tUFnrkODyJPzZYlBlWfDpcjhjBr;

		public KeyCode keyCode => zvVrLCNqeWrMDfcLTvPLsgsTFBT;

		public ModifierKeyFlags modifierKeyFlags => YfXbVhhWcSuyNKacqoMLhXaiabR;

		public string elementDisplayName
		{
			get
			{
				if (FcwxSEAqxlQQhiIiSEyJjkwZaAa == null)
				{
					return string.Empty;
				}
				if (controllerType == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(keyCode, modifierKeyFlags);
				}
				Controller controller = this.controller;
				ControllerElementIdentifier elementIdentifierById = default(ControllerElementIdentifier);
				int num;
				if (controller != null)
				{
					elementIdentifierById = controller.GetElementIdentifierById(yBWjkrHKbDlkjegyONinAthRElAh);
					if (elementIdentifierById == null)
					{
						return string.Empty;
					}
					if (iDCCUtfTWxxiRkkzZhazaAppvzo == ControllerElementType.Axis)
					{
						if (ULUBoZXZbPaLHXiblpGEJyjatZk == AxisRange.Full)
						{
							return elementIdentifierById.name;
						}
						if (ULUBoZXZbPaLHXiblpGEJyjatZk == AxisRange.Positive)
						{
							return elementIdentifierById.positiveName;
						}
						if (ULUBoZXZbPaLHXiblpGEJyjatZk == AxisRange.Negative)
						{
							num = -849951891;
							goto IL_0037;
						}
					}
					return elementIdentifierById.name;
				}
				goto IL_0032;
				IL_0037:
				switch (num ^ -849951892)
				{
				case 0:
					break;
				case 2:
					return string.Empty;
				default:
					return elementIdentifierById.negativeName;
				}
				goto IL_0032;
				IL_0032:
				num = -849951890;
				goto IL_0037;
			}
		}

		internal ElementAssignmentInfo(ControllerMap controllerMap, ElementAssignment assignment)
		{
			while (true)
			{
				int num = 1704899312;
				while (true)
				{
					switch (num ^ 0x659EB2F5)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						ULUBoZXZbPaLHXiblpGEJyjatZk = assignment.axisRange;
						if (FcwxSEAqxlQQhiIiSEyJjkwZaAa.controllerType == ControllerType.Keyboard)
						{
							Keyboard.FixKeyboardAssignments(ref yBWjkrHKbDlkjegyONinAthRElAh, ref zvVrLCNqeWrMDfcLTvPLsgsTFBT);
							num = 1704899318;
							continue;
						}
						return;
					case 2:
						throw new ArgumentNullException("controllerMap");
					case 5:
					{
						int num2;
						if (controllerMap == null)
						{
							num = 1704899319;
							num2 = num;
						}
						else
						{
							num = 1704899313;
							num2 = num;
						}
						continue;
					}
					case 4:
						qxoYaUQyNIsvDIFklnqXHPrHJLd = assignment.actionId;
						FcwxSEAqxlQQhiIiSEyJjkwZaAa = controllerMap;
						GAfvfYIUUhdJTSAPLfSuRJNXfCpf = assignment.elementMapId;
						num = 1704899314;
						continue;
					case 7:
						yBWjkrHKbDlkjegyONinAthRElAh = assignment.elementIdentifierId;
						zvVrLCNqeWrMDfcLTvPLsgsTFBT = assignment.keyboardKey;
						YfXbVhhWcSuyNKacqoMLhXaiabR = assignment.modifierKeyFlags;
						tUFnrkODyJPzZYlBlWfDpcjhjBr = assignment.invert;
						num = 1704899315;
						continue;
					case 6:
						iDCCUtfTWxxiRkkzZhazaAppvzo = zRJHFfVYpYamSokTjXZVUKlCnAG.MuLiOAWIhTPZfOhvnDqSQEksgWmc(assignment.type);
						DqGgYWkBubghVSQVgMNYCIGRYGK = assignment.axisContribution;
						num = 1704899316;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}
	}
}

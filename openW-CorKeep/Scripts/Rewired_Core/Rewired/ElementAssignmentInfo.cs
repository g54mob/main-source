using System;
using UnityEngine;

namespace Rewired
{
	public sealed class ElementAssignmentInfo
	{
		private readonly ControllerMap GDXUSgwoUZfWPfYnYTzthghRQosh;

		private readonly ControllerElementType hiAhSYIGdsTjWpUUUfmmLSNNodzjA;

		private readonly int CqfDoIlflvEKCPPQZSZNcutUecqC;

		private readonly int yqhvwjpWolMjvzmDNAvsDzvuWmBnA;

		private readonly AxisRange zWFduTQwRduHixjYQMFPzQfvMtpX;

		private readonly KeyCode hauPrevOKDbBCXqveXRjCJHlkLdJ;

		private readonly ModifierKeyFlags NoGtcmEOOpYaMdHuBmMMzXImJTsr;

		private readonly int tWgyYVfxAmoUfXWWBfaMUiSMenaG;

		private readonly Pole GzqMTWcfJdLfOJDSYajvyDXVKlrh;

		private readonly bool saneeMhKBrKXKCEHPQGhzHyMajQP;

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (GDXUSgwoUZfWPfYnYTzthghRQosh == null)
				{
					return null;
				}
				return GDXUSgwoUZfWPfYnYTzthghRQosh.player;
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
				return ReInput.mapping.GetAction(tWgyYVfxAmoUfXWWBfaMUiSMenaG);
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
				if (GDXUSgwoUZfWPfYnYTzthghRQosh == null)
				{
					return null;
				}
				return ReInput.controllers.GetController(GDXUSgwoUZfWPfYnYTzthghRQosh.controllerType, GDXUSgwoUZfWPfYnYTzthghRQosh.controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (!ReInput.isReady || GDXUSgwoUZfWPfYnYTzthghRQosh == null)
				{
					return ControllerType.Keyboard;
				}
				return GDXUSgwoUZfWPfYnYTzthghRQosh.controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				if (!ReInput.isReady || GDXUSgwoUZfWPfYnYTzthghRQosh == null)
				{
					return -1;
				}
				return GDXUSgwoUZfWPfYnYTzthghRQosh.controllerId;
			}
		}

		public ControllerMap controllerMap => GDXUSgwoUZfWPfYnYTzthghRQosh;

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(yqhvwjpWolMjvzmDNAvsDzvuWmBnA);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (GDXUSgwoUZfWPfYnYTzthghRQosh == null)
				{
					return null;
				}
				return GDXUSgwoUZfWPfYnYTzthghRQosh.GetElementMap(CqfDoIlflvEKCPPQZSZNcutUecqC);
			}
		}

		public ControllerElementType elementType => hiAhSYIGdsTjWpUUUfmmLSNNodzjA;

		public Pole axisContribution => GzqMTWcfJdLfOJDSYajvyDXVKlrh;

		public AxisRange axisRange => zWFduTQwRduHixjYQMFPzQfvMtpX;

		public bool invert => saneeMhKBrKXKCEHPQGhzHyMajQP;

		public KeyCode keyCode => hauPrevOKDbBCXqveXRjCJHlkLdJ;

		public ModifierKeyFlags modifierKeyFlags => NoGtcmEOOpYaMdHuBmMMzXImJTsr;

		public string elementDisplayName
		{
			get
			{
				if (GDXUSgwoUZfWPfYnYTzthghRQosh == null)
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
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(yqhvwjpWolMjvzmDNAvsDzvuWmBnA);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				if (hiAhSYIGdsTjWpUUUfmmLSNNodzjA == ControllerElementType.Axis)
				{
					if (zWFduTQwRduHixjYQMFPzQfvMtpX == AxisRange.Full)
					{
						return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
					}
					if (zWFduTQwRduHixjYQMFPzQfvMtpX == AxisRange.Positive)
					{
						return elementIdentifierById.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName;
					}
					if (zWFduTQwRduHixjYQMFPzQfvMtpX == AxisRange.Negative)
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
			tWgyYVfxAmoUfXWWBfaMUiSMenaG = P_1.actionId;
			GDXUSgwoUZfWPfYnYTzthghRQosh = P_0;
			CqfDoIlflvEKCPPQZSZNcutUecqC = P_1.elementMapId;
			yqhvwjpWolMjvzmDNAvsDzvuWmBnA = P_1.elementIdentifierId;
			hauPrevOKDbBCXqveXRjCJHlkLdJ = P_1.keyboardKey;
			NoGtcmEOOpYaMdHuBmMMzXImJTsr = P_1.modifierKeyFlags;
			saneeMhKBrKXKCEHPQGhzHyMajQP = P_1.invert;
			hiAhSYIGdsTjWpUUUfmmLSNNodzjA = nwsTruCLxjorysrNysDvPYrmMcrb.jufGHxaTwzWJImsLUguNuiJYioFNA(P_1.type);
			GzqMTWcfJdLfOJDSYajvyDXVKlrh = P_1.axisContribution;
			zWFduTQwRduHixjYQMFPzQfvMtpX = P_1.axisRange;
			if (GDXUSgwoUZfWPfYnYTzthghRQosh.controllerType == ControllerType.Keyboard)
			{
				Keyboard.EfnCgvkaMMnmCiLNUrWbSEUfNAxNA(ref yqhvwjpWolMjvzmDNAvsDzvuWmBnA, ref hauPrevOKDbBCXqveXRjCJHlkLdJ);
			}
		}
	}
}

using System;
using UnityEngine;

namespace Rewired
{
	public sealed class ElementAssignmentInfo
	{
		private readonly ControllerMap fcPcTXdclCfFXHGkwVhNNBHdQNBk;

		private readonly ControllerElementType IDlBgcIyMAualOodjeMvFCUPFMBW;

		private readonly int gAYZSLfQFYythgDFztjkfacvnnQ;

		private readonly int MAfbKattduhdBJEmosLzsDAtqCjp;

		private readonly AxisRange iKpdeCcvrahntrCdBHCMvDYKvQZ;

		private readonly KeyCode BxuLSHaHsvketBoTjeGXEhXvhku;

		private readonly ModifierKeyFlags wDaZeqSOupdtjqsnOLPLLqlYXsh;

		private readonly int CYBGYVfPDvCydagiBzJBExAfcuYb;

		private readonly Pole dqvocVVDwCzopurHObiMuAnppvn;

		private readonly bool HTcNJhfsJaGkhcFqZdFJZCbLyyS;

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (fcPcTXdclCfFXHGkwVhNNBHdQNBk == null)
				{
					return null;
				}
				return fcPcTXdclCfFXHGkwVhNNBHdQNBk.player;
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
				return ReInput.mapping.GetAction(CYBGYVfPDvCydagiBzJBExAfcuYb);
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
				if (fcPcTXdclCfFXHGkwVhNNBHdQNBk == null)
				{
					return null;
				}
				return ReInput.controllers.GetController(fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerType, fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (!ReInput.isReady || fcPcTXdclCfFXHGkwVhNNBHdQNBk == null)
				{
					return ControllerType.Keyboard;
				}
				return fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				if (!ReInput.isReady || fcPcTXdclCfFXHGkwVhNNBHdQNBk == null)
				{
					return -1;
				}
				return fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerId;
			}
		}

		public ControllerMap controllerMap => fcPcTXdclCfFXHGkwVhNNBHdQNBk;

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(MAfbKattduhdBJEmosLzsDAtqCjp);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (fcPcTXdclCfFXHGkwVhNNBHdQNBk == null)
				{
					return null;
				}
				return fcPcTXdclCfFXHGkwVhNNBHdQNBk.GetElementMap(gAYZSLfQFYythgDFztjkfacvnnQ);
			}
		}

		public ControllerElementType elementType => IDlBgcIyMAualOodjeMvFCUPFMBW;

		public Pole axisContribution => dqvocVVDwCzopurHObiMuAnppvn;

		public AxisRange axisRange => iKpdeCcvrahntrCdBHCMvDYKvQZ;

		public bool invert => HTcNJhfsJaGkhcFqZdFJZCbLyyS;

		public KeyCode keyCode => BxuLSHaHsvketBoTjeGXEhXvhku;

		public ModifierKeyFlags modifierKeyFlags => wDaZeqSOupdtjqsnOLPLLqlYXsh;

		public string elementDisplayName
		{
			get
			{
				if (fcPcTXdclCfFXHGkwVhNNBHdQNBk == null)
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
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(MAfbKattduhdBJEmosLzsDAtqCjp);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				if (IDlBgcIyMAualOodjeMvFCUPFMBW == ControllerElementType.Axis)
				{
					if (iKpdeCcvrahntrCdBHCMvDYKvQZ == AxisRange.Full)
					{
						return elementIdentifierById.name;
					}
					if (iKpdeCcvrahntrCdBHCMvDYKvQZ == AxisRange.Positive)
					{
						return elementIdentifierById.positiveName;
					}
					if (iKpdeCcvrahntrCdBHCMvDYKvQZ == AxisRange.Negative)
					{
						return elementIdentifierById.negativeName;
					}
				}
				return elementIdentifierById.name;
			}
		}

		internal ElementAssignmentInfo(ControllerMap controllerMap, ElementAssignment assignment)
		{
			if (controllerMap == null)
			{
				throw new ArgumentNullException("controllerMap");
			}
			CYBGYVfPDvCydagiBzJBExAfcuYb = assignment.actionId;
			fcPcTXdclCfFXHGkwVhNNBHdQNBk = controllerMap;
			gAYZSLfQFYythgDFztjkfacvnnQ = assignment.elementMapId;
			MAfbKattduhdBJEmosLzsDAtqCjp = assignment.elementIdentifierId;
			BxuLSHaHsvketBoTjeGXEhXvhku = assignment.keyboardKey;
			wDaZeqSOupdtjqsnOLPLLqlYXsh = assignment.modifierKeyFlags;
			HTcNJhfsJaGkhcFqZdFJZCbLyyS = assignment.invert;
			IDlBgcIyMAualOodjeMvFCUPFMBW = XqmnYoifzflCsKxcFaHDewlkEkh.oVgOuHppbsfQJuEfZwNSyeJURnL(assignment.type);
			dqvocVVDwCzopurHObiMuAnppvn = assignment.axisContribution;
			iKpdeCcvrahntrCdBHCMvDYKvQZ = assignment.axisRange;
			if (fcPcTXdclCfFXHGkwVhNNBHdQNBk.controllerType == ControllerType.Keyboard)
			{
				Keyboard.VpPkczmTNQbDyXwjTOeJteHwqti(ref MAfbKattduhdBJEmosLzsDAtqCjp, ref BxuLSHaHsvketBoTjeGXEhXvhku);
			}
		}
	}
}

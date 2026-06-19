using System;
using UnityEngine;

namespace Rewired
{
	public sealed class ElementAssignmentInfo
	{
		private readonly ControllerMap BwdkYrCIFNiRPDEpxxAUFyIFLij;

		private readonly ControllerElementType yWNDZKfljBHzdFXVgCeuIlnzKfx;

		private readonly int AnugZrIVxZBnfpinqnprvrNLxfa;

		private readonly int aKTKfMYcYdTWZLyYfpZoZfzZGQT;

		private readonly AxisRange INqAuPUOdfKjEyVKDGDlvfaJUlc;

		private readonly KeyCode tZYyArRcRkLxjOshwQPUAfmDHaI;

		private readonly ModifierKeyFlags QaOwhKpQpcMhpjcMVDDKPLBmZPQ;

		private readonly int sRbRrhSYcsdTbzpQQADExfvLSkq;

		private readonly Pole TdJcRpjgNZFTplnvRloFjqQVLfBE;

		private readonly bool rqWybVSDLptxnnIdEIbMBmnbSae;

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (BwdkYrCIFNiRPDEpxxAUFyIFLij == null)
				{
					return null;
				}
				return BwdkYrCIFNiRPDEpxxAUFyIFLij.player;
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
				return ReInput.mapping.GetAction(sRbRrhSYcsdTbzpQQADExfvLSkq);
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
				if (BwdkYrCIFNiRPDEpxxAUFyIFLij == null)
				{
					return null;
				}
				return ReInput.controllers.GetController(BwdkYrCIFNiRPDEpxxAUFyIFLij.controllerType, BwdkYrCIFNiRPDEpxxAUFyIFLij.controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (!ReInput.isReady || BwdkYrCIFNiRPDEpxxAUFyIFLij == null)
				{
					return ControllerType.Keyboard;
				}
				return BwdkYrCIFNiRPDEpxxAUFyIFLij.controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				if (!ReInput.isReady || BwdkYrCIFNiRPDEpxxAUFyIFLij == null)
				{
					return -1;
				}
				return BwdkYrCIFNiRPDEpxxAUFyIFLij.controllerId;
			}
		}

		public ControllerMap controllerMap => BwdkYrCIFNiRPDEpxxAUFyIFLij;

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(aKTKfMYcYdTWZLyYfpZoZfzZGQT);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (BwdkYrCIFNiRPDEpxxAUFyIFLij == null)
				{
					return null;
				}
				return BwdkYrCIFNiRPDEpxxAUFyIFLij.GetElementMap(AnugZrIVxZBnfpinqnprvrNLxfa);
			}
		}

		public ControllerElementType elementType => yWNDZKfljBHzdFXVgCeuIlnzKfx;

		public Pole axisContribution => TdJcRpjgNZFTplnvRloFjqQVLfBE;

		public AxisRange axisRange => INqAuPUOdfKjEyVKDGDlvfaJUlc;

		public bool invert => rqWybVSDLptxnnIdEIbMBmnbSae;

		public KeyCode keyCode => tZYyArRcRkLxjOshwQPUAfmDHaI;

		public ModifierKeyFlags modifierKeyFlags => QaOwhKpQpcMhpjcMVDDKPLBmZPQ;

		public string elementDisplayName
		{
			get
			{
				if (BwdkYrCIFNiRPDEpxxAUFyIFLij == null)
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
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(aKTKfMYcYdTWZLyYfpZoZfzZGQT);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				if (yWNDZKfljBHzdFXVgCeuIlnzKfx == ControllerElementType.Axis)
				{
					if (INqAuPUOdfKjEyVKDGDlvfaJUlc == AxisRange.Full)
					{
						return elementIdentifierById.name;
					}
					if (INqAuPUOdfKjEyVKDGDlvfaJUlc == AxisRange.Positive)
					{
						return elementIdentifierById.positiveName;
					}
					if (INqAuPUOdfKjEyVKDGDlvfaJUlc == AxisRange.Negative)
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
			sRbRrhSYcsdTbzpQQADExfvLSkq = assignment.actionId;
			BwdkYrCIFNiRPDEpxxAUFyIFLij = controllerMap;
			AnugZrIVxZBnfpinqnprvrNLxfa = assignment.elementMapId;
			aKTKfMYcYdTWZLyYfpZoZfzZGQT = assignment.elementIdentifierId;
			tZYyArRcRkLxjOshwQPUAfmDHaI = assignment.keyboardKey;
			QaOwhKpQpcMhpjcMVDDKPLBmZPQ = assignment.modifierKeyFlags;
			rqWybVSDLptxnnIdEIbMBmnbSae = assignment.invert;
			yWNDZKfljBHzdFXVgCeuIlnzKfx = bEUEMZWgpCwBXKGSoWTyQESUVD.ImSGBfeSUdhdHajXEMFVtcmiijjJ(assignment.type);
			TdJcRpjgNZFTplnvRloFjqQVLfBE = assignment.axisContribution;
			INqAuPUOdfKjEyVKDGDlvfaJUlc = assignment.axisRange;
			if (BwdkYrCIFNiRPDEpxxAUFyIFLij.controllerType == ControllerType.Keyboard)
			{
				Keyboard.pVpzVTFcuJpkyCBLMXuWlfgKhbMJ(ref aKTKfMYcYdTWZLyYfpZoZfzZGQT, ref tZYyArRcRkLxjOshwQPUAfmDHaI);
			}
		}
	}
}

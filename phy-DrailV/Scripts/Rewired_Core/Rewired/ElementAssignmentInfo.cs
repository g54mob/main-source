using System;
using UnityEngine;

namespace Rewired
{
	public sealed class ElementAssignmentInfo
	{
		private readonly ControllerMap KQrkQkAkhknsIKIpiSyrmaMcHTQc;

		private readonly ControllerElementType jRBPSVtNKcYysODJtvbPjIhQUBZJ;

		private readonly int RgkmkgUUNyMYwsChvSaEYBBmdzEK;

		private readonly int hkJhlFMpiETPSIkMyOmVuFxkJKlT;

		private readonly AxisRange PpBKvDDuwSJgSbXdRraQGlHTKPPc;

		private readonly KeyCode cEMwviPpEXMoeVlCpjvfpcneqbmd;

		private readonly ModifierKeyFlags LAWskThCRZDFawlWQqsxyYTLFVmX;

		private readonly int nqrNxyIjKJnAagqUPKmjCYvwkyMr;

		private readonly Pole IYTFZmytpwZEumqfEMDkFoEwUfno;

		private readonly bool alMuiGYujWanyqnrVCGdmGfWAcGR;

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (KQrkQkAkhknsIKIpiSyrmaMcHTQc == null)
				{
					return null;
				}
				return KQrkQkAkhknsIKIpiSyrmaMcHTQc.player;
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
				return ReInput.mapping.GetAction(nqrNxyIjKJnAagqUPKmjCYvwkyMr);
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
				if (KQrkQkAkhknsIKIpiSyrmaMcHTQc == null)
				{
					return null;
				}
				return ReInput.controllers.GetController(KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerType, KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (!ReInput.isReady || KQrkQkAkhknsIKIpiSyrmaMcHTQc == null)
				{
					return ControllerType.Keyboard;
				}
				return KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				if (!ReInput.isReady || KQrkQkAkhknsIKIpiSyrmaMcHTQc == null)
				{
					return -1;
				}
				return KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerId;
			}
		}

		public ControllerMap controllerMap => KQrkQkAkhknsIKIpiSyrmaMcHTQc;

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(hkJhlFMpiETPSIkMyOmVuFxkJKlT);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (KQrkQkAkhknsIKIpiSyrmaMcHTQc == null)
				{
					return null;
				}
				return KQrkQkAkhknsIKIpiSyrmaMcHTQc.GetElementMap(RgkmkgUUNyMYwsChvSaEYBBmdzEK);
			}
		}

		public ControllerElementType elementType => jRBPSVtNKcYysODJtvbPjIhQUBZJ;

		public Pole axisContribution => IYTFZmytpwZEumqfEMDkFoEwUfno;

		public AxisRange axisRange => PpBKvDDuwSJgSbXdRraQGlHTKPPc;

		public bool invert => alMuiGYujWanyqnrVCGdmGfWAcGR;

		public KeyCode keyCode => cEMwviPpEXMoeVlCpjvfpcneqbmd;

		public ModifierKeyFlags modifierKeyFlags => LAWskThCRZDFawlWQqsxyYTLFVmX;

		public string elementDisplayName
		{
			get
			{
				if (KQrkQkAkhknsIKIpiSyrmaMcHTQc == null)
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
				ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(hkJhlFMpiETPSIkMyOmVuFxkJKlT);
				if (elementIdentifierById == null)
				{
					return string.Empty;
				}
				if (jRBPSVtNKcYysODJtvbPjIhQUBZJ == ControllerElementType.Axis)
				{
					if (PpBKvDDuwSJgSbXdRraQGlHTKPPc == AxisRange.Full)
					{
						return elementIdentifierById.name;
					}
					if (PpBKvDDuwSJgSbXdRraQGlHTKPPc == AxisRange.Positive)
					{
						return elementIdentifierById.positiveName;
					}
					if (PpBKvDDuwSJgSbXdRraQGlHTKPPc == AxisRange.Negative)
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
			nqrNxyIjKJnAagqUPKmjCYvwkyMr = P_1.actionId;
			KQrkQkAkhknsIKIpiSyrmaMcHTQc = P_0;
			RgkmkgUUNyMYwsChvSaEYBBmdzEK = P_1.elementMapId;
			hkJhlFMpiETPSIkMyOmVuFxkJKlT = P_1.elementIdentifierId;
			cEMwviPpEXMoeVlCpjvfpcneqbmd = P_1.keyboardKey;
			LAWskThCRZDFawlWQqsxyYTLFVmX = P_1.modifierKeyFlags;
			alMuiGYujWanyqnrVCGdmGfWAcGR = P_1.invert;
			jRBPSVtNKcYysODJtvbPjIhQUBZJ = uAOMfTHsnTLbvEUpHTchXYOhMgjh.XLKAHwgEgKUaInaXPLsoBHajZhZyA(P_1.type);
			IYTFZmytpwZEumqfEMDkFoEwUfno = P_1.axisContribution;
			PpBKvDDuwSJgSbXdRraQGlHTKPPc = P_1.axisRange;
			if (KQrkQkAkhknsIKIpiSyrmaMcHTQc.controllerType == ControllerType.Keyboard)
			{
				Keyboard.cBfVBUZbWeWptZKZFvHhKPyjnheu(ref hkJhlFMpiETPSIkMyOmVuFxkJKlT, ref cEMwviPpEXMoeVlCpjvfpcneqbmd);
			}
		}
	}
}

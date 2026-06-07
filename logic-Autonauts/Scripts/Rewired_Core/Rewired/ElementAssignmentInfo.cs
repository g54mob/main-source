using System;
using UnityEngine;

namespace Rewired
{
	public sealed class ElementAssignmentInfo
	{
		private readonly ControllerMap yAkjWJqxMpaNcNJFRMpKjoUYObX;

		private readonly ControllerElementType ZcCJfoFOnfaVWPxSGABewnPoqKP;

		private readonly int ddrjGRJibtSiCpvkICrzeTvjIRQC;

		private readonly int TZSPqisJATrQkFfRXLKedgRIcwv;

		private readonly AxisRange jlEnqYlFCTxpQiXKkRUPTZLnjeL;

		private readonly KeyCode EZXgGJlJJGLqECQiOgASqMQAZMg;

		private readonly ModifierKeyFlags tmDdGydFlWVbCarXzSZWfplxDpyN;

		private readonly int ZUoDkTcclUigIzTjeFLCXFMQOaU;

		private readonly Pole wLEjKNOLFnsGKpXyzkxPOqxGPgl;

		private readonly bool GxVGOhAsFVqIMspcaPfClxXqvUAu;

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (yAkjWJqxMpaNcNJFRMpKjoUYObX == null)
				{
					return null;
				}
				return yAkjWJqxMpaNcNJFRMpKjoUYObX.player;
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
				return ReInput.mapping.GetAction(ZUoDkTcclUigIzTjeFLCXFMQOaU);
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
				if (yAkjWJqxMpaNcNJFRMpKjoUYObX == null)
				{
					return null;
				}
				return ReInput.controllers.GetController(yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerType, yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (!ReInput.isReady || yAkjWJqxMpaNcNJFRMpKjoUYObX == null)
				{
					return ControllerType.Keyboard;
				}
				return yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerType;
			}
		}

		public int controllerId
		{
			get
			{
				if (!ReInput.isReady || yAkjWJqxMpaNcNJFRMpKjoUYObX == null)
				{
					return -1;
				}
				return yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerId;
			}
		}

		public ControllerMap controllerMap
		{
			get
			{
				return yAkjWJqxMpaNcNJFRMpKjoUYObX;
			}
		}

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (controller == null)
				{
					return null;
				}
				return controller.GetElementIdentifierById(TZSPqisJATrQkFfRXLKedgRIcwv);
			}
		}

		public ActionElementMap elementMap
		{
			get
			{
				if (yAkjWJqxMpaNcNJFRMpKjoUYObX == null)
				{
					return null;
				}
				return yAkjWJqxMpaNcNJFRMpKjoUYObX.GetElementMap(ddrjGRJibtSiCpvkICrzeTvjIRQC);
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return ZcCJfoFOnfaVWPxSGABewnPoqKP;
			}
		}

		public Pole axisContribution
		{
			get
			{
				return wLEjKNOLFnsGKpXyzkxPOqxGPgl;
			}
		}

		public AxisRange axisRange
		{
			get
			{
				return jlEnqYlFCTxpQiXKkRUPTZLnjeL;
			}
		}

		public bool invert
		{
			get
			{
				return GxVGOhAsFVqIMspcaPfClxXqvUAu;
			}
		}

		public KeyCode keyCode
		{
			get
			{
				return EZXgGJlJJGLqECQiOgASqMQAZMg;
			}
		}

		public ModifierKeyFlags modifierKeyFlags
		{
			get
			{
				return tmDdGydFlWVbCarXzSZWfplxDpyN;
			}
		}

		public string elementDisplayName
		{
			get
			{
				if (yAkjWJqxMpaNcNJFRMpKjoUYObX == null)
				{
					return string.Empty;
				}
				if (controllerType == ControllerType.Keyboard)
				{
					return Keyboard.GetKeyName(keyCode, modifierKeyFlags);
				}
				Controller controller = this.controller;
				ControllerElementIdentifier elementIdentifierById = default(ControllerElementIdentifier);
				while (true)
				{
					int num = -315214455;
					while (true)
					{
						switch (num ^ -315214456)
						{
						case 3:
							break;
						case 1:
							if (controller == null)
							{
								num = -315214456;
								continue;
							}
							elementIdentifierById = controller.GetElementIdentifierById(TZSPqisJATrQkFfRXLKedgRIcwv);
							if (elementIdentifierById == null)
							{
								return string.Empty;
							}
							if (ZcCJfoFOnfaVWPxSGABewnPoqKP == ControllerElementType.Axis)
							{
								if (jlEnqYlFCTxpQiXKkRUPTZLnjeL == AxisRange.Full)
								{
									return elementIdentifierById.name;
								}
								if (jlEnqYlFCTxpQiXKkRUPTZLnjeL == AxisRange.Positive)
								{
									num = -315214454;
									continue;
								}
								if (jlEnqYlFCTxpQiXKkRUPTZLnjeL == AxisRange.Negative)
								{
									num = -315214452;
									continue;
								}
							}
							return elementIdentifierById.name;
						case 0:
							return string.Empty;
						case 2:
							return elementIdentifierById.positiveName;
						default:
							return elementIdentifierById.negativeName;
						}
						break;
					}
				}
			}
		}

		internal ElementAssignmentInfo(ControllerMap controllerMap, ElementAssignment assignment)
		{
			if (controllerMap == null)
			{
				throw new ArgumentNullException("controllerMap");
			}
			ZUoDkTcclUigIzTjeFLCXFMQOaU = assignment.actionId;
			yAkjWJqxMpaNcNJFRMpKjoUYObX = controllerMap;
			ddrjGRJibtSiCpvkICrzeTvjIRQC = assignment.elementMapId;
			TZSPqisJATrQkFfRXLKedgRIcwv = assignment.elementIdentifierId;
			EZXgGJlJJGLqECQiOgASqMQAZMg = assignment.keyboardKey;
			tmDdGydFlWVbCarXzSZWfplxDpyN = assignment.modifierKeyFlags;
			GxVGOhAsFVqIMspcaPfClxXqvUAu = assignment.invert;
			ZcCJfoFOnfaVWPxSGABewnPoqKP = KVNLqybISELdZVRJeMgGCnyHIcv.tqXxoFypSRMjqbMSyPdRCcUlCPX(assignment.type);
			wLEjKNOLFnsGKpXyzkxPOqxGPgl = assignment.axisContribution;
			jlEnqYlFCTxpQiXKkRUPTZLnjeL = assignment.axisRange;
			if (yAkjWJqxMpaNcNJFRMpKjoUYObX.controllerType == ControllerType.Keyboard)
			{
				Keyboard.FixKeyboardAssignments(ref TZSPqisJATrQkFfRXLKedgRIcwv, ref EZXgGJlJJGLqECQiOgASqMQAZMg);
			}
		}
	}
}

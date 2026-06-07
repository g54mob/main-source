using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal sealed class LrxjGZteHmJMKhKqexjHMLnoIwmG : IHardwareControllerTemplateMap, IHardwareControllerTemplateMap_Internal
{
	private struct QDZJmRFGrYlwQrvAvRZYCQPQyHOD : IControllerTemplateMapSpecialElement_Internal
	{
		private IControllerTemplateMapSpecialElement_Internal RxRgCoDfRuztChpwSLyKyHQWeXYBA;

		public QDZJmRFGrYlwQrvAvRZYCQPQyHOD(IControllerTemplateMapSpecialElement_Internal P_0)
		{
			RxRgCoDfRuztChpwSLyKyHQWeXYBA = P_0;
		}

		public T GetMapping<T>() where T : ControllerTemplateSpecialElementMapping
		{
			return RxRgCoDfRuztChpwSLyKyHQWeXYBA.GetMapping<T>();
		}

		T IControllerTemplateMapSpecialElement_Internal.GetMapping<T>()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetMapping
			return this.GetMapping<T>();
		}
	}

	private HardwareJoystickTemplateMap xYtQdJgnjgQlJJIZFTpVoTCkiyTP;

	private string XIyZLpKAryslwtOyjtkapodljHfl;

	private string EgTZECgjljIiQVgxDnSIzIFxAvhiA;

	private string ZHYTmzkRPJVmIhURDxmDNcFbbaMp;

	private readonly Guid rFDHpeXodKbnuEjIvhNYfkSXNlzdA;

	private readonly List<HardwareJoystickTemplateMap.Entry> rAqBwLGwGeQSOuCVibMHAGaVISmdA;

	private readonly ControllerTemplateElementIdentifier[] QbEDkiZiAsBIsacvmrsgpeVTcHGSA;

	private readonly DeviceLocalizationInfo UlqRuYtPHkGkIgeCpuXFqAMeaTtBb;

	[NonSerialized]
	private Func<Guid, HardwareJoystickTemplateMap.Entry> edsiphDRubykjBGoUgFmoUUySRTZ;

	public string name => XIyZLpKAryslwtOyjtkapodljHfl;

	public string pVYpWKuNwApnRJoZBAKraKRvLpUHb => EgTZECgjljIiQVgxDnSIzIFxAvhiA;

	public string HoIAuVAaPCIxyNXusRNKsHtvimal => ZHYTmzkRPJVmIhURDxmDNcFbbaMp;

	public Guid ZTZpSgAAOhpivnKYmfHXcJrNdosn => rFDHpeXodKbnuEjIvhNYfkSXNlzdA;

	string IHardwareControllerTemplateMap_Internal.name => XIyZLpKAryslwtOyjtkapodljHfl;

	Guid IHardwareControllerTemplateMap_Internal.typeGuid => rFDHpeXodKbnuEjIvhNYfkSXNlzdA;

	string IHardwareControllerTemplateMap_Internal.typeKey => ZHYTmzkRPJVmIhURDxmDNcFbbaMp;

	private Func<Guid, HardwareJoystickTemplateMap.Entry> PicZzKePsrnNIYsprvoleBKvWoTE => IaHerTHgkswhZngnRyttAAfvdSvC;

	public LrxjGZteHmJMKhKqexjHMLnoIwmG(HardwareJoystickTemplateMap P_0, List<HardwareJoystickTemplateMap.Entry> P_1, ControllerTemplateElementIdentifier[] P_2)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException();
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException();
		}
		xYtQdJgnjgQlJJIZFTpVoTCkiyTP = P_0;
		XIyZLpKAryslwtOyjtkapodljHfl = P_0.name;
		EgTZECgjljIiQVgxDnSIzIFxAvhiA = P_0.ClassName;
		rFDHpeXodKbnuEjIvhNYfkSXNlzdA = P_0.Guid;
		ZHYTmzkRPJVmIhURDxmDNcFbbaMp = P_0.Key;
		rAqBwLGwGeQSOuCVibMHAGaVISmdA = P_1;
		QbEDkiZiAsBIsacvmrsgpeVTcHGSA = P_2;
		UlqRuYtPHkGkIgeCpuXFqAMeaTtBb = new DeviceLocalizationInfo(ControllerType.Joystick, true, ZTZpSgAAOhpivnKYmfHXcJrNdosn, new AList<string> { ZHYTmzkRPJVmIhURDxmDNcFbbaMp }, null);
		UlqRuYtPHkGkIgeCpuXFqAMeaTtBb.FinishRuntimeSetup();
		bool flag = UlqRuYtPHkGkIgeCpuXFqAMeaTtBb.controllerType != ControllerType.Keyboard && UlqRuYtPHkGkIgeCpuXFqAMeaTtBb.controllerType != ControllerType.Mouse;
		for (int i = 0; i < QbEDkiZiAsBIsacvmrsgpeVTcHGSA.Length; i++)
		{
			if (QbEDkiZiAsBIsacvmrsgpeVTcHGSA[i] == null)
			{
				continue;
			}
			if (flag)
			{
				if (ControllerTemplateElementIdentifier.LbpTNHNkqlWCnLIWmRiRivKZtjC.kKLxXkLKNigdNfGeMEaVphhjwzRM(UlqRuYtPHkGkIgeCpuXFqAMeaTtBb, QbEDkiZiAsBIsacvmrsgpeVTcHGSA[i], out var controllerTemplateElementIdentifier))
				{
					QbEDkiZiAsBIsacvmrsgpeVTcHGSA[i] = controllerTemplateElementIdentifier;
					continue;
				}
				ControllerTemplateElementIdentifier.LbpTNHNkqlWCnLIWmRiRivKZtjC.rezfUyvlAJAcsKitNLkDnRKfPYIQA(UlqRuYtPHkGkIgeCpuXFqAMeaTtBb, QbEDkiZiAsBIsacvmrsgpeVTcHGSA[i]);
			}
			QbEDkiZiAsBIsacvmrsgpeVTcHGSA[i].FinishRuntimeSetup(UlqRuYtPHkGkIgeCpuXFqAMeaTtBb);
		}
	}

	public ControllerTemplateElementIdentifier bqUeWqXVHAHAekdcvzMvjQOTwUPG(Guid P_0, int P_1)
	{
		if (P_0 == Guid.Empty || P_1 < 0)
		{
			return null;
		}
		if (rAqBwLGwGeQSOuCVibMHAGaVISmdA == null)
		{
			return null;
		}
		int num = -1;
		int count = rAqBwLGwGeQSOuCVibMHAGaVISmdA.Count;
		for (int i = 0; i < count; i++)
		{
			if (rAqBwLGwGeQSOuCVibMHAGaVISmdA[i] != null && rAqBwLGwGeQSOuCVibMHAGaVISmdA[i].JoystickGuid == P_0)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return null;
		}
		HardwareJoystickTemplateMap.Entry entry = rAqBwLGwGeQSOuCVibMHAGaVISmdA[num];
		if (entry == null)
		{
			return null;
		}
		int templateElementId = entry.GetTemplateElementId(P_1);
		if (templateElementId < 0)
		{
			return null;
		}
		return HardwareJoystickTemplateMap.xfTgyRfIrjozjBGmauZVnIrMPIxfB(QbEDkiZiAsBIsacvmrsgpeVTcHGSA, templateElementId);
	}

	public int ZrEphZfAhHaydVwxQydLSkTLSWLU(Guid P_0, int P_1, List<HardwareControllerTemplateMap.yqBpozNnUGXldJOvkEybfHAdbgiGA> P_2)
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("results");
		}
		if (P_0 == Guid.Empty || P_1 < 0)
		{
			return 0;
		}
		if (rAqBwLGwGeQSOuCVibMHAGaVISmdA == null)
		{
			return 0;
		}
		int num = -1;
		int count = rAqBwLGwGeQSOuCVibMHAGaVISmdA.Count;
		for (int i = 0; i < count; i++)
		{
			if (rAqBwLGwGeQSOuCVibMHAGaVISmdA[i] != null && rAqBwLGwGeQSOuCVibMHAGaVISmdA[i].JoystickGuid == P_0)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return 0;
		}
		HardwareJoystickTemplateMap.Entry entry = rAqBwLGwGeQSOuCVibMHAGaVISmdA[num];
		if (entry == null)
		{
			return 0;
		}
		int count2 = P_2.Count;
		int num2 = ((entry.elementIdentifierMappings != null) ? entry.elementIdentifierMappings.Count : 0);
		for (int j = 0; j < num2; j++)
		{
			if (entry.elementIdentifierMappings == null)
			{
				continue;
			}
			HardwareJoystickTemplateMap.ElementIdentifierMap elementIdentifierMap = entry.elementIdentifierMappings[j];
			if (elementIdentifierMap == null)
			{
				continue;
			}
			ControllerTemplateElementIdentifier controllerTemplateElementIdentifier = FfHoPKADKCdJAevSoqiLJdqJcRGXA(QbEDkiZiAsBIsacvmrsgpeVTcHGSA, elementIdentifierMap.templateId);
			if (controllerTemplateElementIdentifier == null)
			{
				continue;
			}
			if (controllerTemplateElementIdentifier.Rewired_002EInterfaces_002EIControllerTemplateElementIdentifier_002EelementType == ControllerTemplateElementType.Axis)
			{
				if (elementIdentifierMap.splitAxis)
				{
					if (elementIdentifierMap.joystickId != P_1 && elementIdentifierMap.joystickId2 != P_1)
					{
						continue;
					}
				}
				else if (elementIdentifierMap.joystickId != P_1)
				{
					continue;
				}
			}
			else if (elementIdentifierMap.joystickId != P_1)
			{
				continue;
			}
			P_2.Add(new HardwareControllerTemplateMap.yqBpozNnUGXldJOvkEybfHAdbgiGA
			{
				LMYSYqjtklXtRoxFDbfzBhBhObdG = elementIdentifierMap.templateId,
				xAhouHtfvDriGGBEaTnoBhdQDGaz = elementIdentifierMap.joystickId,
				siVMNgCkEjxszoPpjaXnFTBUKdtgb = elementIdentifierMap.joystickId2,
				ikPUxbTBzIBhYnhdsRwrgigBlYgR = (controllerTemplateElementIdentifier.Rewired_002EInterfaces_002EIControllerTemplateElementIdentifier_002EelementType == ControllerTemplateElementType.Axis && elementIdentifierMap.splitAxis)
			});
		}
		return P_2.Count - count2;
	}

	private HardwareJoystickTemplateMap.Entry IaHerTHgkswhZngnRyttAAfvdSvC(Guid P_0)
	{
		if (rAqBwLGwGeQSOuCVibMHAGaVISmdA == null)
		{
			return null;
		}
		for (int i = 0; i < rAqBwLGwGeQSOuCVibMHAGaVISmdA.Count; i++)
		{
			if (rAqBwLGwGeQSOuCVibMHAGaVISmdA[i].JoystickGuid == P_0)
			{
				return rAqBwLGwGeQSOuCVibMHAGaVISmdA[i];
			}
		}
		return null;
	}

	private static ControllerTemplateElementIdentifier FfHoPKADKCdJAevSoqiLJdqJcRGXA(ControllerTemplateElementIdentifier[] P_0, int P_1)
	{
		if (P_0 == null)
		{
			return null;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i] != null && P_0[i].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid == P_1)
			{
				return P_0[i];
			}
		}
		return null;
	}

	int IHardwareControllerTemplateMap_Internal.GetElementIdentifierCount()
	{
		if (QbEDkiZiAsBIsacvmrsgpeVTcHGSA == null)
		{
			return 0;
		}
		return QbEDkiZiAsBIsacvmrsgpeVTcHGSA.Length;
	}

	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifier(int index)
	{
		if (QbEDkiZiAsBIsacvmrsgpeVTcHGSA == null)
		{
			return null;
		}
		return QbEDkiZiAsBIsacvmrsgpeVTcHGSA[index];
	}

	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.xfTgyRfIrjozjBGmauZVnIrMPIxfB(QbEDkiZiAsBIsacvmrsgpeVTcHGSA, elementIdentifierId);
	}

	IControllerTemplateMapSpecialElement_Internal IHardwareControllerTemplateMap_Internal.GetSpecialTemplateElementByElementIdentifierId(int id)
	{
		return new QDZJmRFGrYlwQrvAvRZYCQPQyHOD(((IHardwareControllerTemplateMap_Internal)xYtQdJgnjgQlJJIZFTpVoTCkiyTP).GetSpecialTemplateElementByElementIdentifierId(id));
	}

	wyBGNVjftIezdumZCvkmiqVKqZjAA IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.KwxFoKDkNchmwPnsEbroLDWLfpieA(this, controller, elementIdentifierId, PicZzKePsrnNIYsprvoleBKvWoTE);
	}

	wyBGNVjftIezdumZCvkmiqVKqZjAA IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.hikcUQMOEgQOUVjCSSPkmxypOCqJ(this, controller, elementIdentifierId, PicZzKePsrnNIYsprvoleBKvWoTE);
	}
}

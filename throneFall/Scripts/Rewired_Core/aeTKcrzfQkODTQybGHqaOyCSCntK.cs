using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal sealed class aeTKcrzfQkODTQybGHqaOyCSCntK : IHardwareControllerTemplateMap, IHardwareControllerTemplateMap_Internal
{
	private struct vrzoMrXGJYwLFOXsZfXzKMbwykRF : IControllerTemplateMapSpecialElement_Internal
	{
		private IControllerTemplateMapSpecialElement_Internal uVdcbUgfYcNaXbGngkCzmenbyJDEB;

		public vrzoMrXGJYwLFOXsZfXzKMbwykRF(IControllerTemplateMapSpecialElement_Internal P_0)
		{
			uVdcbUgfYcNaXbGngkCzmenbyJDEB = P_0;
		}

		public T GetMapping<T>() where T : ControllerTemplateSpecialElementMapping
		{
			return uVdcbUgfYcNaXbGngkCzmenbyJDEB.GetMapping<T>();
		}

		T IControllerTemplateMapSpecialElement_Internal.GetMapping<T>()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetMapping
			return this.GetMapping<T>();
		}
	}

	private HardwareJoystickTemplateMap GwTlApsAisBcYAcWzXJyKghYkqEHA;

	private string shUuIJYwkuzalOvTPZTJnEzNriod;

	private string fRtBuomqybMpJmqolagfGfcLopoZA;

	private string yieqCPcdOFdYNWMEjhBwZmuNEuXt;

	private readonly Guid AuliOEJkmYDsbCvVLCnjuobhutuIA;

	private readonly List<HardwareJoystickTemplateMap.Entry> EkOoGnYsXcBnJLdCWcFmUWZrQXxf;

	private readonly ControllerTemplateElementIdentifier[] dqoRhULvVaDmxDPmCSxLytohPJPh;

	private readonly DeviceLocalizationInfo dlMmVitrWeczNHtDDglqOFnKzTku;

	[NonSerialized]
	private Func<Guid, HardwareJoystickTemplateMap.Entry> BPCBQHBTfjazqGjtjalPSElLMDEBB;

	public string name => shUuIJYwkuzalOvTPZTJnEzNriod;

	public string YEuOjukClCSuQmxSxaoCMfmRmnBq => fRtBuomqybMpJmqolagfGfcLopoZA;

	public string mdocjfMYMOWRpcqdQErteoWJawlfA => yieqCPcdOFdYNWMEjhBwZmuNEuXt;

	public Guid oGvOrMOLNvPxwQRPGVryuwYzGqbt => AuliOEJkmYDsbCvVLCnjuobhutuIA;

	string IHardwareControllerTemplateMap_Internal.name => shUuIJYwkuzalOvTPZTJnEzNriod;

	Guid IHardwareControllerTemplateMap_Internal.typeGuid => AuliOEJkmYDsbCvVLCnjuobhutuIA;

	string IHardwareControllerTemplateMap_Internal.typeKey => yieqCPcdOFdYNWMEjhBwZmuNEuXt;

	private Func<Guid, HardwareJoystickTemplateMap.Entry> agEcMgahWlydXbCjRhPGmOgRFQGu => fxlLrbPzadfUXElrmUWWurDylew;

	public aeTKcrzfQkODTQybGHqaOyCSCntK(HardwareJoystickTemplateMap P_0, List<HardwareJoystickTemplateMap.Entry> P_1, ControllerTemplateElementIdentifier[] P_2)
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
		GwTlApsAisBcYAcWzXJyKghYkqEHA = P_0;
		shUuIJYwkuzalOvTPZTJnEzNriod = P_0.name;
		fRtBuomqybMpJmqolagfGfcLopoZA = P_0.ClassName;
		AuliOEJkmYDsbCvVLCnjuobhutuIA = P_0.Guid;
		yieqCPcdOFdYNWMEjhBwZmuNEuXt = P_0.Key;
		EkOoGnYsXcBnJLdCWcFmUWZrQXxf = P_1;
		dqoRhULvVaDmxDPmCSxLytohPJPh = P_2;
		dlMmVitrWeczNHtDDglqOFnKzTku = new DeviceLocalizationInfo(ControllerType.Joystick, true, oGvOrMOLNvPxwQRPGVryuwYzGqbt, new AList<string> { yieqCPcdOFdYNWMEjhBwZmuNEuXt }, null);
		dlMmVitrWeczNHtDDglqOFnKzTku.FinishRuntimeSetup();
		bool flag = dlMmVitrWeczNHtDDglqOFnKzTku.controllerType != ControllerType.Keyboard && dlMmVitrWeczNHtDDglqOFnKzTku.controllerType != ControllerType.Mouse;
		for (int i = 0; i < dqoRhULvVaDmxDPmCSxLytohPJPh.Length; i++)
		{
			if (dqoRhULvVaDmxDPmCSxLytohPJPh[i] == null)
			{
				continue;
			}
			if (flag)
			{
				if (ControllerTemplateElementIdentifier.cnLIjlXYzgcoFOQacCbLJhRmBWmj.DmlAxAVVYyvyKAtVoACihaUZtUEh(dlMmVitrWeczNHtDDglqOFnKzTku, dqoRhULvVaDmxDPmCSxLytohPJPh[i], out var controllerTemplateElementIdentifier))
				{
					dqoRhULvVaDmxDPmCSxLytohPJPh[i] = controllerTemplateElementIdentifier;
					continue;
				}
				ControllerTemplateElementIdentifier.cnLIjlXYzgcoFOQacCbLJhRmBWmj.YPRJvEhsTFFnfHyshaYqZEdHOCDN(dlMmVitrWeczNHtDDglqOFnKzTku, dqoRhULvVaDmxDPmCSxLytohPJPh[i]);
			}
			dqoRhULvVaDmxDPmCSxLytohPJPh[i].FinishRuntimeSetup(dlMmVitrWeczNHtDDglqOFnKzTku);
		}
	}

	public ControllerTemplateElementIdentifier IZaXoSJWdKSjxPetLPqSfEfbqLCk(Guid P_0, int P_1)
	{
		if (P_0 == Guid.Empty || P_1 < 0)
		{
			return null;
		}
		if (EkOoGnYsXcBnJLdCWcFmUWZrQXxf == null)
		{
			return null;
		}
		int num = -1;
		int count = EkOoGnYsXcBnJLdCWcFmUWZrQXxf.Count;
		for (int i = 0; i < count; i++)
		{
			if (EkOoGnYsXcBnJLdCWcFmUWZrQXxf[i] != null && EkOoGnYsXcBnJLdCWcFmUWZrQXxf[i].JoystickGuid == P_0)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return null;
		}
		HardwareJoystickTemplateMap.Entry entry = EkOoGnYsXcBnJLdCWcFmUWZrQXxf[num];
		if (entry == null)
		{
			return null;
		}
		int templateElementId = entry.GetTemplateElementId(P_1);
		if (templateElementId < 0)
		{
			return null;
		}
		return HardwareJoystickTemplateMap.KSzeBtEGktJoyUndKtrivQCboWcBA(dqoRhULvVaDmxDPmCSxLytohPJPh, templateElementId);
	}

	public int semPIdnpgTrlyqbqibZiKvatbSUCA(Guid P_0, int P_1, List<HardwareControllerTemplateMap.FEhsPJDpJWJwcwxoKFKKvWvFgmlN> P_2)
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("results");
		}
		if (P_0 == Guid.Empty || P_1 < 0)
		{
			return 0;
		}
		if (EkOoGnYsXcBnJLdCWcFmUWZrQXxf == null)
		{
			return 0;
		}
		int num = -1;
		int count = EkOoGnYsXcBnJLdCWcFmUWZrQXxf.Count;
		for (int i = 0; i < count; i++)
		{
			if (EkOoGnYsXcBnJLdCWcFmUWZrQXxf[i] != null && EkOoGnYsXcBnJLdCWcFmUWZrQXxf[i].JoystickGuid == P_0)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return 0;
		}
		HardwareJoystickTemplateMap.Entry entry = EkOoGnYsXcBnJLdCWcFmUWZrQXxf[num];
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
			ControllerTemplateElementIdentifier controllerTemplateElementIdentifier = iVznauAqPIPEDKvROjAavAJpbXZFA(dqoRhULvVaDmxDPmCSxLytohPJPh, elementIdentifierMap.templateId);
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
			P_2.Add(new HardwareControllerTemplateMap.FEhsPJDpJWJwcwxoKFKKvWvFgmlN
			{
				kcsniGvamvMOmNoylVbWRgSHdCaN = elementIdentifierMap.templateId,
				WaXPJbxEeJBrRGvXOdXTCNYAsEttb = elementIdentifierMap.joystickId,
				VsjroAKWXrlumPXaTpfIHWyenUqi = elementIdentifierMap.joystickId2,
				LhjBhXLnmShqBGOiOXYKuTPlrWnO = (controllerTemplateElementIdentifier.Rewired_002EInterfaces_002EIControllerTemplateElementIdentifier_002EelementType == ControllerTemplateElementType.Axis && elementIdentifierMap.splitAxis)
			});
		}
		return P_2.Count - count2;
	}

	private HardwareJoystickTemplateMap.Entry fxlLrbPzadfUXElrmUWWurDylew(Guid P_0)
	{
		if (EkOoGnYsXcBnJLdCWcFmUWZrQXxf == null)
		{
			return null;
		}
		for (int i = 0; i < EkOoGnYsXcBnJLdCWcFmUWZrQXxf.Count; i++)
		{
			if (EkOoGnYsXcBnJLdCWcFmUWZrQXxf[i].JoystickGuid == P_0)
			{
				return EkOoGnYsXcBnJLdCWcFmUWZrQXxf[i];
			}
		}
		return null;
	}

	private static ControllerTemplateElementIdentifier iVznauAqPIPEDKvROjAavAJpbXZFA(ControllerTemplateElementIdentifier[] P_0, int P_1)
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
		if (dqoRhULvVaDmxDPmCSxLytohPJPh == null)
		{
			return 0;
		}
		return dqoRhULvVaDmxDPmCSxLytohPJPh.Length;
	}

	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifier(int index)
	{
		if (dqoRhULvVaDmxDPmCSxLytohPJPh == null)
		{
			return null;
		}
		return dqoRhULvVaDmxDPmCSxLytohPJPh[index];
	}

	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.KSzeBtEGktJoyUndKtrivQCboWcBA(dqoRhULvVaDmxDPmCSxLytohPJPh, elementIdentifierId);
	}

	IControllerTemplateMapSpecialElement_Internal IHardwareControllerTemplateMap_Internal.GetSpecialTemplateElementByElementIdentifierId(int id)
	{
		return new vrzoMrXGJYwLFOXsZfXzKMbwykRF(((IHardwareControllerTemplateMap_Internal)GwTlApsAisBcYAcWzXJyKghYkqEHA).GetSpecialTemplateElementByElementIdentifierId(id));
	}

	JuxAmvlvwOWoqJaGcoORwookXVmr IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.lWPkPuXFUqBrlfitoLNDFTxdIjjYA(this, controller, elementIdentifierId, agEcMgahWlydXbCjRhPGmOgRFQGu);
	}

	JuxAmvlvwOWoqJaGcoORwookXVmr IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.KHQLMiCNDaBvZgULseiRylHVAFnk(this, controller, elementIdentifierId, agEcMgahWlydXbCjRhPGmOgRFQGu);
	}
}

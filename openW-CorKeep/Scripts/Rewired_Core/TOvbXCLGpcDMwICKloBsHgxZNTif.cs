using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal sealed class TOvbXCLGpcDMwICKloBsHgxZNTif : IHardwareControllerTemplateMap, IHardwareControllerTemplateMap_Internal
{
	private struct McPPBOnjyYdGoCXXuYgfTWMvpDOk : IControllerTemplateMapSpecialElement_Internal
	{
		private IControllerTemplateMapSpecialElement_Internal TxXDEzZHryBlwCYCNOrbdgCpuAGT;

		public McPPBOnjyYdGoCXXuYgfTWMvpDOk(IControllerTemplateMapSpecialElement_Internal P_0)
		{
			TxXDEzZHryBlwCYCNOrbdgCpuAGT = P_0;
		}

		public T GetMapping<T>() where T : ControllerTemplateSpecialElementMapping
		{
			return TxXDEzZHryBlwCYCNOrbdgCpuAGT.GetMapping<T>();
		}

		T IControllerTemplateMapSpecialElement_Internal.GetMapping<T>()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetMapping
			return this.GetMapping<T>();
		}
	}

	private HardwareJoystickTemplateMap zCfxdQKOJkhvbyPzAhamAdMZOxXpA;

	private string XfsRQqqMPssZGAqWaumPuPnUiflk;

	private string QBPHeNEPqvmxiaNOUNDhokHOapdI;

	private string ZlCBLeGinXTwkCOpWqoaUfPKAdKq;

	private readonly Guid fgHHpxBhNCJnKDfuFsQzdbMokyjHc;

	private readonly List<HardwareJoystickTemplateMap.Entry> bcyVuSckNsEgeXfvvBAqNMaiJMaK;

	private readonly ControllerTemplateElementIdentifier[] SbYgjNdwtwIOXPZWxnXvhXmmWSoB;

	private readonly DeviceLocalizationInfo GjeVmHJTlkssgNGkyiSukTELMUtab;

	[NonSerialized]
	private Func<Guid, HardwareJoystickTemplateMap.Entry> gdogrizEWjBsHApIRECDYFATuQPlA;

	public string name => XfsRQqqMPssZGAqWaumPuPnUiflk;

	public string psWSGDUmMYArjDorAlBQoJJUZoExA => QBPHeNEPqvmxiaNOUNDhokHOapdI;

	public string DOYODWsdwIGdGaMcbUzznnCQtqeE => ZlCBLeGinXTwkCOpWqoaUfPKAdKq;

	public Guid HRXSQfuoydCyPEFyrRKihBvmprmo => fgHHpxBhNCJnKDfuFsQzdbMokyjHc;

	string IHardwareControllerTemplateMap_Internal.name => XfsRQqqMPssZGAqWaumPuPnUiflk;

	Guid IHardwareControllerTemplateMap_Internal.typeGuid => fgHHpxBhNCJnKDfuFsQzdbMokyjHc;

	string IHardwareControllerTemplateMap_Internal.typeKey => ZlCBLeGinXTwkCOpWqoaUfPKAdKq;

	private Func<Guid, HardwareJoystickTemplateMap.Entry> BncPAJUettxTmnCImIyElnPKGZJP => QETatIrXEagVbMDYEzEORFQCoslI;

	public TOvbXCLGpcDMwICKloBsHgxZNTif(HardwareJoystickTemplateMap P_0, List<HardwareJoystickTemplateMap.Entry> P_1, ControllerTemplateElementIdentifier[] P_2)
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
		zCfxdQKOJkhvbyPzAhamAdMZOxXpA = P_0;
		XfsRQqqMPssZGAqWaumPuPnUiflk = P_0.name;
		QBPHeNEPqvmxiaNOUNDhokHOapdI = P_0.ClassName;
		fgHHpxBhNCJnKDfuFsQzdbMokyjHc = P_0.Guid;
		ZlCBLeGinXTwkCOpWqoaUfPKAdKq = P_0.Key;
		bcyVuSckNsEgeXfvvBAqNMaiJMaK = P_1;
		SbYgjNdwtwIOXPZWxnXvhXmmWSoB = P_2;
		GjeVmHJTlkssgNGkyiSukTELMUtab = new DeviceLocalizationInfo(ControllerType.Joystick, true, HRXSQfuoydCyPEFyrRKihBvmprmo, new AList<string> { ZlCBLeGinXTwkCOpWqoaUfPKAdKq }, null);
		GjeVmHJTlkssgNGkyiSukTELMUtab.FinishRuntimeSetup();
		bool flag = GjeVmHJTlkssgNGkyiSukTELMUtab.controllerType != ControllerType.Keyboard && GjeVmHJTlkssgNGkyiSukTELMUtab.controllerType != ControllerType.Mouse;
		for (int i = 0; i < SbYgjNdwtwIOXPZWxnXvhXmmWSoB.Length; i++)
		{
			if (SbYgjNdwtwIOXPZWxnXvhXmmWSoB[i] == null)
			{
				continue;
			}
			if (flag)
			{
				if (ControllerTemplateElementIdentifier.NBdBhAlmfejjaHOpFWtPQKazPGnfA.iHDzshrKpuwRpELINjgmmUfSimNl(GjeVmHJTlkssgNGkyiSukTELMUtab, SbYgjNdwtwIOXPZWxnXvhXmmWSoB[i], out var controllerTemplateElementIdentifier))
				{
					SbYgjNdwtwIOXPZWxnXvhXmmWSoB[i] = controllerTemplateElementIdentifier;
					continue;
				}
				ControllerTemplateElementIdentifier.NBdBhAlmfejjaHOpFWtPQKazPGnfA.jEvfKpEVoXJuScPDJCbeOYUiQTOQb(GjeVmHJTlkssgNGkyiSukTELMUtab, SbYgjNdwtwIOXPZWxnXvhXmmWSoB[i]);
			}
			SbYgjNdwtwIOXPZWxnXvhXmmWSoB[i].FinishRuntimeSetup(GjeVmHJTlkssgNGkyiSukTELMUtab);
		}
	}

	public ControllerTemplateElementIdentifier rMOiCrbVhOFYCRGEoqhGaNUixxVF(Guid P_0, int P_1)
	{
		if (P_0 == Guid.Empty || P_1 < 0)
		{
			return null;
		}
		if (bcyVuSckNsEgeXfvvBAqNMaiJMaK == null)
		{
			return null;
		}
		int num = -1;
		int count = bcyVuSckNsEgeXfvvBAqNMaiJMaK.Count;
		for (int i = 0; i < count; i++)
		{
			if (bcyVuSckNsEgeXfvvBAqNMaiJMaK[i] != null && bcyVuSckNsEgeXfvvBAqNMaiJMaK[i].JoystickGuid == P_0)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return null;
		}
		HardwareJoystickTemplateMap.Entry entry = bcyVuSckNsEgeXfvvBAqNMaiJMaK[num];
		if (entry == null)
		{
			return null;
		}
		int templateElementId = entry.GetTemplateElementId(P_1);
		if (templateElementId < 0)
		{
			return null;
		}
		return HardwareJoystickTemplateMap.hGZDcSeoTdfbXhsAtGIoKHfqGNxSA(SbYgjNdwtwIOXPZWxnXvhXmmWSoB, templateElementId);
	}

	public int LpKSbSHMPLZgHoCXDluyNSRcIVJV(Guid P_0, int P_1, List<HardwareControllerTemplateMap.ovLXoyvOyAIvHyJVxtrGqFYCplsV> P_2)
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("results");
		}
		if (P_0 == Guid.Empty || P_1 < 0)
		{
			return 0;
		}
		if (bcyVuSckNsEgeXfvvBAqNMaiJMaK == null)
		{
			return 0;
		}
		int num = -1;
		int count = bcyVuSckNsEgeXfvvBAqNMaiJMaK.Count;
		for (int i = 0; i < count; i++)
		{
			if (bcyVuSckNsEgeXfvvBAqNMaiJMaK[i] != null && bcyVuSckNsEgeXfvvBAqNMaiJMaK[i].JoystickGuid == P_0)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return 0;
		}
		HardwareJoystickTemplateMap.Entry entry = bcyVuSckNsEgeXfvvBAqNMaiJMaK[num];
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
			ControllerTemplateElementIdentifier controllerTemplateElementIdentifier = FDNBRFiiaWCPkjAeHrxiaoqjwIGic(SbYgjNdwtwIOXPZWxnXvhXmmWSoB, elementIdentifierMap.templateId);
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
			P_2.Add(new HardwareControllerTemplateMap.ovLXoyvOyAIvHyJVxtrGqFYCplsV
			{
				FQOSDpPXXnNWZLBRQeHUYkfMPKzJ = elementIdentifierMap.templateId,
				bYpzkMPSFPGymboibgiFAaddbFyZ = elementIdentifierMap.joystickId,
				cFDyVzugujGkRDPPmMOAGANpygzsA = elementIdentifierMap.joystickId2,
				yKFMkklFGCzKqCZHbbGAdkukBlog = (controllerTemplateElementIdentifier.Rewired_002EInterfaces_002EIControllerTemplateElementIdentifier_002EelementType == ControllerTemplateElementType.Axis && elementIdentifierMap.splitAxis)
			});
		}
		return P_2.Count - count2;
	}

	private HardwareJoystickTemplateMap.Entry QETatIrXEagVbMDYEzEORFQCoslI(Guid P_0)
	{
		if (bcyVuSckNsEgeXfvvBAqNMaiJMaK == null)
		{
			return null;
		}
		for (int i = 0; i < bcyVuSckNsEgeXfvvBAqNMaiJMaK.Count; i++)
		{
			if (bcyVuSckNsEgeXfvvBAqNMaiJMaK[i].JoystickGuid == P_0)
			{
				return bcyVuSckNsEgeXfvvBAqNMaiJMaK[i];
			}
		}
		return null;
	}

	private static ControllerTemplateElementIdentifier FDNBRFiiaWCPkjAeHrxiaoqjwIGic(ControllerTemplateElementIdentifier[] P_0, int P_1)
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
		if (SbYgjNdwtwIOXPZWxnXvhXmmWSoB == null)
		{
			return 0;
		}
		return SbYgjNdwtwIOXPZWxnXvhXmmWSoB.Length;
	}

	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifier(int index)
	{
		if (SbYgjNdwtwIOXPZWxnXvhXmmWSoB == null)
		{
			return null;
		}
		return SbYgjNdwtwIOXPZWxnXvhXmmWSoB[index];
	}

	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.hGZDcSeoTdfbXhsAtGIoKHfqGNxSA(SbYgjNdwtwIOXPZWxnXvhXmmWSoB, elementIdentifierId);
	}

	IControllerTemplateMapSpecialElement_Internal IHardwareControllerTemplateMap_Internal.GetSpecialTemplateElementByElementIdentifierId(int id)
	{
		return new McPPBOnjyYdGoCXXuYgfTWMvpDOk(((IHardwareControllerTemplateMap_Internal)zCfxdQKOJkhvbyPzAhamAdMZOxXpA).GetSpecialTemplateElementByElementIdentifierId(id));
	}

	eyXePMBLHAVdDBzdXMjLzHNfDAjcA IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.CBdFoVbtjepsCCeOLnwHDWAoskcsA(this, controller, elementIdentifierId, BncPAJUettxTmnCImIyElnPKGZJP);
	}

	eyXePMBLHAVdDBzdXMjLzHNfDAjcA IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.hJcutZiwbkMumuoqRXePrjsEPfmi(this, controller, elementIdentifierId, BncPAJUettxTmnCImIyElnPKGZJP);
	}
}

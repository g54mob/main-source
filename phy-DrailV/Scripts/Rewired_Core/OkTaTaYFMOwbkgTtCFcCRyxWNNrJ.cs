using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal sealed class OkTaTaYFMOwbkgTtCFcCRyxWNNrJ : IHardwareControllerTemplateMap, IHardwareControllerTemplateMap_Internal
{
	private struct JXbSSmmLFcWtokRaZhKVRYGuzxTG : IControllerTemplateMapSpecialElement_Internal
	{
		private IControllerTemplateMapSpecialElement_Internal ONfshQzGPJePAfpjWQssROPaiYjk;

		public JXbSSmmLFcWtokRaZhKVRYGuzxTG(IControllerTemplateMapSpecialElement_Internal P_0)
		{
			ONfshQzGPJePAfpjWQssROPaiYjk = P_0;
		}

		public T GetMapping<T>() where T : ControllerTemplateSpecialElementMapping
		{
			return ONfshQzGPJePAfpjWQssROPaiYjk.GetMapping<T>();
		}
	}

	private HardwareJoystickTemplateMap NJqioHDaEPeQLhcgkQGbprgBCAsjA;

	private string XXuYUuZFvXwuYxiNryIOxzHdIWPU;

	private string lLHenXgRQlWYkPRSUzOJFrUXwAdm;

	private string iznbkRlQcoGkZtBlmfunFSNsZtUK;

	private readonly Guid eshGdUGobfKwGkIdgjPlsYxTeZuBA;

	private readonly List<HardwareJoystickTemplateMap.Entry> PmJeDnpQDGJjjDwWldGyhwglhuhs;

	private readonly ControllerTemplateElementIdentifier[] VDarsrjGebJJwIttJrEyFwqTKKGr;

	private readonly DeviceLocalizationInfo epyWrMiKarPbsrBGIHCyAJPFVlJb;

	[NonSerialized]
	private Func<Guid, HardwareJoystickTemplateMap.Entry> KGMKRQdSrgsbboSNURGQaIeolHsA;

	public string name => XXuYUuZFvXwuYxiNryIOxzHdIWPU;

	public string ssCfdClydnxpavvQUhUhUoUenpUA => lLHenXgRQlWYkPRSUzOJFrUXwAdm;

	public string EqHcpXWaGauOvKqzuxjiUENyiiKN => iznbkRlQcoGkZtBlmfunFSNsZtUK;

	public Guid eaLeFvhBFvatmpsmBiVAbiuICkILc => eshGdUGobfKwGkIdgjPlsYxTeZuBA;

	string IHardwareControllerTemplateMap_Internal.name => XXuYUuZFvXwuYxiNryIOxzHdIWPU;

	Guid IHardwareControllerTemplateMap_Internal.typeGuid => eshGdUGobfKwGkIdgjPlsYxTeZuBA;

	string IHardwareControllerTemplateMap_Internal.typeKey => iznbkRlQcoGkZtBlmfunFSNsZtUK;

	private Func<Guid, HardwareJoystickTemplateMap.Entry> eCFtfNMnVMcKSDoGRlrovRmmxMEvA => jcQIPleqWWsZNlvEYGkHBahJWVvN;

	public OkTaTaYFMOwbkgTtCFcCRyxWNNrJ(HardwareJoystickTemplateMap P_0, List<HardwareJoystickTemplateMap.Entry> P_1, ControllerTemplateElementIdentifier[] P_2)
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
		NJqioHDaEPeQLhcgkQGbprgBCAsjA = P_0;
		XXuYUuZFvXwuYxiNryIOxzHdIWPU = P_0.name;
		lLHenXgRQlWYkPRSUzOJFrUXwAdm = P_0.ClassName;
		eshGdUGobfKwGkIdgjPlsYxTeZuBA = P_0.Guid;
		iznbkRlQcoGkZtBlmfunFSNsZtUK = P_0.Key;
		PmJeDnpQDGJjjDwWldGyhwglhuhs = P_1;
		VDarsrjGebJJwIttJrEyFwqTKKGr = P_2;
		epyWrMiKarPbsrBGIHCyAJPFVlJb = new DeviceLocalizationInfo(ControllerType.Joystick, true, eaLeFvhBFvatmpsmBiVAbiuICkILc, new AList<string> { iznbkRlQcoGkZtBlmfunFSNsZtUK }, null);
		epyWrMiKarPbsrBGIHCyAJPFVlJb.FinishRuntimeSetup();
		bool flag = epyWrMiKarPbsrBGIHCyAJPFVlJb.controllerType != ControllerType.Keyboard && epyWrMiKarPbsrBGIHCyAJPFVlJb.controllerType != ControllerType.Mouse;
		for (int i = 0; i < VDarsrjGebJJwIttJrEyFwqTKKGr.Length; i++)
		{
			if (VDarsrjGebJJwIttJrEyFwqTKKGr[i] == null)
			{
				continue;
			}
			if (flag)
			{
				if (ControllerTemplateElementIdentifier.GUPiwiwAUCDUasvYcoQfKeguqMgn.XoWrPhuuoYdElFYmsPRgFLepADbg(epyWrMiKarPbsrBGIHCyAJPFVlJb, VDarsrjGebJJwIttJrEyFwqTKKGr[i], out var controllerTemplateElementIdentifier))
				{
					VDarsrjGebJJwIttJrEyFwqTKKGr[i] = controllerTemplateElementIdentifier;
					continue;
				}
				ControllerTemplateElementIdentifier.GUPiwiwAUCDUasvYcoQfKeguqMgn.fyeqCafQbFyflbNbajUvornPxfgy(epyWrMiKarPbsrBGIHCyAJPFVlJb, VDarsrjGebJJwIttJrEyFwqTKKGr[i]);
			}
			VDarsrjGebJJwIttJrEyFwqTKKGr[i].FinishRuntimeSetup(epyWrMiKarPbsrBGIHCyAJPFVlJb);
		}
	}

	public ControllerTemplateElementIdentifier vlfpBpSWJgpDQsYjreoeHEnEzgkt(Guid P_0, int P_1)
	{
		if (P_0 == Guid.Empty || P_1 < 0)
		{
			return null;
		}
		if (PmJeDnpQDGJjjDwWldGyhwglhuhs == null)
		{
			return null;
		}
		int num = -1;
		int count = PmJeDnpQDGJjjDwWldGyhwglhuhs.Count;
		for (int i = 0; i < count; i++)
		{
			if (PmJeDnpQDGJjjDwWldGyhwglhuhs[i] != null && PmJeDnpQDGJjjDwWldGyhwglhuhs[i].JoystickGuid == P_0)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return null;
		}
		HardwareJoystickTemplateMap.Entry entry = PmJeDnpQDGJjjDwWldGyhwglhuhs[num];
		if (entry == null)
		{
			return null;
		}
		int templateElementId = entry.GetTemplateElementId(P_1);
		if (templateElementId < 0)
		{
			return null;
		}
		return HardwareJoystickTemplateMap.QFJfdAHwNyUBCHQpkstuLyHSqLCHA(VDarsrjGebJJwIttJrEyFwqTKKGr, templateElementId);
	}

	public int ATeSvgZPGYlsCJCvleyQBmemSaXZA(Guid P_0, int P_1, List<HardwareControllerTemplateMap.byvytSemFeFKFEMsWeUwDcEJnxtsA> P_2)
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("results");
		}
		if (P_0 == Guid.Empty || P_1 < 0)
		{
			return 0;
		}
		if (PmJeDnpQDGJjjDwWldGyhwglhuhs == null)
		{
			return 0;
		}
		int num = -1;
		int count = PmJeDnpQDGJjjDwWldGyhwglhuhs.Count;
		for (int i = 0; i < count; i++)
		{
			if (PmJeDnpQDGJjjDwWldGyhwglhuhs[i] != null && PmJeDnpQDGJjjDwWldGyhwglhuhs[i].JoystickGuid == P_0)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return 0;
		}
		HardwareJoystickTemplateMap.Entry entry = PmJeDnpQDGJjjDwWldGyhwglhuhs[num];
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
			ControllerTemplateElementIdentifier controllerTemplateElementIdentifier = mNtZzECZGtOZUsgkfaNGIFvNDggo(VDarsrjGebJJwIttJrEyFwqTKKGr, elementIdentifierMap.templateId);
			if (controllerTemplateElementIdentifier == null)
			{
				continue;
			}
			if (controllerTemplateElementIdentifier.elementType == ControllerTemplateElementType.Axis)
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
			P_2.Add(new HardwareControllerTemplateMap.byvytSemFeFKFEMsWeUwDcEJnxtsA
			{
				CqTmmupZoILJJWmnuPqhCQNfpfRt = elementIdentifierMap.templateId,
				aRDDcbvMGUVmqRZTrMtDGkFbwVmD = elementIdentifierMap.joystickId,
				wFslXZcLONbhQOPqNQSMuPAUPBzD = elementIdentifierMap.joystickId2,
				alaofQOBBmGCkqnSmFiJlcwVBlkbA = (controllerTemplateElementIdentifier.elementType == ControllerTemplateElementType.Axis && elementIdentifierMap.splitAxis)
			});
		}
		return P_2.Count - count2;
	}

	private HardwareJoystickTemplateMap.Entry jcQIPleqWWsZNlvEYGkHBahJWVvN(Guid P_0)
	{
		if (PmJeDnpQDGJjjDwWldGyhwglhuhs == null)
		{
			return null;
		}
		for (int i = 0; i < PmJeDnpQDGJjjDwWldGyhwglhuhs.Count; i++)
		{
			if (PmJeDnpQDGJjjDwWldGyhwglhuhs[i].JoystickGuid == P_0)
			{
				return PmJeDnpQDGJjjDwWldGyhwglhuhs[i];
			}
		}
		return null;
	}

	private static ControllerTemplateElementIdentifier mNtZzECZGtOZUsgkfaNGIFvNDggo(ControllerTemplateElementIdentifier[] P_0, int P_1)
	{
		if (P_0 == null)
		{
			return null;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i] != null && P_0[i].id == P_1)
			{
				return P_0[i];
			}
		}
		return null;
	}

	int IHardwareControllerTemplateMap_Internal.GetElementIdentifierCount()
	{
		if (VDarsrjGebJJwIttJrEyFwqTKKGr == null)
		{
			return 0;
		}
		return VDarsrjGebJJwIttJrEyFwqTKKGr.Length;
	}

	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifier(int index)
	{
		if (VDarsrjGebJJwIttJrEyFwqTKKGr == null)
		{
			return null;
		}
		return VDarsrjGebJJwIttJrEyFwqTKKGr[index];
	}

	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.QFJfdAHwNyUBCHQpkstuLyHSqLCHA(VDarsrjGebJJwIttJrEyFwqTKKGr, elementIdentifierId);
	}

	IControllerTemplateMapSpecialElement_Internal IHardwareControllerTemplateMap_Internal.GetSpecialTemplateElementByElementIdentifierId(int id)
	{
		return new JXbSSmmLFcWtokRaZhKVRYGuzxTG(((IHardwareControllerTemplateMap_Internal)NJqioHDaEPeQLhcgkQGbprgBCAsjA).GetSpecialTemplateElementByElementIdentifierId(id));
	}

	fMlgSaItucfCTlOMuaOrAzViaQaCA IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.YKaEqGcaZJHnGQNjalomhNUXInAc(this, controller, elementIdentifierId, eCFtfNMnVMcKSDoGRlrovRmmxMEvA);
	}

	fMlgSaItucfCTlOMuaOrAzViaQaCA IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.RakZrwoFBOPwyzjkaeEXghlIxchT(this, controller, elementIdentifierId, eCFtfNMnVMcKSDoGRlrovRmmxMEvA);
	}
}

using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal sealed class WRScrEekSojpdBXyEFARqvkVFcPPb : IHardwareControllerTemplateMap, IHardwareControllerTemplateMap_Internal
{
	private struct RfujRChEHQzHpiBxIKcIBxRHvKdlc : IControllerTemplateMapSpecialElement_Internal
	{
		private IControllerTemplateMapSpecialElement_Internal GieQqliAseLnfJizbNWUPTYbfjpc;

		public RfujRChEHQzHpiBxIKcIBxRHvKdlc(IControllerTemplateMapSpecialElement_Internal P_0)
		{
			GieQqliAseLnfJizbNWUPTYbfjpc = P_0;
		}

		public T GetMapping<T>() where T : ControllerTemplateSpecialElementMapping
		{
			return GieQqliAseLnfJizbNWUPTYbfjpc.GetMapping<T>();
		}

		T IControllerTemplateMapSpecialElement_Internal.GetMapping<T>()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetMapping
			return this.GetMapping<T>();
		}
	}

	private HardwareJoystickTemplateMap ckMlmYdWkiTiszvRuExNXVXTYrci;

	private string SwBbLqHXwwfUBoJwOlUwDCsAYPQIb;

	private string XcuuZDjdihEQhtwnyxsQSgGQfBYt;

	private string GZnGPmzHCHhxzERBatYNJqEKXUfDA;

	private readonly Guid oBmvXrWSuQXNTwcKMgqQXXTeBiSj;

	private readonly List<HardwareJoystickTemplateMap.Entry> qcThJILJLgDopHWBPQtBIllgdkJGb;

	private readonly ControllerTemplateElementIdentifier[] XitMgtAZPkmcNUApZvPcJmUcfjbM;

	private readonly DeviceLocalizationInfo JSJegTqZAyKnxQxKSaGBvjRHEvMV;

	[NonSerialized]
	private Func<Guid, HardwareJoystickTemplateMap.Entry> fBFrpsWzPjYQGsshhggavJzJfwke;

	public string name => SwBbLqHXwwfUBoJwOlUwDCsAYPQIb;

	public string yNrMSTbxzQDGulhBuxNfjpYIDjri => XcuuZDjdihEQhtwnyxsQSgGQfBYt;

	public string GVnPQIVUGGbqPrluTmsOJioYFQPeA => GZnGPmzHCHhxzERBatYNJqEKXUfDA;

	public Guid COqSQlZfVhAWYFhKLGoDBewypKFs => oBmvXrWSuQXNTwcKMgqQXXTeBiSj;

	string IHardwareControllerTemplateMap_Internal.name => SwBbLqHXwwfUBoJwOlUwDCsAYPQIb;

	Guid IHardwareControllerTemplateMap_Internal.typeGuid => oBmvXrWSuQXNTwcKMgqQXXTeBiSj;

	string IHardwareControllerTemplateMap_Internal.typeKey => GZnGPmzHCHhxzERBatYNJqEKXUfDA;

	private Func<Guid, HardwareJoystickTemplateMap.Entry> MaLGFNgjStyXxkIkCISpJWMUfuyHA => VHctsUUAhsbGkHHwoEXrYjZYlHSEb;

	public WRScrEekSojpdBXyEFARqvkVFcPPb(HardwareJoystickTemplateMap P_0, List<HardwareJoystickTemplateMap.Entry> P_1, ControllerTemplateElementIdentifier[] P_2)
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
		ckMlmYdWkiTiszvRuExNXVXTYrci = P_0;
		SwBbLqHXwwfUBoJwOlUwDCsAYPQIb = P_0.name;
		XcuuZDjdihEQhtwnyxsQSgGQfBYt = P_0.ClassName;
		oBmvXrWSuQXNTwcKMgqQXXTeBiSj = P_0.Guid;
		GZnGPmzHCHhxzERBatYNJqEKXUfDA = P_0.Key;
		qcThJILJLgDopHWBPQtBIllgdkJGb = P_1;
		XitMgtAZPkmcNUApZvPcJmUcfjbM = P_2;
		JSJegTqZAyKnxQxKSaGBvjRHEvMV = new DeviceLocalizationInfo(ControllerType.Joystick, true, COqSQlZfVhAWYFhKLGoDBewypKFs, new AList<string> { GZnGPmzHCHhxzERBatYNJqEKXUfDA }, null);
		JSJegTqZAyKnxQxKSaGBvjRHEvMV.FinishRuntimeSetup();
		bool flag = JSJegTqZAyKnxQxKSaGBvjRHEvMV.controllerType != ControllerType.Keyboard && JSJegTqZAyKnxQxKSaGBvjRHEvMV.controllerType != ControllerType.Mouse;
		for (int i = 0; i < XitMgtAZPkmcNUApZvPcJmUcfjbM.Length; i++)
		{
			if (XitMgtAZPkmcNUApZvPcJmUcfjbM[i] == null)
			{
				continue;
			}
			if (flag)
			{
				if (ControllerTemplateElementIdentifier.QAIAdMIUYcOJjVJFlWJmegzpnbOIA.vWgKztWlWwTAwDDozARTAQmOPPicb(JSJegTqZAyKnxQxKSaGBvjRHEvMV, XitMgtAZPkmcNUApZvPcJmUcfjbM[i], out var controllerTemplateElementIdentifier))
				{
					XitMgtAZPkmcNUApZvPcJmUcfjbM[i] = controllerTemplateElementIdentifier;
					continue;
				}
				ControllerTemplateElementIdentifier.QAIAdMIUYcOJjVJFlWJmegzpnbOIA.eXMOTdqLTRYjZAgbeDoNcnVMqGpK(JSJegTqZAyKnxQxKSaGBvjRHEvMV, XitMgtAZPkmcNUApZvPcJmUcfjbM[i]);
			}
			XitMgtAZPkmcNUApZvPcJmUcfjbM[i].FinishRuntimeSetup(JSJegTqZAyKnxQxKSaGBvjRHEvMV);
		}
	}

	public ControllerTemplateElementIdentifier iOfeqbJMUGEbLAYcEKWdoWXjwQwjb(Guid P_0, int P_1)
	{
		if (P_0 == Guid.Empty || P_1 < 0)
		{
			return null;
		}
		if (qcThJILJLgDopHWBPQtBIllgdkJGb == null)
		{
			return null;
		}
		int num = -1;
		int count = qcThJILJLgDopHWBPQtBIllgdkJGb.Count;
		for (int i = 0; i < count; i++)
		{
			if (qcThJILJLgDopHWBPQtBIllgdkJGb[i] != null && qcThJILJLgDopHWBPQtBIllgdkJGb[i].JoystickGuid == P_0)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return null;
		}
		HardwareJoystickTemplateMap.Entry entry = qcThJILJLgDopHWBPQtBIllgdkJGb[num];
		if (entry == null)
		{
			return null;
		}
		int templateElementId = entry.GetTemplateElementId(P_1);
		if (templateElementId < 0)
		{
			return null;
		}
		return HardwareJoystickTemplateMap.cDaseMZwurZaEyjiNmzZdtqkkkSL(XitMgtAZPkmcNUApZvPcJmUcfjbM, templateElementId);
	}

	public int GmrpXIezcZGwIxbrhYOTnHUqsfmK(Guid P_0, int P_1, List<HardwareControllerTemplateMap.bSeoxkAXPAPaGzvxBXEzIEDOfGVn> P_2)
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("results");
		}
		if (P_0 == Guid.Empty || P_1 < 0)
		{
			return 0;
		}
		if (qcThJILJLgDopHWBPQtBIllgdkJGb == null)
		{
			return 0;
		}
		int num = -1;
		int count = qcThJILJLgDopHWBPQtBIllgdkJGb.Count;
		for (int i = 0; i < count; i++)
		{
			if (qcThJILJLgDopHWBPQtBIllgdkJGb[i] != null && qcThJILJLgDopHWBPQtBIllgdkJGb[i].JoystickGuid == P_0)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return 0;
		}
		HardwareJoystickTemplateMap.Entry entry = qcThJILJLgDopHWBPQtBIllgdkJGb[num];
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
			ControllerTemplateElementIdentifier controllerTemplateElementIdentifier = OdqcTTXGBGHbpgNCVDDZtQxuonxcb(XitMgtAZPkmcNUApZvPcJmUcfjbM, elementIdentifierMap.templateId);
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
			P_2.Add(new HardwareControllerTemplateMap.bSeoxkAXPAPaGzvxBXEzIEDOfGVn
			{
				IXbDKpkworjxGkKfmAYbfacKYqUUb = elementIdentifierMap.templateId,
				ojQcqIwMmLIApwnAFTEyeaehbiPgA = elementIdentifierMap.joystickId,
				nbcDRvDAJjDCEKArIlwvEcAhvVWGB = elementIdentifierMap.joystickId2,
				xzgpMsWquQjTpZXtZbFzRPnkXcDp = (controllerTemplateElementIdentifier.Rewired_002EInterfaces_002EIControllerTemplateElementIdentifier_002EelementType == ControllerTemplateElementType.Axis && elementIdentifierMap.splitAxis)
			});
		}
		return P_2.Count - count2;
	}

	private HardwareJoystickTemplateMap.Entry VHctsUUAhsbGkHHwoEXrYjZYlHSEb(Guid P_0)
	{
		if (qcThJILJLgDopHWBPQtBIllgdkJGb == null)
		{
			return null;
		}
		for (int i = 0; i < qcThJILJLgDopHWBPQtBIllgdkJGb.Count; i++)
		{
			if (qcThJILJLgDopHWBPQtBIllgdkJGb[i].JoystickGuid == P_0)
			{
				return qcThJILJLgDopHWBPQtBIllgdkJGb[i];
			}
		}
		return null;
	}

	private static ControllerTemplateElementIdentifier OdqcTTXGBGHbpgNCVDDZtQxuonxcb(ControllerTemplateElementIdentifier[] P_0, int P_1)
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
		if (XitMgtAZPkmcNUApZvPcJmUcfjbM == null)
		{
			return 0;
		}
		return XitMgtAZPkmcNUApZvPcJmUcfjbM.Length;
	}

	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifier(int index)
	{
		if (XitMgtAZPkmcNUApZvPcJmUcfjbM == null)
		{
			return null;
		}
		return XitMgtAZPkmcNUApZvPcJmUcfjbM[index];
	}

	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.cDaseMZwurZaEyjiNmzZdtqkkkSL(XitMgtAZPkmcNUApZvPcJmUcfjbM, elementIdentifierId);
	}

	IControllerTemplateMapSpecialElement_Internal IHardwareControllerTemplateMap_Internal.GetSpecialTemplateElementByElementIdentifierId(int id)
	{
		return new RfujRChEHQzHpiBxIKcIBxRHvKdlc(((IHardwareControllerTemplateMap_Internal)ckMlmYdWkiTiszvRuExNXVXTYrci).GetSpecialTemplateElementByElementIdentifierId(id));
	}

	vgyLkSessULxWIPilRPgXWnpbfGE IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.TLKwvFGTYoCSNpPghOtkqmLkNEZK(this, controller, elementIdentifierId, MaLGFNgjStyXxkIkCISpJWMUfuyHA);
	}

	vgyLkSessULxWIPilRPgXWnpbfGE IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.eaVikJJgHonsjxiMfSroXOlObaZfA(this, controller, elementIdentifierId, MaLGFNgjStyXxkIkCISpJWMUfuyHA);
	}
}

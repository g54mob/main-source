using System;
using System.Collections.Generic;

[Serializable]
public class NetworkSaveData
{
	public List<ServerSaveData> servers;

	public List<SwitchSaveData> switches;

	public List<PatchPanelSaveData> patchPanels;

	public List<CableSaveData> cables;

	public List<CustomerBaseSaveData> customerBases;

	public List<SFPSaveData> sfpModules;
}

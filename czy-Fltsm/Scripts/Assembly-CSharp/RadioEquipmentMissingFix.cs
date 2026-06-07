using System;
using UnityEngine;

[Serializable]
public class RadioEquipmentMissingFix : IPersistenceFix
{
	[SerializeField]
	private AgentProfile _radioTechnician;

	[SerializeField]
	private BuildableProperties _radioTower;

	[SerializeField]
	private ItemProperties _radioEquipment;

	public void Apply()
	{
		if (!ActorDescriptor.TryGet<AgentDescriptor>(out var actorDescriptor, _radioTechnician) || Community.PlayerCommunity.ReturnHasBuildable(_radioTower) || Community.PlayerCommunity.Inventory.ReturnContainsItem(_radioEquipment, 1, includeReserved: true))
		{
			return;
		}
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			if (!(agent.Descriptor != actorDescriptor))
			{
				Community.PlayerCommunity.Storages[0].Inventory.AddItem(new Item(_radioEquipment), SubInventoryType.Storage);
				Debug.Log("Missing radio equipment item has magically appeared in one of the towns storages!");
				return;
			}
		}
		Debug.LogException(new Exception("Unable to fix missing radio equipment, the Radio Technician is not a member of the player community."));
	}
}

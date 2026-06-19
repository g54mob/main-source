using System.Collections.Generic;
using Services.Save.Missions;

namespace Services.Missions.Flow
{
	public class MissionsPresetsService
	{
		public MissionDefinition ReachPreset;

		public MissionDefinition DeliverPreset;

		public MissionDefinition DestroyPreset;

		public MissionDefinition AssemblePreset;

		private readonly MissionFactory _missionFactory;

		private readonly IMissionService _missionService;

		private readonly MissionSaveService _missionSaveService;

		public MissionsPresetsService(MissionFactory missionFactory, IMissionService missionService, MissionSaveService missionSaveService)
		{
			_missionFactory = missionFactory;
			_missionService = missionService;
			_missionSaveService = missionSaveService;
		}

		public void StartReachMission(string destinationName, float reward)
		{
			MissionDefinition missionDefinition = _missionFactory.Create(destinationName).WithTitle("Scout around").WithDescription("I want you to lurk around " + destinationName + ". I need to be sure it safe here...")
				.Reach(destinationName)
				.WithReward(reward)
				.Build();
			_missionService.StartMission(missionDefinition);
			_missionSaveService.AddActiveMission(_missionService.GetActive(missionDefinition.MissionId));
		}

		public void StartDeliveryMission(string deliveryName, Dictionary<string, int> products, float reward)
		{
			string text = "\n";
			foreach (KeyValuePair<string, int> product in products)
			{
				text += $"{product.Key}: count of {product.Value};";
				text += "\n";
			}
			MissionBuilder missionBuilder = _missionFactory.Create(deliveryName).WithTitle("Deliver goods").WithDescription("Some folks over there need some products: " + text)
				.WithReward(reward);
			foreach (KeyValuePair<string, int> product2 in products)
			{
				missionBuilder.Deliver(product2.Key, product2.Value);
			}
			MissionDefinition missionDefinition = missionBuilder.Build();
			_missionService.StartMission(missionDefinition);
			_missionSaveService.AddActiveMission(_missionService.GetActive(missionDefinition.MissionId));
		}
	}
}

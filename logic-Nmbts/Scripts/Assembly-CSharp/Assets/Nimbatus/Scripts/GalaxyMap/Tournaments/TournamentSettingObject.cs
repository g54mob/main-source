using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments
{
	[Serializable]
	public class TournamentSettingObject : SerializedScriptableObject
	{
		[OdinSerialize]
		protected internal TournamentSetting Settings = new TournamentSetting();

		public DroneSettingsObject DroneSettings;

		public DroneSettingsObject TrainingDroneSettings;
	}
}

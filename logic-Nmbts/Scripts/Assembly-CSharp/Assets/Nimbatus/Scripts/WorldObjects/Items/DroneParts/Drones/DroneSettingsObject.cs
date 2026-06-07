using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones
{
	[Serializable]
	public class DroneSettingsObject : SerializedScriptableObject
	{
		[OdinSerialize]
		protected internal DroneSettings Settings = new DroneSettings();
	}
}

using Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones
{
	public class DefaultDrone : SerializedScriptableObject
	{
		[HideInInspector]
		public byte[] DroneBytes;

		public EDefaultDroneType DroneType;

		public ETrainingDifficulty Difficulty;
	}
}

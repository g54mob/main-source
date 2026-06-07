using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Assets.Nimbatus.Scripts.Tutorial
{
	[Serializable]
	public class Subtutorial
	{
		public bool CustomDrone = true;

		[ShowIf("CustomDrone", true)]
		public DefaultDrone Drone;

		public bool ShowRadius;

		[ShowIf("ShowRadius", true)]
		public float DroneRadius;

		public bool AllowTags;

		public List<DronePart> AllowedDroneParts;

		public List<WeaponPreset> AllowedWeapons;

		[OdinSerialize]
		public List<DronePrecondition> Preconditions = new List<DronePrecondition>();

		public EAirResistance AirResistance;

		public EGravity Gravity;

		public string TutorialScene;

		public List<TutorialSlide> TutorialSlides;
	}
}

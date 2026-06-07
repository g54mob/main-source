using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones
{
	[Serializable]
	public class DroneSettings
	{
		public bool TwoStepDroneSelection;

		public bool HasCustomScene;

		[ShowIf("HasCustomScene", true)]
		public string CustomSceneName;

		[OdinSerialize]
		protected internal List<DronePrecondition> DronePreconditions = new List<DronePrecondition>();
	}
}

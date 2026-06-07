using System;
using System.Collections.Generic;
using System.Linq;
using NWH.VehiclePhysics2.GroundDetection;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Car
{
	[CreateAssetMenu(menuName = "SimplePlanes 2/Tire Configuration", fileName = "Tire Configuration")]
	public class TireProfile : ScriptableObject
	{
		[Serializable]
		public class TireSurfaceProfile
		{
			public float grip = 1f;

			public float stiffness = 1f;

			public SurfacePreset wheelSurfacePreset;
		}

		public List<TireSurfaceProfile> offroadProfiles = new List<TireSurfaceProfile>();

		public TireSurfaceProfile roadProfile;

		private Dictionary<SurfacePreset, TireSurfaceProfile> _configurations = new Dictionary<SurfacePreset, TireSurfaceProfile>();

		public TireSurfaceProfile GetTireSurfaceProfile(SurfacePreset surfacePreset)
		{
			TireSurfaceProfile value = null;
			if (surfacePreset == null)
			{
				value = roadProfile;
			}
			else if (!_configurations.TryGetValue(surfacePreset, out value))
			{
				value = offroadProfiles.Where((TireSurfaceProfile x) => x.wheelSurfacePreset == surfacePreset).FirstOrDefault();
				if (value == null)
				{
					Debug.Log("TireConfigurationPreset '" + base.name + "' does not have a surface configuration for NWH surface preset '" + surfacePreset.name + ".' Creating default entry.", this);
					value = new TireSurfaceProfile();
				}
				_configurations[surfacePreset] = value;
			}
			return value;
		}
	}
}

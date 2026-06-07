using System;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class GiveResources : NimbatusAction
	{
		[ValidateInput("IsDefined", null, InfoMessageType.Error)]
		public ETerrainMaterial Material;

		public float Amount;

		public override void Execute()
		{
			SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.AddResources(Material, Amount);
		}

		public bool IsDefined(ETerrainMaterial mat)
		{
			return Enum.IsDefined(typeof(ETerrainMaterial), mat);
		}
	}
}

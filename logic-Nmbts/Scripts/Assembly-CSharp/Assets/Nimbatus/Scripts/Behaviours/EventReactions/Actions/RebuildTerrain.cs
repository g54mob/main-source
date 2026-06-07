using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.Common;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class RebuildTerrain : CustomTransformAction
	{
		public float Radius;

		public float Strength;

		public override void Execute()
		{
			TerrainModificationHelper.LerpRebuildTerrainSphere(RuntimeGlobals.WorldController.ForeGroundTerrain, GetTransform().position, Radius, Strength);
		}
	}
}

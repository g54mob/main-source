using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Conditions
{
	public class IsUncovered : NimbatusCondition
	{
		public int Radius;

		public int TolerancePercent;

		public override bool IsTrue()
		{
			int num = Radius * Radius;
			int num2 = Mathf.Max(1, num / 100 * TolerancePercent);
			int num3 = 0;
			for (int i = -Radius; i <= Radius; i++)
			{
				for (int j = -Radius; j <= Radius; j++)
				{
					Vector3 pos = OwnWorldObject.transform.position + new Vector3(i, j, 0f);
					NimbatusTerrainData? data = RuntimeGlobals.WorldController.ForeGroundTerrain.GetData(pos);
					if (data.HasValue && data.Value.Volume > 0.5f)
					{
						num3++;
						if (num3 >= num2)
						{
							return false;
						}
					}
				}
			}
			SerializableMonobehaviour<MissionManager, MissionData>.Instance.ObjectUncovered(OwnWorldObject.UniqueId);
			return true;
		}
	}
}

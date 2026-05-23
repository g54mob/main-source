using UnityEngine;

namespace Battle
{
	public class GolemCluster : EnemyCluster
	{
		[Label("出現角度制限")]
		[Tooltip("n x 2の雑魚敵出現制限がゴーレム方向にかかる")]
		public float spawnFilterAngle;

		public static float SpawnFilterAngle;

		public override void SettingCluster()
		{
		}

		protected override (bool, Vector3) PositionSetting()
		{
			return default((bool, Vector3));
		}
	}
}

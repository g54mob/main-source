using UnityEngine;

namespace Battle
{
	public class SeaCluster : EnemyCluster
	{
		public Vector2 offset;

		[Label("出現角度")]
		public float sallyAngle;

		protected override (bool, Vector3) PositionSetting()
		{
			return default((bool, Vector3));
		}
	}
}

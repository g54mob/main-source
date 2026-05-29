using UnityEngine;

namespace Battle
{
	public class ShellCluster : EnemyCluster
	{
		[Header("minとmaxを入力して楕円状の出現範囲を設定")]
		public Vector2 minRadius;

		public Vector2 maxRadius;

		public Vector2 offset;

		protected override (bool, Vector3) PositionSetting()
		{
			return default((bool, Vector3));
		}
	}
}

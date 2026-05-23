using Battle;
using UnityEngine;

public class DefenseCluster : EnemyCluster
{
	[Header("minとmaxを入力して楕円状の出現範囲を設定")]
	public Vector2 minRadius;

	public Vector2 maxRadius;

	public Vector2 offset;

	private float _baseDegree;

	public override void SettingCluster()
	{
	}
}

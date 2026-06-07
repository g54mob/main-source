using UnityEngine;

public class LaserWarnFX : LineRendFX
{
	public EnemyLaserObj Owner;

	public Collider2D Col;

	public BoxCollider PlayerCol;

	public AnimationCurve CrvWarn;

	public override void Init(DamageType dt, Vector3 startPos, Vector3 endPos, bool isBaby, float thickness = 0f, LineFX parent = null)
	{
	}

	public override void Init(EnemyLaserObj l)
	{
	}

	public void RefreshPlacement(EnemyLaserObj l)
	{
	}

	public void SetDangerPct(float pct)
	{
	}
}

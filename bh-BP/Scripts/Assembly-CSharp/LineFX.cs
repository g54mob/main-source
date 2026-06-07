using UnityEngine;

public class LineFX : MonoBehaviour
{
	public LineFXType Type;

	public virtual void Run(DamageType dt, Vector3 startPos, Vector3 endPos, bool isBaby, float thickness = 0f)
	{
	}

	public virtual void Run(DamageType dt, Vector3 pos, float range)
	{
	}

	public virtual void Init(DamageType dt, Vector3 startPos, Vector3 endPos, bool isBaby, float thickness = 0f, LineFX parent = null)
	{
	}

	public virtual void Init(EnemyLaserObj l)
	{
	}

	public virtual void Run(EnemyLaserObj l)
	{
	}

	public virtual float GetThickness()
	{
		return 0f;
	}
}

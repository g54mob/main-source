using System.Linq;
using UnityEngine;

public class ProjectileScrapShot : Projectile
{
	public EnemyBase target;

	private Vector3 lastKnownPosition;

	private bool hasReachedTarget;

	public event Delegates.HealthChangeHandler OnKill;

	protected override void Move()
	{
		if (target != null)
		{
			lastKnownPosition = target.transform.position;
		}
		if (Vector3.Distance(base.transform.position, lastKnownPosition) < 0.001f)
		{
			speed = 0f;
			return;
		}
		Vector3 normalized = (lastKnownPosition - base.transform.position).normalized;
		float angle = Mathf.Atan2(normalized.y, normalized.x) * 57.29578f;
		base.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		base.transform.Translate(base.transform.right * speed * Time.deltaTime, Space.World);
	}

	protected override void RaycastCollide(float speed)
	{
		if (target == null)
		{
			return;
		}
		RaycastHit2D hit = ((!isEnemyProjectile) ? Physics2D.Raycast(base.transform.position, base.transform.up, speed * Time.deltaTime, LayerMask.GetMask("Enemy")) : Physics2D.Raycast(base.transform.position, base.transform.up, speed * Time.deltaTime, LayerMask.GetMask("Unit", "Resource")));
		if (hit.collider == null)
		{
			return;
		}
		Unit component = hit.collider.GetComponent<Unit>();
		if (component == null || component != target || component.GetComponent<Explosion>() != null || isEnemyProjectile == component.IsEnemy || component.HealthComponent.IsDead || healthComponentsHit.Contains(component.HealthComponent))
		{
			return;
		}
		if (component.TryDodge())
		{
			if (isEnemyProjectile)
			{
				healthComponentsHit.AddRange(from module in Train.Instance.Modules
					where module
					select module.HealthComponent);
			}
			else
			{
				healthComponentsHit.Add(component.HealthComponent);
			}
		}
		else
		{
			UnitHit(component, hit);
		}
	}
}

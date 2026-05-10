using UnityEngine;

public abstract class ProjectileMovement : MonoBehaviour
{
	public delegate void OnTargetReached();

	[SerializeField]
	protected float speed = 10f;

	protected Projectile projectile;

	public event OnTargetReached onTargetReached;

	protected virtual void Awake()
	{
		projectile = GetComponent<Projectile>();
	}

	protected virtual void OnEnable()
	{
	}

	public virtual void Update()
	{
		if (projectile.IsShot)
		{
			Move();
			if (CheckTargetReached())
			{
				this.onTargetReached?.Invoke();
			}
		}
	}

	protected abstract void Move();

	protected abstract bool CheckTargetReached();
}

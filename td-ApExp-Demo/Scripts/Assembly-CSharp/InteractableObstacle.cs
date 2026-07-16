using UnityEngine;

public class InteractableObstacle : TerrainObstacle
{
	[Header("Interactable")]
	[SerializeField]
	protected bool isDestructible;

	[SerializeField]
	protected bool isDestructionAnimated;

	[SerializeField]
	protected Animator animator;

	[Tooltip("Hitbox sizes and offset for each obstacle art. X - size x, Y - size y, Z - offset x, W - offset y")]
	[SerializeField]
	protected Vector4[] hitboxSizes;

	[SerializeField]
	protected Collider2D hitboxCollider;

	protected override void Start()
	{
		if (hitboxCollider == null)
		{
			Debug.LogError("[InteractableObstacle] " + base.name + " is missing a hitbox collider. Check in inspector.");
			base.enabled = false;
		}
		else if (obstaclesArt == null || obstaclesArt.Length == 0)
		{
			Debug.LogError("[InteractableObstacle] " + base.name + " is missing Obstace Art. Check in inspector.");
			base.enabled = false;
		}
		else if (obstaclesArt.Length != hitboxSizes.Length)
		{
			Debug.LogError("[InteractableObstacle] " + base.name + " the Hitbox Sizes array length does not match the Obstacles Art array length.");
			base.enabled = false;
		}
		else if (isDestructionAnimated && animator == null)
		{
			Debug.LogError("[InteractableObstacel] " + base.name + " the Animator is not set for animated obstacle. Check in inspector.");
			base.enabled = false;
		}
		else
		{
			base.Start();
		}
	}

	public override void SetSprite(int i)
	{
		base.SetSprite(i);
		SetColliderSize(i);
	}

	protected virtual void SetColliderSize(int index)
	{
		Vector4 vector = hitboxSizes[index];
		hitboxCollider.SetSize(vector.x, vector.y);
		hitboxCollider.offset = new Vector2(vector.z, vector.w);
	}

	protected virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.TryGetComponent<EnemyBase>(out var component) || component.IsGrounded != groundObstacle || component.IsEnemyGadget)
		{
			return;
		}
		HandleEnemyTriggerEnter(component);
		if (isDestructible)
		{
			if (isDestructionAnimated)
			{
				animator.SetTrigger("Destroy");
			}
			else
			{
				Object.Destroy(base.gameObject);
			}
		}
	}

	protected virtual void HandleEnemyTriggerEnter(EnemyBase enemy)
	{
	}

	protected override void OnDisable()
	{
	}
}

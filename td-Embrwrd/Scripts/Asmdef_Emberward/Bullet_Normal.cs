using UnityEngine;

public class Bullet_Normal : AProjectile
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private Rigidbody rigidbody;

	private int damage;

	private void LateUpdate()
	{
	}

	private void OnCollisionEnter(Collision other)
	{
	}

	public void Setup(int damage)
	{
	}

	protected override void SpawnProc()
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override void DestroyProc()
	{
	}
}

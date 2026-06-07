using UnityEngine;
using UnityEngine.Serialization;

public class Bullet_Cannon : ASingleTargetProjectile
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private Rigidbody rigidbody;

	[SerializeField]
	[FormerlySerializedAs("flightHeight")]
	private float maxFlightHeight;

	[SerializeField]
	private float decreaseFlightHeightRange;

	[SerializeField]
	private float explodeRange;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private float flyHeight;

	private void LateUpdate()
	{
	}

	private void Update()
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

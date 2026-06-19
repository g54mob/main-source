using UnityEngine;

public class WanderingCreature : CreatureBehaviour
{
	[SerializeField]
	private Rigidbody2D _rigidBody;

	[SerializeField]
	private float _idleDurationMin;

	[SerializeField]
	private float _idleDurationMax;

	private float _idleDuration;

	private float _idleTimer;

	private Vector2 _targetLocalPosition;

	private const float _targetPositionProximityGoal = 0.5f;

	[SerializeField]
	private float _movementForce;

	private bool _isMoving;

	private Vector2 _lastPosition;

	public Vector2 GetWanderPosition => default(Vector2);

	protected override void OnInitiate()
	{
	}

	private void FixedUpdate()
	{
	}

	public void CancelMovement()
	{
	}
}

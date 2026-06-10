using UnityEngine;

public class ButterflyMovement : MonoBehaviour
{
	[Header("Movement Settings")]
	public float moveSpeed = 1.5f;

	public float changeTargetDistance = 0.2f;

	[Header("Flutter Settings")]
	public float flutterSpeed = 5f;

	public float flutterHeight = 0.5f;

	[Header("Flight Boundaries")]
	public Vector2 minBounds;

	public Vector2 maxBounds;

	private Vector2 targetPosition;

	private SpriteRenderer spriteRenderer;

	private float flutterTimer;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		PickNewTarget();
	}

	private void Update()
	{
		Vector2 vector = base.transform.position;
		Vector2 normalized = (targetPosition - vector).normalized;
		Vector2 vector2 = Vector2.MoveTowards(vector, targetPosition, moveSpeed * Time.deltaTime);
		flutterTimer += Time.deltaTime * flutterSpeed;
		vector2.y += Mathf.Sin(flutterTimer) * flutterHeight * Time.deltaTime;
		base.transform.position = vector2;
		if (normalized.x > 0f && spriteRenderer.flipX)
		{
			spriteRenderer.flipX = false;
		}
		else if (normalized.x < 0f && !spriteRenderer.flipX)
		{
			spriteRenderer.flipX = true;
		}
		if (Vector2.Distance(base.transform.position, targetPosition) < changeTargetDistance)
		{
			PickNewTarget();
		}
	}

	private void PickNewTarget()
	{
		float x = Random.Range(minBounds.x, maxBounds.x);
		float y = Random.Range(minBounds.y, maxBounds.y);
		targetPosition = new Vector2(x, y);
	}
}

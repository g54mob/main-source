using UnityEngine;

public class Butterfly : EntityMonoBehaviour, IFlyingVisual
{
	public AnimationCurve movementBob;

	public float bobSpeed = 2.5f;

	private float curveDeltaTime;

	private Vector3 defaultSpritePos;

	private Vector3 _groundedSpritePos = new Vector3(0f, 0.1875f, 0f);

	private bool _isGrounded;

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	protected override void Awake()
	{
		base.Awake();
		defaultSpritePos = spriteObjects[0].transform.localPosition;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		curveDeltaTime += Random.Range(0f, 1f);
		DisplayOnGround(value: false);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		curveDeltaTime += Time.deltaTime * bobSpeed;
		spriteObjects[0].transform.localPosition = (_isGrounded ? _groundedSpritePos : defaultSpritePos) - new Vector3(0f, movementBob.Evaluate(curveDeltaTime), 0f);
		if (curveDeltaTime >= 1.2f)
		{
			curveDeltaTime = 0f;
		}
	}

	public void DisplayOnGround(bool value)
	{
		_isGrounded = value;
		spriteObjects[0].transform.localPosition = (_isGrounded ? _groundedSpritePos : defaultSpritePos) - new Vector3(0f, movementBob.Evaluate(curveDeltaTime), 0f);
	}
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Vector2 _moveDirection;

	private float _movementSpeedModifier;

	[SerializeField]
	private Transform _playerTransform;

	[SerializeField]
	private float _speed;

	[SerializeField]
	private float _sprintSpeedModifier;

	[SerializeField]
	private Rigidbody2D _rigidbody;

	[SerializeField]
	private ControlGuide _sprintControlGuide;

	[SerializeField]
	private ControlGuide _movementControlGuide;

	private int _disableStacks;

	public float MaxSpeed => 0f;

	public void AddDisableStack()
	{
	}

	public void RemoveDisableStack()
	{
	}

	private void Start()
	{
	}

	private void OnGameLoaded()
	{
	}

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void SetPos(Vector2 pos)
	{
	}

	public void UpdateMovement(Vector2 moveDirection, float speedModifier)
	{
	}

	private void FixedUpdate()
	{
	}

	public void AddSprintSpeedModifier(float speedModifier)
	{
	}
}

using System;
using System.Collections.Generic;
using PajamaLlama;
using PajamaLlama.Math;
using UnityEngine;

public class WorldMapTownheartPhycis2D : SceneBehaviour
{
	public enum Modes
	{
		MoveTo = 0,
		Velocity = 1,
		Force = 2
	}

	[SerializeField]
	private Rigidbody2D _rigidbody;

	[SerializeField]
	private PolygonCollider2D _collider;

	[SerializeField]
	private CircleCollider2D _ozoneShieldCollider;

	[SerializeField]
	private PolygonCollider2D _constructionColliderPrefab;

	[SerializeField]
	private Modes _mode;

	[SerializeField]
	private float _defaultAngulareDrag = 10f;

	[SerializeField]
	private float _keyAngularDrag;

	[SerializeField]
	private float _mouseAngularDrag;

	[SerializeField]
	[Range(1f, 5f)]
	[Tooltip("Mouse rotation multiplier that is lerped based on the angle between the direct of the town and the direction to the target position.")]
	private float _mouseRotationSpeedMultiplier = 2.5f;

	[Header("Actions")]
	[SerializeField]
	private RewiredAction _forward;

	[SerializeField]
	private RewiredAction _backward;

	[SerializeField]
	private RewiredAction _rotateLeft;

	[SerializeField]
	private RewiredAction _rotateRight;

	[SerializeField]
	private UIFlagSetter _flagSetter;

	private WorldMap _worldMap;

	private Engine _engine;

	private Vector2 _position;

	private bool _doMouseMovement;

	private Vector2 _mouseMovementTarget;

	private float _mouseMovementDirection;

	private float _simulationTimer;

	private Dictionary<WorldMapConstruction, PolygonCollider2D> _colliders;

	private ObjectPool<PolygonCollider2D> _colliderPool;

	public Vector3 Position => _rigidbody.position.Vector3TopDown();

	public Quaternion Rotation => Quaternion.Euler(0f, 0f - _rigidbody.rotation, 0f);

	public bool ProcessedInput { get; private set; }

	public bool Moved { get; private set; }

	public float DistanceMoved { get; private set; }

	public MouseMovementCursorProperties.Gear Gear { get; private set; }

	public RewiredAction Forward => _forward;

	public RewiredAction Backward => _backward;

	public RewiredAction RotateLeft => _rotateLeft;

	public RewiredAction RotateRight => _rotateRight;

	private void OnEnable()
	{
		SetVelocity(0f, 0f);
		if ((bool)_ozoneShieldCollider)
		{
			_ozoneShieldCollider.gameObject.SetActive(GameManager.WorldManager.World.HasEndTile);
		}
		_rigidbody.MovePosition(_worldMap.Townheart.Position.Vector2TopDown());
		_rigidbody.MoveRotation(0f - _worldMap.Townheart.transform.rotation.eulerAngles.y);
		_position = _rigidbody.position;
	}

	private void FixedUpdate()
	{
		DistanceMoved += Vector2.Distance(_rigidbody.position, _position);
		_position = _rigidbody.position;
		_worldMap.Townheart.SetTargetPositionAndRotation(Position, Rotation);
		ProcessedInput = false;
		_flagSetter.enabled = FlotsamInputManager.IsJoystick && FlotsamInputManager.GetAnyButton(_forward.ActionId, _backward.ActionId);
		if (!_worldMap.IsTownMovementBlocked)
		{
			UpdateMovementInputs();
		}
		else
		{
			Moved = false;
		}
	}

	private void UpdateMovementInputs()
	{
		MoveWithKeys();
		if (FlotsamInputManager.HasActiveInput(InputFlags.MouseAndKeyboard) && _doMouseMovement)
		{
			MoveWithMouse(_mouseMovementTarget, _mouseMovementDirection);
		}
		Moved = _worldMap.MovementSpeed / 2f * 0.033f < DistanceMoved;
	}

	private void Update()
	{
		GameSpeed gameSpeed = GameSpeedManager.GameSpeed;
		if ((uint)(gameSpeed - -1) <= 1u)
		{
			DistanceMoved = 0f;
			if (Physics2D.simulationMode == SimulationMode2D.Script)
			{
				_simulationTimer += Time.unscaledDeltaTime;
				while (_simulationTimer >= Time.fixedDeltaTime)
				{
					_simulationTimer -= Time.fixedDeltaTime;
					Physics2D.Simulate(Time.fixedDeltaTime);
					FixedUpdate();
				}
			}
		}
		else
		{
			_simulationTimer = 0f;
		}
	}

	private void LateUpdate()
	{
		GameSpeed gameSpeed = GameSpeedManager.GameSpeed;
		if ((uint)(gameSpeed - -1) > 1u)
		{
			DistanceMoved = 0f;
		}
	}

	public void Initialize(WorldMap worldMap, Engine engine)
	{
		_worldMap = worldMap;
		_engine = engine;
		_rigidbody.transform.position = GameManager.WorldManager.World.TownheartWorldPosition.Vector2TopDown();
		_rigidbody.transform.rotation = Quaternion.Euler(0f, 0f, 0f - GameManager.WorldManager.World.TownheartRotation.eulerAngles.y);
		_colliders = new Dictionary<WorldMapConstruction, PolygonCollider2D>();
		_colliderPool = new ObjectPool<PolygonCollider2D>(() => UnityEngine.Object.Instantiate(_constructionColliderPrefab, base.transform));
	}

	public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
	{
		_position = position;
		_rigidbody.transform.position = position;
		_rigidbody.transform.rotation = rotation;
	}

	public void StopMouseMovement()
	{
		_doMouseMovement = false;
	}

	private void MoveWithKeys()
	{
		Vector2 movementInput = FlotsamInputManager.GetMovementInput(_rotateLeft, _rotateRight, _backward, _forward);
		if (movementInput.sqrMagnitude != 0f)
		{
			float num = Mathf.Clamp(movementInput.y, -1f, 1f) * _worldMap.MovementSpeed;
			float num2 = Mathf.Clamp(movementInput.x, -1f, 1f) * (0f - _worldMap.RotationSpeed);
			if (Mathf.Approximately(0f, num) || Mathf.Approximately(num2, 0f))
			{
				_rigidbody.angularDamping = _defaultAngulareDrag;
			}
			else
			{
				_rigidbody.angularDamping = _keyAngularDrag;
			}
			ApplyMovementAndRotation(num, num2);
			ProcessedInput = true;
		}
	}

	private void MoveWithMouse(Vector2 target, float direction, float speedMultiplier = 1f)
	{
		float movement = direction * _worldMap.MovementSpeed * speedMultiplier;
		float num = _worldMap.RotationSpeed * Time.fixedDeltaTime;
		Vector2 to = target - _rigidbody.position;
		float num2 = ((Gear != MouseMovementCursorProperties.Gear.Reverse) ? Vector2.SignedAngle(_rigidbody.transform.up, to) : Vector2.SignedAngle(-_rigidbody.transform.up, to));
		float num3 = Mathf.Abs(num2);
		num *= Mathf.Lerp(1f, _mouseRotationSpeedMultiplier, num3 / 180f);
		if (Mathf.Approximately(num2, 0f))
		{
			num = 0f;
		}
		else if (num2 < 0f)
		{
			num = Mathf.Max(0f - num, num2);
		}
		else if (0f < num2)
		{
			num = Mathf.Min(num, num2);
		}
		_rigidbody.angularDamping = _mouseAngularDrag;
		ApplyMovementAndRotation(movement, num / Time.fixedDeltaTime);
		ProcessedInput = true;
	}

	private void MoveWithJoystick()
	{
		Vector2 rightStick = FlotsamInputManager.GetRightStick();
		float angle = 0f - Vector2.SignedAngle(Vector2.up, rightStick.normalized);
		Vector3 vector = _worldMap.WorldCameraController.transform.forward.Vector3TopDown();
		Vector3 position = _worldMap.Townheart.transform.position;
		vector.Normalize();
		vector = Quaternion.AngleAxis(angle, Vector3.up) * vector;
		Vector3 vector2 = position + vector * 150f;
		_worldMap.Townheart.DirectionIndicator.transform.position = vector2;
		MoveWithMouse(vector2.Vector2TopDown(), 1f, rightStick.magnitude);
	}

	private void ApplyMovementAndRotation(float movement, float rotation)
	{
		movement = _engine.ReturnMoveableDistance(movement * Time.fixedUnscaledDeltaTime) / Time.fixedUnscaledDeltaTime;
		if (movement != 0f)
		{
			switch (_mode)
			{
			case Modes.Velocity:
				SetVelocity(movement, rotation);
				break;
			case Modes.Force:
				AddForceAndTorque(movement, rotation);
				break;
			default:
				MovePositionAndRotation(movement * Time.fixedUnscaledDeltaTime, rotation * Time.fixedUnscaledDeltaTime);
				break;
			}
		}
	}

	private void MovePositionAndRotation(float movement, float rotation)
	{
		Vector2 vector = _rigidbody.transform.up;
		_rigidbody.MovePosition(_rigidbody.position + vector * movement);
		_rigidbody.MoveRotation(_rigidbody.rotation + rotation);
	}

	private void SetVelocity(float directionalVelocity, float angularVelocity)
	{
		_rigidbody.linearVelocity = _rigidbody.transform.up * directionalVelocity;
		_rigidbody.angularVelocity = angularVelocity;
	}

	private void AddForceAndTorque(float movement, float rotation)
	{
		Vector2 force = _rigidbody.transform.up * movement * (1f / GameSpeedManager.FixedScaledDeltaTime);
		float torque = rotation * (MathF.PI / 180f) * _rigidbody.inertia / Mathf.Max(Time.timeScale, 1f);
		_rigidbody.AddForce(force, ForceMode2D.Force);
		_rigidbody.AddTorque(torque, ForceMode2D.Force);
	}

	public void SetColliderVertices(List<WorldMapConstruction> constructions)
	{
		_collider.enabled = false;
		_collider.isTrigger = true;
		_collider.pathCount = constructions.Count;
		for (int i = 0; i < _collider.pathCount; i++)
		{
			_collider.SetPath(i, constructions[i].Polygon.Polygon2D);
		}
		_collider.enabled = true;
		_rigidbody.centerOfMass = Vector2.zero;
	}

	public void AddConstruction(WorldMapConstruction construction)
	{
		if (!_colliders.TryGetValue(construction, out var value))
		{
			value = _colliderPool.Get();
			value.name = construction.Construction.Buildable.Properties.name;
			value.pathCount = 1;
			value.gameObject.SetActive(value: true);
			_colliders.Add(construction, value);
		}
		value.SetPath(0, construction.Polygon.Polygon2D);
	}

	public void RemoveConstruction(WorldMapConstruction construction)
	{
		if (_colliders.TryGetValue(construction, out var value))
		{
			value.gameObject.SetActive(value: false);
			_colliderPool.Return(value);
			_colliders.Remove(construction);
		}
	}

	public void SetMouseMovementTargetAndDirection(Vector3 mouseMovementTarget, MouseMovementCursorProperties.Gear gear)
	{
		_doMouseMovement = true;
		_mouseMovementTarget = mouseMovementTarget.Vector2TopDown();
		float mouseMovementDirection;
		switch (gear)
		{
		case MouseMovementCursorProperties.Gear.Forward:
			mouseMovementDirection = 1f;
			break;
		case MouseMovementCursorProperties.Gear.Reverse:
		case MouseMovementCursorProperties.Gear.ForwardReverse:
			mouseMovementDirection = -1f;
			break;
		default:
			mouseMovementDirection = 0f;
			break;
		}
		_mouseMovementDirection = mouseMovementDirection;
		Gear = gear;
	}
}

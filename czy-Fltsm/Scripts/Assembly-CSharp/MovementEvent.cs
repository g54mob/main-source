using UnityEngine;

public class MovementEvent : GameEvent
{
	private static MovementEvent _startStopEvent = new MovementEvent(GameEventType.None);

	private static MovementEvent _moveEvent = new MovementEvent(GameEventType.TownheartMove);

	private static MovementEvent _movedEvent = new MovementEvent(GameEventType.TownheartMoved);

	public Vector3 PositionFrom { get; private set; }

	public Vector3 PositionTo { get; private set; }

	public Quaternion RotationFrom { get; private set; }

	public Quaternion RotationTo { get; private set; }

	public float Distance { get; private set; }

	public MovementEvent(GameEventType gameEventType)
		: base(gameEventType)
	{
	}

	private void Initialize(Vector3 positionFrom, Vector3 positionTo, Quaternion rotationFrom, Quaternion rotationTo, float distance)
	{
		PositionFrom = new Vector3(positionFrom.x, 0f, positionFrom.z);
		PositionTo = new Vector3(positionTo.x, 0f, positionTo.z);
		RotationFrom = rotationFrom;
		RotationTo = rotationTo;
		Distance = distance;
	}

	public void ApplyMovementToTransformLocal(Transform transform)
	{
		Vector3 vector = RotationFrom * transform.position + PositionFrom;
		Quaternion quaternion = RotationFrom * transform.rotation;
		transform.position = Quaternion.Inverse(RotationTo) * (vector - PositionTo);
		transform.rotation = quaternion * Quaternion.Inverse(RotationTo);
	}

	public static void DispatchStartedMoving()
	{
		_startStopEvent.EventType = GameEventType.WorldMapStartedMoving;
		_startStopEvent.Dispatch();
	}

	public static void DispatchStoppedMoving()
	{
		_startStopEvent.EventType = GameEventType.WorldMapStoppedMoving;
		_startStopEvent.Dispatch();
	}

	public static void DispatchTownheartMove(Vector3 positionFrom, Vector3 positionTo, Quaternion rotationFrom, Quaternion rotationTo, float distance)
	{
		_moveEvent.Initialize(positionFrom, positionTo, rotationFrom, rotationTo, distance);
		_moveEvent.Dispatch();
	}

	public static void DispatchTownheartMoved(Vector3 positionFrom, Vector3 positionTo, Quaternion rotationFrom, Quaternion rotationTo, float distance)
	{
		_movedEvent.Initialize(positionFrom, positionTo, rotationFrom, rotationTo, distance);
		_movedEvent.Dispatch();
	}
}

using UnityEngine;

public class CameraGameEvent : GameEvent
{
	private static readonly CameraGameEvent _instance = new CameraGameEvent();

	public Vector3 Movement { get; private set; } = Vector3.zero;

	public float DistanceMoved { get; private set; }

	public float Rotation { get; private set; }

	public float Zoom { get; private set; }

	public CameraGameEvent()
		: base(GameEventType.None)
	{
	}

	public static void DispatchManualMovement(Vector3 movement, float distanceMoved = 0f)
	{
		GetInstance(GameEventType.ManualCameraMovement, movement, distanceMoved).Dispatch();
	}

	public static void DispatchManualRotation(float rotation)
	{
		GetInstance(GameEventType.ManualCameraRotation, default(Vector3), 0f, rotation).Dispatch();
	}

	public static void DispatchManualZoom(float zoom)
	{
		GetInstance(GameEventType.ManualCameraZoom, default(Vector3), 0f, 0f, zoom).Dispatch();
	}

	public static void DispatchMaxZoom()
	{
		GetInstance(GameEventType.CameraMaxZoom).Dispatch();
	}

	public static void DispatchMinZoom()
	{
		GetInstance(GameEventType.CameraMinZoom).Dispatch();
	}

	public static void DispatchReset()
	{
		GetInstance(GameEventType.CameraReset).Dispatch();
	}

	private static CameraGameEvent GetInstance(GameEventType eventType, Vector3 movement = default(Vector3), float distanceMoved = 0f, float rotation = 0f, float zoom = 0f)
	{
		_instance.EventType = eventType;
		_instance.Movement = movement;
		_instance.DistanceMoved = ((distanceMoved != 0f) ? distanceMoved : ((movement != Vector3.zero) ? movement.magnitude : 0f));
		_instance.Rotation = rotation;
		_instance.Zoom = zoom;
		return _instance;
	}
}

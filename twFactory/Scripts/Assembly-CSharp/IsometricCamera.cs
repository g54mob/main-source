using System;
using UnityEngine;

public class IsometricCamera : PlayerCamera
{
	[SerializeField]
	private Vector3 targetOffset = Vector3.zero;

	[SerializeField]
	private float pitch = 45f;

	[SerializeField]
	private float zoom = -10f;

	[SerializeField]
	private float worldRotation;

	[SerializeField]
	private float followSmooth = 0.85f;

	[SerializeField]
	private float pitchSmooth = 0.85f;

	[SerializeField]
	private float zoomSmooth = 0.85f;

	[SerializeField]
	private float worldRotationSmooth = 0.85f;

	private float currentPitch;

	private float currentZoom;

	private float currentWorldRotation;

	private Vector3 lastPosition;

	private Vector3 lastOwnCameraPosition;

	private Quaternion lastRotation;

	public override GameObject Target
	{
		get
		{
			return base.Target;
		}
		set
		{
			bool num = !Target;
			base.Target = value;
			if (num)
			{
				FollowTarget(smooth: false);
			}
		}
	}

	public float Pitch
	{
		get
		{
			return pitch;
		}
		set
		{
			pitch = value;
		}
	}

	public float WorldRotation
	{
		get
		{
			return worldRotation;
		}
		set
		{
			worldRotation = value;
		}
	}

	public Vector3 TargetOffset
	{
		get
		{
			return targetOffset;
		}
		set
		{
			targetOffset = value;
		}
	}

	public float Zoom
	{
		get
		{
			return zoom;
		}
		set
		{
			zoom = value;
		}
	}

	public float WorldRotationSmooth
	{
		get
		{
			return worldRotationSmooth;
		}
		set
		{
			worldRotationSmooth = value;
		}
	}

	public event Action onCameraMoved;

	protected override void InitCamera()
	{
		base.InitCamera();
		base.OwnCamera.transform.localPosition = Vector3.zero - Vector3.forward * Zoom;
		base.transform.rotation = Quaternion.Euler(Pitch, WorldRotation, 0f);
		currentPitch = Pitch;
		currentZoom = Zoom;
		currentWorldRotation = WorldRotation;
		FollowTarget(smooth: false);
	}

	protected virtual void Update()
	{
		FollowTarget();
	}

	public void FollowTarget(bool smooth = true)
	{
		lastPosition = base.transform.position;
		lastOwnCameraPosition = base.OwnCamera.transform.localPosition;
		lastRotation = base.transform.rotation;
		if ((bool)Target)
		{
			if (smooth)
			{
				currentPitch = Mathf.Lerp(currentPitch, Pitch, pitchSmooth * GetDeltaTime());
				currentZoom = Mathf.Lerp(currentZoom, Zoom, zoomSmooth * GetDeltaTime());
				float b = Mathf.DeltaAngle(currentWorldRotation % 360f, WorldRotation % 360f);
				currentWorldRotation = currentWorldRotation % 360f + Mathf.Lerp(0f, b, WorldRotationSmooth * GetDeltaTime());
				base.transform.position = Vector3.Lerp(base.transform.position, Target.transform.TransformPoint(TargetOffset), followSmooth * GetDeltaTime());
				base.OwnCamera.transform.localPosition = Vector3.Lerp(base.OwnCamera.transform.localPosition, -Vector3.forward * currentZoom, followSmooth * GetDeltaTime());
				base.transform.rotation = Quaternion.Euler(currentPitch, currentWorldRotation, 0f);
			}
			else
			{
				currentZoom = Zoom;
				currentPitch = Pitch;
				currentWorldRotation = WorldRotation;
				base.transform.position = Target.transform.TransformPoint(TargetOffset);
				base.OwnCamera.transform.localPosition = -Vector3.forward * Zoom;
				base.transform.rotation = Quaternion.Euler(Pitch, WorldRotation, 0f);
			}
		}
		if (lastPosition != base.transform.position || lastOwnCameraPosition != base.OwnCamera.transform.localPosition || lastRotation != base.transform.rotation)
		{
			this.onCameraMoved?.Invoke();
		}
	}
}

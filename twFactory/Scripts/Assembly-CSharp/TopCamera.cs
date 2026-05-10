using UnityEngine;

public class TopCamera : PlayerCamera
{
	[SerializeField]
	private Vector3 targetOffset = Vector3.zero;

	[SerializeField]
	private float height = 10f;

	[SerializeField]
	private float offset = -10f;

	[SerializeField]
	private float worldRotation;

	[SerializeField]
	[Range(0f, 0.999f)]
	private float followSmooth = 0.85f;

	[SerializeField]
	[Range(0f, 0.999f)]
	private float rotationSmooth = 0.85f;

	[SerializeField]
	[Range(0f, 0.999f)]
	private float zoomSmooth = 0.85f;

	[SerializeField]
	[Range(0f, 0.999f)]
	private float worldRotationSmooth = 0.85f;

	private float currentHeight;

	private float currentOffset;

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

	public virtual float Height
	{
		get
		{
			return height;
		}
		set
		{
			height = value;
		}
	}

	public virtual float Offset
	{
		get
		{
			return offset;
		}
		set
		{
			offset = value;
		}
	}

	protected override void InitCamera()
	{
		base.InitCamera();
		base.OwnCamera.transform.position = base.transform.position + Vector3.forward * Offset;
		currentHeight = Height;
		currentOffset = Offset;
		FollowTarget(smooth: false);
	}

	protected virtual void Update()
	{
		FollowTarget();
	}

	private void FollowTarget(bool smooth = true)
	{
		if ((bool)Target)
		{
			if (smooth)
			{
				currentHeight = Mathf.Lerp(currentHeight, height, 1f - zoomSmooth);
				currentOffset = Mathf.Lerp(currentOffset, offset, 1f - zoomSmooth);
				base.transform.position = Vector3.Lerp(base.transform.position, Target.transform.TransformPoint(TargetOffset) + Vector3.up * currentHeight, 1f - followSmooth);
				base.OwnCamera.transform.position = Vector3.Lerp(base.OwnCamera.transform.position, base.transform.position + base.transform.forward * currentOffset, 1f - followSmooth);
				Quaternion b = Quaternion.LookRotation(Target.transform.TransformPoint(TargetOffset) - base.OwnCamera.transform.position);
				base.OwnCamera.transform.rotation = Quaternion.Lerp(base.OwnCamera.transform.rotation, b, 1f - rotationSmooth);
				b = Quaternion.AngleAxis(WorldRotation, base.transform.up);
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, 1f - worldRotationSmooth);
			}
			else
			{
				base.transform.position = Target.transform.TransformPoint(TargetOffset) + Vector3.up * Height;
				base.OwnCamera.transform.position = base.transform.position + Vector3.forward * Offset;
				base.OwnCamera.transform.LookAt(Target.transform.TransformPoint(TargetOffset), Vector3.up);
				base.transform.rotation = Quaternion.AngleAxis(WorldRotation, base.transform.up);
			}
		}
	}
}

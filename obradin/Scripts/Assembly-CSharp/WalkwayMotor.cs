using UnityEngine;

public class WalkwayMotor : MonoBehaviour
{
	public float radius;

	public float height;

	public float maxSpeed = 3f;

	[HideInInspector]
	public bool canControl = true;

	[WalkwayBuilt]
	public WalkwayPhysical physical;

	private float runCharge;

	public bool publishedToTransformAtLeastOnce
	{
		get
		{
			return physical.haveAppliedToSlave;
		}
	}

	private void OnEnable()
	{
		physical.SetSlave(base.transform, 0.5f * height * Vector3.up);
	}

	private void Update()
	{
		if (!Clock.play.running || !canControl)
		{
			runCharge = 0f;
			return;
		}
		float axis = RInput.GetAxis(1);
		Vector2 vector = new Vector2(RInput.GetAxis(0), axis);
		float magnitude = vector.magnitude;
		if (axis < 0.5f)
		{
			runCharge = 0f;
		}
		else
		{
			runCharge += Clock.play.deltaTime * magnitude;
		}
		if (!(magnitude <= 0f))
		{
			vector = vector.normalized * Mathf.Pow(Mathf.Min(1f, magnitude), 2f);
			Vector3 v = base.transform.rotation * vector.ToVector3XZ(0f);
			float num = maxSpeed;
			if (ScreenCap.capturing)
			{
				num *= 1f;
				runCharge = 0f;
			}
			num *= Mathf.Lerp(0.25f, 1f, Player.cameraFovT);
			if (physical.latestFloorHit.valid)
			{
				float t = Mathf.Abs(Vector3.Dot(v.normalized, physical.latestFloorHit.normal));
				num *= Mathf.Lerp(1f, 0.2f, t);
			}
			float num2 = Util.LerpScale(runCharge, 2.5f, 4.5f, 1f, 1.25f);
			num *= num2;
			Vector2 vector2 = num * v.ToVector2XZ();
			Vector2 pos2D = physical.pos + vector2 * Mathf.Max(Clock.play.deltaTime, Time.fixedDeltaTime);
			physical.MoveTo(pos2D);
		}
	}

	public void MoveToFootPos(Vector3 footPos)
	{
		physical.MoveTo(footPos.ToVector2XZ());
	}

	public void WarpToFootPos(Vector3 footPos)
	{
		physical.WarpTo(footPos);
	}
}

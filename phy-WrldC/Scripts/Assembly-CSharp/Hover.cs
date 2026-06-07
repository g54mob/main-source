using UnityEngine;

public class Hover : BaseComponentView
{
	public float kp = 40f;

	public float ki = 5f;

	public float ki2 = 5f;

	public float kd = 6f;

	public float iOffset = 50f;

	[SerializeField]
	private float hoverForce = 20f;

	[SerializeField]
	private float hoverDistance = 0.5f;

	private Rigidbody rb;

	[SerializeField]
	private float currentDistance;

	[SerializeField]
	private float currentForce;

	private Vector3 hitPoint;

	private bool isGroundHit;

	private PidController pid;

	private void FixedUpdate()
	{
		if (Physics.Raycast(base.transform.position, -base.transform.up, out var hitInfo, hoverDistance + 0.5f, LayerNames.BlockMask | LayerNames.LevelMask))
		{
			currentDistance = hitInfo.distance - 0.25f;
			pid.KP = kp;
			pid.KI = ki;
			pid.KI2 = ki2;
			pid.KD = kd;
			pid.MinIOffset = 0f - iOffset;
			pid.MaxIOffset = iOffset;
			currentForce = 1f * pid.Compute(currentDistance, hoverDistance, Time.fixedDeltaTime);
			currentForce = Mathf.Clamp(currentForce, 0f, 50f);
			rb.AddForce(base.transform.up * currentForce, ForceMode.Force);
			hitPoint = hitInfo.point;
			isGroundHit = true;
		}
		else
		{
			isGroundHit = false;
		}
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		rb = GetComponent<Rigidbody>();
		pid = new PidController(10f, 1f, 1f)
		{
			MinIOffset = -50f,
			MaxIOffset = 50f
		};
		isGroundHit = false;
	}

	public override string GetComponentName()
	{
		return typeof(Hover).Name;
	}

	private void OnDrawGizmos()
	{
		if (isGroundHit)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(base.transform.position, hitPoint);
			if (currentForce < 0f)
			{
				Gizmos.color = Color.blue;
			}
			Gizmos.DrawSphere(hitPoint, 0.1f * (currentForce / hoverForce));
		}
	}
}

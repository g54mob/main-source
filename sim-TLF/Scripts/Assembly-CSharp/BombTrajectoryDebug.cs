using UnityEngine;

[RequireComponent(typeof(AirplaneBombDropper))]
public class BombTrajectoryDebug : MonoBehaviour
{
	[Header("Симуляція")]
	[Tooltip("Drag Rigidbody на бомбі (0 = без опору)")]
	public float bombDrag;

	public float bombMass = 1f;

	public float simulationStep = 0.02f;

	public float maxSimTime = 15f;

	public float groundY;

	[Header("Ціль")]
	public Transform target;

	private AirplaneBombDropper dropper;

	private Rigidbody rb;

	private void Awake()
	{
		dropper = GetComponent<AirplaneBombDropper>();
		rb = GetComponent<Rigidbody>();
	}

	private void OnDrawGizmos()
	{
		if (!Application.isPlaying || rb == null || dropper == null)
		{
			return;
		}
		Vector3 dropOrigin = dropper.DropOrigin;
		Vector3 linearVelocity = rb.linearVelocity;
		Vector3 vector = dropOrigin;
		Vector3 vector2 = linearVelocity;
		Vector3 vector3 = dropOrigin;
		float num = ((target != null) ? target.position.y : groundY);
		Gizmos.color = Color.red;
		for (float num2 = 0f; num2 < maxSimTime; num2 += simulationStep)
		{
			Vector3 gravity = Physics.gravity;
			Vector3 vector4 = -vector2.normalized * bombDrag * vector2.sqrMagnitude / bombMass;
			Vector3 vector5 = gravity + vector4;
			Vector3 vector6 = vector + vector2 * simulationStep + 0.5f * vector5 * simulationStep * simulationStep;
			Vector3 vector7 = vector2 + vector5 * simulationStep;
			Gizmos.DrawLine(vector, vector6);
			if (vector6.y <= num)
			{
				float t = (vector.y - num) / (vector.y - vector6.y);
				vector3 = Vector3.Lerp(vector, vector6, t);
				break;
			}
			vector = vector6;
			vector2 = vector7;
		}
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(vector3, 3f);
		Gizmos.DrawLine(dropOrigin, vector3);
		float num3 = Mathf.Abs(Physics.gravity.y);
		float y = linearVelocity.y;
		float num4 = dropOrigin.y - num;
		float num5 = y * y + 2f * num3 * num4;
		float num6 = ((num5 >= 0f) ? ((0f - y + Mathf.Sqrt(num5)) / num3) : 1f);
		Vector3 vector8 = new Vector3(linearVelocity.x, 0f, linearVelocity.z);
		Vector3 vector9 = dropOrigin + vector8 * num6;
		vector9.y = num;
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(vector9, 3f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(vector3, vector9);
		Vector3.Distance(vector3, vector9);
		if (target != null)
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawWireSphere(target.position, 2f);
			Vector3.Distance(new Vector3(vector3.x, target.position.y, vector3.z), target.position);
			Vector3.Distance(new Vector3(vector9.x, target.position.y, vector9.z), target.position);
		}
	}
}

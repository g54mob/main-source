using UnityEngine;

public class RocketHead : RocketAttachment
{
	protected override float liftMultiplier => 1f;

	protected override float dragMultiplier => 1f;

	protected override float momentMultiplier => 1f;

	private void Awake()
	{
		OnAwake();
	}

	private void Start()
	{
		OnStart();
		partType = 0;
		if (rocket != null)
		{
			rocket.rocketHead = base.gameObject;
			rocket.head = this;
		}
	}

	public override Forces AerodynamicsForce(Quaternion steerAngle, Rigidbody rigid, Transform transform, float airDensity, float wingArea, float wingLength, Vector3 wind)
	{
		Vector3 direction = -rigid.linearVelocity - Vector3.Cross(rigid.angularVelocity, transform.position - rigid.worldCenterOfMass) + wind;
		Vector3 vector = transform.InverseTransformDirection(direction);
		Vector3 vector2 = transform.TransformDirection(vector.normalized);
		float num = Mathf.Atan2(Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y), 0f - vector.z) * 57.29578f;
		float num2 = airDensity * vector.sqrMagnitude * wingArea;
		coefficient coefficient = new coefficient(num);
		coefficient coefficient2 = new coefficient(90f - num);
		Vector3 vector3 = Vector3.ProjectOnPlane(vector2, transform.forward).normalized * 0.5f * coefficient.liftCoefficient * num2 * liftMultiplier;
		Vector3 vector4 = vector2;
		Vector3 vector5 = vector4 * 0.5f * coefficient.dragCoefficient * num2 + vector4 * 0.5f * coefficient2.dragCoefficient * num2 * 0.07f * dragMultiplier;
		Vector3 vector6 = (-transform.right * new coefficient(steerAngle.x).momentCoefficient + -transform.up * new coefficient(steerAngle.y).momentCoefficient + transform.forward * new coefficient(steerAngle.z).momentCoefficient) * 0.5f * num2 * wingLength;
		return new Forces(vector3 + vector5, vector6 * momentMultiplier);
	}
}

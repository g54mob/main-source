using System;
using UnityEngine;

public class Parachute : MonoBehaviour
{
	public struct Forces
	{
		public Vector3 Force;

		public Vector3 Torque;

		public Forces(Vector3 InputForce, Vector3 InputTorque)
		{
			Force = InputForce;
			Torque = InputTorque;
		}
	}

	public struct coefficient
	{
		public float liftCoefficient;

		public float dragCoefficient;

		public float momentCoefficient;

		public coefficient(float angleOfAttack)
		{
			float num = angleOfAttack * (MathF.PI / 180f);
			liftCoefficient = 0.8f * Mathf.Sin(2f * num);
			dragCoefficient = 0.8f * Mathf.Sin(2f * num - MathF.PI / 2f) + 0.8f;
			momentCoefficient = -0.6f * Mathf.Sin(num * 0.5f);
		}
	}

	[SerializeField]
	protected float area = 1f;

	[SerializeField]
	protected float length = 2f;

	private float originalArea;

	protected float liftMultiplier;

	protected float dragMultiplier = 1f;

	protected float momentMultiplier = 1f;

	public Rigidbody rocketRb;

	protected float airDensity = 1.2f;

	protected float thrustScalar;

	protected Forces force;

	public virtual Forces AerodynamicsForce(Quaternion steerAngle, Rigidbody rigid, Transform transform, float airDensity, float wingArea, float wingLength, Vector3 wind)
	{
		Vector3 direction = -rigid.linearVelocity - Vector3.Cross(rigid.angularVelocity, transform.position - rigid.worldCenterOfMass) + wind;
		Vector3 vector = transform.InverseTransformDirection(direction);
		Vector3 vector2 = transform.TransformDirection(vector.normalized);
		float num = Mathf.Atan2(vector.y, 0f - vector.z) * 57.29578f;
		float num2 = airDensity * vector.sqrMagnitude * wingArea;
		coefficient coefficient2 = new coefficient(num);
		coefficient coefficient3 = new coefficient(90f - num);
		Vector3 vector3 = Vector3.Cross(vector2, -transform.right) * 0.5f * coefficient2.liftCoefficient * num2 * liftMultiplier;
		Vector3 vector4 = vector2;
		Vector3 vector5 = vector4 * 0.5f * coefficient2.dragCoefficient * num2 + vector4 * 0.5f * coefficient3.dragCoefficient * num2 * 0.07f * dragMultiplier;
		Vector3 vector6 = (-transform.right * new coefficient(steerAngle.x).momentCoefficient + -transform.up * new coefficient(steerAngle.y).momentCoefficient + transform.forward * new coefficient(steerAngle.z).momentCoefficient) * 0.5f * num2 * wingLength;
		return new Forces(vector3 + vector5, vector6 * momentMultiplier);
	}

	public virtual void AddForces()
	{
		Quaternion identity = Quaternion.identity;
		force = AerodynamicsForce(identity, rocketRb, base.transform, airDensity, area, length, GameManager.S.windManager.wind);
		rocketRb.AddForceAtPosition(force.Force, base.transform.position);
	}
}

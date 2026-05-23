using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization;

public class RocketAttachment : MonoBehaviour
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

	public LocalizedString partNameTemp;

	public string partName;

	public int partValue;

	public MeshRenderer meshRenderer;

	public Sprite mainImage;

	public int partType;

	public float mass;

	public GameObject[] gizmos;

	[Header("Forces")]
	public float inspectorForce;

	[SerializeField]
	protected float area = 1f;

	[SerializeField]
	protected float length = 2f;

	private float originalArea;

	protected float bounsArea;

	public Vector3 massOffset;

	public Rigidbody rocketRb;

	public Rocket rocket;

	protected float airDensity = 1.2f;

	protected float thrustScalar;

	protected Forces force;

	protected virtual float liftMultiplier => 1f;

	protected virtual float dragMultiplier => 1f;

	protected virtual float momentMultiplier => 1f;

	private void OnValidate()
	{
		inspectorForce = GetOnlyLiftMagnitude();
	}

	protected void OnAwake()
	{
		originalArea = area;
		bounsArea = 0f;
	}

	public void SetArea(float newArea)
	{
		area = originalArea * newArea;
		bounsArea = area - originalArea;
		inspectorForce = GetOnlyLiftMagnitude();
	}

	protected void OnStart()
	{
		rocket = GetComponentInParent<Rocket>();
		if (rocket != null)
		{
			StartCoroutine(DelayedUpdateRocketMass());
		}
	}

	private IEnumerator DelayedUpdateRocketMass()
	{
		yield return null;
		rocketRb = rocket.GetComponent<Rigidbody>();
		rocketRb.mass += mass;
		rocket.UpdateCenterOfMass();
	}

	public virtual Forces AerodynamicsForce(Quaternion steerAngle, Rigidbody rigid, Transform transform, float airDensity, float wingArea, float wingLength, Vector3 wind)
	{
		Vector3 direction = -rigid.linearVelocity - Vector3.Cross(rigid.angularVelocity, transform.position - rigid.worldCenterOfMass) + wind;
		Vector3 vector = transform.InverseTransformDirection(direction);
		Vector3 vector2 = transform.TransformDirection(vector.normalized);
		float num;
		Vector3 vector3;
		if (partType == 2)
		{
			num = Mathf.Atan2(vector.y, 0f - vector.z) * 57.29578f;
			vector3 = Vector3.Cross(vector2, -transform.right);
		}
		else if (partType == 0)
		{
			float num2 = Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
			num = Mathf.Atan2(num2, 0f - vector.z) * 57.29578f;
			if (num2 > 0.001f)
			{
				Vector3 normalized = new Vector3(vector.x, vector.y, 0f).normalized;
				vector3 = transform.TransformDirection(normalized);
			}
			else
			{
				vector3 = Vector3.zero;
			}
		}
		else if (partType == 1)
		{
			float num3 = Mathf.Sqrt(vector.x * vector.x + vector.z * vector.z);
			num = Mathf.Atan2(num3, 0f - vector.y) * 57.29578f;
			if (num3 > 0.001f)
			{
				Vector3 normalized2 = new Vector3(vector.x, vector.y, 0f).normalized;
				vector3 = transform.TransformDirection(normalized2);
			}
			else
			{
				vector3 = Vector3.zero;
			}
		}
		else
		{
			float num4 = Mathf.Sqrt(vector.x * vector.x + vector.z * vector.z);
			num = Mathf.Atan2(num4, 0f - vector.y) * 57.29578f;
			if (num4 > 0.001f)
			{
				Vector3 normalized3 = new Vector3(vector.x, 0f, vector.z).normalized;
				vector3 = transform.TransformDirection(normalized3);
			}
			else
			{
				vector3 = Vector3.zero;
			}
		}
		float num5 = airDensity * vector.sqrMagnitude * wingArea;
		coefficient coefficient2 = new coefficient(num);
		coefficient coefficient3 = new coefficient(90f - num);
		Vector3 vector4 = vector3 * 0.5f * coefficient2.liftCoefficient * num5 * liftMultiplier;
		Vector3 vector5 = vector2;
		Vector3 vector6 = vector5 * 0.5f * coefficient2.dragCoefficient * num5 + vector5 * 0.5f * coefficient3.dragCoefficient * num5 * 0.07f;
		vector6 *= dragMultiplier;
		return new Forces(InputTorque: (-transform.right * new coefficient(steerAngle.x).momentCoefficient + -transform.up * new coefficient(steerAngle.y).momentCoefficient + transform.forward * new coefficient(steerAngle.z).momentCoefficient) * 0.5f * num5 * wingLength * momentMultiplier, InputForce: vector4 + vector6);
	}

	public virtual float GetOnlyLiftMagnitude()
	{
		Vector3 vector = -base.transform.forward * 5f + base.transform.up;
		_ = Quaternion.identity;
		Vector3 direction = vector;
		Vector3 vector2 = base.transform.InverseTransformDirection(direction);
		Vector3 vector3 = base.transform.TransformDirection(vector2.normalized);
		float num;
		Vector3 vector4;
		if (partType == 2)
		{
			num = Mathf.Atan2(vector2.y, 0f - vector2.z) * 57.29578f;
			vector4 = Vector3.Cross(vector3, -base.transform.right);
		}
		else if (partType == 0)
		{
			float num2 = Mathf.Sqrt(vector2.x * vector2.x + vector2.y * vector2.y);
			num = Mathf.Atan2(num2, 0f - vector2.z) * 57.29578f;
			if (num2 > 0.001f)
			{
				Vector3 normalized = new Vector3(vector2.x, vector2.y, 0f).normalized;
				vector4 = base.transform.TransformDirection(normalized);
			}
			else
			{
				vector4 = Vector3.zero;
			}
		}
		else if (partType == 1)
		{
			float num3 = Mathf.Sqrt(vector2.x * vector2.x + vector2.z * vector2.z);
			num = Mathf.Atan2(num3, 0f - vector2.y) * 57.29578f;
			if (num3 > 0.001f)
			{
				Vector3 normalized2 = new Vector3(vector2.x, vector2.y, 0f).normalized;
				vector4 = base.transform.TransformDirection(normalized2);
			}
			else
			{
				vector4 = Vector3.zero;
			}
		}
		else
		{
			float num4 = Mathf.Sqrt(vector2.x * vector2.x + vector2.z * vector2.z);
			num = Mathf.Atan2(num4, 0f - vector2.y) * 57.29578f;
			if (num4 > 0.001f)
			{
				Vector3 normalized3 = new Vector3(vector2.x, 0f, vector2.z).normalized;
				vector4 = base.transform.TransformDirection(normalized3);
			}
			else
			{
				vector4 = Vector3.zero;
			}
		}
		float num5 = airDensity * vector2.sqrMagnitude * area;
		coefficient coefficient2 = new coefficient(num);
		coefficient coefficient3 = new coefficient(90f - num);
		Vector3 vector5 = vector4 * 0.5f * coefficient2.liftCoefficient * num5 * liftMultiplier;
		Vector3 vector6 = vector3;
		Vector3 vector7 = vector6 * 0.5f * coefficient2.dragCoefficient * num5 + vector6 * 0.5f * coefficient3.dragCoefficient * num5 * 0.07f;
		vector7 *= dragMultiplier;
		return Vector3.ProjectOnPlane(vector5 + vector7, base.transform.forward).magnitude;
	}

	public (float lift, float drag) GetLiftDrag()
	{
		Vector3 vector = -base.transform.forward * 5f + base.transform.up;
		_ = Quaternion.identity;
		Vector3 direction = vector;
		Vector3 vector2 = base.transform.InverseTransformDirection(direction);
		Vector3 vector3 = base.transform.TransformDirection(vector2.normalized);
		float num;
		Vector3 vector4;
		if (partType == 2)
		{
			num = Mathf.Atan2(vector2.y, 0f - vector2.z) * 57.29578f;
			vector4 = Vector3.Cross(vector3, -base.transform.right);
		}
		else if (partType == 0)
		{
			float num2 = Mathf.Sqrt(vector2.x * vector2.x + vector2.y * vector2.y);
			num = Mathf.Atan2(num2, 0f - vector2.z) * 57.29578f;
			if (num2 > 0.001f)
			{
				Vector3 normalized = new Vector3(vector2.x, vector2.y, 0f).normalized;
				vector4 = base.transform.TransformDirection(normalized);
			}
			else
			{
				vector4 = Vector3.zero;
			}
		}
		else if (partType == 1)
		{
			float num3 = Mathf.Sqrt(vector2.x * vector2.x + vector2.z * vector2.z);
			num = Mathf.Atan2(num3, 0f - vector2.y) * 57.29578f;
			if (num3 > 0.001f)
			{
				Vector3 normalized2 = new Vector3(vector2.x, vector2.y, 0f).normalized;
				vector4 = base.transform.TransformDirection(normalized2);
			}
			else
			{
				vector4 = Vector3.zero;
			}
		}
		else
		{
			float num4 = Mathf.Sqrt(vector2.x * vector2.x + vector2.z * vector2.z);
			num = Mathf.Atan2(num4, 0f - vector2.y) * 57.29578f;
			if (num4 > 0.001f)
			{
				Vector3 normalized3 = new Vector3(vector2.x, 0f, vector2.z).normalized;
				vector4 = base.transform.TransformDirection(normalized3);
			}
			else
			{
				vector4 = Vector3.zero;
			}
		}
		float num5 = airDensity * vector2.sqrMagnitude * area;
		coefficient coefficient2 = new coefficient(num);
		coefficient coefficient3 = new coefficient(90f - num);
		Vector3 vector5 = vector4 * 0.5f * coefficient2.liftCoefficient * num5 * liftMultiplier;
		Vector3 vector6 = vector3;
		Vector3 vector7 = vector6 * 0.5f * coefficient2.dragCoefficient * num5 + vector6 * 0.5f * coefficient3.dragCoefficient * num5 * 0.07f;
		vector7 *= dragMultiplier;
		return (lift: vector5.magnitude, drag: vector7.magnitude);
	}

	public virtual void AddForces()
	{
		Quaternion identity = Quaternion.identity;
		force = AerodynamicsForce(identity, rocketRb, base.transform, airDensity, originalArea, length, GameManager.S.windManager.wind);
		rocketRb.AddForceAtPosition(force.Force, base.transform.position);
		rocketRb.AddTorque(force.Torque);
		Debug.DrawRay(base.transform.position, force.Force.normalized * 3f, Color.cyan);
	}

	public void OnDisassembled()
	{
		rocketRb.mass -= mass;
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public float GetCurrentForceMagnitude(Vector3 windDir)
	{
		return AerodynamicsForce(Quaternion.identity, rocketRb, base.transform, airDensity, area, length, windDir).Force.magnitude;
	}

	public Vector3 GetPartPosition()
	{
		return base.transform.position;
	}
}

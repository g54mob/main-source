using System;
using UnityEngine;

public class WheelColliderSource : MonoBehaviour
{
	[SerializeField]
	private Transform renderer;

	private Rigidbody rigidbody;

	private Vector3 accumDir;

	private WheelFrictionCurveSource m_forwardFriction;

	private WheelFrictionCurveSource m_sidewaysFriction;

	private float m_forwardSlip;

	private float m_sidewaysSlip;

	private Vector3 m_totalForce;

	private Vector3 m_center;

	private bool m_isGrounded;

	private float m_wheelMotorTorque;

	private float m_wheelBrakeTorque;

	private float m_wheelSteerAngle;

	private float m_wheelAngularVelocity;

	private float m_wheelRotationAngle;

	[SerializeField]
	private float m_wheelRadius;

	[SerializeField]
	private float m_wheelMass;

	private RaycastHit m_raycastHit;

	[SerializeField]
	private Color GizmoColor;

	private Vector3 forward;

	public Vector3 Center
	{
		get
		{
			return m_center;
		}
		set
		{
			m_center = value;
		}
	}

	public WheelFrictionCurveSource ForwardFriction
	{
		get
		{
			return m_forwardFriction;
		}
		set
		{
			m_forwardFriction = value;
		}
	}

	public WheelFrictionCurveSource SidewaysFriction
	{
		get
		{
			return m_sidewaysFriction;
		}
		set
		{
			m_sidewaysFriction = value;
		}
	}

	public float MotorTorque
	{
		get
		{
			return m_wheelMotorTorque;
		}
		set
		{
			m_wheelMotorTorque = value;
		}
	}

	public float BrakeTorque
	{
		get
		{
			return m_wheelBrakeTorque;
		}
		set
		{
			m_wheelBrakeTorque = value;
		}
	}

	public float SteerAngle
	{
		get
		{
			return m_wheelSteerAngle;
		}
		set
		{
			m_wheelSteerAngle = value;
		}
	}

	public bool IsGrounded => m_isGrounded;

	public float RPM => m_wheelAngularVelocity;

	public Transform Renderer
	{
		get
		{
			return renderer;
		}
		set
		{
			renderer = value;
		}
	}

	public float Radius
	{
		get
		{
			return m_wheelRadius;
		}
		set
		{
			m_wheelRadius = value;
		}
	}

	public float Mass
	{
		get
		{
			return m_wheelMass;
		}
		set
		{
			m_wheelMass = value;
		}
	}

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
		Center = Vector3.zero;
		m_forwardFriction = new WheelFrictionCurveSource();
		m_sidewaysFriction = new WheelFrictionCurveSource();
		m_forwardFriction.ExtremumSlip = 2f;
		m_forwardFriction.ExtremumValue = 800f;
		m_forwardFriction.AsymptoteSlip = 3f;
		m_forwardFriction.AsymptoteValue = 400f;
		m_forwardFriction.Stiffness = 1f;
		m_sidewaysFriction.ExtremumSlip = 1f;
		m_sidewaysFriction.ExtremumValue = 100f;
		m_sidewaysFriction.AsymptoteSlip = 2f;
		m_sidewaysFriction.AsymptoteValue = 50f;
		m_sidewaysFriction.Stiffness = 1f;
		MotorTorque = 0f;
		BrakeTorque = 0f;
	}

	private void FixedUpdate()
	{
		UpdateSuspension();
		UpdateWheel();
		if (m_isGrounded)
		{
			forward = Vector3.Cross(accumDir.normalized, -base.transform.right);
			CalculateSlips();
			CalculateForcesFromSlips();
			rigidbody.AddForce(m_totalForce);
		}
		m_isGrounded = false;
		accumDir.Set(0f, 0f, 0f);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = GizmoColor;
		Vector3 vector = base.transform.TransformPoint(m_wheelRadius * new Vector3(0f, Mathf.Sin(0f), Mathf.Cos(0f)));
		for (int i = 1; i <= 20; i++)
		{
			Vector3 vector2 = base.transform.TransformPoint(m_wheelRadius * new Vector3(0f, Mathf.Sin((float)i / 20f * (float)Math.PI * 2f), Mathf.Cos((float)i / 20f * (float)Math.PI * 2f)));
			Gizmos.DrawLine(vector, vector2);
			vector = vector2;
		}
		Gizmos.color = Color.white;
	}

	public bool GetGroundHit(out WheelHitSource wheelHit)
	{
		wheelHit = default(WheelHitSource);
		if (m_isGrounded)
		{
			wheelHit.Collider = m_raycastHit.collider;
			wheelHit.Point = m_raycastHit.point;
			wheelHit.Normal = m_raycastHit.normal;
			wheelHit.ForwardDir = base.transform.forward;
			wheelHit.SidewaysDir = -base.transform.right;
			wheelHit.Force = m_totalForce;
			wheelHit.ForwardSlip = m_forwardSlip;
			wheelHit.SidewaysSlip = m_sidewaysSlip;
		}
		return m_isGrounded;
	}

	private void UpdateSuspension()
	{
		GizmoColor = (m_isGrounded ? Color.green : Color.red);
	}

	private void UpdateWheel()
	{
		m_wheelRotationAngle += m_wheelAngularVelocity * Time.fixedDeltaTime;
		renderer.localEulerAngles = new Vector3(m_wheelRotationAngle, 0f, 0f);
		if (m_isGrounded && m_wheelMotorTorque == 0f)
		{
			m_wheelAngularVelocity -= Mathf.Sign(m_forwardSlip) * m_forwardFriction.Evaluate(m_forwardSlip) / ((float)Math.PI * 2f * m_wheelRadius) / m_wheelMass * Time.fixedDeltaTime * 100f;
		}
		m_wheelAngularVelocity += m_wheelMotorTorque / m_wheelRadius / m_wheelMass * Time.fixedDeltaTime;
		m_wheelAngularVelocity -= Mathf.Sign(m_wheelAngularVelocity) * Mathf.Min(Mathf.Abs(m_wheelAngularVelocity), m_wheelBrakeTorque * m_wheelRadius / m_wheelMass * Time.fixedDeltaTime);
	}

	private void CalculateSlips()
	{
		Vector3 velocity = rigidbody.velocity;
		Vector3 vector = -base.transform.right;
		Vector3 rhs = Vector3.Dot(velocity, forward) * forward;
		Vector3 rhs2 = Vector3.Dot(velocity, vector) * vector;
		m_forwardSlip = (0f - Mathf.Sign(Vector3.Dot(forward, rhs))) * rhs.magnitude + m_wheelAngularVelocity * (float)Math.PI / 180f * m_wheelRadius;
		m_sidewaysSlip = (0f - Mathf.Sign(Vector3.Dot(vector, rhs2))) * rhs2.magnitude;
	}

	private void CalculateForcesFromSlips()
	{
		m_totalForce = forward * Mathf.Sign(m_forwardSlip) * m_forwardFriction.Evaluate(m_forwardSlip);
		m_totalForce -= base.transform.right * Mathf.Sign(m_sidewaysSlip) * m_forwardFriction.Evaluate(m_sidewaysSlip);
	}

	private void OnCollisionStay(Collision collision)
	{
		accumDir += collision.contacts[0].normal;
		m_isGrounded = true;
	}
}

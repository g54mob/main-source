using System;
using UnityEngine;

[AddComponentMenu("BoneCracker Games/Simple Car Controller/SCC Wheel")]
[RequireComponent(typeof(WheelCollider))]
public class SCC_Wheel : MonoBehaviour
{
	private Rigidbody rigid;

	private SCC_Drivetrain drivetrain;

	private SCC_Network net;

	private WheelCollider wheelCollider;

	public Transform wheelModel;

	private float wheelRotation;

	internal bool isGrounded;

	internal float totalSlip;

	internal float rpm;

	internal float wheelRPMToSpeed;

	private Rigidbody Rigid
	{
		get
		{
			if (rigid == null)
			{
				rigid = GetComponentInParent<Rigidbody>();
			}
			return rigid;
		}
	}

	private SCC_Drivetrain Drivetrain
	{
		get
		{
			if (drivetrain == null)
			{
				drivetrain = GetComponentInParent<SCC_Drivetrain>();
			}
			return drivetrain;
		}
	}

	private SCC_Network Net
	{
		get
		{
			if (net == null)
			{
				net = GetComponentInParent<SCC_Network>();
			}
			return net;
		}
	}

	public WheelCollider WheelCollider
	{
		get
		{
			if (wheelCollider == null)
			{
				wheelCollider = GetComponent<WheelCollider>();
			}
			return wheelCollider;
		}
		set
		{
			wheelCollider = value;
		}
	}

	private void Awake()
	{
		if (!wheelModel)
		{
			Debug.LogError(base.transform.name + " wheel of the " + Drivetrain.transform.name + " is missing wheel model. This wheel is disabled");
			base.enabled = false;
			return;
		}
		GameObject gameObject = new GameObject(wheelModel.name);
		gameObject.transform.position = wheelModel.position;
		gameObject.transform.SetParent(Rigid.transform);
		gameObject.transform.localRotation = Quaternion.identity;
		gameObject.transform.localScale = Vector3.one;
		Transform[] componentsInChildren = wheelModel.GetComponentsInChildren<Transform>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].SetParent(gameObject.transform);
		}
		wheelModel = gameObject.transform;
	}

	private void Update()
	{
		if (!Drivetrain || !WheelCollider)
		{
			Debug.LogError("Drivetrain or wheelcollider is not found. This wheel is disabled");
			base.enabled = false;
		}
		else
		{
			WheelAlign();
		}
	}

	private void FixedUpdate()
	{
		isGrounded = WheelCollider.GetGroundHit(out var hit);
		rpm = WheelCollider.rpm;
		wheelRPMToSpeed = WheelCollider.rpm * WheelCollider.radius / 2.8f * Mathf.Lerp(1f, 0.75f, hit.forwardSlip) * Rigid.transform.lossyScale.y;
	}

	private void WheelAlign()
	{
		if (!wheelModel)
		{
			Debug.LogError(base.transform.name + " wheel of the " + Drivetrain.transform.name + " is missing wheel model. This wheel is disabled");
			base.enabled = false;
			return;
		}
		Vector3 vector = WheelCollider.transform.TransformPoint(WheelCollider.center);
		WheelCollider.GetGroundHit(out var hit);
		if (Physics.Raycast(vector, -WheelCollider.transform.up, out var hitInfo, (WheelCollider.suspensionDistance + WheelCollider.radius) * base.transform.localScale.y) && !hitInfo.collider.isTrigger && !hitInfo.transform.IsChildOf(Rigid.transform))
		{
			wheelModel.transform.position = hitInfo.point + WheelCollider.transform.up * WheelCollider.radius * base.transform.localScale.y;
			float num = (0f - WheelCollider.transform.InverseTransformPoint(hit.point).y - WheelCollider.radius) / WheelCollider.suspensionDistance;
			Debug.DrawLine(hit.point, hit.point + WheelCollider.transform.up * (hit.force / Rigid.mass), ((double)num <= 0.0) ? Color.magenta : Color.white);
			Debug.DrawLine(hit.point, hit.point - WheelCollider.transform.forward * hit.forwardSlip * 2f, Color.green);
			Debug.DrawLine(hit.point, hit.point - WheelCollider.transform.right * hit.sidewaysSlip * 2f, Color.red);
		}
		else
		{
			wheelModel.transform.position = Vector3.Lerp(wheelModel.transform.position, vector - WheelCollider.transform.up * WheelCollider.suspensionDistance * base.transform.localScale.y, Time.deltaTime * 10f);
		}
		float num2 = WheelCollider.rpm;
		if (Net != null && !Net.isOwned && WheelCollider.radius > 0f)
		{
			num2 = Net.syncSpeed / 3.6f * 60f / (MathF.PI * 2f * WheelCollider.radius);
		}
		wheelRotation += num2 * 6f * Time.deltaTime;
		wheelModel.transform.rotation = WheelCollider.transform.rotation * Quaternion.Euler(wheelRotation, WheelCollider.steerAngle, WheelCollider.transform.rotation.z);
	}
}

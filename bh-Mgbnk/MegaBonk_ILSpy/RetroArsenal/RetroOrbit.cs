using Cpp2ILInjected;
using UnityEngine;

namespace RetroArsenal;

public class RetroOrbit : MonoBehaviour
{
	public Transform target;

	public Vector3 cameraOffset;

	public float defaultDistance;

	private float _currentDistance;

	public float xSpeed;

	public float ySpeed;

	public float yMinLimit;

	public float yMaxLimit;

	public float distanceMin;

	public float distanceMax;

	public float zoomLerpSpeed;

	public float smoothingFactor;

	public float collisionOffset;

	private float rotationYAxis;

	private float rotationXAxis;

	private float velocityX;

	private float velocityY;

	private Vector3 originalTargetPosition;

	private void Start()
	{
		//IL_00bb: Expected O, but got F4
		Transform transform = base.transform;
		Vector3 eulerAngles = transform.eulerAngles;
		rotationXAxis = eulerAngles.x;
		rotationYAxis = eulerAngles.y;
		Rigidbody component = GetComponent<Rigidbody>();
		if ((bool)component)
		{
			Rigidbody component2 = GetComponent<Rigidbody>();
			component2.freezeRotation = true;
		}
		_currentDistance = defaultDistance;
		Vector3 position = target.position;
		originalTargetPosition = (Vector3)position.x;
		_ = position.z;
	}

	private unsafe void LateUpdate()
	{
		//IL_0472: Expected O, but got Ref
		//IL_01c9: Expected O, but got Ref
		//IL_01c9: Expected O, but got Ref
		//IL_0500: Invalid comparison between I4 and F4
		//IL_02e9: Expected F4, but got I4
		//IL_055c: Expected O, but got Ref
		//IL_055c: Expected O, but got Ref
		//IL_030b: Expected O, but got Ref
		//IL_030b: Expected O, but got Ref
		//IL_0331: Expected O, but got Ref
		//IL_034d: Expected O, but got Ref
		//IL_0375: Invalid comparison between I4 and F4
		//IL_03c0: Expected F4, but got I4
		//IL_05c4: Invalid comparison between I4 and F4
		//IL_03fc: Expected F4, but got I4
		if (!target)
		{
			return;
		}
		if (Input.GetMouseButton(1))
		{
			float axis = Input.GetAxis("Mouse X");
			float num = xSpeed * axis;
			float num2 = num * _currentDistance;
			float num3 = num2 * 0.02f;
			float num4 = num3 + velocityX;
			velocityX = num4;
			float axis2 = Input.GetAxis("Mouse Y");
			float num5 = axis2 * ySpeed;
			float num6 = num5 * 0.02f;
			float num7 = num6 + velocityY;
			velocityY = num7;
		}
		float num8 = rotationXAxis - velocityY;
		float num9 = velocityX + rotationYAxis;
		float num10 = yMinLimit;
		rotationYAxis = num9;
		if (!(yMinLimit > num8))
		{
			num10 = yMaxLimit;
			if (!(num8 > yMaxLimit))
			{
				num10 = num8;
			}
		}
		rotationXAxis = num10;
		float num11 = default(float);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&num11));
		float axis3 = Input.GetAxis("Mouse ScrollWheel");
		float num12 = axis3 * 10f;
		float num13 = defaultDistance - num12;
		if (!(distanceMin > num13))
		{
			if (num13 > distanceMax)
			{
				num13 = distanceMax;
			}
		}
		else
		{
			num13 = distanceMin;
		}
		defaultDistance = num13;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		Vector3 position2 = target.position;
		Vector3 position3 = target.position;
		float num14 = default(float);
		if (Physics.Raycast((Vector3)(&num14), (Vector3)(&num11), out var hitInfo, defaultDistance))
		{
			Collider collider = hitInfo.collider;
			GameObject gameObject = collider.gameObject;
			string text = gameObject.name;
			if (!text.Contains("Missile"))
			{
				Collider collider2 = hitInfo.collider;
				GameObject gameObject2 = collider2.gameObject;
				string text2 = gameObject2.name;
				if (!text2.Contains("Obstacle"))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231C560");
					object obj = default(object);
					num13 = (float)obj - collisionOffset;
				}
			}
		}
		float deltaTime = Time.deltaTime;
		float num15 = deltaTime * zoomLerpSpeed;
		if (!(0f > num15))
		{
			if (num15 > 1f)
			{
				num15 = 1f;
			}
		}
		else
		{
			num15 = 0f;
		}
		float num16 = num13 - _currentDistance;
		float num17 = num16 * num15;
		float currentDistance = num17 + _currentDistance;
		_currentDistance = currentDistance;
		float num18 = default(float);
		Vector3 vector = (Quaternion)(&num18) * (Vector3)(&num11);
		Vector3 position4 = target.position;
		Vector3 vector2 = (Quaternion)(&num18) * (Vector3)(&num14);
		Transform transform2 = base.transform;
		transform2.rotation = (Quaternion)(&num18);
		Transform transform3 = base.transform;
		transform3.position = (Vector3)(&num11);
		float deltaTime2 = Time.deltaTime;
		float num19 = deltaTime2 * smoothingFactor;
		if (!(0f > num19))
		{
			if (num19 > 1f)
			{
				num19 = 1f;
			}
		}
		else
		{
			num19 = 0f;
		}
		float num20 = 0f - velocityX;
		float num21 = num20 * num19;
		float num22 = num21 + velocityX;
		velocityX = num22;
		float deltaTime3 = Time.deltaTime;
		float num23 = deltaTime3 * smoothingFactor;
		if (!(0f > num23))
		{
			if (num23 > 1f)
			{
				num23 = 1f;
			}
		}
		else
		{
			num23 = 0f;
		}
		float num24 = 0f - velocityY;
		float num25 = num24 * num23;
		float num26 = num25 + velocityY;
		velocityY = num26;
	}

	public RetroOrbit()
	{
		//IL_000f: Expected O, but got I8
		cameraOffset = (Vector3)3221225472L;
		_ = 1056964608;
		defaultDistance = 5f;
		_currentDistance = 5f;
		xSpeed = 1f;
		ySpeed = 1f;
		yMinLimit = -20f;
		yMaxLimit = 80f;
		distanceMin = 0.5f;
		distanceMax = 15f;
		zoomLerpSpeed = 2f;
		smoothingFactor = 2f;
		collisionOffset = 0.2f;
		base._002Ector();
	}
}

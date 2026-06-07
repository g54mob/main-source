using UnityEngine;

public class WaveMotion : MonoBehaviour
{
	private bool isOn;

	private Transform shipBase;

	private Transform shipMotion;

	private Transform ferryBase;

	private Transform ferryMotion;

	private Transform sky;

	private RingBuffer<Matrix4x4> skyHistory = new RingBuffer<Matrix4x4>(60);

	private float windowLight = 1f;

	private LaggedTransform headLaggedTransform = new LaggedTransform();

	private static WaveMotion instance;

	public static Vector3 gravityDir { get; private set; }

	private void Start()
	{
		instance = this;
		sky = base.transform.FindDescendant("Sky");
		shipBase = base.transform.FindDescendant("ship_base");
		shipMotion = base.transform.FindDescendant("ship_motion");
		ferryBase = base.transform.FindDescendant("ferry_base");
		ferryMotion = base.transform.FindDescendant("ferry_motion");
		gravityDir = -Vector3.up;
		isOn = true;
		FixedUpdate();
	}

	private void OnDestroy()
	{
		gravityDir = -Vector3.up;
		if (this == instance)
		{
			instance = null;
		}
	}

	private void FixedUpdate()
	{
		if (!isOn)
		{
			gravityDir = -Vector3.up;
			return;
		}
		Matrix4x4 inverse = (shipBase.worldToLocalMatrix * shipMotion.localToWorldMatrix).inverse;
		sky.transform.rotation = Util.QuaternionFromMatrix(inverse);
		sky.transform.position = inverse.GetColumn(3);
		skyHistory.Add(inverse);
		gravityDir = -inverse.GetY();
		headLaggedTransform.Approach(inverse, 0.5f);
	}

	private void Update()
	{
		isOn = DebugMenu.IsOn("Wave Motion", KeyCode.None, true);
		if (!isOn || sky == null)
		{
			if (HeadMotion.instance != null)
			{
				HeadMotion.instance.SetOffset(HeadMotion.Id.FromWaves, Vector3.zero);
			}
		}
		else
		{
			Vector3 cameraWorldPositionWithoutOffset = HeadMotion.instance.GetCameraWorldPositionWithoutOffset(HeadMotion.Id.FromWaves);
			Vector3 vector = headLaggedTransform.matrix.MultiplyPoint(cameraWorldPositionWithoutOffset);
			HeadMotion.instance.SetOffset(HeadMotion.Id.FromWaves, 0.2f * (vector - cameraWorldPositionWithoutOffset));
			float input = Vector3.Angle(instance.skyHistory.Get(0).GetY(), Vector3.up);
			windowLight = Util.LerpScale(input, 0f, 2f, 1f, 0.5f);
		}
	}

	public static Vector3 GetGravityDir(int fixedFrameDelay)
	{
		if (instance == null || instance.skyHistory.isEmpty || !instance.isOn)
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			float num = 10f * (Mathf.Cos(realtimeSinceStartup * 2f) + 1f) * 0.5f;
			Quaternion q = Quaternion.Euler(num * Mathf.Cos(realtimeSinceStartup * 0.5f), 0f, num * Mathf.Sin(realtimeSinceStartup * 0.5f));
			return Matrix4x4.TRS(Vector3.zero, q, Vector3.one).MultiplyPoint(new Vector3(0f, -1f, 0f));
		}
		Vector3 y = instance.skyHistory.Get(fixedFrameDelay).GetY();
		y = (y + 2f * (y - Vector3.up)).normalized;
		return -y;
	}

	public static float GetWindowLight()
	{
		return (!(instance != null)) ? 1f : instance.windowLight;
	}

	public static Matrix4x4 GetSkyMatrix()
	{
		return (!(instance != null)) ? Matrix4x4.identity : instance.skyHistory.Get(0);
	}

	public static Matrix4x4 GetFerryMatrix()
	{
		if (instance == null || !instance.isOn)
		{
			return Matrix4x4.identity;
		}
		return instance.ferryMotion.localToWorldMatrix;
	}

	public static Matrix4x4 GetFerryBase()
	{
		if (instance == null || !instance.isOn)
		{
			return Matrix4x4.identity;
		}
		return instance.ferryBase.worldToLocalMatrix;
	}
}

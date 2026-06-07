using UnityEngine;

public class LaserBeam : MonoBehaviour
{
	public GameObject segment;

	public int segmentsToInstantiate = 200;

	public float twistAngle;

	public float materialExpStart = 2.2f;

	public float materialExpEnd = 0.3f;

	public int expEndAfterSegments = 10;

	public AnimationCurve expCurve;

	private bool isNonVr;

	private void Start()
	{
		float num = segment.GetComponent<Renderer>().bounds.extents.z * 2f;
		GameObject gameObject = new GameObject();
		for (int i = 0; i < segmentsToInstantiate; i++)
		{
			GameObject obj = Object.Instantiate(segment, gameObject.transform);
			obj.transform.localPosition = new Vector3(0f, 0f, num * (float)i);
			obj.transform.Rotate(gameObject.transform.forward, twistAngle * (float)i);
			obj.GetComponent<Renderer>().material.SetFloat("_Exp", Mathf.Lerp(materialExpStart, materialExpEnd, expCurve.Evaluate((float)i / (float)segmentsToInstantiate)));
			obj.name = obj.name + " " + i;
		}
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localRotation = Quaternion.identity;
		for (int num2 = gameObject.transform.childCount - 1; num2 >= 0; num2--)
		{
			Transform child = gameObject.transform.GetChild(num2);
			Vector3 localPosition = child.transform.localPosition;
			Quaternion localRotation = child.transform.localRotation;
			child.transform.parent = base.transform;
			child.localPosition = localPosition;
			child.localRotation = localRotation;
		}
		Object.Destroy(gameObject);
		isNonVr = !VRManager.IsVREnabled();
		if (!isNonVr)
		{
			base.enabled = false;
		}
	}

	public void EnableBeam(bool enableBeam, bool disableLaserPositionUpdate = false)
	{
		base.gameObject.SetActive(enableBeam);
		if (enableBeam && isNonVr)
		{
			base.enabled = !disableLaserPositionUpdate;
		}
	}

	private void Update()
	{
		Transform transform = PlayerManager.PlayerCamera?.transform;
		if (isNonVr && !(transform == null))
		{
			Vector3 vector = transform.position + transform.forward * 200f;
			base.transform.rotation = Quaternion.LookRotation(vector - base.transform.position);
		}
	}
}

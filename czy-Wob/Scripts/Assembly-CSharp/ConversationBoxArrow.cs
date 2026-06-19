using UnityEngine;

public class ConversationBoxArrow : MonoBehaviour
{
	public Transform targetTransform;

	public GameObject backingArrowRef;

	public Vector3 backingArrowOffset = new Vector3(-10f, -10f, 0f);

	private float rectWorldHeight;

	private Camera uiCam;

	private RectTransform rectRef;

	private void Awake()
	{
		rectRef = GetComponent<RectTransform>();
		uiCam = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Camera>(GlobalObject.UI_CAMERA);
		RecordHeight();
	}

	private void Update()
	{
		UpdateArrowToFollowTransform();
	}

	private void RecordHeight()
	{
		Vector3[] array = new Vector3[4];
		rectRef.GetWorldCorners(array);
		rectWorldHeight = array[1].y - array[0].y;
	}

	private void UpdateArrowToFollowTransform()
	{
		if (rectWorldHeight == 0f)
		{
			RecordHeight();
			return;
		}
		Vector3 position = rectRef.transform.position;
		Vector3 vector = uiCam.WorldToViewportPoint(position);
		float z = MathUtil.GetAngle2D(p2: uiCam.WorldToViewportPoint(targetTransform.position), p1: vector) * 57.29578f - 90f;
		base.transform.localRotation = Quaternion.Euler(0f, 0f, z);
		float num = rectWorldHeight;
		float y = Vector3.Distance(position, targetTransform.position) / num;
		base.transform.localScale = new Vector3(1f, y, 1f);
		backingArrowRef.transform.rotation = base.transform.rotation;
		backingArrowRef.transform.localScale = base.transform.localScale;
		backingArrowRef.transform.position = base.transform.position - backingArrowOffset;
	}
}

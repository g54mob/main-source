using UnityEngine;

public class WindDirectionArrow : MonoBehaviour
{
	private Transform camTransform;

	public RectTransform targetUI0;

	public RectTransform targetUI;

	public RectTransform target;

	public Camera uiCamera;

	public Canvas parentCanvas;

	private void OnEnable()
	{
		camTransform = Camera.main.transform;
	}

	private void Start()
	{
		if (GameManager.S.isAnemometerInstalled)
		{
			target = targetUI;
		}
		else
		{
			target = targetUI0;
		}
	}

	private void Update()
	{
		if (!(target == null) && !(uiCamera == null))
		{
			Vector2 vector = Vector2.zero;
			if (parentCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
			{
				vector = RectTransformUtility.WorldToScreenPoint(null, target.position);
			}
			else if (parentCanvas.renderMode == RenderMode.ScreenSpaceCamera)
			{
				vector = RectTransformUtility.WorldToScreenPoint(parentCanvas.worldCamera, target.position);
			}
			float z = base.transform.localPosition.z;
			Vector3 position = new Vector3(vector.x, vector.y, z);
			Vector3 position2 = uiCamera.ScreenToWorldPoint(position);
			base.transform.position = position2;
			Vector3 vector2 = Camera.main.transform.InverseTransformDirection(GameManager.S.windManager.wind);
			if (vector2 != Vector3.zero)
			{
				Quaternion localRotation = Quaternion.LookRotation(vector2, Vector3.up);
				base.transform.localRotation = localRotation;
			}
		}
	}
}

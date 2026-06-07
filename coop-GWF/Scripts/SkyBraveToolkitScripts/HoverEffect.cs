using UnityEngine;

public class HoverEffect : MonoBehaviour
{
	private Vector3 originalRotation;

	private Vector3 targetRotation;

	private bool isHovered;

	public float rotationIntensity = 10f;

	public float lerpSpeed = 5f;

	private void Start()
	{
		originalRotation = base.transform.rotation.eulerAngles;
		targetRotation = originalRotation;
	}

	private void Update()
	{
		DoHover();
	}

	private void DoHover()
	{
		if (isHovered)
		{
			Vector3 vector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - base.transform.position;
			float num = Mathf.Clamp(vector.y * rotationIntensity, 0f - rotationIntensity, rotationIntensity);
			float num2 = Mathf.Clamp((0f - vector.x) * rotationIntensity, 0f - rotationIntensity, rotationIntensity);
			targetRotation = new Vector3(originalRotation.x + num, originalRotation.y + num2, originalRotation.z);
		}
		else
		{
			targetRotation = originalRotation;
		}
		base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * lerpSpeed);
	}

	private void OnMouseEnter()
	{
		isHovered = true;
	}

	private void OnMouseExit()
	{
		isHovered = false;
	}
}

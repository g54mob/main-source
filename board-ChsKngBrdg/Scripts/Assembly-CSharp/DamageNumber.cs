using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
	public Transform target;

	public Vector3 targetOffset;

	public Camera targetCamera;

	public TMP_Text damageNumber;

	public TMP_Text backdrop;

	public AnimationCurve opacityCurve;

	private float opacitySeconds;

	private bool isSetup;

	public void Setup(string text, Transform hit, Camera cam, Vector3 offset)
	{
		damageNumber.text = text;
		backdrop.text = text;
		target = hit;
		targetOffset = offset;
		targetCamera = cam;
		opacitySeconds = 0f;
		isSetup = true;
	}

	public void Update()
	{
		if (isSetup)
		{
			if (opacitySeconds < opacityCurve[opacityCurve.length - 1].time)
			{
				opacitySeconds += Time.deltaTime;
				damageNumber.color = new Color(damageNumber.color.r, damageNumber.color.g, damageNumber.color.b, opacityCurve.Evaluate(opacitySeconds));
				backdrop.color = new Color(backdrop.color.r, backdrop.color.g, backdrop.color.b, opacityCurve.Evaluate(opacitySeconds));
				base.transform.position = targetCamera.WorldToScreenPoint(target.position + targetOffset);
			}
			else
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}

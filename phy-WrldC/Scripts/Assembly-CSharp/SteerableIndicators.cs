using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SteerableIndicators : MonoBehaviour
{
	[SerializeField]
	private float forwardTargetAngle = 30f;

	[SerializeField]
	private float backwardTargetAngle = 30f;

	[SerializeField]
	private float angleOffset;

	[SerializeField]
	private Image circularFill;

	[SerializeField]
	private Image backwardArrow;

	[SerializeField]
	private Image middleArrow;

	[SerializeField]
	private Image forwardArrow;

	[SerializeField]
	private bool shouldRunInRealTime;

	private void Awake()
	{
		if (circularFill == null)
		{
			circularFill = base.transform.FindComponent<Image>("CircularFill", isRecursively: true);
		}
		if (backwardArrow == null)
		{
			middleArrow = base.transform.FindComponent<Image>("BackwardArrow", isRecursively: true);
		}
		if (middleArrow == null)
		{
			middleArrow = base.transform.FindComponent<Image>("MiddleArrow", isRecursively: true);
		}
		if (forwardArrow == null)
		{
			middleArrow = base.transform.FindComponent<Image>("ForwardArrow", isRecursively: true);
		}
	}

	private void Update()
	{
		if (shouldRunInRealTime)
		{
			UpdateIndicators();
		}
	}

	public void UpdateIndicators()
	{
		float num = Mathf.Clamp(forwardTargetAngle, 0f, 360f);
		float num2 = Mathf.Clamp(backwardTargetAngle, 0f, 360f);
		float num3 = num + num2;
		float z = num2 - angleOffset;
		circularFill.fillAmount = num3 / 360f;
		circularFill.transform.localRotation = Quaternion.Euler(0f, 0f, z);
		backwardArrow.transform.localRotation = Quaternion.Euler(0f, 0f, 0f - angleOffset + num2);
		middleArrow.transform.localRotation = Quaternion.Euler(0f, 0f, 0f - angleOffset);
		forwardArrow.transform.localRotation = Quaternion.Euler(0f, 0f, 0f - angleOffset - num);
	}

	public void SetParameters(float forwardTargetAngle, float backwardTargetAngle, float angleOffset)
	{
		this.forwardTargetAngle = forwardTargetAngle;
		this.backwardTargetAngle = backwardTargetAngle;
		this.angleOffset = angleOffset;
		UpdateIndicators();
	}

	public void SetVisibility(bool isVisible)
	{
		base.gameObject.SetActive(isVisible);
	}
}

using UnityEngine;
using UnityEngine.UI;

public class GoopMixerGUI : MonoBehaviour
{
	public Image mixerGraphic;

	public GameObject mixerHolder;

	public Rigidbody2D mixerGraphicBody;

	public Color standardMixColor;

	public Color fullyMixedColor;

	public GameObject startText;

	public GameObject successText;

	public float torqueMultiplier = 100f;

	private float maximalVel = -4000f;

	private float startPercentage = 0.1f;

	private float standardAngularDrag = 0.05f;

	private float mixerTarget;

	private float mixerIncreaseRate = 0.2f;

	private void Update()
	{
		UpdateMixerGauge();
	}

	public void UpdateGoopMixer(float percentage)
	{
		if (percentage == 0f)
		{
			mixerGraphic.fillAmount = percentage;
		}
		else if (percentage >= 1f)
		{
			mixerGraphicBody.angularVelocity = maximalVel;
		}
		if (percentage > mixerTarget)
		{
			mixerGraphicBody.AddTorque((percentage - mixerTarget) * (0f - torqueMultiplier));
		}
		mixerTarget = percentage;
		if (mixerTarget <= startPercentage)
		{
			ShowStartText();
		}
		else if (mixerTarget < 1f)
		{
			HideAllText();
		}
	}

	public void ResetGoopMixer()
	{
		mixerGraphic.fillAmount = 0f;
		mixerGraphicBody.transform.localRotation = Quaternion.identity;
	}

	private void UpdateMixerGauge()
	{
		if (mixerTarget != mixerGraphic.fillAmount)
		{
			float num = mixerIncreaseRate * Time.deltaTime;
			float num2 = Mathf.Clamp(mixerGraphic.fillAmount + num, 0f, mixerTarget);
			if (mixerTarget >= 1f || mixerTarget == 0f)
			{
				num2 = mixerTarget;
			}
			mixerGraphic.fillAmount = num2;
			if (num2 >= 1f)
			{
				ShowSuccessText();
				mixerGraphicBody.angularDrag = 0f;
				mixerGraphic.color = fullyMixedColor;
			}
			else
			{
				mixerGraphic.color = standardMixColor;
				mixerGraphicBody.angularDrag = standardAngularDrag;
			}
		}
	}

	public void ShowStartText()
	{
		startText.SetActive(value: true);
		successText.SetActive(value: false);
	}

	public void ShowSuccessText()
	{
		startText.SetActive(value: false);
		successText.SetActive(value: true);
	}

	public void HideAllText()
	{
		startText.SetActive(value: false);
		successText.SetActive(value: false);
	}
}

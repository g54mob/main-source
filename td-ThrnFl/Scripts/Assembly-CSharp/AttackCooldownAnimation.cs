using MPUIKIT;
using MoreMountains.Feedbacks;
using UnityEngine;

public class AttackCooldownAnimation : MonoBehaviour
{
	public GameObject parent;

	public MPImage cooldownIndicator;

	public MMF_Player onShow;

	public MMF_Player onHide;

	private float currentCooldownPercentage;

	private bool inCooldown;

	private void Start()
	{
		parent.SetActive(value: false);
	}

	public void SetCurrentCooldownPercentage(float value)
	{
		currentCooldownPercentage = value;
		if (inCooldown && currentCooldownPercentage <= 0f)
		{
			onShow.StopFeedbacks();
			onHide.StopFeedbacks();
			onHide.PlayFeedbacks();
			inCooldown = false;
		}
		if (!inCooldown && currentCooldownPercentage > 0f)
		{
			onShow.StopFeedbacks();
			onHide.StopFeedbacks();
			onShow.PlayFeedbacks();
			inCooldown = true;
		}
	}

	private void Update()
	{
		if (currentCooldownPercentage > 0f)
		{
			cooldownIndicator.fillAmount = 1f - currentCooldownPercentage;
		}
	}
}

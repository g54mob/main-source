using System.Collections;
using MoreMountains.Feedbacks;
using UnityEngine;

public class BuildingFXProcessor : MonoBehaviour
{
	public BuildSlot targetBuilding;

	public Hp targetHp;

	public MMF_Player onBuildFX;

	public MMF_Player onParentBuildFX;

	public MMF_Player onUpgradeFX;

	public MMF_Player onParentUpgradeFX;

	public MMF_Player onReviveFX;

	private void Start()
	{
		targetBuilding.OnUpgrade.AddListener(OnBuildingUpgrade);
		targetBuilding.OnParentUpgrade.AddListener(OnParentBuildingUpgrade);
		if ((bool)targetHp)
		{
			targetHp.OnRevive.AddListener(OnBuildingRevive);
		}
	}

	private void OnBuildingUpgrade()
	{
		if (targetBuilding.Level == 1)
		{
			onBuildFX.PlayFeedbacks();
		}
		else if (targetBuilding.Level > 1)
		{
			onUpgradeFX.PlayFeedbacks();
		}
	}

	private void OnParentBuildingUpgrade()
	{
		StartCoroutine(PlayDelayedParentUpgradeFeedback());
	}

	private IEnumerator PlayDelayedParentUpgradeFeedback()
	{
		yield return null;
		if (targetBuilding.Level == 1)
		{
			onParentBuildFX.PlayFeedbacks();
		}
		else if (targetBuilding.Level > 1)
		{
			onParentUpgradeFX.PlayFeedbacks();
		}
	}

	private void OnBuildingRevive()
	{
		onReviveFX.PlayFeedbacks();
	}
}

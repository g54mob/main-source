using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipUI_tower : TooltipUI
{
	[Header("Target priority")]
	[SerializeField]
	private Image firstTargetProviderImage;

	[SerializeField]
	private Image secondTargetProviderImage;

	[Header("Experience")]
	[SerializeField]
	private FillBar towerUpgradeFillBar;

	[SerializeField]
	private Image towerUpgradedIcon;

	[SerializeField]
	private Color towerUpgradeFullColor;

	[Header("Gems")]
	[SerializeField]
	private UIList gemsList;

	private Tower tower;

	private AutoTransformRebuild autoTransformRebuild;

	private bool setupWorldObject = true;

	public override void Setup(Dictionary<string, object> data)
	{
		tower = data["tower"] as Tower;
		TowerController towerController = tower.Controller as TowerController;
		firstTargetProviderImage.sprite = towerController.FirstTargetProvider.Icon;
		secondTargetProviderImage.sprite = towerController.SecondTargetProvider.Icon;
		if (setupWorldObject)
		{
			WorldObjectUI component = GetComponent<WorldObjectUI>();
			component.FollowTarget = tower.gameObject;
			component.Offset += tower.PlacementComponent.GetCenter() - tower.transform.position;
			setupWorldObject = false;
		}
		if (!tower.GameplayObject.ObjectData.IsUpgrade())
		{
			tower.onExperienceChanged += OnExperienceChanged;
		}
		tower.GemsComponent.onGemAdded += OnGemAddedOrRemoved;
		tower.GemsComponent.onGemRemoved += OnGemAddedOrRemoved;
		UpdateExperienceBar(tower.Experience / LTFunctionLibrary.GetLTGameManager().TowerExperienceToUpgrade);
		UpdateGems();
		if (!autoTransformRebuild)
		{
			autoTransformRebuild = GetComponent<AutoTransformRebuild>();
		}
		autoTransformRebuild.RebuildTransform();
	}

	private void OnDestroy()
	{
		if ((bool)tower && !tower.GameplayObject.ObjectData.IsUpgrade())
		{
			tower.onExperienceChanged -= OnExperienceChanged;
		}
	}

	private void UpdateExperienceBar(float experiencePercentage)
	{
		if (tower.GameplayObject.ObjectData.IsUpgrade())
		{
			towerUpgradeFillBar.gameObject.SetActive(value: false);
			towerUpgradedIcon.gameObject.SetActive(value: true);
			return;
		}
		towerUpgradeFillBar.gameObject.SetActive(value: true);
		towerUpgradedIcon.gameObject.SetActive(value: false);
		towerUpgradeFillBar.SetBarValue(experiencePercentage);
		if (experiencePercentage >= 1f)
		{
			towerUpgradeFillBar.SetBarColor(towerUpgradeFullColor);
		}
	}

	private void UpdateGems()
	{
		List<GemData> list = tower.GemsComponent.GemsList;
		list.TrimExcess();
		if (list.Count > 0)
		{
			gemsList.gameObject.SetActive(value: true);
			gemsList.LoadList(list);
		}
		else
		{
			gemsList.gameObject.SetActive(value: false);
		}
	}

	private void OnExperienceChanged(float experience, float experiencePercentage)
	{
		UpdateExperienceBar(experiencePercentage);
	}

	private void OnGemAddedOrRemoved(GemData data)
	{
		UpdateGems();
		if (base.gameObject.activeInHierarchy)
		{
			autoTransformRebuild?.RebuildTransform();
		}
	}
}

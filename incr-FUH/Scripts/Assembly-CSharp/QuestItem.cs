using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestItem : MonoBehaviour
{
	public AchievementDefinition Achievement;

	public Image IconImage;

	public TMP_Text Title;

	public TMP_Text Description;

	public TMP_Text Reward;

	public TMP_Text DemoDesc;

	public UIButton ButtonClaim;

	public GameObject DarkPanel;

	public List<Sprite> Icons;

	private void Start()
	{
		if (!Achievement.IsVisible())
		{
			DemoDesc.gameObject.SetActive(value: true);
			ButtonClaim.gameObject.SetActive(value: false);
		}
		else
		{
			DemoDesc.gameObject.SetActive(value: false);
		}
	}

	private void FixedUpdate()
	{
		Refresh();
	}

	public void Refresh()
	{
		IconImage.sprite = Icons[(int)Achievement.AchievementType];
		switch (Achievement.AchievementType)
		{
		case AchievementDefinition.AchievementTypeEnum.GarbateOnScreen:
			Title.text = "Waste Wonderland";
			Description.text = "Have " + Achievement.GetCurrentValue() + "/" + Achievement.MaxValue + " trash on screen";
			Reward.text = "<color=green>Reward:</color> Can focus building on top";
			break;
		case AchievementDefinition.AchievementTypeEnum.BreakARock:
			Title.text = "Rock Smasher";
			Description.text = "Break " + Achievement.GetCurrentValue() + "/" + Achievement.MaxValue + " rocks";
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + " yellow shard";
			break;
		case AchievementDefinition.AchievementTypeEnum.Build2SameBuilding:
			Title.text = "I like this";
			Description.text = "Build the same building twice";
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + " yellow shard";
			break;
		case AchievementDefinition.AchievementTypeEnum.DestroyACloudManually:
			Title.text = "Cloudbuster";
			Description.text = "Manually destroy " + Achievement.GetCurrentValue() + "/" + Achievement.MaxValue + " clouds";
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + "$";
			break;
		case AchievementDefinition.AchievementTypeEnum.GetMoneyP1:
			Title.text = "Money Maker";
			Description.text = "Earn " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " $";
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + "$";
			break;
		case AchievementDefinition.AchievementTypeEnum.GetMoneyP2:
			Title.text = "High Roller";
			Description.text = "Earn " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " $";
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + "$";
			break;
		case AchievementDefinition.AchievementTypeEnum.GetMoneyP3:
			Title.text = "Money Master";
			Description.text = "Earn " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " $";
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + "$";
			break;
		case AchievementDefinition.AchievementTypeEnum.GetNewBuilding:
			Title.text = "Building the Future";
			Description.text = "Unlock a new building type";
			Reward.text = "<color=green>Reward:</color> Ability to see all upgrade nodes";
			break;
		case AchievementDefinition.AchievementTypeEnum.Get1RedShard:
			Title.text = "Another dimension";
			Description.text = "Obtain " + Achievement.GetCurrentValue() + "/" + Achievement.MaxValue + " red shard";
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + " blue shard";
			break;
		case AchievementDefinition.AchievementTypeEnum.Get1Book:
			Title.text = "Knowledge is power";
			Description.text = "Obtain " + Achievement.GetCurrentValue() + "/" + Achievement.MaxValue + " book";
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + " blue shard";
			break;
		case AchievementDefinition.AchievementTypeEnum.Open50Nodes:
			Title.text = "???";
			Description.text = "???";
			Reward.text = "???";
			break;
		case AchievementDefinition.AchievementTypeEnum.GetYellowShardP1:
			Title.text = "Yellow Spark";
			Description.text = "Obtain " + Achievement.GetCurrentValue() + "/" + Achievement.MaxValue + " yellow shards";
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + " yellow shard";
			break;
		case AchievementDefinition.AchievementTypeEnum.GetYellowShardP2:
			Title.text = "Shard Seeker";
			Description.text = "Obtain " + Achievement.GetCurrentValue() + "/" + Achievement.MaxValue + " yellow shards";
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + " blue shard";
			break;
		case AchievementDefinition.AchievementTypeEnum.GetBlueShardP1:
			Title.text = "Blue Spark";
			Description.text = "Obtain " + Achievement.GetCurrentValue() + "/" + Achievement.MaxValue + " blue shards";
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + " yellow shard";
			break;
		case AchievementDefinition.AchievementTypeEnum.GetBlueShardP2:
			Title.text = "Collector";
			Description.text = "Obtain " + Achievement.GetCurrentValue() + "/" + Achievement.MaxValue + " blue shards";
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + " yellow shard";
			break;
		case AchievementDefinition.AchievementTypeEnum.Level10Building:
			Title.text = "Master Builder";
			Description.text = "Reach level " + Achievement.GetCurrentValue() + "/" + Achievement.MaxValue + " with any building";
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + " yellow shard, " + Achievement.AmountGiven.ToNumber() + " blue shard";
			break;
		case AchievementDefinition.AchievementTypeEnum.UseCompressor:
			Title.text = LanguageText.GetText("Compressor");
			Description.text = "Use a Compressor building " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " times";
			Reward.text = "<color=green>Reward:</color> Call an airplane to drop trash";
			break;
		case AchievementDefinition.AchievementTypeEnum.UseHelicopter:
			Title.text = LanguageText.GetText("Helipad");
			Description.text = "Use a Helipad building " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " times";
			Reward.text = "<color=green>Reward:</color> Call an airplane to drop trash";
			break;
		case AchievementDefinition.AchievementTypeEnum.UsePower:
			Title.text = LanguageText.GetText("Power");
			Description.text = "Use a Power building " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " times";
			Reward.text = "<color=green>Reward:</color> Call an airplane to drop trash";
			break;
		case AchievementDefinition.AchievementTypeEnum.UseTraining:
			Title.text = LanguageText.GetText("Training");
			Description.text = "Use a Training building " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " times";
			Reward.text = "<color=green>Reward:</color> Call an airplane to drop trash";
			break;
		case AchievementDefinition.AchievementTypeEnum.UseTemple:
			Title.text = "???";
			Description.text = "???";
			Reward.text = "???";
			break;
		case AchievementDefinition.AchievementTypeEnum.UseDrone:
			Title.text = LanguageText.GetText("Cloud Seeder");
			Description.text = "Use a Cloud Seeder building " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " times";
			Reward.text = "<color=green>Reward:</color> Call an airplane to drop trash";
			break;
		case AchievementDefinition.AchievementTypeEnum.UseResearch:
			Title.text = LanguageText.GetText("Research Lab");
			Description.text = "Use a Research Lab building " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " times";
			Reward.text = "<color=green>Reward:</color> Call an airplane to drop trash";
			break;
		case AchievementDefinition.AchievementTypeEnum.UseHotAirStation:
			Title.text = LanguageText.GetText("Hangar");
			Description.text = "Use a Hangar building " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " times";
			Reward.text = "<color=green>Reward:</color> Call an airplane to drop trash";
			break;
		case AchievementDefinition.AchievementTypeEnum.UseAnAbility:
			Title.text = "Ability Activation";
			Description.text = "Use an ability";
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + " yellow shard";
			break;
		case AchievementDefinition.AchievementTypeEnum.Make3Earthquake:
			Title.text = "Seismic Force";
			Description.text = "Trigger " + Achievement.GetCurrentValue() + "/" + Achievement.MaxValue + " earthquakes";
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + "$";
			break;
		case AchievementDefinition.AchievementTypeEnum.FinishGameBadEnding:
			Title.text = "???";
			Description.text = "???";
			Reward.text = "???";
			break;
		case AchievementDefinition.AchievementTypeEnum.FinishGameGoodEnding:
			Title.text = "???";
			Description.text = "???";
			Reward.text = "???";
			break;
		case AchievementDefinition.AchievementTypeEnum.BuildingStability5Times:
			Title.text = "Power Through Destruction";
			Description.text = "Have a building reach durability level " + Achievement.GetCurrentValue() + "/" + Achievement.MaxValue;
			Reward.text = "<color=green>Reward:</color> " + Achievement.AmountGiven.ToNumber() + " yellow shard";
			break;
		case AchievementDefinition.AchievementTypeEnum.RpP1:
			Title.text = "Point of Discovery";
			Description.text = "Earn " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " RP";
			Reward.text = "<color=green>Reward:</color> Get " + Achievement.AmountGiven.ToNumber() + "$";
			break;
		case AchievementDefinition.AchievementTypeEnum.RpP2:
			Title.text = "Knowledge Seeker";
			Description.text = "Earn " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " RP";
			Reward.text = "<color=green>Reward:</color> Get " + Achievement.AmountGiven.ToNumber() + "$";
			break;
		case AchievementDefinition.AchievementTypeEnum.RpP3:
			Title.text = "Research Power";
			Description.text = "Earn " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " RP";
			Reward.text = "<color=green>Reward:</color> Get " + Achievement.AmountGiven.ToNumber() + "$";
			break;
		case AchievementDefinition.AchievementTypeEnum.PeonGarbageThrowP1:
			Title.text = "The Cleanup Begins";
			Description.text = "Have peons throw " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " trash into the hole";
			Reward.text = "<color=green>Reward:</color> Get " + Achievement.AmountGiven.ToNumber() + " yellow shard";
			break;
		case AchievementDefinition.AchievementTypeEnum.PeonGarbageThrowP2:
			Title.text = "Into the Void";
			Description.text = "Have peons throw " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " trash into the hole";
			Reward.text = "<color=green>Reward:</color> Get " + Achievement.AmountGiven.ToNumber() + " yellow shard";
			break;
		case AchievementDefinition.AchievementTypeEnum.PeonGarbageThrowP3:
			Title.text = "Sacrificial Trash";
			Description.text = "Have peons throw " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " trash into the hole";
			Reward.text = "<color=green>Reward:</color> Get " + Achievement.AmountGiven.ToNumber() + " yellow shard";
			break;
		case AchievementDefinition.AchievementTypeEnum.PeonThrow:
			Title.text = "Gods Hand";
			Description.text = "Throw " + Achievement.GetCurrentValue() + "/" + Achievement.MaxValue + " peons";
			Reward.text = "<color=green>Reward:</color> Get " + Achievement.AmountGiven.ToNumber() + "$";
			break;
		case AchievementDefinition.AchievementTypeEnum.UseHouse:
			Title.text = LanguageText.GetText("House");
			Description.text = "Use a House building " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " times";
			Reward.text = "<color=green>Reward:</color> Call an airplane to drop trash";
			break;
		case AchievementDefinition.AchievementTypeEnum.UseCatapult:
			Title.text = LanguageText.GetText("Catapult");
			Description.text = "Use a Catapult building " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " times";
			Reward.text = "<color=green>Reward:</color> Call an airplane to drop trash";
			break;
		case AchievementDefinition.AchievementTypeEnum.UseIndustry:
			Title.text = LanguageText.GetText("Factory");
			Description.text = "Use a Factory building " + Achievement.GetCurrentValue().ToNumber() + "/" + Achievement.MaxValue.ToNumber() + " times";
			Reward.text = "<color=green>Reward:</color> Call an airplane to drop trash";
			break;
		case AchievementDefinition.AchievementTypeEnum.WakeUpTheGolem:
			Title.text = "???";
			Description.text = "???";
			Reward.text = "???";
			break;
		case AchievementDefinition.AchievementTypeEnum.Sacrifice:
			Title.text = "???";
			Description.text = "???";
			Reward.text = "???";
			break;
		}
		if (Achievement.IsVisible())
		{
			if (!Achievement.CanActivate)
			{
				ButtonClaim.gameObject.SetActive(value: false);
				DarkPanel.gameObject.SetActive(value: true);
			}
			else if (Achievement.CanActivate && !Achievement.IsActivated)
			{
				ButtonClaim.gameObject.SetActive(value: true);
				ButtonClaim.ButtonText.text = "Claim";
				DarkPanel.gameObject.SetActive(value: false);
			}
			else if (Achievement.IsActivated)
			{
				ButtonClaim.gameObject.SetActive(value: true);
				ButtonClaim.ButtonText.text = "Claimed";
				DarkPanel.gameObject.SetActive(value: true);
			}
		}
		else
		{
			DarkPanel.gameObject.SetActive(value: true);
		}
		Title.text = Title.text.ToUpper();
	}

	public void ProcessClaim()
	{
		if (Achievement.Activate())
		{
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ui_quest_claim);
		}
	}
}

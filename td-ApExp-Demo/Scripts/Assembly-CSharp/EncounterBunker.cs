using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "Encounter", menuName = "Encounter/Bunker")]
public class EncounterBunker : Encounter
{
	[Header("Option 1")]
	private float scrapGained;

	[SerializeField]
	private float scrapGainedEasy;

	[SerializeField]
	private float scrapGainedMedium;

	[SerializeField]
	private float scrapGainedHard;

	[Header("Option 2")]
	[SerializeField]
	private float percentDamageTaken;

	private EnhancementWagon wagonTypeObtained1;

	[SerializeField]
	private EnhancementWagon wagonTypeObtained1Easy;

	[SerializeField]
	private EnhancementWagon wagonTypeObtained1Medium;

	[SerializeField]
	private EnhancementWagon wagonTypeObtained1Hard;

	[Header("Option 3")]
	private EnhancementWagon wagonTypeObtained2;

	[SerializeField]
	private EnhancementWagon wagonTypeObtained2Easy;

	[SerializeField]
	private EnhancementWagon wagonTypeObtained2Medium;

	[SerializeField]
	private EnhancementWagon wagonTypeObtained2Hard;

	[field: SerializeField]
	public LocalizedString Resolution3Failed { get; set; }

	protected override void CheckRequirementsForEveryOption()
	{
		if (Train.Instance.HealthComponent.HealthCurrent <= Train.Instance.HealthComponent.HealthMax * percentDamageTaken / 100f)
		{
			base.Option2ButtonUI.interactable = false;
		}
		else
		{
			base.Option2ButtonUI.interactable = true;
		}
	}

	public override void StartEncounter()
	{
		switch (LevelManager.Instance.CurrentLevel.Difficulty.Name)
		{
		case "Easy":
			scrapGained = scrapGainedEasy;
			wagonTypeObtained1 = wagonTypeObtained1Easy;
			wagonTypeObtained2 = wagonTypeObtained2Easy;
			break;
		case "Medium":
			scrapGained = scrapGainedMedium;
			wagonTypeObtained1 = wagonTypeObtained1Medium;
			wagonTypeObtained2 = wagonTypeObtained2Medium;
			break;
		case "Hard":
			scrapGained = scrapGainedHard;
			wagonTypeObtained1 = wagonTypeObtained1Hard;
			wagonTypeObtained2 = wagonTypeObtained2Hard;
			break;
		default:
			Debug.Log("Invalid Difficulty set.");
			break;
		}
		base.Reward1.Arguments = new object[1] { scrapGained * (1f + DifficultyManager.Instance.scrapGain) };
		base.Reward2.Arguments = new object[2] { wagonTypeObtained1.ModuleSlotCount, percentDamageTaken };
		base.Reward3.Arguments = new object[2] { wagonTypeObtained2.ModuleSlotCount, percentDamageTaken };
		base.StartEncounter();
	}

	public override void Option1Chosen()
	{
		ResourceManager.Instance.Scrap.AddValue(scrapGained);
		base.Option1Chosen();
	}

	public override void Option2Chosen()
	{
		Train.Instance.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(Train.Instance, Train.Instance.HealthComponent, 0f - percentDamageTaken, isPercent: true, null, canRes: false, ignoreArmor: true, ignoreImmunity: true, isBurn: false, ignoreGrace: true, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		UpgradeManager.Instance.AddWagon(wagonTypeObtained1);
		base.Option2Chosen();
	}

	public override void Option3Chosen()
	{
		if (Train.Instance.GetModuleByType<ModuleHacking>() != null)
		{
			UpgradeManager.Instance.AddWagon(wagonTypeObtained2);
			base.Option3Chosen();
		}
		else
		{
			base.ResolutionTextUI.text = Resolution3Failed.GetLocalizedString();
			base.RewardsTextUI.text = "";
			base.OnOptionChosen();
		}
	}
}

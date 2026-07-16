using UnityEngine;

[CreateAssetMenu(fileName = "Encounter", menuName = "Encounter/Skimmer")]
public class EncounterSkimmer : Encounter
{
	[Header("Option 1")]
	private float percentDamageTaken1;

	[SerializeField]
	private float percentDamageTaken1Easy;

	[SerializeField]
	private float percentDamageTaken1Medium;

	[SerializeField]
	private float percentDamageTaken1Hard;

	private float scrapGained1;

	[SerializeField]
	private float scrapGained1Easy;

	[SerializeField]
	private float scrapGained1Medium;

	[SerializeField]
	private float scrapGained1Hard;

	[Header("Option 2")]
	private float percentDamageTaken2;

	[SerializeField]
	private float percentDamageTaken2Easy;

	[SerializeField]
	private float percentDamageTaken2Medium;

	[SerializeField]
	private float percentDamageTaken2Hard;

	private float scrapGained2;

	[SerializeField]
	private float scrapGained2Easy;

	[SerializeField]
	private float scrapGained2Medium;

	[SerializeField]
	private float scrapGained2Hard;

	[Header("Option 3")]
	private float percentDamageTaken3;

	[SerializeField]
	private float percentDamageTaken3Easy;

	[SerializeField]
	private float percentDamageTaken3Medium;

	[SerializeField]
	private float percentDamageTaken3Hard;

	private float scrapGained3;

	[SerializeField]
	private float scrapGained3Easy;

	[SerializeField]
	private float scrapGained3Medium;

	[SerializeField]
	private float scrapGained3Hard;

	public override bool EncounterRequirementsMet()
	{
		switch (LevelManager.Instance.CurrentLevel.Difficulty.Name)
		{
		case "Easy":
			percentDamageTaken1 = percentDamageTaken1Easy;
			scrapGained1 = scrapGained1Easy;
			percentDamageTaken2 = percentDamageTaken2Easy;
			scrapGained2 = scrapGained2Easy;
			percentDamageTaken3 = percentDamageTaken3Easy;
			scrapGained3 = scrapGained3Easy;
			break;
		case "Medium":
			percentDamageTaken1 = percentDamageTaken1Medium;
			scrapGained1 = scrapGained1Medium;
			percentDamageTaken2 = percentDamageTaken2Medium;
			scrapGained2 = scrapGained2Medium;
			percentDamageTaken3 = percentDamageTaken3Medium;
			scrapGained3 = scrapGained3Medium;
			break;
		case "Hard":
			percentDamageTaken1 = percentDamageTaken1Hard;
			scrapGained1 = scrapGained1Hard;
			percentDamageTaken2 = percentDamageTaken2Hard;
			scrapGained2 = scrapGained2Hard;
			percentDamageTaken3 = percentDamageTaken3Hard;
			scrapGained3 = scrapGained3Hard;
			break;
		default:
			Debug.Log("Invalid Difficulty set.");
			break;
		}
		base.Option1.Arguments = new object[1] { percentDamageTaken1 };
		base.Option2.Arguments = new object[1] { percentDamageTaken2 };
		base.Option3.Arguments = new object[1] { percentDamageTaken3 };
		base.Reward1.Arguments = new object[1] { scrapGained1 * (1f + DifficultyManager.Instance.scrapGain) };
		base.Reward2.Arguments = new object[1] { scrapGained2 * (1f + DifficultyManager.Instance.scrapGain) };
		base.Reward3.Arguments = new object[1] { scrapGained3 * (1f + DifficultyManager.Instance.scrapGain) };
		if (Train.Instance.HealthComponent.HealthCurrent <= Train.Instance.HealthComponent.HealthMax * percentDamageTaken1 / 100f)
		{
			return false;
		}
		return true;
	}

	protected override void CheckRequirementsForEveryOption()
	{
		base.CheckRequirementsForEveryOption();
		if (Train.Instance.HealthComponent.HealthCurrent <= Train.Instance.HealthComponent.HealthMax * percentDamageTaken2 / 100f)
		{
			base.Option2ButtonUI.interactable = false;
		}
		else
		{
			base.Option2ButtonUI.interactable = true;
		}
		if (Train.Instance.HealthComponent.HealthCurrent <= Train.Instance.HealthComponent.HealthMax * percentDamageTaken3 / 100f)
		{
			base.Option3ButtonUI.interactable = false;
		}
		else
		{
			base.Option3ButtonUI.interactable = true;
		}
	}

	public override void Option1Chosen()
	{
		Train.Instance.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(Train.Instance, Train.Instance.HealthComponent, 0f - percentDamageTaken1, isPercent: true, null, canRes: false, ignoreArmor: true, ignoreImmunity: true, isBurn: false, ignoreGrace: true, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		ResourceManager.Instance.Scrap.AddValue(scrapGained1);
		base.Option1Chosen();
	}

	public override void Option2Chosen()
	{
		Train.Instance.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(Train.Instance, Train.Instance.HealthComponent, 0f - percentDamageTaken2, isPercent: true, null, canRes: false, ignoreArmor: true, ignoreImmunity: true, isBurn: false, ignoreGrace: true, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		ResourceManager.Instance.Scrap.AddValue(scrapGained2);
		base.Option2Chosen();
	}

	public override void Option3Chosen()
	{
		Train.Instance.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(Train.Instance, Train.Instance.HealthComponent, 0f - percentDamageTaken3, isPercent: true, null, canRes: false, ignoreArmor: true, ignoreImmunity: true, isBurn: false, ignoreGrace: true, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		ResourceManager.Instance.Scrap.AddValue(scrapGained3);
		base.Option3Chosen();
	}
}

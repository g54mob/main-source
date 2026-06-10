using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "revenge_data", menuName = "Database/Revenge Objective")]
public class RevengeObjective : SoCustomComparison
{
	public enum SpecialConditions
	{
		mustHaveWindows = 0,
		trackProgressFromAddressQuestion = 1,
		trackProgressFromNameQuestion = 2
	}

	public bool disabled;

	[Range(0f, 10f)]
	[Header("Trait Weighting")]
	public int baseChance;

	[Space(7f)]
	[InfoBox("If enabled: The below HEXACO values will combine for a score of 1 to 10: this will be used to calculate the likihood of this being chosen vs others.", EInfoBoxType.Normal)]
	[Tooltip("Use the below hexaco values to match to personality.")]
	public bool useHEXACO;

	[Range(0f, 10f)]
	[EnableIf("useHEXACO")]
	public int feminineMasculine;

	[EnableIf("useHEXACO")]
	[Tooltip("Honesty-Humility (H): sincere, honest, faithful, loyal, modest/unassuming versus sly, deceitful, greedy, pretentious, hypocritical, boastful, pompous")]
	[Range(0f, 10f)]
	public int humility;

	[Tooltip("Emotionality (E): emotional, oversensitive, sentimental, fearful, anxious, vulnerable versus brave, tough, independent, self-assured, stable")]
	[Range(0f, 10f)]
	[EnableIf("useHEXACO")]
	public int emotionality;

	[Tooltip("Extraversion (X): outgoing, lively, extraverted, sociable, talkative, cheerful, active versus shy, passive, withdrawn, introverted, quiet, reserved")]
	[Range(0f, 10f)]
	[EnableIf("useHEXACO")]
	public int extraversion;

	[Tooltip("Agreeableness (A): patient, tolerant, peaceful, mild, agreeable, lenient, gentle versus ill-tempered, quarrelsome, stubborn, choleric")]
	[Range(0f, 10f)]
	[EnableIf("useHEXACO")]
	public int agreeableness;

	[Tooltip("Conscientiousness (C): organized, disciplined, diligent, careful, thorough, precise versus sloppy, negligent, reckless, lazy, irresponsible, absent-minded")]
	[Range(0f, 10f)]
	[EnableIf("useHEXACO")]
	public int conscientiousness;

	[Tooltip("Openness to Experience (O): intellectual, creative, unconventional, innovative, ironic versus shallow, unimaginative, conventional")]
	[Range(0f, 10f)]
	[EnableIf("useHEXACO")]
	public int creativity;

	[Space(7f)]
	[Tooltip("Use character traits to match to personality.")]
	[InfoBox("If enabled: The below traits will be used to calculate the likihood of this being chosen vs others.", EInfoBoxType.Normal)]
	public bool useTraits;

	public List<ClothesPreset.TraitPickRule> characterTraitsPoster;

	public List<ClothesPreset.TraitPickRule> characterTraitsPurp;

	public List<SpecialConditions> specialConditions;

	[Header("Setup")]
	public string d0Name;

	public string d1Name;

	public string idTargetName;

	public JobPreset.JobTag tag;

	[Space(7f)]
	public InterfaceControls.Icon icon;

	[InfoBox("This can be used to dictate an amount; eg how much damage to cause at a property", EInfoBoxType.Normal)]
	public Vector2 passedNumberRange;

	[Tooltip("Multiplies the rewards based on the above number")]
	public Vector2 rewardMultiplier;

	[Tooltip("Name as part of resolve questions")]
	public string resolveQuestionName;

	public string resolveQuestionNameAlternate;

	[Tooltip("Refers to an answer method within this script that is used to check")]
	[Space(10f)]
	public string answerMethod;

	public float Vandalism(int target, int location, float amount)
	{
		return 0f;
	}

	public float VandalismTrash(int target, int location, float amount)
	{
		return 0f;
	}

	public float VandalismWindow(int target, int location, float amount)
	{
		return 0f;
	}

	public bool Handcuff(int target, int location, float amount)
	{
		return false;
	}

	public bool BeatUp(int target, int location, float amount)
	{
		return false;
	}

	public bool KickDownDoor(int target, int location, float amount)
	{
		return false;
	}

	public bool ManualTrigger(int target, int location, float amount)
	{
		return false;
	}
}

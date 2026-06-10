using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "trait_data", menuName = "Database/Character Trait")]
public class CharacterTrait : SoCustomComparison
{
	public enum PosNeg
	{
		postive = 0,
		neutral = 1,
		negative = 2
	}

	public enum RuleType
	{
		ifAnyOfThese = 0,
		ifAllOfThese = 1,
		ifNoneOfThese = 2,
		ifPartnerAnyOfThese = 3
	}

	[Serializable]
	public class TraitPickRule
	{
		public RuleType rule;

		public List<CharacterTrait> traitList;

		[Tooltip("If this isn't true then it won't be picked for application at all.")]
		[ShowIf("isTrait")]
		public bool mustPassForApplication;

		[Tooltip("If the rules match, then apply this to the base chance...")]
		[Range(-1f, 1f)]
		[ShowIf("isTrait")]
		public float baseChance;

		[Tooltip("Since only one reason is picked, this chance is vs other valid chances...")]
		[Range(0f, 10f)]
		[HideIf("isTrait")]
		public int reasonChance;
	}

	[Serializable]
	public class SpecialItemPlacementRule
	{
		public InteractablePreset preset;

		[Range(0f, 1f)]
		public float chance;
	}

	[Header("Type")]
	[Tooltip("If true this is a trait that can be picked, if false, this is a 'reason'.")]
	public bool isTrait;

	[Tooltip("If true, a 'reason' trait will be immediately picked to accompany this trait")]
	public bool needsReson;

	[Tooltip("If true, this trait requires a partner")]
	public bool requiresPartner;

	[Tooltip("If true, this trait requires NO partner")]
	public bool requiresSingle;

	[Tooltip("If true, this trait requires a citizen to have a home")]
	public bool requiresHome;

	[Tooltip("If true, this trait requires a job")]
	public bool requiresEmployment;

	[Tooltip("If true, this needs a date")]
	public bool needsDate;

	[Tooltip("Appears in the 'random interest' pool when acquiring information on the citizen.")]
	public bool featureInInterestPool;

	[Tooltip("Appears in the 'random affliction' pool when acquiring information on the citizen.")]
	public bool featureInAfflictionPool;

	[EnableIf("needsDate")]
	[Tooltip("This event happened when their age was...")]
	public Vector2 ageDateRange;

	[EnableIf("needsDate")]
	[Tooltip("Use couples anniversary date")]
	public bool useCouplesAnniversary;

	[Tooltip("This is a password (special case)")]
	public bool isPassword;

	[Tooltip("Disabled from being assigned automatically")]
	public bool disabled;

	[Tooltip("Is this considered a positive/neutral/negative trait?")]
	public PosNeg postiveNegative;

	[Header("Pick")]
	[Tooltip("When is this anylised to see if it is picked or not? 0 = first, 2 = last")]
	[EnableIf("isTrait")]
	[Range(0f, 3f)]
	public int pickStage;

	[EnableIf("isTrait")]
	[Tooltip("Chance of assigning this trait completely at random on citizen creation")]
	[Range(0f, 1f)]
	public float primeBaseChance;

	[ReorderableList]
	public List<TraitPickRule> pickRules;

	[Tooltip("Importance of matching this to base HEXACO personality. This is added to the base chance of either prime or secondary.")]
	[Range(0f, 1f)]
	[Header("Match")]
	public float matchChance;

	[Space(5f)]
	public bool useHumilityMatch;

	[Range(0f, 1f)]
	[EnableIf("useHumilityMatch")]
	[Tooltip("Honesty-Humility (H): sincere, honest, faithful, loyal, modest/unassuming versus sly, deceitful, greedy, pretentious, hypocritical, boastful, pompous")]
	public float matchHumility;

	public bool useEmotionalityMatch;

	[EnableIf("useEmotionalityMatch")]
	[Range(0f, 1f)]
	[Tooltip("Emotionality (E): emotional, oversensitive, sentimental, fearful, anxious, vulnerable versus brave, tough, independent, self-assured, stable")]
	public float matchEmotionality;

	public bool useExtraversionMatch;

	[Range(0f, 1f)]
	[Tooltip("Extraversion (X): outgoing, lively, extraverted, sociable, talkative, cheerful, active versus shy, passive, withdrawn, introverted, quiet, reserved")]
	[EnableIf("useExtraversionMatch")]
	public float matchExtraversion;

	public bool useAgreeablenessMatch;

	[Range(0f, 1f)]
	[EnableIf("useAgreeablenessMatch")]
	[Tooltip("Agreeableness (A): patient, tolerant, peaceful, mild, agreeable, lenient, gentle versus ill-tempered, quarrelsome, stubborn, choleric")]
	public float matchAgreeableness;

	public bool useConscientiousnessMatch;

	[Tooltip("Conscientiousness (C): organized, disciplined, diligent, careful, thorough, precise versus sloppy, negligent, reckless, lazy, irresponsible, absent-minded")]
	[Range(0f, 1f)]
	[EnableIf("useConscientiousnessMatch")]
	public float matchConscientiousness;

	public bool useCreativityMatch;

	[EnableIf("useCreativityMatch")]
	[Tooltip("Openness to Experience (O): intellectual, creative, unconventional, innovative, ironic versus shallow, unimaginative, conventional")]
	[Range(0f, 1f)]
	public float matchCreativity;

	public bool useSocietalClassMatch;

	[EnableIf("useSocietalClassMatch")]
	[Range(0f, 1f)]
	public float matchSocietalClass;

	[Tooltip("Honesty-Humility (H): sincere, honest, faithful, loyal, modest/unassuming versus sly, deceitful, greedy, pretentious, hypocritical, boastful, pompous")]
	[Range(-1f, 1f)]
	[Header("Effects")]
	public float effectHumility;

	[Range(-1f, 1f)]
	[Tooltip("Emotionality (E): emotional, oversensitive, sentimental, fearful, anxious, vulnerable versus brave, tough, independent, self-assured, stable")]
	public float effectEmotionality;

	[Range(-1f, 1f)]
	[Tooltip("Extraversion (X): outgoing, lively, extraverted, sociable, talkative, cheerful, active versus shy, passive, withdrawn, introverted, quiet, reserved")]
	public float effectExtraversion;

	[Range(-1f, 1f)]
	[Tooltip("Agreeableness (A): patient, tolerant, peaceful, mild, agreeable, lenient, gentle versus ill-tempered, quarrelsome, stubborn, choleric")]
	public float effectAgreeableness;

	[Range(-1f, 1f)]
	[Tooltip("Conscientiousness (C): organized, disciplined, diligent, careful, thorough, precise versus sloppy, negligent, reckless, lazy, irresponsible, absent-minded")]
	public float effectConscientiousness;

	[Tooltip("Openness to Experience (O): intellectual, creative, unconventional, innovative, ironic versus shallow, unimaginative, conventional")]
	[Range(-1f, 1f)]
	public float effectCreativity;

	[Space(7f)]
	public float maxHealthModifier;

	public float recoveryRateModifier;

	public float combatSkillModifier;

	public float combatHeftModifier;

	public float maxNerveModifier;

	public float breathRecoveryModifier;

	[Tooltip("Honesty-Humility (H): sincere, honest, faithful, loyal, modest/unassuming versus sly, deceitful, greedy, pretentious, hypocritical, boastful, pompous")]
	[MinMaxSlider(0f, 1f)]
	[Header("Limits")]
	public Vector2 limitHumility;

	[Tooltip("Emotionality (E): emotional, oversensitive, sentimental, fearful, anxious, vulnerable versus brave, tough, independent, self-assured, stable")]
	[MinMaxSlider(0f, 1f)]
	public Vector2 limitEmotionality;

	[MinMaxSlider(0f, 1f)]
	[Tooltip("Extraversion (X): outgoing, lively, extraverted, sociable, talkative, cheerful, active versus shy, passive, withdrawn, introverted, quiet, reserved")]
	public Vector2 limitExtraversion;

	[Tooltip("Agreeableness (A): patient, tolerant, peaceful, mild, agreeable, lenient, gentle versus ill-tempered, quarrelsome, stubborn, choleric")]
	[MinMaxSlider(0f, 1f)]
	public Vector2 limitAgreeableness;

	[Tooltip("Conscientiousness (C): organized, disciplined, diligent, careful, thorough, precise versus sloppy, negligent, reckless, lazy, irresponsible, absent-minded")]
	[MinMaxSlider(0f, 1f)]
	public Vector2 limitConscientiousness;

	[Tooltip("Openness to Experience (O): intellectual, creative, unconventional, innovative, ironic versus shallow, unimaginative, conventional")]
	[MinMaxSlider(0f, 1f)]
	public Vector2 limitCreativity;

	[Header("Slang Pool")]
	[Tooltip("Affect the slang usage...")]
	[Range(-1f, 1f)]
	public float slangUsageModifier;

	[ReorderableList]
	[Tooltip("A default slang greeting to be used on anyone in a casual manor")]
	public List<string> slangGreetingDefault;

	[ReorderableList]
	[Tooltip("Similar to above, but male specific (eg. 'bro')")]
	public List<string> slangGreetingMale;

	[Tooltip("Similar to above, but female specific")]
	[ReorderableList]
	public List<string> slangGreetingFemale;

	[Tooltip("Slang greeting for a lover")]
	[ReorderableList]
	public List<string> slangGreetingLover;

	[Tooltip("Slang curse words")]
	[ReorderableList]
	public List<string> slangCurse;

	[ReorderableList]
	[Tooltip("Slang cursing noun word")]
	public List<string> slangCurseNoun;

	[ReorderableList]
	[Tooltip("Slang praising noun word")]
	public List<string> slangPraiseNoun;

	[Header("Culture")]
	[Tooltip("Does this affect the number of books this person should have?")]
	public int preferredBookCountModifier;

	public int sightingLimitMemoryModifier;
}

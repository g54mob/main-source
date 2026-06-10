using System.Collections.Generic;
using UnityEngine;

public class ExperienceEffectsDemo : MonoBehaviour
{
	[Header("Demo Configuration")]
	public bool runDemoOnStart = true;

	[Header("Test Parameters")]
	[SerializeField]
	private float fishCatchExperienceAdditive = 25f;

	[SerializeField]
	private float fishCatchExperienceMultiplier = 1.5f;

	[SerializeField]
	private float pondExperienceAdditive = 100f;

	[SerializeField]
	private float pondExperienceMultiplier = 1.2f;

	[SerializeField]
	private float experienceGainMultiplier = 2f;

	private void Start()
	{
		if (runDemoOnStart)
		{
			RunExperienceEffectsDemo();
		}
	}

	[ContextMenu("Run Experience Effects Demo")]
	public void RunExperienceEffectsDemo()
	{
		Debug.Log("===== EXPERIENCE EFFECTS DEMO =====");
		Debug.Log("Demonstrating the 5 new SkillBonusType effect types for experience modifiers:");
		Debug.Log("");
		Debug.Log("--- FISH CATCH EXPERIENCE EFFECTS ---");
		int num = 100;
		float num2 = (float)num + fishCatchExperienceAdditive;
		Debug.Log($"add_fish_catch_experience: {num} + {fishCatchExperienceAdditive} = {num2}");
		float num3 = num2 * fishCatchExperienceMultiplier;
		Debug.Log($"mult_fish_catch_experience: {num2} * {fishCatchExperienceMultiplier} = {num3}");
		float num4 = num3 * experienceGainMultiplier;
		Debug.Log($"mult_experience_gain (global): {num3} * {experienceGainMultiplier} = {num4}");
		Debug.Log($"Final fish XP: {num} -> {Mathf.RoundToInt(num4)} ({(num4 / (float)num - 1f) * 100f:F1}% increase)");
		Debug.Log("");
		Debug.Log("--- POND EXPERIENCE EFFECTS ---");
		int num5 = 500;
		float num6 = (float)num5 + pondExperienceAdditive;
		Debug.Log($"add_pond_experience: {num5} + {pondExperienceAdditive} = {num6}");
		float num7 = num6 * pondExperienceMultiplier;
		Debug.Log($"mult_pond_experience: {num6} * {pondExperienceMultiplier} = {num7}");
		float num8 = num7 * experienceGainMultiplier;
		Debug.Log($"mult_experience_gain (global): {num7} * {experienceGainMultiplier} = {num8}");
		Debug.Log($"Final pond XP: {num5} -> {Mathf.RoundToInt(num8)} ({(num8 / (float)num5 - 1f) * 100f:F1}% increase)");
		Debug.Log("");
		Debug.Log("--- SKILL CONFIGURATION EXAMPLES ---");
		Debug.Log("To use these effects, create skills with these SkillBonusType values:");
		Debug.Log($"• {SkillBonusType.add_fish_catch_experience}: Adds flat XP to fish catches");
		Debug.Log($"• {SkillBonusType.mult_fish_catch_experience}: Multiplies fish catch XP");
		Debug.Log($"• {SkillBonusType.add_pond_experience}: Adds flat XP to pond fishing sessions");
		Debug.Log($"• {SkillBonusType.mult_pond_experience}: Multiplies pond session XP");
		Debug.Log($"• {SkillBonusType.mult_experience_gain}: Universal XP multiplier for both fish and ponds");
		Debug.Log("");
		Debug.Log("--- IMPLEMENTATION DETAILS ---");
		Debug.Log("The experience calculation flows:");
		Debug.Log("1. FishLogManager.LogFish() applies fish-specific bonuses when a fish is caught");
		Debug.Log("2. GameManager.AddXpToCurrentZone() applies pond-specific bonuses at end of fishing session");
		Debug.Log("3. Both systems apply the global experience multiplier for maximum flexibility");
		Debug.Log("4. PlayerStats calculates and caches all multipliers for efficient access");
		Debug.Log("");
		Debug.Log("===== DEMO COMPLETE =====");
		Debug.Log("All 5 new experience effect types are now available for use in skill trees!");
	}

	[ContextMenu("Simulate PlayerStats Calculation")]
	public void SimulatePlayerStatsCalculation()
	{
		Debug.Log("===== SIMULATING PLAYERSTATS CALCULATION =====");
		Debug.Log("This shows how PlayerStats would calculate experience bonuses from skills:");
		Debug.Log("");
		Dictionary<SkillBonusType, float> dictionary = new Dictionary<SkillBonusType, float>
		{
			{
				SkillBonusType.add_fish_catch_experience,
				fishCatchExperienceAdditive
			},
			{
				SkillBonusType.add_pond_experience,
				pondExperienceAdditive
			}
		};
		Dictionary<SkillBonusType, float> dictionary2 = new Dictionary<SkillBonusType, float>
		{
			{
				SkillBonusType.mult_fish_catch_experience,
				fishCatchExperienceMultiplier
			},
			{
				SkillBonusType.mult_pond_experience,
				pondExperienceMultiplier
			},
			{
				SkillBonusType.mult_experience_gain,
				experienceGainMultiplier
			}
		};
		float valueOrDefault = dictionary.GetValueOrDefault(SkillBonusType.add_fish_catch_experience);
		float valueOrDefault2 = dictionary2.GetValueOrDefault(SkillBonusType.mult_fish_catch_experience, 1f);
		float valueOrDefault3 = dictionary.GetValueOrDefault(SkillBonusType.add_pond_experience);
		float valueOrDefault4 = dictionary2.GetValueOrDefault(SkillBonusType.mult_pond_experience, 1f);
		float valueOrDefault5 = dictionary2.GetValueOrDefault(SkillBonusType.mult_experience_gain, 1f);
		Debug.Log("Calculated final stats:");
		Debug.Log($"• FishCatchExperienceAdditive: {valueOrDefault}");
		Debug.Log($"• FishCatchExperienceMultiplier: {valueOrDefault2}");
		Debug.Log($"• PondExperienceAdditive: {valueOrDefault3}");
		Debug.Log($"• PondExperienceMultiplier: {valueOrDefault4}");
		Debug.Log($"• ExperienceGainMultiplier: {valueOrDefault5}");
		Debug.Log("");
		Debug.Log("These values would then be stored as properties on PlayerStats for efficient access.");
		Debug.Log("===== SIMULATION COMPLETE =====");
	}
}

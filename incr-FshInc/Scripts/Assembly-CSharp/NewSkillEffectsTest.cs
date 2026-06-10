using System;
using UnityEngine;

public class NewSkillEffectsTest : MonoBehaviour
{
	[ContextMenu("Test New Skill Effect Types")]
	public void TestNewSkillEffectTypes()
	{
		Debug.Log("[NewSkillEffectsTest] ===== TESTING NEW SKILL EFFECT TYPES =====");
		TestEnumValues();
		TestPlayerStatsProperties();
		TestSkillCalculationIntegration();
		Debug.Log("[NewSkillEffectsTest] ===== ALL TESTS COMPLETED =====");
	}

	private void TestEnumValues()
	{
		Debug.Log("[NewSkillEffectsTest] Test 1: Enum Values");
		try
		{
			SkillBonusType skillBonusType = SkillBonusType.add_faster_catching;
			SkillBonusType skillBonusType2 = SkillBonusType.add_perfect_catch_time;
			SkillBonusType skillBonusType3 = SkillBonusType.add_perfect_start_progress;
			Debug.Log($"[NewSkillEffectsTest] ✓ New enum values exist: {skillBonusType}, {skillBonusType2}, {skillBonusType3}");
		}
		catch (Exception ex)
		{
			Debug.LogError("[NewSkillEffectsTest] ✗ Enum test failed: " + ex.Message);
		}
	}

	private void TestPlayerStatsProperties()
	{
		Debug.Log("[NewSkillEffectsTest] Test 2: PlayerStats Properties");
		if (PlayerStats.Instance == null)
		{
			Debug.LogWarning("[NewSkillEffectsTest] PlayerStats.Instance is null - cannot test properties");
			return;
		}
		try
		{
			float fasterCatchingBonus = PlayerStats.Instance.FasterCatchingBonus;
			float perfectCatchTimeWindow = PlayerStats.Instance.PerfectCatchTimeWindow;
			float perfectStartProgressBonus = PlayerStats.Instance.PerfectStartProgressBonus;
			Debug.Log("[NewSkillEffectsTest] ✓ PlayerStats properties accessible:");
			Debug.Log($"  - FasterCatchingBonus: {fasterCatchingBonus}");
			Debug.Log($"  - PerfectCatchTimeWindow: {perfectCatchTimeWindow}");
			Debug.Log($"  - PerfectStartProgressBonus: {perfectStartProgressBonus}");
			float baseFasterCatching = PlayerStats.Instance.baseFasterCatching;
			float basePerfectCatchTime = PlayerStats.Instance.basePerfectCatchTime;
			float basePerfectStartProgress = PlayerStats.Instance.basePerfectStartProgress;
			Debug.Log("[NewSkillEffectsTest] ✓ Base values accessible:");
			Debug.Log($"  - baseFasterCatching: {baseFasterCatching}");
			Debug.Log($"  - basePerfectCatchTime: {basePerfectCatchTime}");
			Debug.Log($"  - basePerfectStartProgress: {basePerfectStartProgress}");
		}
		catch (Exception ex)
		{
			Debug.LogError("[NewSkillEffectsTest] ✗ PlayerStats properties test failed: " + ex.Message);
		}
	}

	private void TestSkillCalculationIntegration()
	{
		Debug.Log("[NewSkillEffectsTest] Test 3: Skill Calculation Integration");
		if (PlayerStats.Instance == null)
		{
			Debug.LogWarning("[NewSkillEffectsTest] PlayerStats.Instance is null - cannot test skill calculations");
			return;
		}
		try
		{
			Debug.Log("[NewSkillEffectsTest] ✓ Testing skill calculation system integration...");
			PlayerStats.Instance.RecalculateAllStats();
			float fasterCatchingBonus = PlayerStats.Instance.FasterCatchingBonus;
			float perfectCatchTimeWindow = PlayerStats.Instance.PerfectCatchTimeWindow;
			float perfectStartProgressBonus = PlayerStats.Instance.PerfectStartProgressBonus;
			Debug.Log("[NewSkillEffectsTest] ✓ Properties after recalculation:");
			Debug.Log($"  - FasterCatchingBonus: {fasterCatchingBonus}");
			Debug.Log($"  - PerfectCatchTimeWindow: {perfectCatchTimeWindow}");
			Debug.Log($"  - PerfectStartProgressBonus: {perfectStartProgressBonus}");
			Debug.Log("[NewSkillEffectsTest] ✓ Skill calculation integration test passed!");
		}
		catch (Exception ex)
		{
			Debug.LogError("[NewSkillEffectsTest] ✗ Skill calculation integration test failed: " + ex.Message);
		}
	}

	[ContextMenu("Test Perfect Catch Logic")]
	public void TestPerfectCatchLogic()
	{
		Debug.Log("[NewSkillEffectsTest] Testing Perfect Catch Logic...");
		float time = Time.time;
		float num = Time.time + 0.1f;
		float num2 = 0.2f;
		float num3 = num - time;
		bool flag = num3 <= num2;
		Debug.Log("[NewSkillEffectsTest] Perfect catch test scenario:");
		Debug.Log($"  - Time since bite: {num3}s");
		Debug.Log($"  - Perfect window: {num2}s");
		Debug.Log($"  - Would be perfect: {flag}");
	}
}

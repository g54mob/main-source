using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using UnityEngine;

public class GameUtility
{
	private static GameUtility _instance;

	public const float ExpBase = 2.718f;

	private readonly HashSet<ItemType> reusableItemHashSet;

	private readonly List<EntityId> reusableEntityIdList;

	private readonly ItemList reusableItemList = new ItemList();

	private static readonly List<ItemType> PreallocatedItemList = new List<ItemType>();

	private static readonly System.Random rng = new System.Random();

	private static readonly ItemEqualityComparer PreallocatedItemEqualityComparer = new ItemEqualityComparer();

	public readonly HashSet<ItemType> emptyItemHashSet = new HashSet<ItemType>();

	public static List<Upgrade> reusableUpgradeList = new List<Upgrade>();

	private readonly List<StringBuilder> stringBuilderPool = new List<StringBuilder>();

	private static double timerStart;

	private static double lastBenchmark;

	public static bool GlobalDebugFlag;

	public static double MaxDouble;

	public static GameUtility Instance => _instance;

	public static ItemEqualityComparer SharedEqualityComparer => PreallocatedItemEqualityComparer;

	public GameUtility()
	{
		_instance = this;
		reusableEntityIdList = new List<EntityId>();
		reusableItemHashSet = ItemHashSet();
		MaxDouble = Math.Pow(10.0, 300.0);
		for (int i = 0; i < 64; i++)
		{
			PreallocatedItemList.Add((ItemType)i);
		}
	}

	[Conditional("UNITY_EDITOR")]
	public static void SetEditorName(GameObject go, string name)
	{
		go.name = name;
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogEventSystem(string msg)
	{
		UnityEngine.Debug.Log("EVENTS: " + msg);
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogStartup(string msg)
	{
		UnityEngine.Debug.Log("STARTUP: " + msg);
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogMinigame(string msg)
	{
		UnityEngine.Debug.Log("MINIGAME: " + msg);
	}

	[Conditional("UNITY_EDITOR")]
	public static void LogTrading(string msg)
	{
		UnityEngine.Debug.Log("TRADING: " + msg);
	}

	[Conditional("UNITY_EDITOR")]
	public static void LogTooltip(string msg)
	{
		UnityEngine.Debug.Log("TOOLTIP: " + msg);
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogDynamicTooltip(string msg)
	{
		UnityEngine.Debug.Log("TOOLTIP: " + msg);
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogAchievements(string msg)
	{
		UnityEngine.Debug.Log("ACHIEVEMENTS: " + msg);
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogVisual(string msg)
	{
		MenuManager.Instance.townStatsPanel.debugText.text = msg;
	}

	[Conditional("UNITY_EDITOR")]
	public static void LogEditorWarning(string msg)
	{
		UnityEngine.Debug.LogWarning("EDITOR: " + msg);
	}

	[Conditional("UNITY_EDITOR")]
	public static void LogEditorError(string msg)
	{
		UnityEngine.Debug.LogError("EDITOR: " + msg);
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogItemValues(string msg)
	{
		UnityEngine.Debug.LogError("ITEM VALUES: " + msg);
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogRequirements(string msg)
	{
		UnityEngine.Debug.LogError("REQUIREMENTS: " + msg);
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogSelection(string msg)
	{
		UnityEngine.Debug.LogError("SELECTION: " + msg);
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogNavigation(string msg)
	{
		UnityEngine.Debug.LogError("MENU NAV: " + msg);
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogLevels(string msg)
	{
		UnityEngine.Debug.LogError("LEVELS: " + msg);
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogTime(string msg)
	{
		UnityEngine.Debug.LogError("TIME: " + msg);
	}

	[Conditional("UNITY_EDITOR")]
	public static void LogAutoTrade(string msg)
	{
		UnityEngine.Debug.LogError("AUTOTRADE: " + msg);
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogSimulation(string s)
	{
		UnityEngine.Debug.Log("Simulation: " + s);
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogSkill(string s)
	{
		UnityEngine.Debug.Log("SKILL: " + s);
	}

	[Conditional("UNITY_EDITOR")]
	public static void LogEditor(string s, bool highlight = false, UnityEngine.Object contextObject = null)
	{
		string text = "EDITOR: " + s;
		if (highlight)
		{
			UnityEngine.Debug.Log("<color=yellow>" + text + "</color>", contextObject);
		}
		else
		{
			UnityEngine.Debug.Log(text, contextObject);
		}
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogPanelLayout(string s)
	{
		UnityEngine.Debug.Log("LAYOUT: " + s);
	}

	[Conditional("UNITY_EDITORx")]
	public static void LogLayout(string s)
	{
		UnityEngine.Debug.Log("LAYOUT: " + s);
	}

	public static float ClampedCurve(float t)
	{
		return 1f - (Mathf.Cos(t * MathF.PI * 2f) * 0.5f + 0.5f);
	}

	public static T RandomItemFromList<T>(List<T> list)
	{
		if (list != null)
		{
			int count = list.Count;
			return count switch
			{
				0 => default(T), 
				1 => list[0], 
				_ => list[rng.Next(0, count)], 
			};
		}
		return default(T);
	}

	public static List<EntityId> GetFreshEntityIdList()
	{
		Instance.reusableEntityIdList.Clear();
		return Instance.reusableEntityIdList;
	}

	public static ItemList GetFreshItemList()
	{
		Instance.reusableItemList.Clear();
		return Instance.reusableItemList;
	}

	public static HashSet<ItemType> GetFreshItemHashSet()
	{
		Instance.reusableItemHashSet.Clear();
		return Instance.reusableItemHashSet;
	}

	public static HashSet<ItemType> ItemHashSet()
	{
		HashSet<ItemType> hashSet = new HashSet<ItemType>(PreallocatedItemList, PreallocatedItemEqualityComparer);
		hashSet.Clear();
		return hashSet;
	}

	public static int[] ClonedArray(int[] source)
	{
		int[] array = new int[source.Length];
		Array.Copy(source, array, array.Length);
		return array;
	}

	public static bool IsNotZero(double value)
	{
		if (!(value < -5E-324))
		{
			return value > double.Epsilon;
		}
		return true;
	}

	public static bool IsNearlyZero(double value)
	{
		if (value > -5E-324)
		{
			return value < double.Epsilon;
		}
		return false;
	}

	public static bool IsNearlyZero(float value)
	{
		if (value > -1E-45f)
		{
			return value < float.Epsilon;
		}
		return false;
	}

	public static bool IsNotZero(float value)
	{
		if (!(value < -1E-45f))
		{
			return value > float.Epsilon;
		}
		return true;
	}

	public static bool NotEquals(double a, double b)
	{
		return Math.Abs(a - b) > double.Epsilon;
	}

	public static bool NotEquals(float a, float b)
	{
		return Mathf.Abs(a - b) > float.Epsilon;
	}

	public static bool NearlyEquals(double a, double b)
	{
		return Math.Abs(a - b) < 0.0010000000474974513;
	}

	public static bool NearlyEquals(float a, float b)
	{
		return Mathf.Abs(a - b) < 0.001f;
	}

	public static float ParsedFloat(string floatAsString)
	{
		if (floatAsString == null)
		{
			return 0f;
		}
		string text = floatAsString.Replace(',', '.');
		if (float.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		UnityEngine.Debug.LogError("Unable to parse float property: " + text);
		return 0f;
	}

	public static bool IsFlagSet(int summaryValue, int flag)
	{
		return (summaryValue & (1 << flag)) > 0;
	}

	public static void SetFlag(ref byte summaryValue, int flag)
	{
		summaryValue |= (byte)(1 << flag);
	}

	public static void SetFlag(ref int summaryValue, int flag)
	{
		summaryValue |= 1 << flag;
	}

	public static void SetFlag(ref int summaryValue, int flag, bool nextState)
	{
		if (nextState)
		{
			summaryValue |= 1 << flag;
		}
		else
		{
			summaryValue &= ~(1 << flag);
		}
	}

	public static void SetShiftedFlag(ref int summaryValue, int flag)
	{
		summaryValue |= flag;
	}

	public static void SetShiftedFlag(ref int summaryValue, int flag, bool nextState)
	{
		if (nextState)
		{
			summaryValue |= flag;
		}
		else
		{
			summaryValue &= ~flag;
		}
	}

	public static bool IsShiftedFlagSet(int summaryValue, int flag)
	{
		return (summaryValue & flag) > 0;
	}

	public static float ScaledResearchTime(float initialValue, int level)
	{
		return ExponentGrowth(initialValue, level, 1f);
	}

	public static float AdditiveExponentGrowth(float initialValue, int level, float growthRate, float growthAdditive)
	{
		return initialValue * Mathf.Pow(2.718f, (float)level * growthRate) + growthAdditive * (float)level;
	}

	public static float ExponentGrowth(float initialValue, int level, float growthPercent)
	{
		return initialValue * Mathf.Pow(1f + growthPercent, level);
	}

	public static double ScaledHundredValue(double initialValue, int level)
	{
		return initialValue * Math.Pow(100.0, level);
	}

	public static double ScaledTenValue(double initialValue, int level)
	{
		double x = 10.0;
		return initialValue * Math.Pow(x, level);
	}

	public static double ScaledValue(double initialValue, int level)
	{
		double x = 3.162;
		return initialValue * Math.Pow(x, level);
	}

	public static double TruncateToSignificantDigits(double value, int digits)
	{
		if (IsNearlyZero(value))
		{
			return 0.0;
		}
		if (digits <= 0)
		{
			return value;
		}
		bool num = value < 0.0;
		double y = Math.Ceiling(Math.Log10(Math.Abs(value))) - (double)digits;
		double num2 = Math.Pow(10.0, y);
		double num3 = Math.Round(value / num2) * num2;
		if (num)
		{
			num3 *= -1.0;
		}
		return num3;
	}

	public static float RoundToIntOrSigDigits(double value, int digits)
	{
		if (IsNearlyZero(value))
		{
			return 0f;
		}
		bool num = value < 0.0;
		value = Math.Abs(value);
		float num2 = (float)Math.Pow(10.0, Math.Floor(Math.Log10(Math.Abs(value))) + 1.0);
		float num3 = (float)((double)num2 * Math.Round(value / (double)num2, digits));
		if (num)
		{
			num3 *= -1f;
		}
		return num3;
	}

	public static float RoundToIntOrSigDigitsLegacy(float value, int digits)
	{
		if (IsNearlyZero(value))
		{
			return 0f;
		}
		decimal num = (decimal)Math.Pow(10.0, Math.Floor(Math.Log10(Math.Abs(value))) + 1.0);
		return (float)(num * Math.Round((decimal)value / num, digits));
	}

	public static float RoundToIntOrSigDigits(float value)
	{
		if (value < 10f)
		{
			return RoundToIntOrSigDigits(value, 1);
		}
		if (value < 1000f)
		{
			return RoundToIntOrSigDigits(value, 2);
		}
		return RoundToIntOrSigDigits(value, 3);
	}

	[Conditional("UNITY_EDITOR")]
	public static void LogGameMetadataErrors()
	{
		_ = GameManager.Instance;
		List<EntityId> list = Data.Instance.defaultDisplayCategories[BuildCategoryType.Building];
		foreach (BuildingType value3 in Enum.GetValues(typeof(BuildingType)))
		{
			if (value3 != BuildingType.None && Data.Instance.defaultBuildingDefs.TryGetValue(value3, out var value) && value.enabled)
			{
				EntityId item = EntityId.FromBuilding(value3);
				if (!list.Contains(item))
				{
					UnityEngine.Debug.LogError("Did not find " + value3.ToString() + " in visible buildings");
				}
			}
		}
		List<EntityId> list2 = Data.Instance.defaultDisplayCategories[BuildCategoryType.Item];
		foreach (ItemType value4 in Enum.GetValues(typeof(ItemType)))
		{
			if (value4 != ItemType.None && Item.IsDefaultPhysicalItem(value4) && Data.Instance.defaultItemDefs.TryGetValue(value4, out var value2) && value2.enabled)
			{
				EntityId item2 = EntityId.FromItem(value4);
				if (!list2.Contains(item2))
				{
					UnityEngine.Debug.LogError("Did not find " + value4.ToString() + " in visible items, might not be in loadItemDefs");
				}
			}
		}
	}

	public static void CopyDefList<T>(List<T> sourceList, ref List<T> targetList)
	{
		if (sourceList != null)
		{
			if (targetList == null)
			{
				targetList = new List<T>();
			}
			targetList.AddRange(sourceList);
		}
	}

	public static void CopyDefDict<T, U>(Dictionary<T, U> sourceList, Dictionary<T, U> targetList)
	{
		if (sourceList == null || targetList == null)
		{
			return;
		}
		foreach (KeyValuePair<T, U> source in sourceList)
		{
			targetList[source.Key] = source.Value;
		}
	}

	public static void OnPooledObjectGet<T>(T go) where T : MonoBehaviour
	{
		go.gameObject.SetActive(value: true);
	}

	public static void OnPooledObjectReleased<T>(T go) where T : MonoBehaviour
	{
		go.gameObject.SetActive(value: false);
	}

	public static void Shuffle<T>(List<T> list)
	{
		int num = list.Count;
		while (num > 1)
		{
			num--;
			int index = UnityEngine.Random.Range(0, num + 1);
			T value = list[index];
			list[index] = list[num];
			list[num] = value;
		}
	}

	public static float SmoothLerpTo(float original, float target)
	{
		float num = Mathf.Lerp(original, target, 0.1f);
		if (target - num < 0.01f)
		{
			return target;
		}
		return num;
	}

	public static void SetLayerRecursively(GameObject go, int nextLayer)
	{
		go.layer = nextLayer;
		foreach (Transform item in go.transform)
		{
			SetLayerRecursively(item.gameObject, nextLayer);
		}
	}

	[Conditional("UNITY_EDITOR")]
	public static void BeginTimeTracking()
	{
	}

	[Conditional("UNITY_EDITORx")]
	public static void ShowBenchmark(string label)
	{
	}

	public static EntityLevel PrimaryReward(List<EntityLevel> rewards)
	{
		foreach (EntityType item in Data.Instance.entityTypeHierarchy)
		{
			foreach (EntityLevel reward in rewards)
			{
				if (reward.entityId.type == item)
				{
					return reward.GetCopy();
				}
			}
		}
		if (rewards.Count > 0)
		{
			foreach (EntityLevel reward2 in rewards)
			{
				_ = reward2;
			}
		}
		return EntityLevel.None;
	}

	public static int BonusForHappinessQuintile(int quintile)
	{
		if (quintile >= 4)
		{
			return 5;
		}
		return quintile;
	}

	public static int HappinessQuintileForSupplyRate(float rate)
	{
		if (rate >= 0.99f)
		{
			return 4;
		}
		if (rate >= 0.75f)
		{
			return 3;
		}
		if (rate >= 0.5f)
		{
			return 2;
		}
		if (rate >= 0.1f)
		{
			return 1;
		}
		return 0;
	}

	public static bool BoolWithProbability(float p)
	{
		return UnityEngine.Random.Range(0f, 1f) <= p;
	}

	public static float TryCeilToInt(float f)
	{
		if (f < 2.1474836E+09f)
		{
			return Mathf.Ceil(f);
		}
		return f;
	}

	public static float Poly(float level, float constant, float linear, float x2, float x3 = 0f)
	{
		return constant + linear * level + x2 * Mathf.Pow(level, 2f) + x3 * Mathf.Pow(level, 3f);
	}

	public static double Poly(double level, float constant, float linear, float x2, float x3 = 0f)
	{
		return (double)constant + (double)linear * level + (double)x2 * Math.Pow(level, 2.0) + (double)x3 * Math.Pow(level, 3.0);
	}

	public static OverrideState CycledOverride(OverrideState current, bool isParentSpecified)
	{
		switch (current)
		{
		case OverrideState.Off:
			return OverrideState.None;
		case OverrideState.On:
			if (isParentSpecified)
			{
				return OverrideState.Off;
			}
			return OverrideState.None;
		default:
			return OverrideState.On;
		}
	}

	public static StatePriority CycledPriority(StatePriority current, bool isParentSpecified)
	{
		switch (current)
		{
		case StatePriority.Regular:
			return StatePriority.None;
		case StatePriority.None:
			return StatePriority.High;
		case StatePriority.High:
			return StatePriority.Highest;
		case StatePriority.Highest:
			return StatePriority.Lowest;
		case StatePriority.Lowest:
			return StatePriority.Low;
		default:
			if (isParentSpecified)
			{
				return StatePriority.Regular;
			}
			return StatePriority.None;
		}
	}

	public static int RoundToInt(double value)
	{
		if (value > 3.4028234663852886E+38)
		{
			value = 3.4028234663852886E+38;
		}
		else if (value < -3.4028234663852886E+38)
		{
			value = -3.4028234663852886E+38;
		}
		return Mathf.RoundToInt(Convert.ToSingle(value));
	}

	public static float AsTruncatedFloat(double value)
	{
		if (value > 3.4028234663852886E+38)
		{
			return float.MaxValue;
		}
		if (value < -3.4028234663852886E+38)
		{
			return float.MinValue;
		}
		return (float)value;
	}

	public static int AsTruncatedInt(double value)
	{
		if (value > 2147483647.0)
		{
			return int.MaxValue;
		}
		if (value < -2147483648.0)
		{
			return int.MinValue;
		}
		return (int)value;
	}

	public static float AsFloat(double value)
	{
		if (value > 3.4028234663852886E+38)
		{
			return float.MaxValue;
		}
		if (value < -3.4028234663852886E+38)
		{
			return float.MinValue;
		}
		return (float)value;
	}

	public static float RoundToFloat(double value)
	{
		if (value > 3.4028234663852886E+38)
		{
			value = 3.4028234663852886E+38;
		}
		else if (value < -3.4028234663852886E+38)
		{
			value = -3.4028234663852886E+38;
		}
		return Mathf.Round(Convert.ToSingle(value));
	}

	public static StringBuilder GetPooledStringBuilder()
	{
		List<StringBuilder> list = _instance.stringBuilderPool;
		if (list.Count > 0)
		{
			StringBuilder stringBuilder = list[list.Count - 1];
			list.Remove(stringBuilder);
			return stringBuilder;
		}
		return new StringBuilder();
	}

	public static void ReturnToPool(StringBuilder sb)
	{
		sb.Clear();
		_instance.stringBuilderPool.Add(sb);
	}

	public static string ResultOfPooledStringBuilder(StringBuilder sb)
	{
		string result = sb.ToString();
		sb.Clear();
		_instance.stringBuilderPool.Add(sb);
		return result;
	}

	public static void CopyBuildingRequirements(BuildingType t, List<RequirementId> target)
	{
		if (!Crafting.buildingCache.TryGetValue(t, out var value))
		{
			return;
		}
		foreach (RequirementId requirement in value.requirements)
		{
			target.Add(requirement);
		}
	}

	public static double Lerp(double a, double b, float t)
	{
		return a + (b - a) * (double)Mathf.Clamp01(t);
	}

	public static double Billions(int numBillions)
	{
		return (double)numBillions * 1000000000.0;
	}

	public static double Millions(int numMillions)
	{
		return (double)numMillions * 1000000.0;
	}

	public static double RoundedDoubleFromFloat(float f)
	{
		return Math.Round((double)f * 1000.0) / 1000.0;
	}

	public static OverrideState OverrideStateForPauseState(PauseState pauseState)
	{
		return pauseState switch
		{
			PauseState.Play => OverrideState.Off, 
			PauseState.Paused => OverrideState.On, 
			_ => OverrideState.None, 
		};
	}

	public static void PlatformDebug(string s)
	{
		UnityEngine.Debug.Log("PLATFORM: " + s);
	}

	public static double CappedDouble(double i)
	{
		if (i >= MaxDouble)
		{
			return MaxDouble;
		}
		return i;
	}
}

using UnityEngine;

namespace MalbersAnimations
{
	public enum StatOption
	{
		None = 0,
		[InspectorName("Value/Add[+]")]
		AddValue = 1,
		[InspectorName("Value/Set")]
		SetValue = 2,
		[InspectorName("Value/Substract[-]")]
		SubstractValue = 3,
		[InspectorName("Max Value/Modify")]
		ModifyMaxValue = 4,
		[InspectorName("Max Value/Set")]
		SetMaxValue = 5,
		[InspectorName("Degenerate/Value")]
		Degenerate = 6,
		[InspectorName("Degenerate/Stop")]
		DegenerateOff = 7,
		[InspectorName("Regenerate/Value")]
		Regenerate = 8,
		[InspectorName("Regenerate/Stop")]
		RegenerateOff = 9,
		[InspectorName("Value/Reset")]
		Reset = 10,
		[InspectorName("Value/Reduce by percent")]
		ReduceByPercent = 11,
		[InspectorName("Value/Increase by percent")]
		IncreaseByPercent = 12,
		[InspectorName("Multiplier/Set")]
		Multiplier = 13,
		[InspectorName("Value/Reset to Max")]
		ResetToMax = 14,
		[InspectorName("Value/Reset to Min")]
		ResetToMin = 15,
		Enable = 16,
		Inmune = 17,
		[InspectorName("Regenerate/Start")]
		RegenerateOn = 18,
		[InspectorName("Degenerate/Start")]
		DegenerateOn = 19,
		[InspectorName("Regenerate/Default")]
		RestoreRegeneration = 20,
		[InspectorName("Degenerate/Default")]
		RestoreDegeneration = 21,
		[InspectorName("Value/Default")]
		RestoreValue = 22,
		[InspectorName("Max Value/Default")]
		RestoreMax = 23,
		[InspectorName("Min Value/Default")]
		RestoreMin = 24,
		[InspectorName("Multiplier/Default")]
		RestoreMultiplier = 25,
		[InspectorName("Multiplier/Modify")]
		MultiplierModify = 26
	}
}

using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Buildable/Rejuvenator Properties")]
public class RejuvenatorProperties : ScriptableObject
{
	[Serializable]
	public struct ModuleRejuvenator
	{
		public ModuleProperties Module;

		public VitalType Vital;
	}

	[Tooltip("Activity when agent is rejuvenating.")]
	public Activity Activity = Activity.Working;

	[Tooltip("Vital to rejuvenate")]
	public VitalType Vital = VitalType.Rest;

	[Tooltip("Time it takes to rejuvenate.")]
	public Day.E_DayTime Time = Day.E_DayTime.Night;

	[Tooltip("Minimum time it takes to rejuvenate.")]
	public float MinimumTime = 30f;

	public ModuleRejuvenator[] ModuleRejuvenators;
}

using System;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.GameModifiers
{
	[InitializeOnGameStarted]
	public abstract class AtmosphereEquilibriumGameModifierNode : GameModifierNode
	{
		[Header("day atmosphere config")]
		public int minValue;

		public int maxValue;

		public AnimationCurve dayProgression;

		private sbyte _lastValue;

		public string effectType { get; private set; }

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void TimeController_HourChanged(object sender, EventArgs e)
		{
		}

		private bool HasChanges()
		{
			return false;
		}

		protected AtmosphereEquilibriumGameModifierNode(string effectType)
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		private sbyte GetValueForHour(int hour)
		{
			return 0;
		}

		private sbyte GetEffectiveModifierValue(string targetType)
		{
			return 0;
		}

		internal static sbyte GetEffectiveModifierForKey(string effectType)
		{
			return 0;
		}
	}
}

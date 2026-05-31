using System;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class DailyRefresh
	{
		[HideInInspector]
		public bool Enabled = true;

		public EAgentStatistics _statToUpdate;

		public EAgentStatistics _modifierStat;

		public bool UseModifierMultiplicator;

		[ShowIf("UseModifierMultiplicator")]
		[AllowNesting]
		public EAgentStatistics _modifierMultiplicatorStat;

		[Tooltip("Use the modifier's value range instead of the value, for a random value.")]
		public bool _useModifierRange;

		public bool _useDifficultyModifier;

		public StringKey _difficultyModifier;
	}
}

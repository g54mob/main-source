using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.Core
{
	[CreateAssetMenu(menuName = "CTS/Statistics/List")]
	public class StatList : ScriptableObject
	{
		[SerializeField]
		private List<StatisticData> _stats = new List<StatisticData>();

		[SerializeField]
		private SerializableDictionary<StringKey<StatisticData>, StatModifierData> _modifiers = new SerializableDictionary<StringKey<StatisticData>, StatModifierData>();

		public ReadOnlyList<StatisticData> Statistics => _stats;

		public ReadOnlyDictionary<StringKey<StatisticData>, StatModifierData> Modifiers => _modifiers;
	}
}

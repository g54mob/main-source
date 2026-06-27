using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Restory.Data.Base
{
	[CreateAssetMenu(menuName = "Restory/GUI/Rewired Ruleset Tags Dictionary", fileName = "RewiredRulesetTagsDictionary", order = 21)]
	public class RewiredRuleSetTagsDictionary : SerializedScriptableObject
	{
		[OdinSerialize]
		private Dictionary<RewiredLayoutRuleSet, string> tagsDictionary = new Dictionary<RewiredLayoutRuleSet, string>();

		public bool ContainsKey(RewiredLayoutRuleSet key)
		{
			return tagsDictionary.ContainsKey(key);
		}

		public bool ContainsValue(string value)
		{
			return tagsDictionary.ContainsValue(value);
		}

		public bool TryGetValue(RewiredLayoutRuleSet key, out string value)
		{
			return tagsDictionary.TryGetValue(key, out value);
		}
	}
}

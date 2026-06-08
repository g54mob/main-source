using System;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Atn
{
	[Serializable]
	public sealed class PredictionMode
	{
		internal class AltAndContextMap : Dictionary<ATNConfig, BitSet>
		{
			public AltAndContextMap()
				: base((IEqualityComparer<ATNConfig>)AltAndContextConfigEqualityComparator.Instance)
			{
			}
		}

		private sealed class AltAndContextConfigEqualityComparator : EqualityComparer<ATNConfig>
		{
			public static readonly AltAndContextConfigEqualityComparator Instance = new AltAndContextConfigEqualityComparator();

			private AltAndContextConfigEqualityComparator()
			{
			}

			public override int GetHashCode(ATNConfig o)
			{
				return MurmurHash.Finish(MurmurHash.Update(MurmurHash.Update(MurmurHash.Initialize(7), o.state.stateNumber), o.context), 2);
			}

			public override bool Equals(ATNConfig a, ATNConfig b)
			{
				if (a == b)
				{
					return true;
				}
				if (a == null || b == null)
				{
					return false;
				}
				if (a.state.stateNumber == b.state.stateNumber)
				{
					return a.context.Equals(b.context);
				}
				return false;
			}
		}

		public static readonly PredictionMode SLL = new PredictionMode();

		public static readonly PredictionMode LL = new PredictionMode();

		public static readonly PredictionMode LL_EXACT_AMBIG_DETECTION = new PredictionMode();

		public static bool HasSLLConflictTerminatingPrediction(PredictionMode mode, ATNConfigSet configSet)
		{
			if (AllConfigsInRuleStopStates(configSet.configs))
			{
				return true;
			}
			if (mode == SLL && configSet.hasSemanticContext)
			{
				ATNConfigSet aTNConfigSet = new ATNConfigSet();
				foreach (ATNConfig config in configSet.configs)
				{
					aTNConfigSet.Add(new ATNConfig(config, SemanticContext.NONE));
				}
				configSet = aTNConfigSet;
			}
			if (HasConflictingAltSet(GetConflictingAltSubsets(configSet.configs)))
			{
				return !HasStateAssociatedWithOneAlt(configSet.configs);
			}
			return false;
		}

		public static bool HasConfigInRuleStopState(IEnumerable<ATNConfig> configs)
		{
			foreach (ATNConfig config in configs)
			{
				if (config.state is RuleStopState)
				{
					return true;
				}
			}
			return false;
		}

		public static bool AllConfigsInRuleStopStates(IEnumerable<ATNConfig> configs)
		{
			foreach (ATNConfig config in configs)
			{
				if (!(config.state is RuleStopState))
				{
					return false;
				}
			}
			return true;
		}

		public static int ResolvesToJustOneViableAlt(IEnumerable<BitSet> altsets)
		{
			return GetSingleViableAlt(altsets);
		}

		public static bool AllSubsetsConflict(IEnumerable<BitSet> altsets)
		{
			return !HasNonConflictingAltSet(altsets);
		}

		public static bool HasNonConflictingAltSet(IEnumerable<BitSet> altsets)
		{
			foreach (BitSet altset in altsets)
			{
				if (altset.Cardinality() == 1)
				{
					return true;
				}
			}
			return false;
		}

		public static bool HasConflictingAltSet(IEnumerable<BitSet> altsets)
		{
			foreach (BitSet altset in altsets)
			{
				if (altset.Cardinality() > 1)
				{
					return true;
				}
			}
			return false;
		}

		public static bool AllSubsetsEqual(IEnumerable<BitSet> altsets)
		{
			IEnumerator<BitSet> enumerator = altsets.GetEnumerator();
			enumerator.MoveNext();
			BitSet current = enumerator.Current;
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.Equals(current))
				{
					return false;
				}
			}
			return true;
		}

		public static int GetUniqueAlt(IEnumerable<BitSet> altsets)
		{
			BitSet alts = GetAlts(altsets);
			if (alts.Cardinality() == 1)
			{
				return alts.NextSetBit(0);
			}
			return 0;
		}

		public static BitSet GetAlts(IEnumerable<BitSet> altsets)
		{
			BitSet bitSet = new BitSet();
			foreach (BitSet altset in altsets)
			{
				bitSet.Or(altset);
			}
			return bitSet;
		}

		[return: NotNull]
		public static ICollection<BitSet> GetConflictingAltSubsets(IEnumerable<ATNConfig> configs)
		{
			AltAndContextMap altAndContextMap = new AltAndContextMap();
			foreach (ATNConfig config in configs)
			{
				if (!altAndContextMap.TryGetValue(config, out var value))
				{
					value = (altAndContextMap[config] = new BitSet());
				}
				value.Set(config.alt);
			}
			return altAndContextMap.Values;
		}

		[return: NotNull]
		public static IDictionary<ATNState, BitSet> GetStateToAltMap(IEnumerable<ATNConfig> configs)
		{
			IDictionary<ATNState, BitSet> dictionary = new Dictionary<ATNState, BitSet>();
			foreach (ATNConfig config in configs)
			{
				if (!dictionary.TryGetValue(config.state, out var value))
				{
					value = new BitSet();
					dictionary[config.state] = value;
				}
				value.Set(config.alt);
			}
			return dictionary;
		}

		public static bool HasStateAssociatedWithOneAlt(IEnumerable<ATNConfig> configs)
		{
			foreach (BitSet value in GetStateToAltMap(configs).Values)
			{
				if (value.Cardinality() == 1)
				{
					return true;
				}
			}
			return false;
		}

		public static int GetSingleViableAlt(IEnumerable<BitSet> altsets)
		{
			BitSet bitSet = new BitSet();
			foreach (BitSet altset in altsets)
			{
				int index = altset.NextSetBit(0);
				bitSet.Set(index);
				if (bitSet.Cardinality() > 1)
				{
					return 0;
				}
			}
			return bitSet.NextSetBit(0);
		}
	}
}

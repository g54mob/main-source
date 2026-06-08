using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Atn
{
	public class ATNConfigSet
	{
		protected bool readOnly;

		public ConfigHashSet configLookup;

		public ArrayList<ATNConfig> configs = new ArrayList<ATNConfig>(7);

		public int uniqueAlt;

		public BitSet conflictingAlts;

		public bool hasSemanticContext;

		public bool dipsIntoOuterContext;

		public readonly bool fullCtx;

		private int cachedHashCode = -1;

		public List<ATNConfig> Elements => configs;

		public int Count => configs.Count;

		public bool Empty => configs.Count == 0;

		public bool IsReadOnly
		{
			get
			{
				return readOnly;
			}
			set
			{
				readOnly = value;
				configLookup = null;
			}
		}

		public ATNConfigSet(bool fullCtx)
		{
			configLookup = new ConfigHashSet();
			this.fullCtx = fullCtx;
		}

		public ATNConfigSet()
			: this(fullCtx: true)
		{
		}

		public ATNConfigSet(ATNConfigSet old)
			: this(old.fullCtx)
		{
			AddAll(old.configs);
			uniqueAlt = old.uniqueAlt;
			conflictingAlts = old.conflictingAlts;
			hasSemanticContext = old.hasSemanticContext;
			dipsIntoOuterContext = old.dipsIntoOuterContext;
		}

		public bool Add(ATNConfig config)
		{
			return Add(config, null);
		}

		public bool Add(ATNConfig config, MergeCache mergeCache)
		{
			if (readOnly)
			{
				throw new Exception("This set is readonly");
			}
			if (config.semanticContext != SemanticContext.NONE)
			{
				hasSemanticContext = true;
			}
			if (config.OuterContextDepth > 0)
			{
				dipsIntoOuterContext = true;
			}
			ATNConfig orAdd = configLookup.GetOrAdd(config);
			if (orAdd == config)
			{
				cachedHashCode = -1;
				configs.Add(config);
				return true;
			}
			bool rootIsWildcard = !fullCtx;
			PredictionContext context = PredictionContext.Merge(orAdd.context, config.context, rootIsWildcard, mergeCache);
			orAdd.reachesIntoOuterContext = Math.Max(orAdd.reachesIntoOuterContext, config.reachesIntoOuterContext);
			if (config.IsPrecedenceFilterSuppressed)
			{
				orAdd.SetPrecedenceFilterSuppressed(value: true);
			}
			orAdd.context = context;
			return true;
		}

		public HashSet<ATNState> GetStates()
		{
			HashSet<ATNState> hashSet = new HashSet<ATNState>();
			foreach (ATNConfig config in configs)
			{
				hashSet.Add(config.state);
			}
			return hashSet;
		}

		public BitSet GetAlts()
		{
			BitSet bitSet = new BitSet();
			foreach (ATNConfig config in configs)
			{
				bitSet.Set(config.alt);
			}
			return bitSet;
		}

		public List<SemanticContext> GetPredicates()
		{
			List<SemanticContext> list = new List<SemanticContext>();
			foreach (ATNConfig config in configs)
			{
				if (config.semanticContext != SemanticContext.NONE)
				{
					list.Add(config.semanticContext);
				}
			}
			return list;
		}

		public ATNConfig Get(int i)
		{
			return configs[i];
		}

		public void OptimizeConfigs(ATNSimulator interpreter)
		{
			if (readOnly)
			{
				throw new Exception("This set is readonly");
			}
			if (configLookup.Count == 0)
			{
				return;
			}
			foreach (ATNConfig config in configs)
			{
				config.context = interpreter.getCachedContext(config.context);
			}
		}

		public bool AddAll(ICollection<ATNConfig> coll)
		{
			foreach (ATNConfig item in coll)
			{
				Add(item);
			}
			return false;
		}

		public override bool Equals(object o)
		{
			if (o == this)
			{
				return true;
			}
			if (!(o is ATNConfigSet))
			{
				return false;
			}
			ATNConfigSet aTNConfigSet = (ATNConfigSet)o;
			if (configs != null && configs.Equals(aTNConfigSet.configs) && fullCtx == aTNConfigSet.fullCtx && uniqueAlt == aTNConfigSet.uniqueAlt && conflictingAlts == aTNConfigSet.conflictingAlts && hasSemanticContext == aTNConfigSet.hasSemanticContext)
			{
				return dipsIntoOuterContext == aTNConfigSet.dipsIntoOuterContext;
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (IsReadOnly)
			{
				if (cachedHashCode == -1)
				{
					cachedHashCode = configs.GetHashCode();
				}
				return cachedHashCode;
			}
			return configs.GetHashCode();
		}

		public bool Contains(object o)
		{
			if (configLookup == null)
			{
				throw new Exception("This method is not implemented for readonly sets.");
			}
			return configLookup.ContainsKey((ATNConfig)o);
		}

		public void Clear()
		{
			if (readOnly)
			{
				throw new Exception("This set is readonly");
			}
			configs.Clear();
			cachedHashCode = -1;
			configLookup.Clear();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append('[');
			List<ATNConfig> elements = Elements;
			if (elements.Count > 0)
			{
				foreach (ATNConfig item in elements)
				{
					stringBuilder.Append(item.ToString());
					stringBuilder.Append(", ");
				}
				stringBuilder.Length -= 2;
			}
			stringBuilder.Append(']');
			if (hasSemanticContext)
			{
				stringBuilder.Append(",hasSemanticContext=").Append(hasSemanticContext);
			}
			if (uniqueAlt != 0)
			{
				stringBuilder.Append(",uniqueAlt=").Append(uniqueAlt);
			}
			if (conflictingAlts != null)
			{
				stringBuilder.Append(",conflictingAlts=").Append(conflictingAlts);
			}
			if (dipsIntoOuterContext)
			{
				stringBuilder.Append(",dipsIntoOuterContext");
			}
			return stringBuilder.ToString();
		}
	}
}

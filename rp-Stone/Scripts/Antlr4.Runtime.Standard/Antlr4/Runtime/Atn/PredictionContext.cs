using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Atn
{
	public abstract class PredictionContext
	{
		public sealed class IdentityHashMap : Dictionary<PredictionContext, PredictionContext>
		{
			public IdentityHashMap()
				: base((IEqualityComparer<PredictionContext>)IdentityEqualityComparator.Instance)
			{
			}
		}

		public sealed class IdentityEqualityComparator : EqualityComparer<PredictionContext>
		{
			public static readonly IdentityEqualityComparator Instance = new IdentityEqualityComparator();

			private IdentityEqualityComparator()
			{
			}

			public override int GetHashCode(PredictionContext obj)
			{
				return obj.GetHashCode();
			}

			public override bool Equals(PredictionContext a, PredictionContext b)
			{
				return a == b;
			}
		}

		public static readonly int EMPTY_RETURN_STATE = int.MaxValue;

		public static readonly EmptyPredictionContext EMPTY = new EmptyPredictionContext();

		private static readonly int INITIAL_HASH = 1;

		private readonly int cachedHashCode;

		public abstract int Size { get; }

		public virtual bool IsEmpty => this == EMPTY;

		public virtual bool HasEmptyPath => GetReturnState(Size - 1) == EMPTY_RETURN_STATE;

		protected internal static int CalculateEmptyHashCode()
		{
			return MurmurHash.Finish(MurmurHash.Initialize(INITIAL_HASH), 0);
		}

		protected internal static int CalculateHashCode(PredictionContext parent, int returnState)
		{
			return MurmurHash.Finish(MurmurHash.Update(MurmurHash.Update(MurmurHash.Initialize(INITIAL_HASH), parent), returnState), 2);
		}

		protected internal static int CalculateHashCode(PredictionContext[] parents, int[] returnStates)
		{
			int hash = MurmurHash.Initialize(INITIAL_HASH);
			foreach (PredictionContext value in parents)
			{
				hash = MurmurHash.Update(hash, value);
			}
			foreach (int value2 in returnStates)
			{
				hash = MurmurHash.Update(hash, value2);
			}
			return MurmurHash.Finish(hash, 2 * parents.Length);
		}

		protected internal PredictionContext(int cachedHashCode)
		{
			this.cachedHashCode = cachedHashCode;
		}

		public static PredictionContext FromRuleContext(ATN atn, RuleContext outerContext)
		{
			if (outerContext == null)
			{
				outerContext = ParserRuleContext.EMPTY;
			}
			if (outerContext.Parent == null || outerContext == ParserRuleContext.EMPTY)
			{
				return EMPTY;
			}
			PredictionContext predictionContext = FromRuleContext(atn, outerContext.Parent);
			RuleTransition ruleTransition = (RuleTransition)atn.states[outerContext.invokingState].Transition(0);
			return predictionContext.GetChild(ruleTransition.followState.stateNumber);
		}

		public abstract PredictionContext GetParent(int index);

		public abstract int GetReturnState(int index);

		public sealed override int GetHashCode()
		{
			return cachedHashCode;
		}

		internal static PredictionContext Merge(PredictionContext a, PredictionContext b, bool rootIsWildcard, MergeCache mergeCache)
		{
			if (a == b || a.Equals(b))
			{
				return a;
			}
			if (a is SingletonPredictionContext && b is SingletonPredictionContext)
			{
				return MergeSingletons((SingletonPredictionContext)a, (SingletonPredictionContext)b, rootIsWildcard, mergeCache);
			}
			if (rootIsWildcard)
			{
				if (a is EmptyPredictionContext)
				{
					return a;
				}
				if (b is EmptyPredictionContext)
				{
					return b;
				}
			}
			if (a is SingletonPredictionContext)
			{
				a = new ArrayPredictionContext((SingletonPredictionContext)a);
			}
			if (b is SingletonPredictionContext)
			{
				b = new ArrayPredictionContext((SingletonPredictionContext)b);
			}
			return MergeArrays((ArrayPredictionContext)a, (ArrayPredictionContext)b, rootIsWildcard, mergeCache);
		}

		public static PredictionContext MergeSingletons(SingletonPredictionContext a, SingletonPredictionContext b, bool rootIsWildcard, MergeCache mergeCache)
		{
			if (mergeCache != null)
			{
				PredictionContext predictionContext = mergeCache.Get(a, b);
				if (predictionContext != null)
				{
					return predictionContext;
				}
				predictionContext = mergeCache.Get(b, a);
				if (predictionContext != null)
				{
					return predictionContext;
				}
			}
			PredictionContext predictionContext2 = MergeRoot(a, b, rootIsWildcard);
			if (predictionContext2 != null)
			{
				mergeCache?.Put(a, b, predictionContext2);
				return predictionContext2;
			}
			if (a.returnState == b.returnState)
			{
				PredictionContext predictionContext3 = Merge(a.parent, b.parent, rootIsWildcard, mergeCache);
				if (predictionContext3 == a.parent)
				{
					return a;
				}
				if (predictionContext3 == b.parent)
				{
					return b;
				}
				PredictionContext predictionContext4 = SingletonPredictionContext.Create(predictionContext3, a.returnState);
				mergeCache?.Put(a, b, predictionContext4);
				return predictionContext4;
			}
			int[] array = new int[2];
			PredictionContext[] array2 = new PredictionContext[2];
			PredictionContext predictionContext5 = null;
			if (a == b || (a.parent != null && a.parent.Equals(b.parent)))
			{
				predictionContext5 = a.parent;
			}
			PredictionContext predictionContext6;
			if (predictionContext5 != null)
			{
				if (a.returnState > b.returnState)
				{
					array[0] = b.returnState;
					array[1] = a.returnState;
				}
				else
				{
					array[0] = a.returnState;
					array[1] = b.returnState;
				}
				array2[0] = predictionContext5;
				array2[1] = predictionContext5;
				predictionContext6 = new ArrayPredictionContext(array2, array);
				mergeCache?.Put(a, b, predictionContext6);
				return predictionContext6;
			}
			if (a.returnState > b.returnState)
			{
				array[0] = b.returnState;
				array[1] = a.returnState;
				array2[0] = b.parent;
				array2[1] = a.parent;
			}
			else
			{
				array[0] = a.returnState;
				array[1] = b.returnState;
				array2[0] = a.parent;
				array2[1] = b.parent;
			}
			predictionContext6 = new ArrayPredictionContext(array2, array);
			mergeCache?.Put(a, b, predictionContext6);
			return predictionContext6;
		}

		public static PredictionContext MergeArrays(ArrayPredictionContext a, ArrayPredictionContext b, bool rootIsWildcard, MergeCache mergeCache)
		{
			if (mergeCache != null)
			{
				PredictionContext predictionContext = mergeCache.Get(a, b);
				if (predictionContext != null)
				{
					return predictionContext;
				}
				predictionContext = mergeCache.Get(b, a);
				if (predictionContext != null)
				{
					return predictionContext;
				}
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int[] array = new int[a.returnStates.Length + b.returnStates.Length];
			PredictionContext[] array2 = new PredictionContext[a.returnStates.Length + b.returnStates.Length];
			while (num < a.returnStates.Length && num2 < b.returnStates.Length)
			{
				PredictionContext predictionContext2 = a.parents[num];
				PredictionContext predictionContext3 = b.parents[num2];
				if (a.returnStates[num] == b.returnStates[num2])
				{
					int num4 = a.returnStates[num];
					bool num5 = num4 == EMPTY_RETURN_STATE && predictionContext2 == null && predictionContext3 == null;
					bool flag = predictionContext2 != null && predictionContext3 != null && predictionContext2.Equals(predictionContext3);
					if (num5 || flag)
					{
						array2[num3] = predictionContext2;
						array[num3] = num4;
					}
					else
					{
						PredictionContext predictionContext4 = Merge(predictionContext2, predictionContext3, rootIsWildcard, mergeCache);
						array2[num3] = predictionContext4;
						array[num3] = num4;
					}
					num++;
					num2++;
				}
				else if (a.returnStates[num] < b.returnStates[num2])
				{
					array2[num3] = predictionContext2;
					array[num3] = a.returnStates[num];
					num++;
				}
				else
				{
					array2[num3] = predictionContext3;
					array[num3] = b.returnStates[num2];
					num2++;
				}
				num3++;
			}
			if (num < a.returnStates.Length)
			{
				for (int i = num; i < a.returnStates.Length; i++)
				{
					array2[num3] = a.parents[i];
					array[num3] = a.returnStates[i];
					num3++;
				}
			}
			else
			{
				for (int j = num2; j < b.returnStates.Length; j++)
				{
					array2[num3] = b.parents[j];
					array[num3] = b.returnStates[j];
					num3++;
				}
			}
			if (num3 < array2.Length)
			{
				if (num3 == 1)
				{
					PredictionContext predictionContext5 = SingletonPredictionContext.Create(array2[0], array[0]);
					mergeCache?.Put(a, b, predictionContext5);
					return predictionContext5;
				}
				array2 = Arrays.CopyOf(array2, num3);
				array = Arrays.CopyOf(array, num3);
			}
			PredictionContext predictionContext6 = new ArrayPredictionContext(array2, array);
			if (predictionContext6.Equals(a))
			{
				mergeCache?.Put(a, b, a);
				return a;
			}
			if (predictionContext6.Equals(b))
			{
				mergeCache?.Put(a, b, b);
				return b;
			}
			CombineCommonParents(array2);
			mergeCache?.Put(a, b, predictionContext6);
			return predictionContext6;
		}

		protected static void CombineCommonParents(PredictionContext[] parents)
		{
			Dictionary<PredictionContext, PredictionContext> dictionary = new Dictionary<PredictionContext, PredictionContext>();
			foreach (PredictionContext predictionContext in parents)
			{
				if (predictionContext != null && !dictionary.ContainsKey(predictionContext))
				{
					dictionary.Put(predictionContext, predictionContext);
				}
			}
			for (int j = 0; j < parents.Length; j++)
			{
				PredictionContext predictionContext2 = parents[j];
				if (predictionContext2 != null)
				{
					parents[j] = dictionary.Get(predictionContext2);
				}
			}
		}

		public static PredictionContext MergeRoot(SingletonPredictionContext a, SingletonPredictionContext b, bool rootIsWildcard)
		{
			if (rootIsWildcard)
			{
				if (a == EMPTY)
				{
					return EMPTY;
				}
				if (b == EMPTY)
				{
					return EMPTY;
				}
			}
			else
			{
				if (a == EMPTY && b == EMPTY)
				{
					return EMPTY;
				}
				if (a == EMPTY)
				{
					int[] returnStates = new int[2] { b.returnState, EMPTY_RETURN_STATE };
					return new ArrayPredictionContext(new PredictionContext[2] { b.parent, null }, returnStates);
				}
				if (b == EMPTY)
				{
					int[] returnStates2 = new int[2] { a.returnState, EMPTY_RETURN_STATE };
					return new ArrayPredictionContext(new PredictionContext[2] { a.parent, null }, returnStates2);
				}
			}
			return null;
		}

		public static PredictionContext GetCachedContext(PredictionContext context, PredictionContextCache contextCache, IdentityHashMap visited)
		{
			if (context.IsEmpty)
			{
				return context;
			}
			PredictionContext predictionContext = visited.Get(context);
			if (predictionContext != null)
			{
				return predictionContext;
			}
			predictionContext = contextCache.Get(context);
			if (predictionContext != null)
			{
				visited.Put(context, predictionContext);
				return predictionContext;
			}
			bool flag = false;
			PredictionContext[] array = new PredictionContext[context.Size];
			for (int i = 0; i < array.Length; i++)
			{
				PredictionContext cachedContext = GetCachedContext(context.GetParent(i), contextCache, visited);
				if (!flag && cachedContext == context.GetParent(i))
				{
					continue;
				}
				if (!flag)
				{
					array = new PredictionContext[context.Size];
					for (int j = 0; j < context.Size; j++)
					{
						array[j] = context.GetParent(j);
					}
					flag = true;
				}
				array[i] = cachedContext;
			}
			if (!flag)
			{
				contextCache.Add(context);
				visited.Put(context, context);
				return context;
			}
			PredictionContext predictionContext2;
			if (array.Length == 0)
			{
				predictionContext2 = EMPTY;
			}
			else if (array.Length == 1)
			{
				predictionContext2 = SingletonPredictionContext.Create(array[0], context.GetReturnState(0));
			}
			else
			{
				ArrayPredictionContext arrayPredictionContext = (ArrayPredictionContext)context;
				predictionContext2 = new ArrayPredictionContext(array, arrayPredictionContext.returnStates);
			}
			contextCache.Add(predictionContext2);
			visited.Put(predictionContext2, predictionContext2);
			visited.Put(context, predictionContext2);
			return predictionContext2;
		}

		public virtual PredictionContext GetChild(int returnState)
		{
			return new SingletonPredictionContext(this, returnState);
		}

		public virtual string[] ToStrings(IRecognizer recognizer, int currentState)
		{
			return ToStrings(recognizer, EMPTY, currentState);
		}

		public virtual string[] ToStrings(IRecognizer recognizer, PredictionContext stop, int currentState)
		{
			List<string> list = new List<string>();
			int num = 0;
			while (true)
			{
				int num2 = 0;
				bool flag = true;
				PredictionContext predictionContext = this;
				int index = currentState;
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("[");
				while (true)
				{
					if (!predictionContext.IsEmpty && predictionContext != stop)
					{
						int num3 = 0;
						if (predictionContext.Size > 0)
						{
							int i;
							for (i = 1; 1 << i < predictionContext.Size; i++)
							{
							}
							int num4 = (1 << i) - 1;
							num3 = (num >> num2) & num4;
							flag &= num3 >= predictionContext.Size - 1;
							if (num3 >= predictionContext.Size)
							{
								break;
							}
							num2 += i;
						}
						if (recognizer != null)
						{
							if (stringBuilder.Length > 1)
							{
								stringBuilder.Append(' ');
							}
							ATNState aTNState = recognizer.Atn.states[index];
							string value = recognizer.RuleNames[aTNState.ruleIndex];
							stringBuilder.Append(value);
						}
						else if (predictionContext.GetReturnState(num3) != EMPTY_RETURN_STATE && !predictionContext.IsEmpty)
						{
							if (stringBuilder.Length > 1)
							{
								stringBuilder.Append(' ');
							}
							stringBuilder.Append(predictionContext.GetReturnState(num3));
						}
						index = predictionContext.GetReturnState(num3);
						predictionContext = predictionContext.GetParent(num3);
						continue;
					}
					stringBuilder.Append("]");
					list.Add(stringBuilder.ToString());
					if (!flag)
					{
						break;
					}
					return list.ToArray();
				}
				num++;
			}
		}
	}
}

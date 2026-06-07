using System;
using System.Collections.Generic;

namespace Rewired.Glyphs
{
	public static class GlyphTools
	{
		private static class Action2DHelper
		{
			private enum Result
			{
				GoNext = 0,
				Quit = 1
			}

			private static readonly FastList<bool> _usedAction1Aems;

			private static readonly FastList<bool> _usedAction2Aems;

			private static FastList<ActionElementMap> _action1Aems;

			private static FastList<ActionElementMap> _action2Aems;

			private static ControllerElementType[] _controllerElementTypeOrder;

			private static List<Pair<ActionElementMapPair>> _results;

			private static int _resultsRemainingCount;

			private static Func<Result>[] __steps_axisPriority;

			private static Func<Result>[] __steps_buttonPriority;

			private static Func<Result>[] steps_axisPriority => null;

			private static Func<Result>[] steps_buttonPriority => null;

			private static ControllerElementType elementTypePriority => default(ControllerElementType);

			public static int GetActionElementMaps(FastList<ActionElementMap> action1Aems, FastList<ActionElementMap> action2Aems, ControllerElementType[] controllerElementTypeOrder, List<Pair<ActionElementMapPair>> results, ref int resultsRemainingCount)
			{
				return 0;
			}

			private static Result GetCompleteFullAxisPairs()
			{
				return default(Result);
			}

			private static Result GetMixedFullAxisAndSplitAxisPairs()
			{
				return default(Result);
			}

			private static Result GetCompleteSplitAxisQuadSets()
			{
				return default(Result);
			}

			private static Result GetCompleteButtonQuadSets()
			{
				return default(Result);
			}

			private static Result GetMixedFullAxisAndButtonPairs()
			{
				return default(Result);
			}

			private static Result GetMixedSplitAxisAndButtonPairs()
			{
				return default(Result);
			}

			private static Result GetRemaining()
			{
				return default(Result);
			}

			private static Func<Result>[] GetSteps()
			{
				return null;
			}
		}

		private sealed class DefaultControllerMapCache
		{
			private struct Selector
			{
				public readonly int playerId;

				public readonly ControllerIdentifier controllerIdentifier;

				public readonly int mapCategoryId;

				public readonly int layoutId;

				public Selector(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
				{
					this.playerId = 0;
					this.controllerIdentifier = default(ControllerIdentifier);
					this.mapCategoryId = 0;
					this.layoutId = 0;
				}
			}

			private class Entry
			{
				public readonly Selector selector;

				public bool loaded;

				public ControllerMap controllerMap;

				public int lastTouchedFrame;

				public Entry(Selector selector)
				{
				}

				public void Clear()
				{
				}
			}

			private static DefaultControllerMapCache s_instance;

			private readonly List<Entry> _cache;

			public static DefaultControllerMapCache instance => null;

			private DefaultControllerMapCache()
			{
			}

			private void OnRewiredShutDown()
			{
			}

			public ControllerMap GetControllerMap(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				return null;
			}

			private int IndexOf(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				return 0;
			}

			private static bool IsEqualOrNextFrame(int a, int b)
			{
				return false;
			}
		}

		private sealed class FastList<T>
		{
			private const int minCapacity = 2;

			public T[] Array;

			public int Count;

			public int Capacity;

			public FastList(int startingCapacity)
			{
			}

			public void Add(T item)
			{
			}

			public void RemoveAt(int index)
			{
			}

			public void Expand(int size)
			{
			}

			public void SetCount(int size)
			{
			}

			public void ReplaceFrom(IList<T> source)
			{
			}

			public void ReplaceFrom(FastList<T> source)
			{
			}

			public void Clear()
			{
			}

			private static uint RoundUpToPowerOf2(uint value)
			{
				return 0u;
			}

			private static bool IsPowerOfTwo(uint x)
			{
				return false;
			}
		}

		private sealed class ObjectPool<T> where T : class
		{
			private readonly List<T> _objects;

			private readonly Func<T> _createDelegate;

			private readonly Action<T> _onReturnDelegate;

			public ObjectPool(Func<T> createDelegate, Action<T> onReturnDelegate)
			{
			}

			public T Get()
			{
				return null;
			}

			public void Return(T obj)
			{
			}
		}

		private struct ControllerInfo
		{
			public ControllerType type;

			public int controllerId;

			public ControllerInfo(ControllerType type, int controllerId)
			{
				this.type = default(ControllerType);
				this.controllerId = 0;
			}
		}

		private static readonly ObjectPool<FastList<ActionElementMap>> aemFastListPool;

		private static readonly ObjectPool<List<ActionElementMapPair>> aemPairListPool;

		private static readonly ObjectPool<List<Pair<ActionElementMapPair>>> aemPair2dListPool;

		private static readonly ObjectPool<FastList<bool>> boolFastListPool;

		private static readonly ObjectPool<FastList<ControllerInfo>> controllerInfoFastListPool;

		private static readonly List<ActionElementMap> GetElementMapsWithAction_tempAems;

		private static Predicate<ActionElementMap> __defaultGetElementMapsWithActionisAllowedHandler;

		private static Predicate<ActionElementMap> defaultGetElementMapsWithActionisAllowedHandler => null;

		public static bool TryGetActionElementMaps(int playerId, int actionId, AxisRange actionRange, ControllerElementGlyphSelectorOptions options, Predicate<ActionElementMap> isAemAllowedHandlerOverride, out ActionElementMap aemResult1, out ActionElementMap aemResult2)
		{
			aemResult1 = null;
			aemResult2 = null;
			return false;
		}

		public static bool TryGetActionElementMaps(InputAction action, AxisRange actionRange, List<ActionElementMap> aems, out ActionElementMap aemResult1, out ActionElementMap aemResult2)
		{
			aemResult1 = null;
			aemResult2 = null;
			return false;
		}

		public static bool TryGetActionElementMaps(InputAction action, AxisRange actionRange, List<ActionElementMap> aems, ControllerElementGlyphSelectorOptions options, out ActionElementMap aemResult1, out ActionElementMap aemResult2)
		{
			aemResult1 = null;
			aemResult2 = null;
			return false;
		}

		public static bool TryGetActionElementMaps(int playerId, int actionId, int actionId2, ControllerElementGlyphSelectorOptions options, Predicate<ActionElementMap> isAemAllowedHandlerOverride, out ActionElementMapPair aemResult1, out ActionElementMapPair aemResult2)
		{
			aemResult1 = default(ActionElementMapPair);
			aemResult2 = default(ActionElementMapPair);
			return false;
		}

		public static int GetActionElementMaps(int playerId, int actionId, AxisRange actionRange, ControllerElementGlyphSelectorOptions options, Predicate<ActionElementMap> isAemAllowedHandlerOverride, List<ActionElementMapPair> results)
		{
			return 0;
		}

		public static int GetActionElementMaps(int playerId, int actionId, int actionId2, ControllerElementGlyphSelectorOptions options, Predicate<ActionElementMap> isAemAllowedHandlerOverride, List<Pair<ActionElementMapPair>> results)
		{
			return 0;
		}

		public static ActionElementMap FindFirstFullAxisBinding(List<ActionElementMap> actionElementMaps)
		{
			return null;
		}

		public static ActionElementMap FindFirstFullAxisBinding(List<ActionElementMap> actionElementMaps, ControllerElementGlyphSelectorOptions options)
		{
			return null;
		}

		public static int FindFullAxisBindings(List<ActionElementMap> actionElementMaps, List<ActionElementMapPair> results)
		{
			return 0;
		}

		public static int FindFullAxisBindings(List<ActionElementMap> actionElementMaps, ControllerElementGlyphSelectorOptions options, List<ActionElementMapPair> results)
		{
			return 0;
		}

		public static ActionElementMap FindFirstBinding(List<ActionElementMap> actionElementMaps, AxisRange actionRange)
		{
			return null;
		}

		public static ActionElementMap FindFirstBinding(List<ActionElementMap> actionElementMaps, ControllerElementGlyphSelectorOptions options, AxisRange actionRange)
		{
			return null;
		}

		public static int FindBindings(List<ActionElementMap> actionElementMaps, AxisRange actionRange, List<ActionElementMapPair> results)
		{
			return 0;
		}

		public static int FindBindings(List<ActionElementMap> actionElementMaps, AxisRange actionRange, ControllerElementGlyphSelectorOptions options, List<ActionElementMapPair> results)
		{
			return 0;
		}

		public static int FindSplitAxisBindingPairs(List<ActionElementMap> actionElementMaps, List<ActionElementMapPair> results)
		{
			return 0;
		}

		public static int FindSplitAxisBindingPairs(List<ActionElementMap> actionElementMaps, ControllerElementGlyphSelectorOptions options, List<ActionElementMapPair> results)
		{
			return 0;
		}

		public static bool FindFirstSplitAxisBindingPair(List<ActionElementMap> actionElementMaps, out ActionElementMap negativeAem, out ActionElementMap positiveAem)
		{
			negativeAem = null;
			positiveAem = null;
			return false;
		}

		public static bool FindFirstSplitAxisBindingPair(List<ActionElementMap> actionElementMaps, ControllerElementGlyphSelectorOptions options, out ActionElementMap negativeAem, out ActionElementMap positiveAem)
		{
			negativeAem = null;
			positiveAem = null;
			return false;
		}

		public static int FindButtonBindingPairs(List<ActionElementMap> actionElementMaps, List<ActionElementMapPair> results)
		{
			return 0;
		}

		public static int FindButtonBindingPairs(List<ActionElementMap> actionElementMaps, ControllerElementGlyphSelectorOptions options, List<ActionElementMapPair> results)
		{
			return 0;
		}

		public static bool FindFirstButtonBindingPair(List<ActionElementMap> actionElementMaps, out ActionElementMap negativeAem, out ActionElementMap positiveAem)
		{
			negativeAem = null;
			positiveAem = null;
			return false;
		}

		public static bool FindFirstButtonBindingPair(List<ActionElementMap> actionElementMaps, ControllerElementGlyphSelectorOptions options, out ActionElementMap negativeAem, out ActionElementMap positiveAem)
		{
			negativeAem = null;
			positiveAem = null;
			return false;
		}

		public static bool IsMousePrioritizedOverKeyboard(ControllerElementGlyphSelectorOptions options)
		{
			return false;
		}

		private static int GetActionElementMaps(int playerId, int actionId, AxisRange actionRange, ControllerElementGlyphSelectorOptions options, Predicate<ActionElementMap> isAemAllowedHandlerOverride, List<ActionElementMapPair> results, int maxResultCount)
		{
			return 0;
		}

		private static int GetActionElementMaps(InputAction action, AxisRange actionRange, FastList<ActionElementMap> aems, bool isSorted, ControllerElementGlyphSelectorOptions options, List<ActionElementMapPair> results, ref int resultsRemainingCount)
		{
			return 0;
		}

		private static int GetActionElementMaps(int playerId, int actionId, int actionId2, ControllerElementGlyphSelectorOptions options, Predicate<ActionElementMap> isAemAllowedHandlerOverride, List<Pair<ActionElementMapPair>> results, int maxResultCount)
		{
			return 0;
		}

		private static int FindFullAxisBindingsOnly(FastList<ActionElementMap> actionElementMaps, FastList<bool> usedAems, List<ActionElementMapPair> results, ref int resultsRemainingCount)
		{
			return 0;
		}

		private static int FindBindings(FastList<ActionElementMap> actionElementMaps, FastList<bool> usedAems, AxisRange actionRange, List<ActionElementMapPair> results, ref int resultsRemainingCount)
		{
			return 0;
		}

		private static int FindSplitAxisBindingPairsOnly(FastList<ActionElementMap> actionElementMaps, FastList<bool> usedAems, List<ActionElementMapPair> results, ref int resultsRemainingCount)
		{
			return 0;
		}

		private static int FindButtonBindingPairsOnly(FastList<ActionElementMap> actionElementMaps, FastList<bool> usedAems, List<ActionElementMapPair> results, ref int resultsRemainingCount)
		{
			return 0;
		}

		private static int FindSplitAxisAndButtonBindingPairsAndRemaining(FastList<ActionElementMap> actionElementMaps, FastList<bool> usedAems, List<ActionElementMapPair> results, ref int resultsRemainingCount)
		{
			return 0;
		}

		private static int GetElementMapsWithAction(Player player, ControllerType controllerType, int controllerId, int actionId, Predicate<ActionElementMap> isAllowedPredicate, ControllerElementType[] searchOrder, FastList<ActionElementMap> results)
		{
			return 0;
		}

		private static int GetElementMapsWithAction(ControllerMap controllerMap, int actionId, Predicate<ActionElementMap> isAllowedPredicate, ControllerElementType[] searchOrder, FastList<ActionElementMap> results)
		{
			return 0;
		}

		private static int GetElementMapsWithAction(Player player, ControllerType controllerType, int controllerId, int actionId, int actionId2, Predicate<ActionElementMap> isAllowedPredicate, ControllerElementType[] searchOrder, FastList<ActionElementMap> action1Results, FastList<ActionElementMap> action2Results)
		{
			return 0;
		}

		private static int GetElementMapsWithAction(ControllerMap controllerMap, int actionId, int actionId2, Predicate<ActionElementMap> isAllowedPredicate, ControllerElementType[] searchOrder, FastList<ActionElementMap> action1Results, FastList<ActionElementMap> action2Results)
		{
			return 0;
		}

		private static int RemoveInvalidElementMaps(Player player, FastList<ActionElementMap> results, int startIndex, Predicate<ActionElementMap> isAllowedPredicate)
		{
			return 0;
		}

		private static int RemoveInvalidElementMaps(FastList<ActionElementMap> results, int startIndex, Predicate<ActionElementMap> isAllowedPredicate)
		{
			return 0;
		}

		private static ActionElementMap Find(FastList<ActionElementMap> list, int startIndex, ControllerElementType controllerElementType, AxisType axisType, out int index, FastList<bool> used)
		{
			index = default(int);
			return null;
		}

		private static ActionElementMap Find(FastList<ActionElementMap> list, int startIndex, ControllerElementType controllerElementType, AxisType axisType, Pole axisContribution, out int index, FastList<bool> used)
		{
			index = default(int);
			return null;
		}

		private static ActionElementMap Find(FastList<ActionElementMap> list, int startIndex, ControllerElementType controllerElementType, int elementIdentifierId, AxisType axisType, Pole axisContribution, out int index, FastList<bool> used)
		{
			index = default(int);
			return null;
		}

		private static bool Contains(FastList<ControllerInfo> list, ControllerType type, int id)
		{
			return false;
		}

		private static Pair<ActionElementMapPair> Create(ActionElementMapPair a, ActionElementMapPair b, bool reverse)
		{
			return default(Pair<ActionElementMapPair>);
		}

		private static ActionElementMapPair Create(ActionElementMap aem, Pole pole)
		{
			return default(ActionElementMapPair);
		}

		private static bool TryCreate(ActionElementMap aem1, ActionElementMap aem2, out ActionElementMapPair result)
		{
			result = default(ActionElementMapPair);
			return false;
		}

		private static bool SetAndAddIfFull(ActionElementMapPair item, int index, ref Pair<ActionElementMapPair> target, List<Pair<ActionElementMapPair>> items)
		{
			return false;
		}

		private static bool TrySet(ActionElementMapPair item, int index, ref Pair<ActionElementMapPair> target)
		{
			return false;
		}

		private static void Set(ActionElementMap aem, Pole pole, ref ActionElementMapPair destination)
		{
		}

		private static ActionElementMap Get(ActionElementMapPair source, Pole pole)
		{
			return null;
		}

		private static void Clear(ref Pair<ActionElementMapPair> target)
		{
		}

		private static void Clear(ref ActionElementMapPair target)
		{
		}

		private static void SortByElementType(List<ActionElementMap> aems, ControllerElementType[] controllerElementTypes, FastList<ActionElementMap> results)
		{
		}

		private static void SortByElementType(FastList<ActionElementMap> aems, ControllerElementType[] controllerElementTypes)
		{
		}

		private static bool AllowMoreResultsDecrement(ref int remainingCount)
		{
			return false;
		}

		private static FastList<bool> GetUsedPooledList(int count)
		{
			return null;
		}

		private static void ReturnUsedPoolList(FastList<bool> list)
		{
		}
	}
}

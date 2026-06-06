using System;
using System.Collections.Generic;
using Rewired.Internal.Helpers;
using UnityEngine;

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

			private static readonly FastList<bool> _usedAction1Aems = new FastList<bool>(16);

			private static readonly FastList<bool> _usedAction2Aems = new FastList<bool>(16);

			private static FastList<ActionElementMap> _action1Aems;

			private static FastList<ActionElementMap> _action2Aems;

			private static ControllerElementType[] _controllerElementTypeOrder;

			private static List<Pair<ActionElementMapPair>> _results;

			private static int _resultsRemainingCount;

			private static Func<Result>[] __steps_axisPriority;

			private static Func<Result>[] __steps_buttonPriority;

			private static Func<Result>[] steps_axisPriority
			{
				get
				{
					if (__steps_axisPriority == null)
					{
						__steps_axisPriority = new Func<Result>[7] { GetCompleteFullAxisPairs, GetMixedFullAxisAndSplitAxisPairs, GetCompleteSplitAxisQuadSets, GetCompleteButtonQuadSets, GetMixedFullAxisAndButtonPairs, GetMixedSplitAxisAndButtonPairs, GetRemaining };
					}
					return __steps_axisPriority;
				}
			}

			private static Func<Result>[] steps_buttonPriority
			{
				get
				{
					if (__steps_buttonPriority == null)
					{
						__steps_buttonPriority = new Func<Result>[7] { GetCompleteButtonQuadSets, GetCompleteFullAxisPairs, GetMixedFullAxisAndSplitAxisPairs, GetCompleteSplitAxisQuadSets, GetMixedFullAxisAndButtonPairs, GetMixedSplitAxisAndButtonPairs, GetRemaining };
					}
					return __steps_buttonPriority;
				}
			}

			private static ControllerElementType elementTypePriority
			{
				get
				{
					if (_controllerElementTypeOrder[0] != ControllerElementType.Button)
					{
						return ControllerElementType.Axis;
					}
					return ControllerElementType.Button;
				}
			}

			public static int GetActionElementMaps(FastList<ActionElementMap> action1Aems, FastList<ActionElementMap> action2Aems, ControllerElementType[] controllerElementTypeOrder, List<Pair<ActionElementMapPair>> results, ref int resultsRemainingCount)
			{
				_action1Aems = action1Aems;
				_action2Aems = action2Aems;
				_controllerElementTypeOrder = controllerElementTypeOrder;
				_results = results;
				_resultsRemainingCount = resultsRemainingCount;
				int count = results.Count;
				_usedAction1Aems.SetCount(action1Aems.Count);
				_usedAction2Aems.SetCount(action2Aems.Count);
				try
				{
					Func<Result>[] steps = GetSteps();
					for (int i = 0; i < steps.Length && steps[i]() != Result.Quit; i++)
					{
					}
					return results.Count - count;
				}
				finally
				{
					resultsRemainingCount = _resultsRemainingCount;
					_usedAction1Aems.Clear();
					_usedAction2Aems.Clear();
				}
			}

			private static Result GetCompleteFullAxisPairs()
			{
				if (_resultsRemainingCount == 0)
				{
					return Result.Quit;
				}
				FastList<ActionElementMap> action1Aems = _action1Aems;
				FastList<bool> usedAction1Aems = _usedAction1Aems;
				FastList<bool> usedAction2Aems = _usedAction2Aems;
				int count = action1Aems.Count;
				for (int i = 0; i < count; i++)
				{
					if (usedAction1Aems.Array[i])
					{
						continue;
					}
					ActionElementMap actionElementMap = action1Aems.Array[i];
					ActionElementMap a;
					if (actionElementMap.elementType == ControllerElementType.Axis && actionElementMap.axisType == AxisType.Normal && (a = Find(_action2Aems, 0, ControllerElementType.Axis, AxisType.Normal, out var index, usedAction2Aems)) != null)
					{
						_results.Add(new Pair<ActionElementMapPair>(new ActionElementMapPair(actionElementMap, null), new ActionElementMapPair(a, null)));
						usedAction1Aems.Array[i] = true;
						usedAction2Aems.Array[index] = true;
						if (!AllowMoreResultsDecrement(ref _resultsRemainingCount))
						{
							return Result.Quit;
						}
					}
				}
				return Result.GoNext;
			}

			private static Result GetMixedFullAxisAndSplitAxisPairs()
			{
				if (_resultsRemainingCount == 0)
				{
					return Result.Quit;
				}
				int num = 0;
				int num2 = 0;
				do
				{
					FastList<ActionElementMap> fastList;
					FastList<ActionElementMap> list;
					FastList<bool> fastList2;
					FastList<bool> fastList3;
					if (Find(_action1Aems, num, ControllerElementType.Axis, AxisType.Normal, out var index, _usedAction1Aems) != null)
					{
						fastList = _action1Aems;
						list = _action2Aems;
						num = index;
						fastList2 = _usedAction1Aems;
						fastList3 = _usedAction2Aems;
					}
					else
					{
						if (Find(_action2Aems, num2, ControllerElementType.Axis, AxisType.Normal, out index, _usedAction2Aems) == null)
						{
							break;
						}
						fastList = _action2Aems;
						list = _action1Aems;
						num2 = index;
						fastList2 = _usedAction2Aems;
						fastList3 = _usedAction1Aems;
					}
					ActionElementMap a = fastList.Array[index];
					ActionElementMap a2;
					ActionElementMap b;
					if ((a2 = Find(list, 0, ControllerElementType.Axis, AxisType.Split, Pole.Negative, out var index2, fastList3)) != null && (b = Find(list, 0, ControllerElementType.Axis, AxisType.Split, Pole.Positive, out var index3, fastList3)) != null)
					{
						_results.Add(Create(new ActionElementMapPair(a, null), new ActionElementMapPair(a2, b), fastList == _action2Aems));
						fastList2.Array[index] = true;
						fastList3.Array[index2] = true;
						fastList3.Array[index3] = true;
						if (!AllowMoreResultsDecrement(ref _resultsRemainingCount))
						{
							return Result.Quit;
						}
					}
					if (fastList == _action1Aems)
					{
						num = index + 1;
					}
					else
					{
						num2 = index + 1;
					}
				}
				while (num < _action1Aems.Count && num2 < _action2Aems.Count);
				return Result.GoNext;
			}

			private static Result GetCompleteSplitAxisQuadSets()
			{
				if (_resultsRemainingCount == 0)
				{
					return Result.Quit;
				}
				FastList<ActionElementMap> action1Aems = _action1Aems;
				FastList<ActionElementMap> action2Aems = _action2Aems;
				FastList<bool> usedAction1Aems = _usedAction1Aems;
				FastList<bool> usedAction2Aems = _usedAction2Aems;
				int count = action1Aems.Count;
				for (int i = 0; i < count; i++)
				{
					if (usedAction1Aems.Array[i])
					{
						continue;
					}
					ActionElementMap actionElementMap = action1Aems.Array[i];
					ActionElementMap b;
					ActionElementMap a;
					ActionElementMap b2;
					if (actionElementMap.elementType == ControllerElementType.Axis && actionElementMap.axisType == AxisType.Split && actionElementMap.axisContribution == Pole.Negative && (b = Find(action1Aems, 0, ControllerElementType.Axis, AxisType.Split, Pole.Positive, out var index, usedAction1Aems)) != null && (a = Find(action2Aems, 0, ControllerElementType.Axis, AxisType.Split, Pole.Negative, out var index2, usedAction2Aems)) != null && (b2 = Find(action2Aems, 0, ControllerElementType.Axis, AxisType.Split, Pole.Positive, out var index3, usedAction2Aems)) != null)
					{
						_results.Add(new Pair<ActionElementMapPair>(new ActionElementMapPair(actionElementMap, b), new ActionElementMapPair(a, b2)));
						usedAction1Aems.Array[i] = true;
						usedAction1Aems.Array[index] = true;
						usedAction2Aems.Array[index2] = true;
						usedAction2Aems.Array[index3] = true;
						if (!AllowMoreResultsDecrement(ref _resultsRemainingCount))
						{
							return Result.Quit;
						}
					}
				}
				return Result.GoNext;
			}

			private static Result GetCompleteButtonQuadSets()
			{
				if (_resultsRemainingCount == 0)
				{
					return Result.Quit;
				}
				FastList<ActionElementMap> action1Aems = _action1Aems;
				FastList<ActionElementMap> action2Aems = _action2Aems;
				FastList<bool> usedAction1Aems = _usedAction1Aems;
				FastList<bool> usedAction2Aems = _usedAction2Aems;
				int count = action1Aems.Count;
				for (int i = 0; i < count; i++)
				{
					if (usedAction1Aems.Array[i])
					{
						continue;
					}
					ActionElementMap actionElementMap = _action1Aems.Array[i];
					ActionElementMap b;
					ActionElementMap a;
					ActionElementMap b2;
					if (actionElementMap.elementType == ControllerElementType.Button && actionElementMap.axisContribution == Pole.Negative && (b = Find(action1Aems, 0, ControllerElementType.Button, AxisType.None, Pole.Positive, out var index, usedAction1Aems)) != null && (a = Find(action2Aems, 0, ControllerElementType.Button, AxisType.None, Pole.Negative, out var index2, usedAction2Aems)) != null && (b2 = Find(action2Aems, 0, ControllerElementType.Button, AxisType.None, Pole.Positive, out var index3, usedAction2Aems)) != null)
					{
						_results.Add(new Pair<ActionElementMapPair>(new ActionElementMapPair(actionElementMap, b), new ActionElementMapPair(a, b2)));
						usedAction1Aems.Array[i] = true;
						usedAction1Aems.Array[index] = true;
						usedAction2Aems.Array[index2] = true;
						usedAction2Aems.Array[index3] = true;
						if (!AllowMoreResultsDecrement(ref _resultsRemainingCount))
						{
							return Result.Quit;
						}
					}
				}
				return Result.GoNext;
			}

			private static Result GetMixedFullAxisAndButtonPairs()
			{
				if (_resultsRemainingCount == 0)
				{
					return Result.Quit;
				}
				int num = 0;
				int num2 = 0;
				int index;
				int index3;
				ActionElementMapPair result;
				if (elementTypePriority == ControllerElementType.Button)
				{
					do
					{
						FastList<ActionElementMap> fastList;
						FastList<ActionElementMap> list;
						FastList<bool> fastList2;
						FastList<bool> fastList3;
						if (Find(_action1Aems, num, ControllerElementType.Button, AxisType.None, out index, _usedAction1Aems) != null)
						{
							fastList = _action1Aems;
							list = _action2Aems;
							num = index;
							fastList2 = _usedAction1Aems;
							fastList3 = _usedAction2Aems;
						}
						else
						{
							if (Find(_action2Aems, num2, ControllerElementType.Button, AxisType.None, out index, _usedAction2Aems) == null)
							{
								break;
							}
							fastList = _action2Aems;
							list = _action1Aems;
							num2 = index;
							fastList2 = _usedAction2Aems;
							fastList3 = _usedAction1Aems;
						}
						ActionElementMap actionElementMap = fastList.Array[index];
						ActionElementMap aem;
						ActionElementMap a;
						if ((aem = Find(fastList, 0, ControllerElementType.Button, AxisType.None, (actionElementMap.axisContribution == Pole.Positive) ? Pole.Negative : Pole.Positive, out var index2, fastList2)) != null && (a = Find(list, 0, ControllerElementType.Axis, AxisType.Normal, out index3, fastList3)) != null && TryCreate(actionElementMap, aem, out result))
						{
							_results.Add(Create(result, new ActionElementMapPair(a, null), fastList == _action2Aems));
							fastList2.Array[index] = true;
							fastList2.Array[index2] = true;
							fastList3.Array[index3] = true;
							if (!AllowMoreResultsDecrement(ref _resultsRemainingCount))
							{
								return Result.Quit;
							}
						}
						if (fastList == _action1Aems)
						{
							num = index + 1;
						}
						else
						{
							num2 = index + 1;
						}
					}
					while (num < _action1Aems.Count && num2 < _action2Aems.Count);
				}
				else
				{
					do
					{
						FastList<ActionElementMap> fastList;
						FastList<ActionElementMap> list;
						FastList<bool> fastList2;
						FastList<bool> fastList3;
						if (Find(_action1Aems, num, ControllerElementType.Axis, AxisType.Normal, out index, _usedAction1Aems) != null)
						{
							fastList = _action1Aems;
							list = _action2Aems;
							num = index;
							fastList2 = _usedAction1Aems;
							fastList3 = _usedAction2Aems;
						}
						else
						{
							if (Find(_action2Aems, num2, ControllerElementType.Axis, AxisType.Normal, out index, _usedAction2Aems) == null)
							{
								break;
							}
							fastList = _action2Aems;
							list = _action1Aems;
							num2 = index;
							fastList2 = _usedAction2Aems;
							fastList3 = _usedAction1Aems;
						}
						ActionElementMap actionElementMap = fastList.Array[index];
						ActionElementMap a;
						ActionElementMap aem2;
						if ((a = Find(list, 0, ControllerElementType.Button, AxisType.None, Pole.Negative, out index3, fastList3)) != null && (aem2 = Find(list, 0, ControllerElementType.Button, AxisType.None, Pole.Positive, out var index4, fastList3)) != null && TryCreate(a, aem2, out result))
						{
							_results.Add(Create(new ActionElementMapPair(actionElementMap, null), result, fastList == _action2Aems));
							fastList2.Array[index] = true;
							fastList3.Array[index3] = true;
							fastList3.Array[index4] = true;
							if (!AllowMoreResultsDecrement(ref _resultsRemainingCount))
							{
								return Result.Quit;
							}
						}
						if (fastList == _action1Aems)
						{
							num = index + 1;
						}
						else
						{
							num2 = index + 1;
						}
					}
					while (num < _action1Aems.Count && num2 < _action2Aems.Count);
				}
				return Result.GoNext;
			}

			private static Result GetMixedSplitAxisAndButtonPairs()
			{
				if (_resultsRemainingCount == 0)
				{
					return Result.Quit;
				}
				_ = _action1Aems;
				_ = _action2Aems;
				FastList<bool> usedAction1Aems = _usedAction1Aems;
				FastList<bool> usedAction2Aems = _usedAction2Aems;
				int count = _action1Aems.Count;
				for (int i = 0; i < count; i++)
				{
					if (usedAction1Aems.Array[i])
					{
						continue;
					}
					ActionElementMap actionElementMap = _action1Aems.Array[i];
					int index;
					int index2;
					int index3;
					ActionElementMap b;
					ActionElementMap a;
					ActionElementMap b2;
					if (actionElementMap.elementType == ControllerElementType.Axis && actionElementMap.axisType == AxisType.Split && actionElementMap.axisContribution == Pole.Negative)
					{
						if ((b = Find(_action1Aems, 0, ControllerElementType.Axis, AxisType.Split, Pole.Positive, out index, usedAction1Aems)) != null && (a = Find(_action2Aems, 0, ControllerElementType.Button, AxisType.None, Pole.Negative, out index2, usedAction2Aems)) != null && (b2 = Find(_action2Aems, 0, ControllerElementType.Button, AxisType.None, Pole.Positive, out index3, usedAction2Aems)) != null)
						{
							_results.Add(new Pair<ActionElementMapPair>(new ActionElementMapPair(actionElementMap, b), new ActionElementMapPair(a, b2)));
							usedAction1Aems.Array[i] = true;
							usedAction1Aems.Array[index] = true;
							usedAction2Aems.Array[index2] = true;
							usedAction2Aems.Array[index3] = true;
							if (!AllowMoreResultsDecrement(ref _resultsRemainingCount))
							{
								return Result.Quit;
							}
						}
					}
					else if (actionElementMap.elementType == ControllerElementType.Button && actionElementMap.axisContribution == Pole.Negative && (b = Find(_action1Aems, 0, ControllerElementType.Button, AxisType.None, Pole.Positive, out index, usedAction1Aems)) != null && (a = Find(_action2Aems, 0, ControllerElementType.Axis, AxisType.Split, Pole.Negative, out index2, usedAction2Aems)) != null && (b2 = Find(_action2Aems, 0, ControllerElementType.Axis, AxisType.Split, Pole.Positive, out index3, usedAction2Aems)) != null)
					{
						_results.Add(new Pair<ActionElementMapPair>(new ActionElementMapPair(actionElementMap, b), new ActionElementMapPair(a, b2)));
						usedAction1Aems.Array[i] = true;
						usedAction1Aems.Array[index] = true;
						usedAction2Aems.Array[index2] = true;
						usedAction2Aems.Array[index3] = true;
						if (!AllowMoreResultsDecrement(ref _resultsRemainingCount))
						{
							return Result.Quit;
						}
					}
				}
				return Result.GoNext;
			}

			private static Result GetRemaining()
			{
				if (_resultsRemainingCount == 0)
				{
					return Result.Quit;
				}
				Pair<ActionElementMapPair> target = default(Pair<ActionElementMapPair>);
				int num = 0;
				int num2 = 0;
				do
				{
					for (int i = 0; i < 2; i++)
					{
						FastList<ActionElementMap> fastList;
						int num3;
						int index;
						FastList<bool> fastList2;
						if (i == 0)
						{
							fastList = _action1Aems;
							num3 = num;
							index = 0;
							fastList2 = _usedAction1Aems;
						}
						else
						{
							fastList = _action2Aems;
							num3 = num2;
							index = 1;
							fastList2 = _usedAction2Aems;
						}
						if (num3 >= fastList.Count)
						{
							continue;
						}
						if (!fastList2.Array[num3])
						{
							ActionElementMap actionElementMap = fastList.Array[num3];
							int index2;
							if (actionElementMap.elementType == ControllerElementType.Axis)
							{
								if (actionElementMap.axisType == AxisType.Normal)
								{
									bool num4 = SetAndAddIfFull(new ActionElementMapPair(actionElementMap, null), index, ref target, _results);
									fastList2.Array[num3] = true;
									if (num4 && !AllowMoreResultsDecrement(ref _resultsRemainingCount))
									{
										return Result.Quit;
									}
								}
								else if (actionElementMap.axisType == AxisType.Split)
								{
									bool flag = actionElementMap.axisContribution == Pole.Positive;
									ActionElementMap actionElementMap2 = Find(fastList, 0, ControllerElementType.Axis, AxisType.Split, flag ? Pole.Negative : Pole.Positive, out index2, fastList2);
									if (actionElementMap2 == null)
									{
										actionElementMap2 = Find(fastList, 0, ControllerElementType.Button, AxisType.None, flag ? Pole.Negative : Pole.Positive, out index2, fastList2);
									}
									bool num5 = (flag ? SetAndAddIfFull(new ActionElementMapPair(actionElementMap2, actionElementMap), index, ref target, _results) : SetAndAddIfFull(new ActionElementMapPair(actionElementMap, actionElementMap2), index, ref target, _results));
									fastList2.Array[num3] = true;
									if (actionElementMap2 != null)
									{
										fastList2.Array[index2] = true;
									}
									if (num5 && !AllowMoreResultsDecrement(ref _resultsRemainingCount))
									{
										return Result.Quit;
									}
								}
							}
							else if (actionElementMap.elementType == ControllerElementType.Button)
							{
								bool flag = actionElementMap.axisContribution == Pole.Positive;
								ActionElementMap actionElementMap2 = Find(fastList, 0, ControllerElementType.Button, AxisType.None, flag ? Pole.Negative : Pole.Positive, out index2, fastList2);
								if (actionElementMap2 == null)
								{
									actionElementMap2 = Find(fastList, 0, ControllerElementType.Axis, AxisType.Split, flag ? Pole.Negative : Pole.Positive, out index2, fastList2);
								}
								bool num6 = (flag ? SetAndAddIfFull(new ActionElementMapPair(actionElementMap2, actionElementMap), index, ref target, _results) : SetAndAddIfFull(new ActionElementMapPair(actionElementMap, actionElementMap2), index, ref target, _results));
								fastList2.Array[num3] = true;
								if (actionElementMap2 != null)
								{
									fastList2.Array[index2] = true;
								}
								if (num6 && !AllowMoreResultsDecrement(ref _resultsRemainingCount))
								{
									return Result.Quit;
								}
							}
						}
						if (fastList == _action1Aems)
						{
							num = num3 + 1;
						}
						else
						{
							num2 = num3 + 1;
						}
					}
				}
				while (num < _action1Aems.Count || num2 < _action2Aems.Count);
				if (target.a.Count > 0 || target.b.Count > 0)
				{
					_results.Add(target);
					if (!AllowMoreResultsDecrement(ref _resultsRemainingCount))
					{
						return Result.Quit;
					}
				}
				return Result.GoNext;
			}

			private static Func<Result>[] GetSteps()
			{
				if (_controllerElementTypeOrder[0] == ControllerElementType.Button)
				{
					return steps_buttonPriority;
				}
				return steps_axisPriority;
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
					this.playerId = playerId;
					this.controllerIdentifier = controllerIdentifier;
					this.mapCategoryId = mapCategoryId;
					this.layoutId = layoutId;
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
					this.selector = selector;
				}

				public void Clear()
				{
					loaded = false;
					controllerMap = null;
				}
			}

			private static DefaultControllerMapCache s_instance;

			private readonly List<Entry> _cache;

			public static DefaultControllerMapCache instance
			{
				get
				{
					if (!ReInput.isReady)
					{
						return null;
					}
					if (s_instance == null)
					{
						return s_instance = new DefaultControllerMapCache();
					}
					return s_instance;
				}
			}

			private DefaultControllerMapCache()
			{
				_cache = new List<Entry>();
				ReInput.ShutDownEvent += OnRewiredShutDown;
			}

			private void OnRewiredShutDown()
			{
				ReInput.ShutDownEvent -= OnRewiredShutDown;
				s_instance = null;
			}

			public ControllerMap GetControllerMap(int playerId, ControllerIdentifier controllerIdentifier, string mapCategoryName, string layoutName)
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(mapCategoryName);
				if (mapCategoryId < 0)
				{
					return null;
				}
				int layoutId = ReInput.mapping.GetLayoutId(controllerIdentifier.controllerType, layoutName);
				if (layoutId < 0)
				{
					return null;
				}
				int num = IndexOf(playerId, controllerIdentifier, mapCategoryId, layoutId);
				Entry entry;
				if (num < 0)
				{
					entry = new Entry(new Selector(playerId, controllerIdentifier, mapCategoryId, layoutId));
					_cache.Add(entry);
				}
				else
				{
					entry = _cache[num];
				}
				if (!IsEqualOrNextFrame(Time.frameCount, entry.lastTouchedFrame))
				{
					entry.Clear();
				}
				if (!entry.loaded)
				{
					entry.controllerMap = ReInput.mapping.GetControllerMapInstanceSavedOrDefault(playerId, controllerIdentifier, mapCategoryId, layoutId);
					entry.loaded = true;
				}
				entry.lastTouchedFrame = Time.frameCount;
				return entry.controllerMap;
			}

			private int IndexOf(int playerId, ControllerIdentifier controllerIdentifier, int mapCategoryId, int layoutId)
			{
				int count = _cache.Count;
				for (int i = 0; i < count; i++)
				{
					Selector selector = _cache[i].selector;
					if (selector.playerId == playerId && selector.mapCategoryId == mapCategoryId && selector.layoutId == layoutId && selector.controllerIdentifier.controllerType == controllerIdentifier.controllerType && selector.controllerIdentifier.deviceInstanceGuid == controllerIdentifier.deviceInstanceGuid && string.Equals(selector.controllerIdentifier.hardwareIdentifier, controllerIdentifier.hardwareIdentifier, StringComparison.Ordinal))
					{
						return i;
					}
				}
				return -1;
			}

			private static bool IsEqualOrNextFrame(int a, int b)
			{
				if (a == b)
				{
					return true;
				}
				if (b == int.MaxValue)
				{
					return a == 0;
				}
				return a == b + 1;
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
				if (startingCapacity < 2)
				{
					startingCapacity = 2;
				}
				Array = new T[startingCapacity];
				Capacity = startingCapacity;
			}

			public void Add(T item)
			{
				if (Count >= Capacity)
				{
					Expand(Capacity * 2);
				}
				Array[Count] = item;
				Count++;
			}

			public void RemoveAt(int index)
			{
				if ((uint)index >= (uint)Count)
				{
					throw new IndexOutOfRangeException();
				}
				int num = Count - 1;
				for (int i = index; i < num; i++)
				{
					Array[i] = Array[i + 1];
				}
				Array[num] = default(T);
				Count--;
			}

			public void Expand(int size)
			{
				if (size <= 2)
				{
					size = 2;
				}
				if (size > Capacity)
				{
					if (!IsPowerOfTwo((uint)size))
					{
						size = (int)RoundUpToPowerOf2((uint)size);
					}
					T[] array = new T[size];
					int num = ((Capacity < size) ? Capacity : size);
					for (int i = 0; i < num; i++)
					{
						array[i] = Array[i];
					}
					Array = array;
					Capacity = Array.Length;
				}
			}

			public void SetCount(int size)
			{
				if (size < 0)
				{
					size = 0;
				}
				if (size != Count)
				{
					if (size < Count)
					{
						System.Array.Clear(Array, size, Count - size);
					}
					if (size > Capacity)
					{
						Expand(size);
					}
					Count = size;
				}
			}

			public void ReplaceFrom(IList<T> source)
			{
				Clear();
				int count = source.Count;
				Expand(count);
				for (int i = 0; i < count; i++)
				{
					Array[i] = source[i];
				}
				Count = count;
			}

			public void ReplaceFrom(FastList<T> source)
			{
				Clear();
				int count = source.Count;
				Expand(count);
				for (int i = 0; i < count; i++)
				{
					Array[i] = source.Array[i];
				}
				Count = count;
			}

			public void Clear()
			{
				if (Count > 0)
				{
					System.Array.Clear(Array, 0, Count);
				}
				Count = 0;
			}

			private static uint RoundUpToPowerOf2(uint value)
			{
				if (value == 0)
				{
					return 1u;
				}
				value--;
				value |= value >> 1;
				value |= value >> 2;
				value |= value >> 4;
				value |= value >> 8;
				value |= value >> 16;
				value++;
				return value;
			}

			private static bool IsPowerOfTwo(uint x)
			{
				if (x != 0)
				{
					return (x & (x - 1)) == 0;
				}
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
				_createDelegate = createDelegate;
				_onReturnDelegate = onReturnDelegate;
				_objects = new List<T>();
			}

			public T Get()
			{
				if (_objects.Count != 0)
				{
					int index = _objects.Count - 1;
					T result = _objects[index];
					_objects.RemoveAt(index);
					return result;
				}
				return _createDelegate();
			}

			public void Return(T obj)
			{
				if (obj != null && !_objects.Contains(obj))
				{
					_objects.Add(obj);
					_onReturnDelegate(obj);
				}
			}
		}

		private struct ControllerInfo
		{
			public ControllerType type;

			public int controllerId;

			public ControllerInfo(ControllerType type, int controllerId)
			{
				this.type = type;
				this.controllerId = controllerId;
			}
		}

		private static readonly ObjectPool<FastList<ActionElementMap>> aemFastListPool = new ObjectPool<FastList<ActionElementMap>>(() => new FastList<ActionElementMap>(16), delegate(FastList<ActionElementMap> x)
		{
			x.Clear();
		});

		private static readonly ObjectPool<List<ActionElementMapPair>> aemPairListPool = new ObjectPool<List<ActionElementMapPair>>(() => new List<ActionElementMapPair>(16), delegate(List<ActionElementMapPair> x)
		{
			x.Clear();
		});

		private static readonly ObjectPool<List<Pair<ActionElementMapPair>>> aemPair2dListPool = new ObjectPool<List<Pair<ActionElementMapPair>>>(() => new List<Pair<ActionElementMapPair>>(8), delegate(List<Pair<ActionElementMapPair>> x)
		{
			x.Clear();
		});

		private static readonly ObjectPool<FastList<bool>> boolFastListPool = new ObjectPool<FastList<bool>>(() => new FastList<bool>(16), delegate(FastList<bool> x)
		{
			x.Clear();
		});

		private static readonly ObjectPool<FastList<ControllerInfo>> controllerInfoFastListPool = new ObjectPool<FastList<ControllerInfo>>(() => new FastList<ControllerInfo>(8), delegate(FastList<ControllerInfo> x)
		{
			x.Clear();
		});

		private static readonly List<ActionElementMap> GetElementMapsWithAction_tempAems = new List<ActionElementMap>();

		private static Predicate<ActionElementMap> __defaultGetElementMapsWithActionisAllowedHandler;

		private static Predicate<ActionElementMap> defaultGetElementMapsWithActionisAllowedHandler
		{
			get
			{
				if (__defaultGetElementMapsWithActionisAllowedHandler == null)
				{
					__defaultGetElementMapsWithActionisAllowedHandler = (ActionElementMap aem) => (aem != null && aem.controllerMap.enabled && aem.enabled) ? true : false;
				}
				return __defaultGetElementMapsWithActionisAllowedHandler;
			}
		}

		public static bool TryGetActionElementMaps(int playerId, int actionId, AxisRange actionRange, ControllerElementGlyphSelectorOptions options, Predicate<ActionElementMap> isAemAllowedHandlerOverride, out ActionElementMap aemResult1, out ActionElementMap aemResult2)
		{
			List<ActionElementMapPair> list = aemPairListPool.Get();
			if (GetActionElementMaps(playerId, actionId, actionRange, options, isAemAllowedHandlerOverride, list, 1) > 0)
			{
				aemResult1 = list[0].a;
				aemResult2 = list[0].b;
			}
			else
			{
				aemResult1 = null;
				aemResult2 = null;
			}
			aemPairListPool.Return(list);
			if (aemResult1 == null)
			{
				return aemResult2 != null;
			}
			return true;
		}

		public static bool TryGetActionElementMaps(InputAction action, AxisRange actionRange, List<ActionElementMap> aems, out ActionElementMap aemResult1, out ActionElementMap aemResult2)
		{
			return TryGetActionElementMaps(action, actionRange, aems, null, out aemResult1, out aemResult2);
		}

		public static bool TryGetActionElementMaps(InputAction action, AxisRange actionRange, List<ActionElementMap> aems, ControllerElementGlyphSelectorOptions options, out ActionElementMap aemResult1, out ActionElementMap aemResult2)
		{
			List<ActionElementMapPair> list = aemPairListPool.Get();
			FastList<ActionElementMap> fastList = aemFastListPool.Get();
			int resultsRemainingCount = 1;
			fastList.ReplaceFrom(aems);
			if (GetActionElementMaps(action, actionRange, fastList, isSorted: false, options, list, ref resultsRemainingCount) > 0)
			{
				aemResult1 = list[0].a;
				aemResult2 = list[0].b;
			}
			else
			{
				aemResult1 = null;
				aemResult2 = null;
			}
			aemPairListPool.Return(list);
			aemFastListPool.Return(fastList);
			if (aemResult1 == null)
			{
				return aemResult2 != null;
			}
			return true;
		}

		public static bool TryGetActionElementMaps(int playerId, int actionId, int actionId2, ControllerElementGlyphSelectorOptions options, Predicate<ActionElementMap> isAemAllowedHandlerOverride, out ActionElementMapPair aemResult1, out ActionElementMapPair aemResult2)
		{
			List<Pair<ActionElementMapPair>> list = aemPair2dListPool.Get();
			if (GetActionElementMaps(playerId, actionId, actionId2, options, isAemAllowedHandlerOverride, list, 1) > 0)
			{
				aemResult1 = list[0].a;
				aemResult2 = list[0].b;
			}
			else
			{
				aemResult1 = default(ActionElementMapPair);
				aemResult2 = default(ActionElementMapPair);
			}
			aemPair2dListPool.Return(list);
			if (aemResult1.Count <= 0)
			{
				return aemResult2.Count > 0;
			}
			return true;
		}

		public static int GetActionElementMaps(int playerId, int actionId, AxisRange actionRange, ControllerElementGlyphSelectorOptions options, Predicate<ActionElementMap> isAemAllowedHandlerOverride, List<ActionElementMapPair> results)
		{
			return GetActionElementMaps(playerId, actionId, actionRange, options, isAemAllowedHandlerOverride, results, 0);
		}

		public static int GetActionElementMaps(int playerId, int actionId, int actionId2, ControllerElementGlyphSelectorOptions options, Predicate<ActionElementMap> isAemAllowedHandlerOverride, List<Pair<ActionElementMapPair>> results)
		{
			return GetActionElementMaps(playerId, actionId, actionId2, options, isAemAllowedHandlerOverride, results, 0);
		}

		public static ActionElementMap FindFirstFullAxisBinding(List<ActionElementMap> actionElementMaps)
		{
			return FindFirstFullAxisBinding(actionElementMaps, null);
		}

		public static ActionElementMap FindFirstFullAxisBinding(List<ActionElementMap> actionElementMaps, ControllerElementGlyphSelectorOptions options)
		{
			FastList<ActionElementMap> fastList = aemFastListPool.Get();
			FastList<bool> usedPooledList = GetUsedPooledList(actionElementMaps.Count);
			List<ActionElementMapPair> list = aemPairListPool.Get();
			int resultsRemainingCount = 1;
			fastList.ReplaceFrom(actionElementMaps);
			if (options != null)
			{
				SortByElementType(fastList, options.controllerElementTypeOrder);
			}
			ActionElementMap result = ((FindFullAxisBindingsOnly(fastList, usedPooledList, list, ref resultsRemainingCount) <= 0) ? null : list[0].a);
			aemFastListPool.Return(fastList);
			ReturnUsedPoolList(usedPooledList);
			aemPairListPool.Return(list);
			return result;
		}

		public static int FindFullAxisBindings(List<ActionElementMap> actionElementMaps, List<ActionElementMapPair> results)
		{
			return FindFullAxisBindings(actionElementMaps, null, results);
		}

		public static int FindFullAxisBindings(List<ActionElementMap> actionElementMaps, ControllerElementGlyphSelectorOptions options, List<ActionElementMapPair> results)
		{
			FastList<ActionElementMap> fastList = aemFastListPool.Get();
			FastList<bool> usedPooledList = GetUsedPooledList(actionElementMaps.Count);
			int resultsRemainingCount = -1;
			fastList.ReplaceFrom(actionElementMaps);
			if (options != null)
			{
				SortByElementType(fastList, options.controllerElementTypeOrder);
			}
			int result = FindFullAxisBindingsOnly(fastList, usedPooledList, results, ref resultsRemainingCount);
			aemFastListPool.Return(fastList);
			ReturnUsedPoolList(usedPooledList);
			return result;
		}

		public static ActionElementMap FindFirstBinding(List<ActionElementMap> actionElementMaps, AxisRange actionRange)
		{
			return FindFirstBinding(actionElementMaps, actionRange);
		}

		public static ActionElementMap FindFirstBinding(List<ActionElementMap> actionElementMaps, ControllerElementGlyphSelectorOptions options, AxisRange actionRange)
		{
			FastList<ActionElementMap> fastList = aemFastListPool.Get();
			FastList<bool> usedPooledList = GetUsedPooledList(actionElementMaps.Count);
			List<ActionElementMapPair> list = aemPairListPool.Get();
			int resultsRemainingCount = 1;
			fastList.ReplaceFrom(actionElementMaps);
			if (options != null)
			{
				SortByElementType(fastList, options.controllerElementTypeOrder);
			}
			ActionElementMap result = ((FindBindings(fastList, usedPooledList, actionRange, list, ref resultsRemainingCount) <= 0) ? null : ((list[0].a != null) ? list[0].a : list[0].b));
			aemFastListPool.Return(fastList);
			ReturnUsedPoolList(usedPooledList);
			aemPairListPool.Return(list);
			return result;
		}

		public static int FindBindings(List<ActionElementMap> actionElementMaps, AxisRange actionRange, List<ActionElementMapPair> results)
		{
			return FindBindings(actionElementMaps, actionRange, null, results);
		}

		public static int FindBindings(List<ActionElementMap> actionElementMaps, AxisRange actionRange, ControllerElementGlyphSelectorOptions options, List<ActionElementMapPair> results)
		{
			FastList<ActionElementMap> fastList = aemFastListPool.Get();
			FastList<bool> usedPooledList = GetUsedPooledList(actionElementMaps.Count);
			int resultsRemainingCount = -1;
			fastList.ReplaceFrom(actionElementMaps);
			if (options != null)
			{
				SortByElementType(fastList, options.controllerElementTypeOrder);
			}
			int result = FindBindings(fastList, usedPooledList, actionRange, results, ref resultsRemainingCount);
			aemFastListPool.Return(fastList);
			ReturnUsedPoolList(usedPooledList);
			return result;
		}

		public static int FindSplitAxisBindingPairs(List<ActionElementMap> actionElementMaps, List<ActionElementMapPair> results)
		{
			return FindSplitAxisBindingPairs(actionElementMaps, null, results);
		}

		public static int FindSplitAxisBindingPairs(List<ActionElementMap> actionElementMaps, ControllerElementGlyphSelectorOptions options, List<ActionElementMapPair> results)
		{
			FastList<ActionElementMap> fastList = aemFastListPool.Get();
			FastList<bool> usedPooledList = GetUsedPooledList(actionElementMaps.Count);
			int resultsRemainingCount = -1;
			fastList.ReplaceFrom(actionElementMaps);
			if (options != null)
			{
				SortByElementType(fastList, options.controllerElementTypeOrder);
			}
			int result = FindSplitAxisBindingPairsOnly(fastList, usedPooledList, results, ref resultsRemainingCount);
			aemFastListPool.Return(fastList);
			ReturnUsedPoolList(usedPooledList);
			return result;
		}

		public static bool FindFirstSplitAxisBindingPair(List<ActionElementMap> actionElementMaps, out ActionElementMap negativeAem, out ActionElementMap positiveAem)
		{
			return FindFirstSplitAxisBindingPair(actionElementMaps, null, out negativeAem, out positiveAem);
		}

		public static bool FindFirstSplitAxisBindingPair(List<ActionElementMap> actionElementMaps, ControllerElementGlyphSelectorOptions options, out ActionElementMap negativeAem, out ActionElementMap positiveAem)
		{
			List<ActionElementMapPair> list = aemPairListPool.Get();
			FastList<ActionElementMap> fastList = aemFastListPool.Get();
			FastList<bool> usedPooledList = GetUsedPooledList(actionElementMaps.Count);
			int resultsRemainingCount = 1;
			fastList.ReplaceFrom(actionElementMaps);
			if (options != null)
			{
				SortByElementType(fastList, options.controllerElementTypeOrder);
			}
			if (FindSplitAxisBindingPairsOnly(fastList, usedPooledList, list, ref resultsRemainingCount) > 0)
			{
				negativeAem = Get(list[0], Pole.Negative);
				positiveAem = Get(list[0], Pole.Positive);
			}
			else
			{
				negativeAem = null;
				positiveAem = null;
			}
			aemPairListPool.Return(list);
			aemFastListPool.Return(fastList);
			ReturnUsedPoolList(usedPooledList);
			if (negativeAem == null)
			{
				return positiveAem != null;
			}
			return true;
		}

		public static int FindButtonBindingPairs(List<ActionElementMap> actionElementMaps, List<ActionElementMapPair> results)
		{
			return FindSplitAxisBindingPairs(actionElementMaps, null, results);
		}

		public static int FindButtonBindingPairs(List<ActionElementMap> actionElementMaps, ControllerElementGlyphSelectorOptions options, List<ActionElementMapPair> results)
		{
			FastList<ActionElementMap> fastList = aemFastListPool.Get();
			FastList<bool> usedPooledList = GetUsedPooledList(actionElementMaps.Count);
			int resultsRemainingCount = -1;
			fastList.ReplaceFrom(actionElementMaps);
			if (options != null)
			{
				SortByElementType(fastList, options.controllerElementTypeOrder);
			}
			int result = FindButtonBindingPairsOnly(fastList, usedPooledList, results, ref resultsRemainingCount);
			aemFastListPool.Return(fastList);
			ReturnUsedPoolList(usedPooledList);
			return result;
		}

		public static bool FindFirstButtonBindingPair(List<ActionElementMap> actionElementMaps, out ActionElementMap negativeAem, out ActionElementMap positiveAem)
		{
			return FindFirstSplitAxisBindingPair(actionElementMaps, null, out negativeAem, out positiveAem);
		}

		public static bool FindFirstButtonBindingPair(List<ActionElementMap> actionElementMaps, ControllerElementGlyphSelectorOptions options, out ActionElementMap negativeAem, out ActionElementMap positiveAem)
		{
			List<ActionElementMapPair> list = aemPairListPool.Get();
			FastList<ActionElementMap> fastList = aemFastListPool.Get();
			FastList<bool> usedPooledList = GetUsedPooledList(actionElementMaps.Count);
			int resultsRemainingCount = 1;
			fastList.ReplaceFrom(actionElementMaps);
			if (options != null)
			{
				SortByElementType(fastList, options.controllerElementTypeOrder);
			}
			if (FindButtonBindingPairsOnly(fastList, usedPooledList, list, ref resultsRemainingCount) > 0)
			{
				negativeAem = Get(list[0], Pole.Negative);
				positiveAem = Get(list[0], Pole.Positive);
			}
			else
			{
				negativeAem = null;
				positiveAem = null;
			}
			aemPairListPool.Return(list);
			aemFastListPool.Return(fastList);
			ReturnUsedPoolList(usedPooledList);
			if (negativeAem == null)
			{
				return positiveAem != null;
			}
			return true;
		}

		public static bool IsMousePrioritizedOverKeyboard(ControllerElementGlyphSelectorOptions options)
		{
			if (options == null)
			{
				return false;
			}
			ControllerType controllerType;
			for (int i = 0; options.TryGetControllerTypeOrder(i, out controllerType); i++)
			{
				switch (controllerType)
				{
				case ControllerType.Mouse:
					return true;
				case ControllerType.Keyboard:
					return false;
				}
			}
			return false;
		}

		private static int GetActionElementMaps(int playerId, int actionId, AxisRange actionRange, ControllerElementGlyphSelectorOptions options, Predicate<ActionElementMap> isAemAllowedHandlerOverride, List<ActionElementMapPair> results, int maxResultCount)
		{
			if (!ReInput.isReady)
			{
				return 0;
			}
			if (options == null)
			{
				return 0;
			}
			if (results == null)
			{
				return 0;
			}
			if (maxResultCount < 0)
			{
				maxResultCount = 0;
			}
			InputAction action = ReInput.mapping.GetAction(actionId);
			if (action == null)
			{
				return 0;
			}
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return 0;
			}
			ControllerElementType[] controllerElementTypeOrder = options.controllerElementTypeOrder;
			int count = results.Count;
			int resultsRemainingCount = ((maxResultCount > 0) ? maxResultCount : (-1));
			bool useFirstControllerResults = options.useFirstControllerResults;
			Controller controller = player.controllers.GetLastActiveController();
			FastList<ActionElementMap> fastList = aemFastListPool.Get();
			FastList<ControllerInfo> fastList2 = controllerInfoFastListPool.Get();
			try
			{
				Predicate<ActionElementMap> predicate = null;
				if (isAemAllowedHandlerOverride != null)
				{
					predicate = isAemAllowedHandlerOverride;
				}
				else if (options != null)
				{
					predicate = options.isActionElementMapAllowedHandler;
				}
				if (predicate == null)
				{
					predicate = defaultGetElementMapsWithActionisAllowedHandler;
				}
				if (options.useLastActiveController && controller != null)
				{
					Controller controller2 = null;
					if (controller.type == ControllerType.Keyboard || controller.type == ControllerType.Mouse)
					{
						if (IsMousePrioritizedOverKeyboard(options))
						{
							if (ReInput.controllers.Mouse.enabled && player.controllers.hasMouse)
							{
								controller = ReInput.controllers.Mouse;
								controller2 = ReInput.controllers.Keyboard;
							}
						}
						else if (ReInput.controllers.Keyboard.enabled && player.controllers.hasKeyboard)
						{
							controller = ReInput.controllers.Keyboard;
							controller2 = ReInput.controllers.Mouse;
						}
					}
					if (!Contains(fastList2, controller.type, controller.id))
					{
						if (GetElementMapsWithAction(player, controller.type, controller.id, actionId, predicate, controllerElementTypeOrder, fastList) > 0 && GetActionElementMaps(action, actionRange, fastList, isSorted: true, options, results, ref resultsRemainingCount) > 0 && maxResultCount > 0 && resultsRemainingCount <= 0)
						{
							return results.Count - count;
						}
						fastList2.Add(new ControllerInfo(controller.type, controller.id));
					}
					if (controller2 != null && !Contains(fastList2, controller2.type, controller2.id))
					{
						if (GetElementMapsWithAction(player, controller2.type, controller2.id, actionId, predicate, controllerElementTypeOrder, fastList) > 0 && GetActionElementMaps(action, actionRange, fastList, isSorted: true, options, results, ref resultsRemainingCount) > 0 && maxResultCount > 0 && resultsRemainingCount <= 0)
						{
							return results.Count - count;
						}
						fastList2.Add(new ControllerInfo(controller2.type, controller2.id));
					}
					if (useFirstControllerResults && results.Count - count > 0)
					{
						return results.Count - count;
					}
					ControllerType type = controller.type;
					switch (type)
					{
					case ControllerType.Joystick:
					{
						for (int j = 0; j < player.controllers.joystickCount; j++)
						{
							int id2 = player.controllers.Joysticks[j].id;
							if (!Contains(fastList2, type, id2))
							{
								if (GetElementMapsWithAction(player, type, id2, actionId, predicate, controllerElementTypeOrder, fastList) > 0 && GetActionElementMaps(action, actionRange, fastList, isSorted: true, options, results, ref resultsRemainingCount) > 0 && (useFirstControllerResults || (maxResultCount > 0 && resultsRemainingCount <= 0)))
								{
									return results.Count - count;
								}
								fastList2.Add(new ControllerInfo(type, id2));
							}
						}
						break;
					}
					case ControllerType.Custom:
					{
						for (int i = 0; i < player.controllers.customControllerCount; i++)
						{
							int id = player.controllers.CustomControllers[i].id;
							if (!Contains(fastList2, type, id))
							{
								if (GetElementMapsWithAction(player, type, id, actionId, predicate, controllerElementTypeOrder, fastList) > 0 && GetActionElementMaps(action, actionRange, fastList, isSorted: true, options, results, ref resultsRemainingCount) > 0 && (useFirstControllerResults || (maxResultCount > 0 && resultsRemainingCount <= 0)))
								{
									return results.Count - count;
								}
								fastList2.Add(new ControllerInfo(type, id));
							}
						}
						break;
					}
					}
				}
				int num = 15;
				ControllerType[] controllerTypeOrder = options.controllerTypeOrder;
				int num2 = 0;
				while (num != 0)
				{
					ControllerType controllerType;
					if (num2 < controllerTypeOrder.Length)
					{
						controllerType = controllerTypeOrder[num2];
					}
					else if ((num & 1) != 0)
					{
						controllerType = ControllerType.Joystick;
					}
					else if ((num & 4) != 0)
					{
						controllerType = ControllerType.Mouse;
					}
					else if ((num & 2) != 0)
					{
						controllerType = ControllerType.Keyboard;
					}
					else
					{
						if ((num & 8) == 0)
						{
							throw new NotImplementedException();
						}
						controllerType = ControllerType.Custom;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
					{
						if ((num & 1) == 0)
						{
							break;
						}
						for (int k = 0; k < player.controllers.joystickCount; k++)
						{
							int id3 = player.controllers.Joysticks[k].id;
							if (!Contains(fastList2, controllerType, id3))
							{
								if (GetElementMapsWithAction(player, controllerType, id3, actionId, predicate, controllerElementTypeOrder, fastList) > 0 && GetActionElementMaps(action, actionRange, fastList, isSorted: true, options, results, ref resultsRemainingCount) > 0 && (useFirstControllerResults || (maxResultCount > 0 && resultsRemainingCount <= 0)))
								{
									return results.Count - count;
								}
								fastList2.Add(new ControllerInfo(controllerType, id3));
							}
						}
						num &= -2;
						break;
					}
					case ControllerType.Custom:
					{
						if ((num & 8) == 0)
						{
							break;
						}
						for (int l = 0; l < player.controllers.customControllerCount; l++)
						{
							int id3 = player.controllers.CustomControllers[l].id;
							if (!Contains(fastList2, controllerType, id3))
							{
								if (GetElementMapsWithAction(player, controllerType, id3, actionId, predicate, controllerElementTypeOrder, fastList) > 0 && GetActionElementMaps(action, actionRange, fastList, isSorted: true, options, results, ref resultsRemainingCount) > 0 && (useFirstControllerResults || (maxResultCount > 0 && resultsRemainingCount <= 0)))
								{
									return results.Count - count;
								}
								fastList2.Add(new ControllerInfo(controllerType, id3));
							}
						}
						num &= -9;
						break;
					}
					case ControllerType.Keyboard:
					case ControllerType.Mouse:
					{
						bool flag = false;
						bool flag2 = useFirstControllerResults;
						if ((controllerType == ControllerType.Mouse || flag2) && (num & 4) != 0)
						{
							if (player.controllers.hasMouse)
							{
								int id3 = ReInput.controllers.Mouse.id;
								if (!Contains(fastList2, ControllerType.Mouse, id3))
								{
									if (GetElementMapsWithAction(player, ControllerType.Mouse, id3, actionId, predicate, controllerElementTypeOrder, fastList) > 0 && GetActionElementMaps(action, actionRange, fastList, isSorted: true, options, results, ref resultsRemainingCount) > 0)
									{
										if (maxResultCount > 0 && resultsRemainingCount <= 0)
										{
											return results.Count - count;
										}
										flag = true;
									}
									fastList2.Add(new ControllerInfo(ControllerType.Mouse, id3));
								}
							}
							num &= -5;
						}
						if ((controllerType == ControllerType.Keyboard || flag2) && (num & 2) != 0)
						{
							if (player.controllers.hasKeyboard)
							{
								int id3 = ReInput.controllers.Keyboard.id;
								if (!Contains(fastList2, ControllerType.Keyboard, id3))
								{
									if (GetElementMapsWithAction(player, ControllerType.Keyboard, id3, actionId, predicate, controllerElementTypeOrder, fastList) > 0 && GetActionElementMaps(action, actionRange, fastList, isSorted: true, options, results, ref resultsRemainingCount) > 0)
									{
										if (maxResultCount > 0 && resultsRemainingCount <= 0)
										{
											return results.Count - count;
										}
										flag = true;
									}
									fastList2.Add(new ControllerInfo(ControllerType.Keyboard, id3));
								}
							}
							num &= -3;
						}
						if (useFirstControllerResults && flag)
						{
							return results.Count - count;
						}
						break;
					}
					}
					num2++;
				}
				if (options.useDefaultControllers)
				{
					List<ControllerElementGlyphSelectorOptions.ControllerSelector> defaultControllers = options.defaultControllers;
					int num3 = defaultControllers?.Count ?? 0;
					for (int m = 0; m < num3; m++)
					{
						ControllerElementGlyphSelectorOptions.ControllerSelector controllerSelector = defaultControllers[m];
						List<ControllerElementGlyphSelectorOptions.ControllerMapSelector> controllerMapSelectors = controllerSelector.controllerMapSelectors;
						if (controllerMapSelectors != null)
						{
							int count2 = controllerMapSelectors.Count;
							ControllerIdentifier blank = ControllerIdentifier.Blank;
							blank.controllerType = controllerSelector.controllerType;
							blank.hardwareTypeGuid = controllerSelector.hardwareTypeGuid;
							blank.hardwareIdentifier = controllerSelector.hardwareIdentifier;
							for (int n = 0; n < count2; n++)
							{
								ControllerMap controllerMap = DefaultControllerMapCache.instance.GetControllerMap(player.id, blank, controllerMapSelectors[n].mapCategoryName, controllerMapSelectors[n].layoutName);
								if (controllerMap != null)
								{
									controllerMap.enabled = true;
									if (GetElementMapsWithAction(controllerMap, actionId, predicate, controllerElementTypeOrder, fastList) > 0 && GetActionElementMaps(action, actionRange, fastList, isSorted: true, options, results, ref resultsRemainingCount) > 0 && maxResultCount > 0 && resultsRemainingCount <= 0)
									{
										return results.Count - count;
									}
								}
							}
						}
						if (useFirstControllerResults && results.Count - count > 0)
						{
							return results.Count - count;
						}
					}
				}
				return results.Count - count;
			}
			finally
			{
				aemFastListPool.Return(fastList);
				controllerInfoFastListPool.Return(fastList2);
			}
		}

		private static int GetActionElementMaps(InputAction action, AxisRange actionRange, FastList<ActionElementMap> aems, bool isSorted, ControllerElementGlyphSelectorOptions options, List<ActionElementMapPair> results, ref int resultsRemainingCount)
		{
			if (aems == null || results == null)
			{
				throw new ArgumentNullException();
			}
			if (resultsRemainingCount == 0)
			{
				return 0;
			}
			FastList<bool> usedPooledList = GetUsedPooledList(aems.Count);
			int count = results.Count;
			bool flag = action.type == InputActionType.Axis;
			if (!isSorted && options != null)
			{
				SortByElementType(aems, options.controllerElementTypeOrder);
			}
			ControllerElementType controllerElementType = ControllerElementType.Axis;
			if (options != null)
			{
				ControllerElementType[] controllerElementTypeOrder = options.controllerElementTypeOrder;
				for (int i = 0; i < controllerElementTypeOrder.Length; i++)
				{
					if (controllerElementTypeOrder[i] == ControllerElementType.Axis)
					{
						controllerElementType = ControllerElementType.Axis;
						break;
					}
					if (controllerElementTypeOrder[i] == ControllerElementType.Button)
					{
						controllerElementType = ControllerElementType.Button;
						break;
					}
				}
			}
			if (flag)
			{
				if (actionRange == AxisRange.Full)
				{
					if (controllerElementType == ControllerElementType.Button)
					{
						FindButtonBindingPairsOnly(aems, usedPooledList, results, ref resultsRemainingCount);
						if (resultsRemainingCount > 0 && resultsRemainingCount <= 0)
						{
							return results.Count - count;
						}
					}
					FindFullAxisBindingsOnly(aems, usedPooledList, results, ref resultsRemainingCount);
					if (resultsRemainingCount > 0 && resultsRemainingCount <= 0)
					{
						return results.Count - count;
					}
					FindSplitAxisBindingPairsOnly(aems, usedPooledList, results, ref resultsRemainingCount);
					if (resultsRemainingCount > 0 && resultsRemainingCount <= 0)
					{
						return results.Count - count;
					}
					if (controllerElementType != ControllerElementType.Button)
					{
						FindButtonBindingPairsOnly(aems, usedPooledList, results, ref resultsRemainingCount);
						if (resultsRemainingCount > 0 && resultsRemainingCount <= 0)
						{
							return results.Count - count;
						}
					}
					FindSplitAxisAndButtonBindingPairsAndRemaining(aems, usedPooledList, results, ref resultsRemainingCount);
					if (resultsRemainingCount > 0 && resultsRemainingCount <= 0)
					{
						return results.Count - count;
					}
				}
				else
				{
					FindBindings(aems, usedPooledList, actionRange, results, ref resultsRemainingCount);
				}
			}
			else
			{
				FindBindings(aems, usedPooledList, actionRange, results, ref resultsRemainingCount);
			}
			boolFastListPool.Return(usedPooledList);
			return results.Count - count;
		}

		private static int GetActionElementMaps(int playerId, int actionId, int actionId2, ControllerElementGlyphSelectorOptions options, Predicate<ActionElementMap> isAemAllowedHandlerOverride, List<Pair<ActionElementMapPair>> results, int maxResultCount)
		{
			if (!ReInput.isReady)
			{
				return 0;
			}
			if (options == null)
			{
				return 0;
			}
			if (results == null)
			{
				return 0;
			}
			if (maxResultCount < 0)
			{
				maxResultCount = 0;
			}
			InputAction action = ReInput.mapping.GetAction(actionId);
			if (action == null)
			{
				return 0;
			}
			InputAction action2 = ReInput.mapping.GetAction(actionId2);
			if (action2 == null)
			{
				return 0;
			}
			if (action2 == action)
			{
				return 0;
			}
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return 0;
			}
			ControllerElementType[] controllerElementTypeOrder = options.controllerElementTypeOrder;
			int count = results.Count;
			int resultsRemainingCount = ((maxResultCount > 0) ? maxResultCount : (-1));
			bool useFirstControllerResults = options.useFirstControllerResults;
			Controller controller = player.controllers.GetLastActiveController();
			FastList<ActionElementMap> fastList = aemFastListPool.Get();
			FastList<ActionElementMap> fastList2 = aemFastListPool.Get();
			FastList<ControllerInfo> fastList3 = controllerInfoFastListPool.Get();
			try
			{
				Predicate<ActionElementMap> predicate = null;
				if (isAemAllowedHandlerOverride != null)
				{
					predicate = isAemAllowedHandlerOverride;
				}
				else if (options != null)
				{
					predicate = options.isActionElementMapAllowedHandler;
				}
				if (predicate == null)
				{
					predicate = defaultGetElementMapsWithActionisAllowedHandler;
				}
				if (options.useLastActiveController && controller != null)
				{
					Controller controller2 = null;
					if (controller.type == ControllerType.Keyboard || controller.type == ControllerType.Mouse)
					{
						if (IsMousePrioritizedOverKeyboard(options))
						{
							if (ReInput.controllers.Mouse.enabled && player.controllers.hasMouse)
							{
								controller = ReInput.controllers.Mouse;
								controller2 = ReInput.controllers.Keyboard;
							}
						}
						else if (ReInput.controllers.Keyboard.enabled && player.controllers.hasKeyboard)
						{
							controller = ReInput.controllers.Keyboard;
							controller2 = ReInput.controllers.Mouse;
						}
					}
					if (!Contains(fastList3, controller.type, controller.id) && GetElementMapsWithAction(player, controller.type, controller.id, actionId, actionId2, predicate, controllerElementTypeOrder, fastList, fastList2) > 0)
					{
						if (Action2DHelper.GetActionElementMaps(fastList, fastList2, controllerElementTypeOrder, results, ref resultsRemainingCount) > 0 && maxResultCount > 0 && resultsRemainingCount <= 0)
						{
							return results.Count - count;
						}
						fastList3.Add(new ControllerInfo(controller.type, controller.id));
					}
					if (controller2 != null && !Contains(fastList3, controller2.type, controller2.id))
					{
						if (GetElementMapsWithAction(player, controller2.type, controller2.id, actionId, actionId2, predicate, controllerElementTypeOrder, fastList, fastList2) > 0 && Action2DHelper.GetActionElementMaps(fastList, fastList2, controllerElementTypeOrder, results, ref resultsRemainingCount) > 0 && maxResultCount > 0 && resultsRemainingCount <= 0)
						{
							return results.Count - count;
						}
						fastList3.Add(new ControllerInfo(controller2.type, controller2.id));
					}
					if (useFirstControllerResults && results.Count - count > 0)
					{
						return results.Count - count;
					}
					ControllerType type = controller.type;
					switch (type)
					{
					case ControllerType.Joystick:
					{
						for (int j = 0; j < player.controllers.joystickCount; j++)
						{
							int id2 = player.controllers.Joysticks[j].id;
							if (!Contains(fastList3, type, id2))
							{
								if (GetElementMapsWithAction(player, type, id2, actionId, actionId2, predicate, controllerElementTypeOrder, fastList, fastList2) > 0 && Action2DHelper.GetActionElementMaps(fastList, fastList2, controllerElementTypeOrder, results, ref resultsRemainingCount) > 0 && (useFirstControllerResults || (maxResultCount > 0 && resultsRemainingCount <= 0)))
								{
									return results.Count - count;
								}
								fastList3.Add(new ControllerInfo(type, id2));
							}
						}
						break;
					}
					case ControllerType.Custom:
					{
						for (int i = 0; i < player.controllers.customControllerCount; i++)
						{
							int id = player.controllers.CustomControllers[i].id;
							if (!Contains(fastList3, type, id))
							{
								if (GetElementMapsWithAction(player, type, id, actionId, actionId2, predicate, controllerElementTypeOrder, fastList, fastList2) > 0 && Action2DHelper.GetActionElementMaps(fastList, fastList2, controllerElementTypeOrder, results, ref resultsRemainingCount) > 0 && (useFirstControllerResults || (maxResultCount > 0 && resultsRemainingCount <= 0)))
								{
									return results.Count - count;
								}
								fastList3.Add(new ControllerInfo(type, id));
							}
						}
						break;
					}
					}
				}
				int num = 15;
				ControllerType[] controllerTypeOrder = options.controllerTypeOrder;
				int num2 = 0;
				while (num != 0)
				{
					ControllerType controllerType;
					if (num2 < controllerTypeOrder.Length)
					{
						controllerType = controllerTypeOrder[num2];
					}
					else if ((num & 1) != 0)
					{
						controllerType = ControllerType.Joystick;
					}
					else if ((num & 4) != 0)
					{
						controllerType = ControllerType.Mouse;
					}
					else if ((num & 2) != 0)
					{
						controllerType = ControllerType.Keyboard;
					}
					else
					{
						if ((num & 8) == 0)
						{
							throw new NotImplementedException();
						}
						controllerType = ControllerType.Custom;
					}
					switch (controllerType)
					{
					case ControllerType.Joystick:
					{
						if ((num & 1) == 0)
						{
							break;
						}
						for (int k = 0; k < player.controllers.joystickCount; k++)
						{
							int id3 = player.controllers.Joysticks[k].id;
							if (!Contains(fastList3, controllerType, id3))
							{
								if (GetElementMapsWithAction(player, controllerType, id3, actionId, actionId2, predicate, controllerElementTypeOrder, fastList, fastList2) > 0 && Action2DHelper.GetActionElementMaps(fastList, fastList2, controllerElementTypeOrder, results, ref resultsRemainingCount) > 0 && (useFirstControllerResults || (maxResultCount > 0 && resultsRemainingCount <= 0)))
								{
									return results.Count - count;
								}
								fastList3.Add(new ControllerInfo(controllerType, id3));
							}
						}
						num &= -2;
						break;
					}
					case ControllerType.Custom:
					{
						if ((num & 8) == 0)
						{
							break;
						}
						for (int l = 0; l < player.controllers.customControllerCount; l++)
						{
							int id3 = player.controllers.CustomControllers[l].id;
							if (!Contains(fastList3, controllerType, id3))
							{
								if (GetElementMapsWithAction(player, controllerType, id3, actionId, actionId2, predicate, controllerElementTypeOrder, fastList, fastList2) > 0 && Action2DHelper.GetActionElementMaps(fastList, fastList2, controllerElementTypeOrder, results, ref resultsRemainingCount) > 0 && (useFirstControllerResults || (maxResultCount > 0 && resultsRemainingCount <= 0)))
								{
									return results.Count - count;
								}
								fastList3.Add(new ControllerInfo(controllerType, id3));
							}
						}
						num &= -9;
						break;
					}
					case ControllerType.Keyboard:
					case ControllerType.Mouse:
					{
						bool flag = false;
						bool flag2 = useFirstControllerResults;
						if ((controllerType == ControllerType.Mouse || flag2) && (num & 4) != 0)
						{
							if (player.controllers.hasMouse)
							{
								int id3 = ReInput.controllers.Mouse.id;
								if (!Contains(fastList3, ControllerType.Mouse, id3))
								{
									if (GetElementMapsWithAction(player, ControllerType.Mouse, id3, actionId, actionId2, predicate, controllerElementTypeOrder, fastList, fastList2) > 0 && Action2DHelper.GetActionElementMaps(fastList, fastList2, controllerElementTypeOrder, results, ref resultsRemainingCount) > 0)
									{
										if (useFirstControllerResults || (maxResultCount > 0 && resultsRemainingCount <= 0))
										{
											return results.Count - count;
										}
										flag = true;
									}
									fastList3.Add(new ControllerInfo(ControllerType.Mouse, id3));
								}
							}
							num &= -5;
						}
						if ((controllerType == ControllerType.Keyboard || flag2) && (num & 2) != 0)
						{
							if (player.controllers.hasKeyboard)
							{
								int id3 = ReInput.controllers.Keyboard.id;
								if (!Contains(fastList3, ControllerType.Keyboard, id3))
								{
									if (GetElementMapsWithAction(player, ControllerType.Keyboard, id3, actionId, actionId2, predicate, controllerElementTypeOrder, fastList, fastList2) > 0 && Action2DHelper.GetActionElementMaps(fastList, fastList2, controllerElementTypeOrder, results, ref resultsRemainingCount) > 0)
									{
										if (useFirstControllerResults || (maxResultCount > 0 && resultsRemainingCount <= 0))
										{
											return results.Count - count;
										}
										flag = true;
									}
									fastList3.Add(new ControllerInfo(ControllerType.Keyboard, id3));
								}
							}
							num &= -3;
						}
						if (useFirstControllerResults && flag)
						{
							return results.Count - count;
						}
						break;
					}
					}
					num2++;
				}
				if (options.useDefaultControllers)
				{
					List<ControllerElementGlyphSelectorOptions.ControllerSelector> defaultControllers = options.defaultControllers;
					int num3 = defaultControllers?.Count ?? 0;
					for (int m = 0; m < num3; m++)
					{
						ControllerElementGlyphSelectorOptions.ControllerSelector controllerSelector = defaultControllers[m];
						List<ControllerElementGlyphSelectorOptions.ControllerMapSelector> controllerMapSelectors = controllerSelector.controllerMapSelectors;
						if (controllerMapSelectors != null)
						{
							int count2 = controllerMapSelectors.Count;
							ControllerIdentifier blank = ControllerIdentifier.Blank;
							blank.controllerType = controllerSelector.controllerType;
							blank.hardwareTypeGuid = controllerSelector.hardwareTypeGuid;
							blank.hardwareIdentifier = controllerSelector.hardwareIdentifier;
							for (int n = 0; n < count2; n++)
							{
								ControllerMap controllerMap = DefaultControllerMapCache.instance.GetControllerMap(player.id, blank, controllerMapSelectors[n].mapCategoryName, controllerMapSelectors[n].layoutName);
								if (controllerMap != null)
								{
									controllerMap.enabled = true;
									if (GetElementMapsWithAction(controllerMap, actionId, actionId2, predicate, controllerElementTypeOrder, fastList, fastList2) > 0 && Action2DHelper.GetActionElementMaps(fastList, fastList2, controllerElementTypeOrder, results, ref resultsRemainingCount) > 0 && maxResultCount > 0 && resultsRemainingCount <= 0)
									{
										return results.Count - count;
									}
								}
							}
						}
						if (useFirstControllerResults && results.Count - count > 0)
						{
							return results.Count - count;
						}
					}
				}
				return results.Count - count;
			}
			finally
			{
				aemFastListPool.Return(fastList);
				aemFastListPool.Return(fastList2);
				controllerInfoFastListPool.Return(fastList3);
			}
		}

		private static int FindFullAxisBindingsOnly(FastList<ActionElementMap> actionElementMaps, FastList<bool> usedAems, List<ActionElementMapPair> results, ref int resultsRemainingCount)
		{
			if (resultsRemainingCount == 0)
			{
				return 0;
			}
			int count = results.Count;
			int count2 = actionElementMaps.Count;
			for (int i = 0; i < count2; i++)
			{
				if (usedAems.Array[i])
				{
					continue;
				}
				ActionElementMap actionElementMap = actionElementMaps.Array[i];
				if (actionElementMap.elementType == ControllerElementType.Axis && actionElementMap.axisType == AxisType.Normal)
				{
					results.Add(new ActionElementMapPair(actionElementMap, null));
					usedAems.Array[i] = true;
					if (!AllowMoreResultsDecrement(ref resultsRemainingCount))
					{
						return results.Count - count;
					}
				}
			}
			return results.Count - count;
		}

		private static int FindBindings(FastList<ActionElementMap> actionElementMaps, FastList<bool> usedAems, AxisRange actionRange, List<ActionElementMapPair> results, ref int resultsRemainingCount)
		{
			if (actionElementMaps.Count == 0)
			{
				return 0;
			}
			if (resultsRemainingCount == 0)
			{
				return 0;
			}
			int count = results.Count;
			int count2 = actionElementMaps.Count;
			for (int i = 0; i < count2; i++)
			{
				if (usedAems.Array[i])
				{
					continue;
				}
				ActionElementMap actionElementMap = actionElementMaps.Array[i];
				if (actionRange != AxisRange.Full)
				{
					if ((uint)(actionRange - 1) > 1u)
					{
						continue;
					}
					Pole pole = ((actionRange != AxisRange.Positive) ? Pole.Negative : Pole.Positive);
					ActionElementMap negativeResult;
					ActionElementMap positiveResult;
					if (actionElementMap.axisType == AxisType.Split || actionElementMap.elementType == ControllerElementType.Button)
					{
						if (actionElementMap.axisContribution == pole)
						{
							results.Add(Create(actionElementMap, pole));
							usedAems.Array[i] = true;
							if (!AllowMoreResultsDecrement(ref resultsRemainingCount))
							{
								return results.Count - count;
							}
						}
					}
					else if (actionElementMap.axisType == AxisType.Normal && ActionElementMapHelper.TryGetSplitAxisMaps(actionElementMap, out negativeResult, out positiveResult))
					{
						results.Add(Create((negativeResult.axisContribution == pole) ? negativeResult : positiveResult, pole));
						usedAems.Array[i] = true;
						if (!AllowMoreResultsDecrement(ref resultsRemainingCount))
						{
							return results.Count - count;
						}
					}
				}
				else if (actionElementMap.axisRange == AxisRange.Full && actionElementMap.elementType == ControllerElementType.Axis)
				{
					results.Add(new ActionElementMapPair(actionElementMap, null));
					usedAems.Array[i] = true;
					if (!AllowMoreResultsDecrement(ref resultsRemainingCount))
					{
						return results.Count - count;
					}
				}
			}
			if (actionRange == AxisRange.Full)
			{
				for (int j = 0; j < count2; j++)
				{
					if (usedAems.Array[j])
					{
						continue;
					}
					bool flag = false;
					ActionElementMap actionElementMap = actionElementMaps.Array[j];
					if ((actionElementMap.axisType != AxisType.Split && actionElementMap.elementType != ControllerElementType.Button) || actionElementMap.axisContribution != Pole.Positive)
					{
						continue;
					}
					for (int k = count; k < results.Count; k++)
					{
						if (results[k].a == actionElementMap && results[k].b == null)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						results.Add(new ActionElementMapPair(actionElementMap, null));
						usedAems.Array[j] = true;
						if (!AllowMoreResultsDecrement(ref resultsRemainingCount))
						{
							return results.Count - count;
						}
					}
				}
			}
			return results.Count - count;
		}

		private static int FindSplitAxisBindingPairsOnly(FastList<ActionElementMap> actionElementMaps, FastList<bool> usedAems, List<ActionElementMapPair> results, ref int resultsRemainingCount)
		{
			if (resultsRemainingCount == 0)
			{
				return 0;
			}
			int count = results.Count;
			int count2 = actionElementMaps.Count;
			ActionElementMapPair destination = default(ActionElementMapPair);
			for (int i = 0; i < count2; i++)
			{
				if (usedAems.Array[i])
				{
					continue;
				}
				ActionElementMap actionElementMap = actionElementMaps.Array[i];
				if (actionElementMap.elementType != ControllerElementType.Axis || actionElementMap.axisType == AxisType.Normal || actionElementMap.axisType == AxisType.None)
				{
					continue;
				}
				Pole pole = ((actionElementMap.axisContribution == Pole.Positive) ? Pole.Negative : Pole.Positive);
				int index;
				ActionElementMap actionElementMap2 = Find(actionElementMaps, 0, ControllerElementType.Axis, actionElementMap.elementIdentifierId, AxisType.Split, pole, out index, usedAems);
				if (actionElementMap2 == null)
				{
					actionElementMap2 = Find(actionElementMaps, 0, ControllerElementType.Axis, AxisType.Split, pole, out index, usedAems);
				}
				if (actionElementMap2 != null)
				{
					Set(actionElementMap, actionElementMap.axisContribution, ref destination);
					Set(actionElementMap2, pole, ref destination);
					results.Add(destination);
					Clear(ref destination);
					usedAems.Array[i] = true;
					usedAems.Array[index] = true;
					if (!AllowMoreResultsDecrement(ref resultsRemainingCount))
					{
						return results.Count - count;
					}
				}
			}
			return results.Count - count;
		}

		private static int FindButtonBindingPairsOnly(FastList<ActionElementMap> actionElementMaps, FastList<bool> usedAems, List<ActionElementMapPair> results, ref int resultsRemainingCount)
		{
			if (resultsRemainingCount == 0)
			{
				return 0;
			}
			int count = results.Count;
			int count2 = actionElementMaps.Count;
			ActionElementMapPair destination = default(ActionElementMapPair);
			for (int i = 0; i < count2; i++)
			{
				if (usedAems.Array[i])
				{
					continue;
				}
				ActionElementMap actionElementMap = actionElementMaps.Array[i];
				if (actionElementMap.elementType != ControllerElementType.Button)
				{
					continue;
				}
				Pole pole = ((actionElementMap.axisContribution == Pole.Positive) ? Pole.Negative : Pole.Positive);
				int index;
				ActionElementMap actionElementMap2 = Find(actionElementMaps, 0, ControllerElementType.Button, AxisType.None, pole, out index, usedAems);
				if (actionElementMap2 != null)
				{
					Set(actionElementMap, actionElementMap.axisContribution, ref destination);
					Set(actionElementMap2, pole, ref destination);
					results.Add(destination);
					Clear(ref destination);
					usedAems.Array[i] = true;
					usedAems.Array[index] = true;
					if (!AllowMoreResultsDecrement(ref resultsRemainingCount))
					{
						return results.Count - count;
					}
				}
			}
			return results.Count - count;
		}

		private static int FindSplitAxisAndButtonBindingPairsAndRemaining(FastList<ActionElementMap> actionElementMaps, FastList<bool> usedAems, List<ActionElementMapPair> results, ref int resultsRemainingCount)
		{
			if (resultsRemainingCount == 0)
			{
				return 0;
			}
			int count = results.Count;
			int count2 = actionElementMaps.Count;
			ActionElementMapPair destination = default(ActionElementMapPair);
			for (int i = 0; i < count2; i++)
			{
				if (usedAems.Array[i])
				{
					continue;
				}
				ActionElementMap actionElementMap = actionElementMaps.Array[i];
				if (actionElementMap.elementType == ControllerElementType.Axis)
				{
					if (actionElementMap.axisType == AxisType.Normal || actionElementMap.axisType == AxisType.None)
					{
						continue;
					}
				}
				else if (actionElementMap.elementType != ControllerElementType.Button)
				{
					continue;
				}
				Pole pole = ((actionElementMap.axisContribution == Pole.Positive) ? Pole.Negative : Pole.Positive);
				ActionElementMap actionElementMap2;
				int index;
				if (actionElementMap.elementType == ControllerElementType.Axis)
				{
					actionElementMap2 = Find(actionElementMaps, 0, ControllerElementType.Axis, actionElementMap.elementIdentifierId, AxisType.Split, pole, out index, usedAems);
					if (actionElementMap2 == null)
					{
						actionElementMap2 = Find(actionElementMaps, 0, ControllerElementType.Axis, AxisType.Split, pole, out index, usedAems);
					}
				}
				else
				{
					actionElementMap2 = Find(actionElementMaps, 0, ControllerElementType.Button, AxisType.None, pole, out index, usedAems);
				}
				if (actionElementMap2 != null)
				{
					Set(actionElementMap, actionElementMap.axisContribution, ref destination);
					Set(actionElementMap2, pole, ref destination);
					results.Add(destination);
					Clear(ref destination);
					usedAems.Array[i] = true;
					usedAems.Array[index] = true;
					if (!AllowMoreResultsDecrement(ref resultsRemainingCount))
					{
						return results.Count - count;
					}
				}
			}
			for (int j = 0; j < count2; j++)
			{
				if (usedAems.Array[j])
				{
					continue;
				}
				ActionElementMap actionElementMap = actionElementMaps.Array[j];
				if (actionElementMap.elementType == ControllerElementType.Axis)
				{
					if (actionElementMap.axisType == AxisType.Normal || actionElementMap.axisType == AxisType.None)
					{
						continue;
					}
				}
				else if (actionElementMap.elementType != ControllerElementType.Button)
				{
					continue;
				}
				if (Get(destination, actionElementMap.axisContribution) == null)
				{
					Set(actionElementMap, actionElementMap.axisContribution, ref destination);
					usedAems.Array[j] = true;
				}
				if (destination.Count == 2)
				{
					results.Add(destination);
					Clear(ref destination);
					if (!AllowMoreResultsDecrement(ref resultsRemainingCount))
					{
						return results.Count - count;
					}
				}
			}
			if (destination.Count > 0)
			{
				results.Add(destination);
				AllowMoreResultsDecrement(ref resultsRemainingCount);
				return results.Count - count;
			}
			return results.Count - count;
		}

		private static int GetElementMapsWithAction(Player player, ControllerType controllerType, int controllerId, int actionId, Predicate<ActionElementMap> isAllowedPredicate, ControllerElementType[] searchOrder, FastList<ActionElementMap> results)
		{
			results.Clear();
			player.controllers.maps.GetElementMapsWithAction(controllerType, controllerId, actionId, skipDisabledMaps: false, GetElementMapsWithAction_tempAems);
			SortByElementType(GetElementMapsWithAction_tempAems, searchOrder, results);
			RemoveInvalidElementMaps(player, results, 0, isAllowedPredicate);
			GetElementMapsWithAction_tempAems.Clear();
			return results.Count;
		}

		private static int GetElementMapsWithAction(ControllerMap controllerMap, int actionId, Predicate<ActionElementMap> isAllowedPredicate, ControllerElementType[] searchOrder, FastList<ActionElementMap> results)
		{
			results.Clear();
			if (controllerMap == null)
			{
				return 0;
			}
			controllerMap.GetElementMapsWithAction(actionId, skipDisabledMaps: false, GetElementMapsWithAction_tempAems);
			SortByElementType(GetElementMapsWithAction_tempAems, searchOrder, results);
			RemoveInvalidElementMaps(results, 0, isAllowedPredicate);
			GetElementMapsWithAction_tempAems.Clear();
			return results.Count;
		}

		private static int GetElementMapsWithAction(Player player, ControllerType controllerType, int controllerId, int actionId, int actionId2, Predicate<ActionElementMap> isAllowedPredicate, ControllerElementType[] searchOrder, FastList<ActionElementMap> action1Results, FastList<ActionElementMap> action2Results)
		{
			action1Results.Clear();
			action2Results.Clear();
			player.controllers.maps.GetElementMapsWithAction(controllerType, controllerId, actionId, skipDisabledMaps: false, GetElementMapsWithAction_tempAems);
			SortByElementType(GetElementMapsWithAction_tempAems, searchOrder, action1Results);
			RemoveInvalidElementMaps(player, action1Results, 0, isAllowedPredicate);
			player.controllers.maps.GetElementMapsWithAction(controllerType, controllerId, actionId2, skipDisabledMaps: false, GetElementMapsWithAction_tempAems);
			SortByElementType(GetElementMapsWithAction_tempAems, searchOrder, action2Results);
			RemoveInvalidElementMaps(player, action2Results, 0, isAllowedPredicate);
			GetElementMapsWithAction_tempAems.Clear();
			return action1Results.Count + action2Results.Count;
		}

		private static int GetElementMapsWithAction(ControllerMap controllerMap, int actionId, int actionId2, Predicate<ActionElementMap> isAllowedPredicate, ControllerElementType[] searchOrder, FastList<ActionElementMap> action1Results, FastList<ActionElementMap> action2Results)
		{
			action1Results.Clear();
			action2Results.Clear();
			if (controllerMap == null)
			{
				return 0;
			}
			controllerMap.GetElementMapsWithAction(actionId, skipDisabledMaps: false, GetElementMapsWithAction_tempAems);
			SortByElementType(GetElementMapsWithAction_tempAems, searchOrder, action1Results);
			RemoveInvalidElementMaps(action1Results, 0, isAllowedPredicate);
			controllerMap.GetElementMapsWithAction(actionId2, skipDisabledMaps: false, GetElementMapsWithAction_tempAems);
			SortByElementType(GetElementMapsWithAction_tempAems, searchOrder, action2Results);
			RemoveInvalidElementMaps(action2Results, 0, isAllowedPredicate);
			GetElementMapsWithAction_tempAems.Clear();
			return action1Results.Count + action2Results.Count;
		}

		private static int RemoveInvalidElementMaps(Player player, FastList<ActionElementMap> results, int startIndex, Predicate<ActionElementMap> isAllowedPredicate)
		{
			int count = results.Count;
			for (int num = count - 1; num >= startIndex; num--)
			{
				if (!player.controllers.ContainsController(results.Array[num].controllerMap.controller) || !results.Array[num].controllerMap.controller.enabled)
				{
					results.RemoveAt(num);
				}
			}
			RemoveInvalidElementMaps(results, startIndex, isAllowedPredicate);
			return results.Count - count;
		}

		private static int RemoveInvalidElementMaps(FastList<ActionElementMap> results, int startIndex, Predicate<ActionElementMap> isAllowedPredicate)
		{
			int count = results.Count;
			if (isAllowedPredicate != null)
			{
				int num = results.Count;
				for (int i = startIndex; i < num; i++)
				{
					bool flag = false;
					try
					{
						if (!isAllowedPredicate(results.Array[i]))
						{
							flag = true;
						}
					}
					catch (Exception ex)
					{
						Debug.LogError("Rewired: An exception was thrown in isAllowedPredicate callback. This exception was thrown by your code.\n" + ex);
						continue;
					}
					if (flag)
					{
						results.RemoveAt(i);
						num--;
						i--;
					}
				}
			}
			return results.Count - count;
		}

		private static ActionElementMap Find(FastList<ActionElementMap> list, int startIndex, ControllerElementType controllerElementType, AxisType axisType, out int index, FastList<bool> used)
		{
			int count = list.Count;
			for (int i = startIndex; i < count; i++)
			{
				if (!used.Array[i])
				{
					ActionElementMap actionElementMap = list.Array[i];
					if (actionElementMap.elementType == controllerElementType && actionElementMap.axisType == axisType)
					{
						index = i;
						return actionElementMap;
					}
				}
			}
			index = -1;
			return null;
		}

		private static ActionElementMap Find(FastList<ActionElementMap> list, int startIndex, ControllerElementType controllerElementType, AxisType axisType, Pole axisContribution, out int index, FastList<bool> used)
		{
			int count = list.Count;
			for (int i = startIndex; i < count; i++)
			{
				if (!used.Array[i])
				{
					ActionElementMap actionElementMap = list.Array[i];
					if (actionElementMap.elementType == controllerElementType && actionElementMap.axisType == axisType && actionElementMap.axisContribution == axisContribution)
					{
						index = i;
						return actionElementMap;
					}
				}
			}
			index = -1;
			return null;
		}

		private static ActionElementMap Find(FastList<ActionElementMap> list, int startIndex, ControllerElementType controllerElementType, int elementIdentifierId, AxisType axisType, Pole axisContribution, out int index, FastList<bool> used)
		{
			int count = list.Count;
			for (int i = startIndex; i < count; i++)
			{
				if (!used.Array[i])
				{
					ActionElementMap actionElementMap = list.Array[i];
					if (actionElementMap.elementType == controllerElementType && actionElementMap.elementIdentifierId == elementIdentifierId && actionElementMap.axisType == axisType && actionElementMap.axisContribution == axisContribution)
					{
						index = i;
						return actionElementMap;
					}
				}
			}
			index = -1;
			return null;
		}

		private static bool Contains(FastList<ControllerInfo> list, ControllerType type, int id)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list.Array[i].type == type && list.Array[i].controllerId == id)
				{
					return true;
				}
			}
			return false;
		}

		private static Pair<ActionElementMapPair> Create(ActionElementMapPair a, ActionElementMapPair b, bool reverse)
		{
			if (reverse)
			{
				return new Pair<ActionElementMapPair>(b, a);
			}
			return new Pair<ActionElementMapPair>(a, b);
		}

		private static ActionElementMapPair Create(ActionElementMap aem, Pole pole)
		{
			return pole switch
			{
				Pole.Positive => new ActionElementMapPair(null, aem), 
				Pole.Negative => new ActionElementMapPair(aem, null), 
				_ => throw new NotImplementedException(), 
			};
		}

		private static bool TryCreate(ActionElementMap aem1, ActionElementMap aem2, out ActionElementMapPair result)
		{
			result = default(ActionElementMapPair);
			bool flag = false;
			for (int i = 0; i < 2; i++)
			{
				ActionElementMap actionElementMap = ((i == 0) ? aem1 : aem2);
				if (actionElementMap == null)
				{
					continue;
				}
				if (actionElementMap.axisContribution == Pole.Negative)
				{
					if (result.a != null)
					{
						flag = true;
					}
					else
					{
						result.a = actionElementMap;
					}
				}
				else if (result.b != null)
				{
					flag = true;
				}
				else
				{
					result.b = actionElementMap;
				}
			}
			return !flag;
		}

		private static bool SetAndAddIfFull(ActionElementMapPair item, int index, ref Pair<ActionElementMapPair> target, List<Pair<ActionElementMapPair>> items)
		{
			bool result = false;
			if (!TrySet(item, index, ref target))
			{
				items.Add(target);
				result = true;
				Clear(ref target);
				TrySet(item, index, ref target);
			}
			if (target.a.Count > 0 && target.b.Count > 0)
			{
				items.Add(target);
				result = true;
				Clear(ref target);
			}
			return result;
		}

		private static bool TrySet(ActionElementMapPair item, int index, ref Pair<ActionElementMapPair> target)
		{
			switch (index)
			{
			case 0:
				if (target.a.Count > 0)
				{
					return false;
				}
				target.a = item;
				return true;
			case 1:
				if (target.b.Count > 0)
				{
					return false;
				}
				target.b = item;
				return true;
			default:
				throw new ArgumentOutOfRangeException("index");
			}
		}

		private static void Set(ActionElementMap aem, Pole pole, ref ActionElementMapPair destination)
		{
			switch (pole)
			{
			case Pole.Positive:
				destination.b = aem;
				break;
			case Pole.Negative:
				destination.a = aem;
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private static ActionElementMap Get(ActionElementMapPair source, Pole pole)
		{
			return pole switch
			{
				Pole.Positive => source.b, 
				Pole.Negative => source.a, 
				_ => throw new NotImplementedException(), 
			};
		}

		private static void Clear(ref Pair<ActionElementMapPair> target)
		{
			Clear(ref target.a);
			Clear(ref target.b);
		}

		private static void Clear(ref ActionElementMapPair target)
		{
			target.a = null;
			target.b = null;
		}

		private static void SortByElementType(List<ActionElementMap> aems, ControllerElementType[] controllerElementTypes, FastList<ActionElementMap> results)
		{
			results.Clear();
			results.ReplaceFrom(aems);
			SortByElementType(results, controllerElementTypes);
		}

		private static void SortByElementType(FastList<ActionElementMap> aems, ControllerElementType[] controllerElementTypes)
		{
			FastList<ActionElementMap> fastList = aemFastListPool.Get();
			FastList<bool> usedPooledList = GetUsedPooledList(aems.Count);
			for (int i = 0; i < controllerElementTypes.Length; i++)
			{
				for (int j = 0; j < aems.Count; j++)
				{
					if (aems.Array[j].elementType == controllerElementTypes[i])
					{
						fastList.Add(aems.Array[j]);
						usedPooledList.Array[j] = true;
					}
				}
			}
			if (fastList.Count < aems.Count)
			{
				for (int k = 0; k < aems.Count; k++)
				{
					if (!usedPooledList.Array[k])
					{
						fastList.Add(aems.Array[k]);
					}
				}
			}
			aems.ReplaceFrom(fastList);
			aemFastListPool.Return(fastList);
			boolFastListPool.Return(usedPooledList);
		}

		private static bool AllowMoreResultsDecrement(ref int remainingCount)
		{
			if (remainingCount < 0)
			{
				return true;
			}
			remainingCount--;
			if (remainingCount < 0)
			{
				remainingCount = 0;
			}
			return remainingCount > 0;
		}

		private static FastList<bool> GetUsedPooledList(int count)
		{
			FastList<bool> fastList = boolFastListPool.Get();
			fastList.SetCount(count);
			return fastList;
		}

		private static void ReturnUsedPoolList(FastList<bool> list)
		{
			boolFastListPool.Return(list);
		}
	}
}

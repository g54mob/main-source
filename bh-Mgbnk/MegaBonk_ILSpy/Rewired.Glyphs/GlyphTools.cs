using System;
using System.Collections.Generic;

namespace Rewired.Glyphs;

public static class GlyphTools
{
	public unsafe static bool TryGetActionElementMaps(int playerId, int actionId, AxisRange actionRange, ControllerElementGlyphSelectorOptions options, List<ActionElementMap> workingActionElementMaps, out ActionElementMap aemResult1, out ActionElementMap aemResult2)
	{
		//IL_08dd: Expected O, but got I4
		//IL_08cb: Expected I4, but got O
		//IL_084b: Expected O, but got I4
		//IL_072f: Expected O, but got I4
		//IL_0769: Expected O, but got I4
		//IL_0977: Expected O, but got I4
		ref ActionElementMap aemResult3 = ref *(ActionElementMap*)null;
		object obj = 0;
		List<ActionElementMap> list = default(List<ActionElementMap>);
		if (!ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF || options == null || list == null)
		{
			goto IL_08af;
		}
		ReInput.MappingHelper mapping = ReInput.mapping;
		InputAction action;
		Player player;
		Controller lastActiveController;
		Controller controller;
		Controller controller2;
		Mouse mouse;
		if (mapping != null)
		{
			action = mapping.GetAction(actionId);
			if (action == null)
			{
				goto IL_08af;
			}
			ReInput.PlayerHelper players = ReInput.players;
			if (players != null)
			{
				player = players.GetPlayer(playerId);
				if (player == null)
				{
					goto IL_08af;
				}
				if (player.controllers != null)
				{
					lastActiveController = player.controllers.GetLastActiveController();
					int version = list._version + 1;
					list._version = version;
					list._size = 0;
					if (list._size > 0)
					{
						Array.Clear(list._items, 0, list._size);
					}
					if (!options._useLastActiveController || lastActiveController == null)
					{
						goto IL_06d2;
					}
					if (lastActiveController.type != ControllerType.Keyboard)
					{
						ControllerType type = lastActiveController.type;
						bool flag = type != ControllerType.Mouse;
						controller = null;
						controller2 = lastActiveController;
						if (flag)
						{
							goto IL_0582;
						}
					}
					int num = 0;
					ControllerType controllerType;
					while (options.TryGetControllerTypeOrder(num, out controllerType))
					{
						if (controllerType != ControllerType.Mouse)
						{
							if (controllerType != ControllerType.Keyboard)
							{
								num++;
								continue;
							}
							break;
						}
						goto IL_029c;
					}
					ReInput.ControllerHelper controllers = ReInput.controllers;
					if (controllers != null)
					{
						Keyboard keyboard = controllers.Keyboard;
						if (keyboard != null)
						{
							bool enabled = keyboard.enabled;
							bool flag2 = !enabled;
							controller = null;
							controller2 = lastActiveController;
							if (flag2)
							{
								goto IL_0582;
							}
							if (player.controllers != null)
							{
								bool hasKeyboard = player.controllers.hasKeyboard;
								bool flag3 = !hasKeyboard;
								controller = null;
								controller2 = lastActiveController;
								if (flag3)
								{
									goto IL_0582;
								}
								ReInput.ControllerHelper controllers2 = ReInput.controllers;
								if (controllers2 != null)
								{
									Keyboard keyboard2 = controllers2.Keyboard;
									ReInput.ControllerHelper controllers3 = ReInput.controllers;
									if (controllers3 != null)
									{
										mouse = controllers3.Mouse;
										controller2 = keyboard2;
										goto IL_055d;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_08bd;
		IL_0582:
		ControllerType type2 = controller2.type;
		bool flag4 = default(bool);
		List<ActionElementMap> results = default(List<ActionElementMap>);
		int elementMapsWithAction = GetElementMapsWithAction(player, type2, controller2.id, actionId, flag4, results);
		AxisRange actionRange2;
		if (elementMapsWithAction > 0)
		{
			if (TryGetActionElementMaps(action, actionRange, list, out aemResult3, out *(flag4 ? ((ActionElementMap*)1) : ((ActionElementMap*)null))))
			{
				goto IL_08a1;
			}
			actionRange2 = actionRange;
		}
		else
		{
			actionRange2 = actionRange;
		}
		if (controller != null)
		{
			ControllerType type3 = controller.type;
			int elementMapsWithAction2 = GetElementMapsWithAction(player, type3, controller.id, actionId, flag4, results);
			if (elementMapsWithAction2 > 0 && TryGetActionElementMaps(action, actionRange2, list, out aemResult3, out *(flag4 ? ((ActionElementMap*)1) : ((ActionElementMap*)null))))
			{
				goto IL_08a1;
			}
		}
		ControllerType type4 = controller2.type;
		int elementMapsWithAction3 = GetElementMapsWithAction(player, type4, actionId, skipDisabledMaps: true, (List<ActionElementMap>)flag4);
		if (elementMapsWithAction3 <= 0 || !TryGetActionElementMaps(action, actionRange2, list, out aemResult3, out *(flag4 ? ((ActionElementMap*)1) : ((ActionElementMap*)null))))
		{
			goto IL_06d2;
		}
		goto IL_08a1;
		IL_029c:
		ReInput.ControllerHelper controllers4 = ReInput.controllers;
		if (controllers4 != null)
		{
			Mouse mouse2 = controllers4.Mouse;
			if (mouse2 != null)
			{
				bool enabled2 = mouse2.enabled;
				bool flag5 = !enabled2;
				controller = null;
				controller2 = lastActiveController;
				if (flag5)
				{
					goto IL_0582;
				}
				if (player.controllers != null)
				{
					bool hasMouse = player.controllers.hasMouse;
					bool flag6 = !hasMouse;
					controller = null;
					controller2 = lastActiveController;
					if (flag6)
					{
						goto IL_0582;
					}
					ReInput.ControllerHelper controllers5 = ReInput.controllers;
					if (controllers5 != null)
					{
						Mouse mouse3 = controllers5.Mouse;
						ReInput.ControllerHelper controllers6 = ReInput.controllers;
						if (controllers6 != null)
						{
							Keyboard keyboard3 = controllers6.Keyboard;
							mouse = (Mouse)(object)keyboard3;
							controller2 = mouse3;
							goto IL_055d;
						}
					}
				}
			}
		}
		goto IL_08bd;
		IL_08bd:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_08a1:
		return true;
		IL_08af:
		return false;
		IL_055d:
		bool flag7 = controller2 == null;
		controller = mouse;
		if (!flag7)
		{
			goto IL_0582;
		}
		goto IL_08bd;
		IL_06d2:
		int index = 0;
		int num2 = 0;
		ControllerType controllerType2;
		while (options.TryGetControllerTypeOrder(index, out controllerType2))
		{
			Player.ControllerHelper controllers7 = player.controllers;
			if (player.controllers != null && controllers7.maps != null)
			{
				int elementMapsWithAction4 = controllers7.maps.GetElementMapsWithAction(controllerType2, actionId, skipDisabledMaps: true, (List<ActionElementMap>)flag4);
				int num3 = RemoveInvalidElementMaps(player, list, list._size);
				object obj2 = list._size - list._size;
				if ((nint)obj2 <= 0 || !TryGetActionElementMaps(action, actionRange, list, out aemResult3, out *(flag4 ? ((ActionElementMap*)1) : ((ActionElementMap*)null))))
				{
					num2++;
					index = num2;
					continue;
				}
				goto IL_08a1;
			}
			goto IL_08bd;
		}
		Player.ControllerHelper controllers8 = player.controllers;
		if (player.controllers != null && controllers8.maps != null)
		{
			int elementMapsWithAction5 = controllers8.maps.GetElementMapsWithAction(actionId, skipDisabledMaps: true, list);
			int num4 = RemoveInvalidElementMaps(player, list, list._size);
			object obj3 = list._size - list._size;
			if ((nint)obj3 > 0 && TryGetActionElementMaps(action, actionRange, list, out aemResult3, out *(flag4 ? ((ActionElementMap*)1) : ((ActionElementMap*)null))))
			{
				goto IL_08a1;
			}
			goto IL_08af;
		}
		goto IL_08bd;
	}

	public unsafe static bool TryGetActionElementMaps(InputAction action, AxisRange actionRange, List<ActionElementMap> tempAems, out ActionElementMap aemResult1, out ActionElementMap aemResult2)
	{
		//IL_030f: Expected O, but got I4
		//IL_02fd: Expected I4, but got O
		//IL_02dc: Expected O, but got I4
		ref ActionElementMap reference = ref *(ActionElementMap*)null;
		object obj = 0;
		if (action != null && tempAems != null)
		{
			if (tempAems._size <= 0)
			{
				goto IL_02e1;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num5 = default(int);
			object obj3 = default(object);
			object obj5 = default(object);
			int num6 = default(int);
			while (true)
			{
				ActionElementMap actionElementMap;
				object obj4;
				if (action._type != InputActionType.Axis || actionRange != AxisRange.Full)
				{
					actionElementMap = FindFirstBinding(tempAems, actionRange);
					if (actionElementMap == null)
					{
						goto IL_032c;
					}
				}
				else
				{
					actionElementMap = FindFirstFullAxisBinding(tempAems);
					if (actionElementMap == null)
					{
						bool flag = tempAems._size <= 0;
						int num4 = num5;
						object obj2 = obj3;
						num2 = num5;
						obj4 = obj3;
						if (!flag)
						{
							while (true)
							{
								ActionElementMap actionElementMap2 = tempAems.get_Item(num);
								if (actionElementMap2 == null)
								{
									break;
								}
								if (actionElementMap2._elementType != ControllerElementType.Axis)
								{
									if (actionElementMap2._elementType == ControllerElementType.Button)
									{
										goto IL_01c0;
									}
								}
								else
								{
									AxisType axisType = actionElementMap2.axisType;
									if (axisType != AxisType.Normal && actionElementMap2.axisType != AxisType.None)
									{
										goto IL_01c0;
									}
								}
								goto IL_023c;
								IL_01c0:
								if (actionElementMap2._axisContribution != Pole.Positive)
								{
									if (obj2 == null)
									{
										obj2 = obj5;
									}
								}
								else if (num4 == 0)
								{
									num4 = num6;
								}
								goto IL_023c;
								IL_023c:
								num++;
								bool flag2 = num < tempAems._size;
								num2 = num4;
								obj4 = obj2;
								if (flag2)
								{
									continue;
								}
								goto IL_027c;
							}
							break;
						}
						goto IL_027c;
					}
				}
				reference = ref *(ActionElementMap*)actionElementMap;
				goto IL_03c8;
				IL_03c8:
				return true;
				IL_032c:
				num3++;
				if (num3 < tempAems._size)
				{
					continue;
				}
				goto IL_02e1;
				IL_027c:
				if (obj4 == null && num2 <= 0)
				{
					num = 0;
					goto IL_032c;
				}
				reference = ref *(ActionElementMap*)obj4;
				obj = num2;
				goto IL_03c8;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_02e1:
		return false;
	}

	public static ActionElementMap FindFirstFullAxisBinding(List<ActionElementMap> actionElementMaps)
	{
		ActionElementMap actionElementMap;
		if (actionElementMaps != null)
		{
			bool flag = actionElementMaps._size <= 0;
			int num = 0;
			if (flag)
			{
				goto IL_00b1;
			}
			while (true)
			{
				actionElementMap = actionElementMaps.get_Item(num);
				if (actionElementMap == null)
				{
					break;
				}
				if (actionElementMap._elementType == ControllerElementType.Axis)
				{
					AxisType axisType = actionElementMap.axisType;
					if (axisType == AxisType.Normal)
					{
						goto IL_0119;
					}
				}
				num++;
				if (num < actionElementMaps._size)
				{
					continue;
				}
				goto IL_00b1;
			}
		}
		return (ActionElementMap)(object)new NullReferenceException();
		IL_0119:
		return actionElementMap;
		IL_00b1:
		actionElementMap = null;
		goto IL_0119;
	}

	public static ActionElementMap FindFirstBinding(List<ActionElementMap> actionElementMaps, AxisRange actionRange)
	{
		//IL_0063: Expected O, but got I4
		//IL_0118: Expected O, but got I4
		ActionElementMap actionElementMap;
		if (actionElementMaps != null)
		{
			if (actionElementMaps._size == 0)
			{
				goto IL_0342;
			}
			bool flag = actionElementMaps._size <= 0;
			int num = 0;
			if (flag)
			{
				goto IL_021e;
			}
			while (true)
			{
				actionElementMap = actionElementMaps.get_Item(num);
				bool flag2 = actionRange == AxisRange.Full;
				bool flag3;
				if (!flag2)
				{
					object obj = actionRange - 1;
					if (!flag2)
					{
						if ((nint)obj == 1)
						{
							if (actionElementMap == null)
							{
								break;
							}
							AxisType axisType = actionElementMap.axisType;
							if (axisType == AxisType.Split || actionElementMap.axisType == AxisType.None)
							{
								object obj2 = actionElementMap._axisContribution - 1;
								flag3 = obj2 == null;
								goto IL_0381;
							}
						}
					}
					else
					{
						if (actionElementMap == null)
						{
							break;
						}
						AxisType axisType2 = actionElementMap.axisType;
						if (axisType2 == AxisType.Split || actionElementMap.axisType == AxisType.None)
						{
							flag3 = actionElementMap._axisContribution == Pole.Positive;
							goto IL_0381;
						}
					}
					goto IL_01ef;
				}
				if (actionElementMap == null)
				{
					break;
				}
				flag3 = actionElementMap._axisRange == AxisRange.Full;
				goto IL_0381;
				IL_0381:
				if (flag3)
				{
					goto IL_03bd;
				}
				goto IL_01ef;
				IL_01ef:
				num++;
				if (num < actionElementMaps._size)
				{
					continue;
				}
				goto IL_021e;
			}
		}
		goto IL_0356;
		IL_0356:
		return (ActionElementMap)(object)new NullReferenceException();
		IL_0342:
		actionElementMap = null;
		goto IL_03bd;
		IL_03bd:
		return actionElementMap;
		IL_021e:
		if (actionRange == AxisRange.Full)
		{
			bool flag4 = actionElementMaps._size <= 0;
			int num2 = 0;
			if (!flag4)
			{
				while (true)
				{
					actionElementMap = actionElementMaps.get_Item(num2);
					if (actionElementMap == null)
					{
						break;
					}
					AxisType axisType3 = actionElementMap.axisType;
					if ((axisType3 != AxisType.Split && actionElementMap.axisType != AxisType.None) || actionElementMap._axisContribution != Pole.Positive)
					{
						num2++;
						if (num2 < actionElementMaps._size)
						{
							continue;
						}
						goto IL_0342;
					}
					goto IL_03bd;
				}
				goto IL_0356;
			}
		}
		goto IL_0342;
	}

	public unsafe static bool FindFirstSplitAxisBindingPair(List<ActionElementMap> actionElementMaps, out ActionElementMap negativeAem, out ActionElementMap positiveAem)
	{
		//IL_0202: Expected I4, but got O
		ref ActionElementMap reference = ref *(ActionElementMap*)null;
		ref ActionElementMap reference2 = ref *(ActionElementMap*)null;
		if (actionElementMaps != null)
		{
			bool flag = actionElementMaps._size <= 0;
			int num = 0;
			if (flag)
			{
				goto IL_0180;
			}
			while (true)
			{
				ActionElementMap actionElementMap = actionElementMaps.get_Item(num);
				if (actionElementMap == null)
				{
					break;
				}
				if (actionElementMap._elementType != ControllerElementType.Axis)
				{
					if (actionElementMap._elementType == ControllerElementType.Button)
					{
						goto IL_00d3;
					}
				}
				else
				{
					AxisType axisType = actionElementMap.axisType;
					if (axisType != AxisType.Normal && actionElementMap.axisType != AxisType.None)
					{
						goto IL_00d3;
					}
				}
				goto IL_0151;
				IL_00d3:
				if (actionElementMap._axisContribution != Pole.Positive)
				{
					if (negativeAem == null)
					{
						reference = ref *(ActionElementMap*)actionElementMap;
					}
				}
				else if (positiveAem == null)
				{
					reference2 = ref *(ActionElementMap*)actionElementMap;
				}
				goto IL_0151;
				IL_0151:
				num++;
				if (num < actionElementMaps._size)
				{
					continue;
				}
				goto IL_0180;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0180:
		if (negativeAem != null)
		{
			return true;
		}
		bool flag2 = (nint)positiveAem < 0;
		bool flag3 = positiveAem == null;
		bool flag4 = !flag2;
		bool flag5 = !flag3;
		return flag5 & flag4;
	}

	public static bool IsMousePrioritizedOverKeyboard(ControllerElementGlyphSelectorOptions options)
	{
		if (options != null)
		{
			ControllerType controllerType;
			for (int i = 0; options.TryGetControllerTypeOrder(i, out controllerType); i++)
			{
				switch (controllerType)
				{
				default:
					continue;
				case ControllerType.Mouse:
					return true;
				case ControllerType.Keyboard:
					break;
				}
				break;
			}
		}
		return false;
	}

	private static int GetElementMapsWithAction(Player player, ControllerType controllerType, int controllerId, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
	{
		//IL_00e2: Expected I4, but got O
		List<ActionElementMap> list = default(List<ActionElementMap>);
		if (list != null && player != null)
		{
			Player.ControllerHelper controllers = player.controllers;
			if (player.controllers != null && controllers.maps != null)
			{
				bool skipDisabledMaps2 = default(bool);
				List<ActionElementMap> results2 = default(List<ActionElementMap>);
				int elementMapsWithAction = controllers.maps.GetElementMapsWithAction(controllerType, controllerId, actionId, skipDisabledMaps2, results2);
				int num = RemoveInvalidElementMaps(player, list, list._size);
				return list._size - list._size;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private static int GetElementMapsWithAction(Player player, ControllerType controllerType, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
	{
		//IL_00de: Expected I4, but got O
		List<ActionElementMap> list = default(List<ActionElementMap>);
		if (list != null && player != null)
		{
			Player.ControllerHelper controllers = player.controllers;
			if (player.controllers != null && controllers.maps != null)
			{
				List<ActionElementMap> results2 = default(List<ActionElementMap>);
				int elementMapsWithAction = controllers.maps.GetElementMapsWithAction(controllerType, actionId, skipDisabledMaps, results2);
				int num = RemoveInvalidElementMaps(player, list, list._size);
				return list._size - list._size;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private static int GetElementMapsWithAction(Player player, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
	{
		//IL_00da: Expected I4, but got O
		if (results != null && player != null)
		{
			Player.ControllerHelper controllers = player.controllers;
			if (player.controllers != null && controllers.maps != null)
			{
				int elementMapsWithAction = controllers.maps.GetElementMapsWithAction(actionId, skipDisabledMaps, results);
				int num = RemoveInvalidElementMaps(player, results, results._size);
				return results._size - results._size;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private static int RemoveInvalidElementMaps(Player player, List<ActionElementMap> results, int startIndex)
	{
		//IL_01d9: Expected I4, but got O
		if (results != null)
		{
			int num = results._size - 1;
			if (num < startIndex)
			{
				goto IL_01af;
			}
			if (player != null)
			{
				while (true)
				{
					ActionElementMap actionElementMap = results.get_Item(num);
					if (actionElementMap == null || actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe == null)
					{
						break;
					}
					Controller controller = actionElementMap.VZbcOnbGHkbQCctumTLcvpEpIcLe.controller;
					if (player.controllers == null)
					{
						break;
					}
					if (player.controllers.ContainsController(controller))
					{
						ActionElementMap actionElementMap2 = results.get_Item(num);
						if (actionElementMap2 == null || actionElementMap2.VZbcOnbGHkbQCctumTLcvpEpIcLe == null)
						{
							break;
						}
						Controller controller2 = actionElementMap2.VZbcOnbGHkbQCctumTLcvpEpIcLe.controller;
						if (controller2 == null)
						{
							break;
						}
						if (controller2.enabled)
						{
							goto IL_0182;
						}
					}
					((List<object>)(object)results).RemoveAt(num);
					goto IL_0182;
					IL_0182:
					num--;
					if (num >= startIndex)
					{
						continue;
					}
					goto IL_01af;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
		IL_01af:
		return results._size - results._size;
	}
}

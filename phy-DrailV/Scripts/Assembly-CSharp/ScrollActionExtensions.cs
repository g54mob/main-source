using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class ScrollActionExtensions
{
	private static readonly Dictionary<ScrollAction, ScrollAction> SwitchAxisDictionary = new Dictionary<ScrollAction, ScrollAction>
	{
		{
			ScrollAction.ScrollDown,
			ScrollAction.ScrollRight
		},
		{
			ScrollAction.ScrollUp,
			ScrollAction.ScrollLeft
		},
		{
			ScrollAction.ScrollRight,
			ScrollAction.ScrollDown
		},
		{
			ScrollAction.ScrollLeft,
			ScrollAction.ScrollUp
		}
	};

	private static readonly Dictionary<ScrollAction, ScrollAction> FlipAxisDictionary = new Dictionary<ScrollAction, ScrollAction>
	{
		{
			ScrollAction.ScrollDown,
			ScrollAction.ScrollUp
		},
		{
			ScrollAction.ScrollUp,
			ScrollAction.ScrollDown
		},
		{
			ScrollAction.ScrollLeft,
			ScrollAction.ScrollRight
		},
		{
			ScrollAction.ScrollRight,
			ScrollAction.ScrollLeft
		}
	};

	public static bool IsPositive(this ScrollAction action)
	{
		if (!object.Equals(ScrollAction.ScrollUp, action))
		{
			return object.Equals(ScrollAction.ScrollRight, action);
		}
		return true;
	}

	public static bool IsHorizontal(this ScrollAction action)
	{
		if (!object.Equals(ScrollAction.ScrollRight, action))
		{
			return object.Equals(ScrollAction.ScrollLeft, action);
		}
		return true;
	}

	public static bool IsVertical(this ScrollAction action)
	{
		return !action.IsHorizontal();
	}

	public static bool IsSameAxis(this ScrollAction action, ScrollAction other)
	{
		return action.IsHorizontal() == other.IsHorizontal();
	}

	public static ScrollAction FlipAxis(this ScrollAction action)
	{
		return FlipAxisDictionary[action];
	}

	public static ScrollAction SwitchAxis(this ScrollAction action)
	{
		ScrollAction scrollAction = SwitchAxisDictionary[action];
		if (GamePreferences.Get<int>(Preferences.ScrollDownMeansRight) != 1)
		{
			return scrollAction.FlipAxis();
		}
		return scrollAction;
	}

	[Conditional("UNITY_EDITOR")]
	private static void EnsureIsDirection(ScrollAction action)
	{
		if (object.Equals(ScrollAction.Release, action))
		{
			throw new ArgumentException("Invalid argument Release. Expected one of 4 directions!");
		}
	}
}

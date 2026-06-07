using System.Collections.Generic;
using Dhs5.Utility.Console;
using Dhs5.Utility.Settings;
using UnityEngine;
using UnityEngine.InputSystem;

[Settings("Editor/OnScreen Console", Scope.User)]
public class OnScreenConsoleSettings : CustomSettings<OnScreenConsoleSettings>
{
	[Header("Predefined Commands")]
	[SerializeField]
	private List<PredefinedConsoleCommand> m_predefinedCommands;

	[Header("Inputs")]
	[SerializeField]
	private InputActionReference m_openInputRef;

	[SerializeField]
	private InputActionReference m_closeInputRef;

	[Header("GUI")]
	[Tooltip("Width of the input rect in percent of the game view")]
	[SerializeField]
	[Range(0.2f, 1f)]
	private float m_inputRectWidth = 0.8f;

	[Tooltip("Height of the input rect in pixels")]
	[SerializeField]
	[Min(10f)]
	private float m_inputRectHeight = 50f;

	[SerializeField]
	[Min(10f)]
	private int m_inputFontSize = 40;

	[SerializeField]
	[ColorUsage(false)]
	private Color m_inputTextColor = Color.white;

	[SerializeField]
	[ColorUsage(false)]
	private Color m_inputValidTextColor = Color.green;

	[Space(15f)]
	[Tooltip("Height of an option rect in pixels")]
	[SerializeField]
	private float m_optionRectHeight = 30f;

	[Tooltip("Max number of options displayed at the same time")]
	[SerializeField]
	[Min(1f)]
	private int m_maxOptionsDisplayed = 10;

	[SerializeField]
	[Min(10f)]
	private int m_optionFontSize = 30;

	[SerializeField]
	[ColorUsage(false)]
	private Color m_optionTextColor = Color.white;

	public static IEnumerable<PredefinedConsoleCommand> PredefinedCommands
	{
		get
		{
			if (!(CustomSettings<OnScreenConsoleSettings>.I != null))
			{
				return null;
			}
			return CustomSettings<OnScreenConsoleSettings>.I.m_predefinedCommands;
		}
	}

	public static float InputRectWidthPercent
	{
		get
		{
			if (!(CustomSettings<OnScreenConsoleSettings>.I != null))
			{
				return 0.8f;
			}
			return CustomSettings<OnScreenConsoleSettings>.I.m_inputRectWidth;
		}
	}

	public static float InputRectHeight
	{
		get
		{
			if (!(CustomSettings<OnScreenConsoleSettings>.I != null))
			{
				return 50f;
			}
			return CustomSettings<OnScreenConsoleSettings>.I.m_inputRectHeight;
		}
	}

	public static int InputFontSize
	{
		get
		{
			if (!(CustomSettings<OnScreenConsoleSettings>.I != null))
			{
				return 40;
			}
			return CustomSettings<OnScreenConsoleSettings>.I.m_inputFontSize;
		}
	}

	public static Color InputTextColor
	{
		get
		{
			if (!(CustomSettings<OnScreenConsoleSettings>.I != null))
			{
				return Color.white;
			}
			return CustomSettings<OnScreenConsoleSettings>.I.m_inputTextColor;
		}
	}

	public static Color InputValidTextColor
	{
		get
		{
			if (!(CustomSettings<OnScreenConsoleSettings>.I != null))
			{
				return Color.green;
			}
			return CustomSettings<OnScreenConsoleSettings>.I.m_inputValidTextColor;
		}
	}

	public static float OptionRectHeight
	{
		get
		{
			if (!(CustomSettings<OnScreenConsoleSettings>.I != null))
			{
				return 30f;
			}
			return CustomSettings<OnScreenConsoleSettings>.I.m_optionRectHeight;
		}
	}

	public static int MaxOptionsDisplayed
	{
		get
		{
			if (!(CustomSettings<OnScreenConsoleSettings>.I != null))
			{
				return 10;
			}
			return CustomSettings<OnScreenConsoleSettings>.I.m_maxOptionsDisplayed;
		}
	}

	public static int OptionFontSize
	{
		get
		{
			if (!(CustomSettings<OnScreenConsoleSettings>.I != null))
			{
				return 30;
			}
			return CustomSettings<OnScreenConsoleSettings>.I.m_optionFontSize;
		}
	}

	public static Color OptionTextColor
	{
		get
		{
			if (!(CustomSettings<OnScreenConsoleSettings>.I != null))
			{
				return Color.white;
			}
			return CustomSettings<OnScreenConsoleSettings>.I.m_optionTextColor;
		}
	}

	public static bool HasOpenConsoleInput(out InputAction action)
	{
		if (CustomSettings<OnScreenConsoleSettings>.I != null && CustomSettings<OnScreenConsoleSettings>.I.m_openInputRef != null)
		{
			action = CustomSettings<OnScreenConsoleSettings>.I.m_openInputRef.ToInputAction();
			return action != null;
		}
		action = null;
		return false;
	}

	public static bool HasCloseConsoleInput(out InputAction action)
	{
		if (CustomSettings<OnScreenConsoleSettings>.I != null && CustomSettings<OnScreenConsoleSettings>.I.m_closeInputRef != null)
		{
			action = CustomSettings<OnScreenConsoleSettings>.I.m_closeInputRef.ToInputAction();
			return action != null;
		}
		action = null;
		return false;
	}
}

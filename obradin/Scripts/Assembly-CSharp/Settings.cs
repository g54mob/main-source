using UnityEngine;

public class Settings
{
	public enum OutputMode
	{
		Analog = 0,
		Digital0 = 1,
		Digital1 = 2,
		Digital2 = 3,
		Digital3 = 4,
		Digital4 = 5,
		Digital5 = 6,
		COUNT = 7
	}

	public class Monitor
	{
		public string id;

		public string name;

		public Color blackColor;

		public Color whiteColor;

		public Monitor(string id_, string name_, Color blackColor_, Color whiteColor_, float a = 0f, float b = 1f)
		{
			id = id_;
			name = name_;
			blackColor = Color.Lerp(blackColor_, whiteColor_, a);
			whiteColor = Color.Lerp(blackColor_, whiteColor_, b);
		}
	}

	public static OutputMode outputMode = OutputMode.Analog;

	public static bool lookInvertY = false;

	public static float lookSpeedX = 1f;

	public static float lookSpeedY = 1f;

	private static Color colorBlack_ = new Color(0.2f, 0.2f, 0.1f, 1f);

	private static Color colorWhite_ = new Color(0.9f, 1f, 1f, 1f);

	private static string colorId_ = "default";

	private const float kDimA = 0.2f;

	private const float kDimB = 0.8f;

	public static Monitor[] monitors = new Monitor[6]
	{
		new Monitor("default", "Macintosh", new Color(0.2f, 0.2f, 0.1f, 1f), new Color(0.9f, 1f, 1f, 1f)),
		new Monitor("ibm5151", "IBM 5151", Util.HexToColor("25342f"), Util.HexToColor("00eb5f")),
		new Monitor("zvm1240", "Zenith ZVM 1240", Util.HexToColor("3f291e"), Util.HexToColor("fdca55")),
		new Monitor("cbm1084", "Commodore 1084", Util.HexToColor("40318e"), Util.HexToColor("88d7de")),
		new Monitor("ibm8053", "IBM 8503", Util.HexToColor("2e3037"), Util.HexToColor("ebe5ce")),
		new Monitor("lcd", "LCD", Util.HexToColor("000000"), Util.HexToColor("ffffff"))
	};

	public static string activeSaveId = "P1";

	public static bool outputModeIsFramed
	{
		get
		{
			return outputMode >= OutputMode.Digital0;
		}
	}

	public static bool outputModeIsUpscaled
	{
		get
		{
			return outputMode == OutputMode.Analog;
		}
	}

	public static bool outputModeIsAnalog
	{
		get
		{
			return outputMode == OutputMode.Analog;
		}
	}

	public static string outputModeStyleName
	{
		get
		{
			return (!outputModeIsUpscaled) ? "default" : "upscale";
		}
	}

	public static float volume
	{
		get
		{
			return AudioListener.volume;
		}
		set
		{
			AudioListener.volume = value;
		}
	}

	public static Color colorBlack
	{
		get
		{
			return colorBlack_;
		}
		set
		{
			colorBlack_ = value;
		}
	}

	public static Color colorWhite
	{
		get
		{
			return colorWhite_;
		}
		set
		{
			colorWhite_ = value;
		}
	}

	public static string colorId
	{
		get
		{
			return colorId_;
		}
		set
		{
			Monitor[] array = monitors;
			foreach (Monitor monitor in array)
			{
				if (monitor.id == value)
				{
					colorId_ = monitor.id;
					colorBlack = monitor.blackColor;
					colorWhite = monitor.whiteColor;
				}
			}
		}
	}

	public static OutputMode CalcOutputModeMax()
	{
		if (LocReview.active)
		{
			return OutputMode.Digital5;
		}
		Vector2 vector = new Vector2(Resolution.nativeResW, Resolution.nativeResH);
		Vector2 vector2 = new Vector2(Resolution.bufferW, Resolution.bufferH);
		float num = vector.x / vector.y;
		float num2 = vector2.x / vector2.y;
		int index = ((num > num2) ? 1 : 0);
		int num3 = 20;
		while (num3 > 1 && (float)num3 * vector2[index] > vector[index])
		{
			num3--;
		}
		return (OutputMode)(1 + Mathf.Min(num3 - 1, 5));
	}

	public static void Save()
	{
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt("OutputMode", (int)outputMode);
		PlayerPrefs.SetFloat("Volume", volume);
		PlayerPrefs.SetString("Monitor", colorId_);
		PlayerPrefs.SetInt("InvertY", lookInvertY ? 1 : 0);
		PlayerPrefs.SetFloat("LookSpeedX", lookSpeedX);
		PlayerPrefs.SetFloat("LookSpeedY", lookSpeedY);
		PlayerPrefs.SetString("ActiveSave", activeSaveId);
		PlayerPrefs.SetString("Language", Lang.loadedLanguage.langId);
		PlayerPrefs.Save();
	}

	public static void Load()
	{
		outputMode = (OutputMode)PlayerPrefs.GetInt("OutputMode", (int)outputMode);
		volume = PlayerPrefs.GetFloat("Volume", volume);
		colorId = PlayerPrefs.GetString("Monitor", colorId);
		lookInvertY = PlayerPrefs.GetInt("InvertY", lookInvertY ? 1 : 0) != 0;
		lookSpeedX = PlayerPrefs.GetFloat("LookSpeedX", lookSpeedX);
		lookSpeedY = PlayerPrefs.GetFloat("LookSpeedY", lookSpeedY);
		activeSaveId = PlayerPrefs.GetString("ActiveSave", activeSaveId);
		Lang.Load(PlayerPrefs.GetString("Language", Lang.loadedLanguage.langId));
	}
}

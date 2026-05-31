using System;

[Serializable]
public class AppData
{
	public string Version = GetVersion();

	public DateTime TimeCreated;

	public int VolumeVolume;

	public int MusicVolume;

	public int SFXVolume;

	public int CRTEffect;

	public int HoleTrash;

	public int ViewStats;

	public int IsNormalFont;

	public bool HasCRTEffect
	{
		get
		{
			return CRTEffect == 1;
		}
		set
		{
			if (value)
			{
				CRTEffect = 1;
			}
			else
			{
				CRTEffect = 0;
			}
		}
	}

	public bool HasHoleTrash
	{
		get
		{
			return HoleTrash == 1;
		}
		set
		{
			if (value)
			{
				HoleTrash = 1;
			}
			else
			{
				HoleTrash = 0;
			}
		}
	}

	public bool HasViewStats
	{
		get
		{
			return ViewStats == 1;
		}
		set
		{
			if (value)
			{
				ViewStats = 1;
			}
			else
			{
				ViewStats = 0;
			}
		}
	}

	public bool HasIsNormalFont
	{
		get
		{
			return IsNormalFont == 1;
		}
		set
		{
			if (value)
			{
				IsNormalFont = 1;
			}
			else
			{
				IsNormalFont = 0;
			}
		}
	}

	public static string GetVersion()
	{
		return "VERSION1.3";
	}
}

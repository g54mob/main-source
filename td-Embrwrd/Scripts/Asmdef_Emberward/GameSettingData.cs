using UnityEngine;

public abstract class GameSettingData : ScriptableObject
{
	[SerializeField]
	[Header("預設值")]
	protected int defaultValue;

	[SerializeField]
	[Header("數值")]
	protected int settingValue;

	[SerializeField]
	[Header("類型")]
	protected eSettingItemType type;

	[Header("可調整這個設定的平台")]
	[SerializeField]
	protected eSettingPlatform platform;

	[Header("可調整這個設定的輸入方式")]
	[SerializeField]
	protected eSettingInputType inputType;

	[SerializeField]
	[Header("是否可以在Demo版出現")]
	protected bool canAppearInDemo;

	[SerializeField]
	[Header("是否只在開始時讀取一次")]
	protected bool onlyLoadOnceOnStart;

	private static bool isLoaded;

	public int DefaultValue => 0;

	public int SettingValue => 0;

	public eSettingItemType Type => default(eSettingItemType);

	public eSettingPlatform Platform => default(eSettingPlatform);

	public eSettingInputType InputType => default(eSettingInputType);

	public bool CanAppearInDemo => false;

	public void ApplySetting(int value)
	{
	}

	protected abstract void ApplySettingToGame();

	public int LoadSetting(bool andApplyToGame)
	{
		return 0;
	}

	public void ResetToDefault()
	{
	}

	public bool IsPlatformSupported(eSettingPlatform checkPlatform)
	{
		return false;
	}

	public string GetLocString()
	{
		return null;
	}
}

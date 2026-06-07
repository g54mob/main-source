using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
	public static SettingsManager Instance;

	[Header("設定資料")]
	[SerializeField]
	private List<GameSettingData> list_GameSettingData;

	public float Accessibility_MonsterFlashLevel;

	public bool Accessibility_TurnOffTimer;

	public GameSettingData_RecallBlockButton.eRecallBlockButton RecallBlockButtonType;

	public bool DoUseDarkFogColor;

	public bool DoStopMovingBackground;

	public bool DoEdgeScroll;

	public bool ActivateSpeedrunTimer;

	public bool ShowLongestPathLength;

	public int CameraShakeLevel;

	public int JoystickVibrationLevel;

	public bool DamageNumberOn;

	public bool CursorSupportLineOn;

	public bool SoftenElectricBlockEffect;

	public bool WorkMode;

	public bool AlwaysPlaceMultiple;

	public eDamageNumberType DamageNumberType;

	private bool isInitialized;

	private GameSettingData[] gameSettings;

	private bool isRunningOnSteamDeck;

	public bool IsRunningOnSteamDeck => false;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Initialize()
	{
	}

	public GameSettingData GetGameSettingData(eSettingItemType type)
	{
		return null;
	}

	private void OnApplicationFocus(bool focusStatus)
	{
	}

	public eSettingPlatform GetCurrentSettingPlatform()
	{
		return default(eSettingPlatform);
	}
}

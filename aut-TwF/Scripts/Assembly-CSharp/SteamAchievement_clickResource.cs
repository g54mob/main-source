using Steamworks;
using UnityEngine;

[CreateAssetMenu(fileName = "SteamAchievement_clickResource_default", menuName = "Tower Factory/Steam Achievements/Click Resource")]
public class SteamAchievement_clickResource : SteamAchievement
{
	[Header("Click Resource")]
	[SerializeField]
	private int clicksAmount;

	[SerializeField]
	[Tooltip("None = any")]
	private GameplayObjectData sourceObjectData;

	private int currentClicks;

	public override void StartAchievement()
	{
		base.StartAchievement();
		SteamUserStats.GetStat("clicksResources", out currentClicks);
	}

	protected override void OnStartGame()
	{
		base.OnStartGame();
		LTFunctionLibrary.GetLTPlayerController().onInputModeChanged += OnInputModeChanged;
	}

	private void OnInputModeChanged(InputMode newInputMode, InputMode oldInputMode)
	{
		if (newInputMode.InputModeType == EInputMode.Standard)
		{
			(newInputMode as StandardInputMode).onSourceClickPerformed += OnSourceClickPerformed;
		}
	}

	private void OnSourceClickPerformed(Source source)
	{
		if (!sourceObjectData || source.ObjectData.Id == sourceObjectData.Id)
		{
			currentClicks++;
			SteamUserStats.SetStat("clicksResources", currentClicks);
			SteamUserStats.StoreStats();
			if (currentClicks >= clicksAmount)
			{
				UnlockAchievement();
			}
		}
	}
}

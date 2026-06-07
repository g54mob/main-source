using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulebookFogManager : MonoBehaviour
{
	private SoundManager soundManager;

	public RuleBookScreenManager ruleBookScreenManager;

	public bool isProgressingFog;

	public void Start()
	{
		if (SaveSystem.currentPlayerSaveData.pageFogEntries.Count < 1)
		{
			GenerateFogEntries();
		}
		soundManager = Object.FindObjectOfType<SoundManager>();
	}

	private void GenerateFogEntries()
	{
		foreach (RuleBookScreenData ruleBookScreen in ruleBookScreenManager.ruleBookScreens)
		{
			foreach (RuleBookPage ruleBookPage in ruleBookScreen.ruleBookPages)
			{
				bool isFog = ruleBookPage.turnsToClearFog > 0;
				if (SpeedrunTimer.doSpeedrunTimer)
				{
					isFog = false;
				}
				PageFogEntry item = new PageFogEntry(ruleBookPage.pageID, isFog, ruleBookPage.turnsToClearFog, ruleBookScreenManager.ruleBookScreens.IndexOf(ruleBookScreen));
				SaveSystem.currentPlayerSaveData.pageFogEntries.Add(item);
			}
		}
	}

	public void ProgressFogClearing(ChessPieceData.ChessPieceType chessPieceType)
	{
		isProgressingFog = true;
		bool flag = false;
		foreach (PageFogEntry pageFogEntry in SaveSystem.currentPlayerSaveData.pageFogEntries)
		{
			RuleBookPage pageByID = GetPageByID(pageFogEntry.pageID);
			if (!pageFogEntry.isFog)
			{
				continue;
			}
			if (pageByID.checkForSpecificFogPiece)
			{
				if (pageByID.clearFogPiece == chessPieceType)
				{
					pageFogEntry.turnsToClearFog--;
				}
			}
			else
			{
				pageFogEntry.turnsToClearFog--;
			}
			if (!flag && pageFogEntry.turnsToClearFog < 1)
			{
				flag = true;
				StartCoroutine(ClearFog(pageFogEntry));
			}
		}
		if (!flag)
		{
			isProgressingFog = false;
		}
	}

	public bool CheckIfPageIsFogged(RuleBookPage page)
	{
		foreach (PageFogEntry pageFogEntry in SaveSystem.currentPlayerSaveData.pageFogEntries)
		{
			if (GetPageByID(pageFogEntry.pageID) == page)
			{
				return pageFogEntry.isFog;
			}
		}
		return false;
	}

	public PageFogEntry GetPageFogEntry(RuleBookPage page)
	{
		foreach (PageFogEntry pageFogEntry in SaveSystem.currentPlayerSaveData.pageFogEntries)
		{
			if (GetPageByID(pageFogEntry.pageID) == page)
			{
				return pageFogEntry;
			}
		}
		return null;
	}

	public IEnumerator ClearFog(PageFogEntry pageFogEntry)
	{
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_rulebook_fog_dissipate);
		StartCoroutine(ruleBookScreenManager.bookShake.Shake(1f, 0.05f));
		ChessMatchManager chessMatchManager = Object.FindObjectOfType<ChessMatchManager>();
		List<ChessPieceObject> chessPieces = new List<ChessPieceObject>();
		chessPieces.AddRange(chessMatchManager.whitePieces);
		chessPieces.AddRange(chessMatchManager.blackPieces);
		chessPieces.AddRange(chessMatchManager.utilityPieces);
		foreach (ChessPieceObject item in chessPieces)
		{
			item.StartCoroutine(item.FogFadeOut());
		}
		yield return new WaitForSeconds(1f);
		RuleBookScreenData fogClearScreen = ruleBookScreenManager.ruleBookScreens[pageFogEntry.screenIndex];
		ruleBookScreenManager.FlipToSpecificPage(fogClearScreen);
		while (ruleBookScreenManager.currentRuleBookScreen != fogClearScreen)
		{
			yield return null;
		}
		pageFogEntry.isFog = false;
		switch (fogClearScreen.ruleBookPages.IndexOf(GetPageByID(pageFogEntry.pageID)))
		{
		case 0:
		{
			ParticleSystem.MainModule sysModule = ruleBookScreenManager.fogLeftParticle.main;
			sysModule.simulationSpeed = 3f;
			ruleBookScreenManager.fogLeftParticle.Stop();
			yield return new WaitForSeconds(2f);
			sysModule.simulationSpeed = 1f;
			break;
		}
		case 1:
		{
			ParticleSystem.MainModule sysModule = ruleBookScreenManager.fogRightParticle.main;
			sysModule.simulationSpeed = 3f;
			ruleBookScreenManager.fogRightParticle.Stop();
			yield return new WaitForSeconds(2f);
			sysModule.simulationSpeed = 1f;
			break;
		}
		}
		ProgressAchievements();
		foreach (ChessPieceObject item2 in chessPieces)
		{
			item2.StartCoroutine(item2.FogFadeIn());
		}
		isProgressingFog = false;
	}

	public RuleBookPage GetPageByID(string pageID)
	{
		foreach (RuleBookScreenData ruleBookScreen in ruleBookScreenManager.ruleBookScreens)
		{
			foreach (RuleBookPage ruleBookPage in ruleBookScreen.ruleBookPages)
			{
				if (ruleBookPage.pageID == pageID)
				{
					return ruleBookPage;
				}
			}
		}
		return null;
	}

	private void ProgressAchievements()
	{
		int num = 0;
		foreach (PageFogEntry pageFogEntry in SaveSystem.currentPlayerSaveData.pageFogEntries)
		{
			if (!pageFogEntry.isFog)
			{
				num++;
			}
		}
		if (num >= SaveSystem.currentPlayerSaveData.pageFogEntries.Count - 10)
		{
			SteamAchievements.UnlockAchievement("UNLOCKED_10_PAGES");
		}
		if (num >= SaveSystem.currentPlayerSaveData.pageFogEntries.Count)
		{
			SteamAchievements.UnlockAchievement("UNLOCKED_ALL_PAGES");
		}
	}
}

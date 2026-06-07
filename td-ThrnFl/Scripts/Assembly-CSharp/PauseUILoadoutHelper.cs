using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseUILoadoutHelper : MonoBehaviour
{
	public UIFrame frame;

	public ThronefallUIElement topmostButton;

	public ThronefallUIElement botmostButton;

	public ThronefallUIElement nightButton;

	public GridLayoutGroup loadoutGroup;

	public GridLayoutGroup enemyPreview;

	public TFUIEquippable equippableButtonPrefab;

	public TFUIEnemy enemyButtonPrefab;

	public TFUIIncomeDisplay incomeDisplayPrefab;

	public TextMeshProUGUI nightPreviewText;

	public Sprite difficultySprite;

	private List<ThronefallUIElement> loadoutGrid = new List<ThronefallUIElement>();

	private List<ThronefallUIElement> enemyGrid = new List<ThronefallUIElement>();

	private const int maxRows = 2;

	private int currentPreviewWavenumber = 1;

	private int currentTrueWaveNumver = 1;

	private void OnEnable()
	{
		if (EnemySpawner.instance == null)
		{
			currentTrueWaveNumver = 1;
		}
		else if (DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Night)
		{
			currentTrueWaveNumver = EnemySpawner.instance.Wavenumber;
		}
		else
		{
			currentTrueWaveNumver = EnemySpawner.instance.Wavenumber + 1;
		}
		currentPreviewWavenumber = currentTrueWaveNumver;
	}

	public void CycleNightPreview(int direction)
	{
		currentPreviewWavenumber += direction;
		if (currentPreviewWavenumber < 0)
		{
			currentPreviewWavenumber = 0;
		}
		if (currentPreviewWavenumber > EnemySpawner.instance.WaveCount - 1)
		{
			currentPreviewWavenumber = EnemySpawner.instance.WaveCount - 1;
		}
		RefreshOnlyEnemyPreview();
		AssignNavigationTargets();
	}

	public void OnFrameSelectionChange()
	{
		if (currentTrueWaveNumver != currentPreviewWavenumber && frame.CurrentSelection != nightButton && !enemyGrid.Contains(frame.CurrentSelection))
		{
			currentPreviewWavenumber = currentTrueWaveNumver;
			RefreshOnlyEnemyPreview();
			AssignNavigationTargets();
		}
	}

	public void Refresh()
	{
		if (SceneTransitionManager.instance.CurrentSceneState != SceneTransitionManager.SceneState.InGame)
		{
			return;
		}
		loadoutGrid.Clear();
		foreach (Transform item in loadoutGroup.transform)
		{
			Object.Destroy(item.gameObject);
		}
		List<Equippable> list = new List<Equippable>();
		List<Equippable> list2 = new List<Equippable>();
		List<Equippable> list3 = new List<Equippable>();
		foreach (Equippable item2 in PerkManager.instance.CurrentlyEquipped)
		{
			if (item2 is EquippableWeapon)
			{
				list.Add(item2);
			}
			else if (item2 is EquippablePerk)
			{
				list2.Add(item2);
			}
			else if (item2 is EquippableMutation)
			{
				list3.Add(item2);
			}
		}
		foreach (Equippable item3 in list)
		{
			AddTFUIEquippable(loadoutGroup, item3);
		}
		foreach (Equippable item4 in list2)
		{
			AddTFUIEquippable(loadoutGroup, item4);
		}
		foreach (Equippable item5 in list3)
		{
			AddTFUIEquippable(loadoutGroup, item5);
		}
		RefreshOnlyEnemyPreview();
		AssignNavigationTargets();
	}

	private void RefreshOnlyEnemyPreview()
	{
		if (EnemySpawner.instance != null)
		{
			enemyPreview.gameObject.SetActive(value: true);
			nightPreviewText.gameObject.SetActive(value: true);
			WaveInfo waveInfo = ((!(EnemySpawner.instance != null)) ? new WaveInfo() : EnemySpawner.GetWaveInfoByNumber(currentPreviewWavenumber));
			if (waveInfo == null)
			{
				return;
			}
			enemyGrid.Clear();
			foreach (Transform item in enemyPreview.transform)
			{
				Object.Destroy(item.gameObject);
			}
			foreach (WaveEnemyInfo enemy in waveInfo.enemies)
			{
				AddTFUIEnemey(enemyPreview, enemy);
			}
			if (waveInfo.difficultyMulti != 1f)
			{
				WaveEnemyInfo waveEnemyInfo = new WaveEnemyInfo();
				waveEnemyInfo.enemyIcon = difficultySprite;
				waveEnemyInfo.enemyCount = Mathf.RoundToInt((waveInfo.difficultyMulti - 1f) / 0.1f);
				waveEnemyInfo.enemyName = LocalizationManager.GetTranslation("Menu/DifficultyBoost");
				waveEnemyInfo.enemyDescription = "+ " + Mathf.Round((waveInfo.difficultyMulti - 1f) * 100f) + "% " + LocalizationManager.GetTranslation("Menu/AdditionalHealth");
				WaveEnemyInfo waveEnemyInfo2 = waveEnemyInfo;
				waveEnemyInfo2.enemyDescription = waveEnemyInfo2.enemyDescription + "\n+ " + Mathf.Round((waveInfo.difficultyMulti - 1f) * 50f) + "% " + LocalizationManager.GetTranslation("Menu/AdditionalDamage");
				AddTFUIEnemey(enemyPreview, waveEnemyInfo);
			}
			AddIncomePreview(enemyPreview);
			if (currentPreviewWavenumber == currentTrueWaveNumver)
			{
				nightPreviewText.text = LocalizationManager.GetTranslation("Menu/Night") + ": <style=Body Numerals>" + waveInfo.waveNumber + "</style>/<style=Body Numerals>" + waveInfo.outOfWaves;
			}
			else
			{
				nightPreviewText.text = LocalizationManager.GetTranslation("Menu/Night") + ": <style=Body Numerals>" + waveInfo.waveNumber + "</style>(<style=Body Numerals>" + (currentTrueWaveNumver + 1) + "</style>)<style=Body Numerals></style>/<style=Body Numerals>" + waveInfo.outOfWaves;
			}
		}
		else
		{
			enemyPreview.gameObject.SetActive(value: false);
			nightPreviewText.gameObject.SetActive(value: false);
		}
	}

	private void AddTFUIEquippable(GridLayoutGroup parent, Equippable e)
	{
		TFUIEquippable component = Object.Instantiate(equippableButtonPrefab, parent.transform).GetComponent<TFUIEquippable>();
		component.SetDataSimple(e);
		loadoutGrid.Add(component);
	}

	private void AddTFUIEnemey(GridLayoutGroup parent, WaveEnemyInfo e)
	{
		TFUIEnemy tFUIEnemy = Object.Instantiate(enemyButtonPrefab, parent.transform);
		tFUIEnemy.SetDataSimple(e);
		enemyGrid.Add(tFUIEnemy);
	}

	private void AddIncomePreview(GridLayoutGroup parent)
	{
		TFUIIncomeDisplay tFUIIncomeDisplay = Object.Instantiate(incomeDisplayPrefab, parent.transform);
		tFUIIncomeDisplay.UpdateData(currentPreviewWavenumber);
		enemyGrid.Add(tFUIIncomeDisplay);
	}

	private void AssignNavigationTargets()
	{
		ThronefallUIElement botElement = topmostButton;
		if (loadoutGrid.Count > 0)
		{
			botElement = loadoutGrid[0];
		}
		CalculateGridNavigation(enemyGrid, botElement, botmostButton, isTopMostGrid: true, isBotMostGrid: false);
		ThronefallUIElement topElement = botmostButton;
		if (enemyGrid.Count > 0)
		{
			topElement = enemyGrid[0];
		}
		CalculateGridNavigation(loadoutGrid, topmostButton, topElement, isTopMostGrid: false, isBotMostGrid: true);
	}

	private void CalculateGridNavigation(List<ThronefallUIElement> grid, ThronefallUIElement botElement, ThronefallUIElement topElement, bool isTopMostGrid, bool isBotMostGrid)
	{
		int num = grid.Count / 2;
		int num2 = grid.Count % 2;
		if (num2 > 0)
		{
			num++;
		}
		else
		{
			num2 = 2;
		}
		int num3 = 0;
		int num4 = 0;
		for (int i = 0; i < grid.Count; i++)
		{
			ThronefallUIElement thronefallUIElement = grid[i];
			if (num3 == 0)
			{
				thronefallUIElement.topNav = topElement;
			}
			else
			{
				thronefallUIElement.topNav = grid[i - 1];
			}
			if (num3 == 1 || (num == 1 && i == grid.Count - 1))
			{
				thronefallUIElement.botNav = botElement;
			}
			else if (num > 1 && i == grid.Count - 1)
			{
				thronefallUIElement.botNav = grid[2 * num4 - 1];
			}
			else
			{
				thronefallUIElement.botNav = grid[i + 1];
			}
			if (num > 1)
			{
				if (num4 == 0)
				{
					if (num3 <= num2 - 1)
					{
						thronefallUIElement.leftNav = grid[grid.Count - (num2 - num3)];
					}
					else if (i + 2 <= grid.Count - 1)
					{
						thronefallUIElement.leftNav = grid[i + 2];
					}
				}
				else
				{
					thronefallUIElement.leftNav = grid[i - 2];
				}
				if (num4 == num - 1)
				{
					thronefallUIElement.rightNav = grid[i - 2 * (num - 1)];
				}
				else
				{
					int num5 = i + 2;
					if (num5 <= grid.Count - 1)
					{
						thronefallUIElement.rightNav = grid[num5];
					}
					else
					{
						thronefallUIElement.rightNav = grid[i - 2 * num4];
					}
				}
			}
			num3++;
			if (num3 > 1)
			{
				num3 = 0;
				num4++;
			}
		}
		if (grid.Count <= 0)
		{
			return;
		}
		if (isTopMostGrid)
		{
			botmostButton.botNav = grid[0];
		}
		if (isBotMostGrid)
		{
			if (num2 != 2 && num > 1)
			{
				topmostButton.topNav = grid[2 * (num - 1) - 1];
			}
			else
			{
				topmostButton.topNav = grid[grid.Count - 1];
			}
		}
	}
}

using System.Collections.Generic;
using FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class MinigamePanelWater : MinigamePanel
{
	public GameObject waterMinigameButtonPrefab;

	public GridLayoutGroup tileButtonGroup;

	private readonly List<List<WaterMinigameTerrainButton>> buttonRows = new List<List<WaterMinigameTerrainButton>>();

	private WaterMinigameTerrainButton startButton;

	private WaterMinigameTerrainButton endButton;

	private readonly List<WaterMinigameTerrainButton> path = new List<WaterMinigameTerrainButton>();

	private readonly List<WaterMinigameTerrainButton> pathTemp = new List<WaterMinigameTerrainButton>();

	private readonly Queue<WaterMinigameTerrainButton> queue = new Queue<WaterMinigameTerrainButton>();

	private List<WaterMinigameTerrainButton> rockButtons = new List<WaterMinigameTerrainButton>();

	private List<WaterMinigameTerrainButton> buttonCandidates = new List<WaterMinigameTerrainButton>();

	private int victoryAnimationCounter;

	private bool isAnimatingVictory;

	private float victoryAnimationTimer;

	private int numSources;

	private int numCapturedSources;

	private int gridWidth = 12;

	private int gridHeight = 8;

	private TextValueChangeAnimation textValueChangeAnimation;

	public override void CreateItems()
	{
		levelStat = MenuPanel.gm.minigameWater;
		energyTracker = MenuPanel.gm.energyWater;
		CreateTileButtons();
		rewardEntities.AddItem(ItemType.Water, 10.0);
		base.CreateItems();
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (!isAnimatingVictory)
		{
			return;
		}
		victoryAnimationTimer += TimeManager.MenuDelta * 12f;
		while (victoryAnimationTimer >= 1f)
		{
			victoryAnimationCounter++;
			int num = victoryAnimationCounter - 1;
			if (num < path.Count)
			{
				WaterMinigameTerrainButton waterMinigameTerrainButton = path[num];
				waterMinigameTerrainButton.isInPrimaryPath = true;
				waterMinigameTerrainButton.UpdateItemIcon();
				if (waterMinigameTerrainButton.isWaterSource)
				{
					float num2 = ValueForWaterSource();
					MenuManager.Instance.PlayStarParticles(waterMinigameTerrainButton.transform.position);
					EarnReward(num2);
					AnimateItemGain(waterMinigameTerrainButton.transform, num2, 5);
					float num3 = XpValue();
					if (num3 > 0f)
					{
						AnimateToExperience(waterMinigameTerrainButton.transform, levelStat.iconItem, num3);
					}
				}
			}
			else
			{
				float num4 = ValueForCompletion();
				EarnReward(num4);
				isAnimatingVictory = false;
				AnimateItemGain(endButton.transform, num4, 4);
				float num5 = XpValue();
				if (num5 > 0f)
				{
					AnimateToExperience(endButton.transform, levelStat.iconItem, num5);
				}
			}
			victoryAnimationTimer -= 1f;
		}
	}

	public override void ResetMinigame()
	{
		base.ResetMinigame();
		isAnimatingVictory = false;
		victoryAnimationTimer = 0f;
		victoryAnimationCounter = 0;
		numSources = 0;
		numCapturedSources = 0;
		base.ResetMinigame();
		startButton = null;
		endButton = null;
		rockButtons.Clear();
		ResetButtons();
	}

	private void CreateTileButtons()
	{
		int num = gridWidth;
		tileButtonGroup.constraintCount = num;
		for (int i = 0; i < gridHeight; i++)
		{
			List<WaterMinigameTerrainButton> list = new List<WaterMinigameTerrainButton>();
			buttonRows.Add(list);
			for (int j = 0; j < num; j++)
			{
				WaterMinigameTerrainButton item = CreateTileButtons(j, i);
				list.Add(item);
			}
		}
	}

	private WaterMinigameTerrainButton CreateTileButtons(int x, int y)
	{
		WaterMinigameTerrainButton component = MenuManager.GetMenuObject(waterMinigameButtonPrefab, tileButtonGroup.transform).GetComponent<WaterMinigameTerrainButton>();
		component.Init(x, y);
		component.actionDelegate = OnActivatedButton;
		component.parentMap = this;
		return component;
	}

	private void ResetButtons()
	{
		foreach (List<WaterMinigameTerrainButton> buttonRow in buttonRows)
		{
			foreach (WaterMinigameTerrainButton item in buttonRow)
			{
				item.ResetState();
			}
		}
	}

	protected override void LoadNewMinigame()
	{
		base.LoadNewMinigame();
		numSources = 4;
		ResetButtons();
		ChooseStartAndEnd();
		FillWithStones(15);
		FillWithWaterSources();
		minigameState = MinigameState.Running;
	}

	private bool TryGetButton(Coord c, out WaterMinigameTerrainButton result)
	{
		if (c.y >= 0 && c.y < buttonRows.Count)
		{
			List<WaterMinigameTerrainButton> list = buttonRows[c.y];
			if (c.x >= 0 && c.x < list.Count)
			{
				result = list[c.x];
				return true;
			}
		}
		result = null;
		return false;
	}

	public void OnActivatedButton(DraggableButton sender, bool isDragging)
	{
		if (!(sender is WaterMinigameTerrainButton waterMinigameTerrainButton) || minigameState != MinigameState.Running)
		{
			return;
		}
		Coord coord = waterMinigameTerrainButton.coord;
		if (waterMinigameTerrainButton.tileState == WaterMinigameTileState.Rock)
		{
			MenuManager.Instance.PlayStarParticles(waterMinigameTerrainButton.transform.position);
		}
		else
		{
			if (waterMinigameTerrainButton.tileState != WaterMinigameTileState.Grass)
			{
				return;
			}
			MenuManager.Instance.PlayDigParticles(waterMinigameTerrainButton.transform.position);
			waterMinigameTerrainButton.Excavate();
			bool flag = false;
			for (int i = 0; i < 4; i++)
			{
				if (TryGetButton(coord.Offset(i), out var result) && result.tileState == WaterMinigameTileState.Water)
				{
					SpreadWaterFrom(result.coord);
					flag = true;
				}
			}
			if (flag)
			{
				CheckForVictory();
			}
		}
	}

	private void CheckForVictory()
	{
		FindPath(allowGround: false);
		if (path.Count > 0)
		{
			DeclareVictory();
		}
	}

	protected override void CalcReward()
	{
		rewardAmount = 0.0;
		numCapturedSources = 0;
		if (path.Count > 0)
		{
			rewardAmount += ValueForCompletion();
			foreach (WaterMinigameTerrainButton item in path)
			{
				if (item.isWaterSource)
				{
					numCapturedSources++;
				}
			}
		}
		rewardAmount += ValueForWaterSource() * (float)numCapturedSources;
		if (numCapturedSources >= numSources)
		{
			rewardAmount *= MultiplierForPerfect();
		}
	}

	protected override void DeclareVictory()
	{
		base.DeclareVictory();
		isAnimatingVictory = true;
	}

	protected override bool IsReadyToDisplayFinalResult()
	{
		if (base.IsReadyToDisplayFinalResult())
		{
			return !isAnimatingVictory;
		}
		return false;
	}

	protected override void DisplayFinalCompletionState()
	{
		base.DisplayFinalCompletionState();
		if (MenuPanel.gm.gameState == GameState.InGame)
		{
			return;
		}
		FindPath(allowGround: false);
		if (path.Count <= 0)
		{
			return;
		}
		foreach (WaterMinigameTerrainButton item in path)
		{
			item.isInPrimaryPath = true;
			item.UpdateItemIcon();
		}
	}

	protected override bool IsPerfect()
	{
		return numCapturedSources >= numSources;
	}

	private void SpreadWaterFrom(Coord c)
	{
		for (int i = 0; i < 4; i++)
		{
			if (TryGetButton(c.Offset(i), out var result) && result.tileState == WaterMinigameTileState.Dirt)
			{
				result.tileState = WaterMinigameTileState.Water;
				result.UpdateItemIcon();
				SpreadWaterFrom(result.coord);
			}
		}
	}

	private WaterMinigameTerrainButton ButtonFromRow(List<WaterMinigameTerrainButton> row, int margin)
	{
		int num = row.Count - margin * 2;
		if (num > 1)
		{
			int num2 = Random.Range(0, num);
			return row[margin + num2];
		}
		return null;
	}

	private void SetStart(WaterMinigameTerrainButton b)
	{
		startButton = b;
		if (null != startButton)
		{
			startButton.isStart = true;
			startButton.tileState = WaterMinigameTileState.Water;
			startButton.UpdateItemIcon();
		}
	}

	private void SetEnd(WaterMinigameTerrainButton b)
	{
		endButton = b;
		if (null != endButton)
		{
			endButton.isEnd = true;
			endButton.tileState = WaterMinigameTileState.Dirt;
			endButton.UpdateItemIcon();
		}
	}

	private void ChooseStartAndEnd()
	{
		if (buttonRows.Count > 0)
		{
			SetStart(ButtonFromRow(buttonRows[0], 2));
			SetEnd(ButtonFromRow(buttonRows[buttonRows.Count - 1], 2));
		}
	}

	private bool IsValidWaterSource(WaterMinigameTerrainButton testButton)
	{
		if (testButton.isStart || testButton.isEnd)
		{
			return false;
		}
		bool flag = testButton.coord.x == 0 || testButton.coord.x == gridWidth - 1;
		if ((testButton.coord.y == 0 || testButton.coord.y == gridHeight - 1) && flag)
		{
			return false;
		}
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (TryGetButton(testButton.coord.Offset(i), out var result))
			{
				if (result.isStart || result.isEnd)
				{
					return false;
				}
				if (result.tileState != WaterMinigameTileState.Rock)
				{
					num++;
				}
			}
		}
		return num >= 2;
	}

	private bool PassesPathTest(WaterMinigameTerrainButton testButton, bool reverse)
	{
		ClearPathInfo();
		WaterMinigameTerrainButton end = (reverse ? endButton : startButton);
		WaterMinigameTerrainButton end2 = (reverse ? startButton : endButton);
		FindPathFrom(testButton, end, allowGround: true);
		if (path.Count == 0)
		{
			return false;
		}
		pathTemp.Clear();
		pathTemp.AddRange(path);
		ClearPathInfo();
		foreach (WaterMinigameTerrainButton item in pathTemp)
		{
			if (item == testButton)
			{
				continue;
			}
			item.pathExcludeFlag = true;
			for (int i = 0; i < 4; i++)
			{
				if (!TryGetButton(item.coord.Offset(i), out var result))
				{
					continue;
				}
				result.pathExcludeFlag = true;
				if (!result.isWaterSource)
				{
					continue;
				}
				for (int j = 0; j < 4; j++)
				{
					if (TryGetButton(item.coord.Offset(j), out var result2))
					{
						result2.pathExcludeFlag = true;
					}
				}
			}
		}
		FindPathFrom(testButton, end2, allowGround: true);
		if (path.Count == 0)
		{
			return false;
		}
		return true;
	}

	private void FillWithWaterSources()
	{
		buttonCandidates.Clear();
		foreach (List<WaterMinigameTerrainButton> buttonRow in buttonRows)
		{
			foreach (WaterMinigameTerrainButton item in buttonRow)
			{
				if (IsValidWaterSource(item))
				{
					buttonCandidates.Add(item);
				}
			}
		}
		int num = numSources;
		while (buttonCandidates.Count > 0 && num > 0)
		{
			int index = Random.Range(0, buttonCandidates.Count);
			WaterMinigameTerrainButton waterMinigameTerrainButton = buttonCandidates[index];
			if (!PassesPathTest(waterMinigameTerrainButton, reverse: false) && !PassesPathTest(waterMinigameTerrainButton, reverse: true))
			{
				buttonCandidates.Remove(waterMinigameTerrainButton);
				continue;
			}
			waterMinigameTerrainButton.tileState = WaterMinigameTileState.Water;
			waterMinigameTerrainButton.isWaterSource = true;
			waterMinigameTerrainButton.UpdateItemIcon();
			buttonCandidates.Remove(waterMinigameTerrainButton);
			num--;
			for (int i = 0; i < 4; i++)
			{
				if (TryGetButton(waterMinigameTerrainButton.coord.Offset(i), out var result))
				{
					buttonCandidates.Remove(result);
				}
			}
		}
	}

	private float XpValue()
	{
		return 10f * GameManager.Instance.MultiplierForGlobalPerk(PerkType.MinigameXPGainSpeed);
	}

	protected override void CalcYield()
	{
		base.CalcYield();
		yieldBaselineUpgraded = yieldBaseline * MenuPanel.gm.MultiplierForGlobalUpgrade(UpgradeType.MinigameWaterYield);
	}

	private float ValueForCompletion()
	{
		return yieldBaselineUpgraded * yieldMultiplier;
	}

	private float ValueForWaterSource()
	{
		return yieldBaselineUpgraded * yieldMultiplier;
	}

	private void FillWithStones(int p)
	{
		buttonCandidates.Clear();
		foreach (List<WaterMinigameTerrainButton> buttonRow in buttonRows)
		{
			foreach (WaterMinigameTerrainButton item in buttonRow)
			{
				if (!item.isWaterSource && !item.isStart && !item.isEnd)
				{
					buttonCandidates.Add(item);
				}
			}
		}
		for (int i = 0; i < 4; i++)
		{
			if (TryGetButton(startButton.coord.Offset(i), out var result))
			{
				buttonCandidates.Remove(result);
			}
			if (TryGetButton(endButton.coord.Offset(i), out var result2))
			{
				buttonCandidates.Remove(result2);
			}
		}
		int num = p;
		while (buttonCandidates.Count > 0 && num > 0)
		{
			int index = Random.Range(0, buttonCandidates.Count);
			WaterMinigameTerrainButton waterMinigameTerrainButton = buttonCandidates[index];
			waterMinigameTerrainButton.tileState = WaterMinigameTileState.Rock;
			waterMinigameTerrainButton.UpdateItemIcon();
			rockButtons.Add(waterMinigameTerrainButton);
			buttonCandidates.Remove(waterMinigameTerrainButton);
			num--;
			for (int j = 4; j < 8; j++)
			{
				if (TryGetButton(waterMinigameTerrainButton.coord.Offset(j), out var result3))
				{
					buttonCandidates.Remove(result3);
				}
			}
		}
		while (rockButtons.Count >= 2 && !HasValidPath())
		{
			int index2 = Random.Range(0, rockButtons.Count);
			WaterMinigameTerrainButton waterMinigameTerrainButton2 = rockButtons[index2];
			waterMinigameTerrainButton2.tileState = WaterMinigameTileState.Grass;
			waterMinigameTerrainButton2.UpdateItemIcon();
			rockButtons.Remove(waterMinigameTerrainButton2);
		}
	}

	private bool HasValidPath()
	{
		FindPath(allowGround: true);
		return path.Count > 0;
	}

	private void TryQueue(WaterMinigameTerrainButton source, int dir, bool allowGround)
	{
		Coord c = source.coord.Offset(dir);
		if (!TryGetButton(c, out var result) || result.pathExcludeFlag || result.tileState == WaterMinigameTileState.Rock || (result.tileState == WaterMinigameTileState.Grass && !allowGround))
		{
			return;
		}
		int num = source.distance + 1;
		if (result.distance == 0 || num < result.distance)
		{
			result.distance = num;
			result.searchParent = source;
			if (!result.isQueued)
			{
				queue.Enqueue(result);
				result.isQueued = true;
			}
			if (result.distance == 0)
			{
				Debug.DrawLine(source.transform.position, result.transform.position, Color.cyan, 3f);
			}
			else
			{
				Debug.DrawLine(source.transform.position, result.transform.position, Color.yellow, 3f);
			}
		}
	}

	private void ClearPathInfo()
	{
		path.Clear();
		queue.Clear();
		foreach (List<WaterMinigameTerrainButton> buttonRow in buttonRows)
		{
			foreach (WaterMinigameTerrainButton item in buttonRow)
			{
				item.ClearPathInfo();
			}
		}
	}

	private void FindPathFrom(WaterMinigameTerrainButton start, WaterMinigameTerrainButton end, bool allowGround)
	{
		if (null != start)
		{
			start.pathExcludeFlag = true;
			for (int i = 0; i < 4; i++)
			{
				TryQueue(start, i, allowGround);
			}
		}
		while (queue.Count > 0)
		{
			WaterMinigameTerrainButton waterMinigameTerrainButton = queue.Dequeue();
			waterMinigameTerrainButton.isQueued = false;
			for (int j = 0; j < 4; j++)
			{
				TryQueue(waterMinigameTerrainButton, j, allowGround);
			}
		}
		if (null != end.searchParent)
		{
			path.Add(end);
		}
		WaterMinigameTerrainButton searchParent = end.searchParent;
		while (null != searchParent)
		{
			path.Add(searchParent);
			searchParent = searchParent.searchParent;
		}
	}

	private void FindPath(bool allowGround)
	{
		ClearPathInfo();
		FindPathFrom(endButton, startButton, allowGround);
	}

	protected override void LoadFromDictionary(Dictionary<string, fsData> dataDict)
	{
		base.LoadFromDictionary(dataDict);
		if (dataDict.TryGetValue("ds", out var value))
		{
			Coord coord = SaveFile.CoordFromData(value);
			gridWidth = coord.x;
			gridHeight = coord.y;
		}
		if (dataDict.TryGetValue("start", out var value2))
		{
			Coord c = SaveFile.CoordFromData(value2);
			if (TryGetButton(c, out var result))
			{
				SetStart(result);
			}
		}
		if (dataDict.TryGetValue("end", out var value3))
		{
			Coord c2 = SaveFile.CoordFromData(value3);
			if (TryGetButton(c2, out var result2))
			{
				SetEnd(result2);
			}
		}
		if (!dataDict.TryGetValue("Items", out var value4) || !value4.TryAsList(out var result3))
		{
			return;
		}
		foreach (fsData item in result3)
		{
			if (!item.TryAsList(out var result4) || result4.Count < 2)
			{
				continue;
			}
			Coord c3 = SaveFile.CoordFromData(result4[0]);
			if (TryGetButton(c3, out var result5))
			{
				if (result4[1].TryAsInt(out var i))
				{
					result5.tileState = (WaterMinigameTileState)i;
				}
				if (result4.Count >= 3)
				{
					result5.isWaterSource = true;
				}
			}
		}
	}

	protected override void PostProcessLoadedData()
	{
		base.PostProcessLoadedData();
		foreach (List<WaterMinigameTerrainButton> buttonRow in buttonRows)
		{
			foreach (WaterMinigameTerrainButton item in buttonRow)
			{
				item.UpdateItemIcon();
			}
		}
	}

	public override fsData GetData()
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		StoreCommonData(dictionary);
		dictionary["ds"] = SaveFile.DataFromCoord(new Coord(gridWidth, gridHeight));
		if (null != startButton)
		{
			dictionary["start"] = SaveFile.DataFromCoord(startButton.coord);
		}
		if (null != endButton)
		{
			dictionary["end"] = SaveFile.DataFromCoord(endButton.coord);
		}
		List<fsData> list = new List<fsData>();
		foreach (List<WaterMinigameTerrainButton> buttonRow in buttonRows)
		{
			foreach (WaterMinigameTerrainButton item in buttonRow)
			{
				if (item.tileState != WaterMinigameTileState.None && item.tileState != WaterMinigameTileState.Grass)
				{
					List<fsData> list2 = new List<fsData>();
					list2.Add(SaveFile.DataFromCoord(item.coord));
					list2.Add(new fsData((long)item.tileState));
					if (item.isWaterSource)
					{
						list2.Add(fsData.True);
					}
					list.Add(new fsData(list2));
				}
			}
		}
		dictionary["Items"] = new fsData(list);
		return new fsData(dictionary);
	}

	public override bool ShouldBeAvailable()
	{
		return false;
	}
}

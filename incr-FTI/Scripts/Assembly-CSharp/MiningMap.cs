using System;
using System.Collections.Generic;
using DG.Tweening;
using FullSerializer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiningMap : MinigamePanel
{
	public GameObject miningButtonPrefab;

	public GameObject directoryIconPrefab;

	public GridLayoutGroup miningGroup;

	public GridLayoutGroup directoryGroup;

	public TextMeshProUGUI attemptsRemainingLabel;

	public TextMeshProUGUI oreChunksRemainingLabel;

	private readonly List<List<MiningButton>> buttonRows = new List<List<MiningButton>>();

	private readonly Dictionary<MiningGemInstance, MiningDirectoryIcon> directoryIcons = new Dictionary<MiningGemInstance, MiningDirectoryIcon>();

	private bool useDebugTransparency;

	private List<MiningGemShape> gemShapes = new List<MiningGemShape>();

	private readonly List<MiningDirectoryIcon> protectionIcons = new List<MiningDirectoryIcon>();

	public int digCount;

	[NonSerialized]
	public bool isRewardStale;

	private int numRows = 8;

	private int numCols = 12;

	private Coord lastClickedCoord;

	public new const int energyCost = 10;

	private TextFlashAnimation textAnimationAttempts;

	private const bool harvestImmediately = true;

	public List<Sprite> surfaceSprites;

	public override void Initialize()
	{
		base.Initialize();
		textAnimationAttempts = new TextFlashAnimation(attemptsRemainingLabel);
		LoadGemShapes();
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		if (isRewardStale)
		{
			CalcReward();
		}
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		attemptsRemainingLabel.text = "AttemptsRemaining".Localized();
		oreChunksRemainingLabel.text = "OreChunksRemaining".Localized();
	}

	public override void CreateItems()
	{
		CreateMiningButtons();
		levelStat = MenuPanel.gm.minigameMining;
		energyTracker = MenuPanel.gm.energyMining;
		rewardEntities.AddItem(ItemType.Stone, 10.0);
		rewardEntities.AddItem(ItemType.IronOre, 8.0);
		rewardEntities.AddItem(ItemType.Coal, 8.0);
		rewardEntities.AddItem(ItemType.CopperOre, 8.0);
		rewardEntities.AddItem(ItemType.SilverOre, 4.0);
		rewardEntities.AddItem(ItemType.GoldOre, 3.0);
		rewardEntities.AddItem(ItemType.Mana, 2.0);
		rewardEntities.AddItem(ItemType.RedRuby, 1.0);
		rewardEntities.AddItem(ItemType.YellowTopaz, 1.0);
		rewardEntities.AddItem(ItemType.BlueSapphire, 1.0);
		rewardEntities.AddItem(ItemType.PurpleAmethyst, 1.0);
		base.CreateItems();
	}

	protected override void LoadNewMinigame()
	{
		base.LoadNewMinigame();
		ResetButtons();
		CreateGemInstances();
		FillWithStones(60);
		maxNumAttempts = 3;
		digCount = 0;
		DisplayAttemptIcons(maxNumAttempts);
		UpdateProtectionIcons();
	}

	public void UpdateProtectionIcons()
	{
		int num = GameManager.Instance.LevelOfGlobalUpgrade(UpgradeType.LuckyPickaxe) - digCount;
		for (int i = 0; i < protectionIcons.Count; i++)
		{
			protectionIcons[i].gameObject.SetActive(i < num);
		}
	}

	public override void DisplayAttemptIcons(int num)
	{
		int num2 = 3;
		for (int i = 0; i < num2; i++)
		{
			MiningDirectoryIcon miningDirectoryIcon = null;
			if (i < protectionIcons.Count)
			{
				miningDirectoryIcon = protectionIcons[i];
			}
			else
			{
				miningDirectoryIcon = MenuManager.GetMenuObject(MenuManager.Instance.attemptIconPrefab, attemptsGroup.transform).GetComponent<MiningDirectoryIcon>();
				protectionIcons.Add(miningDirectoryIcon);
			}
			miningDirectoryIcon.gameObject.SetActive(value: true);
			miningDirectoryIcon.shapeImage.sprite = IconManager.Instance.luckyPickaxe;
			miningDirectoryIcon.checkmark.sprite = IconManager.Instance.invalidSlash;
			miningDirectoryIcon.checkmark.gameObject.SetActive(value: false);
		}
		base.DisplayAttemptIcons(num);
	}

	private float ValueForIndividualBlock()
	{
		return 0f;
	}

	private float XpForExcavatedGemBlock()
	{
		return 3f * MenuPanel.gm.MultiplierForGlobalPerk(PerkType.MinigameXPGainSpeed);
	}

	protected override void CalcYield()
	{
		base.CalcYield();
		yieldBaselineUpgraded = yieldBaseline * MenuPanel.gm.MultiplierForGlobalUpgrade(UpgradeType.MinigameMiningYield);
	}

	private float ValueForExcavatedGemBlock()
	{
		return yieldBaselineUpgraded * yieldMultiplier;
	}

	public void OnReveal(MiningButton b)
	{
		if (b.item != ItemType.Stone && b.item != ItemType.None)
		{
			float num = ValueForIndividualBlock();
			if (num > 0f)
			{
				EarnReward(num);
				AnimateItemGain(b.transform, num);
			}
		}
		MenuManager.Instance.PlayDigParticles(b.transform.position);
	}

	protected override bool IsPerfect()
	{
		return IsMapCompletelyExcavated();
	}

	protected override void DisplayFinalCompletionState()
	{
		base.DisplayFinalCompletionState();
		RevealEntireMap();
	}

	protected override void SetPerfect()
	{
		float num = ValueForExcavatedGemBlock() * 10f;
		if (MenuPanel.gm.gameState == GameState.InGame)
		{
			EarnReward(num);
			minigameFooter.SetPerfect(num, animated: false);
			AnimateItemGain(minigameFooter.perfectionBonusSection.transform, num, 5);
		}
		else
		{
			minigameFooter.SetPerfect(num, animated: false);
		}
	}

	private void LoadGemShapes()
	{
		foreach (List<Coord> item in new List<List<Coord>>
		{
			new List<Coord>
			{
				new Coord(-1, 0),
				new Coord(0, 0),
				new Coord(1, 0)
			},
			new List<Coord>
			{
				new Coord(0, -1),
				new Coord(0, 0),
				new Coord(0, 1)
			},
			new List<Coord>
			{
				new Coord(0, -1),
				new Coord(0, 0),
				new Coord(0, 1),
				new Coord(1, 1)
			},
			new List<Coord>
			{
				new Coord(0, -1),
				new Coord(0, 0),
				new Coord(0, 1),
				new Coord(-1, 1)
			},
			new List<Coord>
			{
				new Coord(0, -1),
				new Coord(0, 0),
				new Coord(0, 1),
				new Coord(0, 2)
			},
			new List<Coord>
			{
				new Coord(0, -1),
				new Coord(0, 0),
				new Coord(0, 1),
				new Coord(1, 0),
				new Coord(2, 0)
			},
			new List<Coord>
			{
				new Coord(-1, 0),
				new Coord(0, 0),
				new Coord(1, 0),
				new Coord(0, 1),
				new Coord(0, -1)
			},
			new List<Coord>
			{
				new Coord(-1, 1),
				new Coord(-1, 0),
				new Coord(0, 0),
				new Coord(0, -1),
				new Coord(1, -1)
			},
			new List<Coord>
			{
				new Coord(-1, 0),
				new Coord(0, 0),
				new Coord(1, 0),
				new Coord(-1, 1),
				new Coord(0, 1)
			},
			new List<Coord>
			{
				new Coord(1, 1),
				new Coord(0, 1),
				new Coord(0, 0),
				new Coord(0, -1),
				new Coord(1, -1)
			},
			new List<Coord>
			{
				new Coord(1, 1),
				new Coord(0, 1),
				new Coord(0, 0),
				new Coord(-1, 0)
			},
			new List<Coord>
			{
				new Coord(-1, 1),
				new Coord(0, 1),
				new Coord(0, 0),
				new Coord(1, 0)
			},
			new List<Coord>
			{
				new Coord(1, 1),
				new Coord(0, 1),
				new Coord(0, 0),
				new Coord(-1, 0),
				new Coord(-2, 0)
			},
			new List<Coord>
			{
				new Coord(-1, 1),
				new Coord(0, 1),
				new Coord(0, 0),
				new Coord(1, 0),
				new Coord(2, 0)
			},
			new List<Coord>
			{
				new Coord(0, -1),
				new Coord(0, 0),
				new Coord(-1, 0),
				new Coord(0, 1),
				new Coord(1, 1)
			},
			new List<Coord>
			{
				new Coord(0, 1),
				new Coord(0, 0),
				new Coord(1, 0),
				new Coord(0, -1),
				new Coord(-1, -1)
			}
		})
		{
			AddShapeFromTemplate(item, 0);
			AddShapeFromTemplate(item, 1);
			AddShapeFromTemplate(item, 2);
			AddShapeFromTemplate(item, 3);
		}
	}

	private MiningGemShape AddShapeFromTemplate(List<Coord> shape, int numRotations)
	{
		MiningGemShape miningGemShape = new MiningGemShape();
		if (numRotations == 0)
		{
			miningGemShape.offsets = shape;
		}
		else
		{
			List<Coord> list = new List<Coord>();
			foreach (Coord item in shape)
			{
				list.Add(item.Rotated(numRotations));
			}
			miningGemShape.offsets = list;
		}
		miningGemShape.shapeSprite = IconManager.SpriteForMiningShape(miningGemShape.offsets);
		gemShapes.Add(miningGemShape);
		return miningGemShape;
	}

	public override void ResetMinigame()
	{
		digCount = 0;
		base.ResetMinigame();
		ResetButtons();
	}

	private void ResetButtons()
	{
		foreach (List<MiningButton> buttonRow in buttonRows)
		{
			foreach (MiningButton item in buttonRow)
			{
				item.ResetState();
			}
		}
		foreach (Transform item2 in directoryGroup.transform)
		{
			UnityEngine.Object.Destroy(item2.gameObject);
		}
		directoryIcons.Clear();
		RandomizeSurfaces();
	}

	private void CreateGemInstances()
	{
		CreateGemInstance(ItemType.PurifiedFire);
		CreateGemInstance(ItemType.PurifiedWater);
		CreateGemInstance(ItemType.PurifiedEarth);
		CreateGemInstance(ItemType.PurifiedAir);
	}

	private void FillWithStones(int p)
	{
		foreach (List<MiningButton> buttonRow in buttonRows)
		{
			foreach (MiningButton item in buttonRow)
			{
				if (item.item == ItemType.None && UnityEngine.Random.Range(0, 100) < p)
				{
					item.AssignItem(ItemType.Stone);
				}
			}
		}
	}

	private void CreateDirectoryEntryForInstance(MiningGemInstance i)
	{
		MiningDirectoryIcon component = MenuManager.GetMenuObject(directoryIconPrefab, directoryGroup.transform).GetComponent<MiningDirectoryIcon>();
		component.checkmark.enabled = false;
		component.shapeImage.sprite = i.parentShape.shapeSprite;
		directoryIcons[i] = component;
	}

	private void CreateGemInstance(ItemType t)
	{
		int index = UnityEngine.Random.Range(0, gemShapes.Count);
		MiningGemShape miningGemShape = gemShapes[index];
		List<Coord> list = new List<Coord>();
		for (int i = 0; i < 100; i++)
		{
			int num = UnityEngine.Random.Range(0, buttonRows.Count);
			List<MiningButton> list2 = buttonRows[num];
			int x = UnityEngine.Random.Range(0, list2.Count);
			Coord centerCoord = new Coord(x, num);
			foreach (Coord offset in miningGemShape.offsets)
			{
				list.Add(centerCoord.Offset(offset));
			}
			bool flag = true;
			foreach (Coord item in list)
			{
				if (!IsValidGemLocation(item))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				MiningGemInstance gemInstance = new MiningGemInstance(t, miningGemShape, centerCoord, list);
				ProcessGemInstance(gemInstance);
				break;
			}
			list.Clear();
		}
	}

	private void ProcessGemInstance(MiningGemInstance gemInstance)
	{
		CreateDirectoryEntryForInstance(gemInstance);
		foreach (Coord formationCoord in gemInstance.formationCoords)
		{
			if (TryGetButton(formationCoord, out var result))
			{
				result.parentGemFormation = gemInstance;
				result.AssignItem(gemInstance.itemType);
			}
			else
			{
				Debug.LogError("No button at " + formationCoord.ToString() + " for item " + gemInstance.itemType);
			}
		}
	}

	private bool IsValidGemLocation(Coord c)
	{
		if (TryGetButton(c, out var result))
		{
			return result.item == ItemType.None;
		}
		return false;
	}

	private bool TryGetButton(Coord c, out MiningButton result)
	{
		if (c.y >= 0 && c.y < buttonRows.Count)
		{
			List<MiningButton> list = buttonRows[c.y];
			if (c.x >= 0 && c.x < list.Count)
			{
				result = list[c.x];
				return true;
			}
		}
		result = null;
		return false;
	}

	private void CreateMiningButtons()
	{
		int num = numCols;
		miningGroup.constraintCount = num;
		for (int i = 0; i < numRows; i++)
		{
			List<MiningButton> list = new List<MiningButton>();
			buttonRows.Add(list);
			for (int j = 0; j < num; j++)
			{
				MiningButton miningButton = CreateMiningButton(j, i);
				list.Add(miningButton);
				if (useDebugTransparency)
				{
					Color color = miningButton.cover.color;
					miningButton.cover.color = new Color(color.r, color.g, color.b, 0.5f);
				}
			}
		}
	}

	private MiningButton CreateMiningButton(int x, int y)
	{
		MiningButton component = MenuManager.GetMenuObject(miningButtonPrefab, miningGroup.transform).GetComponent<MiningButton>();
		component.Init(x, y);
		component.parentMap = this;
		return component;
	}

	public void AutoReveal(Coord c)
	{
		if (TryGetButton(c, out var result) && !result.isRevealed)
		{
			Vector2.Distance(lastClickedCoord.AsVector2, result.coord.AsVector2);
			float num = lastClickedCoord.GridDistanceFrom(result.coord);
			result.Reveal(num * 0.03f);
			if (result.item == ItemType.None)
			{
				RevealSurroundingFrom(result);
			}
		}
	}

	public void BeginRevealSurroundingFrom(MiningButton b)
	{
		lastClickedCoord = b.coord;
		RevealSurroundingFrom(b);
	}

	public void RevealSurroundingFrom(MiningButton b)
	{
		AutoReveal(b.coord.Left());
		AutoReveal(b.coord.Right());
		AutoReveal(b.coord.Up());
		AutoReveal(b.coord.Down());
	}

	private void CalcGemInstanceState(MiningGemInstance gemInstance)
	{
		gemInstance.numRevealed = 0;
		foreach (Coord formationCoord in gemInstance.formationCoords)
		{
			if (TryGetButton(formationCoord, out var result) && result.isRevealed)
			{
				gemInstance.numRevealed++;
			}
		}
	}

	public void TryUnlockFormation(MiningGemInstance gemInstance)
	{
		CalcGemInstanceState(gemInstance);
		if (!gemInstance.IsFullyUncovered())
		{
			return;
		}
		bool flag = false;
		foreach (Coord formationCoord in gemInstance.formationCoords)
		{
			if (TryGetButton(formationCoord, out var result))
			{
				result.Unlock();
				if (!flag && directoryIcons.TryGetValue(result.parentGemFormation, out var value))
				{
					value.shapeImage.color = ColorForItem(result.item);
					flag = true;
				}
				if (MenuPanel.gm.gameState == GameState.InGame)
				{
					Transform transform = result.transform;
					transform.DOShakePosition(0.5f, new Vector3(10f, 0f, 0f), 10, 0f);
					MenuManager.Instance.PlayStarParticles(transform.position);
				}
			}
		}
		if (MenuPanel.gm.gameState == GameState.InGame)
		{
			AnimateExcavation(gemInstance);
		}
	}

	private void AnimateExcavation(MiningGemInstance gemInstance)
	{
		if (MenuPanel.gm.gameState != GameState.InGame)
		{
			return;
		}
		GameObject gameObject = new GameObject();
		Transform obj = gameObject.transform;
		obj.SetParent(base.transform);
		obj.localScale = Vector3.one;
		obj.position = AveragePosition(gemInstance);
		foreach (Coord formationCoord in gemInstance.formationCoords)
		{
			if (TryGetButton(formationCoord, out var result))
			{
				MiningButton component = MenuManager.GetMenuObject(miningButtonPrefab, gameObject.transform).GetComponent<MiningButton>();
				Transform obj2 = component.transform;
				obj2.localScale = Vector3.one;
				obj2.position = result.transform.position;
				component.item = result.item;
				component.isRevealed = true;
				component.isExcavated = false;
				component.UpdateItemIcon();
			}
		}
		gameObject.AddComponent<MiningExcavation>().gemInstance = gemInstance;
		TryExcavateFormation(gemInstance);
	}

	public Vector3 AveragePosition(MiningGemInstance gemInstance)
	{
		Vector3 zero = Vector3.zero;
		foreach (Coord formationCoord in gemInstance.formationCoords)
		{
			if (TryGetButton(formationCoord, out var result))
			{
				zero += result.transform.position;
			}
		}
		return zero / gemInstance.formationCoords.Count;
	}

	public static Color ColorForItem(ItemType t)
	{
		return t switch
		{
			ItemType.PurifiedFire => new Color(0.98f, 0.05f, 0.05f, 1f), 
			ItemType.PurifiedAir => new Color(0.98f, 0.98f, 0.05f, 1f), 
			ItemType.PurifiedWater => new Color(0.05f, 0.58f, 0.98f, 1f), 
			ItemType.PurifiedEarth => new Color(0.98f, 0.05f, 0.98f, 1f), 
			_ => Color.white, 
		};
	}

	public void TryExcavateFormation(MiningGemInstance gemInstance)
	{
		CalcGemInstanceState(gemInstance);
		if (!gemInstance.IsFullyUncovered())
		{
			return;
		}
		gemInstance.Excavate();
		isRewardStale = true;
		if (directoryIcons.TryGetValue(gemInstance, out var value))
		{
			value.checkmark.enabled = true;
		}
		foreach (Coord formationCoord in gemInstance.formationCoords)
		{
			if (TryGetButton(formationCoord, out var result))
			{
				float num = ValueForExcavatedGemBlock();
				float num2 = XpForExcavatedGemBlock();
				result.Excavate();
				if (num > 0f)
				{
					EarnReward(num);
				}
				RevealSurroundingFrom(result);
			}
		}
		TestForVictory();
	}

	public void AnimateBonus(MiningExcavation excavation)
	{
		foreach (Transform item in excavation.transform)
		{
			float num = ValueForExcavatedGemBlock();
			float num2 = XpForExcavatedGemBlock();
			if (num > 0f)
			{
				AnimateItemGain(item.transform, num);
			}
			if (num2 > 0f)
			{
				AnimateToExperience(item.transform, levelStat.iconItem, num2, 1);
			}
		}
	}

	private bool IsMapCompletelyExcavated()
	{
		foreach (KeyValuePair<MiningGemInstance, MiningDirectoryIcon> directoryIcon in directoryIcons)
		{
			if (!directoryIcon.Key.isExcavated)
			{
				return false;
			}
		}
		return true;
	}

	private void TestForVictory()
	{
		if (IsMapCompletelyExcavated())
		{
			DeclareVictory();
		}
	}

	public void OnClickedRock()
	{
		ConsumeAttempt();
	}

	protected override void DeclareFailure()
	{
		base.DeclareFailure();
		if (MenuPanel.gm.gameState == GameState.InGame)
		{
			AnimateFailure();
			DisplayFinalCompletionState();
		}
	}

	private void RevealEntireMap()
	{
		foreach (List<MiningButton> buttonRow in buttonRows)
		{
			foreach (MiningButton item in buttonRow)
			{
				if (!item.isRevealed)
				{
					Color color = item.cover.color;
					item.cover.color = new Color(color.r, color.g, color.b, 0.5f);
				}
			}
		}
	}

	public void AnimateFailure()
	{
		textAnimationAttempts.Run();
	}

	protected override void CalcReward()
	{
	}

	protected override void LoadFromDictionary(Dictionary<string, fsData> dataDict)
	{
		base.LoadFromDictionary(dataDict);
		SaveFile.TryLoadInt(dataDict, "count", ref digCount);
		if (dataDict.TryGetValue("ds", out var value))
		{
			Coord coord = SaveFile.CoordFromData(value);
			numCols = coord.x;
			numRows = coord.y;
		}
		if (dataDict.TryGetValue("Items", out var value2) && value2.TryAsList(out var result))
		{
			foreach (fsData item in result)
			{
				if (!item.TryAsList(out var result2) || result2.Count < 3)
				{
					continue;
				}
				fsData data = result2[0];
				fsData data2 = result2[1];
				fsData data3 = result2[2];
				Coord c = SaveFile.CoordFromData(data);
				data2.TryAsBool(out var b);
				data3.TryAsBool(out var b2);
				if (TryGetButton(c, out var result3))
				{
					result3.isRevealed = b;
					if (b2)
					{
						result3.item = ItemType.Stone;
					}
				}
			}
		}
		if (!dataDict.TryGetValue("formations", out var value3) || !value3.TryAsList(out var result4))
		{
			return;
		}
		foreach (fsData item2 in result4)
		{
			LoadGemInstanceFromData(item2);
		}
	}

	protected override void PostProcessLoadedData()
	{
		base.PostProcessLoadedData();
		foreach (List<MiningButton> buttonRow in buttonRows)
		{
			foreach (MiningButton item in buttonRow)
			{
				item.UpdateItemIcon();
			}
		}
		if (IsMapCompletelyExcavated())
		{
			SetPerfect();
		}
		UpdateProtectionIcons();
		RandomizeSurfaces();
	}

	private bool Matches(List<Coord> list1, List<Coord> list2)
	{
		if (list1.Count != list2.Count)
		{
			return false;
		}
		foreach (Coord item in list1)
		{
			if (!list2.Contains(item))
			{
				return false;
			}
		}
		return true;
	}

	private MiningGemShape TryGetGemShape(Coord center, List<Coord> formationCoords)
	{
		List<Coord> list = new List<Coord>();
		foreach (Coord formationCoord in formationCoords)
		{
			list.Add(formationCoord.Offset(-center.x, -center.y));
		}
		foreach (MiningGemShape gemShape in gemShapes)
		{
			if (Matches(gemShape.offsets, list))
			{
				return gemShape;
			}
		}
		return AddShapeFromTemplate(list, 0);
	}

	public override fsData GetData()
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		StoreCommonData(dictionary);
		dictionary["ds"] = SaveFile.DataFromCoord(new Coord(numCols, numRows));
		List<fsData> list = new List<fsData>();
		foreach (KeyValuePair<MiningGemInstance, MiningDirectoryIcon> directoryIcon in directoryIcons)
		{
			MiningGemInstance key = directoryIcon.Key;
			list.Add(DataFromGemInstance(key));
		}
		dictionary["formations"] = new fsData(list);
		dictionary["count"] = new fsData(digCount);
		List<fsData> list2 = new List<fsData>();
		foreach (List<MiningButton> buttonRow in buttonRows)
		{
			foreach (MiningButton item in buttonRow)
			{
				if (item.isRevealed || item.item == ItemType.Stone)
				{
					List<fsData> list3 = new List<fsData>();
					list3.Add(SaveFile.DataFromCoord(item.coord));
					list3.Add(new fsData(item.isRevealed));
					list3.Add(new fsData(item.item == ItemType.Stone));
					list2.Add(new fsData(list3));
				}
			}
		}
		dictionary["Items"] = new fsData(list2);
		return new fsData(dictionary);
	}

	private fsData DataFromGemInstance(MiningGemInstance i)
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		dictionary["item"] = new fsData((long)i.itemType);
		if (i.isExcavated)
		{
			dictionary["fullyExcavated"] = fsData.True;
		}
		dictionary["revealed"] = new fsData(i.numRevealed);
		List<fsData> list = new List<fsData>();
		foreach (Coord formationCoord in i.formationCoords)
		{
			list.Add(SaveFile.DataFromCoord(formationCoord));
		}
		dictionary["Coords"] = new fsData(list);
		dictionary["center"] = SaveFile.DataFromCoord(i.center);
		return new fsData(dictionary);
	}

	private void LoadGemInstanceFromData(fsData gemInstanceData)
	{
		if (!gemInstanceData.TryAsDictionary(out var result) || !result.TryGetValue("center", out var value) || !result.TryGetValue("Coords", out var value2) || !value2.TryAsList(out var result2))
		{
			return;
		}
		SaveFile.TryLoadIntOut(result, "item", out var targetInt);
		ItemType t = (ItemType)targetInt;
		Coord coord = SaveFile.CoordFromData(value);
		SaveFile.TryLoadIntOut(result, "revealed", out var targetInt2);
		bool flag = result.ContainsKey("fullyExcavated");
		List<Coord> list = new List<Coord>();
		foreach (fsData item in result2)
		{
			list.Add(SaveFile.CoordFromData(item));
		}
		MiningGemShape parent = TryGetGemShape(coord, list);
		MiningGemInstance miningGemInstance = new MiningGemInstance(t, parent, coord, list);
		ProcessGemInstance(miningGemInstance);
		miningGemInstance.numRevealed = targetInt2;
		miningGemInstance.isExcavated = flag;
		TryUnlockFormation(miningGemInstance);
		if (!flag)
		{
			return;
		}
		if (directoryIcons.TryGetValue(miningGemInstance, out var value3))
		{
			value3.checkmark.enabled = true;
		}
		foreach (Coord formationCoord in miningGemInstance.formationCoords)
		{
			if (TryGetButton(formationCoord, out var result3))
			{
				result3.Excavate();
			}
		}
	}

	public override bool ShouldBeAvailable()
	{
		return false;
	}

	public void RandomizeSurfaces()
	{
		foreach (List<MiningButton> buttonRow in buttonRows)
		{
			foreach (MiningButton item in buttonRow)
			{
				int index = UnityEngine.Random.Range(0, surfaceSprites.Count);
				item.cover.sprite = surfaceSprites[index];
			}
		}
	}
}

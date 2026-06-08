using UnityEngine;

public class SaveFilesRow : DialogButton
{
	private enum Mode
	{
		SavedGame = 0,
		NewGame = 1
	}

	public int heroX = 5;

	public int heroY = 3;

	public AsciiString playerNameLabel;

	public AsciiString playerLevelLabel;

	public AsciiString totalStarsLabel;

	public AsciiString gearPointsLabel;

	public AsciiString gearPointsValue;

	public int gearPointsOffsetY;

	public DialogButton newStoryButton;

	public AsciiString newStoryLabel;

	private SaveFiles.SaveFileMeta _saveFile;

	private Mode mode;

	private Hero myHero;

	public SaveFiles.SaveFileMeta saveFile
	{
		get
		{
			return _saveFile;
		}
		set
		{
			_saveFile = value;
			UpdateContents();
		}
	}

	public Hero hero => myHero;

	public void UpdateContents()
	{
		if (saveFile != null)
		{
			mode = Mode.SavedGame;
			string text = saveFile.playerName;
			if (text == "New Story")
			{
				text = Te.xt(text);
			}
			playerNameLabel.SetValue(text);
			if (saveFile.playerLevel == 0)
			{
				playerLevelLabel.Clear();
			}
			else
			{
				string format = Te.xt("Lv{0}");
				format = string.Format(format, saveFile.playerLevel);
				playerLevelLabel.SetValue(format);
			}
			if (saveFile.totalStars == 0)
			{
				totalStarsLabel.Clear();
			}
			else
			{
				totalStarsLabel.SetValue("☆" + saveFile.totalStars + "☆");
			}
			if (ShowGearPoints())
			{
				gearPointsValue.SetValue($"{saveFile.gearPoints:n0}");
			}
			if (myHero.LeftHand != null)
			{
				Object.Destroy(myHero.LeftHand.gameObject);
				myHero.LeftHand = null;
			}
			Weapon weapon = LoadItem(saveFile.leftItemId, saveFile.leftItemData);
			if (weapon != null)
			{
				myHero.EquipLeft(weapon);
			}
			if (myHero.RightHand != null)
			{
				Object.Destroy(myHero.RightHand.gameObject);
				myHero.RightHand = null;
			}
			weapon = LoadItem(saveFile.rightItemId, saveFile.rightItemData);
			if (weapon != null)
			{
				myHero.EquipRight(weapon);
			}
			myHero.bigHead.enabled = saveFile.bigHead;
		}
		else
		{
			mode = Mode.NewGame;
		}
	}

	private Weapon LoadItem(string itemId, string itemData)
	{
		if (string.IsNullOrEmpty(itemId))
		{
			return null;
		}
		Item item = ItemFactory.singleton.MakeItem(itemId);
		if (item == null)
		{
			Utils.LogError("[SaveFilesRow] Item " + itemId + " failed to load.");
			return null;
		}
		Weapon weapon = item as Weapon;
		if (weapon == null)
		{
			Utils.LogError("[SaveFilesRow] loaded equipped item " + itemId + " but it's not a Weapon.");
			return null;
		}
		if (itemData != null)
		{
			weapon.ParseData(itemData);
		}
		return weapon;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (mode == Mode.SavedGame)
		{
			if (ShowGearPoints())
			{
				offsetY -= gearPointsOffsetY;
			}
			playerNameLabel.Draw(r, offsetX, offsetY);
			playerLevelLabel.Draw(r, offsetX, offsetY);
			totalStarsLabel.Draw(r, offsetX, offsetY);
			if (ShowGearPoints())
			{
				gearPointsLabel.Draw(r, offsetX, offsetY);
				gearPointsValue.Draw(r, offsetX, offsetY);
				offsetY += gearPointsOffsetY;
			}
		}
		else
		{
			newStoryButton.Draw(r, offsetX, offsetY);
			newStoryLabel.Draw(r, offsetX, offsetY);
		}
		base.Draw(r, offsetX, offsetY);
		if (mode == Mode.SavedGame)
		{
			int offsetX2 = offsetX + heroX - myHero.PositionX;
			int offsetY2 = offsetY + heroY - myHero.PositionZ + myHero.PositionY;
			myHero.Draw(r, offsetX2, offsetY2);
		}
	}

	private bool ShowGearPoints()
	{
		if (saveFile.totalStars >= 35)
		{
			return saveFile.gearPoints > 0;
		}
		return false;
	}

	protected override void Awake()
	{
		base.Awake();
		myHero = Object.Instantiate(GameStates.Singleton.heroPrefab);
	}
}

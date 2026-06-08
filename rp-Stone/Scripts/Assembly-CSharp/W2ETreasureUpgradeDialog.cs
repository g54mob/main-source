using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class W2ETreasureUpgradeDialog : TwoChoiceDialog
{
	public AsciiString title;

	public AsciiString smallArrow;

	public int leftIconX;

	public int leftIconY;

	public int rightIconX;

	public int rightIconY;

	private AsciiSprite leftIcon;

	private AsciiSprite rightIcon;

	private int iconPaddingLeftX;

	private int iconPaddingRightX;

	private TreasureItem currentTreasure;

	private TreasureItem upgradedTreasure;

	private bool isClickable = true;

	public static Dictionary<string, string> treasureUpgrades = new Dictionary<string, string>
	{
		{ "treasure_0", "treasure_2" },
		{ "treasure_1", "treasure_2" },
		{ "treasure_2", "treasure_3" },
		{ "treasure_3", "treasure_4" },
		{ "bone", "skullnata" }
	};

	private static string LAST_TREASURE_UPGRADE_KEY = "last_treasure_upgrade";

	private static int TREASURE_UPGRADE_INTERVAL = 10;

	private static int TREASURE_UPGRADE_INTERVAL_PC = 4248;

	public static bool InCooldownPeriod()
	{
		if (PlayerPrefs.HasKey(LAST_TREASURE_UPGRADE_KEY))
		{
			DateTime dateTime = DateTime.Parse(PlayerPrefs.GetString(LAST_TREASURE_UPGRADE_KEY), CultureInfo.InvariantCulture);
			int tREASURE_UPGRADE_INTERVAL_PC = TREASURE_UPGRADE_INTERVAL_PC;
			DateTime dateTime2 = dateTime.AddMinutes(tREASURE_UPGRADE_INTERVAL_PC);
			Debug.Log("treasure_upgrade will next be available at: " + dateTime2);
			if (dateTime2 <= DateTime.Now)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool CanTreasureBeUpgraded(string itemId)
	{
		return treasureUpgrades.ContainsKey(itemId);
	}

	public override void Show()
	{
		int height = Height;
		int positionY = PositionY;
		base.Show();
		Height = height;
		PositionY = positionY;
	}

	public void Setup(TreasureItem passedCurrentTreasure, TreasureItem passedUpgradedTreasure)
	{
		currentTreasure = passedCurrentTreasure;
		upgradedTreasure = passedUpgradedTreasure;
		leftIcon = ((currentTreasure != null) ? currentTreasure.GetIcon() : null);
		rightIcon = ((upgradedTreasure != null) ? upgradedTreasure.GetIcon() : null);
		UpdateMessage();
		if (currentTreasure != null && currentTreasure.type == TreasureItem.Type.Bone)
		{
			iconPaddingLeftX = -2;
			iconPaddingRightX = 1;
		}
		else
		{
			iconPaddingLeftX = 0;
			iconPaddingRightX = 0;
		}
	}

	private void UpdateMessage()
	{
		string format = Te.xt("tid_w2e_upgrade_message");
		string arg = ((upgradedTreasure != null) ? upgradedTreasure.GetName() : "?");
		SetMessage(string.Format(format, arg));
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.CurrentState == State.Idle && base.ElapsedStateTics == 1800 && OuroborosWeapon.IsEnabled())
		{
			Hide();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState == State.Idle)
		{
			offsetX += PositionX;
			offsetY += PositionY;
			title.Draw(r, offsetX, offsetY);
			smallArrow.Draw(r, offsetX, offsetY);
			if (leftIcon != null)
			{
				leftIcon.Draw(r, offsetX + leftIconX + iconPaddingLeftX, offsetY + leftIconY);
			}
			if (rightIcon != null)
			{
				rightIcon.Draw(r, offsetX + rightIconX + iconPaddingRightX, offsetY + rightIconY);
			}
		}
	}

	private void TryWatchToEarn()
	{
		isClickable = false;
		GiveUpgradedTreasure();
		StartCooldownPeriod();
		Hide();
		isClickable = true;
	}

	public static void StartCooldownPeriod()
	{
		PlayerPrefs.SetString(LAST_TREASURE_UPGRADE_KEY, DateTime.Now.ToString(CultureInfo.InvariantCulture));
	}

	private void GiveCurrentTreasure()
	{
		Inventory.Singleton.GainItem(currentTreasure);
		SequentialPopupManager.singleton.ScheduleItemFound(currentTreasure);
	}

	private void GiveUpgradedTreasure()
	{
		Inventory.Singleton.GainItem(upgradedTreasure);
		SequentialPopupManager.singleton.ScheduleItemFound(upgradedTreasure);
	}

	private void HandleOnOkPressed(DialogButton button)
	{
		TryWatchToEarn();
	}

	private void HandleOnCancelPressed(DialogButton button)
	{
		StartCooldownPeriod();
		GiveCurrentTreasure();
		Hide();
	}

	private void HandleOnClickedOutside()
	{
		if (!isClickable)
		{
			Debug.Log("TreasureUpgradeDialog.HandleOnClickedOutside skipping because not isClickable");
			return;
		}
		Debug.Log("TreasureUpgradeDialog.HandleOnClickedOutside processing.");
		GiveCurrentTreasure();
		if (clickOutsideHides)
		{
			Hide();
		}
	}

	protected override void Start()
	{
		base.OnClickedOutside += HandleOnClickedOutside;
		if (okButton != null)
		{
			okButton.OnPressed += HandleOnOkPressed;
		}
		if (cancelButton != null)
		{
			cancelButton.OnPressed += HandleOnCancelPressed;
		}
	}

	protected new void OnDestroy()
	{
		base.OnClickedOutside -= HandleOnClickedOutside;
		if (okButton != null)
		{
			okButton.OnPressed -= HandleOnOkPressed;
		}
		if (cancelButton != null)
		{
			cancelButton.OnPressed -= HandleOnCancelPressed;
		}
	}
}

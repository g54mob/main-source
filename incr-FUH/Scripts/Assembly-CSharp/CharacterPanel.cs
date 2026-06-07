using System;

public class CharacterPanel : BaseBuildingPanel
{
	public ColumnController PanelColumn;

	public PanelTitle Title;

	public MixedRow RowAmount;

	public MixedRow RowCarry;

	public MixedRow RowSpeed;

	public MixedRow Recall;

	private bool _isFirstBuy = true;

	private void Start()
	{
		Title.Initialize(base.gameObject, "Peon");
		RowAmount.Initialize(base.gameObject, MixedRow.StateEnum.Full, "Amount");
		RowCarry.Initialize(base.gameObject, MixedRow.StateEnum.NoButton, "Carry");
		Recall.Initialize(base.gameObject, MixedRow.StateEnum.NoValue, "Recall");
		RowSpeed.gameObject.SetActive(value: false);
		Title.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Peon", "", "Peons collect trash and work in buildings. If they get too sad, they'll jump into the hole.\n\nHappy Speed: " + BaseBuildingPanel.FormatPercentage(GameController.GlobalInfo.CharHappySpeed() - 1f) + "\nContent Speed: " + BaseBuildingPanel.FormatPercentage(GameController.GlobalInfo.CharNormalSpeed() - 1f) + "\nSad Speed: " + BaseBuildingPanel.FormatPercentage(GameController.GlobalInfo.CharSadSpeed() - 1f) + "\n", ""));
		RowAmount.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Peon", GameController.Instance.PeonController.GetCharacterCount() + "/" + SignChar.UpgradeInfo.GetMaxCharacterCount(), "Get a new peon. Peon can do different tasks and throw trash in the hole.", GetNewCharacterCost()));
		RowCarry.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Carry", "", "The amount of trash the peon can carry.\n\nCarry: " + GameController.GlobalInfo.GetCharacterCarryLimit(), ""));
		Recall.SetDynamicTooltip((TooltipPanel.TooltipInfo a) => a.Update("Recall", "", "Teleport all outside peons back to this location.", "Recall"));
		RowAmount.ButtonPressEvent += BuyNewCharacter;
		Recall.ButtonPressEvent += RecallPeon;
	}

	private void Update()
	{
		RowAmount.SetValue(GameController.Instance.PeonController.GetCharacterCount() + "/" + SignChar.UpgradeInfo.GetMaxCharacterCount());
		RowCarry.SetValue(GameController.GlobalInfo.GetCharacterCarryLimit().ToString());
		if (GameController.Instance.PeonController.GetCharacterCount() == 0)
		{
			RowCarry.gameObject.SetActive(value: false);
			Recall.gameObject.SetActive(value: false);
		}
		else
		{
			RowCarry.gameObject.SetActive(value: true);
			Recall.gameObject.SetActive(value: true);
		}
		RowAmount.SetButton(GetNewCharacterCost());
		if (GameController.Instance.PeonController.GetCharacterCount() >= SignChar.UpgradeInfo.GetMaxCharacterCount())
		{
			RowAmount.SetButtonColor(isOn: false);
		}
		else
		{
			RowAmount.SetButtonColor(SignChar.UpgradeInfo.NewCharacterCost() <= GameController.Instance.Money.Amount);
		}
		Recall.SetButton("Recall");
		SetPanelHeight();
		if (!FreezeScale)
		{
			PanelHelper.SetSize(this);
		}
	}

	public void BuyNewCharacter(object o, EventArgs e)
	{
		int num = SignChar.UpgradeInfo.NewCharacterCost();
		if (_isFirstBuy && GameController.Instance.PeonController.GetCharacterCount() > 0)
		{
			_isFirstBuy = false;
		}
		if ((GameController.Instance.Money.Amount >= num || num == 0) && GameController.Instance.PeonController.GetCharacterCount() < SignChar.UpgradeInfo.GetMaxCharacterCount())
		{
			GameController.Instance.GainMoney(-num);
			GameController.Instance.SignChar.SpawnCharacter();
			if (_isFirstBuy)
			{
				WorldCanvasController.Instance.ClosePanel();
				_isFirstBuy = false;
				TutorialController.Instance.EnablePart(2);
				TutorialController.Instance.EnablePart(3);
			}
		}
	}

	public void RecallPeon(object o, EventArgs e)
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ga_recall);
		GameController.Instance.PeonController.RecallAllCharacters();
	}

	private string GetMovementSpeedStr()
	{
		float characterSpeed = GameController.GlobalInfo.GetCharacterSpeed(isHappy: false, isContent: true, isSad: false);
		return ((float)Math.Round(characterSpeed, 1)).ToString();
	}

	private string GetNewCharacterCost()
	{
		if (GameController.Instance.PeonController.GetCharacterCount() >= SignChar.UpgradeInfo.GetMaxCharacterCount())
		{
			return "Max";
		}
		return SignChar.UpgradeInfo.NewCharacterCost().ToNumber() + "$";
	}

	protected override int GetRowCount()
	{
		return 0 + (RowAmount.gameObject.activeSelf ? 1 : 0) + (RowCarry.gameObject.activeSelf ? 1 : 0) + (RowSpeed.gameObject.activeSelf ? 1 : 0) + (Recall.gameObject.activeSelf ? 1 : 0);
	}
}

public class OfflineFarmRewards : DialogNineSlice
{
	public AsciiSprite titleBG;

	public AsciiString title;

	public AsciiString treasuresHeader;

	public MultiTreasureCountsUI treasuresUI;

	public AsciiString resourcesHeader;

	public AsciiString resourcesValues;

	public AsciiString resSpentHeader;

	public AsciiString resSpentValues;

	public DialogButton okButton;

	private int initialPosY;

	private int initialHeight;

	private bool drawResourcesGained;

	private bool drawResourcesSpent;

	public virtual void Show()
	{
		SfxController.singleton.Play("pickup_success");
		base.SetState(State.In);
	}

	public virtual void Hide()
	{
		base.SetState(State.Out);
	}

	public void Setup(OfflineFarmController.RewardsInfo rewardsInfo)
	{
		treasuresUI.Clear();
		if (rewardsInfo.treasuresCount != null)
		{
			for (int i = 0; i < rewardsInfo.treasuresCount.Length; i++)
			{
				int num = rewardsInfo.treasuresCount[i];
				if (num > 0)
				{
					treasuresUI.DisplayTreasure(i, num);
				}
			}
		}
		int num2 = initialHeight;
		string text = null;
		if (rewardsInfo.resGainedAmount > 0)
		{
			text = MoneyUI.BuildResourceString(rewardsInfo.resGainedAmount, rewardsInfo.resGainedType);
		}
		if (rewardsInfo.kiGained > 0)
		{
			if (text != null)
			{
				text += "   ";
			}
			text += MoneyUI.BuildResourceString(rewardsInfo.kiGained, Data.Resource.Xi);
		}
		if (text != null)
		{
			resourcesValues.SetValue(text);
			drawResourcesGained = true;
		}
		else
		{
			resourcesValues.Clear();
			drawResourcesGained = false;
			num2 -= 3;
		}
		string text2 = null;
		if (rewardsInfo.resSpentAmountA > 0)
		{
			text2 = MoneyUI.BuildResourceString(rewardsInfo.resSpentAmountA, rewardsInfo.resSpentTypeA);
		}
		if (rewardsInfo.resSpentAmountB > 0)
		{
			if (text2 != null)
			{
				text2 += "   ";
			}
			text2 += MoneyUI.BuildResourceString(rewardsInfo.resSpentAmountB, rewardsInfo.resSpentTypeB);
		}
		if (text2 != null)
		{
			resSpentValues.SetValue(text2);
			drawResourcesSpent = true;
		}
		else
		{
			resSpentValues.Clear();
			drawResourcesSpent = false;
			num2 -= 3;
		}
		Height = num2;
		PositionY = initialPosY + (initialHeight - num2) / 2;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		okButton.UpdateTic();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState == State.Idle)
		{
			offsetX += PositionX;
			offsetY += PositionY;
			titleBG.Draw(r, offsetX, offsetY);
			title.Draw(r, offsetX, offsetY);
			treasuresHeader.Draw(r, offsetX, offsetY);
			treasuresUI.Draw(r, offsetX, offsetY);
			if (drawResourcesGained)
			{
				resourcesHeader.Draw(r, offsetX, offsetY);
				resourcesValues.Draw(r, offsetX, offsetY);
			}
			else
			{
				offsetY -= 3;
			}
			if (drawResourcesSpent)
			{
				resSpentHeader.Draw(r, offsetX, offsetY);
				resSpentValues.Draw(r, offsetX, offsetY);
			}
			else
			{
				offsetY -= 3;
			}
			okButton.Draw(r, offsetX, offsetY);
		}
	}

	protected override void Start()
	{
		base.Start();
		initialPosY = PositionY;
		initialHeight = Height;
		okButton.OnPressed += HandleOnOkPressed;
		base.OnClickedOutside += HandleOnClickedOutside;
	}

	protected void OnDestroy()
	{
		okButton.OnPressed -= HandleOnOkPressed;
		base.OnClickedOutside -= HandleOnClickedOutside;
	}

	private void HandleOnOkPressed(DialogButton button)
	{
		Hide();
	}

	private void HandleOnClickedOutside()
	{
		Hide();
	}
}

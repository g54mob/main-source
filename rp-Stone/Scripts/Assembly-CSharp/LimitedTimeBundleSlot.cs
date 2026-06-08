using UnityEngine;

public class LimitedTimeBundleSlot : DialogButton
{
	public AsciiString title;

	public AsciiString subtitle;

	public AsciiString limitedTimeHeader0;

	public AsciiString limitedTimeHeader1;

	public AsciiString limitedTimeClock;

	public string[] preloadDependencies;

	public AsciiSprite[] contentSprites;

	private bool isLastChance;

	private bool isTimeRunningOut;

	public ShopData.LimitedTimeBundle bundleData { get; set; }

	protected long timeRunningOutSeconds { get; set; }

	public virtual Item MakeInventoryItem()
	{
		return null;
	}

	protected override void Start()
	{
		base.Start();
		string text = Te.xt("tid_shop_limited_time");
		string[] array = Utils.BreakIntoLines(text, 16);
		if (array.Length <= 1)
		{
			limitedTimeHeader0.SetValue(text);
			limitedTimeHeader1.Clear();
			limitedTimeClock.PositionY = limitedTimeHeader1.PositionY;
		}
		else
		{
			limitedTimeHeader0.SetValue(array[0]);
			limitedTimeHeader1.SetValue(array[1]);
			limitedTimeClock.PositionY = limitedTimeHeader1.PositionY + 1;
		}
		UpdateClock();
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.ElapsedStateTics % 15 == 0)
		{
			UpdateClock();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY;
		title.Draw(r, offsetX, offsetY);
		subtitle.Draw(r, offsetX, offsetY);
		for (int i = 0; i < contentSprites.Length; i++)
		{
			contentSprites[i].Draw(r, offsetX, offsetY);
		}
		limitedTimeHeader0.Draw(r, offsetX, offsetY);
		limitedTimeHeader1.Draw(r, offsetX, offsetY);
		if (isLastChance)
		{
			Color colorOverride = ((base.ElapsedStateTics % 30 < 15) ? ColorConstants.red : ColorConstants.darkRed);
			limitedTimeClock.Draw(r, offsetX, offsetY, colorOverride);
		}
		else if (isTimeRunningOut)
		{
			limitedTimeClock.Draw(r, offsetX, offsetY, ColorConstants.midRed);
		}
		else
		{
			limitedTimeClock.Draw(r, offsetX, offsetY);
		}
	}

	protected virtual void UpdateClock()
	{
		long remainingSeconds = bundleData.GetRemainingSeconds();
		if (remainingSeconds < 300)
		{
			isLastChance = true;
			limitedTimeClock.SetValue(Te.xt("tid_shop_last_chance"));
			return;
		}
		isLastChance = false;
		isTimeRunningOut = remainingSeconds < timeRunningOutSeconds;
		string value = Utils.FormatTimeCasual(remainingSeconds, morePrecision: true);
		limitedTimeClock.SetValue(value);
	}

	private void PreloadDependencies()
	{
		for (int i = 0; i < preloadDependencies.Length; i++)
		{
			Utils.PreloadAsyncPrefab(preloadDependencies[i]);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		PreloadDependencies();
		timeRunningOutSeconds = LimitedTimeBundlesController.TIME_48_HOURS_IN_SECONDS;
	}
}

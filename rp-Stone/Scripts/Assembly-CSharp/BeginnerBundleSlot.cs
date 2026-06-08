using UnityEngine;

public class BeginnerBundleSlot : LimitedTimeBundleSlot
{
	private int[] defaultContentPivots;

	protected override void Start()
	{
		base.Start();
		string text = Te.xt(base.bundleData.title);
		string[] array = Utils.BreakIntoLines(text, Width - 2);
		if (array.Length <= 1)
		{
			title.SetValue(text);
			subtitle.Clear();
			for (int i = 0; i < contentSprites.Length; i++)
			{
				contentSprites[i].pivotY = defaultContentPivots[i] + 1;
			}
		}
		else
		{
			title.SetValue(array[0]);
			subtitle.SetValue(array[1]);
			for (int j = 0; j < contentSprites.Length; j++)
			{
				contentSprites[j].pivotY = defaultContentPivots[j];
			}
		}
		title.PositionX = Width >> 1;
		subtitle.PositionX = title.PositionX;
		if (Mathf.Max(title.Length, subtitle.Length) % 2 == 0)
		{
			title.PositionX++;
			subtitle.PositionX++;
		}
		limitedTimeClock.PositionY = Height - 2;
	}

	protected override void UpdateClock()
	{
		base.UpdateClock();
		limitedTimeClock.PositionX = Width >> 1;
		if (limitedTimeClock.Length % 2 == 0)
		{
			limitedTimeClock.PositionX++;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		base.timeRunningOutSeconds = LimitedTimeBundlesController.TIME_1_HOUR_IN_SECONDS * 10;
		defaultContentPivots = new int[contentSprites.Length];
		for (int i = 0; i < contentSprites.Length; i++)
		{
			defaultContentPivots[i] = contentSprites[i].pivotY;
		}
	}
}

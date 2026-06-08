using UnityEngine;

public class ShopHiddenSlot : DialogNineSlice
{
	private enum HiddenSlotState
	{
		Normal = 0,
		Delay = 1,
		Open = 2,
		Disabled = 3
	}

	public AsciiString hiddenLabel;

	private HiddenSlotState currentHiddenSlotState;

	private int elapsedHiddenSlotTics;

	private int delayDuration;

	private readonly int OPEN_DURATION = 15;

	public bool IsDelayed()
	{
		return currentHiddenSlotState == HiddenSlotState.Delay;
	}

	public bool IsDisabled()
	{
		if (currentHiddenSlotState != HiddenSlotState.Normal)
		{
			return currentHiddenSlotState == HiddenSlotState.Disabled;
		}
		return true;
	}

	private void SetHiddenSlotState(HiddenSlotState newState)
	{
		if (newState == HiddenSlotState.Open)
		{
			SfxController.singleton.Play("booklet_turn_page");
		}
		currentHiddenSlotState = newState;
		elapsedHiddenSlotTics = 0;
	}

	public void Show(int delay)
	{
		delayDuration = delay;
		SetHiddenSlotState(HiddenSlotState.Delay);
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (currentHiddenSlotState == HiddenSlotState.Delay)
		{
			if (++elapsedHiddenSlotTics >= delayDuration)
			{
				SetHiddenSlotState(HiddenSlotState.Open);
			}
		}
		else if (currentHiddenSlotState == HiddenSlotState.Open && ++elapsedHiddenSlotTics >= OPEN_DURATION)
		{
			SetHiddenSlotState(HiddenSlotState.Disabled);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentHiddenSlotState != HiddenSlotState.Disabled)
		{
			if (currentHiddenSlotState == HiddenSlotState.Open)
			{
				float num = (float)elapsedHiddenSlotTics / (float)OPEN_DURATION;
				r.PushClip(new AsciiRenderProcedural.Clip
				{
					right = r.width - base.lastDrawX - Mathf.RoundToInt((float)(Width / 2) * (1f - num))
				});
				base.Draw(r, offsetX, offsetY);
				hiddenLabel.Draw(r, offsetX + PositionX, offsetY + PositionY);
				r.PopClip();
				r.PushClip(new AsciiRenderProcedural.Clip
				{
					left = base.lastDrawX + Width - Mathf.RoundToInt((float)(Width / 2) * (1f - num))
				});
				base.Draw(r, offsetX, offsetY);
				hiddenLabel.Draw(r, offsetX + PositionX, offsetY + PositionY);
				r.PopClip();
			}
			else
			{
				base.Draw(r, offsetX, offsetY);
				hiddenLabel.Draw(r, offsetX + PositionX, offsetY + PositionY);
			}
		}
	}
}

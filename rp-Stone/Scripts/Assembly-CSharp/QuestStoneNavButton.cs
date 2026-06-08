using UnityEngine;

public class QuestStoneNavButton : ToggleButton
{
	public new enum State
	{
		Idle = 0,
		UnlockAvailable = 1,
		RewardAvailable = 2,
		KiTreasureAvailable = 3
	}

	public State currentState { get; private set; }

	public void SetState(State newState)
	{
		if (mySprite == null)
		{
			InitSprite();
		}
		switch (newState)
		{
		case State.Idle:
			mySprite.colorOverride = ColorConstants.grey;
			break;
		case State.UnlockAvailable:
			mySprite.colorOverride = ColorConstants.legendQuest;
			break;
		case State.RewardAvailable:
			mySprite.colorOverride = ColorConstants.rewardGreen;
			break;
		case State.KiTreasureAvailable:
			mySprite.colorOverride = ColorConstants.magenta;
			break;
		}
		currentState = newState;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentState != State.Idle && GameStates.Singleton.CurrentState != GameStates.State.CustomQuests)
		{
			float num = Mathf.Repeat(Time.realtimeSinceStartup, 8f);
			if (num < 0.2f)
			{
				offsetX++;
			}
			else if (num > 0.25f && num < 0.35f)
			{
				offsetX--;
			}
		}
		base.Draw(r, offsetX, offsetY);
	}
}

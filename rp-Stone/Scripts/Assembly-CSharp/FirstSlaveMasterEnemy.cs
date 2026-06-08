using UnityEngine;

public class FirstSlaveMasterEnemy : Enemy
{
	public enum NpcState
	{
		Waiting = 0,
		GetBackToWork = 1,
		Done = 2
	}

	public int heroApproachOffsetX = -5;

	public NPCDialogBubble dialogBubblePrefab;

	private NPCDialogBubble dialogBubble;

	public int bubbleOffsetX = -12;

	public int bubbleOffsetY = 3;

	private NpcState currentNpcState;

	private void SetState(NpcState newState)
	{
		switch (newState)
		{
		case NpcState.GetBackToWork:
			StopHeroAI();
			SetupDialog(Te.xt("What are you doing? Get back to work!"));
			SfxController.singleton.Play("first_controller");
			break;
		case NpcState.Done:
			RestoreHeroAI();
			break;
		}
		currentNpcState = newState;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (GameStates.Singleton.CurrentState != GameStates.State.PlayPaused)
		{
			if (currentNpcState == NpcState.Waiting && GameStates.Singleton.hero.PositionX >= base.PositionX + heroApproachOffsetX)
			{
				SetState(NpcState.GetBackToWork);
			}
			else if (currentNpcState == NpcState.GetBackToWork)
			{
				dialogBubble.UpdateTic();
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		if (currentNpcState != NpcState.Waiting && currentNpcState != NpcState.Done)
		{
			int screenX = base.MySprite.lastDrawX + mouthOffsetX;
			int screenY = base.MySprite.lastDrawY + mouthOffsetY;
			dialogBubble.SetNPCMouthPosition(screenX, screenY);
			screenX = base.MySprite.lastDrawX + bubbleOffsetX;
			screenY = base.MySprite.lastDrawY + bubbleOffsetY;
			dialogBubble.Draw(r, screenX, screenY);
		}
	}

	private void SetupDialog(string message)
	{
		dialogBubble.PositionX = 0;
		dialogBubble.PositionY = 0;
		dialogBubble.SetMessage(message);
		dialogBubble.Show();
	}

	private void HandleDialogDone()
	{
		SetState(currentNpcState + 1);
	}

	private void StopHeroAI()
	{
		GameStates.Singleton.hero.RestoreAI();
		GameStates.Singleton.hero.GetComponent<HeroAI>().enabled = false;
	}

	private void RestoreHeroAI()
	{
		GameStates.Singleton.hero.RestoreAI();
	}

	protected override void Awake()
	{
		base.Awake();
		dialogBubble = Object.Instantiate(dialogBubblePrefab);
		dialogBubble.OnDone += HandleDialogDone;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (dialogBubble != null)
		{
			dialogBubble.OnDone -= HandleDialogDone;
			Object.Destroy(dialogBubble.gameObject);
		}
	}
}

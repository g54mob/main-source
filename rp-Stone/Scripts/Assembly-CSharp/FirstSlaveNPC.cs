using UnityEngine;

public class FirstSlaveNPC : Decoration
{
	public enum State
	{
		Waiting = 0,
		AsFastAsICan = 1,
		StopsPushing = 2,
		WhoAreYou = 3,
		CallMePusher = 4,
		PreConfused = 5,
		AWayOut = 6,
		IWouldGoToAcropolis = 7,
		BewareTongue = 8,
		IShouldContinue = 9,
		ResumesPushing = 10,
		Done = 11
	}

	public int heroApproachOffsetX = -5;

	public AsciiAnimation pushingAnm;

	public AsciiAnimation stopsPushingAnm;

	public AsciiAnimation confusedAnm;

	public AsciiAnimation talkingAnm;

	public AsciiAnimation preConfusedAnm;

	public AsciiAnimation warningAnm;

	public AsciiAnimation resumesPushingAnm;

	public NPCDialogBubble dialogBubblePrefab;

	private NPCDialogBubble dialogBubble;

	private State currentState;

	private int stateElapsedTics;

	private AsciiAnimation currentAnim;

	public int bubbleOffsetX = -12;

	public int bubbleOffsetY = 3;

	private Sfx lastSfx;

	private void SetState(State newState)
	{
		AsciiAnimation asciiAnimation = null;
		switch (newState)
		{
		case State.Waiting:
			asciiAnimation = pushingAnm;
			break;
		case State.AsFastAsICan:
			StopHeroAI();
			SetupDialog("I'm pushing as fast as I can!");
			PlayVoice();
			break;
		case State.StopsPushing:
			asciiAnimation = stopsPushingAnm;
			break;
		case State.WhoAreYou:
			asciiAnimation = confusedAnm;
			SetupDialog("By the Torch! I thought you were a [color=#00ffff]Controller[/color].\n\nWhat are you? Are you from Acropolis?");
			PlayVoice();
			break;
		case State.CallMePusher:
			asciiAnimation = talkingAnm;
			SetupDialog("{0}, huh? I don't have a name, but you can call me [color=#00ffff]Pusher[/color].", HeroSettings.name);
			PlayVoice();
			break;
		case State.PreConfused:
			asciiAnimation = preConfusedAnm;
			break;
		case State.AWayOut:
			asciiAnimation = confusedAnm;
			SetupDialog("You're from the outside? I didn't know there was a way out.");
			PlayVoice();
			break;
		case State.IWouldGoToAcropolis:
			asciiAnimation = talkingAnm;
			SetupDialog("If I got out I'd go to Acropolis. I'm told they don't have to work there. That's where most of our Bronze goes!");
			PlayVoice();
			break;
		case State.BewareTongue:
			asciiAnimation = warningAnm;
			SetupDialog("Beware of [color=#00ffff]The Tongue[/color]. When the walls tremble, that's when The Tongue comes.");
			PlayVoice();
			break;
		case State.IShouldContinue:
			asciiAnimation = talkingAnm;
			SetupDialog("I should continue pushing before a Controller sees me.");
			PlayVoice();
			break;
		case State.ResumesPushing:
			asciiAnimation = resumesPushingAnm;
			break;
		case State.Done:
			RestoreHeroAI();
			asciiAnimation = pushingAnm;
			break;
		}
		if (asciiAnimation != null && currentAnim != asciiAnimation)
		{
			currentAnim = asciiAnimation;
			currentAnim.Stop();
			currentAnim.Play();
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (GameStates.Singleton.CurrentState != GameStates.State.PlayPaused)
		{
			stateElapsedTics++;
			if (currentState == State.Waiting && GameStates.Singleton.hero.PositionX >= base.PositionX + heroApproachOffsetX)
			{
				SetState(State.AsFastAsICan);
			}
			else if (currentState == State.StopsPushing && stateElapsedTics >= 10)
			{
				SetState(currentState + 1);
			}
			else if (currentState == State.PreConfused && stateElapsedTics >= 6)
			{
				SetState(currentState + 1);
			}
			else if (currentState == State.ResumesPushing && stateElapsedTics >= 10)
			{
				SetState(currentState + 1);
			}
			if (currentState >= State.AsFastAsICan && currentState < State.Done)
			{
				dialogBubble.UpdateTic();
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		int num = base.PositionX + heroApproachOffsetX - GameStates.Singleton.hero.PositionX;
		offsetX += num / 6;
		base.Draw(r, offsetX, offsetY);
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		if (!(currentAnim != null) || !(currentAnim.Sprite != null))
		{
			return;
		}
		currentAnim.Sprite.Draw(r, offsetX, offsetY);
		if (currentState != State.Waiting && currentState != State.Done)
		{
			int screenX = base.MySprite.lastDrawX + mouthOffsetX;
			int screenY = base.MySprite.lastDrawY;
			dialogBubble.SetNPCMouthPosition(screenX, screenY);
			screenX = base.MySprite.lastDrawX + bubbleOffsetX;
			screenY = base.MySprite.lastDrawY + bubbleOffsetY;
			if (dialogBubble.lineCount > 7)
			{
				screenY -= dialogBubble.lineCount - 7;
			}
			dialogBubble.Draw(r, screenX, screenY);
		}
	}

	private void Update()
	{
		if (currentState > State.Waiting && currentState != State.Done && QuickCheats.SkipAheadKeyPressed())
		{
			SetState(State.Done);
		}
	}

	private void SetupDialog(string message)
	{
		_SetupDialog(Te.xt(message));
	}

	private void SetupDialog(string message, string param)
	{
		_SetupDialog(string.Format(Te.xt(message), param));
	}

	private void _SetupDialog(string message)
	{
		dialogBubble.PositionX = 0;
		dialogBubble.PositionY = 0;
		dialogBubble.SetMessage(message);
		dialogBubble.Show();
	}

	private void PlayVoice()
	{
		if (lastSfx != null)
		{
			lastSfx.Stop();
		}
		lastSfx = SfxController.singleton.Play("slave_npc");
	}

	private void HandleDialogDone()
	{
		SetState(currentState + 1);
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

	protected override void Start()
	{
		base.Start();
		pushingAnm.Sprite.Load();
		stopsPushingAnm.Sprite.Load();
		confusedAnm.Sprite.Load();
		talkingAnm.Sprite.Load();
		warningAnm.Sprite.Load();
		resumesPushingAnm.Sprite.Load();
		SetState(State.Waiting);
	}

	protected override void Awake()
	{
		base.Awake();
		dialogBubble = Object.Instantiate(dialogBubblePrefab);
		dialogBubble.OnDone += HandleDialogDone;
	}

	private void OnDestroy()
	{
		if (dialogBubble != null)
		{
			dialogBubble.OnDone -= HandleDialogDone;
			Object.Destroy(dialogBubble.gameObject);
		}
	}
}

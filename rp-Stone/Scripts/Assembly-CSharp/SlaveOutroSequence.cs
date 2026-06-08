using System;
using UnityEngine;

public class SlaveOutroSequence : Decoration, IPostAsciiRendererEffect
{
	[Serializable]
	public class DialogPos
	{
		public int x;

		public int y;

		public int mouthX;

		public int mouthY;
	}

	private enum State
	{
		Waiting = 0,
		InitialDelay = 1,
		GuardianIsUnmade1 = 2,
		GuardianIsUnmade2 = 3,
		PanCamera = 4,
		SlavesEnter = 5,
		ByTheTorch = 6,
		ProtectionFromTongueIn = 7,
		ProtectionFromTongueLoop = 8,
		ProtectionFromTongueOut = 9,
		BowerAdvances = 10,
		BowerBows = 11,
		FirstSlaveAdvances = 12,
		NotAController = 13,
		BowerSitsUp = 14,
		GoToAcropolis = 15,
		LowersArm = 16,
		UpUpUp = 17,
		ShowUsTheWayOut = 18,
		ForTheTorch1 = 19,
		ForTheTorch2 = 20,
		ForTheTorch3 = 21,
		HeroExits = 22,
		SlavesExit = 23,
		TransitionToMountainClimb = 24,
		MountainClimb = 25,
		Outro = 26,
		FadeToBlack = 27,
		Done = 28
	}

	private class CrowdMember
	{
		public enum State
		{
			Sleeping = 0,
			In = 1,
			Idle = 2,
			Out = 3,
			Done = 4
		}

		public int posX;

		public int posY;

		private AsciiAnimation walkRight;

		private AsciiAnimation idle;

		private AsciiAnimation walkLeft;

		private State crowdMemberState;

		private AsciiAnimation currentAnm;

		public CrowdMember(SlaveOutroSequence outroSequence)
		{
			walkRight = UnityEngine.Object.Instantiate(outroSequence.slaveWalkRightRef);
			idle = UnityEngine.Object.Instantiate(outroSequence.slaveIdleRef);
			walkLeft = UnityEngine.Object.Instantiate(outroSequence.slaveWalkLeftRef);
			SetState(State.In);
		}

		public void Cleanup()
		{
			currentAnm = null;
			UnityEngine.Object.Destroy(walkRight.gameObject);
			UnityEngine.Object.Destroy(idle.gameObject);
			UnityEngine.Object.Destroy(walkLeft.gameObject);
		}

		public void SetState(State newState)
		{
			switch (newState)
			{
			case State.In:
				currentAnm = walkRight;
				break;
			case State.Idle:
				currentAnm = idle;
				break;
			case State.Out:
				currentAnm = walkLeft;
				break;
			default:
				currentAnm = null;
				break;
			}
			if (currentAnm != null)
			{
				currentAnm.Play();
			}
			crowdMemberState = newState;
		}

		public void SetCustomAnimation(AsciiAnimation customSprite)
		{
			currentAnm = customSprite;
			currentAnm.Play();
		}

		public void UpdateTic()
		{
			if (crowdMemberState == State.In && (currentAnm == null || !currentAnm.Playing))
			{
				SetState(State.Idle);
			}
			else if (crowdMemberState == State.Out && (currentAnm == null || !currentAnm.Playing))
			{
				SetState(State.Done);
			}
		}

		public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
		{
			if (currentAnm != null)
			{
				currentAnm.Sprite.Draw(r, offsetX + posX, offsetY + posY);
			}
		}
	}

	private const int SCARED_INDEX = 3;

	private const int BOWER_INDEX = 9;

	private const int EXPLAINER_INDEX = 0;

	public AsciiAnimation slaveWalkRightRef;

	public AsciiAnimation slaveWalkLeftRef;

	public AsciiAnimation slaveIdleRef;

	public AsciiAnimation scaredIn;

	public AsciiAnimation scaredLoop;

	public AsciiAnimation scaredOut;

	public AsciiAnimation bowerAdvance;

	public AsciiAnimation bowerBows;

	public AsciiAnimation bowerSitsUp;

	public AsciiAnimation explainerAdvance;

	public AsciiAnimation explainerRaiseArm;

	public AsciiAnimation explainerLowerArm;

	public AsciiAnimation explainerUpUp;

	public AsciiAnimation forTheTorchCheer;

	public NPCDialogBubble dialogBubblePrefab;

	private NPCDialogBubble dialogBubble;

	public MultilayerSprite mountainClimb;

	public Separator dialogExtraMouth;

	public AsciiSprite forTheTorchMultiTail;

	public DialogPos guardianDialogPos;

	public DialogPos byTheTorchDialogPos;

	public DialogPos ohNoTongueDialogPos;

	public DialogPos bowerDialogPos;

	public DialogPos notControllerDialogPos;

	public DialogPos allTogetherDialogPos;

	private DialogPos currentDialogPos;

	private State currentState;

	private int stateElapsedTics;

	private AsciiRenderProcedural lastRenderer;

	private CrowdMember[] crowd = new CrowdMember[10];

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.GuardianIsUnmade1:
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.HideHud);
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
			SetupDialog("The Guardian is unmade!\n\nThe Guardian is unmade!");
			currentDialogPos = guardianDialogPos;
			SfxController.singleton.Play("slave_outro_voice");
			MusicController.singleton.Play("slave_outro_loop");
			break;
		case State.GuardianIsUnmade2:
			SetupDialog("Hurry all!\n\nThe Guardian is unmade!");
			SfxController.singleton.Play("slave_outro_voice");
			break;
		case State.PanCamera:
			SfxController.singleton.Play("slave_outro_chatter");
			break;
		case State.ByTheTorch:
			SetupDialog("By the Torch, it's true!");
			currentDialogPos = byTheTorchDialogPos;
			SfxController.singleton.Play("slave_outro_voice");
			break;
		case State.ProtectionFromTongueIn:
			crowd[3].SetCustomAnimation(scaredIn);
			break;
		case State.ProtectionFromTongueLoop:
			SetupDialog("Oh no! Who will protect us from The Tongue?");
			currentDialogPos = ohNoTongueDialogPos;
			SfxController.singleton.Play("slave_outro_voice");
			crowd[3].SetCustomAnimation(scaredLoop);
			break;
		case State.ProtectionFromTongueOut:
			crowd[3].SetCustomAnimation(scaredOut);
			break;
		case State.BowerAdvances:
			crowd[3].SetState(CrowdMember.State.Idle);
			crowd[9].SetCustomAnimation(bowerAdvance);
			break;
		case State.BowerBows:
			SetupDialog("Glory to the Controller, Guardian Slayer!");
			currentDialogPos = bowerDialogPos;
			SfxController.singleton.Play("slave_outro_voice");
			crowd[9].SetCustomAnimation(bowerBows);
			crowd[9].posX += 7;
			crowd[9].posY++;
			break;
		case State.FirstSlaveAdvances:
			crowd[0].SetCustomAnimation(explainerAdvance);
			break;
		case State.NotAController:
			SetupDialog("This isn't a Controller. It's a {0}. From the outside.", HeroSettings.name);
			currentDialogPos = notControllerDialogPos;
			SfxController.singleton.Play("slave_outro_voice");
			crowd[0].SetCustomAnimation(explainerRaiseArm);
			crowd[0].posX += 8;
			crowd[0].posY += 3;
			break;
		case State.BowerSitsUp:
			crowd[9].SetCustomAnimation(bowerSitsUp);
			crowd[0].SetCustomAnimation(explainerLowerArm);
			break;
		case State.GoToAcropolis:
			SetupDialog("We should go to Acropolis! Where comfort is plenty and work is sparse.");
			crowd[0].SetCustomAnimation(explainerRaiseArm);
			SfxController.singleton.Play("slave_outro_voice");
			break;
		case State.LowersArm:
			crowd[0].SetCustomAnimation(explainerLowerArm);
			break;
		case State.UpUpUp:
			SetupDialog("Up, up we go, to the highest point in the world!");
			crowd[0].SetCustomAnimation(explainerUpUp);
			SfxController.singleton.Play("slave_outro_voice");
			break;
		case State.ShowUsTheWayOut:
			SetupDialog("{0}, you must show us the way out!\n\nFor the Torch!", HeroSettings.name);
			crowd[0].SetCustomAnimation(forTheTorchCheer);
			SfxController.singleton.Play("slave_outro_voice");
			break;
		case State.ForTheTorch1:
		case State.ForTheTorch2:
		case State.ForTheTorch3:
			SetupDialog("FOR THE TORCH!");
			currentDialogPos = allTogetherDialogPos;
			SfxController.singleton.Play("slave_outro_voice");
			if (newState == State.ForTheTorch1)
			{
				for (int i = 0; i < crowd.Length; i++)
				{
					crowd[i].SetCustomAnimation(forTheTorchCheer);
				}
			}
			break;
		case State.Outro:
			GameStates.Singleton.playChoiceDialog.SetupText("tid_slaves_17", "Continue", KeyCode.Return);
			GameStates.Singleton.playChoiceDialog.buttonSingle.OnPressed += OnOutroDialogPressed;
			GameStates.Singleton.playChoiceDialog.Show();
			break;
		case State.FadeToBlack:
			GameStates.Singleton.CompleteQuest();
			break;
		case State.Done:
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.ShowHud);
			if (lastRenderer != null)
			{
				lastRenderer.RemovePostEffect(this);
				lastRenderer = null;
			}
			CleanupCrowd();
			break;
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (GameStates.Singleton.CurrentState == GameStates.State.PlayPaused)
		{
			return;
		}
		stateElapsedTics++;
		UpdateCrowd();
		if (currentState == State.InitialDelay)
		{
			if (stateElapsedTics == 1)
			{
				SfxController.singleton.Play("slave_outro_transition");
			}
			else if (stateElapsedTics >= 10)
			{
				NextState();
			}
		}
		else if (currentState == State.PanCamera && stateElapsedTics >= 30)
		{
			NextState();
		}
		else if (currentState == State.SlavesEnter)
		{
			if (stateElapsedTics == 1)
			{
				AddCrowdMember(6, -28, 0);
			}
			else if (stateElapsedTics == 15)
			{
				AddCrowdMember(4, -25, -2);
			}
			else if (stateElapsedTics == 30)
			{
				AddCrowdMember(7, -27, 2);
			}
			else if (stateElapsedTics == 45)
			{
				AddCrowdMember(2, -21, -3);
			}
			else if (stateElapsedTics == 60)
			{
				AddCrowdMember(9, -29, 4);
			}
			else if (stateElapsedTics == 75)
			{
				AddCrowdMember(0, -19, -4);
			}
			else if (stateElapsedTics == 90)
			{
				AddCrowdMember(3, -29, -3);
			}
			else if (stateElapsedTics == 105)
			{
				AddCrowdMember(8, -31, 3);
			}
			else if (stateElapsedTics == 120)
			{
				AddCrowdMember(1, -26, -4);
			}
			else if (stateElapsedTics == 135)
			{
				AddCrowdMember(5, -32, -1);
			}
			else if (stateElapsedTics >= 150)
			{
				NextState();
			}
		}
		else if ((currentState == State.ProtectionFromTongueIn || currentState == State.ProtectionFromTongueOut) && stateElapsedTics >= 9)
		{
			NextState();
		}
		else if (currentState == State.BowerAdvances && stateElapsedTics >= 30)
		{
			NextState();
		}
		else if (currentState == State.FirstSlaveAdvances && stateElapsedTics >= 30)
		{
			NextState();
		}
		else if (currentState == State.BowerSitsUp && stateElapsedTics >= 15)
		{
			NextState();
		}
		else if (currentState == State.LowersArm && stateElapsedTics >= 6)
		{
			NextState();
		}
		else if (currentState == State.ForTheTorch1 || currentState == State.ForTheTorch2 || currentState == State.ForTheTorch3)
		{
			dialogBubble.UpdateTic();
			if (stateElapsedTics == 45)
			{
				dialogBubble.Hide();
			}
			else if (stateElapsedTics >= 60)
			{
				NextState();
			}
		}
		else if (currentState == State.HeroExits && stateElapsedTics >= 0)
		{
			NextState();
		}
		else if (currentState == State.SlavesExit)
		{
			if (stateElapsedTics == 5)
			{
				MusicController.singleton.Play("slave_outro_climb", 0f, 1.5f);
			}
			if (stateElapsedTics == 1)
			{
				crowd[5].SetState(CrowdMember.State.Out);
			}
			else if (stateElapsedTics == 8)
			{
				crowd[1].SetState(CrowdMember.State.Out);
			}
			else if (stateElapsedTics == 16)
			{
				crowd[8].SetState(CrowdMember.State.Out);
			}
			else if (stateElapsedTics == 24)
			{
				crowd[3].SetState(CrowdMember.State.Out);
			}
			else if (stateElapsedTics == 32)
			{
				crowd[0].SetState(CrowdMember.State.Out);
			}
			else if (stateElapsedTics == 40)
			{
				crowd[9].SetState(CrowdMember.State.Out);
			}
			else if (stateElapsedTics == 48)
			{
				crowd[2].SetState(CrowdMember.State.Out);
			}
			else if (stateElapsedTics == 56)
			{
				crowd[7].SetState(CrowdMember.State.Out);
			}
			else if (stateElapsedTics == 64)
			{
				crowd[4].SetState(CrowdMember.State.Out);
			}
			else if (stateElapsedTics == 72)
			{
				crowd[6].SetState(CrowdMember.State.Out);
			}
			else if (stateElapsedTics >= 150)
			{
				NextState();
			}
		}
		else if (currentState == State.TransitionToMountainClimb && stateElapsedTics >= 31)
		{
			NextState();
		}
		else if (currentState == State.MountainClimb)
		{
			if (stateElapsedTics == 30)
			{
				mountainClimb.additionalLayers[1].gameObject.SetActive(value: true);
			}
			else if (stateElapsedTics == 50)
			{
				mountainClimb.additionalLayers[2].gameObject.SetActive(value: true);
			}
			else if (stateElapsedTics == 85)
			{
				mountainClimb.additionalLayers[3].gameObject.SetActive(value: true);
			}
			else if (stateElapsedTics == 95)
			{
				mountainClimb.additionalLayers[4].gameObject.SetActive(value: true);
			}
			else if (stateElapsedTics == 105)
			{
				mountainClimb.additionalLayers[5].gameObject.SetActive(value: true);
			}
			else if (stateElapsedTics == 150)
			{
				mountainClimb.additionalLayers[6].gameObject.SetActive(value: true);
			}
			else if (stateElapsedTics == 170)
			{
				mountainClimb.additionalLayers[7].gameObject.SetActive(value: true);
			}
			else if (stateElapsedTics == 185)
			{
				mountainClimb.additionalLayers[8].gameObject.SetActive(value: true);
			}
			else if (stateElapsedTics == 230)
			{
				mountainClimb.additionalLayers[9].gameObject.SetActive(value: true);
			}
			else if (stateElapsedTics == 130)
			{
				mountainClimb.additionalLayers[10].gameObject.SetActive(value: true);
			}
			else if (stateElapsedTics >= 560)
			{
				NextState();
			}
		}
		else if (currentState == State.Outro)
		{
			GameStates.Singleton.playChoiceDialog.UpdateTic();
		}
		else if (currentState != State.FadeToBlack && currentState > State.Waiting && currentState < State.Done)
		{
			dialogBubble.UpdateTic();
		}
	}

	private void AddCrowdMember(int index, int x, int y)
	{
		CrowdMember crowdMember = new CrowdMember(this);
		crowdMember.posX = x;
		crowdMember.posY = y;
		crowd[index] = crowdMember;
	}

	private void UpdateCrowd()
	{
		for (int i = 0; i < crowd.Length; i++)
		{
			if (crowd[i] != null)
			{
				crowd[i].UpdateTic();
			}
		}
	}

	private void CleanupCrowd()
	{
		for (int i = 0; i < crowd.Length; i++)
		{
			if (crowd[i] != null)
			{
				crowd[i].Cleanup();
				crowd[i] = null;
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		for (int i = 0; i < crowd.Length; i++)
		{
			if (crowd[i] != null)
			{
				crowd[i].Draw(r, offsetX, offsetY);
			}
		}
		if ((currentState == State.GuardianIsUnmade1 || currentState == State.GuardianIsUnmade2) && dialogBubble.CurrentState == DialogNineSlice.State.Idle)
		{
			dialogExtraMouth.Draw(r, currentDialogPos.x + offsetX, currentDialogPos.y + offsetY);
		}
		if (currentState > State.InitialDelay && currentState < State.Done)
		{
			int screenX = base.MySprite.lastDrawX + currentDialogPos.mouthX;
			int screenY = base.MySprite.lastDrawY + currentDialogPos.mouthY;
			dialogBubble.SetNPCMouthPosition(screenX, screenY);
			screenX = base.MySprite.lastDrawX + currentDialogPos.x;
			screenY = base.MySprite.lastDrawY + currentDialogPos.y;
			dialogBubble.Draw(r, screenX, screenY);
		}
		if (currentState >= State.ForTheTorch1 && currentState <= State.ForTheTorch3 && dialogBubble.CurrentState == DialogNineSlice.State.Idle)
		{
			forTheTorchMultiTail.Draw(r, currentDialogPos.x + offsetX, currentDialogPos.y + offsetY);
		}
		if (currentState == State.TransitionToMountainClimb && lastRenderer == null)
		{
			lastRenderer = r;
			r.AddPostEffect(this);
		}
	}

	public void ApplyPostEffect(AsciiRenderProcedural r)
	{
		AsciiRenderProcedural.Clip clip = r.clip;
		if (currentState == State.TransitionToMountainClimb)
		{
			float num = Mathf.Clamp01((float)stateElapsedTics / 30f);
			clip.left = Mathf.RoundToInt((float)r.width * (1f - num));
		}
		else if (currentState == State.MountainClimb)
		{
			clip.left = 0;
		}
		r.PushClip(clip, computeIntersection: false);
		r.Clear();
		mountainClimb.Draw(r, r.width >> 1, r.height >> 1);
		if (currentState == State.Outro || currentState == State.FadeToBlack)
		{
			GameStates.Singleton.playChoiceDialog.Draw(r, r.width - 46 >> 1, r.height);
			AsciiMouse.singleton.Draw(r, 0, 0);
		}
		if (currentState == State.FadeToBlack)
		{
			stateElapsedTics++;
			float t = Mathf.Clamp01((float)stateElapsedTics / 6f);
			for (int i = 0; i < r.width; i++)
			{
				for (int j = 0; j < r.height; j++)
				{
					AsciiCellProcedural cell = r.GetCell(i, j);
					int value = cell.GetValue();
					Color foreground = cell.GetForeground();
					Color background = cell.GetBackground();
					foreground = Color.Lerp(foreground, r.defaultBackgroundColor, t);
					background = Color.Lerp(background, r.defaultBackgroundColor, t);
					cell.SetValue(value, foreground, background);
				}
			}
			if (!GameStates.Singleton.IsPlaying())
			{
				SetState(State.Done);
			}
		}
		r.PopClip();
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

	private void HandleDialogDone()
	{
		if (currentState != State.ForTheTorch1 && currentState != State.ForTheTorch2 && currentState != State.ForTheTorch3)
		{
			NextState();
		}
	}

	private void HandleCharacterDied(Character c, DeathReason reason, Damage damage)
	{
		if (c.id == "fissure_stone" || c.id == "treasure_pickup")
		{
			NextState();
		}
	}

	private void NextState()
	{
		SetState(currentState + 1);
	}

	private void OnOutroDialogPressed(DialogButton btn)
	{
		btn.OnPressed -= OnOutroDialogPressed;
		SetState(State.FadeToBlack);
	}

	private void Update()
	{
		if (currentState > State.Waiting && currentState != State.Done && QuickCheats.SkipAheadKeyPressed())
		{
			if (currentState < State.TransitionToMountainClimb)
			{
				SetState(State.TransitionToMountainClimb);
			}
			else
			{
				SetState(State.Done);
			}
		}
	}

	protected override void Start()
	{
		base.Start();
		SetState(State.Waiting);
	}

	protected override void Awake()
	{
		base.Awake();
		dialogBubble = UnityEngine.Object.Instantiate(dialogBubblePrefab);
		dialogBubble.OnDone += HandleDialogDone;
		Character.OnCharacterDied += HandleCharacterDied;
	}

	private void OnDestroy()
	{
		if (dialogBubble != null)
		{
			dialogBubble.OnDone -= HandleDialogDone;
			UnityEngine.Object.Destroy(dialogBubble.gameObject);
		}
		Character.OnCharacterDied -= HandleCharacterDied;
		if (lastRenderer != null)
		{
			lastRenderer.RemovePostEffect(this);
			lastRenderer = null;
		}
	}
}

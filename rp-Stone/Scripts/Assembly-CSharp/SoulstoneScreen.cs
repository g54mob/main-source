using System;
using UnityEngine;

public class SoulstoneScreen : MonoBehaviour
{
	[Serializable]
	public class SoulstoneEntry
	{
		public AsciiSprite sprite;

		public int clickOffsetX;

		public int clickOffsetY;
	}

	public enum Type
	{
		SightStone = 0,
		StarStone = 1,
		XiStone = 2,
		XpStone = 3,
		OuroborosStone = 4,
		QuestStone = 5,
		FissureStone = 6,
		TriskelionStone = 7,
		MindStone = 8,
		MoonStone = 9
	}

	public enum State
	{
		WaitingForTap = 0,
		StoneTappedAnimation = 1,
		MagicTransition = 2,
		Done = 3
	}

	private static bool DEBUG_CLICK_CENTER;

	public SoulstoneEntry[] soulstoneEntries;

	public AsciiAnimation transitionAnimation;

	private int magicTransitionDuration = 45;

	private int moondialTransitionDuration = 75;

	public DialogButton stopButton;

	private State _currentState;

	private int stateElapsedTics;

	private AsciiSprite currentStoneSprite;

	private AsciiAnimation currentStoneAnimation;

	public static bool hideStopButton;

	public Type currentType { get; private set; }

	public State currentState => _currentState;

	public bool isOfflineFarmTransition { get; set; }

	public void Setup(Type soulstoneType)
	{
		currentType = soulstoneType;
		SetState(State.WaitingForTap);
		currentStoneSprite = soulstoneEntries[(int)soulstoneType].sprite;
		currentStoneAnimation = currentStoneSprite.GetComponent<AsciiAnimation>();
		if (currentStoneAnimation != null)
		{
			currentStoneAnimation.Stop();
			currentStoneSprite.SetFrameIndex(0);
		}
	}

	private void SetState(State newState)
	{
		if (newState == State.StoneTappedAnimation)
		{
			GameStates.Singleton.HideMouse();
			if (currentType == Type.SightStone)
			{
				AnalyticsMacros.IntroSightStone();
			}
			else if (currentType == Type.StarStone)
			{
				AnalyticsMacros.IntroStarStone();
			}
			else if (currentType == Type.XiStone)
			{
				AnalyticsMacros.IntroKiStone();
			}
			else if (currentType == Type.XpStone)
			{
				AnalyticsMacros.IntroXPStone();
			}
			else if (currentType == Type.OuroborosStone)
			{
				AnalyticsMacros.IntroOuroboros();
			}
			else if (currentType == Type.QuestStone)
			{
				AnalyticsMacros.IntroQuestStone();
			}
			else if (currentType == Type.FissureStone)
			{
				AnalyticsMacros.IntroFissureStone();
			}
			else if (currentType == Type.TriskelionStone)
			{
				AnalyticsMacros.IntroTriskelion();
			}
			else if (currentType == Type.MindStone)
			{
				AnalyticsMacros.IntroMindStone();
				SfxController.singleton.Play("mindstone_found", ignoreDuplicateSfxInSameFrame: true, 0.1f);
			}
			else if (currentType == Type.MoonStone)
			{
				AnalyticsMacros.IntroMoondial();
			}
			if (currentStoneAnimation == null)
			{
				SetState(State.MagicTransition);
				return;
			}
			currentStoneAnimation.Play();
			if (currentType == Type.QuestStone)
			{
				SfxController.singleton.Play("quest_stone_jump");
			}
		}
		if (newState == State.MagicTransition)
		{
			transitionAnimation.Stop();
			transitionAnimation.Play();
			GameStates.Singleton.HideMouse();
			AmbianceController.singleton.StopAllAmbient();
			MusicController.singleton.FadeToSilence();
			SfxController.singleton.Play("soul_stone");
		}
		if (newState == State.Done)
		{
			GameStates.Singleton.ShowMouse();
			isOfflineFarmTransition = false;
		}
		_currentState = newState;
		stateElapsedTics = 0;
	}

	public void UpdateTic()
	{
		stateElapsedTics++;
		if (_currentState == State.WaitingForTap)
		{
			if (IsLoopingOuroboros() || isOfflineFarmTransition)
			{
				if (!hideStopButton)
				{
					stopButton.UpdateTic();
				}
				if (stateElapsedTics >= 45 && !GameStates.Singleton.isTransitioning)
				{
					SetState(State.MagicTransition);
				}
			}
			else if (stateElapsedTics >= 15 && AsciiMouse.singleton.down0)
			{
				int num = GameStates.Singleton.asciiRenderer.width / 2 - AsciiMouse.singleton.x;
				int num2 = GameStates.Singleton.asciiRenderer.height / 2 - AsciiMouse.singleton.y;
				int value = num + soulstoneEntries[(int)currentType].clickOffsetX;
				num2 += soulstoneEntries[(int)currentType].clickOffsetY;
				if (Mathf.Abs(value) < 5 && Mathf.Abs(num2) < 3)
				{
					SetState(State.StoneTappedAnimation);
				}
				if (currentType == Type.OuroborosStone)
				{
					OuroborosWeapon.hasBeenTapped = true;
				}
				else if (currentType == Type.MindStone)
				{
					MindStoneController.singleton.enabled = true;
				}
			}
		}
		else if (_currentState == State.StoneTappedAnimation)
		{
			if (currentStoneAnimation == null || !currentStoneAnimation.Playing)
			{
				SetState(State.MagicTransition);
			}
		}
		else if (_currentState == State.MagicTransition && stateElapsedTics >= magicTransitionDuration && (currentType != Type.MoonStone || stateElapsedTics >= moondialTransitionDuration))
		{
			SetState(State.Done);
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (_currentState == State.WaitingForTap)
		{
			float value = (float)stateElapsedTics / 18f;
			currentStoneSprite.Draw(r, offsetX, offsetY, Mathf.Clamp01(value));
			if (IsLoopingOuroboros() && !hideStopButton)
			{
				stopButton.Draw(r, r.width, r.height);
			}
		}
		else if (_currentState == State.StoneTappedAnimation)
		{
			currentStoneSprite.Draw(r, offsetX, offsetY);
		}
		else if (_currentState == State.MagicTransition)
		{
			float t = (float)stateElapsedTics / 6f;
			currentStoneSprite.Draw(r, offsetX, offsetY, Mathf.Lerp(1f, 0.25f, t));
			Color overrideBackground = transitionAnimation.Sprite.colorOverride;
			if (isOfflineFarmTransition && OuroborosWeapon.singleton != null)
			{
				overrideBackground = (UpgradeRelicScreen.selectedRarityColor = UpgradeRelicScreen.GetColorForLevel(OuroborosWeapon.singleton.level));
			}
			if (!AdditionalSettings.isScreenFlash)
			{
				overrideBackground *= 0.35f;
			}
			offsetX += soulstoneEntries[(int)currentType].clickOffsetX;
			offsetY += soulstoneEntries[(int)currentType].clickOffsetY;
			transitionAnimation.Sprite.Draw(r, offsetX, offsetY, ColorConstants.black, overrideBackground);
		}
		if (DEBUG_CLICK_CENTER)
		{
			r.GetCell(r.width / 2 + soulstoneEntries[(int)currentType].clickOffsetX, r.height / 2 + soulstoneEntries[(int)currentType].clickOffsetY).SetBackground(Color.magenta);
		}
	}

	private void Update()
	{
		if (_currentState == State.WaitingForTap && GameStates.Singleton.CurrentState == GameStates.State.Soulstone && !GameStates.Singleton.isTransitioning && IsLoopingOuroboros() && (Input.GetKeyDown(KeyCode.Escape) || Binding.singleton.IsDown(Binding.Action.Pause)))
		{
			HandleStopButtonPressed(null);
		}
	}

	private bool IsLoopingOuroboros()
	{
		if (currentType == Type.OuroborosStone && OuroborosWeapon.questToReplay != null)
		{
			return OuroborosWeapon.hasBeenTapped;
		}
		return false;
	}

	private void HandleStopButtonPressed(DialogButton btn)
	{
		GameStates.Singleton.ExitSoulstoneScreen();
		AchievementController.singleton.ReportLocationPausedManually();
	}

	private void Start()
	{
		for (int i = 0; i < soulstoneEntries.Length; i++)
		{
			soulstoneEntries[i].sprite.Load();
		}
		transitionAnimation.Sprite.Load();
		stopButton.OnPressed += HandleStopButtonPressed;
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class UndeadCryptIntro : Decoration
{
	private enum State
	{
		Approach1 = 0,
		ApproachPause = 1,
		Approach2 = 2,
		Pulling = 3,
		WakingUp = 4,
		WakingUpSecondTime = 5,
		NoTreasureNotificationAsk = 6,
		NoTreasureNotificationSet = 7,
		NotificationChoice = 8,
		Talking = 9,
		RevealingItemUp = 10,
		RevealingItemPause = 11,
		RevealingItemDown = 12,
		Shuffling = 13,
		ShufflingPause = 14,
		WaitingForInput = 15,
		RevealingChoiceUp = 16,
		RevealingChoicePause1 = 17,
		RevealingChoicePause2 = 18,
		RevealingChoiceDown = 19,
		SwappingSkulls = 20,
		DroppingItem = 21,
		ApproachingItem = 22,
		PickingUpItem = 23,
		ShowingTreasure = 24,
		ApproachGateWithKey = 25,
		UnlockingGate = 26,
		OpeningGate = 27,
		EnterGate = 28,
		ReferralQuestion = 29,
		ReferralYesNo = 30,
		ReferralCodeInput = 31,
		ReferralError = 32,
		ReferralPending = 33,
		ReferralSuccess1 = 34,
		ReferralSuccess2 = 35,
		ReferralExhausted = 36,
		Done = 37
	}

	private enum ShufflingSide
	{
		Right = 0,
		Left = 1
	}

	private enum ShufflingDirection
	{
		Clockwise = 0,
		CounterClockwise = 1
	}

	private bool DEBUG_SHOW_ITEM_POSITION_AT_ALL_TIMES;

	private bool LIGHT_TORCHES_ALL_THE_TIME;

	private const int approachPauseTics = 10;

	private const int approach2Tics = 65;

	private const int pullingTics = 60;

	private const int wakingUpTics = 75;

	private const int talkingTics = 90;

	private const int revealingPause1Tics = 13;

	private const int revealingPause2Tics = 17;

	private const int revealingDownTics = 30;

	private const int droppingItemTics = 63;

	private const int approachingItemTics = 27;

	private const int pickingUpItemTics = 12;

	private const int approachGateWithKeyTics = 40;

	private const int unlockingGateTics = 24;

	private const int openingGateTics = 40;

	private const int enteringGateTics = 20;

	private const int ticsPerRevealMove = 4;

	private int[] shuffleTicsPerMovePerScore = new int[3] { 4, 2, 1 };

	private int[] shufflePauseTicsPerScore = new int[3] { 5, 3, 2 };

	private int[] shuffleMoveDataX = new int[4] { 2, 4, 5, 6 };

	private int[] shuffleMoveDataY = new int[4] { 0, 0, 1, 2 };

	private int[] shuffleMoveDataXccw = new int[4] { 0, 1, 2, 4 };

	private int[] shuffleMoveDataYccw = new int[4] { 1, 2, 3, 3 };

	private const int heroStopOffsetX = 6;

	private const int heroGateOffsetX = 25;

	private int[] dropItemFromPos0_X = new int[2] { 0, -1 };

	private int[] dropItemFromPos0_Y = new int[14]
	{
		0, 0, 1, 1, 2, 3, 4, 5, 6, 8,
		9, 11, 13, 15
	};

	private int[] dropItemFromPos1_X = new int[13]
	{
		0, -1, -2, -2, -3, -3, -4, -4, -5, -5,
		-6, -6, -7
	};

	private int[] dropItemFromPos1_Y = new int[14]
	{
		0, 0, 0, 1, 1, 2, 3, 4, 5, 6,
		7, 8, 10, 12
	};

	private int[] dropItemFromPos2_X = new int[14]
	{
		0, -1, -2, -3, -4, -5, -6, -7, -8, -9,
		-10, -11, -12, -13
	};

	private int[] dropItemFromPos2_Y = new int[14]
	{
		0, 0, 0, 1, 1, 2, 2, 3, 4, 5,
		6, 7, 8, 9
	};

	private const int dropTicsPerFrame = 3;

	private const int heroPickupOffsetX = 14;

	public UndeadCryptIntroSkull smallSkullPrefab;

	public UndeadCryptIntroSkull bigSkullPrefab;

	public NPCDialogBubble dialogBubblePrefab;

	public ReferralCodeInputDialog referralCodeInputDialogPrefab;

	private ReferralCodeInputDialog referralCodeInputDialog;

	public AsciiSprite keyPrefab;

	private string treasureIcon = "Treasure/treasure_icon_1";

	private string giantTreasureIcon = "Treasure/treasure_icon_2";

	private string rareTreasureIcon = "Treasure/treasure_icon_3";

	private string epicTreasureIcon = "Treasure/treasure_icon_4";

	private string boneTreasureIcon = "Treasure/treasure_icon_bone";

	private string goldTreasureIcon = "Treasure/treasure_icon_gold";

	public IntPosition[] skullPositions;

	public AsciiString timeRemainingLabel;

	public bool isQuestControlled;

	private UIButton _referralButton;

	private State previousState;

	private State currentState;

	private int stateElapsedTics;

	public static int timesPlayed;

	private static DateTime nextTreasureAvailableDate;

	private static bool wasNotificationAnswerYes = true;

	private int itemPosIndex;

	private int score;

	private bool scoreImproved;

	private bool scoreWorsened;

	private int smallSkull1PosIndex;

	private int smallSkull2PosIndex;

	private int bigSkullPosIndex;

	private IntPosition smallSkull1Pos = new IntPosition();

	private IntPosition smallSkull2Pos = new IntPosition();

	private IntPosition bigSkullPos = new IntPosition();

	private int revealedItemCount;

	private int revealPosIndex;

	private int revealOffsetY;

	private int shuffleTicsPerMove;

	private int shuffleMoveIndex;

	private int shuffleCount;

	private ShufflingSide shufflingSide;

	private ShufflingDirection shufflingDirection;

	private bool hasGuessedBefore;

	private int inputChoice;

	private bool hasSwapped;

	private int dropOffsetX;

	private int dropOffsetY;

	private UndeadCryptIntroSkull smallSkull1;

	private UndeadCryptIntroSkull smallSkull2;

	private UndeadCryptIntroSkull bigSkull;

	private NPCDialogBubble dialogBubble;

	private AsciiSprite itemSprite;

	private bool specialCaseTreasureJustArrived;

	private bool isReferralEnabled;

	private bool referralButtonEnabled = true;

	private bool referralManuallyScheduled;

	private bool hasScottyAsked;

	private bool isGoldenTreasure;

	private string referralFriendName;

	private bool hasWishedHappyHolidays;

	private string selectedTreasureId;

	private ScottyTheSkull scottyTheSkullNPC;

	private ScottyTheSkull.DialogData dialogData;

	private long _lastSecondsRemaining = -1L;

	private Decoration gateDeco;

	public static event Action OnSkullGameWon;

	private void SetState(State newState)
	{
		if (currentState == State.WakingUp || currentState == State.WakingUpSecondTime)
		{
			smallSkull1.SetState(UndeadCryptIntroSkull.State.Idle);
			smallSkull2.SetState(UndeadCryptIntroSkull.State.Idle);
			bigSkull.SetState(UndeadCryptIntroSkull.State.Idle);
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + 6, base.PositionZ - 1);
			RestoreGatePosition();
		}
		else if (currentState == State.Talking)
		{
			bigSkull.SetState(UndeadCryptIntroSkull.State.Idle);
		}
		else if (currentState == State.ReferralCodeInput || currentState == State.ReferralPending)
		{
			GameStates.Singleton.loadingSpinner.enabled = false;
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.EnablePause);
		}
		switch (newState)
		{
		case State.Approach1:
			itemPosIndex = 1;
			score = 0;
			SetTorchesForScore();
			smallSkull1PosIndex = 0;
			smallSkull2PosIndex = 2;
			bigSkullPosIndex = 1;
			smallSkull1.SetState(UndeadCryptIntroSkull.State.Asleep);
			smallSkull2.SetState(UndeadCryptIntroSkull.State.Asleep);
			bigSkull.SetState(UndeadCryptIntroSkull.State.Asleep);
			InitRewardItem();
			isReferralEnabled = false;
			if (!IsItemKey())
			{
				ReferralController.singleton.IsSystemEnabled(delegate(bool value)
				{
					isReferralEnabled = value;
				});
			}
			break;
		case State.ApproachPause:
			StopHeroAI();
			GameStates.Singleton.hero.SetState(Hero.State.Idle);
			break;
		case State.Approach2:
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + 25, base.PositionZ);
			break;
		case State.Pulling:
			StopHeroAI();
			GameStates.Singleton.hero.SetState(Hero.State.Pulling);
			break;
		case State.WakingUp:
		case State.WakingUpSecondTime:
			smallSkull1.SetState(UndeadCryptIntroSkull.State.WakingUp);
			smallSkull2.SetState(UndeadCryptIntroSkull.State.WakingUp);
			bigSkull.SetState(UndeadCryptIntroSkull.State.WakingUp);
			break;
		case State.NotificationChoice:
			RegisterDialogCallbacks();
			GameStates.Singleton.ShowPlayChoiceDialog("", "Yes", "No", KeyCode.Y, KeyCode.N);
			break;
		case State.Talking:
			SetupDialog();
			MusicController.singleton.Play("undead_crypt_intro");
			break;
		case State.RevealingItemUp:
			revealedItemCount++;
			revealPosIndex = itemPosIndex;
			break;
		case State.RevealingItemDown:
			referralButtonEnabled = false;
			break;
		case State.Shuffling:
			shuffleTicsPerMove = shuffleTicsPerMovePerScore[score];
			shuffleMoveIndex = 0;
			shuffleCount = 0;
			RandomizeShuffle();
			break;
		case State.RevealingChoiceUp:
			revealPosIndex = inputChoice;
			break;
		case State.SwappingSkulls:
			hasSwapped = true;
			shuffleTicsPerMove = 5;
			shuffleMoveIndex = 0;
			RandomizeShuffle();
			if (bigSkullPosIndex == 0)
			{
				shufflingSide = ShufflingSide.Left;
			}
			else if (bigSkullPosIndex == 2)
			{
				shufflingSide = ShufflingSide.Right;
			}
			revealOffsetY = 1;
			break;
		case State.DroppingItem:
			dropOffsetX = 0;
			dropOffsetY = 0;
			revealOffsetY = 0;
			BigHead.treasureTime = 3f;
			AchievementController.singleton.ReportSkullGameCompleted();
			break;
		case State.ApproachingItem:
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + 14, base.PositionZ - 1);
			break;
		case State.PickingUpItem:
			StopHeroAI();
			GameStates.Singleton.hero.SetState(Hero.State.PickingUp);
			break;
		case State.ShowingTreasure:
		{
			TreasureItem treasureItem = MakeTreasureItem();
			GameStates.Singleton.AddItemFromPickup(treasureItem, 1, offerUpgradeOption: true);
			SfxController.singleton.Play("pickup_success");
			SetNextTreasureAvailableDate();
			AnalyticsMacros.SkullGameTreasure();
			UndeadCryptIntro.OnSkullGameWon?.Invoke();
			if (treasureItem.type == TreasureItem.Type.Gold)
			{
				ReferralController.singleton.ReportCurrentRedeemTransactionComplete();
			}
			break;
		}
		case State.ApproachGateWithKey:
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + 25 - 1, base.PositionZ);
			break;
		case State.UnlockingGate:
			StopHeroAI();
			GameStates.Singleton.hero.SetState(Hero.State.Pulling);
			break;
		case State.OpeningGate:
		{
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + 25 - 5, base.PositionZ + 2);
			Decoration gate = GetGate();
			if (gate != null)
			{
				AsciiAnimation component = gate.GetComponent<AsciiAnimation>();
				component.Play();
				component.ElapsedTime = component.duration * 2f / (float)gate.MySprite.FrameCount;
			}
			SfxController.singleton.Play("haunted_gate_opening");
			break;
		}
		case State.EnterGate:
			GameStates.Singleton.hero.SetMoveDestination(base.PositionX + 25 + 1, base.PositionZ - 1);
			break;
		case State.ReferralYesNo:
			RegisterDialogCallbacks();
			GameStates.Singleton.ShowPlayChoiceDialog("Scotty asked if you have a referral code", "Yes", "No", KeyCode.Y, KeyCode.N);
			break;
		case State.ReferralCodeInput:
			if (referralCodeInputDialog == null)
			{
				referralCodeInputDialog = UnityEngine.Object.Instantiate(referralCodeInputDialogPrefab);
			}
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
			break;
		case State.ReferralPending:
			GameStates.Singleton.loadingSpinner.enabled = true;
			GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
			break;
		case State.Done:
			GameStates.Singleton.hero.RestoreAI();
			timesPlayed++;
			break;
		}
		previousState = currentState;
		currentState = newState;
		stateElapsedTics = 0;
	}

	private void StopHeroAI()
	{
		GameStates.Singleton.hero.RestoreAI();
		GameStates.Singleton.hero.GetComponent<HeroAI>().enabled = false;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (GameStates.Singleton.CurrentState == GameStates.State.PlayPaused)
		{
			return;
		}
		stateElapsedTics++;
		if (currentState == State.Approach1 && GameStates.Singleton.hero.PositionX >= base.PositionX + 6)
		{
			SetState(State.ApproachPause);
		}
		else if (currentState == State.ApproachPause && stateElapsedTics >= 10)
		{
			if (IsItemKey())
			{
				SetState(State.Approach2);
			}
			else
			{
				SetState(State.WakingUpSecondTime);
			}
		}
		else if (currentState == State.Approach2 && stateElapsedTics >= 65)
		{
			SetState(State.Pulling);
		}
		else if (currentState == State.Pulling || currentState == State.WakingUp)
		{
			if (GameStates.Singleton.hero.MySprite.GetFrameIndex() == 1)
			{
				SetGatePullPosition();
			}
			else
			{
				RestoreGatePosition();
			}
			if (currentState == State.Pulling && stateElapsedTics >= 60)
			{
				SetState(State.WakingUp);
			}
			else if (currentState == State.WakingUp && stateElapsedTics >= 75)
			{
				SetState(State.Talking);
			}
		}
		else if (currentState == State.WakingUpSecondTime && stateElapsedTics >= 75)
		{
			if (!IsItemKey() && !IsTreasureAvailable() && !isQuestControlled)
			{
				if (ShouldAskForNotification())
				{
					SetState(State.NoTreasureNotificationAsk);
				}
				else
				{
					SetState(State.NoTreasureNotificationSet);
				}
			}
			SetState(State.Talking);
		}
		else if (currentState == State.Talking)
		{
			dialogBubble.UpdateTic();
			if (specialCaseTreasureJustArrived)
			{
				MoveForwardWithSpecialCaseTreasureJustArrived();
			}
			else if (previousState == State.NoTreasureNotificationAsk && dialogBubble.npcDialogState == NPCDialogBubble.NPCDialogState.WaitingForSkip && !dialogData.continuesInNextDialog)
			{
				SetState(State.NotificationChoice);
			}
		}
		else if (currentState == State.RevealingItemUp && stateElapsedTics % 4 == 0)
		{
			revealOffsetY++;
			if (revealOffsetY == 3)
			{
				SetState(currentState + 1);
			}
		}
		else if (currentState == State.RevealingItemPause && stateElapsedTics >= 13)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.RevealingItemDown && stateElapsedTics % 4 == 0)
		{
			if (revealOffsetY > 0)
			{
				revealOffsetY--;
			}
			else if (stateElapsedTics >= 30)
			{
				if (isReferralEnabled && !isQuestControlled && (!ReferralController.singleton.hasSeenScottyQuestion || referralManuallyScheduled))
				{
					hasScottyAsked = true;
					referralButtonEnabled = false;
					ReferralController.singleton.hasSeenScottyQuestion = true;
					referralManuallyScheduled = false;
					SetState(State.ReferralQuestion);
					SetState(State.Talking);
				}
				else if (isReferralEnabled && !isQuestControlled && !hasScottyAsked && ReferralController.singleton.scottyExplainsExhaustion && !ShowReferralButton())
				{
					ReferralController.singleton.scottyExplainsExhaustion = false;
					SetState(State.ReferralExhausted);
					SetState(State.Talking);
				}
				else if (score == 0 && revealedItemCount <= 1)
				{
					SetState(State.Talking);
				}
				else
				{
					SetState(State.Shuffling);
				}
			}
		}
		else if (currentState == State.Shuffling)
		{
			if (stateElapsedTics >= shuffleTicsPerMove)
			{
				stateElapsedTics = 0;
				shuffleMoveIndex++;
				if (shuffleMoveIndex == shuffleMoveDataX.Length)
				{
					shuffleMoveIndex = 0;
					shuffleCount++;
					EffectivelySwapSkulls();
					if (shufflingSide == ShufflingSide.Left)
					{
						if (itemPosIndex == 0)
						{
							itemPosIndex = 1;
						}
						else if (itemPosIndex == 1)
						{
							itemPosIndex = 0;
						}
					}
					else if (itemPosIndex == 1)
					{
						itemPosIndex = 2;
					}
					else if (itemPosIndex == 2)
					{
						itemPosIndex = 1;
					}
					RandomizeShuffle();
					int num = 5 * (score + 1);
					if (shuffleCount >= num)
					{
						if (!hasGuessedBefore)
						{
							SetupDialog();
						}
						SetState(State.WaitingForInput);
					}
					else if (shufflePauseTicsPerScore[score] > 0)
					{
						currentState = State.ShufflingPause;
						stateElapsedTics = 0;
					}
				}
				if (score < 2)
				{
					SfxController.singleton.Play("haunted_gate_shuffle");
				}
				else
				{
					SfxController.singleton.Play("haunted_gate_shuffle_fast");
				}
			}
		}
		else if (currentState == State.ShufflingPause)
		{
			if (stateElapsedTics >= shufflePauseTicsPerScore[score])
			{
				currentState = State.Shuffling;
				stateElapsedTics = 0;
			}
		}
		else if (currentState == State.WaitingForInput)
		{
			if (referralManuallyScheduled)
			{
				SetState(State.ReferralQuestion);
				SetState(State.Talking);
				return;
			}
			dialogBubble.UpdateTic();
			for (int i = 0; i < 3; i++)
			{
				if (HasPressedSkullIndex(i))
				{
					hasGuessedBefore = true;
					inputChoice = i;
					SetState(State.RevealingChoiceUp);
					bigSkull.SetState(UndeadCryptIntroSkull.State.Idle);
					dialogBubble.Hide();
					dialogBubble.UpdateTic();
					SfxController.singleton.Play("confirm");
					break;
				}
			}
		}
		else if (currentState == State.RevealingChoiceUp && stateElapsedTics % 4 == 0)
		{
			revealOffsetY++;
			if (revealOffsetY == 3)
			{
				SetState(currentState + 1);
			}
		}
		else if (currentState == State.RevealingChoicePause1 && stateElapsedTics >= 13)
		{
			if (inputChoice == itemPosIndex)
			{
				score++;
				scoreImproved = true;
				scoreWorsened = false;
				if (score >= 3)
				{
					GlobalGameplayEvent.Execute(GlobalGameplayEvent.Type.DisablePause);
				}
				else
				{
					SfxController.singleton.Play("haunted_gate_torch_on");
				}
				AnalyticsMacros.PlaySkullGame();
			}
			else
			{
				score = Mathf.Max(0, score - 1);
				scoreImproved = false;
				scoreWorsened = true;
				SfxController.singleton.Play("haunted_gate_point_lost");
			}
			SetTorchesForScore();
			SetState(currentState + 1);
		}
		else if (currentState == State.RevealingChoicePause2 && stateElapsedTics >= 17)
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.RevealingChoiceDown && stateElapsedTics % 4 == 0)
		{
			if (revealOffsetY > 0)
			{
				revealOffsetY--;
			}
			else if (stateElapsedTics >= 30)
			{
				SetState(State.Talking);
			}
		}
		else if (currentState == State.SwappingSkulls)
		{
			if (stateElapsedTics >= shuffleTicsPerMove)
			{
				stateElapsedTics = 0;
				shuffleMoveIndex++;
				if (shuffleMoveIndex == 1)
				{
					revealOffsetY++;
				}
				else if (shuffleMoveIndex >= 3)
				{
					revealOffsetY--;
				}
				if (shuffleMoveIndex == shuffleMoveDataX.Length)
				{
					EffectivelySwapSkulls();
					SetState(State.Talking);
				}
				SfxController.singleton.Play("haunted_gate_shuffle");
			}
		}
		else if (currentState == State.DroppingItem)
		{
			if (stateElapsedTics % 4 == 1)
			{
				if (stateElapsedTics < 12)
				{
					if (revealOffsetY < 2)
					{
						revealOffsetY++;
					}
				}
				else if (revealOffsetY > 0)
				{
					revealOffsetY--;
				}
			}
			int[] array = ((itemPosIndex == 0) ? dropItemFromPos0_X : ((itemPosIndex == 1) ? dropItemFromPos1_X : dropItemFromPos2_X));
			int[] array2 = ((itemPosIndex == 0) ? dropItemFromPos0_Y : ((itemPosIndex == 1) ? dropItemFromPos1_Y : dropItemFromPos2_Y));
			int num2 = stateElapsedTics / 3;
			int a = num2;
			int a2 = num2;
			num2 = Mathf.Min(num2, itemSprite.FrameCount - 1);
			a = Mathf.Min(a, array.Length - 1);
			a2 = Mathf.Min(a2, array2.Length - 1);
			itemSprite.SetFrameIndex(num2);
			dropOffsetX = array[a];
			dropOffsetY = array2[a2];
			if (IsItemKey())
			{
				if (stateElapsedTics == 15)
				{
					SfxController.singleton.Play("haunted_gate_key_bounce_1");
				}
				else if (stateElapsedTics == 40)
				{
					SfxController.singleton.Play("haunted_gate_key_bounce_1");
				}
				else if (stateElapsedTics == 50)
				{
					SfxController.singleton.Play("haunted_gate_key_bounce_2");
				}
				else if (stateElapsedTics == 60)
				{
					SfxController.singleton.Play("haunted_gate_key_bounce_3");
				}
			}
			else if (stateElapsedTics == 5)
			{
				SfxController.singleton.Play("soul_stone_drop");
			}
			else if (stateElapsedTics == 40)
			{
				SfxController.singleton.Play("treasure_drop");
			}
			if (stateElapsedTics >= 63)
			{
				SetState(State.ApproachingItem);
			}
		}
		else if (currentState == State.PickingUpItem && stateElapsedTics >= 12)
		{
			if (IsItemKey())
			{
				SetState(State.ApproachGateWithKey);
			}
			else
			{
				SetState(State.ShowingTreasure);
			}
		}
		else if (currentState == State.ShowingTreasure && GameStates.Singleton.CurrentState != GameStates.State.SequentialPopupRewards)
		{
			SetState(State.Talking);
		}
		if (currentState == State.ApproachGateWithKey && stateElapsedTics == 39)
		{
			SfxController.singleton.Play("haunted_gate_key_into_gate");
		}
		if (currentState == State.OpeningGate && stateElapsedTics >= 40)
		{
			SetState(State.Talking);
		}
		else if ((currentState == State.ApproachingItem && stateElapsedTics >= 27) || (currentState == State.ApproachGateWithKey && stateElapsedTics >= 40) || (currentState == State.UnlockingGate && stateElapsedTics >= 24))
		{
			SetState(currentState + 1);
		}
		else if (currentState == State.EnterGate && stateElapsedTics >= 20)
		{
			SetState(State.Done);
		}
		else if (currentState == State.ReferralCodeInput)
		{
			if (stateElapsedTics == 1)
			{
				referralCodeInputDialog.Show();
			}
			else
			{
				referralCodeInputDialog.UpdateTic();
				if (referralCodeInputDialog.CurrentState == DialogNineSlice.State.Disabled)
				{
					if (referralCodeInputDialog.textToSubmit != null)
					{
						SetState(State.ReferralPending);
						string text = referralCodeInputDialog.inputField.text;
						ReferralController.singleton.RedeemKey(text, HandleReferralKeyRedemptionComplete);
					}
					else
					{
						SetState(State.ReferralError);
						SetState(State.Talking);
					}
				}
			}
		}
		else if (currentState == State.ReferralPending && stateElapsedTics >= 150)
		{
			SetState(State.ReferralError);
			SetState(State.Talking);
		}
		UpdateReferralButton();
	}

	private void HandleReferralKeyRedemptionComplete(bool success, string friendName)
	{
		if (!(this == null) && !(base.gameObject == null) && GameStates.Singleton.CurrentState == GameStates.State.Playing && GameStates.Singleton.level.QuestData != null && !(GameStates.Singleton.level.QuestData.id != "undead_crypt_intro"))
		{
			if (success)
			{
				isGoldenTreasure = true;
				referralFriendName = friendName;
				SelectTreasure(TreasureItem.Type.Gold);
				SetState(State.ReferralSuccess1);
			}
			else
			{
				SetState(State.ReferralError);
			}
			SetState(State.Talking);
		}
	}

	private void UpdateReferralButton()
	{
		if (_referralButton != null)
		{
			_referralButton.isVisible = ShowReferralButton();
		}
	}

	private bool ShowReferralButton()
	{
		if (isReferralEnabled && !isQuestControlled && _referralButton != null && referralButtonEnabled && ReferralController.singleton.CanRedeem() && ReferralController.singleton.hasSeenScottyQuestion && Hud.IsEnabled(Hud.Flag.ABILITIES) && GameStates.Singleton.CurrentState == GameStates.State.Playing && IsTreasureAvailable())
		{
			return !IsItemKey();
		}
		return false;
	}

	private void HandleReferralButtonPressed(DialogButton btn)
	{
		referralButtonEnabled = false;
		referralManuallyScheduled = true;
	}

	private void MoveForwardWithSpecialCaseTreasureJustArrived()
	{
		specialCaseTreasureJustArrived = false;
		scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.WelcomeBack);
		scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.WelcomeBack2);
		dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.SpecialCaseSkullIsBack);
		dialogBubble.SetMessage(dialogData.message);
		SfxController.singleton.Play(dialogData.sfxId);
		dialogBubble.Show();
		bigSkull.SetState(UndeadCryptIntroSkull.State.Talking, dialogData.expression);
		previousState = State.Talking;
		currentState = State.Talking;
	}

	private void SetupDialog()
	{
		dialogBubble.PositionX = 0;
		dialogBubble.PositionY = 0;
		if (scottyTheSkullNPC == null)
		{
			scottyTheSkullNPC = new ScottyTheSkull();
		}
		bool flag = IsItemKey();
		if (currentState == State.NoTreasureNotificationAsk || previousState == State.NoTreasureNotificationAsk)
		{
			dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.NoTreasureReminderAsk);
		}
		else if (currentState == State.NoTreasureNotificationSet || previousState == State.NoTreasureNotificationSet)
		{
			dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.NoTreasureReminderSet);
		}
		else if (currentState == State.OpeningGate || currentState == State.ShowingTreasure)
		{
			if (flag)
			{
				dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.GoodBye);
			}
			else
			{
				if (isQuestControlled)
				{
					return;
				}
				dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.GoodBye2);
			}
		}
		else if (currentState == State.ReferralQuestion)
		{
			dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.ReferralQuestion);
		}
		else if (currentState == State.ReferralYesNo || previousState == State.ReferralYesNo)
		{
			dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.ReferralDeclined);
		}
		else if (currentState == State.ReferralError || previousState == State.ReferralError)
		{
			dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.ReferralError);
		}
		else if (currentState == State.ReferralSuccess1)
		{
			dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.ReferralSuccess1);
		}
		else if (currentState == State.ReferralSuccess2 || previousState == State.ReferralSuccess2)
		{
			dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.ReferralSuccess2);
			dialogData.message = string.Format(dialogData.message, HeroSettings.name, referralFriendName);
		}
		else if (currentState == State.ReferralExhausted || previousState == State.ReferralExhausted)
		{
			dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.ReferralExhausted);
		}
		else if ((score == 0 && !hasGuessedBefore) || (score == 1 && currentState == State.SwappingSkulls))
		{
			if (timesPlayed == 0 || flag)
			{
				dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.Hello);
			}
			else if (timesPlayed == 1)
			{
				dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.WelcomeBack);
			}
			else if (!hasWishedHappyHolidays && EventController.singleton.IsEventActiveAndStarted("winter"))
			{
				hasWishedHappyHolidays = true;
				dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.HappyHolidays);
			}
			else
			{
				dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.WelcomeBack2);
			}
		}
		else if (score == 0 && scoreWorsened)
		{
			dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.PlayerMissesScoreZero);
		}
		else if (score == 1)
		{
			if (scoreImproved)
			{
				dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.Score1);
			}
			else
			{
				dialogData = scottyTheSkullNPC.GetRandomDialogForType(ScottyTheSkull.DialogType.PlayerMisses);
			}
		}
		else if (score == 2)
		{
			if (scoreImproved)
			{
				dialogData = scottyTheSkullNPC.GetRandomDialogForType(ScottyTheSkull.DialogType.Score2);
			}
			else
			{
				dialogData = scottyTheSkullNPC.GetRandomDialogForType(ScottyTheSkull.DialogType.PlayerMisses);
			}
		}
		else if (score == 3)
		{
			if (flag)
			{
				dialogData = scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.PlayerWinsFirstTime);
			}
			else
			{
				dialogData = scottyTheSkullNPC.GetRandomDialogForType(ScottyTheSkull.DialogType.PlayerWins);
			}
		}
		dialogBubble.SetMessage(dialogData.message);
		dialogBubble.Show();
		bigSkull.SetState(UndeadCryptIntroSkull.State.Talking, dialogData.expression);
		SfxController.singleton.Play(dialogData.sfxId);
	}

	private void HandleDialogBubbleDone()
	{
		if (currentState == State.Talking)
		{
			if (dialogData != null && dialogData.continuesInNextDialog)
			{
				SetupDialog();
			}
			else if (previousState == State.NoTreasureNotificationSet)
			{
				GameStates.Singleton.EndQuest();
			}
			else if (previousState == State.ShowingTreasure)
			{
				timesPlayed++;
				if (isQuestControlled)
				{
					bigSkull.SetState(UndeadCryptIntroSkull.State.Idle);
				}
				else
				{
					GameStates.Singleton.EndQuest();
				}
			}
			else if (previousState == State.OpeningGate)
			{
				SetState(State.EnterGate);
			}
			else if (previousState == State.ReferralQuestion)
			{
				scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.WelcomeBack);
				scottyTheSkullNPC.GetDialogForType(ScottyTheSkull.DialogType.WelcomeBack2);
				SetState(State.ReferralYesNo);
			}
			else if (previousState == State.ReferralSuccess1)
			{
				SetState(State.ReferralSuccess2);
				SetState(State.Talking);
			}
			else if (score == 0)
			{
				SetState(State.RevealingItemUp);
			}
			else if (score == 1 && !hasSwapped)
			{
				SetState(State.SwappingSkulls);
			}
			else if (score <= 2)
			{
				SetState(State.RevealingItemUp);
			}
			else
			{
				SetState(State.DroppingItem);
			}
		}
		else
		{
			bigSkull.SetState(UndeadCryptIntroSkull.State.Idle);
		}
	}

	private void EffectivelySwapSkulls()
	{
		int num = 0;
		int num2 = 1;
		if (shufflingSide == ShufflingSide.Right)
		{
			num++;
			num2++;
		}
		if (smallSkull1PosIndex == num && smallSkull2PosIndex == num2)
		{
			smallSkull1PosIndex = num2;
			smallSkull2PosIndex = num;
		}
		else if (smallSkull1PosIndex == num && bigSkullPosIndex == num2)
		{
			smallSkull1PosIndex = num2;
			bigSkullPosIndex = num;
		}
		else if (smallSkull2PosIndex == num && smallSkull1PosIndex == num2)
		{
			smallSkull2PosIndex = num2;
			smallSkull1PosIndex = num;
		}
		else if (smallSkull2PosIndex == num && bigSkullPosIndex == num2)
		{
			smallSkull2PosIndex = num2;
			bigSkullPosIndex = num;
		}
		else if (bigSkullPosIndex == num && smallSkull1PosIndex == num2)
		{
			bigSkullPosIndex = num2;
			smallSkull1PosIndex = num;
		}
		else if (bigSkullPosIndex == num && smallSkull2PosIndex == num2)
		{
			bigSkullPosIndex = num2;
			smallSkull2PosIndex = num;
		}
	}

	private bool HasPressedSkullIndex(int index)
	{
		if (AsciiMouse.singleton.down0)
		{
			UndeadCryptIntroSkull undeadCryptIntroSkull = ((index == smallSkull1PosIndex) ? smallSkull1 : ((index != smallSkull2PosIndex) ? bigSkull : smallSkull2));
			int x = AsciiMouse.singleton.x;
			int y = AsciiMouse.singleton.y;
			if (x >= undeadCryptIntroSkull.LastDrawX - 1 && x <= undeadCryptIntroSkull.LastDrawX + 5 && y >= undeadCryptIntroSkull.LastDrawY && y <= undeadCryptIntroSkull.LastDrawY + 2)
			{
				return true;
			}
		}
		return false;
	}

	private void Update()
	{
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += base.PositionX;
		offsetY += base.PositionZ - base.PositionY;
		if (currentState == State.RevealingItemUp || currentState == State.RevealingItemPause || currentState == State.RevealingItemDown || currentState == State.RevealingChoiceUp || currentState == State.RevealingChoicePause1 || currentState == State.RevealingChoicePause2 || currentState == State.RevealingChoiceDown || currentState == State.SwappingSkulls || currentState == State.DroppingItem || currentState == State.ApproachingItem || currentState == State.PickingUpItem)
		{
			if (currentState >= State.DroppingItem || (revealOffsetY != 0 && (currentState <= State.RevealingItemDown || inputChoice == itemPosIndex)))
			{
				IntPosition intPosition = skullPositions[itemPosIndex];
				itemSprite.Draw(r, offsetX + intPosition.x + dropOffsetX, offsetY + intPosition.y + dropOffsetY);
			}
		}
		else if (currentState == State.ApproachGateWithKey || currentState == State.UnlockingGate)
		{
			Hero hero = GameStates.Singleton.hero;
			int num = offsetX - base.PositionX + hero.PositionX;
			int num2 = offsetY - base.PositionZ + base.PositionY + hero.PositionZ - hero.PositionY;
			if (currentState == State.ApproachGateWithKey)
			{
				num += 3;
				num2 -= 2;
			}
			else if (currentState == State.UnlockingGate)
			{
				num += 3;
				num2 -= 3;
			}
			itemSprite.Draw(r, num, num2);
			if (currentState == State.UnlockingGate)
			{
				r.SetCell(num + 1, num2 + 1, SpecialSymbols.Map('·'));
			}
		}
		if (currentState == State.PickingUpItem && !IsItemKey())
		{
			int offsetX2 = offsetX - base.PositionX;
			int offsetY2 = offsetY - base.PositionZ + base.PositionY;
			GameStates.Singleton.hero.Draw(r, offsetX2, offsetY2);
		}
		smallSkull1Pos.x = skullPositions[smallSkull1PosIndex].x;
		smallSkull1Pos.y = skullPositions[smallSkull1PosIndex].y;
		smallSkull2Pos.x = skullPositions[smallSkull2PosIndex].x;
		smallSkull2Pos.y = skullPositions[smallSkull2PosIndex].y;
		bigSkullPos.x = skullPositions[bigSkullPosIndex].x;
		bigSkullPos.y = skullPositions[bigSkullPosIndex].y;
		if (currentState == State.Shuffling || currentState == State.SwappingSkulls)
		{
			int num3 = ((shufflingSide != ShufflingSide.Left) ? 1 : 0);
			IntPosition intPosition2 = ((smallSkull1PosIndex == num3) ? smallSkull1Pos : ((smallSkull2PosIndex != num3) ? bigSkullPos : smallSkull2Pos));
			int num4 = ((shufflingSide == ShufflingSide.Left) ? 1 : 2);
			IntPosition intPosition3 = ((smallSkull1PosIndex == num4) ? smallSkull1Pos : ((smallSkull2PosIndex != num4) ? bigSkullPos : smallSkull2Pos));
			int[] array = ((shufflingDirection == ShufflingDirection.Clockwise) ? shuffleMoveDataX : shuffleMoveDataXccw);
			int[] obj = ((shufflingDirection == ShufflingDirection.Clockwise) ? shuffleMoveDataY : shuffleMoveDataYccw);
			int num5 = array[shuffleMoveIndex];
			int num6 = obj[shuffleMoveIndex];
			intPosition2.x += num5;
			intPosition2.y += num6;
			intPosition3.x -= num5;
			intPosition3.y -= num6;
		}
		if (currentState == State.RevealingItemUp || currentState == State.RevealingItemPause || currentState == State.RevealingItemDown || currentState == State.RevealingChoiceUp || currentState == State.RevealingChoicePause1 || currentState == State.RevealingChoicePause2 || currentState == State.RevealingChoiceDown || currentState == State.SwappingSkulls || currentState == State.DroppingItem)
		{
			if (revealPosIndex == smallSkull1PosIndex)
			{
				smallSkull1Pos.y -= revealOffsetY;
			}
			else if (revealPosIndex == smallSkull2PosIndex)
			{
				smallSkull2Pos.y -= revealOffsetY;
			}
			else if (revealPosIndex == bigSkullPosIndex)
			{
				bigSkullPos.y -= revealOffsetY;
			}
		}
		if (score > 0 || IsItemKey() || IsTreasureAvailable() || isQuestControlled)
		{
			smallSkull1.Draw(r, offsetX + smallSkull1Pos.x, offsetY + smallSkull1Pos.y);
		}
		smallSkull2.Draw(r, offsetX + smallSkull2Pos.x, offsetY + smallSkull2Pos.y);
		bigSkull.Draw(r, offsetX + bigSkullPos.x, offsetY + bigSkullPos.y);
		if (DEBUG_SHOW_ITEM_POSITION_AT_ALL_TIMES)
		{
			IntPosition intPosition4 = skullPositions[itemPosIndex];
			itemSprite.Draw(r, offsetX + intPosition4.x, offsetY + intPosition4.y);
		}
		if (currentState == State.Talking || currentState == State.WaitingForInput || currentState == State.NotificationChoice)
		{
			dialogBubble.SetNPCMouthPosition(bigSkull.LastDrawX + 2, bigSkull.LastDrawY);
			int offsetX3 = r.width - dialogBubble.Width >> 1;
			int num7 = bigSkull.LastDrawY + 5;
			if (currentState == State.WaitingForInput)
			{
				if (bigSkullPosIndex == 0)
				{
					num7 += 4;
				}
				else if (bigSkullPosIndex == 1)
				{
					num7++;
				}
			}
			dialogBubble.Draw(r, offsetX3, num7);
			if (dialogData.type == ScottyTheSkull.DialogType.NoTreasureReminderAsk || dialogData.type == ScottyTheSkull.DialogType.NoTreasureReminderSet)
			{
				DrawTimeRemaining(r);
			}
		}
		else if (currentState == State.ReferralCodeInput && stateElapsedTics >= 1)
		{
			referralCodeInputDialog.Draw(r, (r.width - referralCodeInputDialog.Width) / 2, (r.height - referralCodeInputDialog.Height) / 2);
		}
		else if (currentState == State.ReferralPending && GameStates.Singleton.loadingSpinner != null)
		{
			GameStates.Singleton.loadingSpinner.Draw(r, (r.width >> 1) + 2, 2);
		}
	}

	private void DrawTimeRemaining(AsciiRenderProcedural r)
	{
		long num = (long)GetTreasureSecondsRemaining();
		if (_lastSecondsRemaining != num)
		{
			_lastSecondsRemaining = num;
			if (num <= 0)
			{
				specialCaseTreasureJustArrived = true;
				if (currentState == State.NotificationChoice)
				{
					UnregisterDialogCallbacks();
					GameStates.Singleton.SetState(GameStates.State.Playing);
					MoveForwardWithSpecialCaseTreasureJustArrived();
				}
			}
			else
			{
				timeRemainingLabel.SetValue(Utils.FormatTimeCasual(num));
			}
		}
		for (int i = dialogBubble.lastDrawX; i < r.width; i++)
		{
			for (int j = dialogBubble.lastDrawY; j < r.height; j++)
			{
				AsciiCellProcedural cell = r.GetCell(i, j);
				if (cell != null && cell.GetValue() == 38)
				{
					timeRemainingLabel.Draw(r, i, j);
					break;
				}
			}
		}
	}

	private void SetTorchesForScore()
	{
		EnableLeftTorch(score >= 1 || LIGHT_TORCHES_ALL_THE_TIME);
		EnableRightTorch(score >= 2 || LIGHT_TORCHES_ALL_THE_TIME);
	}

	private void EnableLeftTorch(bool enabled)
	{
		EnableTorchWithName(enabled, "undead_crypt_torch_flame_L");
	}

	private void EnableRightTorch(bool enabled)
	{
		EnableTorchWithName(enabled, "undead_crypt_torch_flame_R");
	}

	private void EnableTorchWithName(bool enabled, string torchName)
	{
		Decoration decorationWithId = GameStates.Singleton.level.GetDecorationWithId(torchName);
		if (decorationWithId != null)
		{
			decorationWithId.PositionY = ((!enabled) ? 100 : 0);
			decorationWithId.gameObject.SetActive(enabled);
			AudioSource component = decorationWithId.gameObject.GetComponent<AudioSource>();
			if (component != null)
			{
				component.enabled = enabled & SfxController.singleton.enabled;
				component.volume = AmbianceController.singleton.volume;
			}
		}
	}

	private void RandomizeShuffle()
	{
		shufflingSide = ((!(UnityEngine.Random.Range(0f, 1f) < 0.5f)) ? ShufflingSide.Left : ShufflingSide.Right);
		shufflingDirection = ((!(UnityEngine.Random.Range(0f, 1f) < 0.5f)) ? ShufflingDirection.CounterClockwise : ShufflingDirection.Clockwise);
	}

	private void HandleButton1(DialogButton btn)
	{
		UnregisterDialogCallbacks();
		if (currentState == State.ReferralYesNo)
		{
			GameStates.Singleton.playChoiceDialog.Hide();
			GameStates.Singleton.SetState(GameStates.State.Playing);
			SetState(State.ReferralCodeInput);
		}
		else
		{
			wasNotificationAnswerYes = true;
			NotificationMacros.UndeadCryptIntro(nextTreasureAvailableDate);
			GameStates.Singleton.EndQuest();
		}
	}

	private void HandleButton2(DialogButton btn)
	{
		UnregisterDialogCallbacks();
		if (currentState == State.ReferralYesNo)
		{
			GameStates.Singleton.playChoiceDialog.Hide();
			GameStates.Singleton.SetState(GameStates.State.Playing);
			SetState(State.Talking);
		}
		else
		{
			GameStates.Singleton.EndQuest();
		}
	}

	private void RegisterDialogCallbacks()
	{
		GameStates.Singleton.playChoiceDialog.button1.OnPressed += HandleButton1;
		GameStates.Singleton.playChoiceDialog.button2.OnPressed += HandleButton2;
	}

	private void UnregisterDialogCallbacks()
	{
		GameStates.Singleton.playChoiceDialog.button1.OnPressed -= HandleButton1;
		GameStates.Singleton.playChoiceDialog.button2.OnPressed -= HandleButton2;
	}

	private Decoration GetGate()
	{
		if (gateDeco == null)
		{
			gateDeco = GameStates.Singleton.level.GetDecorationWithId("undead_crypt_gate");
		}
		return gateDeco;
	}

	private void SetGatePullPosition()
	{
		Decoration gate = GetGate();
		if (gate != null && gate.MySprite.GetFrameIndex() != 1)
		{
			gate.MySprite.SetFrameIndex(1);
			SfxController.singleton.Play("haunted_gate_try_to_open");
		}
	}

	private void RestoreGatePosition()
	{
		Decoration gate = GetGate();
		if (gate != null)
		{
			gate.MySprite.SetFrameIndex(0);
		}
	}

	private void InitRewardItem()
	{
		if (IsItemKey())
		{
			MakeKeySprite();
		}
		else
		{
			SelectTreasure();
		}
	}

	private void MakeKeySprite()
	{
		itemSprite = UnityEngine.Object.Instantiate(keyPrefab);
		itemSprite.Load();
	}

	private void SelectTreasure()
	{
		if (timesPlayed == 1)
		{
			SelectTreasure(TreasureItem.Type.Giant);
		}
		else if (timesPlayed == 2)
		{
			SelectTreasure(TreasureItem.Type.Rare);
		}
		else
		{
			SelectTreasure(TreasureItem.Type.Bone);
		}
	}

	private void SelectTreasure(TreasureItem.Type type)
	{
		string prefabPath = treasureIcon;
		selectedTreasureId = "treasure_1";
		switch (type)
		{
		case TreasureItem.Type.Bone:
			prefabPath = boneTreasureIcon;
			selectedTreasureId = "bone";
			break;
		case TreasureItem.Type.Rare:
			prefabPath = rareTreasureIcon;
			selectedTreasureId = "treasure_3";
			break;
		case TreasureItem.Type.Giant:
			prefabPath = giantTreasureIcon;
			selectedTreasureId = "scotty_giant";
			break;
		case TreasureItem.Type.Epic:
			prefabPath = epicTreasureIcon;
			selectedTreasureId = "treasure_4";
			break;
		case TreasureItem.Type.Gold:
			prefabPath = goldTreasureIcon;
			selectedTreasureId = "treasure_gold";
			break;
		}
		if (itemSprite != null)
		{
			UnityEngine.Object.Destroy(itemSprite.gameObject);
		}
		itemSprite = Utils.InstantiatePrefab(prefabPath).GetComponent<AsciiSprite>();
		itemSprite.Load();
	}

	private TreasureItem MakeTreasureItem()
	{
		if (selectedTreasureId == "scotty_giant")
		{
			string itemId = "treasure_2";
			Data.Treasure treasureWithId = TreasureFactory.singleton.GetTreasureWithId(selectedTreasureId);
			TreasureItem obj = ItemFactory.singleton.MakeItem(itemId) as TreasureItem;
			obj.itemsInTreasure = treasureWithId.items;
			return obj;
		}
		List<ItemData.Element> possibleElements = TreasureFactory.singleton.MakeListOfPossibleElements();
		return TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", selectedTreasureId, possibleElements);
	}

	protected override void Start()
	{
		base.Start();
		GameCamera gameCamera = GameStates.Singleton.level.gameCamera;
		gameCamera.SetupLerpToPos((int)gameCamera.lerpDestX, 1, (int)gameCamera.lerpDestZ, gameCamera.lerpSpeed);
		gameCamera.JumpToDestination();
		SetState(State.Approach1);
		if (!isQuestControlled)
		{
			UIButton uIButton = SSUILayer.singleton.AddButton();
			uIButton.anchorX = (uIButton.dockX = UIControl.AnchorX.left);
			uIButton.anchorY = (uIButton.dockY = UIControl.AnchorY.bottom);
			uIButton.PositionX = 2;
			uIButton.PositionY = -1;
			uIButton.Width = 23;
			uIButton.Height = 3;
			uIButton.isVisible = false;
			uIButton.Property_SetText(Te.xt("Add Referral Code"));
			_referralButton = uIButton;
			_referralButton.button.OnPressed += HandleReferralButtonPressed;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		smallSkull1 = UnityEngine.Object.Instantiate(smallSkullPrefab);
		smallSkull2 = UnityEngine.Object.Instantiate(smallSkullPrefab);
		bigSkull = UnityEngine.Object.Instantiate(bigSkullPrefab);
		dialogBubble = UnityEngine.Object.Instantiate(dialogBubblePrefab);
		dialogBubble.OnDone += HandleDialogBubbleDone;
		Utils.PreloadAsyncPrefab(treasureIcon);
		Utils.PreloadAsyncPrefab(giantTreasureIcon);
		Utils.PreloadAsyncPrefab(rareTreasureIcon);
		Utils.PreloadAsyncPrefab(epicTreasureIcon);
		Utils.PreloadAsyncPrefab(boneTreasureIcon);
	}

	private void OnDestroy()
	{
		if ((bool)smallSkull1 && (bool)smallSkull1.gameObject)
		{
			UnityEngine.Object.Destroy(smallSkull1.gameObject);
		}
		if ((bool)smallSkull2 && (bool)smallSkull2.gameObject)
		{
			UnityEngine.Object.Destroy(smallSkull2.gameObject);
		}
		if ((bool)bigSkull && (bool)bigSkull.gameObject)
		{
			UnityEngine.Object.Destroy(bigSkull.gameObject);
		}
		if (dialogBubble != null)
		{
			dialogBubble.OnDone -= HandleDialogBubbleDone;
		}
		if (_referralButton != null)
		{
			_referralButton.button.OnPressed -= HandleReferralButtonPressed;
		}
	}

	public static bool IsItemKey()
	{
		return !QuestController.singleton.IsAvailable("undead_crypt");
	}

	public static bool IsTreasureAvailable()
	{
		if (timesPlayed > 0 && !IsItemKey())
		{
			if (timesPlayed == 1)
			{
				return true;
			}
			return DateTime.Now >= nextTreasureAvailableDate;
		}
		return false;
	}

	public static double GetTreasureSecondsRemaining()
	{
		return (nextTreasureAvailableDate - DateTime.Now).TotalSeconds;
	}

	private static void SetNextTreasureAvailableDate()
	{
		if (timesPlayed == 0)
		{
			nextTreasureAvailableDate = DateTime.Now;
		}
		else if (timesPlayed == 1)
		{
			nextTreasureAvailableDate = DateTime.Now.AddMinutes(5.0);
		}
		else if (timesPlayed == 2)
		{
			nextTreasureAvailableDate = DateTime.Now.AddHours(1.0);
		}
		else
		{
			nextTreasureAvailableDate = DateTime.Now.AddHours(23.0);
		}
		if (wasNotificationAnswerYes && timesPlayed >= 1)
		{
			NotificationMacros.UndeadCryptIntro(nextTreasureAvailableDate);
		}
	}

	private static bool ShouldAskForNotification()
	{
		if (!wasNotificationAnswerYes)
		{
			return false;
		}
		return false;
	}

	public static void ResetClock()
	{
		nextTreasureAvailableDate = DateTime.Now;
	}

	public static string Serialize()
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("timesPlayed", timesPlayed);
		SlimJson.AddProperty("nextTreasureAvailableDate", nextTreasureAvailableDate);
		return SlimJson.EndSerialization();
	}

	public static void Parse(string sjson)
	{
		ClearProgress();
		if (sjson != null)
		{
			timesPlayed = SlimJson.ParseInt(sjson, "timesPlayed");
			nextTreasureAvailableDate = SlimJson.ParseDateTime(sjson, "nextTreasureAvailableDate");
		}
	}

	public static void ClearProgress()
	{
		timesPlayed = 0;
		ResetClock();
	}
}

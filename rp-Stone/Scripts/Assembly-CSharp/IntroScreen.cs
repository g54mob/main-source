using UnityEngine;

public class IntroScreen : MonoBehaviour
{
	public enum State
	{
		Dot = 0,
		SeeNothing = 1,
		HearNothing = 2,
		FeelSomething = 3,
		TheGroundIsRocky = 4,
		Collecting = 5,
		FoundSightstone = 6,
		Done = 7
	}

	public AsciiString message;

	public DialogButton collectButton;

	public AsciiString tapToStopMessage;

	public string dotSymbol = "o";

	private int pressToStartDelay = 20;

	public int dotBlinkPeriod = 20;

	public int textTrickleDuration = 20;

	public int feelTextTrickleDuration = 50;

	public int tapAllowedAfterTics = 20;

	public int collectButtonExtraDelay = 10;

	public int ticsPerStoneCollected = 100;

	public int tapToStopAppears = 70;

	private State currentState;

	private int stateElapsedTics;

	private int stateTrickleDuration;

	private int stoneCollectionTic;

	private long lastStoneCount = -1L;

	private int initialTicDelay;

	public State CurrentState => currentState;

	public void Activate()
	{
		SetState(State.Dot);
	}

	public void SetState(State newState)
	{
		stateTrickleDuration = textTrickleDuration;
		switch (newState)
		{
		case State.Dot:
			message.SetValue(Te.xt("PRESS TO BEGIN"));
			AmbianceController.singleton.AddAmbient("cross_deadwood_wind");
			AnalyticsMacros.FtueDot();
			break;
		case State.SeeNothing:
			message.SetValue(Te.xt("You see nothing"));
			AnalyticsMacros.FirstInteraction();
			break;
		case State.HearNothing:
			message.SetValue(Te.xt("You hear nothing"));
			break;
		case State.FeelSomething:
			message.SetValue(Te.xt("You feel...... something"));
			stateTrickleDuration = feelTextTrickleDuration;
			break;
		case State.TheGroundIsRocky:
			message.SetValue(Te.xt("The ground, it feels rocky"));
			break;
		case State.Collecting:
			stoneCollectionTic = 0;
			AnalyticsMacros.IntroCollecting();
			break;
		case State.FoundSightstone:
			message.SetValue(Te.xt("One stone has something etched onto it"));
			break;
		}
		initialTicDelay = -1;
		currentState = newState;
		stateElapsedTics = 0;
	}

	public void UpdateTic()
	{
		stateElapsedTics++;
		if (currentState == State.Dot && CheckTap(tapAllowedAfterTics))
		{
			SetState(State.SeeNothing);
		}
		else if (currentState == State.SeeNothing && CheckTap(tapAllowedAfterTics + stateTrickleDuration))
		{
			SetState(State.HearNothing);
		}
		else if (currentState == State.HearNothing && CheckTap(tapAllowedAfterTics + stateTrickleDuration))
		{
			SetState(State.FeelSomething);
		}
		else if (currentState == State.FeelSomething && CheckTap(tapAllowedAfterTics + stateTrickleDuration))
		{
			SetState(State.TheGroundIsRocky);
		}
		else if (currentState == State.TheGroundIsRocky)
		{
			if (stateElapsedTics >= stateTrickleDuration + collectButtonExtraDelay)
			{
				collectButton.UpdateTic();
			}
		}
		else if (currentState == State.Collecting)
		{
			long resourceOfType = InventoryResources.singleton.GetResourceOfType(Data.Resource.Stone);
			if (resourceOfType >= 2 && resourceOfType < 5 && CheckTap(0))
			{
				InventoryResources.singleton.AddResourceOfType(Data.Resource.Stone, 5 - resourceOfType);
				SetState(State.FoundSightstone);
				return;
			}
			stoneCollectionTic++;
			if (stoneCollectionTic >= ticsPerStoneCollected)
			{
				stoneCollectionTic = 0;
				if (resourceOfType >= 5)
				{
					SetState(State.FoundSightstone);
				}
				else
				{
					InventoryResources.singleton.AddResourceOfType(Data.Resource.Stone, 1L);
				}
			}
		}
		else if (currentState == State.FoundSightstone && CheckTap(tapAllowedAfterTics + stateTrickleDuration))
		{
			ShowSightstone();
		}
	}

	private void HandleOnCollectPressed(DialogButton button)
	{
		SetState(State.Collecting);
	}

	private bool CheckTap(int afterTics)
	{
		if (stateElapsedTics >= afterTics)
		{
			return AsciiMouse.singleton.down0;
		}
		return false;
	}

	private void ShowSightstone()
	{
		Inventory.Singleton.AddItem(ItemFactory.singleton.MakeItem("sight_stone"));
		GameStates.Singleton.ShowSoulstoneScreen(SoulstoneScreen.Type.SightStone, GameStates.State.SightstonePlayTransition);
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		r.Clear();
		if (currentState == State.Dot)
		{
			DrawDot(r, offsetX, offsetY);
			if (stateElapsedTics >= pressToStartDelay)
			{
				DrawMessageWithTrickle(r, offsetX, offsetY);
			}
		}
		else if (currentState == State.SeeNothing || currentState == State.HearNothing || currentState == State.FeelSomething || currentState == State.FoundSightstone)
		{
			DrawMessageWithTrickle(r, offsetX, offsetY);
			if (stateElapsedTics >= tapAllowedAfterTics + stateTrickleDuration)
			{
				DrawDot(r, offsetX, offsetY);
			}
		}
		else if (currentState == State.TheGroundIsRocky)
		{
			DrawMessageWithTrickle(r, offsetX, offsetY);
			if (stateElapsedTics >= stateTrickleDuration + collectButtonExtraDelay)
			{
				collectButton.Draw(r, offsetX, offsetY);
			}
		}
		else if (currentState == State.Collecting)
		{
			long resourceOfType = InventoryResources.singleton.GetResourceOfType(Data.Resource.Stone);
			if (lastStoneCount != resourceOfType)
			{
				lastStoneCount = resourceOfType;
				string value = resourceOfType switch
				{
					0L => Te.xt("tid_intro_zero"), 
					1L => Te.xt("1 stone"), 
					5L => Te.xt("tid_intro_five"), 
					_ => string.Format(Te.xt("{0} stones"), Utils.FormatNumber(resourceOfType)), 
				};
				message.SetValue(value);
			}
			if (resourceOfType == 1 || resourceOfType >= 10)
			{
				message.Draw(r, offsetX, offsetY);
			}
			else
			{
				message.Draw(r, offsetX + 1, offsetY);
			}
			if (resourceOfType >= 2)
			{
				DrawDot(r, offsetX, offsetY);
			}
			if (resourceOfType >= 7)
			{
				tapToStopMessage.Draw(r, offsetX, offsetY);
			}
		}
	}

	private bool DrawDot(AsciiRenderProcedural r, int x, int y)
	{
		if (initialTicDelay == -1)
		{
			initialTicDelay = stateElapsedTics;
		}
		if (dotSymbol.Length > 0 && (stateElapsedTics - initialTicDelay) % dotBlinkPeriod < dotBlinkPeriod >> 1)
		{
			r.SetCell(x, y, (int)dotSymbol[0], false);
			return true;
		}
		return false;
	}

	private void DrawMessageWithTrickle(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		int width = r.width;
		int length = message.Length;
		int num = (width - length) / 2 - 1;
		float num2 = 1f - Mathf.Clamp01((float)stateElapsedTics / (float)stateTrickleDuration);
		r.PushClip(new AsciiRenderProcedural.Clip
		{
			left = num,
			right = (int)((float)(width - 2 * num) * num2) + num
		});
		message.Draw(r, offsetX, offsetY);
		r.PopClip();
	}

	private void Update()
	{
	}

	private void Start()
	{
		collectButton.OnPressed += HandleOnCollectPressed;
	}

	private void OnDestroy()
	{
		collectButton.OnPressed -= HandleOnCollectPressed;
	}
}

using System;
using UnityEngine;

public class GateScreen : MonoBehaviour
{
	private enum State
	{
		Idle = 0,
		Opening = 1,
		WhiteOut = 2,
		Done = 3,
		Back = 4
	}

	public int lockTapAreaWidth = 5;

	public int lockTapAreaHeight = 3;

	public int whiteOutTicDuration = 30;

	public BronzeGateLooseStone looseStone;

	private GateData _gateData;

	private AsciiAnimation background;

	private State currentState;

	private State previousState;

	private int stateElapsedTics;

	public GateData gateData
	{
		get
		{
			return _gateData;
		}
		set
		{
			_gateData = value;
			LoadBackground();
			SetState(State.Idle);
		}
	}

	public event Action<GateData> OnOpenGate;

	public event Action<GateData> OnCannotOpen;

	public event Action<GateData> OnEscape;

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.Idle:
			background.Stop();
			AmbianceController.singleton.AddAmbient("ambient_bronze_gate");
			AnalyticsMacros.ExamineBronzeGate();
			break;
		case State.Opening:
			AsciiMouse.singleton.Hide();
			background.Play();
			break;
		}
		previousState = currentState;
		currentState = newState;
		stateElapsedTics = 0;
	}

	private void Update()
	{
		if (currentState == State.Idle && Input.GetKeyDown(KeyCode.Escape))
		{
			FireOnEscape();
			SetState(State.Back);
		}
	}

	private bool CanOpen()
	{
		if (gateData.unlockRequires == null)
		{
			return true;
		}
		for (int i = 0; i < gateData.unlockRequires.Length; i++)
		{
			string text = gateData.unlockRequires[i];
			if (!ProgressFlags.GetFlag(text) && !Inventory.Singleton.HasItemById(text))
			{
				return false;
			}
		}
		return true;
	}

	public void UpdateTic()
	{
		stateElapsedTics++;
		if (currentState == State.Opening)
		{
			if (!background.Playing)
			{
				SetState(State.WhiteOut);
			}
		}
		else if (currentState == State.WhiteOut && stateElapsedTics >= whiteOutTicDuration)
		{
			SetState(State.Done);
			FireOnOpen();
		}
		else
		{
			if (currentState != State.Idle)
			{
				return;
			}
			int x = AsciiMouse.singleton.x;
			int y = AsciiMouse.singleton.y;
			int num = GameStates.Singleton.asciiRenderer.width >> 1;
			int num2 = GameStates.Singleton.asciiRenderer.height >> 1;
			int num3 = num;
			int num4 = num2;
			int num5 = 12;
			int num6 = 12;
			if (gateData != null && background != null)
			{
				num3 += gateData.lockX;
				num4 += gateData.lockY;
			}
			if (AsciiMouse.singleton.down0 && x >= num3 - lockTapAreaWidth && x <= num3 + lockTapAreaWidth && y >= num4 - lockTapAreaHeight && y <= num4 + lockTapAreaHeight)
			{
				if (CanOpen())
				{
					SfxController.singleton.Play("wand_drop");
					SetState(State.Opening);
					AnalyticsMacros.BronzeGateOpened();
				}
				else
				{
					SfxController.singleton.Play(_gateData.lockedSfx);
					FireOnCannotOpen();
				}
			}
			else if (AsciiMouse.singleton.down0 && x >= num - num5 && x <= num + num5 && y >= num2 - num6 && y <= num2 + num6)
			{
				SfxController.singleton.Play("metal_drop");
			}
			else if (looseStone != null)
			{
				looseStone.UpdateTic();
			}
		}
	}

	private void FireOnOpen()
	{
		if (this.OnOpenGate != null)
		{
			this.OnOpenGate(gateData);
		}
	}

	private void FireOnCannotOpen()
	{
		if (this.OnCannotOpen != null)
		{
			this.OnCannotOpen(gateData);
		}
	}

	private void FireOnEscape()
	{
		if (this.OnEscape != null)
		{
			this.OnEscape(gateData);
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX = r.width >> 1;
		offsetY = r.height >> 1;
		if (background != null)
		{
			background.Sprite.Draw(r, offsetX, offsetY);
		}
		if (!(looseStone == null) && currentState != State.WhiteOut && (currentState != State.Opening || stateElapsedTics < 102) && (currentState != State.Done || previousState != State.WhiteOut))
		{
			looseStone.Draw(r, offsetX, offsetY);
		}
	}

	private void LoadBackground()
	{
		if (background != null)
		{
			UnityEngine.Object.Destroy(background.gameObject);
			background = null;
		}
		GameObject gameObject = Utils.InstantiatePrefab("Quests/" + gateData.background);
		if (gameObject != null)
		{
			background = gameObject.GetComponent<AsciiAnimation>();
			if (background != null)
			{
				background.transform.parent = base.transform;
				background.Sprite.Load();
			}
		}
		if (background == null)
		{
			Utils.LogError("Could not load background for Gate " + gateData.id);
		}
	}
}

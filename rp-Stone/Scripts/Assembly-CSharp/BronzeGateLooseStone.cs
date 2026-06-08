using UnityEngine;

[RequireComponent(typeof(AsciiSprite))]
public class BronzeGateLooseStone : MonoBehaviour
{
	private enum State
	{
		WaitingForPress = 0,
		Boomerang = 1,
		Empty = 2
	}

	public AsciiSprite boomerangSprite;

	public AsciiAnimation stoneFallingAnm;

	private AsciiSprite mySprite;

	private const string FLAG_STONE_OPENED = "bronze_gate_loose_stone_0";

	private const string FLAG_BOOMERANG_COLLECTED = "bronze_gate_loose_stone_1";

	private State currentState;

	private int stateElapsedTics;

	private bool showFallingStone;

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.Boomerang:
			SfxController.singleton.Play("pickup_success");
			showFallingStone = true;
			stoneFallingAnm.Stop();
			stoneFallingAnm.Play();
			break;
		case State.Empty:
			SfxController.singleton.Play("buy");
			break;
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	public void UpdateTic()
	{
		stateElapsedTics++;
		if (!AsciiMouse.singleton.down0 || (currentState != State.WaitingForPress && currentState != State.Boomerang))
		{
			return;
		}
		int x = AsciiMouse.singleton.x;
		int y = AsciiMouse.singleton.y;
		if (x < mySprite.lastDrawX - 1 || x > mySprite.lastDrawX + 7 || y < mySprite.lastDrawY || y > mySprite.lastDrawY + 4)
		{
			return;
		}
		if (currentState == State.Boomerang)
		{
			if (stateElapsedTics >= 11)
			{
				SetState(State.Empty);
			}
		}
		else if (mySprite.GetFrameIndex() == mySprite.FrameCount - 1)
		{
			SetState(State.Boomerang);
		}
		else
		{
			mySprite.SetFrameIndex(mySprite.GetFrameIndex() + 1);
			SfxController.singleton.Play("waterfall_land");
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentState == State.WaitingForPress)
		{
			mySprite.Draw(r, offsetX, offsetY);
		}
		else if (currentState == State.Boomerang)
		{
			boomerangSprite.Draw(r, offsetX, offsetY);
		}
		if (showFallingStone && (currentState == State.Boomerang || currentState == State.Empty))
		{
			stoneFallingAnm.Sprite.Draw(r, offsetX, offsetY);
		}
	}

	private void Start()
	{
		mySprite.Load();
		if (ProgressFlags.GetFlag("bronze_gate_loose_stone_1"))
		{
			currentState = State.Empty;
		}
		else if (ProgressFlags.GetFlag("bronze_gate_loose_stone_0"))
		{
			currentState = State.Boomerang;
		}
	}

	private void Awake()
	{
		mySprite = GetComponent<AsciiSprite>();
	}
}

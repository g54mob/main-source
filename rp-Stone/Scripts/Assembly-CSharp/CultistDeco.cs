using UnityEngine;

public class CultistDeco : Decoration
{
	private enum State
	{
		Praying = 0,
		Delay = 1,
		GettingUp = 2,
		RunningAway = 3,
		ClimbingStairs = 4,
		Done = 5
	}

	public AsciiAnimation gettingUpAnm;

	public AsciiAnimation runningAnm;

	public AsciiAnimation climbingStairsAnm;

	public int DelayTics = 300;

	private int gettingUpTics = 45;

	private int climbingStairsTics = 78;

	private State currentState;

	private int stateElapsedTics;

	private Nagaraja nagaraja;

	private float runX;

	private float runZ;

	private float offsetCenterX = 10.5f;

	private float offsetCenterZ = -1f;

	private float pitRadius = 12f;

	private float elipseFactor = 3f;

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.GettingUp:
		{
			base.MySprite = gettingUpAnm.Sprite;
			gettingUpAnm.Play();
			Character3DLoopSfx component = GetComponent<Character3DLoopSfx>();
			if (component != null && component.sfxLoop != null)
			{
				component.sfxLoop.Stop();
			}
			break;
		}
		case State.RunningAway:
			base.MySprite = runningAnm.Sprite;
			runningAnm.Play();
			runX = base.PositionX;
			runZ = base.PositionZ;
			break;
		case State.ClimbingStairs:
			base.MySprite = climbingStairsAnm.Sprite;
			break;
		case State.Done:
			base.Die(DeathReason.DecorationCleanup);
			break;
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		stateElapsedTics++;
		if (currentState == State.Praying)
		{
			if (nagaraja == null)
			{
				nagaraja = GameStates.Singleton.level.GetCharacterWithId("nagaraja") as Nagaraja;
			}
			if (nagaraja != null && nagaraja.CurrentState == Enemy.State.WakingUp)
			{
				SetState(State.Delay);
			}
		}
		else if (currentState == State.Delay && stateElapsedTics >= DelayTics)
		{
			SetState(State.GettingUp);
		}
		else if (currentState == State.GettingUp && stateElapsedTics >= gettingUpTics)
		{
			SetState(State.RunningAway);
		}
		else if (currentState == State.RunningAway)
		{
			float num = (float)nagaraja.PositionX + 24f;
			float num2 = (float)nagaraja.PositionZ + 1f;
			float num3 = num - runX;
			float num4 = num2 - runZ;
			if (num3 < 0.5f && num3 > -0.5f && num4 < 0.25f && num4 > -0.25f)
			{
				SetState(State.ClimbingStairs);
				return;
			}
			float num5 = (float)nagaraja.PositionX + offsetCenterX;
			float num6 = (float)nagaraja.PositionZ + offsetCenterZ;
			Vector2 vector = new Vector2(num3, num4);
			if (runX < num5 && runZ > num6 && runZ < num6 + 4f)
			{
				vector.y += 5f;
			}
			else if (runX < num5 && runZ < num6 && runZ > num6 - 6f)
			{
				vector.y -= 5f;
			}
			vector.Normalize();
			float num7 = runX + vector.x * 0.3f;
			float num8 = runZ + vector.y * 0.3f * 0.5f;
			vector = new Vector2(num7 - num5, (num8 - num6) * elipseFactor);
			float magnitude = vector.magnitude;
			float num9 = pitRadius - magnitude;
			if (num9 > 0f)
			{
				vector = vector * num9 / magnitude;
				vector.y /= elipseFactor;
				num7 += vector.x;
				num8 += vector.y;
			}
			runX = num7;
			runZ = num8;
			base.PositionX = Mathf.RoundToInt(num7);
			base.PositionZ = Mathf.RoundToInt(num8);
		}
		else if (currentState == State.ClimbingStairs)
		{
			if (stateElapsedTics >= climbingStairsTics)
			{
				SetState(State.Done);
			}
			else if (stateElapsedTics % 18 == 0)
			{
				base.PositionX += 3;
				base.PositionZ++;
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentState == State.ClimbingStairs)
		{
			int frameIndex = stateElapsedTics / 3 % 6;
			base.MySprite.SetFrameIndex(frameIndex);
		}
		base.Draw(r, offsetX, offsetY);
	}
}

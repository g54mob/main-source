using UnityEngine;

public class BronzeMineSlave : Decoration
{
	private enum State
	{
		Normal = 0,
		Celebrating = 1,
		Afraid = 2,
		TonguePre = 3,
		Tongue = 4
	}

	public int ticsPerMove = 40;

	public int wrapAroundX = 100;

	public bool wrapsAround = true;

	public int cheerDistance = 23;

	public AsciiSprite[] celebratingSprites;

	public AsciiSprite afraidSprite;

	public AsciiAnimation tongueAnimation;

	private State currentState;

	private int elapsedTics;

	private AsciiSprite defaultSprite;

	private int tremorCount;

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.Normal:
			base.MySprite = defaultSprite;
			break;
		case State.Celebrating:
		{
			int num = Random.Range(0, celebratingSprites.Length);
			base.MySprite = celebratingSprites[num];
			break;
		}
		case State.Afraid:
			base.MySprite = afraidSprite;
			break;
		case State.Tongue:
			tongueAnimation.Play();
			base.MySprite = tongueAnimation.Sprite;
			break;
		}
		currentState = newState;
		elapsedTics = 0;
		tremorCount = 0;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		elapsedTics++;
		if (currentState == State.Normal && BronzeMineTremor.activeInstance != null && BronzeMineTremor.activeInstance.isActive && base.PositionX - GameStates.Singleton.level.gameCamera.PositionX <= 30)
		{
			tremorCount++;
			if (tremorCount >= 30)
			{
				if (BronzeMineTremor.activeInstance.hasTongue && base.PositionZ < 12)
				{
					SetState(State.Tongue);
				}
				else
				{
					SetState(State.Afraid);
				}
			}
		}
		if (currentState == State.Normal && elapsedTics >= ticsPerMove)
		{
			elapsedTics = 0;
			base.PositionX--;
		}
		if (currentState == State.TonguePre && elapsedTics > 30)
		{
			SetState(State.Tongue);
		}
		if (wrapsAround && base.MySprite.lastDrawX + base.MySprite.width < 0)
		{
			base.PositionX += GameStates.Singleton.asciiRenderer.width + base.MySprite.width;
			SetState(State.Normal);
		}
	}

	public override void Die(DeathReason reason)
	{
		if (wrapsAround)
		{
			base.PositionX += wrapAroundX;
			SetState(State.Normal);
		}
		else
		{
			base.Die(reason);
		}
	}

	protected override void Start()
	{
		base.Start();
		defaultSprite = base.MySprite;
		Character.OnCharacterDied += HandleOnCharacterDied;
	}

	private void OnDestroy()
	{
		Character.OnCharacterDied -= HandleOnCharacterDied;
	}

	private void HandleOnCharacterDied(Character character, DeathReason reason, Damage damage)
	{
		if (Mathf.Abs(character.PositionX - base.PositionX) <= cheerDistance && character.id == "slave_master")
		{
			SetState(State.Celebrating);
		}
	}
}

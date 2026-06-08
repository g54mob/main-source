using System;
using UnityEngine;

public class GameCamera
{
	public enum State
	{
		RelativeToHero = 0,
		SpecificPos = 1
	}

	public int defaultZ = 13;

	public float playLerpSpeed = 0.15f;

	public int PositionX;

	public int PositionY;

	public int PositionZ;

	public int LimitLeft;

	public int LimitRight;

	private State currentState;

	private float fPosX;

	private float fPosY;

	private float fPosZ;

	private int heroLeadX;

	private int additionalOffsetX;

	private Data.Quest quest;

	private float minMovX = 0.3f;

	private float minMovY = 0.3f;

	private int lastLimitSection;

	public State CurrentState
	{
		get
		{
			return currentState;
		}
		set
		{
			currentState = value;
		}
	}

	public float lerpDestX { get; set; }

	public float lerpDestY { get; set; }

	public float lerpDestZ { get; set; }

	public float lerpSpeed { get; set; }

	public int shakeOffsetX { get; set; }

	public event Action<GameCamera> OnPosChanged;

	public void Reset()
	{
		PositionX = 0;
		PositionY = 0;
		PositionZ = 0;
		fPosX = 0f;
		fPosY = 0f;
		fPosZ = 0f;
		lerpDestX = 0f;
		lerpDestY = 0f;
		lerpDestZ = 0f;
		lerpSpeed = 0f;
		shakeOffsetX = 0;
	}

	public void SetState(State newState)
	{
		if (newState == State.RelativeToHero)
		{
			SetupLerpRelativeToPlayer();
			lerpSpeed = playLerpSpeed;
		}
		currentState = newState;
	}

	public void UpdateTic()
	{
		fPosX = CustomLerp(fPosX, lerpDestX + (float)additionalOffsetX, minMovX);
		fPosY = CustomLerp(fPosY, lerpDestY, minMovY);
		fPosZ = Mathf.Lerp(fPosZ, lerpDestZ, lerpSpeed);
		ComputePos();
	}

	private float CustomLerp(float currentValue, float targetValue, float minMove)
	{
		float num = Mathf.Lerp(currentValue, targetValue, lerpSpeed);
		float num2 = num - currentValue;
		if (num2 > 0f && num2 < minMove)
		{
			num = Mathf.Min(targetValue, currentValue + minMove);
		}
		else if (num2 < 0f && num2 > 0f - minMove)
		{
			num = Mathf.Max(targetValue, currentValue - minMove);
		}
		return num;
	}

	public void JumpToDestination()
	{
		fPosX = lerpDestX;
		fPosY = lerpDestY;
		fPosZ = lerpDestZ;
		ComputePos();
	}

	private void ComputePos()
	{
		PositionX = (int)fPosX;
		PositionY = (int)fPosY;
		PositionZ = (int)fPosZ;
		if (currentState == State.RelativeToHero)
		{
			Hero hero = GameStates.Singleton.hero;
			PositionX += hero.PositionX;
			PositionY += hero.PositionY;
			PositionZ += defaultZ;
		}
		ComputeLimitRightIfNeeded();
		if (PositionX > LimitRight)
		{
			PositionX = LimitRight;
			fPosX = PositionX;
		}
		PositionX = Mathf.Max(LimitLeft, PositionX);
		PositionX += shakeOffsetX;
		if (this.OnPosChanged != null)
		{
			this.OnPosChanged(this);
		}
	}

	private void SetupLerpRelativeToPlayer()
	{
		lerpDestX = heroLeadX;
		lerpDestY = 0f;
		lerpDestZ = 0f;
		Hero hero = GameStates.Singleton.hero;
		fPosX = PositionX - hero.PositionX;
		fPosY = PositionY - hero.PositionY;
		fPosZ = PositionZ - defaultZ;
	}

	public void SetupLerpToPos(int destinationX, int destinationY, int destinationZ, float speed)
	{
		lerpDestX = destinationX;
		lerpDestY = destinationY;
		lerpDestZ = destinationZ;
		lerpSpeed = speed;
		if (currentState == State.RelativeToHero)
		{
			Hero hero = GameStates.Singleton.hero;
			fPosX += hero.PositionX;
			fPosY += hero.PositionY;
			fPosZ += defaultZ;
		}
		SetState(State.SpecificPos);
	}

	public void PrepareForQuest(Data.Quest quest)
	{
		this.quest = quest;
		LimitLeft = 0;
		ComputeLimitRight();
		if (quest.sections != null)
		{
			lerpDestX = 0f;
			lerpDestY = 0f;
			lerpDestZ = 13f;
			SetState(State.SpecificPos);
		}
		else
		{
			ComputeHeroLead();
			SetState(State.RelativeToHero);
		}
		JumpToDestination();
	}

	private void ComputeLimitRight()
	{
		lastLimitSection = quest.cameraLimitSection;
		LimitRight = quest.cameraLimitX;
		if (quest.sections != null && quest.sections.Length != 0 && quest.cameraLimitSection < int.MaxValue)
		{
			LimitRight = Mathf.Min(LimitRight, 69 * quest.cameraLimitSection);
		}
	}

	private void ComputeLimitRightIfNeeded()
	{
		if (lastLimitSection != quest.cameraLimitSection)
		{
			ComputeLimitRight();
		}
	}

	private void ComputeHeroLead()
	{
		if (quest.safe)
		{
			heroLeadX = 2;
		}
		else
		{
			heroLeadX = 4 + GameStates.Singleton.hero.ComputeMaxWeaponRange() * 2 / 3;
		}
	}
}

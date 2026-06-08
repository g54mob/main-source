using System;
using UnityEngine;

[RequireComponent(typeof(Decoration))]
public class BronzeMineTremor : MonoBehaviour
{
	public static BronzeMineTremor activeInstance;

	public float chanceOfTremor = 1f;

	public float chanceOfTongue;

	public int distanceToHeroEnabled = 20;

	public float initialDelay;

	public float duration = 3f;

	public float minPeriod = 0.5f;

	public float peakPeriod = 0.15f;

	public Decoration fallingParticlePrefab;

	private float elapsedTime;

	private float periodRemainingTime;

	private bool isOffset = true;

	private Decoration myDecoration;

	private bool hasTremor = true;

	public bool isActive { get; private set; }

	public bool hasTongue { get; private set; }

	private void Update()
	{
		if (!isActive && hasTremor && myDecoration.PositionX - GameStates.Singleton.hero.PositionX <= distanceToHeroEnabled)
		{
			isActive = true;
			activeInstance = this;
		}
		if (!isActive)
		{
			return;
		}
		elapsedTime += Time.deltaTime;
		if (elapsedTime - initialDelay > duration)
		{
			isActive = false;
			Cleanup();
		}
		else
		{
			if (!(elapsedTime > initialDelay))
			{
				return;
			}
			periodRemainingTime += Time.deltaTime;
			if (periodRemainingTime >= EvalPeriod())
			{
				periodRemainingTime = 0f;
				isOffset = !isOffset;
			}
			int num = (isOffset ? 1 : 0);
			if (GameStates.Singleton.level.gameCamera.shakeOffsetX != num)
			{
				GameStates.Singleton.level.gameCamera.shakeOffsetX = num;
				if (isOffset)
				{
					SpawnParticle();
				}
			}
		}
	}

	private void Cleanup()
	{
		if (activeInstance == this)
		{
			activeInstance = null;
			GameStates.Singleton.level.gameCamera.shakeOffsetX = 0;
		}
	}

	private float EvalPeriod()
	{
		float t = -0.5f * Mathf.Cos((elapsedTime - initialDelay) / duration * MathF.PI * 2f) + 0.5f;
		return Mathf.Lerp(minPeriod, peakPeriod, t);
	}

	private void SpawnParticle()
	{
		Character character = UnityEngine.Object.Instantiate(fallingParticlePrefab);
		character.PositionX = myDecoration.PositionX + UnityEngine.Random.Range(-30, 30);
		character.PositionY = myDecoration.PositionY;
		character.PositionZ = myDecoration.PositionZ + UnityEngine.Random.Range(-4, 5);
		GameStates.Singleton.level.AddCharacter(character);
	}

	private void Awake()
	{
		hasTremor = UnityEngine.Random.Range(0f, 1f) < chanceOfTremor;
		if (hasTremor)
		{
			hasTongue = UnityEngine.Random.Range(0f, 1f) < chanceOfTongue;
			myDecoration = GetComponent<Decoration>();
		}
	}

	private void OnDestroy()
	{
		Cleanup();
	}
}

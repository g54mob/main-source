using System;
using UnityEngine;

public class ReturningSoulstonesSprite : AsciiSprite
{
	private const int NUMBER_OF_STONES = 9;

	public Vector2 start;

	public Vector2 target;

	public float startSpeed = 1f;

	public float verticalScale = 2f;

	public float drag = 0.98f;

	public float initialDelay = 1f;

	public float growTime = 3f;

	public float accelerationToTarget = 0.2f;

	public float deactivationThreshold = 1f;

	public bool reset;

	private Vector2[] positions = new Vector2[9];

	private Vector2[] velocities = new Vector2[9];

	private bool[] isActive = new bool[9];

	private bool isPlaying;

	private float elapsedTime;

	private int stoneSymbol;

	private Color starstoneColor;

	private Color ouroborosColor;

	private int numStones;

	private const float timePerTic = 0.015f;

	private float accumulatedTicTime;

	public void Reset()
	{
		numStones = 9;
		if ((bool)Inventory.Singleton && !Inventory.Singleton.HasItemById("moon_stone"))
		{
			numStones--;
		}
		for (int i = 0; i < positions.Length; i++)
		{
			positions[i] = start;
			float f = MathF.PI * 2f * (float)i / (float)numStones;
			velocities[i] = startSpeed * new Vector2(Mathf.Cos(f), Mathf.Sin(f));
			isActive[i] = true;
		}
		elapsedTime = 0f;
		stoneSymbol = SpecialSymbols.Map('ʘ');
		starstoneColor = ColorConstants.white;
		if (StarStoneWeapon.singleton != null)
		{
			int level = StarStoneWeapon.singleton.level;
			if (level > 1)
			{
				starstoneColor = UpgradeRelicScreen.GetColorForLevel(level);
			}
		}
		ouroborosColor = ColorConstants.white;
		if (OuroborosWeapon.singleton != null)
		{
			int level2 = OuroborosWeapon.singleton.level;
			if (level2 > 1)
			{
				ouroborosColor = UpgradeRelicScreen.GetColorForLevel(level2);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		Draw(r, offsetX, offsetY, 1f, ColorConstants.white);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply, Color tint)
	{
		isPlaying = true;
		if (elapsedTime < initialDelay)
		{
			return;
		}
		for (int i = 0; i < numStones; i++)
		{
			if (isActive[i])
			{
				Vector2 vector = positions[i];
				int x = Mathf.RoundToInt(vector.x) - pivotX + offsetX;
				int y = Mathf.RoundToInt(vector.y / verticalScale) - pivotY + offsetY;
				Color white = ColorConstants.white;
				switch (i)
				{
				case 0:
					white = starstoneColor;
					break;
				case 3:
					white = ouroborosColor;
					break;
				}
				r.SetCell(x, y, stoneSymbol, white);
			}
		}
	}

	private new void UpdateTic()
	{
		elapsedTime += 0.015f;
		if (elapsedTime < initialDelay)
		{
			return;
		}
		for (int i = 0; i < numStones; i++)
		{
			if (!isActive[i])
			{
				continue;
			}
			Vector2 vector = positions[i];
			Vector2 vector2 = velocities[i];
			vector += vector2;
			if (elapsedTime >= initialDelay + growTime)
			{
				Vector2 vector3 = target - vector;
				if (vector3.sqrMagnitude <= deactivationThreshold)
				{
					isActive[i] = false;
				}
				Vector2 vector4 = vector3.normalized * accelerationToTarget;
				vector2 += vector4;
			}
			vector2 *= drag;
			positions[i] = vector;
			velocities[i] = vector2;
		}
	}

	private void Update()
	{
		if (isPlaying && !AsciiAnimation.gameplayPaused)
		{
			if (reset)
			{
				reset = false;
				Reset();
			}
			UpdateTics(Time.deltaTime);
		}
	}

	private void UpdateTics(float deltaTime)
	{
		accumulatedTicTime += deltaTime;
		while (accumulatedTicTime >= 0.015f)
		{
			accumulatedTicTime -= 0.015f;
			UpdateTic();
		}
	}

	public override void Load()
	{
	}

	private void Start()
	{
		Reset();
	}
}

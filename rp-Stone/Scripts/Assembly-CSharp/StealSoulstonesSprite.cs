using UnityEngine;

public class StealSoulstonesSprite : AsciiSprite
{
	private const int NUMBER_OF_STONES = 9;

	public Vector2 start;

	public Vector2 center;

	public Vector2 startVelocity;

	public float gravity = 1f;

	public float drag = 0.98f;

	public float verticalScale = 2f;

	public float initialDelay = 2f;

	public int delayBetweenStones = 5;

	public float initialDrag = 0.994f;

	public float growDrag = 1.01f;

	public float shrinkDrag = 0.95f;

	public float growTime = 4f;

	public float shrinkTime = 6f;

	public bool reset;

	private Vector2[] positions = new Vector2[9];

	private Vector2[] velocities = new Vector2[9];

	private int[] delay = new int[9];

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
		for (int i = 0; i < positions.Length; i++)
		{
			positions[i] = start;
			velocities[i] = startVelocity;
			delay[i] = i * delayBetweenStones;
		}
		elapsedTime = 0f;
		drag = initialDrag;
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
		numStones = 9;
		if ((bool)Inventory.Singleton && !Inventory.Singleton.HasItemById("moon_stone"))
		{
			numStones--;
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
			if (delay[i] <= 0)
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
		if (elapsedTime >= shrinkTime + initialDelay)
		{
			drag = shrinkDrag;
		}
		else if (elapsedTime >= growTime + initialDelay)
		{
			drag = growDrag;
		}
		else
		{
			drag = initialDrag;
		}
		for (int i = 0; i < numStones; i++)
		{
			if (delay[i] > 0)
			{
				delay[i]--;
				continue;
			}
			Vector2 vector = positions[i];
			Vector2 vector2 = velocities[i];
			Vector2 vector3 = (center - vector).normalized * gravity;
			vector += vector2;
			vector2 += vector3;
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

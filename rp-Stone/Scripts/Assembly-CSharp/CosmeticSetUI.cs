using UnityEngine;

public class CosmeticSetUI : MonoBehaviour
{
	public enum State
	{
		InitialDelay = 0,
		ShrinkingCircle = 1,
		FadeFromWhiteRequirement = 2,
		PrepareReward = 3,
		OrbitingReward = 4,
		FadeFromWhiteReward = 5,
		Done = 6
	}

	public AsciiString title;

	public GrowingRingSprite growingRing;

	private int largeBoxStyle;

	private CosmeticController.SetUnlock unlockData;

	private AsciiSprite[] icons;

	private string rewardName;

	private Color defaultTitleColor;

	private Color defaultIconColor;

	private int stateElapsedTics;

	private int targetIndex;

	private float stateRealStartTime;

	public Vector2 startVelocity;

	public Vector2 centerStartVelocity;

	public int delayBetween = 5;

	public float centerDrag = 0.95f;

	public float gravity = 1f;

	public float drag = 0.98f;

	public float initialDrag = 0.994f;

	public float growDrag = 1.01f;

	public float shrinkDrag = 0.95f;

	public float growTime = 4f;

	public float shrinkTime = 6f;

	public float verticalScale = 2f;

	public float centerLerp = 4f;

	public float orbitDuration = 8f;

	private Vector2 centerPosition;

	private Vector2 centerVelocity;

	private Vector2[] positions;

	private Vector2[] velocities;

	private int[] delay;

	private float elapsedOrbitTime;

	private const int iconDistanceX = 8;

	private const int largeBoxW = 7;

	private const int largeBoxH = 5;

	public State currentState { get; private set; }

	public State previousState { get; private set; }

	public void Setup(CosmeticController.SetUnlock setUnlockData)
	{
		unlockData = setUnlockData;
		SetState(State.InitialDelay);
		Cosmetic cosmeticPrefab = CosmeticController.singleton.GetCosmeticPrefab(setUnlockData.collectionId);
		icons = new AsciiSprite[unlockData.requirements.Length + 1];
		for (int i = 0; i < unlockData.requirements.Length; i++)
		{
			CosmeticController.ItemEntry itemEntry = unlockData.requirements[i];
			Item prefabForId = ItemFactory.singleton.GetPrefabForId(itemEntry.itemId);
			ItemData.Element element = prefabForId.element;
			prefabForId.element = itemEntry.element;
			icons[i] = cosmeticPrefab.GetCosmeticIcon(prefabForId);
			prefabForId.element = element;
		}
		Item prefabForId2 = ItemFactory.singleton.GetPrefabForId(unlockData.rewardId);
		AsciiSprite cosmeticIcon = cosmeticPrefab.GetCosmeticIcon(prefabForId2);
		icons[icons.Length - 1] = cosmeticIcon;
		defaultIconColor = cosmeticIcon.colorOverride;
		for (int j = 0; j < icons.Length; j++)
		{
			if (!unlockData.ownership[j] && !unlockData.unlockPending[j])
			{
				AsciiSprite asciiSprite = icons[j];
				asciiSprite.colorOverride = defaultIconColor * 0.25f;
				DisableSpriteRenderingProperties(asciiSprite);
			}
		}
		rewardName = prefabForId2.GetName();
		title.SetValue(string.Format(Te.xt("Set: {0}"), rewardName));
		title.color = cosmeticPrefab.GetLabelColor();
	}

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.InitialDelay:
			growingRing.gameObject.SetActive(value: false);
			GameStates.Singleton.HideMouse();
			SfxController.singleton.Preload("blade_glow");
			SfxController.singleton.Preload("ui_bell_ring");
			SfxController.singleton.Preload("bearer_stealing");
			break;
		case State.ShrinkingCircle:
			growingRing.gameObject.SetActive(value: true);
			SfxController.singleton.Play("blade_glow");
			break;
		case State.FadeFromWhiteRequirement:
			growingRing.gameObject.SetActive(value: false);
			SfxController.singleton.Play("ui_bell_ring");
			break;
		case State.PrepareReward:
			Hud.Disable(Hud.Flag.RESOURCES);
			SfxController.singleton.Play("bearer_stealing");
			break;
		case State.OrbitingReward:
		{
			elapsedOrbitTime = 0f;
			positions = new Vector2[icons.Length - 1];
			velocities = new Vector2[icons.Length - 1];
			delay = new int[icons.Length - 1];
			for (int i = 0; i < icons.Length - 1; i++)
			{
				AsciiSprite asciiSprite = icons[i];
				positions[i] = new Vector2(asciiSprite.lastDrawX + asciiSprite.pivotX, (float)(asciiSprite.lastDrawY + asciiSprite.pivotY) * verticalScale);
				velocities[i] = startVelocity;
				delay[i] = (icons.Length - 1 - i) * delayBetween;
			}
			centerPosition = default(Vector2);
			centerPosition.x = positions[positions.Length - 1].x + 8f + 1f;
			centerPosition.y = positions[positions.Length - 1].y;
			centerVelocity = centerStartVelocity;
			break;
		}
		case State.FadeFromWhiteReward:
			title.SetValue(unlockData.rewardName);
			break;
		case State.Done:
			GameStates.Singleton.ShowMouse();
			break;
		}
		previousState = currentState;
		currentState = newState;
		stateElapsedTics = 0;
		stateRealStartTime = Time.realtimeSinceStartup;
	}

	public void Hide()
	{
		Hud.Enable(Hud.Flag.RESOURCES);
		GameStates.Singleton.ShowMouse();
		for (int i = 0; i < icons.Length; i++)
		{
			RestoreSpriteRenderingProperties(icons[i]);
		}
	}

	private void DisableSpriteRenderingProperties(AsciiSprite sprite)
	{
		AsciiSpritePPShiny component = sprite.GetComponent<AsciiSpritePPShiny>();
		if (component != null)
		{
			component.SetEffectEnabled(value: false);
		}
		AsciiSpritePPPrismatic component2 = sprite.GetComponent<AsciiSpritePPPrismatic>();
		if (component2 != null)
		{
			component2.SetEffectEnabled(value: false);
		}
	}

	private void RestoreSpriteRenderingProperties(AsciiSprite sprite)
	{
		sprite.colorOverride = defaultIconColor;
		AsciiSpritePPShiny component = sprite.GetComponent<AsciiSpritePPShiny>();
		if (component != null)
		{
			component.SetEffectEnabled(value: true);
		}
		AsciiSpritePPPrismatic component2 = sprite.GetComponent<AsciiSpritePPPrismatic>();
		if (component2 != null)
		{
			component2.SetEffectEnabled(value: true);
		}
	}

	private void Next()
	{
		if (unlockData.unlockIndexes.Count == 0)
		{
			if (unlockData.unlockReward)
			{
				SetState(State.PrepareReward);
			}
			else
			{
				SetState(State.Done);
			}
		}
		else
		{
			targetIndex = unlockData.unlockIndexes[0];
			unlockData.unlockIndexes.RemoveAt(0);
			SetState(State.ShrinkingCircle);
		}
	}

	public void UpdateTic()
	{
		stateElapsedTics++;
		if (currentState == State.InitialDelay)
		{
			if (stateElapsedTics >= 20 || AsciiMouse.singleton.down0)
			{
				Next();
			}
		}
		else if (currentState == State.ShrinkingCircle)
		{
			if (stateElapsedTics >= 14 || AsciiMouse.singleton.down0)
			{
				unlockData.ownership[targetIndex] = true;
				unlockData.unlockPending[targetIndex] = false;
				RestoreSpriteRenderingProperties(icons[targetIndex]);
				SetState(State.FadeFromWhiteRequirement);
			}
		}
		else if (currentState == State.FadeFromWhiteRequirement)
		{
			if (stateElapsedTics >= 45 || AsciiMouse.singleton.down0)
			{
				Next();
			}
		}
		else if (currentState == State.PrepareReward)
		{
			if (stateElapsedTics >= 20)
			{
				SetState(State.OrbitingReward);
			}
		}
		else if (currentState == State.OrbitingReward)
		{
			if ((float)stateElapsedTics >= 30f * orbitDuration)
			{
				SetState(State.FadeFromWhiteReward);
			}
		}
		else if (currentState == State.FadeFromWhiteReward && stateElapsedTics >= 62)
		{
			SetState(State.Done);
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentState == State.OrbitingReward)
		{
			DrawOrbitingRewardState(r);
			return;
		}
		if (currentState == State.FadeFromWhiteReward)
		{
			DrawFadeFromWhiteRewardState(r);
			return;
		}
		if (currentState == State.Done && previousState == State.FadeFromWhiteReward)
		{
			DrawRewardDoneState(r);
			return;
		}
		int num = unlockData.requirements.Length + 1;
		int num2 = (num - 1) * 8 + 7;
		float t = 0f;
		Color color = defaultTitleColor;
		if (currentState == State.PrepareReward)
		{
			t = Mathf.Clamp01((Time.realtimeSinceStartup - stateRealStartTime) / 0.6667f);
			color = Color.Lerp(color, ColorConstants.black, t);
		}
		title.Draw(r, offsetX, offsetY, color);
		Color color2 = ColorConstants.darkGrey;
		if (currentState == State.PrepareReward)
		{
			color2 = Color.Lerp(color2, ColorConstants.black, t);
		}
		offsetX -= num2 >> 1;
		BoxDrawing.Command command = default(BoxDrawing.Command);
		BoxDrawing.Command command2 = new BoxDrawing.Command(0, 0, 5, 3, color2, 1);
		command2.y = offsetY - 1;
		int value = 43;
		for (int i = 0; i < num; i++)
		{
			command2.x = offsetX;
			if (i == num - 1)
			{
				command2.style = largeBoxStyle;
				command2.w = 7;
				command2.h = 5;
				command2.y = offsetY - 2;
				command2.color = ColorConstants.darkGrey;
				value = 61;
			}
			if (i > 0)
			{
				r.SetCell(command2.x - 2, offsetY, value, color2);
			}
			if (i == targetIndex)
			{
				command = command2;
			}
			BoxDrawing.Draw(r, command2);
			if (!unlockData.unlockPending[i])
			{
				icons[i].Draw(r, offsetX + (command2.w >> 1), offsetY);
			}
			offsetX += 8;
		}
		if (currentState == State.ShrinkingCircle)
		{
			offsetX = command.x + (command.w >> 1);
			growingRing.Draw(r, offsetX, offsetY);
		}
		else
		{
			if (currentState != State.FadeFromWhiteRequirement)
			{
				return;
			}
			bool flag = unlockData.unlockIndexes.Count == 0 && !unlockData.unlockReward;
			if (stateElapsedTics == 0 && AdditionalSettings.isScreenFlash && flag)
			{
				for (int j = 0; j < r.width; j++)
				{
					for (int k = 0; k < r.height; k++)
					{
						AsciiCellProcedural cell = r.GetCell(j, k);
						Color background = cell.GetBackground();
						cell.SetBackground(Color.white);
						cell.SetForeground(background);
					}
				}
				return;
			}
			for (int l = command.x; l < command.x + command.w; l++)
			{
				for (int m = command.y; m < command.y + command.h; m++)
				{
					AsciiCellProcedural cell2 = r.GetCell(l, m);
					if (cell2 != null)
					{
						t = ((!flag) ? Mathf.Clamp01((Time.realtimeSinceStartup - stateRealStartTime - 0.2f) / 1.3f) : Mathf.Clamp01((Time.realtimeSinceStartup - stateRealStartTime - 0.5f) / 1f));
						cell2.foregroundColor = Color.Lerp(ColorConstants.white, cell2.foregroundColor, t);
						cell2.backgroundColor = Color.Lerp(ColorConstants.white, ColorConstants.black, t);
					}
				}
			}
		}
	}

	private void DrawOrbitingRewardState(AsciiRenderProcedural r)
	{
		int x = Mathf.RoundToInt(centerPosition.x) - 3;
		int y = Mathf.RoundToInt(centerPosition.y / verticalScale) - 2;
		BoxDrawing.Command command = new BoxDrawing.Command(x, y, 7, 5, ColorConstants.darkGrey, largeBoxStyle);
		BoxDrawing.Draw(r, command);
		for (int i = 0; i < positions.Length; i++)
		{
			Vector2 vector = positions[i];
			x = Mathf.RoundToInt(vector.x);
			y = Mathf.RoundToInt(vector.y / verticalScale);
			icons[i].Draw(r, x, y);
		}
	}

	private void DrawFadeFromWhiteRewardState(AsciiRenderProcedural r)
	{
		int i;
		int j;
		if (stateElapsedTics == 0 && AdditionalSettings.isScreenFlash)
		{
			for (i = 0; i < r.width; i++)
			{
				for (j = 0; j < r.height; j++)
				{
					AsciiCellProcedural cell = r.GetCell(i, j);
					cell.SetBackground(Color.white);
					cell.SetForeground(Color.white);
				}
			}
			return;
		}
		i = Mathf.RoundToInt(centerPosition.x);
		j = Mathf.RoundToInt(centerPosition.y / verticalScale);
		BoxDrawing.Command command = new BoxDrawing.Command(i - 3, j - 2, 7, 5, ColorConstants.darkGrey, largeBoxStyle);
		BoxDrawing.Draw(r, command);
		if (stateRealStartTime > 1.5f)
		{
			float t = Mathf.Clamp01((Time.realtimeSinceStartup - stateRealStartTime - 1.5f) * 2f);
			Color colorOverride = Color.Lerp(ColorConstants.black, title.color, t);
			title.Draw(r, i, j - 2, colorOverride);
		}
		icons[icons.Length - 1].Draw(r, i, j);
		for (i = command.x - 1; i < command.x + command.w + 1; i++)
		{
			for (j = command.y; j < command.y + command.h; j++)
			{
				AsciiCellProcedural cell2 = r.GetCell(i, j);
				if (cell2 != null)
				{
					float t2 = Mathf.Clamp01((Time.realtimeSinceStartup - stateRealStartTime - 0.5f) / 1f);
					cell2.foregroundColor = Color.Lerp(ColorConstants.white, cell2.foregroundColor, t2);
					cell2.backgroundColor = Color.Lerp(ColorConstants.white, ColorConstants.black, t2);
				}
			}
		}
	}

	private void DrawRewardDoneState(AsciiRenderProcedural r)
	{
		int num = Mathf.RoundToInt(centerPosition.x);
		int num2 = Mathf.RoundToInt(centerPosition.y / verticalScale);
		BoxDrawing.Command command = new BoxDrawing.Command(num - 3, num2 - 2, 7, 5, ColorConstants.darkGrey, largeBoxStyle);
		BoxDrawing.Draw(r, command);
		title.Draw(r, num, num2 - 2);
		icons[icons.Length - 1].Draw(r, num, num2);
	}

	private void FixedUpdate()
	{
		if (currentState != State.OrbitingReward)
		{
			return;
		}
		elapsedOrbitTime += Time.fixedDeltaTime;
		if (elapsedOrbitTime >= shrinkTime)
		{
			drag = shrinkDrag;
		}
		else if (elapsedOrbitTime >= growTime)
		{
			drag = growDrag;
		}
		else
		{
			drag = initialDrag;
		}
		for (int i = 0; i < positions.Length; i++)
		{
			if (delay[i] > 0)
			{
				delay[i]--;
				continue;
			}
			Vector2 vector = positions[i];
			Vector2 vector2 = velocities[i];
			Vector2 vector3 = (centerPosition - vector).normalized * gravity;
			vector += vector2;
			vector2 += vector3;
			vector2 *= drag;
			positions[i] = vector;
			velocities[i] = vector2;
		}
		float t = Time.fixedDeltaTime * centerLerp;
		AsciiRenderProcedural asciiRenderer = GameStates.Singleton.asciiRenderer;
		float b = asciiRenderer.width / 2;
		float b2 = asciiRenderer.height;
		centerPosition += centerVelocity;
		centerVelocity *= centerDrag;
		centerPosition.x = Mathf.Lerp(centerPosition.x, b, t);
		centerPosition.y = Mathf.Lerp(centerPosition.y, b2, t);
	}

	private void Awake()
	{
		defaultTitleColor = title.color;
		largeBoxStyle = BoxDrawing.AddStyle(new char[14]
		{
			' ', '_', ' ', '│', ' ', '│', ' ', '‾', ' ', '┼',
			'├', '┤', '│', '│'
		});
	}
}

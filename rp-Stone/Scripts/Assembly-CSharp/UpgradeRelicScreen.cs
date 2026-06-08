using UnityEngine;

public abstract class UpgradeRelicScreen : MonoBehaviour
{
	public enum State
	{
		Painting = 0,
		TrailerMagicTransitionDelay = 1,
		MagicTransition = 2,
		Done = 3
	}

	public AsciiSprite background;

	public AsciiSprite foreground;

	public AsciiAnimation transitionAnimation;

	public AsciiParticleEmitter splatterEmitter;

	public int magicOffsetX;

	public int magicOffsetY;

	public int magicTransitionDuration = 45;

	private int stateElapsedTics;

	private bool[,] paintData;

	private bool paintingComplete;

	private int dataWidth;

	private int dataHeight;

	private Color previousRarityColor = Color.white;

	public static Color selectedRarityColor = Color.white;

	public State currentState { get; private set; }

	protected abstract Item GetRelic();

	public void Activate()
	{
		foreground.Load();
		AsciiData.Page currentPage = foreground.GetCurrentPage();
		dataWidth = currentPage.width;
		dataHeight = currentPage.height;
		paintData = new bool[dataWidth, dataHeight];
		Item relic = GetRelic();
		if (relic != null)
		{
			selectedRarityColor = GetColorForLevel(relic.level + 1);
			previousRarityColor = GetColorForLevel(relic.level);
		}
		SetState(State.Painting);
	}

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.Painting:
			GameStates.Singleton.asciiRenderer.defaultForegroundColor = selectedRarityColor;
			break;
		case State.TrailerMagicTransitionDelay:
			GameStates.Singleton.HideMouse();
			break;
		case State.MagicTransition:
			transitionAnimation.Stop();
			transitionAnimation.Play();
			GameStates.Singleton.HideMouse();
			MusicController.singleton.FadeToSilence();
			SfxController.singleton.Play("soul_stone");
			break;
		case State.Done:
			GameStates.Singleton.asciiRenderer.defaultForegroundColor = ColorConstants.white;
			GameStates.Singleton.ShowMouse();
			break;
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	public void UpdateTic()
	{
		stateElapsedTics++;
		if (currentState == State.Painting)
		{
			if (AsciiMouse.singleton.down0)
			{
				EmitSplatter(AsciiMouse.singleton.x, AsciiMouse.singleton.y);
			}
			if (paintingComplete && !AsciiMouse.singleton.isDown0)
			{
				SetState(State.MagicTransition);
			}
			else
			{
				if (stateElapsedTics < 10 || !AsciiMouse.singleton.isDown0)
				{
					return;
				}
				int num = AsciiMouse.singleton.x - GameStates.Singleton.asciiRenderer.width / 2 + foreground.pivotX;
				int num2 = AsciiMouse.singleton.y - GameStates.Singleton.asciiRenderer.height / 2 + foreground.pivotY;
				for (int i = num - 1; i <= num + 1; i++)
				{
					for (int j = num2 - 1; j <= num2 + 1; j++)
					{
						if (i >= 0 && i < dataWidth && j >= 0 && j < dataHeight)
						{
							paintData[i, j] = true;
						}
					}
				}
			}
		}
		else if (currentState == State.TrailerMagicTransitionDelay && stateElapsedTics >= 150)
		{
			SetState(State.MagicTransition);
		}
		else if (currentState == State.MagicTransition && stateElapsedTics >= magicTransitionDuration)
		{
			UpgradeRelic();
			SetState(State.Done);
		}
	}

	protected virtual void UpgradeRelic()
	{
		Item relic = GetRelic();
		string groupId = relic.GetGroupId();
		Inventory.Singleton.RemoveItem(relic);
		relic.level++;
		Inventory.Singleton.AddItem(relic);
		Weapon weapon = relic as Weapon;
		if (weapon != null)
		{
			UtilityBeltKeyShortcuts.singleton.ReportCraft(relic.id, groupId, weapon.handType, weapon);
		}
	}

	private void EmitSplatter(int x, int y)
	{
		SfxController.singleton.Play("paint_splat");
		Transform obj = splatterEmitter.transform;
		Vector3 position = obj.position;
		position.x = x;
		position.y = y;
		obj.position = position;
		splatterEmitter.Emit();
	}

	private void HandleParticlesEmitted(AsciiParticle[] particles)
	{
		for (int i = 0; i < particles.Length; i++)
		{
			if (!(particles[i] == null))
			{
				Color[] colorProgression = particles[i].colorProgression;
				colorProgression[0] = selectedRarityColor;
				colorProgression[1] = selectedRarityColor;
			}
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (!background.loaded || !foreground.loaded)
		{
			return;
		}
		if (currentState == State.Painting || currentState == State.TrailerMagicTransitionDelay)
		{
			float t = (float)stateElapsedTics / 18f;
			Color overrideForeground = Color.Lerp(Color.black, Color.white, t);
			background.Draw(r, offsetX, offsetY, overrideForeground, ColorConstants.black);
			overrideForeground = Color.Lerp(Color.black, previousRarityColor, t);
			foreground.Draw(r, offsetX, offsetY, overrideForeground);
			overrideForeground = Color.Lerp(Color.black, selectedRarityColor, t);
			AsciiData.Page currentPage = foreground.GetCurrentPage();
			paintingComplete = true;
			for (int i = 0; i < currentPage.width; i++)
			{
				for (int j = 0; j < currentPage.height; j++)
				{
					if (currentPage.Data[i][j] == -1)
					{
						continue;
					}
					AsciiCellProcedural cell = r.GetCell(i + offsetX - foreground.pivotX, j + offsetY - foreground.pivotY);
					if (cell != null && cell.GetValue() > 0 && cell.GetValue() != 32)
					{
						if (i < dataWidth && j < dataHeight && paintData[i, j])
						{
							cell.SetForeground(overrideForeground);
						}
						else
						{
							paintingComplete = false;
						}
					}
				}
			}
		}
		else if (currentState == State.MagicTransition)
		{
			float num = Mathf.Clamp01((float)stateElapsedTics / 6f);
			Color b = new Color(0.25f, 0.25f, 0.25f);
			Color overrideForeground2 = Color.Lerp(Color.white, b, num);
			background.Draw(r, offsetX, offsetY, overrideForeground2, ColorConstants.black);
			foreground.Draw(r, offsetX, offsetY, Color.Lerp(selectedRarityColor, b, num / 2f));
			offsetX += magicOffsetX;
			offsetY += magicOffsetY;
			transitionAnimation.Sprite.Draw(r, offsetX, offsetY, ColorConstants.black, selectedRarityColor);
		}
	}

	public static Color GetColorForDifficulty(int difficulty)
	{
		return GetColorForLevel(GetRelicLevelForDifficulty(difficulty));
	}

	public static int GetRelicLevelForDifficulty(int difficulty)
	{
		return Mathf.FloorToInt(((float)difficulty - 1f) / 5f) + 1;
	}

	public static Color GetColorForLevel(int level)
	{
		return level switch
		{
			2 => ColorConstants.rarityUncommon, 
			3 => ColorConstants.rarityRare, 
			4 => ColorConstants.rarityHeroic, 
			5 => ColorConstants.rarityEpic, 
			6 => ColorConstants.rarityLegendary, 
			_ => ColorConstants.white, 
		};
	}

	private void Start()
	{
		background.Load();
		foreground.Load();
		transitionAnimation.Sprite.Load();
		splatterEmitter.OnParticlesEmitted += HandleParticlesEmitted;
	}

	private void OnDestroy()
	{
		if (splatterEmitter != null)
		{
			splatterEmitter.OnParticlesEmitted -= HandleParticlesEmitted;
		}
	}
}

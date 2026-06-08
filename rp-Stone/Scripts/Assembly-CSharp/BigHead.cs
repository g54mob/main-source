using System;
using UnityEngine;

[RequireComponent(typeof(AsciiSprite))]
public class BigHead : MonoBehaviour
{
	private const bool DEBUG_SEARCH_AREA = false;

	public static float treasureTime;

	public static float seeingBossTime;

	public static Action<AsciiRenderProcedural, int, int> OnPostDraw;

	private AsciiSprite mySprite;

	private string customFace;

	public void Reset()
	{
		treasureTime = 0f;
		seeingBossTime = 0f;
		customFace = null;
	}

	public void UpdateTic()
	{
		customFace = null;
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color bodyColor)
	{
		if (TryDraw(r, offsetX, offsetY - 2, bodyColor))
		{
			FirePostDraw(r, offsetX, offsetY);
		}
		else
		{
			if ((bool)GameStates.Singleton.hero.RightHand && GameStates.Singleton.hero.RightHand.tags.Contains("mask"))
			{
				return;
			}
			int[] array = new int[4] { 1, 0, -1, 0 };
			int[] array2 = new int[4] { 0, 1, 0, -1 };
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 1;
			int num5 = 0;
			for (int i = 0; i < 88; i++)
			{
				if (num >= -4 && num <= 4 && num2 >= -5 && num2 <= 1)
				{
					int offsetX2 = offsetX + num;
					int num6 = offsetY + num2 - 2;
					if (TryDraw(r, offsetX2, num6, bodyColor))
					{
						FirePostDraw(r, offsetX2, num6 + 2);
						break;
					}
				}
				num += array[num3];
				num2 += array2[num3];
				num5++;
				if (num5 == num4)
				{
					num5 = 0;
					num3 = (num3 + 1) % 4;
					if (num3 % 2 == 0)
					{
						num4++;
					}
				}
			}
		}
	}

	private void FirePostDraw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (OnPostDraw != null)
		{
			OnPostDraw(r, offsetX, offsetY);
		}
	}

	private bool TryDraw(AsciiRenderProcedural r, int offsetX, int offsetY, Color bodyColor)
	{
		AsciiCellProcedural cell = r.GetCell(offsetX, offsetY);
		if (cell != null && cell.GetValue() == 79)
		{
			if (!base.enabled)
			{
				return true;
			}
			if (GameStates.Singleton.CurrentState > GameStates.State.MainMenu && !HeroSettings.bigHeadEnabled)
			{
				return true;
			}
			SelectFrame();
			mySprite.Draw(r, offsetX, offsetY, bodyColor);
			if (customFace != null)
			{
				for (int i = 1; i < customFace.Length && i < 5; i++)
				{
					char c = customFace[i];
					int num = SpecialSymbols.Map(c);
					if (num >= 0)
					{
						r.SetCell(offsetX - 2 + i, offsetY - 1, num);
					}
					else
					{
						r.SetCell(offsetX - 2 + i, offsetY - 1, c);
					}
				}
			}
			return true;
		}
		return false;
	}

	private void SelectFrame()
	{
		Hero hero = GameStates.Singleton.hero;
		if (hero.CurrentState == Hero.State.PickingUp)
		{
			mySprite.SetFrameIndex(1);
		}
		else if (treasureTime > 0f)
		{
			mySprite.SetFrameIndex(3);
		}
		else if (seeingBossTime > 0f)
		{
			mySprite.SetFrameIndex(4);
		}
		else if (hero.CurrentState == Hero.State.Choked)
		{
			mySprite.SetFrameIndex(6);
		}
		else if (Mathf.Repeat(Time.realtimeSinceStartup, 4f) < 0.25f)
		{
			mySprite.SetFrameIndex(7);
		}
		else
		{
			mySprite.SetFrameIndex(0);
		}
		mySprite.flipX = hero.lookDirection == Character.LookDirection.Left;
	}

	public string GetFacialExpression()
	{
		if (!base.enabled || !HeroSettings.bigHeadEnabled)
		{
			return "";
		}
		Hero hero = GameStates.Singleton.hero;
		if (hero.CurrentState == Hero.State.PickingUp)
		{
			return "( ,,)";
		}
		if (treasureTime > 0f)
		{
			return "( ^^)";
		}
		if (seeingBossTime > 0f)
		{
			return "('°°)";
		}
		if (hero.CurrentState == Hero.State.Choked)
		{
			return "( xx)";
		}
		if (Mathf.Repeat(Time.realtimeSinceStartup, 4f) < 0.25f)
		{
			return "(   )";
		}
		if (customFace != null)
		{
			return customFace;
		}
		return "( '')";
	}

	public void SetFacialExpression(string str)
	{
		if (base.enabled && HeroSettings.bigHeadEnabled)
		{
			customFace = str;
		}
	}

	private void Update()
	{
		if (!AsciiAnimation.gameplayPaused)
		{
			treasureTime -= Time.deltaTime;
			seeingBossTime -= Time.deltaTime;
		}
	}

	private void Start()
	{
		Reset();
	}

	private void Awake()
	{
		mySprite = GetComponent<AsciiSprite>();
	}
}

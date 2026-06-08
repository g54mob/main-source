using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHelmet : MonoBehaviour
{
	public enum State
	{
		Normal = 0,
		Broken = 1
	}

	public string pivotSymbol = "@";

	public string replacementSymbol = "\u00af";

	public AsciiAnimation helmetAnm;

	public AsciiAnimation brokenAnm;

	public string brokenSfx;

	public int searchOffsetX;

	public int searchOffsetY;

	public int searchOffsetWidth;

	public int searchOffsetHeight;

	private Enemy myEnemy;

	public State currentState { get; private set; }

	private void HandleTookDamage(Character c, Damage dmg)
	{
		if (c == myEnemy && currentState == State.Normal && myEnemy.Armor <= 0f)
		{
			myEnemy.armorPerSecond = 0f;
			myEnemy.Hitpoints = myEnemy.MaxHitpoints;
			brokenAnm.Play();
			SfxController.singleton.Play(brokenSfx);
			currentState = State.Broken;
		}
	}

	private void HandlePostDraw(Character c, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (pivotSymbol.Length <= 0)
		{
			return;
		}
		AsciiData.Page currentPage = c.MySprite.GetCurrentPage();
		if (currentPage == null)
		{
			return;
		}
		int num = SpecialSymbols.Map(pivotSymbol[0]);
		int num2 = c.MySprite.lastDrawX + searchOffsetX;
		int num3 = c.MySprite.lastDrawY + searchOffsetY;
		int num4 = num2 + currentPage.width + searchOffsetWidth;
		int num5 = num3 + currentPage.height + searchOffsetHeight;
		bool flag = false;
		int num6 = 0;
		int num7 = 0;
		for (num6 = num2; num6 < num4; num6++)
		{
			if (flag)
			{
				break;
			}
			for (num7 = num3; num7 < num5; num7++)
			{
				if (flag)
				{
					break;
				}
				AsciiCellProcedural cell = r.GetCell(num6, num7);
				if (cell != null && cell.GetValue() == num)
				{
					num2 = num6;
					num3 = num7;
					flag = true;
				}
			}
		}
		if (flag)
		{
			if (replacementSymbol.Length > 0)
			{
				int value = SpecialSymbols.Map(replacementSymbol[0]);
				r.SetCell(num2, num3, value);
			}
			if (currentState == State.Broken)
			{
				brokenAnm.Sprite.Draw(r, num2, num3, 1f, myEnemy.colorTint);
			}
			else
			{
				helmetAnm.Sprite.Draw(r, num2, num3, 1f, myEnemy.colorTint);
			}
		}
	}

	private void Start()
	{
		helmetAnm.Sprite.Load();
		brokenAnm.Sprite.Load();
	}

	private void Awake()
	{
		myEnemy = GetComponent<Enemy>();
		Character.OnCharacterTookDamage += HandleTookDamage;
		myEnemy.OnPostDrawCharacter += HandlePostDraw;
	}

	private void OnDestroy()
	{
		Character.OnCharacterTookDamage -= HandleTookDamage;
		myEnemy.OnPostDrawCharacter -= HandlePostDraw;
	}
}

using UnityEngine;

[RequireComponent(typeof(AsciiSprite))]
public class SpriteAccessory : MonoBehaviour
{
	public string pivotSymbol = "@";

	public string replacementSymbol = " ";

	public string specificEventId = "";

	public bool ignoreTint;

	public int searchOffsetX;

	public int searchOffsetY;

	public int searchOffsetWidth;

	public int searchOffsetHeight;

	public AsciiSprite accessorySprite;

	public bool playAnimationOnFirstDraw;

	public bool syncFrameIndex;

	private Color _tint = ColorConstants.white;

	private AsciiSprite mySprite;

	private bool firstDraw = true;

	public Color tint
	{
		get
		{
			return _tint;
		}
		set
		{
			_tint = value;
		}
	}

	public AsciiSprite Sprite
	{
		get
		{
			return mySprite;
		}
		set
		{
			if (mySprite != null)
			{
				mySprite.OnDraw -= HandleDraw;
			}
			mySprite = value;
			mySprite.OnDraw += HandleDraw;
		}
	}

	private void HandleDraw(AsciiSprite sprite, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (pivotSymbol.Length <= 0 || accessorySprite == null)
		{
			return;
		}
		AsciiData.Page currentPage = mySprite.GetCurrentPage();
		if (currentPage == null)
		{
			return;
		}
		if (firstDraw && playAnimationOnFirstDraw)
		{
			firstDraw = false;
			AsciiAnimation component = accessorySprite.GetComponent<AsciiAnimation>();
			if (component != null)
			{
				component.Play();
			}
		}
		else if (syncFrameIndex)
		{
			accessorySprite.SetFrameIndex(mySprite.GetFrameIndex());
		}
		int num = SpecialSymbols.Map(pivotSymbol[0]);
		int num2 = mySprite.lastDrawX + searchOffsetX;
		int num3 = mySprite.lastDrawY + searchOffsetY;
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
		if (!flag)
		{
			return;
		}
		if (replacementSymbol.Length > 0)
		{
			int value = SpecialSymbols.Map(replacementSymbol[0]);
			r.SetCell(num2, num3, value);
		}
		if (string.IsNullOrEmpty(specificEventId) || (EventController.singleton != null && EventController.singleton.IsEventActiveAndStarted(specificEventId) && EventController.singleton.CanPlayerSeeEvents()))
		{
			if (tint != ColorConstants.white && !ignoreTint)
			{
				accessorySprite.Draw(r, num2, num3, 1f, tint);
			}
			else
			{
				accessorySprite.Draw(r, num2, num3, 1f);
			}
		}
	}

	private void Awake()
	{
		mySprite = GetComponent<AsciiSprite>();
		mySprite.OnDraw += HandleDraw;
	}

	private void OnDestroy()
	{
		mySprite.OnDraw -= HandleDraw;
	}
}

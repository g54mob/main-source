using UnityEngine;

[RequireComponent(typeof(AsciiSprite))]
public abstract class LevelColoredSoulStoneIcon : MonoBehaviour
{
	public AsciiSprite backgroundSprite;

	public AsciiSprite foregroundSprite;

	public AsciiSprite rainbowSprite;

	public Color backgroundColorOverride = ColorConstants.lightGrey;

	public int levelColorOffset;

	private AsciiSprite mySprite;

	private bool recursionStop;

	protected abstract int GetItemLevel();

	private void HandleDraw(AsciiSprite sprite, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (recursionStop)
		{
			return;
		}
		recursionStop = true;
		float lastColorMultiply = sprite.lastColorMultiply;
		int num = GetItemLevel() + levelColorOffset;
		if (num > 1)
		{
			backgroundSprite.Draw(r, offsetX, offsetY, backgroundColorOverride * lastColorMultiply);
			if (num >= 7 && rainbowSprite != null)
			{
				rainbowSprite.Draw(r, offsetX, offsetY, lastColorMultiply);
			}
			else
			{
				Color colorForLevel = UpgradeRelicScreen.GetColorForLevel(num);
				foregroundSprite.Draw(r, offsetX, offsetY, colorForLevel * lastColorMultiply);
			}
		}
		recursionStop = false;
	}

	private void Start()
	{
		mySprite = GetComponent<AsciiSprite>();
		mySprite.OnDraw += HandleDraw;
		foregroundSprite.Load();
	}

	private void OnDestroy()
	{
		if (mySprite != null)
		{
			mySprite.OnDraw -= HandleDraw;
		}
	}
}

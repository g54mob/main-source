using UnityEngine;

[RequireComponent(typeof(AsciiSprite))]
public class XpStoneIcon : MonoBehaviour
{
	public AsciiSprite wideSprite;

	public AsciiString xpNumberLabel;

	private AsciiSprite mySprite;

	private int lastXpValue = -1;

	private void HandleDraw(AsciiSprite sprite, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		int currentLevel = XPController.singleton.currentLevel;
		if (lastXpValue != currentLevel)
		{
			lastXpValue = currentLevel;
			if (currentLevel == 0)
			{
				xpNumberLabel.SetValue("O");
			}
			else
			{
				xpNumberLabel.SetValue(currentLevel.ToString());
			}
		}
		if (currentLevel >= 10 && currentLevel <= 99)
		{
			wideSprite.Draw(r, offsetX, offsetY);
		}
		xpNumberLabel.Draw(r, offsetX, offsetY);
	}

	private void Start()
	{
		mySprite = GetComponent<AsciiSprite>();
		mySprite.OnDraw += HandleDraw;
		wideSprite.Load();
	}

	private void OnDestroy()
	{
		if (mySprite != null)
		{
			mySprite.OnDraw -= HandleDraw;
		}
	}
}

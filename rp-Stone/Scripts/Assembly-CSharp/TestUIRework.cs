using UnityEngine;

public class TestUIRework : MonoBehaviour
{
	public enum ItemLayout
	{
		HeroFirst = 0,
		HeroMiddle = 1,
		HeroLast = 2
	}

	public AsciiMouse mouse;

	public AsciiSprite questList;

	public AsciiSprite itemHero;

	public AsciiSprite itemLeft;

	public AsciiSprite itemRight;

	public AsciiSprite itemList;

	public DialogButton locationsButton;

	public DialogButton workstationButton;

	public DialogButton itemsButton;

	public DialogButton hatcheryButton;

	public DialogButton locationsButtonRight;

	public DialogButton workstationButtonRight;

	public DialogButton itemsButtonRight;

	public DialogButton hatcheryButtonRight;

	public AsciiSprite fancySelection;

	public Separator verticalSeparator;

	public ItemLayout itemLayoutType;

	private const float timePerTic = 0.03333333f;

	private float accumulatedTicTime;

	private void Start()
	{
		hatcheryButton.OnPressed += HandleHatcheryPressed;
		hatcheryButtonRight.OnPressed += HandleHatcheryPressed;
		itemHero.Load();
		itemLeft.Load();
		itemRight.Load();
		itemList.Load();
		fancySelection.Load();
	}

	private void HandleHatcheryPressed(DialogButton button)
	{
		itemLayoutType = (ItemLayout)((int)(itemLayoutType + 1) % 3);
	}

	private void UpdateTic()
	{
		if (itemLayoutType == ItemLayout.HeroFirst)
		{
			locationsButtonRight.UpdateTic();
			workstationButtonRight.UpdateTic();
			itemsButtonRight.UpdateTic();
			hatcheryButtonRight.UpdateTic();
		}
		else
		{
			locationsButton.UpdateTic();
			workstationButton.UpdateTic();
			itemsButton.UpdateTic();
			hatcheryButton.UpdateTic();
		}
		mouse.UpdateTic();
	}

	private void DoDraw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (itemLayoutType == ItemLayout.HeroFirst)
		{
			verticalSeparator.Draw(r, 42, 0);
			locationsButtonRight.Draw(r, 0, 0);
			workstationButtonRight.Draw(r, 0, 0);
			itemsButtonRight.Draw(r, 0, 0);
			hatcheryButtonRight.Draw(r, 0, 0);
		}
		else
		{
			locationsButton.Draw(r, 0, 0);
			workstationButton.Draw(r, 0, 0);
			itemsButton.Draw(r, 0, 0);
			hatcheryButton.Draw(r, 0, 0);
			ToggleButton selectedButton = GetComponent<ToggleButtonGroup>().selectedButton;
			fancySelection.Draw(r, selectedButton.PositionX, selectedButton.PositionY);
		}
		int offsetX2 = 0;
		int offsetY2 = 2;
		int offsetX3 = 0;
		int offsetY3 = 7;
		int offsetX4 = 0;
		int offsetY4 = 13;
		int offsetX5 = 0;
		int offsetY5 = 0;
		if (itemLayoutType == ItemLayout.HeroFirst)
		{
			offsetX2 = (offsetX3 = (offsetX4 = 4));
			offsetX5 = 17;
		}
		else if (itemLayoutType == ItemLayout.HeroMiddle)
		{
			offsetX2 = (offsetX3 = (offsetX4 = 24));
			offsetX5 = 38;
		}
		else if (itemLayoutType == ItemLayout.HeroLast)
		{
			offsetX2 = (offsetX3 = (offsetX4 = 70));
			offsetX5 = 25;
		}
		itemHero.Draw(r, offsetX2, offsetY2);
		itemLeft.Draw(r, offsetX3, offsetY3);
		itemRight.Draw(r, offsetX4, offsetY4);
		itemList.Draw(r, offsetX5, offsetY5);
		mouse.Draw(r, 0, 0);
	}

	private void LateUpdate()
	{
		accumulatedTicTime += Utils.deltaTime;
		while (accumulatedTicTime >= 0.03333333f)
		{
			accumulatedTicTime -= 0.03333333f;
			UpdateTic();
		}
		AsciiRenderProcedural asciiRenderProcedural = Object.FindObjectOfType<AsciiRenderProcedural>();
		asciiRenderProcedural.Clear();
		DoDraw(asciiRenderProcedural, 0, 0);
		asciiRenderProcedural.Push();
	}
}

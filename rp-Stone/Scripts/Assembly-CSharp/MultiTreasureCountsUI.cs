using System.Collections.Generic;
using UnityEngine;

public class MultiTreasureCountsUI : MonoBehaviour
{
	public int positionX;

	public int positionY;

	public AsciiSprite humbleTreasureSprite;

	public AsciiSprite commonTreasureSprite;

	public AsciiSprite greatTreasureSprite;

	public AsciiSprite omegaTreasureSprite;

	public AsciiSprite deltaTreasureSprite;

	public AsciiSprite skullnataSprite;

	public AsciiSprite goldTreasureSprite;

	public AsciiSprite emeraldEggSprite;

	public AsciiSprite rubyEggSprite;

	public AsciiSprite sapphireEggSprite;

	public Color labelColor = Color.white;

	private readonly int[] TREASURE_OFFSETS = new int[6] { 0, -5, -7, -11, -12, -13 };

	private readonly int[] TREASURE_DISTANCES = new int[6] { 0, 9, 7, 7, 6, 5 };

	private int treasureOffsetX = -10;

	private int treasureDistance = 7;

	private List<AsciiSprite> treasureSprites;

	private List<AsciiString> treasureLabels;

	private List<AsciiSprite> treasureSpritesToDraw;

	private List<AsciiString> treasureLabelsToDraw;

	public void Clear()
	{
		Init();
		treasureSpritesToDraw.Clear();
		treasureLabelsToDraw.Clear();
	}

	public void DisplayTreasure(int index, float amount)
	{
		Init();
		if (index < treasureLabels.Count)
		{
			string value = "x" + amount.ToString("0.#");
			treasureLabels[index].SetValue(value);
			SelectTreasure(index);
		}
	}

	private void SelectTreasure(int index)
	{
		treasureSpritesToDraw.Add(treasureSprites[index]);
		treasureLabelsToDraw.Add(treasureLabels[index]);
		int num = treasureSpritesToDraw.Count - 1;
		treasureOffsetX = TREASURE_OFFSETS[num];
		treasureDistance = TREASURE_DISTANCES[num];
	}

	private void Init()
	{
		if (treasureSprites == null)
		{
			treasureSprites = new List<AsciiSprite>();
			treasureLabels = new List<AsciiString>();
			treasureSpritesToDraw = new List<AsciiSprite>();
			treasureLabelsToDraw = new List<AsciiString>();
			treasureSprites.Add(humbleTreasureSprite);
			treasureSprites.Add(commonTreasureSprite);
			treasureSprites.Add(greatTreasureSprite);
			treasureSprites.Add(omegaTreasureSprite);
			treasureSprites.Add(deltaTreasureSprite);
			treasureSprites.Add(skullnataSprite);
			treasureSprites.Add(goldTreasureSprite);
			treasureSprites.Add(emeraldEggSprite);
			treasureSprites.Add(rubyEggSprite);
			treasureSprites.Add(sapphireEggSprite);
			treasureLabels.Add(NewTreasureCountLabel());
			treasureLabels.Add(NewTreasureCountLabel());
			treasureLabels.Add(NewTreasureCountLabel());
			treasureLabels.Add(NewTreasureCountLabel());
			treasureLabels.Add(NewTreasureCountLabel());
			treasureLabels.Add(NewTreasureCountLabel());
			treasureLabels.Add(NewTreasureCountLabel());
			treasureLabels.Add(NewTreasureCountLabel());
			treasureLabels.Add(NewTreasureCountLabel());
			treasureLabels.Add(NewTreasureCountLabel());
		}
	}

	private AsciiString NewTreasureCountLabel()
	{
		return new AsciiString
		{
			color = labelColor,
			alignment = AsciiString.Alignment.Center
		};
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		Init();
		offsetX += positionX + treasureOffsetX;
		offsetY += positionY;
		for (int i = 0; i < treasureSpritesToDraw.Count; i++)
		{
			treasureSpritesToDraw[i].Draw(r, offsetX, offsetY);
			treasureLabelsToDraw[i].Draw(r, offsetX, offsetY + 2);
			offsetX += treasureDistance;
		}
	}
}

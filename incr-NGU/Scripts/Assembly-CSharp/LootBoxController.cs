using UnityEngine;

public class LootBoxController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public void openExpBox()
	{
		if (character.lootBoxes.expBoxCount <= 0)
		{
			tooltip.showTooltip("You don't have any EXP boxes, dummy!");
			return;
		}
		character.lootBoxes.expBoxCount--;
		expBoxReward();
	}

	private void expBoxReward()
	{
		Random.state = character.lootBoxes.expBoxState;
		float value = Random.value;
		float num = 0f;
		character.lootBoxes.expBoxState = Random.state;
		if (value <= (num += 0.005f))
		{
			character.addExp(100L);
			tooltip.showTooltip("Holy balls, you just got 100 EXP!", 2f);
		}
		else if (value < (num += 0.01f))
		{
			character.addExp(50L);
			tooltip.showTooltip("You found 50 EXP! Jeez, you're lucky!", 2f);
		}
		else if (value < (num += 0.02f))
		{
			character.addExp(25L);
			tooltip.showTooltip("You found 25 EXP! Nice RNG there, buddy!", 2f);
		}
		else if (value < (num += 0.05f))
		{
			character.addExp(10L);
			tooltip.showTooltip("You found 10 EXP! Pretty sweet!", 2f);
		}
		else if (value < (num += 0.1f))
		{
			character.addExp(5L);
			tooltip.showTooltip("You found 5 EXP! Not bad at all!", 2f);
		}
		else if (value < (num += 0.25f))
		{
			character.addExp(2L);
			tooltip.showTooltip("You found 2 EXP! Hey, any EXP is nice to have, right?", 2f);
		}
		else if (value < (num += 0.5f))
		{
			character.addExp(1L);
			tooltip.showTooltip("You found 1 EXP! ... a little underwhelming.", 2f);
		}
		else
		{
			tooltip.showTooltip("You found 0 EXP! Wait, what? What a ripoff!", 2f);
		}
	}
}

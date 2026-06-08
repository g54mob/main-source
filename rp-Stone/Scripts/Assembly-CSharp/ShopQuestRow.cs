using UnityEngine;

public class ShopQuestRow : QuestRow
{
	protected override void Awake()
	{
		base.Awake();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.mode = ((!IsNewIndicating()) ? Mode.Normal : Mode.NormalWithCost);
		base.Draw(r, offsetX, offsetY);
	}

	public override bool IsNewIndicating()
	{
		return base.IsNewIndicating();
	}

	public override Color GetNewIndicatorColor()
	{
		return base.GetNewIndicatorColor();
	}

	public override string GetNewIndicatorString()
	{
		return base.GetNewIndicatorString();
	}
}

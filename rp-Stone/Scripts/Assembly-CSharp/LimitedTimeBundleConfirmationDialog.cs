using UnityEngine;

public class LimitedTimeBundleConfirmationDialog : GateShopBuyConfirmationDialog
{
	public AsciiMultiColorTextBox specialDescription;

	public AsciiString percentOffLabel;

	private AsciiRenderProcedural.Clip myClip;

	private int lastScreenHeight;

	public override void Setup(ShopData.Entry entryData, Item inventoryItem = null)
	{
		base.Setup(entryData, inventoryItem);
		if (entryData.percentOff != 0)
		{
			percentOffLabel.backgroundColor = new Color(0.29803923f, 0.41960785f, 2f / 15f);
			percentOffLabel.SetValue(" -" + entryData.percentOff + "% ");
		}
		else
		{
			percentOffLabel.Clear();
		}
	}

	protected override void RecalculateHeight()
	{
		AsciiRenderProcedural asciiRenderer = GameStates.Singleton.asciiRenderer;
		lastScreenHeight = asciiRenderer.height;
		iconPadTop = 2 + Mathf.Min(5, specialDescription.lineCount);
		trimSeparator = true;
		trimIconTop = asciiRenderer.height <= 25 && specialDescription.lineCount >= 5;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (r.height != lastScreenHeight)
		{
			RecalculateHeight();
		}
		PositionX = 0;
		PositionY = 0;
		Width = r.width;
		Height = r.height;
		base.forceDrawRegardlessOfState = true;
		int num = (int)((float)Width * scaleX);
		int num2 = (int)((float)Height * scaleY);
		myClip.left = r.width - num >> 1;
		myClip.right = myClip.left;
		myClip.top = r.height - num2 >> 1;
		myClip.bottom = myClip.top;
		r.PushClip(myClip);
		base.Draw(r, offsetX, offsetY);
		specialDescription.Draw(r, r.width >> 1, offsetY);
		icon.Draw(r, icon.lastDrawX + icon.pivotX, icon.lastDrawY + icon.pivotY);
		percentOffLabel.Draw(r, buyCashButton.lastDrawnX, buyCashButton.lastDrawnY);
		r.PopClip();
	}
}

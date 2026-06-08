using UnityEngine;

public class UulaaFakeShopFTUE : MonoBehaviour
{
	public UulaaShopSlot crystalSlot;

	public DialogNineSlice hiddenSlot;

	private bool isActive;

	private float slideX = 90f;

	private void Update()
	{
		if (isActive)
		{
			slideX = Mathf.Lerp(slideX, 0f, Time.deltaTime * 8f);
		}
	}

	public void UpdateTic()
	{
		isActive = true;
		crystalSlot.UpdateTic();
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += Mathf.RoundToInt(slideX);
		DrawHiddenSlot(r, offsetX + crystalSlot.Width - 1, offsetY);
		DrawHiddenSlot(r, offsetX, offsetY + crystalSlot.Height - 1);
		DrawHiddenSlot(r, offsetX + crystalSlot.Width - 1, offsetY + crystalSlot.Height - 1);
		crystalSlot.Draw(r, offsetX, offsetY);
	}

	private void DrawHiddenSlot(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		hiddenSlot.Draw(r, offsetX + crystalSlot.PositionX, offsetY + crystalSlot.PositionY);
	}
}

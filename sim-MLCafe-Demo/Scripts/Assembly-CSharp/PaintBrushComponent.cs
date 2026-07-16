using UnityEngine;

public class PaintBrushComponent : MonoBehaviour
{
	[SerializeField]
	private Color startColor = Color.white;

	[SerializeField]
	private Color currentColor = Color.white;

	private int index;

	private void Start()
	{
		currentColor = startColor;
		GetComponentInChildren<MeshRenderer>().material.SetColor("_Gradient_Bottom", startColor);
		InputManager.OnCancleClick.AddListener(SwitchColor);
	}

	public void SwitchColor()
	{
		if (GlobalReferences.GetCharacterController().socket.IsHoldingItem() && GlobalReferences.GetCharacterController().socket.GetItemComponent().GetComponent<PaintBrushComponent>() == this)
		{
			AssignColor(ColorPaletteManager.Palette.Wall);
		}
	}

	public void AssignColor(ColorPaletteManager.Palette palette)
	{
		index++;
		if (index >= ColorPaletteManager.GetPalette(palette).Length)
		{
			index = 0;
		}
		currentColor = ColorPaletteManager.GetPalette(palette)[index];
		GetComponentInChildren<MeshRenderer>().material.SetColor("_Gradient_Bottom", currentColor);
	}

	public Color GetColor()
	{
		return currentColor;
	}
}

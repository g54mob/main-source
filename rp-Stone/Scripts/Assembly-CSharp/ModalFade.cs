using UnityEngine;

public class ModalFade : MonoBehaviour
{
	public float velocity = 7f;

	public float opacity = 0.75f;

	public Color color = Color.black;

	private float modalFade;

	public bool active { get; set; }

	public float Alpha => modalFade;

	private void Update()
	{
		if (active)
		{
			modalFade += Utils.deltaTime * velocity;
		}
		else
		{
			modalFade -= Utils.deltaTime * velocity;
		}
		modalFade = Mathf.Clamp(modalFade, 0f, opacity);
	}

	public void JumpToTargetOpacity()
	{
		if (active)
		{
			modalFade = opacity;
		}
		else
		{
			modalFade = 0f;
		}
	}

	public void ApplyModalFadeToCell(AsciiCellProcedural cell)
	{
		cell.ClearInteractionLayer();
		Color foreground = cell.GetForeground();
		foreground = Color.Lerp(foreground, color, modalFade);
		cell.SetForeground(foreground);
		foreground = cell.GetBackground();
		foreground = Color.Lerp(foreground, color, modalFade);
		cell.SetBackground(foreground);
	}

	public void Draw(AsciiRenderProcedural r)
	{
		if (!(modalFade > 0f))
		{
			return;
		}
		for (int i = 0; i < r.width; i++)
		{
			for (int j = 0; j < r.height; j++)
			{
				AsciiCellProcedural cell = r.GetCell(i, j);
				ApplyModalFadeToCell(cell);
			}
		}
	}
}

using UnityEngine;

public class PlayItemNavigationBar : MonoBehaviour
{
	public AsciiTextBox questNameBox;

	public DialogButton backButton;

	public int width = 21;

	public int iconX = 11;

	public int iconY = 18;

	public int maxLeftMargin = 3;

	public float leftMarginPercentOfSpace = 0.4f;

	public float midMarginPercentOfSpace = 0.45f;

	private AsciiSprite questIcon;

	public void SetQuestData(Data.Quest questData)
	{
		SetData(questData.name, questData.iconId);
	}

	public void SetData(string name, string iconPath)
	{
		questNameBox.Text = Te.xt(name);
		if (iconPath != null)
		{
			questIcon = IconLoader.Singleton.GetSharedIcon(iconPath);
		}
		else
		{
			questIcon = null;
		}
	}

	public void UpdateTic()
	{
		backButton.UpdateTic();
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		questNameBox.Draw(r, offsetX, offsetY - questNameBox.lineCount);
		if ((bool)questIcon)
		{
			questIcon.Draw(r, offsetX + iconX, offsetY + iconY);
		}
		backButton.Draw(r, offsetX, offsetY);
	}

	public int ComputeLeftMargin(int emptySpace)
	{
		return Mathf.Min(maxLeftMargin, Mathf.RoundToInt((float)emptySpace * leftMarginPercentOfSpace));
	}

	public int ComputeMidMargin(int emptySpace)
	{
		return Mathf.RoundToInt((float)(emptySpace - ComputeLeftMargin(emptySpace)) * midMarginPercentOfSpace);
	}

	private void HandleBackButtonPressed(DialogButton button)
	{
	}

	private void Awake()
	{
		backButton.OnPressed += HandleBackButtonPressed;
	}
}

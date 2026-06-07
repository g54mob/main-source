using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_TetrisCardRune : MonoBehaviour
{
	public enum eStatus
	{
		EMPTY = 0,
		ACTIVATED = 1,
		USED = 2
	}

	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private Image image_BG;

	public void SetStatus(eStatus status)
	{
	}

	public void SetRuneIcon(Sprite icon)
	{
	}

	public void SetRuneBGColor(Color color)
	{
	}
}

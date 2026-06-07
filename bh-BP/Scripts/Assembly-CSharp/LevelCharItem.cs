using UnityEngine;
using UnityEngine.UI;

public class LevelCharItem : MonoBehaviour
{
	public Image Img;

	public Image ImgState;

	public CoolButton Btn;

	public LevelType TgtLvl;

	public int TgtNGPlus;

	public CharType TgtChar;

	public int TgtDiff;

	private void Awake()
	{
	}

	public void Init(LevelData lvlData, CharMetaInst c, int diff)
	{
	}

	private void OnHover()
	{
	}

	private void OnHoverExit()
	{
	}
}

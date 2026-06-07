using UnityEngine;
using UnityEngine.UI;

public class AssignWorkerItem : MonoBehaviour
{
	public RectTransform Xfm;

	public CoolButton Btn;

	public Image ImgIcon;

	public Image WrapperStatus;

	public Image ImgStatus;

	public int Idx;

	private CharMetaInst _char;

	private void Awake()
	{
	}

	public void Init(int i, CharMetaInst c)
	{
	}

	public void InitEmpty()
	{
	}

	public CharMetaInst GetChar()
	{
		return null;
	}

	private void OnClicked()
	{
	}

	private void OnHoverEnter()
	{
	}

	private void OnHoverExit()
	{
	}
}

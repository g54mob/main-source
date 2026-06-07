using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkerItem : MonoBehaviour
{
	public int Idx;

	public RectTransform Xfm;

	public CoolButton Btn;

	public Image ImgIcon;

	public TextMeshProUGUI TxtLvl;

	public Image ImgCapacityBacking;

	public TextMeshProUGUI TxtCapacity;

	public bool CanWork;

	public bool IsActive;

	public CoolButtonViz VizActive;

	public CoolButtonViz VizInactive;

	public Image WrapperStatus;

	public Image ImgStatus;

	private CharMetaInst _tgtChar;

	public CoolButton BtnMoveLeft;

	public CoolButton BtnMoveRight;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnResolutionChanged()
	{
	}

	public void Init(int oIdx, CharMetaInst w)
	{
	}

	public void SetActive(bool ac)
	{
	}

	public CharMetaInst GetWorker()
	{
		return null;
	}

	public bool IsEmpty()
	{
		return false;
	}

	private void OnClicked()
	{
	}

	public CharMetaInst GetTgtChar()
	{
		return null;
	}

	private void OnHoverEnter()
	{
	}

	private void OnHoverExit()
	{
	}

	public void OnLeftClicked()
	{
	}

	public void OnRightClicked()
	{
	}
}

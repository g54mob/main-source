using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MasseuseItem : MonoBehaviour
{
	public int Idx;

	public RectTransform Xfm;

	public CoolButton Btn;

	private CharMetaInst _tgtChar;

	public Image ImgIcon;

	public Image ImgStaminaBacking;

	public Image ImgStamina;

	public TextMeshProUGUI TxtStamina;

	public Image WrapperStatus;

	public Image ImgStatus;

	public TextMeshProUGUI TxtCost;

	public int MasseuseCost;

	private void Awake()
	{
	}

	public void Init(int oIdx, CharMetaInst w)
	{
	}

	private void OnDestroy()
	{
	}

	private void OnResolutionChanged()
	{
	}

	private void OnClicked()
	{
	}
}

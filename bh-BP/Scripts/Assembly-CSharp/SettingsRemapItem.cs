using I2.Loc;
using Rewired;
using UnityEngine;
using UnityEngine.UI;

public class SettingsRemapItem : MonoBehaviour
{
	public SettingsScreen Owner;

	public RectTransform Xfm;

	public CoolButton Btn;

	public GameActionType TgtAction;

	public RectTransform WrapperMap;

	public CoolButton BtnMap1;

	public Localize LocAction;

	public Image ImgMappedBtn;

	public Localize LocMappedBtn;

	public RectTransform WrapperMap2;

	public CoolButton BtnMap2;

	public Image ImgMappedBtn2;

	public Localize LocMappedBtn2;

	public Pole AxisContribution;

	private bool _isPressValid;

	private void Awake()
	{
	}

	public void Init(GameActionType action, Pole axisContrib)
	{
	}

	private void OnPressed()
	{
	}

	private void OnClicked()
	{
	}

	private void OnBtn1Pressed()
	{
	}

	private void OnBtn1Clicked()
	{
	}

	private void OnBtn2Pressed()
	{
	}

	private void OnBtn2Clicked()
	{
	}

	public void SetSelected(bool isSelected, int idx)
	{
	}
}

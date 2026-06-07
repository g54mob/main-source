using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplayItem : MonoBehaviour
{
	public StatDisplayGroup Owner;

	public Image ImgIcon;

	public Localize LocLabel;

	public TextMeshProUGUI TxtValue;

	public TextMeshProUGUI TxtChange;

	private int _changeAmt;

	public Image ImgConnector;

	public TextMeshProUGUI TxtScaling;

	public CoolButton BtnLabel;

	public CoolButton BtnScaling;

	private int _numConnections;

	public StatType Type;

	private void Awake()
	{
	}

	private void InitInternal(CharType c, StatType t)
	{
	}

	public void InitGame(StatType t)
	{
	}

	public void InitChar(CharInfo hInf, StatType t)
	{
	}

	public void InitChar(CharMetaInst hInf, StatType t)
	{
	}

	public void SetChangeAmt(int amt)
	{
	}

	public void AddChangeAmt(int amt)
	{
	}

	private void OnScalingHover()
	{
	}

	private void OnScalingHoverExit()
	{
	}

	private void OnLabelHover()
	{
	}

	private void OnLabelHoverExit()
	{
	}
}

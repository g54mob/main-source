using I2.Loc;
using TMPro;
using UnityEngine;

public class StatPropDisplayItem : MonoBehaviour
{
	public Localize LocLabel;

	public TextMeshProUGUI TxtValue;

	public TextMeshProUGUI TxtChange;

	public StatPropType Type;

	public StatPropDisplayType DispType;

	private int _displayedInt;

	private int _displayedIntMax;

	private float _displayedFloat;

	private void InitInternal(StatPropType t)
	{
	}

	public void InitChar(CharMetaInst hInf, StatPropType t)
	{
	}

	public void InitEmpty()
	{
	}

	public void InitGame(StatPropType t)
	{
	}

	public void CheckForChange()
	{
	}
}

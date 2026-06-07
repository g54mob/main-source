using System.Collections.Generic;
using UnityEngine;

public class StatDisplayGroup : MonoBehaviour
{
	public bool NoChange;

	public bool AddPropSpacing;

	public bool ShowScaling;

	public StatDisplayItem[] StatItems;

	public List<UISpacer> Spacers;

	public void InitGame()
	{
	}

	public void InitChar(CharMetaInst hInst)
	{
	}

	public void SetChangeAmt(StatType t, int amt)
	{
	}

	public void AddChangeAmt(StatType t, int amt)
	{
	}

	private void PopulateIfNeeded()
	{
	}
}
